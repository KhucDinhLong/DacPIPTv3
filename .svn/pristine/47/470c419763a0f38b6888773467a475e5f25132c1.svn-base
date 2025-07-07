using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PIPTWeb.Shared.Data;
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
    public class UserRoleController : ControllerBase
    {
        private readonly PIPTDbContext _dbContext;
        //private readonly PIPTWebLogger Logger;
        private readonly int Claim_UserName = 1;
        public UserRoleController(PIPTDbContext oneAppDbContext)
        {
            _dbContext = oneAppDbContext;
            //Logger = new PIPTWebLogger(_dbContext);
        }

        [HttpPost("Create")]
        public async Task<IdentityUserRole<string>> Create(IdentityUserRole<string> request)
        {
            if (!string.IsNullOrEmpty(request.UserId) && !string.IsNullOrEmpty(request.RoleId))
            {
                try
                {
                    _dbContext.UserRoles.Add(request);
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
        [HttpPost("getrole")]
        public async Task<ResultApiModel<string>> GetRoleByUser([FromBody] string userId)
        {
            var ResultApiModel = new ResultApiModel<string>();
            var queryable = await (from r in _dbContext.Roles
                                   join ur in _dbContext.UserRoles on r.Id equals ur.RoleId
                                   join u in _dbContext.Users on ur.UserId equals u.Id
                                   where u.Id == userId
                                   select r.Id).ToListAsync();
            ResultApiModel.Code = "200";
            ResultApiModel.Status = "Success";
            ResultApiModel.Message = "Thành công";
            if (queryable != null && queryable.Count != 0)
            {
                ResultApiModel.Data = queryable;
            }
            else
            {
                ResultApiModel.Data = new List<string>();
            }
            return ResultApiModel;
        }
        [HttpDelete]
        public async Task DeleteRoleByUser([FromQuery] string userId)
        {
            var LstRole = _dbContext.UserRoles.Where(x => x.UserId == userId);
            if (LstRole != null && LstRole.Count() > 0)
            {
                _dbContext.UserRoles.RemoveRange(LstRole);
                await _dbContext.SaveChangesAsync();
            }
        }
        [HttpGet("getRoleClaims")]
        public async Task<ResultApiModel<RoleClaimsViewModel>> GetRoleClaims(string userId)
        {
            var ResultApiModel = new ResultApiModel<RoleClaimsViewModel>();
            var queryable = await (from ur in _dbContext.UserRoles
                                   join rc in _dbContext.RoleClaims on ur.RoleId equals rc.RoleId
                                   where ur.UserId == userId
                                   select rc).ToListAsync();
            ResultApiModel.Code = "200";
            ResultApiModel.Status = "Success";
            ResultApiModel.Message = "Thành công";
            if (queryable != null && queryable.Count != 0)
            {
                List<RoleClaimsViewModel> roleClaims = new List<RoleClaimsViewModel>();
                foreach (var roleClaim in queryable)
                {
                    roleClaims.Add(new RoleClaimsViewModel { Type = roleClaim.ClaimType, Value = roleClaim.ClaimValue, Selected = true });
                }
                ResultApiModel.Data = roleClaims;
            }
            else
            {
                ResultApiModel.Data = new List<RoleClaimsViewModel>();
            }
            return ResultApiModel;
        }
    }
}
