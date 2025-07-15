using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.OldVersion;
using DAC.DAL.ViewModels;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using DacAgency = DAC.DAL.DacCustomer;

namespace DAC.Core.Services.Implements
{
    public class DacCustomerService : IDacCustomerService
    {
        public BaseViewModel<List<DacCustomerVM>> GetAll()
        {
            var response = new BaseViewModel<List<DacCustomerVM>>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    response.ResponseData = dbContext.DacCustomer.Select(x => new DacCustomerVM
                    {
                        Id = x.Id,
                        Code = x.Code,
                        Name = x.Name,
                        Address = x.Address,
                        Active = x.Active,
                        CreatedDate = x.CreatedDate,
                        CreatedUser = x.CreatedUser,
                        DependCode = x.DependCode,
                        Description = x.Description,
                        Email = x.Email,
                        JoinContact = x.JoinContact,
                        MobileNum = x.MobileNum,
                        ModifiedDate = x.ModifiedDate,
                        ModifiedUser = x.ModifiedUser,
                        OwnerName = x.OwnerName,
                        PhoneNum = x.PhoneNum,
                        ProvinceCode = x.ProvinceCode,
                        Region = x.Region,
                        TaxCode = x.TaxCode,
                        ParentName = dbContext.DacCustomer.FirstOrDefault(y => y.Code == x.DependCode).Name
                    }).OrderByDescending(x => x.CreatedDate).ToList();
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacAgency> GetById(int id)
        {
            var response = new BaseViewModel<DacAgency>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    response.ResponseData = dbContext.DacCustomer.FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacAgency> Create(DacAgency newAgency)
        {
            var response = new BaseViewModel<DacAgency>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    newAgency.CreatedDate = DateTime.Now;
                    dbContext.DacCustomer.Add(newAgency);
                    dbContext.SaveChanges();
                    response.ResponseData = newAgency;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacAgency> Edit(DacAgency agency)
        {
            var response = new BaseViewModel<DacAgency>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    agency.ModifiedDate = DateTime.Now;
                    dbContext.Entry(agency).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    response.ResponseData = agency;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> Delete(int id)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var agency = dbContext.DacCustomer.FirstOrDefault(x => x.Id == id);
                    if (agency != null)
                    {
                        dbContext.DacCustomer.Remove(agency);
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

        public BaseViewModel<bool> HasUsed(string code)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    response.ResponseData = dbContext.DacCustomer.Any(x => x.DependCode == code) || dbContext.DacStore.Any(x => x.AgencyCode == code)
                        || dbContext.DacExport.Any(x => x.CustomerCode == code);
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
                response.ResponseData = true;
            }
            return response;
        }

        public BaseViewModel<DacAgency> GetByCode(string code)
        {
            var response = new BaseViewModel<DacAgency>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    response.ResponseData = dbContext.DacCustomer.FirstOrDefault(x => x.Code == code);
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacCustomerVM> GetIncludeStores(string code)
        {
            var response = new BaseViewModel<DacCustomerVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var agency = dbContext.DacCustomer.Where(x => x.Code == code).Select(x => new DacCustomerVM
                    {
                        Id = x.Id,
                        Code = x.Code,
                        Name = x.Name,
                        Address = x.Address,
                        DependCode = x.DependCode,
                        Region = x.Region,
                        Description = x.Description,
                        Active = x.Active,
                        CreatedDate = x.CreatedDate,
                        CreatedUser = x.CreatedUser,
                        Email = x.Email,
                        JoinContact = x.JoinContact,
                        MobileNum = x.MobileNum,
                        ModifiedDate = x.ModifiedDate,
                        ModifiedUser = x.ModifiedUser,
                        OwnerName = x.OwnerName,
                        PhoneNum = x.PhoneNum,
                        ProvinceCode = x.ProvinceCode,
                        TaxCode = x.TaxCode,
                        LstStore = dbContext.DacStore.Where(y => y.AgencyCode == code).ToList()
                    }).FirstOrDefault();
                    response.ResponseData = agency;
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
                var agencies = new List<DacAgency>();

                FileInfo fileInfo = new FileInfo(filePath);
                using (var package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                    int rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        string AgencyCode = worksheet.Cells[row, 2].Text;
                        if (!string.IsNullOrWhiteSpace(AgencyCode))
                        {
                            var ExsitedAgency = GetByCode(AgencyCode).ResponseData;
                            if (ExsitedAgency == null)
                            {
                                var agency = new DacAgency
                                {
                                    Code = worksheet.Cells[row, 2].Text,
                                    Name = worksheet.Cells[row, 3].Text,
                                    Address = worksheet.Cells[row, 4].Text,
                                    ProvinceCode = worksheet.Cells[row, 5].Text,
                                    JoinContact = worksheet.Cells[row, 6].Text,
                                    OwnerName = worksheet.Cells[row, 7].Text,
                                    TaxCode = worksheet.Cells[row, 8].Text,
                                    PhoneNum = worksheet.Cells[row, 9].Text,
                                    MobileNum = worksheet.Cells[row, 10].Text,
                                    Email = worksheet.Cells[row, 11].Text,
                                    DependCode = worksheet.Cells[row, 12].Text,
                                    Region = worksheet.Cells[row, 13].Text,
                                    Description = worksheet.Cells[row, 18].Text,
                                    Active = true,
                                    CreatedDate = DateTime.Now,
                                    CreatedUser = (!string.IsNullOrWhiteSpace(UserName) ? UserName + "-" : string.Empty) + "ImportTool"
                                };

                                agencies.Add(agency);
                            }
                            else
                            {
                                response.ErrorMessage += "\r\nMã " + AgencyCode + " đã tồn tại.";
                            }
                        }
                        else
                        {
                            response.ErrorMessage += "\r\nDòng " + row + " không có mã đại lý.";
                        }
                    }
                }

                using (var db = new PIPTDbContext())
                {
                    db.DacCustomer.AddRange(agencies);
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

        public bool RestoreData()
        {
            List<DacAgency> LstAgency = new List<DacAgency>();
            try
            {
                using (var oldVersionDbContext = new PIPTOldVerDbContext())
                {
                    var data = oldVersionDbContext.DacAgency?.ToList();
                    if (data != null && data.Any())
                    {
                        foreach (var item in data)
                        {
                            DacAgency restoreData = new DacAgency();
                            restoreData.Code = item.Code;
                            restoreData.Name = item.Name;
                            restoreData.Address = item.Address;
                            restoreData.ProvinceCode = item.ProvinceCode;
                            restoreData.OwnerName = item.OwnerName;
                            restoreData.TaxCode = item.TaxCode;
                            restoreData.PhoneNum = item.PhoneNum;
                            restoreData.MobileNum = item.MobileNum;
                            restoreData.Email = item.Email;
                            restoreData.Description = item.Description;
                            restoreData.JoinContact = item.JoinContact;
                            restoreData.DependCode = item.DependCode;
                            restoreData.Region = item.Region;
                            restoreData.CreatedDate = item.CreatedDate;
                            restoreData.CreatedUser = item.CreatedUser;
                            restoreData.ModifiedDate = item.ModifiedDate;
                            restoreData.ModifiedUser = item.ModifiedUser;
                            restoreData.Active = item.Active;
                            LstAgency.Add(restoreData);
                        }
                    }
                }
                if (LstAgency != null && LstAgency.Any())
                {
                    using (var dbContext = new PIPTDbContext())
                    {
                        dbContext.DacCustomer.AddRange(LstAgency);
                        dbContext.SaveChanges();
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
