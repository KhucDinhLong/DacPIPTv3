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
    public class DacRegionsController : ControllerBase
    {
        private readonly PIPTDbContext _dbContext;
        public DacRegionsController(PIPTDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<ResultApiModel<DacRegion>> GetPagingRegions([FromBody] PaginatedInputModel pagination)
        {
            PaginatedList<DacRegion> paginatedList;
            var resultApiModel = new ResultApiModel<DacRegion>();
            try
            {
                var queryable = _dbContext.DacRegion.AsQueryable();
                #region [Filter]
                if (pagination != null)
                {
                    if (pagination.FilterParams != null)
                        queryable = FilterUtility.Filter<DacRegion>.FilteredData(pagination.FilterParams, queryable) ?? queryable;
                }
                #endregion
                #region [Sorting]
                if (pagination != null && pagination.SortingParams != null)
                {
                    if (pagination.SortingParams.Count() > 0 && Enum.IsDefined(typeof(SortingUtility.SortOrders), pagination.SortingParams.Select(x => x.SortOrder)))
                        queryable = SortingUtility.Sorting<DacRegion>.SortData(queryable, pagination.SortingParams);
                }
                #endregion
                #region [Grouping]
                if (pagination != null && pagination.GroupingColumns != null)
                {
                    if (pagination.GroupingColumns.Count() > 0)
                        queryable = SortingUtility.Sorting<DacRegion>.GroupingData(queryable, pagination.GroupingColumns) ?? queryable;
                }
                #endregion
                #region [Paging]
                if (pagination != null)
                {
                    paginatedList = await PaginatedList<DacRegion>.CreateAsync(queryable, pagination.PageNumber, pagination.PageSize);
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
        public async Task<List<DacRegion>> GetRegions([FromQuery] bool? Active)
        {
            if (!Active.HasValue)
            {
                try
                {
                    var regions = await _dbContext.DacRegion.ToListAsync();
                    return regions;
                }
                catch (Exception ex)
                {

                    return new List<DacRegion>();
                }
            }
            else
            {
                try
                {
                    var regions = await _dbContext.DacRegion.Where(x => x.Active == Active).ToListAsync();
                    return regions;
                }
                catch (Exception ex)
                {

                    return new List<DacRegion>();
                }
            }

        }
        [HttpGet("GetRegionById")]
        public async Task<DacRegion> GetRegionById([FromQuery] int RegionId)
        {
            try
            {
                var region = await _dbContext.DacRegion.FindAsync(RegionId);
                return region;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("GetRegionByCode")]
        public async Task<DacRegion> GetRegionByCode([FromQuery] string RegionCode)
        {
            try
            {
                var region = await _dbContext.DacRegion.SingleOrDefaultAsync(x => x.RegionCode == RegionCode);
                return region;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("Create")]
        public async Task<ResultApiModel<DacRegion>> Create(DacRegion request)
        {
            var resultApiModel = new ResultApiModel<DacRegion>();
            try
            {
                var region = _dbContext.DacRegion.FirstOrDefault(x => x.RegionCode == request.RegionCode);
                if (region != null)
                {
                    resultApiModel.Status = "Eror";
                    resultApiModel.Code = "500";
                    resultApiModel.Message = "Mã vùng miền đã tồn tại!";
                    resultApiModel.Data = null;
                    resultApiModel.Records = 0;
                    resultApiModel.Pagination = null;
                    return resultApiModel;
                }
                _dbContext.DacRegion.Add(request);
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
        public async Task<ResultApiModel<DacRegion>> Edit(DacRegion request)
        {
            var resultApiModel = new ResultApiModel<DacRegion>();
            try
            {
                _dbContext.Entry(request).State = EntityState.Modified;
                _dbContext.Entry(request).Property(x => x.RegionCode).IsModified = false;
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
                var region = await _dbContext.DacRegion.FindAsync(id);
                if (region != null)
                {
                    var ChildrenAgencies = _dbContext.DacAgency.Where(x => x.Region == region.RegionCode);
                    if (ChildrenAgencies != null && ChildrenAgencies.Count() > 0)
                    {
                        return "500";
                    }
                    _dbContext.DacRegion.Remove(region);
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
