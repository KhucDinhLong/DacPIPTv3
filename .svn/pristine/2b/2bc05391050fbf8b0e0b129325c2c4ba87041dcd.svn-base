using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PIPTWeb.Shared;
using PIPTWeb.Shared.Data;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Server.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SecUsersController : ControllerBase
    {
        private readonly PIPTDbContext _dbContext;
        private readonly UserManager<SecUsers> _userManager;
        //private readonly PIPTWebLogger Logger;

        public SecUsersController(PIPTDbContext oneAppDbContext, UserManager<SecUsers> userManager)
        {
            _dbContext = oneAppDbContext;
            _userManager = userManager;
            //Logger = new PIPTWebLogger(_dbContext);
        }

        [HttpPost]
        public async Task<ResultApiModel<SecUsers>> GetUsers([FromBody] PaginatedInputModel pagination)
        {
            PaginatedList<SecUsers> paginatedList;
            var resultApiModel = new ResultApiModel<SecUsers>();
            try
            {
                var queryable = _dbContext.Users.OrderBy(x => x.UserName).AsQueryable();
                #region [Filter]
                if (pagination != null)
                {
                    if (pagination.FilterParams != null)
                        queryable = FilterUtility.Filter<SecUsers>.FilteredData(pagination.FilterParams, queryable) ?? queryable;
                }
                #endregion
                #region [Sorting]
                if (pagination != null && pagination.SortingParams != null)
                {
                    if (pagination.SortingParams.Count() > 0 && Enum.IsDefined(typeof(SortingUtility.SortOrders), pagination.SortingParams.Select(x => x.SortOrder)))
                        queryable = SortingUtility.Sorting<SecUsers>.SortData(queryable, pagination.SortingParams);
                }
                #endregion
                #region [Grouping]
                if (pagination != null && pagination.GroupingColumns != null)
                {
                    if (pagination.GroupingColumns.Count() > 0)
                        queryable = SortingUtility.Sorting<SecUsers>.GroupingData(queryable, pagination.GroupingColumns) ?? queryable;
                }
                #endregion
                #region [Paging]
                paginatedList = await PaginatedList<SecUsers>.CreateAsync(queryable, pagination.PageNumber, pagination.PageSize);
                pagination.PagesQuantity = paginatedList.TotalPages;
                #endregion
                resultApiModel.Status = "Success";
                resultApiModel.Code = "200";
                resultApiModel.Message = "Thành công";
                resultApiModel.Data = paginatedList.Data;
                resultApiModel.Records = paginatedList.Data.Count();
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
        public async Task<SecUsers> GetUserById(string id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            return user;
        }

        [HttpPost("Create")]
        public async Task<SecUsers> Create(SecUsers request)
        {
            request.Avatar = "dist/img/avatar/default-avatar.jpg";
            if (!string.IsNullOrEmpty(request.UserName))
            {
                string PasswordDefault = request.UserName;
                await _userManager.CreateAsync(request, PasswordDefault);
            }
            return request;
        }

        [HttpPost("Edit/{id}")]
        public async Task<SecUsers> Edit(string id, SecUsers request)
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
        public async Task<bool> Delete(string id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
                return false;
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        
        [HttpPost("setpassword")]
        public async Task<bool> SetPassword([FromQuery] string UserName)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(UserName);
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, UserName);
                return true;
            }
            catch (Exception ex)
            {
                //Logger.Log<string>(LogLevel.Error, new EventId(), null, ex, null);
                return false;
            }
        }

        [HttpGet("GetByUserName")]
        public async Task<SecUsers> GetUserByUserName([FromQuery] string UserName)
        {
            return (await _dbContext.SecUsers.SingleOrDefaultAsync(x => x.UserName == UserName));
        }
        [HttpGet("GetCustomerByUserName")]
        public async Task<Customers> GetCustomerByUserName([FromQuery] string UserName)
        {
            var Customer = await ((from u in _dbContext.SecUsers
                                   join a in _dbContext.DacAgency on u.AgencyId equals a.ID
                                   join c in _dbContext.Customers on a.CustomerId equals c.Id
                                   select c).SingleOrDefaultAsync());
            return Customer;
        }
    }
}
