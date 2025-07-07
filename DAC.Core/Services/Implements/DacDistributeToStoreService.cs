using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacDistributeToStoreService : IDacDistributeToStoreService
    {
        public BaseViewModel<List<DacDistributeToStoreVM>> GetAll()
        {
            var response = new BaseViewModel<List<DacDistributeToStoreVM>>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var queryable = (from i in dbContext.DacDistributeToStore
                                     join se in dbContext.DacStore on i.StoreCode equals se.Code
                                     join sk in dbContext.DacStock on i.StockCode equals sk.Code into left
                                     from l in left.DefaultIfEmpty()
                                     select new DacDistributeToStoreVM
                                     {
                                         Id = i.Id,
                                         OrderNumber = i.OrderNumber,
                                         StoreCode = i.StoreCode,
                                         Description = i.Description,
                                         Quantity = i.Quantity,
                                         CreatedDate = i.CreatedDate,
                                         StockCode = i.StockCode,
                                         Active = i.Active,
                                         StoreName = se.Name,
                                         StockName = l != null ? l.Name : null
                                     })?.OrderByDescending(x => x.CreatedDate)?.ToList();
                    response.ResponseData = queryable;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacDistributeToStoreVM> GetDetail(int Id)
        {
            var response = new BaseViewModel<DacDistributeToStoreVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var exportInfo = dbContext.DacDistributeToStore.FirstOrDefault(x => x.Id == Id);
                    if (exportInfo != null)
                    {
                        var queryable = new DacDistributeToStoreVM
                        {
                            Id = exportInfo.Id,
                            OrderNumber = exportInfo.OrderNumber,
                            StoreCode = exportInfo.StoreCode,
                            Description = exportInfo.Description,
                            Quantity = exportInfo.Quantity,
                            CreatedDate = exportInfo.CreatedDate,
                            StockCode = exportInfo.StockCode,
                            Active = exportInfo.Active,
                            StoreName = dbContext.DacStore.FirstOrDefault(x => x.Code == exportInfo.StoreCode)?.Name,
                            StockName = dbContext.DacStock.FirstOrDefault(x => x.Code == exportInfo.StockCode)?.Name,
                            LstDetails = dbContext.DacDistributeToStoreDetails.Where(x => x.DistributeToStoreId == Id)?.Select(x => new DacDistributeToStoreDetailsVM
                            {
                                Id = x.Id,
                                DistributeToStoreId = x.DistributeToStoreId,
                                DacCode = x.DacCode,
                                ProductCode = x.ProductCode,
                                ProductName = dbContext.DacProduct.FirstOrDefault(y => y.Code == x.ProductCode).Name
                            })?.ToList(),
                        };
                        queryable.RealityQuantity = queryable.LstDetails != null ? queryable.LstDetails.Count : 0;
                        queryable.ProductName = queryable.LstDetails != null ? string.Join(",", queryable.LstDetails.Select(x => x.ProductName).Distinct()) : string.Empty;
                        response.ResponseData = queryable;
                    }
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacDistributeToStoreVM> Create(DacDistributeToStoreVM exportInfoVM)
        {
            var response = new BaseViewModel<DacDistributeToStoreVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var NewExportInfo = new DacDistributeToStore
                    {
                        Id = exportInfoVM.Id,
                        OrderNumber = exportInfoVM.OrderNumber,
                        StoreCode = exportInfoVM.StoreCode,
                        Description = exportInfoVM.Description,
                        Quantity = exportInfoVM.Quantity,
                        CreatedDate = exportInfoVM.CreatedDate,
                        StockCode = exportInfoVM.StockCode,
                        Active = exportInfoVM.Active,
                    };
                    dbContext.DacDistributeToStore.Add(NewExportInfo);
                    dbContext.SaveChanges();
                    if (NewExportInfo.Id > 0)
                    {
                        if (exportInfoVM.LstDetails != null && exportInfoVM.LstDetails.Any())
                        {
                            List<DacDistributeToStoreDetailsVM> LstDuplicateSeri = exportInfoVM.LstDetails.Where(x => dbContext.DacDistributeToStoreDetails.FirstOrDefault(y => y.DacCode == x.DacCode) != null)?.ToList();
                            if (LstDuplicateSeri != null && LstDuplicateSeri.Any())
                            {
                                exportInfoVM.LstDetails = exportInfoVM.LstDetails.Except(LstDuplicateSeri)?.ToList();
                            }
                            if (exportInfoVM.LstDetails != null && exportInfoVM.LstDetails.Any())
                            {
                                List<DacDistributeToStoreDetails> LstNewDetail = new List<DacDistributeToStoreDetails>();
                                foreach (var detail in exportInfoVM.LstDetails)
                                {
                                    var newDetail = new DacDistributeToStoreDetails();
                                    newDetail.Id = detail.Id;
                                    newDetail.DistributeToStoreId = NewExportInfo.Id;
                                    newDetail.DacCode = detail.DacCode;
                                    newDetail.ProductCode = detail.ProductCode;
                                    LstNewDetail.Add(newDetail);
                                }
                                if (LstDuplicateSeri != null && LstDuplicateSeri.Any())
                                {
                                    response.ErrorMessage += "Mã QR " + string.Join(",", LstDuplicateSeri) + " đã được xuất ở lệnh khác! Mã QR này sẽ bị loại khỏi lệnh xuất này và số lượng quy định trong lệnh này sẽ được cập nhật!";
                                    NewExportInfo.Quantity = exportInfoVM.LstDetails.Count;
                                }
                                try
                                {
                                    dbContext.DacDistributeToStoreDetails.AddRange(LstNewDetail);
                                    dbContext.SaveChanges();
                                    exportInfoVM.Id = NewExportInfo.Id;
                                }
                                catch
                                {
                                    dbContext.DacDistributeToStore.Remove(NewExportInfo);
                                }
                            }
                            else
                            {
                                dbContext.DacDistributeToStore.Remove(NewExportInfo);
                                response.ErrorMessage += "Toàn bộ các mã QR đã được xuất ở lệnh khác! Lưu phiếu xuất không thành công!";
                            }
                        }
                        response.ResponseData = exportInfoVM;
                    }
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacDistributeToStoreVM> Edit(DacDistributeToStoreVM exportInfoVM)
        {
            var response = new BaseViewModel<DacDistributeToStoreVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var exportInfo = dbContext.DacDistributeToStore.FirstOrDefault(x => x.Id == exportInfoVM.Id);
                    if (exportInfo != null)
                    {
                        exportInfo.Quantity = exportInfoVM.Quantity;
                        exportInfo.StoreCode = exportInfoVM.StoreCode;
                        exportInfo.Description = exportInfoVM.Description;
                        exportInfo.CreatedDate = exportInfoVM.CreatedDate;
                        exportInfo.StockCode = exportInfoVM.StockCode;
                        exportInfo.Active = exportInfoVM.Active;
                    }
                    dbContext.Entry(exportInfo).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    response.ResponseData = exportInfoVM;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> Delete(int exportInfoId)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var LstDetails = dbContext.DacDistributeToStoreDetails.Where(x => x.DistributeToStoreId == exportInfoId);
                    if (LstDetails != null && LstDetails.Any())
                    {
                        dbContext.DacDistributeToStoreDetails.RemoveRange(LstDetails);
                    }
                    var exportInfo = dbContext.DacDistributeToStore.FirstOrDefault(x => x.Id == exportInfoId);
                    if (exportInfo != null)
                    {
                        dbContext.DacDistributeToStore.Remove(exportInfo);
                    }
                    dbContext.SaveChanges();
                    response.ResponseData = true;
                }
            }
            catch (Exception ex)
            {
                response.ResponseData = false;
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<string> GenerateNewCode()
        {
            var response = new BaseViewModel<string>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var LstCode = dbContext.DacDistributeToStore?.Select(x => x.OrderNumber)?.ToList();
                    if (LstCode != null && LstCode.Any())
                    {
                        var LstThisMonth = LstCode.Where(x => x.Substring(0, 4) == DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString("D2"))?.OrderByDescending(x => x)?.ToList();
                        if (LstThisMonth != null && LstThisMonth.Any())
                        {
                            var LastCode = int.Parse(LstThisMonth.First().Substring(4, 5));
                            response.ResponseData = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString("D2") + (LastCode + 1).ToString("D5");
                        }
                        else
                        {
                            response.ResponseData = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString("D2") + 1.ToString("D5");
                        }
                    }
                    else
                    {
                        response.ResponseData = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString("D2") + 1.ToString("D5");
                    }
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> InvalidProductCode(string DacCode, string ProductCode)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var PackageProductCode = (from d in dbContext.DacPackageDetails
                                              join p in dbContext.DacPackage on d.PackageId equals p.Id
                                              where d.DacCode == DacCode
                                              select p.ProductCode)?.FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(PackageProductCode) && PackageProductCode != ProductCode)
                    {
                        response.ResponseData = true;
                        response.ErrorMessage = "QR code " + DacCode + " đã được đóng thùng với mã sản phẩm "
                            + PackageProductCode + ", không thể xuất với mã sản phẩm " + ProductCode;
                        return response;
                    }
                    var WarehouseProductCode = (from d in dbContext.DacInsertToWarehouseDetails
                                                join w in dbContext.DacInsertToWarehouse on d.InsertID equals w.Id
                                                where d.DacCode == DacCode
                                                select w.ProductCode)?.FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(WarehouseProductCode) && WarehouseProductCode != ProductCode)
                    {
                        response.ResponseData = true;
                        response.ErrorMessage = "QR code " + DacCode + " đã được nhập kho với mã sản phẩm "
                            + WarehouseProductCode + ", không thể xuất với mã sản phẩm " + ProductCode;
                        return response;
                    }
                    var AgencyProductCode = (from d in dbContext.DacDistributeToAgencyDetails
                                              where d.DacCode == DacCode
                                              select d.ProductCode)?.FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(AgencyProductCode) && AgencyProductCode != ProductCode)
                    {
                        response.ResponseData = true;
                        response.ErrorMessage = "QR code " + DacCode + " đã được xuất đến đại lý với mã sản phẩm "
                            + AgencyProductCode + ", không thể xuất với mã sản phẩm " + ProductCode;
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.ResponseData = false;
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacDistributeToStore> GetByCode(string OrderNumber)
        {
            var response = new BaseViewModel<DacDistributeToStore>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    response.ResponseData = dbContext.DacDistributeToStore.FirstOrDefault(x => x.OrderNumber == OrderNumber);
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }
    }
}
