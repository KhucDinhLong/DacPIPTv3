using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacInsertToWarehouseService : IDacInsertToWarehouseService
    {
        public BaseViewModel<List<DacInsertToWarehouseVM>> GetAll()
        {
            var response = new BaseViewModel<List<DacInsertToWarehouseVM>>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var queryable = (from i in dbContext.DacInsertToWarehouse
                                     join p in dbContext.DacProduct on i.ProductCode equals p.Code into leftp
                                     from lp in leftp.DefaultIfEmpty()
                                     join s in dbContext.DacStock on i.StockCode equals s.Code into leftps
                                     from lps in leftps.DefaultIfEmpty()
                                     select new DacInsertToWarehouseVM
                                     {
                                         Id = i.Id,
                                         InsertNumber = i.InsertNumber,
                                         ProductCode = i.ProductCode,
                                         OutputType = i.OutputType,
                                         Description = i.Description,
                                         Quantity = i.Quantity,
                                         CreatedDate = i.CreatedDate,
                                         StockCode = i.StockCode,
                                         Active = i.Active,
                                         ProductName = lp != null ? lp.Name : null,
                                         StockName = lps != null ? lps.Name : null
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

        public BaseViewModel<DacInsertToWarehouseVM> GetDetail(int Id)
        {
            var response = new BaseViewModel<DacInsertToWarehouseVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var importInfo = dbContext.DacInsertToWarehouse.FirstOrDefault(x => x.Id == Id);
                    if (importInfo != null)
                    {
                        var queryable = new DacInsertToWarehouseVM
                        {
                            Id = importInfo.Id,
                            InsertNumber = importInfo.InsertNumber,
                            ProductCode = importInfo.ProductCode,
                            OutputType = importInfo.OutputType,
                            Description = importInfo.Description,
                            Quantity = importInfo.Quantity,
                            CreatedDate = importInfo.CreatedDate,
                            StockCode = importInfo.StockCode,
                            Active = importInfo.Active,
                            ProductName = dbContext.DacProduct.FirstOrDefault(x => x.Code == importInfo.ProductCode)?.Name,
                            StockName = dbContext.DacStock.FirstOrDefault(x => x.Code == importInfo.StockCode)?.Name,
                            LstDetails = dbContext.DacInsertToWarehouseDetails.Where(x => x.InsertID == Id)?.ToList(),
                        };
                        queryable.RealityQuantity = queryable.LstDetails != null ? queryable.LstDetails.Count : 0;
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

        public BaseViewModel<DacInsertToWarehouseVM> Create(DacInsertToWarehouseVM importInfoVM)
        {
            var response = new BaseViewModel<DacInsertToWarehouseVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var NewImportInfo = new DacInsertToWarehouse
                    {
                        Id = importInfoVM.Id,
                        InsertNumber = importInfoVM.InsertNumber,
                        ProductCode = importInfoVM.ProductCode,
                        OutputType = importInfoVM.OutputType,
                        Description = importInfoVM.Description,
                        Quantity = importInfoVM.Quantity,
                        CreatedDate = importInfoVM.CreatedDate,
                        StockCode = importInfoVM.StockCode,
                        Active = importInfoVM.Active,
                    };
                    dbContext.DacInsertToWarehouse.Add(NewImportInfo);
                    dbContext.SaveChanges();
                    if (NewImportInfo.Id > 0)
                    {
                        if (importInfoVM.LstDetails != null && importInfoVM.LstDetails.Any())
                        {
                            List<DacInsertToWarehouseDetails> LstDuplicateSeri = importInfoVM.LstDetails.Where(x => dbContext.DacInsertToWarehouseDetails.FirstOrDefault(y => y.DacCode == x.DacCode) != null)?.ToList();
                            if (LstDuplicateSeri != null && LstDuplicateSeri.Any())
                            {
                                importInfoVM.LstDetails = importInfoVM.LstDetails.Except(LstDuplicateSeri)?.ToList();
                            }
                            foreach (var detail in importInfoVM.LstDetails)
                            {
                                detail.InsertID = NewImportInfo.Id;
                            }
                            if (LstDuplicateSeri != null && LstDuplicateSeri.Any())
                            {
                                response.ErrorMessage += "Mã QR " + string.Join(",", LstDuplicateSeri) + " đã được nhập kho ở phiếu khác! Mã QR này sẽ bị loại khỏi thùng này và số lượng quy định trong phiếu nhập này sẽ được cập nhật!";
                                NewImportInfo.Quantity = importInfoVM.LstDetails.Count;
                            }
                            try
                            {
                                dbContext.DacInsertToWarehouseDetails.AddRange(importInfoVM.LstDetails);
                                dbContext.SaveChanges();
                                importInfoVM.Id = NewImportInfo.Id;
                            }
                            catch
                            {
                                dbContext.DacInsertToWarehouse.Remove(NewImportInfo);
                            }
                        }
                        response.ResponseData = importInfoVM;
                    }
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacInsertToWarehouseVM> Edit(DacInsertToWarehouseVM importInfoVM)
        {
            var response = new BaseViewModel<DacInsertToWarehouseVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var importInfo = dbContext.DacInsertToWarehouse.FirstOrDefault(x => x.Id == importInfoVM.Id);
                    if (importInfo != null)
                    {
                        importInfo.InsertNumber = importInfoVM.InsertNumber;
                        importInfo.Quantity = importInfoVM.Quantity;
                        importInfo.ProductCode = importInfoVM.ProductCode;
                        importInfo.OutputType = importInfoVM.OutputType;
                        importInfo.Description = importInfoVM.Description;
                        importInfo.CreatedDate = importInfoVM.CreatedDate;
                        importInfo.StockCode = importInfoVM.StockCode;
                        importInfo.Active = importInfoVM.Active;
                    }
                    dbContext.Entry(importInfo).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    response.ResponseData = importInfoVM;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> Delete(int importInfoId)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var LstDetails = dbContext.DacInsertToWarehouseDetails.Where(x => x.InsertID == importInfoId);
                    if (LstDetails != null && LstDetails.Any())
                    {
                        dbContext.DacInsertToWarehouseDetails.RemoveRange(LstDetails);
                    }
                    var package = dbContext.DacInsertToWarehouse.FirstOrDefault(x => x.Id == importInfoId);
                    if (package != null)
                    {
                        dbContext.DacInsertToWarehouse.Remove(package);
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

        public BaseViewModel<string> GetMaxInsertNumber(string DisplayFormat)
        {
            var response = new BaseViewModel<string>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var LastImportInfo = dbContext.DacInsertToWarehouse.Last();
                    if (LastImportInfo != null)
                    {
                        int nextIndex = int.Parse(LastImportInfo.InsertNumber) + 1;
                        response.ResponseData = nextIndex.ToString(DisplayFormat);
                    }
                    else
                    {
                        response.ResponseData = string.Format(DisplayFormat, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> InvalidProductCode(DacInsertToWarehouseVM importInfoVM)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    foreach (var detail in importInfoVM.LstDetails)
                    {
                        var PackageProductCode = (from d in dbContext.DacPackageDetails
                                                    join p in dbContext.DacPackage on d.PackageId equals p.Id
                                                    where d.DacCode == detail.DacCode
                                                    select p.ProductCode)?.FirstOrDefault();
                        if (!string.IsNullOrWhiteSpace(PackageProductCode) && PackageProductCode != importInfoVM.ProductCode)
                        {
                            response.ResponseData = true;
                            response.ErrorMessage = "QR code " + detail.DacCode + " đã được đóng thùng với mã sản phẩm "
                                + PackageProductCode + ", không thể nhập kho với mã sản phẩm " + importInfoVM.ProductCode;
                            return response;
                        }
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

        public BaseViewModel<DacInsertToWarehouse> GetByCode(string InsertNumber)
        {
            var response = new BaseViewModel<DacInsertToWarehouse>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    response.ResponseData = dbContext.DacInsertToWarehouse.FirstOrDefault(x => x.InsertNumber == InsertNumber);
                }
            }
            catch (Exception ex)
            {
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
                    var LstCode = dbContext.DacInsertToWarehouse?.Select(x => x.InsertNumber)?.ToList();
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
    }
}
