using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public static class DacExportDetail3Service
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
                        var details = LstDetail.Select(x => new DacExportDetail3 { Id = x.Id, ExportId = x.ExportId, DacCode = x.DacCode, ProductCode = x.ProductCode });
                        dbContext.DacExportDetail3.AddRange(details);
                        int? ExportId = LstDetail.FirstOrDefault().ExportId;
                        if (ExportId.HasValue)
                        {
                            var exportInfo = dbContext.DacExport3.FirstOrDefault(x => x.Id == ExportId);
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
                    var detail = dbContext.DacExportDetail3.Where(x => LstDacCode.Contains(x.DacCode));
                    if (detail != null && detail.Any())
                    {
                        dbContext.DacExportDetail3.RemoveRange(detail);
                        int? ExportId = detail.FirstOrDefault().ExportId;
                        if (ExportId.HasValue)
                        {
                            var exportInfo = dbContext.DacExport3.FirstOrDefault(x => x.Id == ExportId);
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

        public static BaseViewModel<bool> DeleteByDacCode(string DacCode)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var detail = dbContext.DacExportDetail3.FirstOrDefault(x => x.DacCode == DacCode);
                    if (detail != null)
                    {
                        var exportInfo = dbContext.DacExport3.FirstOrDefault(x => x.Id == detail.ExportId);
                        dbContext.DacExportDetail3.Remove(detail);
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

        public static BaseViewModel<DacExportDetailVM> GetByDacCode(string DacCode)
        {
            var response = new BaseViewModel<DacExportDetailVM>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var detail = dbContext.DacExportDetail3.FirstOrDefault(x => x.DacCode == DacCode);
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
                    var info = (from d in dbContext.DacExportDetail3
                                join e in dbContext.DacExport on d.ExportId equals e.Id
                                join c in dbContext.DacCustomer on e.CustomerCode equals c.Code
                                where d.DacCode == DacCode
                                select new DacExportVM
                                {
                                    OrderNumber = e.OrderNumber,
                                    CustomerCode = e.CustomerCode,
                                    CustomerName = c.Name,
                                    CreatedDate = e.CreatedDate,
                                    ProductName = d.ProductCode
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
                    var info = (from d in dbContext.DacExportDetail2
                                join e in dbContext.DacExport2 on d.ExportId equals e.Id
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
    }
}
