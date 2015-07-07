using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.BUS.Product;
using iPOS.DTO.System;
using iPOS.BUS.System;
using iPOS.Management.Common;
using iPOS.Core.Helper;
using Commons = iPOS.Management.Common.Common;
using iPOS.DTO.Product;

namespace iPOS.Management.Product
{
    public partial class uc_ProvinceDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        PRO_tblProvinceBUS busProvince;
        uc_Province parentForm;
        SYS_tblPermissionDTO permission;
        SYS_tblPermissionBUS busPermission;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            string LanguageID = User.UserInfo.LanguageID;
            logDetail.Text = (LanguageID.Equals("VN")) ? "Thông Tin Tỉnh Thành" : "Province Information";
            lciProvinceCode.Text = (LanguageID.Equals("VN")) ? "Mã tỉnh thành:" : "Province code:";
            lciVNName.Text = (LanguageID.Equals("VN")) ? "Tên tỉnh thành VN:" : "VN name:";
            lciENName.Text = (LanguageID.Equals("VN")) ? "Tên tỉnh thành EN:" : "EN name:";
            lciNote.Text = (LanguageID.Equals("VN")) ? "Ghi chú:" : "Note:";
            lciRank.Text = (LanguageID.Equals("VN")) ? "Thứ tự:" : "Rank:";
            chkUsed.Text = (LanguageID.Equals("VN")) ? "Đang sử dụng?" : "Is using?";
            btnSaveClose.Text = (LanguageID.Equals("VN")) ? "Lưu && Đóng" : "Save && Close";
            btnSaveInsert.Text = (LanguageID.Equals("VN")) ? "Lưu && Thêm" : "Save && Insert";
            btnCancel.Text = (LanguageID.Equals("VN")) ? "Hủy Bỏ" : "Cancel";

            busProvince = new PRO_tblProvinceBUS();
            busPermission = new SYS_tblPermissionBUS();
        }

        private void SetPermission()
        {
            permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "8", User.UserInfo.Username);
            if (txtProvinceID.Text.Equals(""))
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

        private bool CheckValidate()
        {
            if (txtProvinceCode.Text.Equals(""))
            {
                depError.SetError(txtProvinceCode, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
                txtProvinceCode.Focus();
                return false;
            }
            if (txtProvinceCode.Text.Contains(" "))
            {
                depError.SetError(txtProvinceCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
                txtProvinceCode.Focus();
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

            return true;
        }

        private bool SaveProvince(bool isEdit)
        {
            string strError = "";
            try
            {
                PRO_tblProvinceDTO item = new PRO_tblProvinceDTO
                {
                    Activity = (isEdit) ? "Update" : "Insert",
                    Username = User.UserInfo.Username,
                    LanguageID = User.UserInfo.LanguageID,
                    ProvinceID = txtProvinceID.Text,
                    ProvinceCode = txtProvinceCode.Text,
                    VNName = txtVNName.Text,
                    ENName = txtENName.Text,
                    Rank = speRank.EditValue,
                    Note = mmoNote.Text,
                    Used = chkUsed.Checked
                };
                strError = (isEdit) ? busProvince.UpdateProvince(item) : busProvince.InsertProvince(item);
                if (strError != "")
                {
                    Commons.ShowMessage(strError, 0);
                    txtProvinceCode.Focus();
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

        private void LoadDataToEdit(PRO_tblProvinceDTO item)
        {
            txtProvinceID.EditValue = (item == null) ? null : item.ProvinceID;
            txtProvinceCode.EditValue = (item == null) ? null : item.ProvinceCode;
            txtVNName.EditValue = (item == null) ? null : item.VNName;
            txtENName.EditValue = (item == null) ? null : item.ENName;
            speRank.EditValue = (item == null) ? 0 : item.Rank;
            chkUsed.EditValue = (item == null) ? true : item.Used;
            mmoNote.EditValue = (item == null) ? null : item.Note;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = (User.UserInfo.LanguageID.Equals("VN")) ? "Thêm Mới Tỉnh Thành" : "Insert New Province";
            }
            txtProvinceCode.Focus();
        }
        #endregion

        #region [Form Events]
        public uc_ProvinceDetail(uc_Province parent)
        {
            InitializeComponent();
            parentForm = parent;
            Initialize();
            SetPermission();
        }

        public uc_ProvinceDetail(uc_Province parent, PRO_tblProvinceDTO item)
        {
            InitializeComponent();
            parentForm = parent;
            Initialize();
            LoadDataToEdit(item);
            SetPermission();
        }

        private void txtProvinceCode_EditValueChanged(object sender, EventArgs e)
        {
            if (txtProvinceCode.Text.Contains(" "))
                depError.SetError(txtProvinceCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
            else depError.SetError(txtProvinceCode, (string.IsNullOrEmpty(txtProvinceCode.Text)) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void txtVNName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtVNName, (txtVNName.Text.Trim().Equals("")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void txtENName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtENName, (txtENName.Text.Trim().Equals("")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (SaveProvince((txtProvinceID.Text.Equals("")) ? false : true))
                    this.ParentForm.Close();
        }

        private void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (SaveProvince((txtProvinceID.Text.Equals("")) ? false : true))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
