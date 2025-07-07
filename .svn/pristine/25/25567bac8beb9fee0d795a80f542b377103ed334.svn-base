using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DacAgencyController : ControllerBase
    {
        private readonly PIPTDbContext _dbContext;
        public DacAgencyController(PIPTDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<ResultApiModel<DacAgency>> GetPagingAgencies([FromBody] PaginatedInputModel pagination)
        {
            PaginatedList<DacAgency> paginatedList;
            var resultApiModel = new ResultApiModel<DacAgency>();
            try
            {
                var queryable = _dbContext.DacAgency.AsQueryable();
                #region [Filter]
                if (pagination != null)
                {
                    if (pagination.FilterParams != null)
                        queryable = FilterUtility.Filter<DacAgency>.FilteredData(pagination.FilterParams, queryable) ?? queryable;
                }
                #endregion
                #region [Sorting]
                if (pagination != null && pagination.SortingParams != null)
                {
                    if (pagination.SortingParams.Count() > 0 && Enum.IsDefined(typeof(SortingUtility.SortOrders), pagination.SortingParams.Select(x => x.SortOrder)))
                        queryable = SortingUtility.Sorting<DacAgency>.SortData(queryable, pagination.SortingParams);
                }
                #endregion
                #region [Grouping]
                if (pagination != null && pagination.GroupingColumns != null)
                {
                    if (pagination.GroupingColumns.Count() > 0)
                        queryable = SortingUtility.Sorting<DacAgency>.GroupingData(queryable, pagination.GroupingColumns) ?? queryable;
                }
                #endregion
                #region [Paging]
                if (pagination != null)
                {
                    paginatedList = await PaginatedList<DacAgency>.CreateAsync(queryable, pagination.PageNumber, pagination.PageSize);
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
        [HttpPost("GetPagingAgenciesByUserName")]
        public async Task<ResultApiModel<DacAgency>> GetPagingAgenciesByUserName([FromBody] PaginatedInputModel pagination, [FromQuery] string UserName)
        {
            PaginatedList<DacAgency> paginatedList;
            var resultApiModel = new ResultApiModel<DacAgency>();
            try
            {
                var queryable = (from a in _dbContext.DacAgency 
                                 join u in _dbContext.SecUsers on a.ID equals u.AgencyId 
                                 where u.UserName == UserName 
                                 select a);
                var agency = queryable.FirstOrDefault();
                if (agency != null)
                {
                    var childAgency = _dbContext.DacAgency.Where(x => x.DependCode == agency.Code);
                    queryable = queryable.Union(childAgency);
                } 
                    
                #region [Filter]
                if (pagination != null)
                {
                    if (pagination.FilterParams != null)
                        queryable = FilterUtility.Filter<DacAgency>.FilteredData(pagination.FilterParams, queryable) ?? queryable;
                }
                #endregion
                #region [Sorting]
                if (pagination != null && pagination.SortingParams != null)
                {
                    if (pagination.SortingParams.Count() > 0 && Enum.IsDefined(typeof(SortingUtility.SortOrders), pagination.SortingParams.Select(x => x.SortOrder)))
                        queryable = SortingUtility.Sorting<DacAgency>.SortData(queryable, pagination.SortingParams);
                }
                #endregion
                #region [Grouping]
                if (pagination != null && pagination.GroupingColumns != null)
                {
                    if (pagination.GroupingColumns.Count() > 0)
                        queryable = SortingUtility.Sorting<DacAgency>.GroupingData(queryable, pagination.GroupingColumns) ?? queryable;
                }
                #endregion
                #region [Paging]
                if (pagination != null)
                {
                    paginatedList = await PaginatedList<DacAgency>.CreateAsync(queryable, pagination.PageNumber, pagination.PageSize);
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
        public async Task<List<DacAgency>> GetAgencies([FromQuery] bool? Active)
        {
            if (!Active.HasValue)
            {
                try
                {
                    var DacAgencies = await _dbContext.DacAgency.ToListAsync();
                    return DacAgencies;
                }
                catch (Exception ex)
                {

                    return new List<DacAgency>();
                }
            }
            else
            {
                try
                {
                    var DacAgencies = await _dbContext.DacAgency.Where(x => x.Active == Active).ToListAsync();
                    return DacAgencies;
                }
                catch (Exception ex)
                {

                    return new List<DacAgency>();
                }
            }  
        }
        [HttpGet("GetAgencyById")]
        public async Task<DacAgency> GetAgencyById([FromQuery] int AgencyId)
        {
            try
            {
                var Agency = await _dbContext.DacAgency.FindAsync(AgencyId);
                return Agency;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("GetAgencyByCode")]
        public async Task<DacAgency> GetAgencyByCode([FromQuery] string AgencyCode)
        {
            try
            {
                var Agency = await _dbContext.DacAgency.SingleOrDefaultAsync(x => x.Code == AgencyCode);
                return Agency;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("GetAgencyByName")]
        public async Task<List<DacAgency>> GetAgencyByName([FromQuery] string AgencyName)
        {
            try
            {
                var LstAgency = await _dbContext.DacAgency.Where(x => x.Name == AgencyName).ToListAsync();
                return LstAgency;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("GetAgencyByUserName")]
        public async Task<DacAgency> GetAgencyByUserName([FromQuery] string UserName)
        {
            try
            {
                var Agency = await ((from u in _dbContext.SecUsers
                                     join a in _dbContext.DacAgency on u.AgencyId equals a.ID
                                     where u.UserName == UserName
                                     select a).SingleOrDefaultAsync());
                return Agency;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("GetParentAgencyByUserName")]
        public async Task<DacAgency> GetParentAgencyByUserName([FromQuery] string UserName)
        {
            try
            {
                var Agency = await ((from u in _dbContext.SecUsers
                                     join a in _dbContext.DacAgency on u.AgencyId equals a.ID
                                     where u.UserName == UserName
                                     select a).SingleOrDefaultAsync());
                if (Agency != null)
                {
                    var ParentAgency = _dbContext.DacAgency.SingleOrDefault(x => x.Code == Agency.DependCode);
                    return ParentAgency;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("GetChildrenByAgencyId")]
        public async Task<List<DacAgency>> GetChildrenByAgencyId([FromQuery] int AgencyId)
        {
            try
            {
                var Children = await ((from c in _dbContext.DacAgency
                                     join a in _dbContext.DacAgency on c.DependCode equals a.Code
                                     where a.ID == AgencyId
                                     select c).ToListAsync());
                return Children;
            }
            catch (Exception ex)
            {
                return new List<DacAgency>();
            }
        }
        [HttpGet("GetChildrenAgenciesByUserName")]
        public async Task<ResultApiModel<DacAgency>> GetChildrenAgenciesByUserName([FromQuery] string UserName)
        {
            var resultApiModel = new ResultApiModel<DacAgency>();
            try
            {
                var Agency = await ((from u in _dbContext.SecUsers
                                     join a in _dbContext.DacAgency on u.AgencyId equals a.ID
                                     where u.UserName == UserName
                                     select a).SingleOrDefaultAsync());
                if (Agency != null)
                {
                    var queryable = await _dbContext.DacAgency.Where(x => x.DependCode == Agency.Code).ToListAsync();
                    resultApiModel.Data = queryable;
                }
                else
                {
                    resultApiModel.Data = new List<DacAgency>();
                }
                resultApiModel.Status = "Success";
                resultApiModel.Code = "200";
                resultApiModel.Message = "Thành công";
                resultApiModel.Pagination = null;
            }
            catch (Exception ex)
            {
                resultApiModel.Status = "Eror";
                resultApiModel.Code = "";
                resultApiModel.Message = "Có lỗi xảy ra trong quá trình lấy dữ liệu!";
                resultApiModel.Data = null;
                resultApiModel.Records = 0;
                resultApiModel.Pagination = null;
            }
            return resultApiModel;
        }
        [HttpPost("Create")]
        public async Task<ResultApiModel<DacAgency>> Create(DacAgency request)
        {
            var resultApiModel = new ResultApiModel<DacAgency>();
            try
            {
                var Agency = _dbContext.DacAgency.FirstOrDefault(x => x.Code == request.Code);
                if (Agency != null)
                {
                    resultApiModel.Status = "Eror";
                    resultApiModel.Code = "500";
                    resultApiModel.Message = "Mã đại lý đã tồn tại!";
                    resultApiModel.Data = null;
                    resultApiModel.Records = 0;
                    resultApiModel.Pagination = null;
                    return resultApiModel;
                }
                _dbContext.DacAgency.Add(request);
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
        public async Task<ResultApiModel<DacAgency>> Edit(DacAgency request)
        {
            var resultApiModel = new ResultApiModel<DacAgency>();
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
                var Agency = await _dbContext.DacAgency.FindAsync(id);
                if (Agency != null)
                {
                    var ChildrenAgencies = _dbContext.DacAgency.Where(x => x.DependCode == Agency.Code);
                    if (ChildrenAgencies != null && ChildrenAgencies.Count() > 0)
                    {
                        return "500";
                    }
                    _dbContext.DacAgency.Remove(Agency);
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
