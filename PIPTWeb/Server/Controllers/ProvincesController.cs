using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIPTWeb.Shared;
using PIPTWeb.Shared.Data;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly PIPTDbContext _dbContext;
        public ProvincesController(PIPTDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<ResultApiModel<Province>> GetPagingProvinces([FromBody] PaginatedInputModel pagination)
        {
            PaginatedList<Province> paginatedList;
            var resultApiModel = new ResultApiModel<Province>();
            try
            {
                var queryable = _dbContext.Province.AsQueryable();
                #region [Filter]
                if (pagination != null)
                {
                    if (pagination.FilterParams != null)
                        queryable = FilterUtility.Filter<Province>.FilteredData(pagination.FilterParams, queryable) ?? queryable;
                }
                #endregion
                #region [Sorting]
                if (pagination != null && pagination.SortingParams != null)
                {
                    if (pagination.SortingParams.Count() > 0 && Enum.IsDefined(typeof(SortingUtility.SortOrders), pagination.SortingParams.Select(x => x.SortOrder)))
                        queryable = SortingUtility.Sorting<Province>.SortData(queryable, pagination.SortingParams);
                }
                #endregion
                #region [Grouping]
                if (pagination != null && pagination.GroupingColumns != null)
                {
                    if (pagination.GroupingColumns.Count() > 0)
                        queryable = SortingUtility.Sorting<Province>.GroupingData(queryable, pagination.GroupingColumns) ?? queryable;
                }
                #endregion
                #region [Paging]
                if (pagination != null)
                {
                    paginatedList = await PaginatedList<Province>.CreateAsync(queryable, pagination.PageNumber, pagination.PageSize);
                    pagination.PagesQuantity = paginatedList.TotalPages;
                    resultApiModel.Data = paginatedList.Data;
                    resultApiModel.Records = paginatedList.Data.Count();
                }
                else
                {
                    resultApiModel.Data = queryable;
                    resultApiModel.Records = queryable.Count();
                }
                #endregion
                resultApiModel.Status = "Success";
                resultApiModel.Code = "200";
                resultApiModel.Message = "Thành công";
                resultApiModel.Pagination = pagination;
            }
            catch (Exception ex)
            {

            }
            return resultApiModel;
        }
        [HttpGet]
        public async Task<List<Province>> GetProvinces([FromQuery] bool? Active)
        {
            if (!Active.HasValue)
            {
                try
                {
                    var provinces = await _dbContext.Province.ToListAsync();
                    return provinces;
                }
                catch (Exception ex)
                {

                    return new List<Province>();
                }
            }
            else
            {
                try
                {
                    var provinces = await _dbContext.Province.Where(x => x.Active == Active).ToListAsync();
                    return provinces;
                }
                catch (Exception ex)
                {

                    return new List<Province>();
                }
            } 
                
        }
        [HttpGet("GetProvinceById")]
        public async Task<Province> GetProvinceById([FromQuery] int ProvinceId)
        {
            try
            {
                var province = await _dbContext.Province.FindAsync(ProvinceId);
                return province;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("GetProvinceByCode")]
        public async Task<Province> GetProvinceByCode([FromQuery] string ProvinceCode)
        {
            try
            {
                var province = await _dbContext.Province.SingleOrDefaultAsync(x => x.Code == ProvinceCode);
                return province;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("Create")]
        public async Task<ResultApiModel<Province>> Create(Province request)
        {
            var resultApiModel = new ResultApiModel<Province>();
            try
            {
                var province = _dbContext.Province.FirstOrDefault(x => x.Code == request.Code);
                if (province != null)
                {
                    resultApiModel.Status = "Eror";
                    resultApiModel.Code = "500";
                    resultApiModel.Message = "Mã tỉnh thành đã tồn tại!";
                    resultApiModel.Data = null;
                    resultApiModel.Records = 0;
                    resultApiModel.Pagination = null;
                    return resultApiModel;
                }
                _dbContext.Province.Add(request);
                await _dbContext.SaveChangesAsync();
                resultApiModel.Status = "Success";
                resultApiModel.Code = "201";
                resultApiModel.Message = "Thêm mới thành công!";
                resultApiModel.Data = null;
                resultApiModel.Records = 1;
                resultApiModel.Pagination = null;
            }
            catch (Exception ex)
            {
                resultApiModel.Status = "Eror";
                resultApiModel.Code = "";
                resultApiModel.Message = "Có lỗi xảy ra trong quá trình thêm dữ liệu!";
                resultApiModel.Data = null;
                resultApiModel.Records = 0;
                resultApiModel.Pagination = null;
            }
            return resultApiModel;
        }

        [HttpPut]
        public async Task<ResultApiModel<Province>> Edit(Province request)
        {
            var resultApiModel = new ResultApiModel<Province>();
            try
            {
                _dbContext.Entry(request).State = EntityState.Modified;
                _dbContext.Entry(request).Property(x => x.Code).IsModified = false;
                await _dbContext.SaveChangesAsync();
                resultApiModel.Status = "Success";
                resultApiModel.Code = "200";
                resultApiModel.Message = "Cập nhật thành công!";
                resultApiModel.Data = null;
                resultApiModel.Records = 1;
                resultApiModel.Pagination = null;
            }
            catch (Exception ex)
            {
                resultApiModel.Status = "Eror";
                resultApiModel.Code = "";
                resultApiModel.Message = "Cập nhật thất bại!";
                resultApiModel.Data = null;
                resultApiModel.Records = 0;
                resultApiModel.Pagination = null;
            }
            return resultApiModel;
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            try
            {
                var province = await _dbContext.Province.FindAsync(id);
                if (province != null)
                {
                    var ChildrenAgencies = _dbContext.DacAgency.Where(x => x.ProvinceCode == province.Code);
                    if (ChildrenAgencies != null && ChildrenAgencies.Count() > 0)
                    {
                        return "500";
                    }
                    _dbContext.Province.Remove(province);
                    await _dbContext.SaveChangesAsync();
                    return "204";
                }
                else
                {
                    return "200";
                }

            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
