using PIPTWeb.Shared.Models;
using System.Collections.Generic;

namespace PIPTWeb.Shared.ViewModels
{
    public class ManagerRoleMenusViewModel
    {
        public string RoleId { get; set; }
        public List<RoleMenusViewModel> RoleMenus { get; set; }
    }
    public class RoleMenusViewModel : SysMenu
    {
        public bool Selected { get; set; }
    }
    public class TreeMenusViewModel : RoleMenusViewModel
    {
        public List<TreeMenusViewModel> ChildrenMenus { get; set; }
    }
}
