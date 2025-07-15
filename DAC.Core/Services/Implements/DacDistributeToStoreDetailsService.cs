using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacDistributeToStoreDetailsService : IDacDistributeToStoreDetailsService
    {
        public BaseViewModel<bool> AddRange(List<DacDistributeToStoreDetails> LstDetail)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    dbContext.DacDistributeToStoreDetails.AddRange(LstDetail);
                    int? ExportId = LstDetail.FirstOrDefault().DistributeToStoreId;
                    if (ExportId.HasValue)
                    {
                        var exportInfo = dbContext.DacExport2.FirstOrDefault(x => x.Id == ExportId);
                        if (exportInfo != null && exportInfo.Quantity.HasValue)
                        {
                            exportInfo.Quantity = exportInfo.Quantity.Value + LstDetail.Count();
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
                    var detail = dbContext.DacDistributeToStoreDetails.Where(x => LstDacCode.Contains(x.DacCode));
                    if (detail != null && detail.Any())
                    {
                        dbContext.DacDistributeToStoreDetails.RemoveRange(detail);
                        int? ExportId = detail.FirstOrDefault().DistributeToStoreId;
                        if (ExportId.HasValue)
                        {
                            var exportInfo = dbContext.DacExport2.FirstOrDefault(x => x.Id == ExportId);
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
                    var detail = dbContext.DacDistributeToStoreDetails.FirstOrDefault(x => x.DacCode == DacCode);
                    if (detail != null)
                    {
                        var exportInfo = dbContext.DacExport2.FirstOrDefault(x => x.Id == detail.DistributeToStoreId);
                        dbContext.DacDistributeToStoreDetails.Remove(detail);
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

        public BaseViewModel<DacDistributeToStoreDetails> GetByDacCode(string DacCode)
        {
            var response = new BaseViewModel<DacDistributeToStoreDetails>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var detail = dbContext.DacDistributeToStoreDetails.FirstOrDefault(x => x.DacCode == DacCode);
                    response.ResponseData = detail;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<DacExport2VM> GetExportInfo(string DacCode)
        {
            var response = new BaseViewModel<DacExport2VM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var info = (from d in dbContext.DacDistributeToStoreDetails
                                join e in dbContext.DacExport2 on d.DistributeToStoreId equals e.Id
                                where d.DacCode == DacCode
                                select new DacExport2VM
                                {
                                    CustomerCode = e.CustomerCode,
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
