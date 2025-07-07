using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PIPTWeb.Server.Logging;
using PIPTWeb.Shared.Data;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.Parameters;
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
    public class RoleMenuController : ControllerBase
    {
        private readonly PIPTDbContext _dbContext;
        private readonly PIPTWebLogger Logger;
        private readonly int Claim_UserName = 1;
        public RoleMenuController(PIPTDbContext oneAppDbContext)
        {
            _dbContext = oneAppDbContext;
            Logger = new PIPTWebLogger(_dbContext);
        }

        [HttpPost("Create")]
        public async Task<ResultApiModel<SecRoleMenu>> Create(SecRoleMenu request)
        {
            var ResultApiModel = new ResultApiModel<SecRoleMenu>();
            if (!string.IsNullOrEmpty(request.RoleID) && request.MenuID > 0)
            {
                try
                {
                    _dbContext.SecRoleMenus.Add(request);
                    await _dbContext.SaveChangesAsync();
                    ResultApiModel.Code = "201";
                    ResultApiModel.Status = "Success";
                    ResultApiModel.Message = "Thành công";
                }
                catch (Exception ex)
                {
                    LogParams param = new();
                    param.RequestParam = request;
                    param.UserName = HttpContext.User.Claims?.ToList()[Claim_UserName]?.Value;
                    param.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                    Logger.Log(LogLevel.Error, new EventId(), param, ex, (param, ex) => { return Newtonsoft.Json.JsonConvert.SerializeObject(param); });
                    ResultApiModel.Code = "505";
                    ResultApiModel.Status = "Fail";
                    ResultApiModel.Message = "Error";
                }
            }
            return ResultApiModel;
        }
        [HttpGet("getmenu")]
        public async Task<ResultApiModel<RoleMenusViewModel>> GetMenuByRole([FromQuery] string roleId)
        {
            var ResultApiModel = new ResultApiModel<RoleMenusViewModel>();
            var RoleMenus = new List<RoleMenusViewModel>();
            // Lấy tất cả menu
            var allMenus = await _dbContext.SysMenus.ToListAsync();
            // Lấy Menu theo roleId
            var rolemenus = await (from rm in _dbContext.SecRoleMenus
                                   join m in _dbContext.SysMenus on rm.MenuID equals m.ID
                                   where rm.RoleID == roleId
                                   select m).ToListAsync();
            // Lấy danh sách menu được gán quyền
            var authorizedMenus = new List<SysMenu>();
            if (rolemenus.Count > 0)
            {
                authorizedMenus = allMenus.Intersect(rolemenus).ToList();
            }
            foreach(var menu in allMenus)
            {
                var roleMenu = new RoleMenusViewModel {
                    ID = menu.ID,
                    Value = menu.Value,
                    Link = menu.Link,
                    Icon = menu.Icon,
                    ParentID = menu.ParentID,
                    SortOrder = menu.SortOrder,
                    Active = menu.Active,
                    Selected = false
                };
                if(authorizedMenus.Any(m => m.ID == menu.ID))
                {
                    roleMenu.Selected = true;
                }
                RoleMenus.Add(roleMenu);
            }    
            ResultApiModel.Code = "200";
            ResultApiModel.Status = "Success";
            ResultApiModel.Message = "Thành công";
            ResultApiModel.Records = RoleMenus.Count();
            if (allMenus != null && allMenus.Count != 0)
            {
                ResultApiModel.Data = RoleMenus;
            }
            else
            {
                ResultApiModel.Data = new List<RoleMenusViewModel>();
            }
            return ResultApiModel;
        }

        [HttpPost("addRoleMenus")]
        public async Task<ResultApiModel<int>> AddRoleMenus([FromBody] ManagerRoleMenusViewModel roleMenus)
        {
            ResultApiModel<int> resultApiModel = new ResultApiModel<int>();
            if (roleMenus != null)
            {
                try
                {
                    foreach (var roleMenu in roleMenus.RoleMenus)
                    {
                        SecRoleMenu menu = new SecRoleMenu { MenuID = roleMenu.ID, RoleID = roleMenus.RoleId };
                        _dbContext.SecRoleMenus.Add(menu);
                    }
                    await _dbContext.SaveChangesAsync();
                    resultApiModel.Code = "200";
                    resultApiModel.Status = "Success";
                    resultApiModel.Message = "Không có dữ liệu để lưu vào Claims";
                    resultApiModel.Records = roleMenus.RoleMenus.Count;
                }
                catch (Exception ex)
                {
                    LogParams param = new();
                    param.RequestParam = roleMenus;
                    param.UserName = HttpContext.User.Claims?.ToList()[Claim_UserName]?.Value;
                    param.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                    Logger.Log(LogLevel.Error, new EventId(), param, ex, (param, ex) => { return Newtonsoft.Json.JsonConvert.SerializeObject(param); });
                    resultApiModel.Code = "505";
                    resultApiModel.Status = "Fail";
                    resultApiModel.Message = "Lỗi lưu claims vào cơ sở dữ liệu, bạn liên hệ quản trị mạng!";
                    resultApiModel.Records = 0;
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
        public async Task DeleteMenuByRole([FromQuery] string roleId)
        {
            var LstMenu = _dbContext.SecRoleMenus.Where(x => x.RoleID == roleId);
            if (LstMenu != null && LstMenu.Count() > 0)
            {
                _dbContext.SecRoleMenus.RemoveRange(LstMenu);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
