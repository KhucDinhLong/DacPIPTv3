using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.OldVersion;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public static class DacExport2Service
    {
        public static BaseViewModel<List<DacExportVM>> GetAll()
        {
            var response = new BaseViewModel<List<DacExportVM>>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var queryable = (from i in dbContext.DacExport2
                                     join a in dbContext.DacCustomer on i.CustomerCode equals a.Code
                                     join s in dbContext.DacStock on i.StockCode equals s.Code into left
                                     from l in left.DefaultIfEmpty()
                                     select new DacExportVM
                                     {
                                         Id = i.Id,
                                         OrderNumber = i.OrderNumber,
                                         CustomerCode = i.CustomerCode,
                                         Description = i.Description,
                                         Quantity = i.Quantity,
                                         CreatedDate = i.CreatedDate,
                                         StockCode = i.StockCode,
                                         Active = i.Active,
                                         CustomerName = a.Name,
                                         StockName = l != null ? l.Name : null,
                                         CustomerLevel = 3
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

        public static BaseViewModel<DacExportVM> GetDetail(int Id)
        {
            var response = new BaseViewModel<DacExportVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var exportInfo = dbContext.DacExport2.FirstOrDefault(x => x.Id == Id);
                    if (exportInfo != null)
                    {
                        var queryable = new DacExportVM
                        {
                            Id = exportInfo.Id,
                            OrderNumber = exportInfo.OrderNumber,
                            CustomerCode = exportInfo.CustomerCode,
                            Description = exportInfo.Description,
                            Quantity = exportInfo.Quantity,
                            CreatedDate = exportInfo.CreatedDate,
                            StockCode = exportInfo.StockCode,
                            Active = exportInfo.Active,
                            CustomerName = dbContext.DacCustomer.FirstOrDefault(x => x.Code == exportInfo.CustomerCode)?.Name,
                            StockName = dbContext.DacStock.FirstOrDefault(x => x.Code == exportInfo.StockCode)?.Name,
                            CustomerLevel = 1,
                            LstDetails = dbContext.DacExportDetail2.Where(x => x.ExportId == Id)?.Select(x => new DacExportDetailVM
                            {
                                Id = x.Id,
                                ExportId = x.ExportId,
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

        public static BaseViewModel<DacExportVM> Create(DacExportVM exportInfoVM)
        {
            var response = new BaseViewModel<DacExportVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var NewExportInfo = new DacExport2
                    {
                        Id = exportInfoVM.Id,
                        OrderNumber = exportInfoVM.OrderNumber,
                        CustomerCode = exportInfoVM.CustomerCode,
                        Description = exportInfoVM.Description,
                        Quantity = exportInfoVM.Quantity,
                        CreatedDate = exportInfoVM.CreatedDate,
                        StockCode = exportInfoVM.StockCode,
                        Active = exportInfoVM.Active,
                    };
                    dbContext.DacExport2.Add(NewExportInfo);
                    dbContext.SaveChanges();
                    if (NewExportInfo.Id > 0)
                    {
                        if (exportInfoVM.LstDetails != null && exportInfoVM.LstDetails.Any())
                        {
                            List<DacExportDetailVM> LstDuplicateSeri = exportInfoVM.LstDetails.Where(x => dbContext.DacExportDetail2.FirstOrDefault(y => y.DacCode == x.DacCode) != null)?.ToList();
                            if (LstDuplicateSeri != null && LstDuplicateSeri.Any())
                            {
                                exportInfoVM.LstDetails = exportInfoVM.LstDetails.Except(LstDuplicateSeri)?.ToList();
                            }
                            if (exportInfoVM.LstDetails != null && exportInfoVM.LstDetails.Any())
                            {
                                List<DacExportDetail2> LstNewDetail = new List<DacExportDetail2>();
                                foreach (var detail in exportInfoVM.LstDetails)
                                {
                                    var newDetail = new DacExportDetail2();
                                    newDetail.Id = detail.Id;
                                    newDetail.ExportId = NewExportInfo.Id;
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
                                    dbContext.DacExportDetail2.AddRange(LstNewDetail);
                                    dbContext.SaveChanges();
                                    exportInfoVM.Id = NewExportInfo.Id;
                                }
                                catch
                                {
                                    dbContext.DacExport2.Remove(NewExportInfo);
                                }
                            }
                            else
                            {
                                dbContext.DacExport2.Remove(NewExportInfo);
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

        public static BaseViewModel<DacExportVM> Edit(DacExportVM exportInfoVM)
        {
            var response = new BaseViewModel<DacExportVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var exportInfo = dbContext.DacExport2.FirstOrDefault(x => x.Id == exportInfoVM.Id);
                    if (exportInfo != null)
                    {
                        exportInfo.Quantity = exportInfoVM.Quantity;
                        exportInfo.CustomerCode = exportInfoVM.CustomerCode;
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

        public static BaseViewModel<bool> Delete(int exportInfoId)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var LstDetails = dbContext.DacExportDetail2.Where(x => x.ExportId == exportInfoId);
                    if (LstDetails != null && LstDetails.Any())
                    {
                        dbContext.DacExportDetail2.RemoveRange(LstDetails);
                    }
                    var exportInfo = dbContext.DacExport2.FirstOrDefault(x => x.Id == exportInfoId);
                    if (exportInfo != null)
                    {
                        dbContext.DacExport2.Remove(exportInfo);
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

        public static BaseViewModel<string> GenerateNewCode()
        {
            var response = new BaseViewModel<string>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var LstCode = dbContext.DacExport2?.Select(x => x.OrderNumber)?.ToList();
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

        public static BaseViewModel<bool> InvalidProductCode(string DacCode, string ProductCode)
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
                    var ExportProductCode = (from d in dbContext.DacExportDetail
                                             where d.DacCode == DacCode
                                              select d.ProductCode)?.FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(ExportProductCode) && ExportProductCode != ProductCode)
                    {
                        response.ResponseData = true;
                        response.ErrorMessage = "QR code " + DacCode + " đã được xuất với mã sản phẩm "
                            + ExportProductCode + ", không thể xuất với mã sản phẩm " + ProductCode;
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

        public static BaseViewModel<DacExportVM> GetByCode(string OrderNumber)
        {
            var response = new BaseViewModel<DacExportVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var exportData = dbContext.DacExport2.FirstOrDefault(x => x.OrderNumber == OrderNumber);

                    response.ResponseData = exportData != null ? new DacExportVM
                    {
                        Id = exportData.Id,
                        OriginalId = exportData.OriginalId?.ToString(),
                        OrderNumber = exportData.OrderNumber,
                        CreatedDate = exportData.CreatedDate,
                        CustomerCode = exportData.CustomerCode,
                        Quantity = exportData.Quantity,
                        Description = exportData.Description,
                        Active = exportData.Active,
                        StockCode = exportData.StockCode
                    } : null;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public static bool RestoreData()
        {
            List<DacExport2> LstExport = new List<DacExport2>();
            List<DacExportDetail2> LstExportDetail = new List<DacExportDetail2>();
            try
            {
                using (var oldVersionDbContext = new PIPTOldVerDbContext())
                {
                    var data = oldVersionDbContext.DacDistributeToStore?.ToList();
                    if (data != null && data.Any())
                    {
                        foreach (var item in data)
                        {
                            DacExport2 restoreData = new DacExport2();
                            restoreData.OrderNumber = item.OrderNumber;
                            restoreData.CreatedDate = item.CreatedDate;
                            restoreData.CustomerCode = item.StoreCode;
                            restoreData.Quantity = item.Quantity;
                            restoreData.Description = item.Description;
                            restoreData.Active = item.Active;
                            restoreData.StockCode = item.StockID;
                            restoreData.OriginalId = item.ID.ToString();
                            LstExport.Add(restoreData);
                        }
                    }
                }
                if (LstExport != null && LstExport.Any())
                {
                    using (var dbContext = new PIPTDbContext())
                    {
                        dbContext.DacExport2.AddRange(LstExport);
                        dbContext.SaveChanges();
                    }
                    foreach (var item in LstExport)
                    {
                        LstExportDetail.Clear();
                        using (var oldVersionDbContext = new PIPTOldVerDbContext())
                        {
                            var details = oldVersionDbContext.DacDistributeToStoreDetails.Where(x => x.DistributorID.HasValue && x.DistributorID.Value.ToString() == item.OriginalId);
                            if (details != null && details.Any())
                            {
                                foreach (var detail in details)
                                {
                                    DacExportDetail2 restoreDetail = new DacExportDetail2();
                                    restoreDetail.ExportId = item.Id;
                                    restoreDetail.DacCode = detail.DacCode;
                                    restoreDetail.ProductCode = detail.ProductCode;
                                    LstExportDetail.Add(restoreDetail);
                                }
                            }
                        }
                        using (var dbContext = new PIPTDbContext())
                        {
                            dbContext.DacExportDetail2.AddRange(LstExportDetail);
                            dbContext.SaveChanges();
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
