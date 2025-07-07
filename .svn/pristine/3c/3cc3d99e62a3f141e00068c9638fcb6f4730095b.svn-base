using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PIPTWeb.Shared.Data;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneApp.Server.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoleClaimsController : ControllerBase
    {
        private readonly PIPTDbContext _dbContext;
        private readonly RoleManager<SecRoles> _roleManager;
        //private readonly PIPTWebLogger Logger;
        private readonly int Claim_UserName = 1;
        public RoleClaimsController(PIPTDbContext oneAppDbContext, RoleManager<SecRoles> roleManager)
        {
            _dbContext = oneAppDbContext;
            _roleManager = roleManager;
            //Logger = new PIPTWebLogger(_dbContext);
        }

        [HttpGet("getClaims")]
        public async Task<ResultApiModel<RoleClaimsViewModel>> GetClaimByRole(string roleId)
        {
            var ResultApiModel = new ResultApiModel<RoleClaimsViewModel>();
            var RoleClaims = new List<RoleClaimsViewModel>();
            RoleClaims = await (from rc in _dbContext.RoleClaims
                                where rc.RoleId == roleId
                                select new RoleClaimsViewModel
                                {
                                    Type = rc.ClaimType,
                                    Value = rc.ClaimValue,
                                    Selected = true
                                }).ToListAsync();
            ResultApiModel.Code = "200";
            ResultApiModel.Status = "Success";
            ResultApiModel.Message = "Thành công";
            ResultApiModel.Records = RoleClaims.Count();
            if (RoleClaims != null && RoleClaims.Count != 0)
            {
                ResultApiModel.Data = RoleClaims;
            }
            else
            {
                ResultApiModel.Data = new List<RoleClaimsViewModel>();
            }
            return ResultApiModel;
        }

        [HttpPost("addClaims")]
        public async Task<ResultApiModel<int>> AddRoleClaims([FromBody] PermissionViewModel roleClaims)
        {
            ResultApiModel<int> resultApiModel = new ResultApiModel<int>();
            if(roleClaims != null)
            {
                try
                {
                    var role = await _roleManager.FindByIdAsync(roleClaims.RoleId);
                    foreach(var roleClaim in roleClaims.RoleClaims)
                    {
                        await _roleManager.AddClaimAsync(role, new System.Security.Claims.Claim(roleClaim.Type, roleClaim.Value));
                    }
                    resultApiModel.Code = "200";
                    resultApiModel.Status = "Success";
                    resultApiModel.Message = "Không có dữ liệu để lưu vào Claims";
                    resultApiModel.Records = roleClaims.RoleClaims.Count;
                }
                catch (Exception ex)
                {
                    //LogParams param = new();
                    //param.RequestParam = roleClaims;
                    //param.UserName = HttpContext.User.Claims?.ToList()[Claim_UserName]?.Value;
                    //param.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                    //Logger.Log(LogLevel.Error, new EventId(), param, ex, (param, ex) => { return Newtonsoft.Json.JsonConvert.SerializeObject(param); });
                    //resultApiModel.Code = "505";
                    //resultApiModel.Status = "Fail";
                    //resultApiModel.Message = "Lỗi lưu claims vào cơ sở dữ liệu, bạn liên hệ quản trị mạng!";
                    //resultApiModel.Records = 0;
                }
            }   
            else
            {
                resultApiModel.Code = "505";
                resultApiModel.Status = "Fail";
                resultApiModel.Message = "Không có dữ liệu để lưu vào Claims";
                resultApiModel.Records = 0;
            }
            return resultApiModel;
        }

        [HttpDelete]
        public async Task DeleteRoleClaims([FromQuery] string roleId)
        {
            var LstMenu = _dbContext.RoleClaims.Where(x => x.RoleId == roleId);
            if (LstMenu != null && LstMenu.Count() > 0)
            {
                _dbContext.RoleClaims.RemoveRange(LstMenu);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
