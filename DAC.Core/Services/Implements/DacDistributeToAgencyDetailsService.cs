using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacDistributeToAgencyDetailsService : IDacDistributeToAgencyDetailsService
    {
        public BaseViewModel<DacDistributeToAgencyDetails> GetByDacCode(string DacCode)
        {
            var response = new BaseViewModel<DacDistributeToAgencyDetails>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var detail = dbContext.DacDistributeToAgencyDetails.FirstOrDefault(x => x.DacCode == DacCode);
                    response.ResponseData = detail;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> AddRange(List<DacDistributeToAgencyDetails> LstDetail)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    dbContext.DacDistributeToAgencyDetails.AddRange(LstDetail);
                    int? ExportId = LstDetail.FirstOrDefault().DistributeToAgencyId;
                    if (ExportId.HasValue)
                    {
                        var exportInfo = dbContext.DacDistributeToAgency.FirstOrDefault(x => x.Id == ExportId);
                        if (exportInfo != null && exportInfo.Quantity.HasValue)
                        {
                            exportInfo.Quantity = exportInfo.Quantity.Value + LstDetail.Count;
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
                    var detail = dbContext.DacDistributeToAgencyDetails.Where(x => LstDacCode.Contains(x.DacCode));
                    if (detail != null && detail.Any())
                    {
                        dbContext.DacDistributeToAgencyDetails.RemoveRange(detail);
                        int? ExportId = detail.FirstOrDefault().DistributeToAgencyId;
                        if (ExportId.HasValue)
                        {
                            var exportInfo = dbContext.DacDistributeToAgency.FirstOrDefault(x => x.Id == ExportId);
                            if (exportInfo != null && exportInfo.Quantity.HasValue && exportInfo.Quantity.Value > detail.Count())
                            {
                                exportInfo.Quantity = exportInfo.Quantity.Value - detail.Count();
                            }
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

        public BaseViewModel<bool> DeleteByDacCode(string DacCode)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var detail = dbContext.DacDistributeToAgencyDetails.FirstOrDefault(x => x.DacCode == DacCode);
                    if (detail != null)
                    {
                        var exportInfo = dbContext.DacDistributeToAgency.FirstOrDefault(x => x.Id == detail.DistributeToAgencyId);
                        dbContext.DacDistributeToAgencyDetails.Remove(detail);
                        if (exportInfo != null)
                        {
                            exportInfo.Quantity--;
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

        public BaseViewModel<DacDistributeToAgencyVM> GetExportInfo(string DacCode)
        {
            var response = new BaseViewModel<DacDistributeToAgencyVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var info = (from d in dbContext.DacDistributeToAgencyDetails
                                join e in dbContext.DacDistributeToAgency on d.DistributeToAgencyId equals e.Id
                                where d.DacCode == DacCode
                                select new DacDistributeToAgencyVM
                                {
                                    AgencyCode = e.AgencyCode,
                                    CreatedDate = e.CreatedDate,
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
