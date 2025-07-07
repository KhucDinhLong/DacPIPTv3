using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIPTWeb.Shared;
using PIPTWeb.Shared.Data;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService authenticateService;
        private readonly IUserManagementService userManagmentService;
        private readonly UserManager<SecUsers> _userManager;
        private readonly PIPTDbContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public AuthenticationController(IAuthenticateService authenticateService, IUserManagementService userManagmentService,
            PIPTDbContext dbContext, UserManager<SecUsers> userManager, IWebHostEnvironment env)
        {
            this.authenticateService = authenticateService;
            this.userManagmentService = userManagmentService;
            _userManager = userManager;
            _dbContext = dbContext;
            _env = env;
        }

        [HttpPost]
        [Route("login")]
        public async Task<LoginResult> SecUser([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var user = await authenticateService.IsAuthenticatedUsers(loginRequest);
                if(user != null)
                {
                    var lstRole = (from r in _dbContext.Roles
                                   join ur in _dbContext.UserRoles on r.Id equals ur.RoleId
                                   join u in _dbContext.Users on ur.UserId equals u.Id
                                   where u.UserName == user.UserName
                                   select r).ToList();
                    var lstMenu = new List<SysMenu>();
                    if (user.IsAdmin.HasValue && user.IsAdmin.Value)
                    {
                        lstMenu = _dbContext.SysMenus.OrderBy(m => m.ParentID).ThenBy(m => m.SortOrder).ToList();
                    }
                    else
                    {
                        if (lstRole != null && lstRole.Count > 0)
                        {
                            foreach (SecRoles role in lstRole)
                            {
                                var Menus = ((from rm in _dbContext.SecRoleMenus 
                                             join m in _dbContext.SysMenus on rm.MenuID equals m.ID
                                             where rm.RoleID == role.Id
                                             select m).AsEnumerable() 
                                             .Union(from m in _dbContext.SysMenus 
                                                    let parent = (from mn in _dbContext.SysMenus 
                                                                 join rm in _dbContext.SecRoleMenus on mn.ID equals rm.MenuID
                                                                 where rm.RoleID == role.Id 
                                                                 select mn.ParentID).AsEnumerable()
                                                    where parent.Contains(m.ID) select m)).OrderBy(x => x.ParentID).ThenBy(x => x.SortOrder).ToList();
                                foreach (SysMenu menu in Menus)
                                {
                                    if (!lstMenu.Contains(menu))
                                        lstMenu.Add(menu);
                                }
                            }
                        }
                    }
                    // role claims for permission
                    var roleClaims = await (from ur in _dbContext.UserRoles
                                      join rc in _dbContext.RoleClaims on ur.RoleId equals rc.RoleId
                                      where ur.UserId == user.Id
                                      select new AuthClaims { Type = rc.ClaimType, Value = rc.ClaimValue }).ToListAsync();
                    var authClaims = string.Empty;
                    if (roleClaims.Count > 0)
                    {
                        authClaims = Newtonsoft.Json.JsonConvert.SerializeObject(roleClaims);
                        authClaims = PIPTWebMethods.EncryptString(authClaims);
                    }
                    try
                    {
                        var token = authenticateService.GenerateToken(user);
                        return new LoginResult
                        {
                            UserId = user.Id,
                            UserName = user.UserName,
                            FullName = user.FirstName + " " + user.LastName,
                            Role = lstRole,
                            Token = token,
                            RoleClaims = authClaims,
                            Message = "User đúng, bạn đã tạo token thành công!",
                            Success = true,
                            ErrorCode = 0,
                            Menus = lstMenu,
                            Avatar = user.Avatar
                        };
                    }
                    catch (Exception)
                    {
                        return new LoginResult
                        {
                            Message = "Lỗi tạo token từ Server bạn hãy liên hệ quản trị!",
                            Success = false,
                            ErrorCode = 2
                        };
                    }
                }
                else
                {
                    return new LoginResult
                    {
                        Message = "Tài khoản không tồn tại, bạn hãy kiểm tra lại hoặc liên hệ Quản trị mạng.",
                        Success = false,
                        ErrorCode = 1
                    };
                }
            }
            catch (Exception ex)
            {
                return new LoginResult
                {
                    Message = "Lỗi lấy thông tin người dùng từ Server, bạn hãy liên hệ Quản trị mạng. " + ex.Message,
                    Success = false,
                    ErrorCode = 3
                };
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<SecUsers> Register([FromBody] RegisterRequest registerRequest)
        {
            SecUsers user = await userManagmentService.Register(registerRequest);
            return user;
        }
        [HttpPost]
        [Route("changepassword")]
        public async Task<bool> ChangePassword([FromBody] ChangePwdModel changePwdModel)
        {
            var user = await userManagmentService.IsValidUsers(changePwdModel.UserName, changePwdModel.OldPassword);
            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, changePwdModel.OldPassword, changePwdModel.NewPassword);
                return result.Succeeded;
            }
            return false;
        }
        [HttpPost]
        [Route("uploadavatar")]
        public async Task<ResultApiModel<UploadFileModel>> UploadAvatar([FromBody] UploadFileModel avatar)
        {
            try
            {
                var buf = Convert.FromBase64String(avatar.base64data);
                DirectoryInfo ParentDir = Directory.GetParent(_env.ContentRootPath);
                string ParentPath = ParentDir.FullName;
                string DesPath = ParentPath + "/Client/wwwroot/dist/img/avatar/";
                string ImgType = avatar.fileName.Substring(avatar.fileName.LastIndexOf('.'));
                string AvatarPath = DesPath + avatar.UserName + ImgType;
                await System.IO.File.WriteAllBytesAsync(AvatarPath, buf);
                var user = _dbContext.Users.SingleOrDefault(x => x.UserName == avatar.UserName);
                if (user != null)
                {
                    string avatarDbPath = "dist/img/avatar/" + avatar.UserName + ImgType;
                    user.Avatar = avatarDbPath;
                    _dbContext.SaveChanges();
                }
                var resultApiModel = new ResultApiModel<UploadFileModel>();
                resultApiModel.Status = "Success";
                resultApiModel.Code = "200";
                resultApiModel.Message = _env.WebRootPath + "avatars\\" + Guid.NewGuid().ToString("N") + "-" + avatar.fileName;
                resultApiModel.Data = null;
                resultApiModel.Pagination = null;
                resultApiModel.Records = 0;
                return resultApiModel;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("IsValidUser")]
        public async Task<bool> IsValidUser([FromBody] LoginRequest login)
        {
            var user = await userManagmentService.IsValidUsers(login.UserName, login.Password);
            return (user != null);
        }
    }
}
