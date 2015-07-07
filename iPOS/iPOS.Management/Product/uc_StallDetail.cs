using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.BUS.Product;
using iPOS.BUS.System;
using iPOS.DTO.System;
using iPOS.Management.Common;
using iPOS.DTO.Product;
using iPOS.Core.Helper;
using Commons = iPOS.Management.Common.Common;

namespace iPOS.Management.Product
{
    public partial class uc_StallDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        PRO_tblWarehouseBUS busWarehouse;
        PRO_tblStallBUS busStall;
        SYS_tblPermissionBUS busPermission;
        SYS_tblPermissionDTO permission;
        uc_Stall parentForm;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            string LanguageID = User.UserInfo.LanguageID;
            logDetail.Text = LanguageID.Equals("VN") ? "Thông Tin Quầy Bán" : "Stall Information";
            lciStallCode.Text = LanguageID.Equals("VN") ? "Mã quầy:" : "Stall code:";
            lciVNName.Text = LanguageID.Equals("VN") ? "Tên quầy VN:" : "VN Stall name:";
            lciENName.Text = LanguageID.Equals("VN") ? "Tên quầy EN:" : "EN Stall name:";
            lciWarehouse.Text = LanguageID.Equals("VN") ? "Kho hàng:" : "Warehouse:";
            gluWarehouse.Properties.NullText = LanguageID.Equals("VN") ? "[Chọn kho hàng]" : "[Choose warehouse]";
            lciRank.Text = LanguageID.Equals("VN") ? "Thứ tự:" : "Rank:";
            chkUsed.Text = LanguageID.Equals("VN") ? "Đang hoạt động?" : "Are active?";
            lciNote.Text = LanguageID.Equals("VN") ? "Ghi chú:" : "Note:";
            btnSaveClose.Text = (LanguageID.Equals("VN")) ? "Lưu && Đóng" : "Save && Close";
            btnSaveInsert.Text = (LanguageID.Equals("VN")) ? "Lưu && Thêm" : "Save && Insert";
            btnCancel.Text = (LanguageID.Equals("VN")) ? "Hủy Bỏ" : "Cancel";

            busStall = new PRO_tblStallBUS();
            busWarehouse = new PRO_tblWarehouseBUS();
            busPermission = new SYS_tblPermissionBUS();
            busWarehouse = new PRO_tblWarehouseBUS();
            LoadWarehouse();
        }

        private void SetPermission()
        {
            permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "19", User.UserInfo.Username);
            if (txtStallID.Text.Equals(""))
            {
                btnSaveClose.Enabled = permission.AllowInsert;
                btnSaveInsert.Enabled = permission.AllowInsert;
            }
            else
            {
                btnSaveClose.Enabled = permission.AllowUpdate;
                btnSaveInsert.Enabled = permission.AllowInsert && permission.AllowUpdate;
            }
        }

        private void LoadDataToEdit(PRO_tblStallDTO item)
        {
            txtStallID.EditValue = item == null ? null : item.StallID;
            txtStallCode.EditValue = item == null ? null : item.StallCode;
            txtVNName.EditValue = item == null ? null : item.VNName;
            txtENName.EditValue = item == null ? null : item.ENName;
            gluWarehouse.EditValue = item == null ? null : item.WarehouseID;
            speRank.EditValue = item == null ? null : item.Rank;
            chkUsed.Checked = item == null ? true : item.Used;
            mmoNote.EditValue = item == null ? null : item.Note;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = (User.UserInfo.LanguageID.Equals("VN")) ? "Thêm Mới Quầy Bán" : "Insert New Stall";
            }
            txtStallCode.Focus();
        }

        private void LoadWarehouse()
        {
            DataTable dt = busWarehouse.GetDataCombobox(User.UserInfo.Username, User.UserInfo.LanguageID);
            if (dt != null && dt.Rows.Count > 0)
            {
                gluWarehouse.DataBindings.Clear();
                gluWarehouse.Properties.DataSource = dt;
                gluWarehouse.Properties.ValueMember = "WarehouseID";
                gluWarehouse.Properties.DisplayMember = "FullWarehouseName";
            }
        }

        private bool CheckValidate()
        {
            if (txtStallCode.Text.Equals(""))
            {
                depError.SetError(txtStallCode, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
                txtStallCode.Focus();
                return false;
            }
            if (txtStallCode.Text.Contains(" "))
            {
                depError.SetError(txtStallCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
                txtStallCode.Focus();
                return false;
            }
            if (txtVNName.Text.Equals(""))
            {
                depError.SetError(txtVNName, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
                txtVNName.Focus();
                return false;
            }
            if (txtENName.Text.Equals(""))
            {
                depError.SetError(txtENName, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
                txtENName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(gluWarehouse.EditValue + ""))
            {
                depError.SetError(gluWarehouse, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
                gluWarehouse.Focus();
                gluWarehouse.ShowPopup();
                return false;
            }

            return true;
        }

        private bool SaveStall(bool isEdit)
        {
            string strError = "";
            try
            {
                PRO_tblStallDTO item = new PRO_tblStallDTO
                {
                    Activity = (isEdit) ? "Update" : "Insert",
                    Username = User.UserInfo.Username,
                    LanguageID = User.UserInfo.LanguageID,
                    StallID = txtStallID.Text,
                    StallCode = txtStallCode.Text,
                    VNName = txtVNName.Text,
                    ENName = txtENName.Text,
                    WarehouseID = gluWarehouse.EditValue + "",
                    Rank = speRank.EditValue,
                    Used = chkUsed.Checked,
                    Note = mmoNote.Text
                };
                strError = (isEdit) ? busStall.UpdateStall(item) : busStall.InsertStall(item);
                if (strError != "")
                {
                    Commons.ShowMessage(strError, 0);
                    txtStallCode.Focus();
                    return false;
                }
                else parentForm.LoadAllData();
            }
            catch (Exception ex)
            {
                Commons.ShowExceptionMessage(ex);
                return false;
            }

            return true;
        }
        #endregion

        #region [Form Events]
        public uc_StallDetail(uc_Stall parent)
        {
            InitializeComponent();
            parentForm = parent;
            Initialize();
            SetPermission();
        }

        public uc_StallDetail(uc_Stall parent, PRO_tblStallDTO item)
        {
            InitializeComponent();
            parentForm = parent;
            Initialize();
            LoadDataToEdit(item);
            SetPermission();
        }

        private void txtStallCode_EditValueChanged(object sender, EventArgs e)
        {
            if (txtStallCode.Text.Contains(" "))
                depError.SetError(txtStallCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
            else depError.SetError(txtStallCode, (string.IsNullOrEmpty(txtStallCode.Text)) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void txtVNName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtVNName, (txtVNName.Text.Trim().Equals("")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void txtENName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtENName, (txtENName.Text.Trim().Equals("")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void gluWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(gluWarehouse, (string.IsNullOrEmpty(gluWarehouse.EditValue + "")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (SaveStall(txtStallID.Text.Equals("") ? false : true))
                    this.ParentForm.Close();
        }

        private void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (SaveStall(txtStallID.Text.Equals("") ? false : true))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
