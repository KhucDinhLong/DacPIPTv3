using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacPackageDetailService : IDacPackageDetailService
    {
        public BaseViewModel<DacPackageDetails> GetByDacCode(string DacCode)
        {
            var response = new BaseViewModel<DacPackageDetails>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var detail = dbContext.DacPackageDetails.FirstOrDefault(x => x.DacCode == DacCode);
                    response.ResponseData = detail;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> AddRange(List<DacPackageDetails> LstDetail)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    dbContext.DacPackageDetails.AddRange(LstDetail);
                    int? PackageId = LstDetail.FirstOrDefault().PackageId;
                    if (PackageId.HasValue)
                    {
                        var packageInfo = dbContext.DacPackage.FirstOrDefault(x => x.Id == PackageId);
                        if (packageInfo != null && packageInfo.Quantity.HasValue)
                        {
                            packageInfo.Quantity = packageInfo.Quantity.Value + LstDetail.Count;
                        }
                    }
                    response.ResponseData = dbContext.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                response.ResponseData = false;
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> DeleteByDacCode(List<string> LstDacCode)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var detail = dbContext.DacPackageDetails.Where(x => LstDacCode.Contains(x.DacCode));
                    if (detail != null && detail.Any())
                    {
                        dbContext.DacPackageDetails.RemoveRange(detail);
                        dbContext.SaveChanges();
                    }
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

        public BaseViewModel<bool> DeleteByDacCode(string DacCode)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var detail = dbContext.DacPackageDetails.FirstOrDefault(x => x.DacCode == DacCode);
                    if (detail != null)
                    {
                        var packageInfo = dbContext.DacPackage.FirstOrDefault(x => x.Id == detail.PackageId);
                        dbContext.DacPackageDetails.Remove(detail);
                        if (packageInfo != null)
                        {
                            packageInfo.Quantity--;
                        }
                        dbContext.SaveChanges();
                    }
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
    }
}
