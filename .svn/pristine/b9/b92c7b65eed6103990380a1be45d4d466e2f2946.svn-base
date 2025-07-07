using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SecRoleController : ControllerBase
    {
        private readonly PIPTDbContext _dbContext;
        //private readonly PIPTWebLogger Logger;
        private readonly int Claim_UserName = 1;

        public SecRoleController(PIPTDbContext oneAppDbContext)
        {
            _dbContext = oneAppDbContext;
            //Logger = new PIPTWebLogger(_dbContext);
        }

        [HttpPost]
        public async Task<ResultApiModel<SecRoles>> GetRoles([FromBody] PaginatedInputModel pagination)
        {
            PaginatedList<SecRoles> paginatedList;
            var resultApiModel = new ResultApiModel<SecRoles>();
            try
            {
                var queryable = _dbContext.Roles.AsQueryable();
                #region [Filter]
                if (pagination != null)
                {
                    if (pagination.FilterParams != null)
                        queryable = FilterUtility.Filter<SecRoles>.FilteredData(pagination.FilterParams, queryable) ?? queryable;
                }
                #endregion
                #region [Sorting]
                if (pagination != null && pagination.SortingParams != null)
                {
                    if (pagination.SortingParams.Count() > 0 && Enum.IsDefined(typeof(SortingUtility.SortOrders), pagination.SortingParams.Select(x => x.SortOrder)))
                        queryable = SortingUtility.Sorting<SecRoles>.SortData(queryable, pagination.SortingParams);
                }
                #endregion
                #region [Grouping]
                if (pagination != null && pagination.GroupingColumns != null)
                {
                    if (pagination.GroupingColumns.Count() > 0)
                        queryable = SortingUtility.Sorting<SecRoles>.GroupingData(queryable, pagination.GroupingColumns) ?? queryable;
                }
                #endregion
                #region [Paging]
                if (pagination != null)
                {
                    paginatedList = await PaginatedList<SecRoles>.CreateAsync(queryable, pagination.PageNumber, pagination.PageSize);
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
                //Logger.Log<string>(LogLevel.Error, new EventId(), null, ex, null);
                //resultApiModel.Status = "Fail";
                //resultApiModel.Code = "505";
                //resultApiModel.Message = ex.Message;
                //resultApiModel.Data = null;
                //resultApiModel.Records = 0;
                //resultApiModel.Pagination = null;
            }
            return resultApiModel;
        }

        [HttpGet("{id}")]
        public async Task<SecRoles> GetRoleById(string id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            return role;
        }

        [HttpPost("Create")]
        public async Task<SecRoles> Create(SecRoles request)
        {
            if (!string.IsNullOrEmpty(request.Name))
            {
                try
                {
                    _dbContext.Roles.Add(request);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    //LogParams param = new();
                    //param.RequestParam = request;
                    //param.UserName = HttpContext.User.Claims?.ToList()[Claim_UserName]?.Value;
                    //param.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                    //Logger.Log(LogLevel.Error, new EventId(), param, ex, (param, ex) => { return Newtonsoft.Json.JsonConvert.SerializeObject(param); });
                    return null;
                }
            }
            return request;
        }

        [HttpPost("Edit/{id}")]
        public async Task<SecRoles> Edit(string id, SecRoles request)
        {
            if (id != request.Id)
            {
                return null;
            }
            _dbContext.Entry(request).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return request;
        }

        [HttpPost("Delete/{id}")]
        public async Task<int> Delete(string id)
        {
            // Nếu role đã được gán thì không xóa được
            var role = await _dbContext.Roles.FindAsync(id);
            var roleUser = await _dbContext.UserRoles.FirstOrDefaultAsync(ur => ur.RoleId == id);
            var roleMenu = await _dbContext.SecRoleMenus.FirstOrDefaultAsync(rm => rm.RoleID == id);
            if (role == null)
                return -1;
            if (roleUser != null || roleMenu != null)
                return 0;
            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        [HttpGet]
        public async Task<List<SecRoles>> GetAllRoles()
        {
            return await _dbContext.Roles.ToListAsync();
        }
    }
}
