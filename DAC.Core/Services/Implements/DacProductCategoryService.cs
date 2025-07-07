using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class DacProductCategoryService : IDacProductCategoryService
    {
        public BaseViewModel<List<DacProductCategory>> GetAll()
        {
            var response = new BaseViewModel<List<DacProductCategory>>();
            try
            {
                using (var dbContext = new PIPTDbContext())
                {
                    var queryable = dbContext.DacProductCategory.OrderByDescending(x => x.CreatedDate).ToList();
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
