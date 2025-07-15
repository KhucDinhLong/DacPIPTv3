using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacStoreService : IDacStoreService
    {
        public BaseViewModel<List<DacStoreVM>> GetAll()
        {
            var response = new BaseViewModel<List<DacStoreVM>>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    response.ResponseData = (from store in db.DacStore
                                             join agency in db.DacCustomer on store.AgencyCode equals agency.Code into left
                                             from l in left.DefaultIfEmpty()
                                             select new DacStoreVM
                                             {
                                                 Id = store.Id,
                                                 Code = store.Code,
                                                 Name = store.Name,
                                                 Address = store.Address,
                                                 AgencyCode = store.AgencyCode,
                                                 AgencyName = l != null ? l.Name : null,
                                                 Active = store.Active,
                                                 CreatedDate = store.CreatedDate,
                                                 CreatedUser = store.CreatedUser,
                                                 Description = store.Description,
                                                 Email = store.Email,
                                                 MobileNum = store.MobileNum,
                                                 ModifiedDate = store.ModifiedDate,
                                                 ModifiedUser = store.ModifiedUser,
                                                 PhoneNum = store.PhoneNum,
                                                 ProvinceCode = store.ProvinceCode,
                                                 ShopKeeper = store.ShopKeeper
                                             }).OrderByDescending(x => x.CreatedDate).ToList();
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<DacStore> GetById(int id)
        {
            var response = new BaseViewModel<DacStore>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    response.ResponseData = db.DacStore.FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<DacStore> Create(DacStore store)
        {
            var response = new BaseViewModel<DacStore>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    store.CreatedDate = DateTime.Now;
                    db.DacStore.Add(store);
                    db.SaveChanges();
                    response.ResponseData = store;
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<DacStore> Edit(DacStore store)
        {
            var response = new BaseViewModel<DacStore>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    store.ModifiedDate = DateTime.Now;
                    db.Entry(store).State = EntityState.Modified;
                    db.SaveChanges();
                    response.ResponseData = store;
                }
            }
            catch (Exception ex) { response.ex = ex; }
            return response;
        }

        public BaseViewModel<bool> Delete(int id)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var db = new PIPTDbContext())
                {
                    var entity = db.DacStore.FirstOrDefault(x => x.Id == id);
                    if (entity != null)
                    {
                        db.DacStore.Remove(entity);
                        db.SaveChanges();
                        response.ResponseData = true;
                    }
                    else response.ResponseData = false;
                }
            }
            catch (Exception ex)
            {
                response.ResponseData = false;
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> HasUsed(string code)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    response.ResponseData = dbContext.DacExport.Any(x => x.CustomerCode == code);
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
                response.ResponseData = true;
            }
            return response;
        }

        public BaseViewModel<DacStore> GetByCode(string StoreCode)
        {
            var response = new BaseViewModel<DacStore>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    response.ResponseData = dbContext.DacStore.FirstOrDefault(x => x.Code == StoreCode);
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<int> ImportFromExcel(string filePath, string UserName)
        {
            var response = new BaseViewModel<int>();
            try
            {
                var stores = new List<DacStore>();

                FileInfo fileInfo = new FileInfo(filePath);
                using (var package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                    int rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        string StoreCode = worksheet.Cells[row, 2].Text;
                        if (!string.IsNullOrWhiteSpace(StoreCode))
                        {
                            var ExsitedStore = GetByCode(StoreCode).ResponseData;
                            if (ExsitedStore == null)
                            {
                                var agency = new DacStore
                                {
                                    Code = worksheet.Cells[row, 2].Text,
                                    Name = worksheet.Cells[row, 3].Text,
                                    Address = worksheet.Cells[row, 4].Text,
                                    ProvinceCode = worksheet.Cells[row, 5].Text,
                                    ShopKeeper = worksheet.Cells[row, 6].Text,
                                    PhoneNum = worksheet.Cells[row, 7].Text,
                                    MobileNum = worksheet.Cells[row, 8].Text,
                                    Email = worksheet.Cells[row, 9].Text,
                                    AgencyCode = worksheet.Cells[row, 10].Text,
                                    Description = worksheet.Cells[row, 15].Text,
                                    Active = true,
                                    CreatedDate = DateTime.Now,
                                    CreatedUser = (!string.IsNullOrWhiteSpace(UserName) ? UserName + "-" : string.Empty) + "ImportTool"
                                };

                                stores.Add(agency);
                            }
                            else
                            {
                                response.ErrorMessage += "\r\nMã " + StoreCode + " đã tồn tại.";
                            }
                        }
                        else
                        {
                            response.ErrorMessage += "\r\nDòng " + row + " không có mã cửa hàng.";
                        }
                    }
                }

                using (var db = new PIPTDbContext())
                {
                    db.DacStore.AddRange(stores);
                    var count = db.SaveChanges();
                    response.ResponseData = count;
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
