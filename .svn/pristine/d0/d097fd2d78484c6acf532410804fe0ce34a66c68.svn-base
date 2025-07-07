using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DAC.Core.Security;

namespace PIPT.Agency
{
    public partial class frmMain : Form
    {
        #region Variables
        Common common = new Common();
        private MenuGroupCollection menuGroupCollection = null;
        private MenuBS menuBS;
        private List<DAC.Core.Security.Menu> lstMenu;
        #endregion

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //If IsAdmin then show all menu
            if (!CommonBS.IsAdminUser)
            {
                ShowMenuFromDB();
            }
            // Cap nhat du lieu tu may chu
            common.CurrentForm = this;
            common.CurrentFormMethodInvoker = common.GetUpdateDataFromServer;
            common.App_ShowWaitForm(DataState.Edit);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !DAC.Core.CommonCore.FormClosing(Common.sExitProgram);
        }

        #region Functions
        // Test method waiting
        private void UpdateMenu()
        {
            try
            {
                lstMenu = new List<DAC.Core.Security.Menu>();
                menuBS = new MenuBS();

                DAC.Core.Security.Menu objMenu;
                // Delete all data in table menu
                //menu.Delete();

                foreach (ToolStripMenuItem item in menuMain.Items)
                {
                    objMenu = new DAC.Core.Security.Menu();
                    objMenu.MenuID = item.Name;
                    if (item.Tag != null)
                        objMenu.FormName = item.Tag.ToString();

                    objMenu.MenuValue = item.Text;

                    // Add object menu into List
                    lstMenu.Add(objMenu);

                    // Insert sub menu
                    IterateMenus(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Update data in DB
            bool bResult = menuBS.UpdateMenu(lstMenu);

            if (bResult)
            {
                CommonBS.SaveSuccessfully();
            }
            else
            {
                CommonBS.SaveNotSuccessfully();
            }
        }
        /// <summary>
        /// IterateMenus
        /// </summary>
        /// <param name="item"></param>
        private void IterateMenus(ToolStripMenuItem item)
        {
            DAC.Core.Security.Menu objMenu;
            foreach (ToolStripMenuItem subMenu in item.DropDownItems)
            {
                objMenu = new DAC.Core.Security.Menu();
                objMenu.MenuID = subMenu.Name;
                objMenu.MenuValue = subMenu.Text;
                objMenu.MenuFiliationID = item.Name;
                objMenu.FormName = (subMenu.Tag == null ? String.Empty : subMenu.Tag.ToString());

                // Add object menu into List
                lstMenu.Add(objMenu);

                IterateMenus(subMenu);
            }
        }

        /// <summary>
        /// Is Authorized
        /// </summary>
        /// <param name="sMenuID"></param>
        /// <returns></returns>
        private bool IsAuthorized(string sMenuID)
        {
            foreach (MenuGroup objMenuGroup in menuGroupCollection)
            {
                if (objMenuGroup.MenuID == sMenuID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Show menu from DB
        /// </summary>
        private void ShowMenuFromDB()
        {
            menuMain.Items.Clear();

            List<Guid> lstGroupID = new GroupUserBS().GetListGroupIdByUserID(CommonBS.CurrentUser.LoginID.ToLower());
            menuGroupCollection = new MenuGroupBS().GetMenuGroupCollectionByGroupID(lstGroupID);

            MenuCollection menuCollection = new MenuBS().GetMenuCollection();
            foreach (DAC.Core.Security.Menu objMenu in menuCollection)
            {
                if (objMenu.MenuFiliationID == String.Empty)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();

                    menuItem.Name = objMenu.MenuID;
                    menuItem.Text = objMenu.MenuValue;

                    // Add menu item
                    menuMain.Items.Add(menuItem);

                    // Add sub menuItem of this menuItem
                    ShowSubMenu(menuCollection, menuItem.Name, menuItem);
                }
            }
        }

        /// <summary>
        /// Add sub menu
        /// </summary>
        /// <param name="menuCollection"></param>
        /// <param name="sParentMenuName">Parent menu name</param>
        /// <param name="menuItem">Menu item</param>
        private void ShowSubMenu(MenuCollection menuCollection, string sParentMenuName, ToolStripMenuItem menuItem)
        {
            foreach (DAC.Core.Security.Menu objSubMenu in menuCollection)
            {
                if (objSubMenu.MenuFiliationID == sParentMenuName)
                {
                    ToolStripMenuItem subItem = new ToolStripMenuItem();

                    subItem.Name = objSubMenu.MenuID;
                    subItem.Text = objSubMenu.MenuValue;

                    // Check user can use this menu?
                    if (CommonBS.IsAdminUser || subItem.Name.Equals("tsmiLogOff") || subItem.Name.Equals("tsmiClose") || subItem.Name.Equals("tsmiChangePassword") || IsAuthorized(subItem.Name))
                    {
                        //Set MenuItemChecked event
                        subItem.Click += new EventHandler(MenuItems_Click);

                        subItem.Visible = true;
                        subItem.Tag = objSubMenu.FormName;
                    }
                    else
                    {
                        subItem.Visible = false;
                    }

                    // Add menu item
                    menuItem.DropDownItems.Add(subItem);

                    // Call ShowSubMenu
                    ShowSubMenu(menuCollection, subItem.Name, subItem);
                }
            }
        }

        private void MenuItems_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Tag == null) return;
            string frmName = ((ToolStripMenuItem)sender).Tag.ToString();
            Form frm = null;
            switch (frmName)
            {
                #region System
                case "frmUser":
                    frm = frmUser.Instance(this, true);
                    break;
                case "frmChangePassword":
                    frm = frmChangePassword.Instance(this, true);
                    break;
                case "tsmiLogOff":
                    Application.Restart();
                    return;
                case "frmConfig":
                    frm = frmDacAgency.Instance(this, true);
                    break;
                case "frmAuthorization":
                    frm = frmAuthorization.Instance(this, true);
                    break;
                case "frmUpdateMenu":
                    // Only Admin Can Update menu
                    common.CurrentForm = this;
                    common.CurrentFormMethodInvoker = UpdateMenu;
                    common.App_ShowWaitForm(DataState.Edit);
                    return;
                case "frmDacBackupRestore":
                    frm = frmDacBackupRestore.Instance(this, true);
                    break;
                case "tsmiClose":
                    Application.Exit();
                    return;
                #endregion
                #region Catalogue
                case "frmDacStore":
                    frm = frmDacStore.Instance(this, true);
                    break;
                case "frmDacCatalogue":
                    frm = frmDacCatalogue.Instance(this, true);
                    break;
                case "frmDacProductUnit":
                    frm = frmDacProductUnit.Instance(this, true);
                    break;
                case "frmDacProduct":
                    frm = frmDacProduct.Instance(this, true);
                    break;
                #endregion
                #region Công cụ
                case "frmDacDistributeToStore":
                    frm = frmDacDistributeToStore.Instance(this, true); 
                    break;
                case "frmDacChecking":
                    frm = frmDacChecking.Instance(this, true);
                    break;
                case "frmDacGetSerial":
                    frm = frmDacGetSerial.Instance(this, true);
                    break;
                case "frmDacLogNotUpload":
                    frm = frmDacLogNotUpload.Instance(this, true);
                    break;
                case "frmDacDeleteCode":
                    frm = frmDacDeleteCode.Instance(this, true);
                    break;
                #endregion
                #region Báo cáo
                case "frmReportExportInfo":
                    frm = frmReportExportInfo.Instance(this, true);
                    break;
                    #endregion
            }
        }
        #endregion
    }
}
