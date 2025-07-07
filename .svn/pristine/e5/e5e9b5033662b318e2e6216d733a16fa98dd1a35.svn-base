using Microsoft.AspNetCore.Identity;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Services
{
    public interface IRoleMenuService
    {
        public SysMenu Menu { get; set; }
        public SecRoles Role { get; set; }
        public List<SysMenu> LstMenu { get; set; }
        public List<SecRoles> LstRole { get; set; }
        public SecRoleMenu roleMenu { get; set; }
        Task<bool> AddRoleMenu(SecRoleMenu roleMenu);
        Task<List<TreeMenusViewModel>> GetMenuByRole(string roleId);
        Task<List<TreeMenusViewModel>> GetTreeMenuByRole(string roleId);
        Task<List<RoleClaimsViewModel>> GetClaimByRole(string roleId);
        Task DeleteRoleMenus(string roleId);
        Task DeleteRoleClaims(string roleId);
        Task<bool> AddRoleMenus(ManagerRoleMenusViewModel roleMenus);
        Task<bool> AddRoleClaims(PermissionViewModel roleClaims);
    }
    public class RoleMenuService : IRoleMenuService
    {
        private readonly HttpClient _httpClient;
        public SysMenu Menu { get; set; }
        public SecRoles Role { get; set; }
        public List<SysMenu> LstMenu { get; set; }
        public List<SecRoles> LstRole { get; set; }
        public SecRoleMenu roleMenu { get; set; }

        public RoleMenuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddRoleMenu(SecRoleMenu roleMenu)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/RoleMenu/Create", roleMenu);
            var responseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<SecRoleMenu>>();
            if (responseContent.Code == "201")
                return true;
            return false;
        }
        public async Task<List<TreeMenusViewModel>> GetMenuByRole(string roleId)
        {
            var response = await _httpClient.GetAsync($"api/v1/RoleMenu/getmenu/?roleId={roleId}");
            var responseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<RoleMenusViewModel>>();
            if (responseContent.Code == "200")
            {
                List<TreeMenusViewModel> TreeMenusViews = responseContent.Data
                 .Where(m => m.Selected == true)
                 .Select(m => new TreeMenusViewModel
                 {
                     ID = m.ID,
                     Value = m.Value,
                     Link = m.Link,
                     Icon = m.Icon,
                     ParentID = m.ParentID,
                     SortOrder = m.SortOrder,
                     Active = m.Active,
                     Selected = m.Selected,
                     ChildrenMenus = null
                 })
                 .ToList();
                return TreeMenusViews;
            }
            return null;
        }
        public async Task<List<TreeMenusViewModel>> GetTreeMenuByRole(string roleId)
        {
            var response = await _httpClient.GetAsync($"api/v1/RoleMenu/getmenu/?roleId={roleId}");
            var responseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<RoleMenusViewModel>>();
            if (responseContent.Code == "200")
            {
                // Recursion đệ quy để quét hết menu cha và con
                List<TreeMenusViewModel> TreeMenusViews = responseContent.Data
                .Where(m => m.ParentID == 0)
                .Select(m => new TreeMenusViewModel
                {
                    ID = m.ID,
                    Value = m.Value,
                    Link = m.Link,
                    Icon = m.Icon,
                    ParentID = m.ParentID,
                    SortOrder = m.SortOrder,
                    Active = m.Active,
                    Selected = m.Selected,
                    ChildrenMenus = GetChildren(responseContent.Data, m.ID)
                })
                .ToList();
                return TreeMenusViews;
            }
            return null;
        }
        public async Task<List<RoleClaimsViewModel>> GetClaimByRole(string roleId)
        {
            var response = await _httpClient.GetAsync($"api/v1/RoleClaims/getClaims/?roleId={roleId}");
            var responseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<RoleClaimsViewModel>>();
            if (responseContent.Code == "200")
            {
                // Lấy tất cả các RoleClaims đã được gán quyền.
                List<RoleClaimsViewModel> RoleClaims = responseContent.Data
                .Select(m => new RoleClaimsViewModel
                {
                    Type = m.Type,
                    Value = m.Value,
                    Name = PIPTWeb.Shared.Permissions.GetPermissionName(m.Value),
                    Selected = m.Selected
                })
                .ToList();
                return RoleClaims;
            }
            return null;
        }
        public async Task DeleteRoleMenus(string roleId)
        {
            await _httpClient.DeleteAsync($"api/v1/RoleMenu/?roleId={roleId}");
        }

        public async Task DeleteRoleClaims(string roleId)
        {
            await _httpClient.DeleteAsync($"api/v1/RoleClaims/?roleId={roleId}");
        }

        private List<TreeMenusViewModel> GetChildren(IEnumerable<RoleMenusViewModel> childrenMenus, int parentId)
        {
            return childrenMenus
                .Where(m => m.ParentID == parentId)
                .Select(m => new TreeMenusViewModel
                {
                    ID = m.ID,
                    Value = m.Value,
                    Link = m.Link,
                    Icon = m.Icon,
                    ParentID = m.ParentID,
                    SortOrder = m.SortOrder,
                    Active = m.Active,
                    Selected = m.Selected,
                    ChildrenMenus = GetChildren(childrenMenus, m.ID)
                })
                .ToList();
        }

        public async Task<bool> AddRoleMenus(ManagerRoleMenusViewModel roleMenus)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/RoleMenu/addRoleMenus", roleMenus);
            var responseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<int>>();
            if (responseContent.Code == "200")
                return true;
            return false;
        }

        public async Task<bool> AddRoleClaims(PermissionViewModel roleClaims)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/RoleClaims/addClaims", roleClaims);
            var responseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<int>>();
            if (responseContent.Code == "200")
                return true;
            return false;
        }
    }
}
