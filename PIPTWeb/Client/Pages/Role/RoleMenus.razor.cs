using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared;
using PIPTWeb.Shared.ViewModels;
using Radzen;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.Role
{
    public partial class RoleMenus
    {
        [Parameter]
        public string roleId { get; set; }
        string roleName = string.Empty;
        [Inject]
        public IRoleMenuService RoleMenuService { get; set; }
        [Inject]
        public IRoleService RoleService { get; set; }
        [Inject] NotificationService NotificationService { get; set; }
        public TreeMenusViewModel CurrentMenu { get; set; }
        public List<TreeMenusViewModel> Menus { get; set; } = new List<TreeMenusViewModel>();
        public List<TreeMenusViewModel> SelectedMenus { get; set; } = new List<TreeMenusViewModel>();
        public List<RoleClaimsViewModel> RoleClaims { get; set; } = new List<RoleClaimsViewModel>();
        public List<RoleClaimsViewModel> RoleMenuClaims { get; set; } = new List<RoleClaimsViewModel>();
        [CascadingParameter]
        public Task<AuthenticationState> Authentication { get; set; }
        [Inject]
        public IAuthorizationService AuthorizationService { get; set; }
        [Inject]
        public NavigationManager navigation { get; set; }
        protected override async void OnInitialized()
        {
            roleName = (await RoleService.GetRoleById(roleId))?.Name;
            var authState = await Authentication;
            if (authState.User.Identity.IsAuthenticated)
            {
                //if (!AuthorizationService.AuthorizeAsync(authState.User, Permissions.RoleMenus.View).Result.Succeeded)
                //{
                //    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Quyền truy cập trang", Detail = $"Bạn không có quyền truy cập trang này!", Duration = 4000 });
                //    navigation.NavigateTo("/");
                //}
            }
            CurrentMenu = new TreeMenusViewModel();
        }
        protected override async Task OnParametersSetAsync()
        {
            if (roleId != null)
            {
                Menus = await RoleMenuService.GetTreeMenuByRole(roleId);
                GetSelectedMenus(Menus); // Dùng để lấy các đối tượng trên menu cho việc tự động checked
                RoleClaims = await RoleMenuService.GetClaimByRole(roleId);
            }
        }

        private void SelectedMenu(TreeMenusViewModel contextItem)
        {
            if (roleId != null)
            {
                CurrentMenu = (CurrentMenu != contextItem) ? contextItem : null;
                if (CurrentMenu != null)
                {
                    if (CurrentMenu.ParentID != 0)
                    {
                        var menuLink = Permissions.ClassNameByLink(CurrentMenu.Link);
                        RoleMenuClaims = Permissions.GetCurrentMenuPermissions(menuLink, RoleClaims);
                    }
                    if(!SelectedMenus.Any(m => m.ID == contextItem.ID))
                    {
                        SelectedMenus.Add(contextItem);
                    }
                }
                else
                {
                    RoleMenuClaims = new List<RoleClaimsViewModel>();
                    if (SelectedMenus.Any(m => m.ID == contextItem.ID))
                    {
                        SelectedMenus.Remove(contextItem);
                    }
                }
            }
        }

        private void PermissionsChecked(string value, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                foreach (var permission in RoleMenuClaims.Where(p => p.Value == value))
                {
                    permission.Selected = true;
                    if(!RoleClaims.Any(c => c.Value == value))
                    {
                        RoleClaims.Add(permission);
                    }
                }
            }
            else
            {
                foreach (var permission in RoleMenuClaims.Where(p => p.Value == value))
                {
                    permission.Selected = false;
                    var claim = RoleClaims.Where(c => c.Value == value).FirstOrDefault();
                    if(claim != null)
                    {
                        RoleClaims.Remove(claim);
                    }
                }
            }
        }

        private async void UpdatePermission(string roleId)
        {
            // Xoá tất cả các nhóm Nenu Role
            await RoleMenuService.DeleteRoleMenus(roleId);
            // Thêm mới tất cả các nhóm Menu và Role
            ManagerRoleMenusViewModel roleMenus = new ManagerRoleMenusViewModel();
            roleMenus.RoleId = roleId;
            roleMenus.RoleMenus = new List<RoleMenusViewModel>();
            foreach (var menu in SelectedMenus)
            {
                roleMenus.RoleMenus.Add(new RoleMenusViewModel { ID = menu.ID, Value = menu.Value, Link = menu.Link, ParentID = menu.ParentID, Icon = menu.Icon, SortOrder = menu.SortOrder, Active = menu.Active, Selected = menu.Selected });
            }
            var result = await RoleMenuService.AddRoleMenus(roleMenus);
            // Xoá tất cả các Claims theo RoleId
            await RoleMenuService.DeleteRoleClaims(roleId);
            // Thêm tất cả các Claims mới theo RoleId
            PermissionViewModel roleClaims = new PermissionViewModel();
            roleClaims.RoleId = roleId;
            roleClaims.RoleClaims = RoleClaims;
            result = await RoleMenuService.AddRoleClaims(roleClaims);
            if(result)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Cập nhật hệ thống quyền", Detail = $"Bạn đã cập nhật dữ liệu phân quyền cho hệ thống thành công", Duration = 4000 });
            }
            else
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Cập nhật hệ thống quyền", Detail = $"Bạn đã cập nhật dữ liệu phân quyền cho hệ thống thất bại", Duration = 4000 });
            }
        }
        private void GetSelectedMenus(List<TreeMenusViewModel> menus)
        {
            SelectedMenus = new List<TreeMenusViewModel>();
            foreach (var menu in menus)
            {
                if (menu.Selected)
                {
                    SelectedMenus.Add(menu);
                    if (menu.ChildrenMenus.Count > 0)
                    {
                        GetChildrenItem(menu.ChildrenMenus);
                    }
                }
                else
                {
                    if (menu.ChildrenMenus.Count > 0)
                    {
                        GetChildrenItem(menu.ChildrenMenus);
                    }
                }
            }
        }

        private void GetChildrenItem(List<TreeMenusViewModel> childrenMenus)
        {
            foreach (var child in childrenMenus)
            {
                if (child.Selected)
                {
                    SelectedMenus.Add(child);
                    if (child.ChildrenMenus.Count > 0)
                    {
                        GetChildrenItem(child.ChildrenMenus);
                    }
                }
                else
                {
                    if (child.ChildrenMenus.Count > 0)
                    {
                        GetChildrenItem(child.ChildrenMenus);
                    }
                }
            }
        }

        private void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }
    }
}
