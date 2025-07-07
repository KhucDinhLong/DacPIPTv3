using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacInsertToWarehouseDetailsService : IDacInsertToWarehouseDetailsService
    {
        public BaseViewModel<DacInsertToWarehouseDetails> GetByDacCode(string DacCode)
        {
            var response = new BaseViewModel<DacInsertToWarehouseDetails>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var detail = dbContext.DacInsertToWarehouseDetails.FirstOrDefault(x => x.DacCode == DacCode);
                    response.ResponseData = detail;
                }
            }
            catch (Exception ex)
            {
                response.ex = ex;
            }
            return response;
        }

        public BaseViewModel<bool> AddRange(List<DacInsertToWarehouseDetails> LstDetail)
        {
            var response = new BaseViewModel<bool>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    dbContext.DacInsertToWarehouseDetails.AddRange(LstDetail);
                    int? ImportId = LstDetail.FirstOrDefault().InsertID;
                    if (ImportId.HasValue)
                    {
                        var importInfo = dbContext.DacInsertToWarehouse.FirstOrDefault(x => x.Id == ImportId);
                        if (importInfo != null && importInfo.Quantity.HasValue)
                        {
                            importInfo.Quantity = importInfo.Quantity.Value + LstDetail.Count;
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
                    var detail = dbContext.DacInsertToWarehouseDetails.Where(x => LstDacCode.Contains(x.DacCode));
                    if (detail != null && detail.Any())
                    {
                        dbContext.DacInsertToWarehouseDetails.RemoveRange(detail);
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
                    var detail = dbContext.DacInsertToWarehouseDetails.FirstOrDefault(x => x.DacCode == DacCode);
                    if (detail != null)
                    {
                        var importInfo = dbContext.DacInsertToWarehouse.FirstOrDefault(x => x.Id == detail.InsertID);
                        dbContext.DacInsertToWarehouseDetails.Remove(detail);
                        if (importInfo != null)
                        {
                            importInfo.Quantity--;
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
