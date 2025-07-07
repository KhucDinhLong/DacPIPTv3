using DAC.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PIPT.Agency
{
    public partial class frmAuthorization : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmAuthorization _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmAuthorization Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmAuthorization();
            }
            return _instance;
        }

        public static frmAuthorization Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmAuthorization Instance(Form parent, bool isActivate)
        {
            _instance = Instance(parent);
            if (isActivate)
            {
                _instance.WindowState = FormWindowState.Normal;
                _instance.Show();
                _instance.Activate();
            }
            return _instance;
        }
        #endregion
        #region Variables
        private const string sSpace = "      ";//6
        private bool bIsAutoCheck = false;
        private bool bIsClickCheckAll = false;
        private int nCheckedItemsCount = 0;

        TreeNode tnGroupSelectedNode = null;

        private bool isProgrammingCheckedListView = true;
        private bool isProgrammingSelectedTreeNode = true;
        #endregion
        public frmAuthorization()
        {
            InitializeComponent();
        }

        private void frmAuthorization_Load(object sender, EventArgs e)
        {
            DisplayGroups();
            DisplayMenus();
            //Set Authorization
            ucDataButtonAuthorization.EditVisible = true;
        }
        #region TreeView Groups
        /// <summary>
        /// DisplayGroups
        /// </summary>
        private void DisplayGroups()
        {
            isProgrammingSelectedTreeNode = true;
            treeViewGroupUser.Nodes.Clear();
            treeViewGroupUser.ImageIndex = 0;
            treeViewGroupUser.SelectedImageIndex = 1;
            GroupCollection groupCollection = new GroupBS().GetListOfGroup();
            foreach (Group objGroup in groupCollection)
            {
                TreeNode tnGroup = new TreeNode(objGroup.GroupName);
                tnGroup.Tag = objGroup.GroupID;
                treeViewGroupUser.Nodes.Add(tnGroup);
            }
            isProgrammingSelectedTreeNode = false;
        }
        private void treeViewGroupUser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DisplayGrantedAuthorization();
        }
        private void DisplayGrantedAuthorization()
        {
            isProgrammingCheckedListView = true;
            nCheckedItemsCount = 0;

            if (isProgrammingSelectedTreeNode) return;
 
            MenuGroupCollection menuGroupCollection = new MenuGroupCollection();
            MenuGroupBS menuGroupBS = new MenuGroupBS();
            GroupBS groupBS = new GroupBS();
            if (treeViewGroupUser.SelectedNode != null)
            {
                object sGroupID = treeViewGroupUser.SelectedNode.Tag;
                tnGroupSelectedNode = treeViewGroupUser.SelectedNode;
                if (groupBS.GetGroupByID(sGroupID.ToString()).IsAdmin)
                {
                    checkBoxSelectAll.Checked = true;
                }
                else
                {
                    checkBoxSelectAll.Checked = false;
                    List<Guid> lstGroupID = new List<Guid>();
                    lstGroupID.Add((Guid)sGroupID);
                    menuGroupCollection = menuGroupBS.GetMenuGroupCollectionByGroupID(lstGroupID);
                    for(int i = 0; i < listViewAuthorization.Items.Count; i++)
                    {
                        listViewAuthorization.Items[i].Checked = CheckedAuthorization(listViewAuthorization.Items[i].Tag.ToString(), menuGroupCollection);
                    }
                }
                isProgrammingCheckedListView = false;
            }
        }
        private bool CheckedAuthorization(string menuID, MenuGroupCollection menuGroupCollection)
        {
            foreach(MenuGroup menuGroup in menuGroupCollection)
            {
                if(menuID == menuGroup.MenuID)
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckedAuthorization(string menuID, List<MenuGroup> lstmenuGroupCollection)
        {
            foreach (MenuGroup menuGroup in lstmenuGroupCollection)
            {
                if (menuID == menuGroup.MenuID)
                {
                    return true;
                }
            }
            return false;
        }
        private void DisplayMenus()
        {
            if (treeViewGroupUser == null) return;

            listViewAuthorization.Items.Clear();

            MenuBS menuBS = new MenuBS();
            MenuCollection authCollection = menuBS.GetMenuCollection();
            foreach (DAC.Core.Security.Menu menu in authCollection)
            {
                ListViewItem item = new ListViewItem();
                item.Text = menu.MenuValue;
                item.Tag = menu.MenuID;

                listViewAuthorization.Items.Add(item);
            }
        }
        #endregion

        #region ListView Group
        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (bIsAutoCheck) return;

            bIsClickCheckAll = true;
            if (checkBoxSelectAll.Checked)
                nCheckedItemsCount = listViewAuthorization.Items.Count;
            else
                nCheckedItemsCount = 0;

            for (int i = 0; i < listViewAuthorization.Items.Count; i++)
            {
                listViewAuthorization.Items[i].Checked = checkBoxSelectAll.Checked;
            }

            bIsClickCheckAll = false;
        }
        private void listViewAuthorization_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (isProgrammingCheckedListView) return;

            if (e.Item.Checked)
            {
                if (bIsClickCheckAll == false)
                    nCheckedItemsCount++;
            }
            else
            {
                if (bIsClickCheckAll == false)
                    nCheckedItemsCount--;
            }

            if (bIsClickCheckAll == false)
            {
                bIsAutoCheck = true;
                if (nCheckedItemsCount < listViewAuthorization.Items.Count)
                    checkBoxSelectAll.Checked = false;
                else
                    checkBoxSelectAll.Checked = true;
                bIsAutoCheck = false;
            }
        }
        #endregion

        #region Button's Events
        private void ucDataButtonAuthorization_EditHandler()
        {
            listViewAuthorization.Enabled = true;
        }

        private void ucDataButtonAuthorization_SaveHandler()
        {
            UpdateAuthorization();
            listViewAuthorization.Enabled = false;
        }
        private bool UpdateAuthorization()
        {
            List<MenuGroup> lstTempMenuGroup = new List<MenuGroup>();
            List<MenuGroup> lstAddedMenuGroup = new List<MenuGroup>();
            List<MenuGroup> lstDeletedMenuGroup = new List<MenuGroup>();
            // Lay danh sach cac menu luu trong database
            List<MenuGroup> lstSavedMenuGroup = new List<MenuGroup>();
            MenuGroupBS menuGroupBS = new MenuGroupBS();
            List<Guid> lstGroupID = new List<Guid>();
            lstGroupID.Add((Guid)tnGroupSelectedNode.Tag);
            MenuGroupCollection menuGroupCollection = menuGroupBS.GetMenuGroupCollectionByGroupID(lstGroupID);
            // Duyet tren listView nhung menu duoc checked
            for(int i = 0; i < listViewAuthorization.Items.Count; i++)
            {
                if(listViewAuthorization.Items[i].Checked)
                {
                    MenuGroup menuGroup = new MenuGroup();
                    menuGroup.GroupID = (Guid)tnGroupSelectedNode.Tag;
                    menuGroup.MenuID = listViewAuthorization.Items[i].Tag.ToString();
                    lstTempMenuGroup.Add(menuGroup);
                }
            }
            // Lay danh sach cac menu bi xoa
            foreach (MenuGroup menuGroup in menuGroupCollection)
            {
                if (CheckedAuthorization(menuGroup.MenuID, lstTempMenuGroup))
                {
                    // Neu mot item trong database da ton tai trong listAdded thi loai khoi danh
                    var tempMenuGroup = lstTempMenuGroup.SingleOrDefault(menu => menu.MenuID == menuGroup.MenuID);
                    lstTempMenuGroup.Remove(tempMenuGroup);
                }
                else
                {
                    // Neu mot item trong database khong ton tai trong listAdded thi se xoa di
                    lstDeletedMenuGroup.Add(menuGroup);
                }
            }
            lstAddedMenuGroup = lstTempMenuGroup;
            // Luu lai vao co do du lieu
            DAC.DAL.DacDbAccess dacDb = new DAC.DAL.DacDbAccess();
            return menuGroupBS.UpdateMenuGroup(dacDb, lstAddedMenuGroup, lstDeletedMenuGroup);
        }
        private void ucDataButtonAuthorization_CancelHandler()
        {
            listViewAuthorization.Enabled = false;
        }
        #endregion
    }
}