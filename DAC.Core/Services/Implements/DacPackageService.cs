using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacPackageService : IDacPackageService
    {
        public BaseViewModel<List<DacPackageVM>> GetAll()
        {
            var response = new BaseViewModel<List<DacPackageVM>>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var queryable = dbContext.DacPackage
                                     .Select(p => new DacPackageVM
                                     {
                                         Id = p.Id,
                                         PackageCode = p.PackageCode,
                                         ProductCode = p.ProductCode,
                                         Batch = p.Batch,
                                         Description = p.Description,
                                         FactoryCode = p.FactoryCode,
                                         PersonPackaged = p.PersonPackaged,
                                         Quantity = p.Quantity,
                                         CreatedDate = p.CreatedDate,
                                         //NgaySanXuat = p.NgaySanXuat,
                                         Active = p.Active
                                     })?.OrderByDescending(x => x.Id)?.ToList();
                    response.ResponseData = queryable;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacPackageVM> GetDetail(int PackageId)
        {
            var response = new BaseViewModel<DacPackageVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var package = dbContext.DacPackage.FirstOrDefault(x => x.Id == PackageId);
                    if (package != null)
                    {
                        var queryable = new DacPackageVM
                        {
                            Id = package.Id,
                            PackageCode = package.PackageCode,
                            ProductCode = package.ProductCode,
                            Batch = package.Batch,
                            Description = package.Description,
                            FactoryCode = package.FactoryCode,
                            PersonPackaged = package.PersonPackaged,
                            Quantity = package.Quantity,
                            CreatedDate = package.CreatedDate,
                            Active = package.Active,
                            LstDetails = dbContext.DacPackageDetails.Where(x => x.PackageId == PackageId)?.ToList(),
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

        public BaseViewModel<DacPackageVM> Create(DacPackageVM packageVM)
        {
            var response = new BaseViewModel<DacPackageVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var NewPackage = new DacPackage
                    {
                        Id = packageVM.Id,
                        PackageCode = packageVM.PackageCode,
                        ProductCode = packageVM.ProductCode,
                        Quantity = packageVM.Quantity,
                        FactoryCode = packageVM.FactoryCode,
                        Description = packageVM.Description,
                        PersonPackaged = packageVM.PersonPackaged,
                        CreatedDate = packageVM.CreatedDate,
                        Batch = packageVM.Batch,
                        Active = packageVM.Active
                    };
                    dbContext.DacPackage.Add(NewPackage);
                    dbContext.SaveChanges();
                    if (NewPackage.Id > 0)
                    {
                        if (packageVM.LstDetails != null && packageVM.LstDetails.Any())
                        {
                            List<DacPackageDetails> LstDuplicateSeri = packageVM.LstDetails.Where(x => dbContext.DacPackageDetails.FirstOrDefault(y => y.DacCode == x.DacCode) != null)?.ToList();
                            if (LstDuplicateSeri != null && LstDuplicateSeri.Any())
                            {
                                packageVM.LstDetails = packageVM.LstDetails.Except(LstDuplicateSeri)?.ToList();
                            }
                            foreach (var detail in packageVM.LstDetails)
                            {
                                detail.PackageId = NewPackage.Id;
                            }
                            if (LstDuplicateSeri != null && LstDuplicateSeri.Any())
                            {
                                response.ErrorMessage += "Mã QR " + string.Join(",", LstDuplicateSeri) + " đã được đóng vào thùng khác! Mã QR này sẽ bị loại khỏi thùng này và số lượng quy định trong thùng này sẽ được cập nhật!";
                                NewPackage.Quantity = packageVM.LstDetails.Count;
                            }
                            try
                            {
                                dbContext.DacPackageDetails.AddRange(packageVM.LstDetails);
                                dbContext.SaveChanges();
                                packageVM.Id = NewPackage.Id;
                            }
                            catch
                            {
                                dbContext.DacPackage.Remove(NewPackage);
                            }
                        }
                        response.ResponseData = packageVM;
                    }
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacPackageVM> Edit(DacPackageVM packageVM)
        {
            var response = new BaseViewModel<DacPackageVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var package = dbContext.DacPackage.FirstOrDefault(x => x.Id == packageVM.Id);
                    if (package != null)
                    {
                        package.ProductCode = packageVM.ProductCode;
                        package.Quantity = packageVM.Quantity;
                        package.PersonPackaged = packageVM.PersonPackaged;
                        package.FactoryCode = package.FactoryCode;
                        package.Batch = packageVM.Batch;
                        package.Description = packageVM.Description;
                        package.Active = packageVM.Active;
                    }
                    dbContext.Entry(package).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    response.ResponseData = packageVM;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> Delete(int packageId)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var LstDetails = dbContext.DacPackageDetails.Where(x => x.PackageId == packageId);
                    if (LstDetails != null && LstDetails.Any())
                    {
                        dbContext.DacPackageDetails.RemoveRange(LstDetails);
                    }
                    var package = dbContext.DacPackage.FirstOrDefault(x => x.Id == packageId);
                    if (package != null)
                    {
                        dbContext.DacPackage.Remove(package);
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

        public BaseViewModel<bool> Exist(string PackageCode)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var package = dbContext.DacPackage.FirstOrDefault(x => x.PackageCode == PackageCode);
                    response.ResponseData = package != null;
                }
            }
            catch (Exception ex)
            {
                response.ResponseData = true;
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<string> GetMaxPackage(string pattern, string Size)
        {
            var response = new BaseViewModel<string>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var LastPackage = (from pkg in dbContext.DacPackage
                                       join p in dbContext.DacProduct on pkg.ProductCode equals p.Code
                                       where Size == null || Size == string.Empty || p.Size == Size
                                       select pkg)?.OrderByDescending(x => x.Id)?.FirstOrDefault();
                    if (LastPackage == null)
                    {
                        response.ResponseData = pattern + "-" + (!string.IsNullOrWhiteSpace(Size) ? Size + "-" : string.Empty) + "001" + DateTime.Now.Year.ToString().Substring(2, 2) + "-001";
                    }
                    else
                    {
                        string[] CodeArr = LastPackage.PackageCode.Split('-');
                        string BatchNum = CodeArr.Length == 3 ? CodeArr[1].Substring(0, 3) : CodeArr[2].Substring(0, 3);
                        string PackageNum = CodeArr.Length == 3 ? CodeArr[2] : CodeArr[3];
                        if (PackageNum == "138")
                        {
                            BatchNum = (int.Parse(BatchNum) + 1).ToString("D3");
                            PackageNum = "001";
                        }
                        else
                        {
                            PackageNum = (int.Parse(PackageNum) + 1).ToString("D3");
                        }
                        response.ResponseData = pattern + "-" + (!string.IsNullOrWhiteSpace(Size) ? Size + "-" : string.Empty) + BatchNum + DateTime.Now.Year.ToString().Substring(2, 2) + "-" + PackageNum;
                    }
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> InvalidProductCode(DacPackageVM packageVM)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    foreach (var detail in packageVM.LstDetails)
                    {
                        var WarehouseProductCode = (from d in dbContext.DacInsertToWarehouseDetails
                                                    join w in dbContext.DacInsertToWarehouse on d.InsertID equals w.Id
                                                    where d.DacCode == detail.DacCode
                                                    select w.ProductCode)?.FirstOrDefault();
                        if (!string.IsNullOrWhiteSpace(WarehouseProductCode) && WarehouseProductCode != packageVM.ProductCode)
                        {
                            response.ResponseData = true;
                            response.ErrorMessage = "QR code " + detail.DacCode + " đã được nhập kho với mã sản phẩm "
                                + WarehouseProductCode + ", không thể đóng thùng với mã sản phẩm " + packageVM.ProductCode;
                            return response;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.ResponseData = true;
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacPackageVM> GetInfo(string DacCode)
        {
            var response = new BaseViewModel<DacPackageVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var info = (from d in dbContext.DacPackageDetails
                                join pkg in dbContext.DacPackage on d.PackageId equals pkg.Id
                                join p in dbContext.DacProduct on pkg.ProductCode equals p.Code
                                where d.DacCode == DacCode
                                select new DacPackageVM
                                {
                                    PackageCode = pkg.PackageCode,
                                    ProductCode = p.Code,
                                    ProductName = p.Name,
                                    CreatedDate = pkg.CreatedDate,
                                    Quantity = pkg.Quantity,
                                    Batch = pkg.Batch,
                                    FactoryCode = pkg.FactoryCode,
                                    PersonPackaged = pkg.PersonPackaged,
                                    Description = pkg.Description
                                }).FirstOrDefault();
                    response.ResponseData = info;
                }
            }
            catch (Exception ex)
            {
                response.ResponseData = null;
                response.ex = ex;
            }
            return response;
        }
    }
}
