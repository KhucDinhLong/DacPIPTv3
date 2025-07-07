using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacDistributeToAgencyService : IDacDistributeToAgencyService
    {
        public BaseViewModel<List<DacDistributeToAgencyVM>> GetAll()
        {
            var response = new BaseViewModel<List<DacDistributeToAgencyVM>>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var queryable = (from i in dbContext.DacDistributeToAgency
                                     join a in dbContext.DacAgency on i.AgencyCode equals a.Code
                                     join s in dbContext.DacStock on i.StockCode equals s.Code into left
                                     from l in left.DefaultIfEmpty()
                                     select new DacDistributeToAgencyVM
                                     {
                                         Id = i.Id,
                                         OrderNumber = i.OrderNumber,
                                         AgencyCode = i.AgencyCode,
                                         Description = i.Description,
                                         Quantity = i.Quantity,
                                         CreatedDate = i.CreatedDate,
                                         StockCode = i.StockCode,
                                         Active = i.Active,
                                         AgencyName = a.Name,
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

        public BaseViewModel<DacDistributeToAgencyVM> GetDetail(int Id)
        {
            var response = new BaseViewModel<DacDistributeToAgencyVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var exportInfo = dbContext.DacDistributeToAgency.FirstOrDefault(x => x.Id == Id);
                    if (exportInfo != null)
                    {
                        var queryable = new DacDistributeToAgencyVM
                        {
                            Id = exportInfo.Id,
                            OrderNumber = exportInfo.OrderNumber,
                            AgencyCode = exportInfo.AgencyCode,
                            Description = exportInfo.Description,
                            Quantity = exportInfo.Quantity,
                            CreatedDate = exportInfo.CreatedDate,
                            StockCode = exportInfo.StockCode,
                            Active = exportInfo.Active,
                            AgencyName = dbContext.DacAgency.FirstOrDefault(x => x.Code == exportInfo.AgencyCode)?.Name,
                            StockName = dbContext.DacStock.FirstOrDefault(x => x.Code == exportInfo.StockCode)?.Name,
                            LstDetails = dbContext.DacDistributeToAgencyDetails.Where(x => x.DistributeToAgencyId == Id)?.Select(x => new DacDistributeToAgencyDetailVM
                            {
                                Id = x.Id,
                                DistributeToAgencyId = x.DistributeToAgencyId,
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

        public BaseViewModel<DacDistributeToAgencyVM> Create(DacDistributeToAgencyVM exportInfoVM)
        {
            var response = new BaseViewModel<DacDistributeToAgencyVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var NewExportInfo = new DacDistributeToAgency
                    {
                        Id = exportInfoVM.Id,
                        OrderNumber = exportInfoVM.OrderNumber,
                        AgencyCode = exportInfoVM.AgencyCode,
                        Description = exportInfoVM.Description,
                        Quantity = exportInfoVM.Quantity,
                        CreatedDate = exportInfoVM.CreatedDate,
                        StockCode = exportInfoVM.StockCode,
                        Active = exportInfoVM.Active,
                    };
                    dbContext.DacDistributeToAgency.Add(NewExportInfo);
                    dbContext.SaveChanges();
                    if (NewExportInfo.Id > 0)
                    {
                        if (exportInfoVM.LstDetails != null && exportInfoVM.LstDetails.Any())
                        {
                            List<DacDistributeToAgencyDetailVM> LstDuplicateSeri = exportInfoVM.LstDetails.Where(x => dbContext.DacDistributeToAgencyDetails.FirstOrDefault(y => y.DacCode == x.DacCode) != null)?.ToList();
                            if (LstDuplicateSeri != null && LstDuplicateSeri.Any())
                            {
                                exportInfoVM.LstDetails = exportInfoVM.LstDetails.Except(LstDuplicateSeri)?.ToList();
                            }
                            if (exportInfoVM.LstDetails != null && exportInfoVM.LstDetails.Any())
                            {
                                List<DacDistributeToAgencyDetails> LstNewDetail = new List<DacDistributeToAgencyDetails>();
                                foreach (var detail in exportInfoVM.LstDetails)
                                {
                                    var newDetail = new DacDistributeToAgencyDetails();
                                    newDetail.Id = detail.Id;
                                    newDetail.DistributeToAgencyId = NewExportInfo.Id;
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
                                    dbContext.DacDistributeToAgencyDetails.AddRange(LstNewDetail);
                                    dbContext.SaveChanges();
                                    exportInfoVM.Id = NewExportInfo.Id;
                                }
                                catch
                                {
                                    dbContext.DacDistributeToAgency.Remove(NewExportInfo);
                                }
                            }
                            else
                            {
                                dbContext.DacDistributeToAgency.Remove(NewExportInfo);
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

        public BaseViewModel<DacDistributeToAgencyVM> Edit(DacDistributeToAgencyVM exportInfoVM)
        {
            var response = new BaseViewModel<DacDistributeToAgencyVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var exportInfo = dbContext.DacDistributeToAgency.FirstOrDefault(x => x.Id == exportInfoVM.Id);
                    if (exportInfo != null)
                    {
                        exportInfo.Quantity = exportInfoVM.Quantity;
                        exportInfo.AgencyCode = exportInfoVM.AgencyCode;
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
                    var LstDetails = dbContext.DacDistributeToAgencyDetails.Where(x => x.DistributeToAgencyId == exportInfoId);
                    if (LstDetails != null && LstDetails.Any())
                    {
                        dbContext.DacDistributeToAgencyDetails.RemoveRange(LstDetails);
                    }
                    var exportInfo = dbContext.DacDistributeToAgency.FirstOrDefault(x => x.Id == exportInfoId);
                    if (exportInfo != null)
                    {
                        dbContext.DacDistributeToAgency.Remove(exportInfo);
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
                    var LstCode = dbContext.DacDistributeToAgency?.Select(x => x.OrderNumber)?.ToList();
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
                }
            }
            catch (Exception ex)
            {
                response.ResponseData = false;
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacDistributeToAgency> GetByCode(string OrderNumber)
        {
            var response = new BaseViewModel<DacDistributeToAgency>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    response.ResponseData = dbContext.DacDistributeToAgency.FirstOrDefault(x => x.OrderNumber == OrderNumber);
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
