using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using PIPTWeb.Shared.Models;

namespace PIPTWeb.Client.Services
{
    public class DataStorageService
    {
        private List<SysMenu> _lstMenus;
        private List<IdentityRole> _lstRole;
        private string _UserName;
        public List<SysMenu> lstMenus
        {
            get
            {
                return _lstMenus;
            }
            set
            {
                _lstMenus = value;
                NotifyDataChange();
            }
        }

        public List<IdentityRole> lstRole
        {
            get
            {
                return _lstRole;
            }
            set
            {
                _lstRole = value;
                NotifyDataChange();
            }
        }

        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
                NotifyDataChange();
            }
        }
        public string tmp { get; set; } = "Test";

        public event Action Onchange;

        private void NotifyDataChange() => Onchange?.Invoke();
    }
}
