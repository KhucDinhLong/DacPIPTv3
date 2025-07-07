using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacProductUnitService : IDacProductUnitService
    {
        public BaseViewModel<List<DacProductUnit>> GetAll()
        {
            var response = new BaseViewModel<List<DacProductUnit>>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var queryable = dbContext.DacProductUnit.OrderByDescending(x => x.Id).ToList();
                    response.ResponseData = queryable;
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
