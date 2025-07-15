using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacProductService : IDacProductService
    {
        public BaseViewModel<List<DacProductVM>> GetAll()
        {
            var response = new BaseViewModel<List<DacProductVM>>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var queryable = (from p in dbContext.DacProduct
                                     join c in dbContext.DacProductCategory on p.ProductCategoryId equals c.Id into leftc
                                     from lc in leftc.DefaultIfEmpty()
                                     join u in dbContext.DacProductUnit on p.ProductUnitId equals u.Id into leftcu
                                     from lcu in leftcu.DefaultIfEmpty()
                                     select new DacProductVM
                                     {
                                         Id = p.Id,
                                         Code = p.Code,
                                         ProductCategoryId = p.ProductCategoryId,
                                         ProductUnitId = p.ProductUnitId,
                                         Name = p.Name,
                                         RegisterNumber = p.RegisterNumber,
                                         GeneralFormat = p.GeneralFormat,
                                         Manufacture = p.Manufacture,
                                         Remark = p.Remark,
                                         Size = p.Size,
                                         Active = p.Active,
                                         CreatedDate = p.CreatedDate,
                                         CreatedUser = p.CreatedUser,
                                         ModifiedDate = p.ModifiedDate,
                                         ModifiedUser = p.ModifiedUser,
                                         CategoryName = lc != null ? lc.Name : string.Empty,
                                         UnitName = lcu != null ? lcu.Name : string.Empty
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

        public BaseViewModel<DacProduct> GetById(int Id)
        {
            var response = new BaseViewModel<DacProduct>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var product = dbContext.DacProduct.FirstOrDefault(x => x.Id == Id);
                    response.ResponseData = product;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacProduct> GetByCode(string ProductCode)
        {
            var response = new BaseViewModel<DacProduct>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var product = dbContext.DacProduct.FirstOrDefault(x => x.Code == ProductCode);
                    response.ResponseData = product;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacProduct> Create(DacProduct NewProduct)
        {
            var response = new BaseViewModel<DacProduct>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    NewProduct.CreatedDate = DateTime.Now;
                    dbContext.DacProduct.Add(NewProduct);
                    dbContext.SaveChanges();
                    response.ResponseData = NewProduct;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacProduct> Edit(DacProduct Product)
        {
            var response = new BaseViewModel<DacProduct>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    Product.ModifiedDate = DateTime.Now;
                    dbContext.Entry(Product).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    response.ResponseData = Product;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> Delete(int Id)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var product = dbContext.DacProduct.FirstOrDefault(x => x.Id == Id);
                    if (product != null)
                    {
                        dbContext.DacProduct.Remove(product);
                        dbContext.SaveChanges();
                        response.ResponseData = true;
                    }
                    else
                    {
                        response.ResponseData = false;
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

        public BaseViewModel<bool> HasUsed(string ProductCode)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    bool isUsed = dbContext.DacContainer.Any(x => x.ProductCode == ProductCode)
                        || dbContext.DacExportDetail.Any(x => x.ProductCode == ProductCode)
                        || dbContext.DacExportDetail1.Any(x => x.ProductCode == ProductCode)
                        || dbContext.DacDistributeToStoreDetails.Any(x => x.ProductCode == ProductCode)
                        || dbContext.DacInsertToWarehouse.Any(x => x.ProductCode == ProductCode)
                        || dbContext.DacPackage.Any(x => x.ProductCode == ProductCode);

                    response.ResponseData = isUsed;
                }
            }
            catch (Exception ex)
            {
                response.ResponseData = true;
                response.ex = ex;
            }
            return response;
        }
    }
}
