using DAC.Core.ObjectFactory;
using DAC.Core.Security;
using DAC.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PIPT.Tools
{
    public partial class frmRefactor : Form
    {
        IPIPTOldVersionMetaDataService _metaDataService;
        IRestoreDataService restoreService;
        public frmRefactor(IPIPTOldVersionMetaDataService metaDataService)
        {
            InitializeComponent();
            _metaDataService = metaDataService;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = ProcessData;
            objCommon.App_ShowWaitForm(DataState.Insert);
            
        }

        private void ProcessData()
        {
            if (cbbDataTable.EditValue != null && !string.IsNullOrWhiteSpace(cbbDataTable.EditValue.ToString()))
            {
                restoreService = RestoreDataFactory.GetService(cbbDataTable.EditValue.ToString());
                bool result = restoreService.RestoreData(0);
                if (result)
                {
                    MessageBox.Show("Sao chép dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sao chép dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmRefactor_Load(object sender, EventArgs e)
        {
            List<string> LstTableName = _metaDataService.GetTableName();
            if (LstTableName != null && LstTableName.Any())
            {
                foreach (var item in LstTableName)
                {
                    cbbDataTable.Properties.Items.Add(item);
                }
            }
        }
    }
}
