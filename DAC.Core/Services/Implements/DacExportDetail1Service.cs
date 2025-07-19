using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public static class DacExportDetail1Service
    {
        public static BaseViewModel<bool> AddRange(List<DacExportDetailVM> LstDetail)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    if (LstDetail != null && LstDetail.Any())
                    {
                        var details = LstDetail.Select(x => new DacExportDetail1 { Id = x.Id, ExportId = x.ExportId, DacCode = x.DacCode, ProductCode = x.ProductCode });
                        dbContext.DacExportDetail1.AddRange(details);
                        int? ExportId = LstDetail.FirstOrDefault().ExportId;
                        if (ExportId.HasValue)
                        {
                            var exportInfo = dbContext.DacExport1.FirstOrDefault(x => x.Id == ExportId);
                            if (exportInfo != null && exportInfo.Quantity.HasValue)
                            {
                                exportInfo.Quantity = exportInfo.Quantity.Value + LstDetail.Count;
                            }
                        }
                        response.ResponseData = dbContext.SaveChanges() > 0;
                    }
                    else
                    {
                        response.ResponseData = true;
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

        public static BaseViewModel<bool> DeleteByDacCode(List<string> LstDacCode)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var exporteds = dbContext.DacExportDetail2.Where(x => LstDacCode.Contains(x.DacCode))?.Select(x => x.DacCode).ToList();
                    if (exporteds != null)
                    {
                        LstDacCode = LstDacCode.Except(exporteds)?.ToList();
                        response.ErrorMessage = string.Join(",", exporteds);
                    }
                    if (LstDacCode != null)
                    {
                        var detail = dbContext.DacExportDetail1.Where(x => LstDacCode.Contains(x.DacCode));
                        if (detail != null && detail.Any())
                        {
                            int? ExportId = detail.FirstOrDefault().ExportId;
                            dbContext.DacExportDetail1.RemoveRange(detail);
                            if (ExportId.HasValue)
                            {
                                var exportInfo = dbContext.DacExport1.FirstOrDefault(x => x.Id == ExportId);
                                if (exportInfo != null && exportInfo.Quantity.HasValue && exportInfo.Quantity.Value > detail.Count())
                                {
                                    exportInfo.Quantity = exportInfo.Quantity.Value - detail.Count();
                                    if (exportInfo.Quantity <= 0)
                                    {
                                        dbContext.DacExport1.Remove(exportInfo);
                                    }
                                }
                            }
                            dbContext.SaveChanges();
                        }
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

        public static BaseViewModel<bool> DeleteByDacCode(string DacCode)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var detail = dbContext.DacExportDetail1.FirstOrDefault(x => x.DacCode == DacCode);
                    if (detail != null)
                    {
                        var exportInfo = dbContext.DacExport1.FirstOrDefault(x => x.Id == detail.ExportId);
                        dbContext.DacExportDetail1.Remove(detail);
                        if (exportInfo != null)
                        {
                            exportInfo.Quantity--;
                            if (exportInfo.Quantity <= 0)
                            {
                                dbContext.DacExport1.Remove(exportInfo);
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

        public static BaseViewModel<DacExportDetailVM> GetByDacCode(string DacCode)
        {
            var response = new BaseViewModel<DacExportDetailVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var detail = dbContext.DacExportDetail1.FirstOrDefault(x => x.DacCode == DacCode);
                    response.ResponseData = detail != null ? new DacExportDetailVM { Id = detail.Id, ExportId = detail.ExportId, DacCode = detail.DacCode, ProductCode = detail.ProductCode } : null;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public static BaseViewModel<DacExportVM> GetExportInfo(string DacCode)
        {
            var response = new BaseViewModel<DacExportVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var info = (from d in dbContext.DacExportDetail1
                                join e in dbContext.DacExport1 on d.ExportId equals e.Id
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

        public static BaseViewModel<bool> Exportable(string DacCode, string CustomerCode)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var info = (from d in dbContext.DacExportDetail
                                join e in dbContext.DacExport on d.ExportId equals e.Id
                                where d.DacCode == DacCode && e.CustomerCode == CustomerCode 
                                select d).FirstOrDefault();
                    response.ResponseData = info != null;
                }
            }
            catch (Exception ex)
            {
                response.ResponseData = false;
                response.ex = ex;
            }
            return response;
        }

        public static BaseViewModel<bool> Exported(string DacCode)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var exported = dbContext.DacExportDetail2.FirstOrDefault(x => x.DacCode == DacCode);
                    if (exported != null)
                    {
                        response.ResponseData = true;
                        response.ErrorMessage = "exported";
                    }
                    else
                    {
                        response.ResponseData = false;
                    }
                    return response;
                }
            }
            catch
            {
                response.ResponseData = true;
                return response;
            }
        }
    }
}
