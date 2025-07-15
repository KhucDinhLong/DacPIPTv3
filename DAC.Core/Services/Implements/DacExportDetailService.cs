using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacExportDetailService : IDacExportDetailService
    {
        public BaseViewModel<DacExportDetail> GetByDacCode(string DacCode)
        {
            var response = new BaseViewModel<DacExportDetail>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var detail = dbContext.DacExportDetail.FirstOrDefault(x => x.DacCode == DacCode);
                    response.ResponseData = detail;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> AddRange(List<DacExportDetail> LstDetail)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    dbContext.DacExportDetail.AddRange(LstDetail);
                    int? ExportId = LstDetail.FirstOrDefault().ExportId;
                    if (ExportId.HasValue)
                    {
                        var exportInfo = dbContext.DacExport.FirstOrDefault(x => x.Id == ExportId);
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
                    var detail = dbContext.DacExportDetail.Where(x => LstDacCode.Contains(x.DacCode));
                    if (detail != null && detail.Any())
                    {
                        dbContext.DacExportDetail.RemoveRange(detail);
                        int? ExportId = detail.FirstOrDefault().ExportId;
                        if (ExportId.HasValue)
                        {
                            var exportInfo = dbContext.DacExport.FirstOrDefault(x => x.Id == ExportId);
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
                    var detail = dbContext.DacExportDetail.FirstOrDefault(x => x.DacCode == DacCode);
                    if (detail != null)
                    {
                        var exportInfo = dbContext.DacExport.FirstOrDefault(x => x.Id == detail.ExportId);
                        dbContext.DacExportDetail.Remove(detail);
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

        public BaseViewModel<DacExportVM> GetExportInfo(string DacCode)
        {
            var response = new BaseViewModel<DacExportVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var info = (from d in dbContext.DacExportDetail
                                join e in dbContext.DacExport on d.ExportId equals e.Id
                                where d.DacCode == DacCode
                                select new DacExportVM
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
