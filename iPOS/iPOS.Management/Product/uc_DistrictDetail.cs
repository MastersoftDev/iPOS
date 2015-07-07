using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.BUS.Product;
using iPOS.Management.Common;
using Commons = iPOS.Management.Common.Common;
using iPOS.BUS.System;
using iPOS.DTO.System;
using iPOS.Core.Helper;
using iPOS.DTO.Product;

namespace iPOS.Management.Product
{
    public partial class uc_DistrictDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        PRO_tblProvinceBUS busProvince;
        PRO_tblDistrictBUS busDistrict;
        SYS_tblPermissionBUS busPermission;
        SYS_tblPermissionDTO permission;
        uc_District parentForm;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            string LanguageID = User.UserInfo.LanguageID;
            logDetail.Text = (LanguageID.Equals("VN")) ? "Thông Tin Quận Huyện" : "District Information";
            lciDistrictCode.Text = (LanguageID.Equals("VN")) ? "Mã quận huyện:" : "District code:";
            lciVNName.Text = (LanguageID.Equals("VN")) ? "Tên quận huyện VN:" : "VN name:";
            lciENName.Text = (LanguageID.Equals("VN")) ? "Tên quận huyện EN:" : "EN name:";
            lciNote.Text = (LanguageID.Equals("VN")) ? "Ghi chú:" : "Note:";
            lciRank.Text = (LanguageID.Equals("VN")) ? "Thứ tự:" : "Rank:";
            chkUsed.Text = (LanguageID.Equals("VN")) ? "Đang sử dụng?" : "Is using?";
            btnSaveClose.Text = (LanguageID.Equals("VN")) ? "Lưu && Đóng" : "Save && Close";
            btnSaveInsert.Text = (LanguageID.Equals("VN")) ? "Lưu && Thêm" : "Save && Insert";
            btnCancel.Text = (LanguageID.Equals("VN")) ? "Hủy Bỏ" : "Cancel";

            busProvince = new PRO_tblProvinceBUS();
            busPermission = new SYS_tblPermissionBUS();
            busDistrict = new PRO_tblDistrictBUS();
            LoadProvince();
        }

        private void SetPermission()
        {
            permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "12", User.UserInfo.Username);
            if (txtDistrictID.Text.Equals(""))
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

        private void LoadProvince()
        {
            DataTable dt = busProvince.GetDataCombobox(User.UserInfo.Username, User.UserInfo.LanguageID);
            if (dt != null && dt.Rows.Count > 0)
            {
                gluProvince.DataBindings.Clear();
                gluProvince.Properties.DataSource = dt;
                gluProvince.Properties.ValueMember = "ProvinceID";
                gluProvince.Properties.DisplayMember = "FullProvinceName";
            }
        }

        private bool CheckValidate()
        {
            if (txtDistrictCode.Text.Equals(""))
            {
                depError.SetError(txtDistrictCode, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
                txtDistrictCode.Focus();
                return false;
            }
            if (txtDistrictCode.Text.Contains(" "))
            {
                depError.SetError(txtDistrictCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
                txtDistrictCode.Focus();
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
            if (string.IsNullOrEmpty(gluProvince.EditValue + ""))
            {
                depError.SetError(gluProvince, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
                gluProvince.ShowPopup();
                return false;
            }

            return true;
        }

        private bool SaveDistrict(bool isEdit)
        {
            string strError = "";
            try
            {
                PRO_tblDistrictDTO item = new PRO_tblDistrictDTO
                {
                    Activity = (isEdit) ? "Update" : "Insert",
                    Username = User.UserInfo.Username,
                    LanguageID = User.UserInfo.LanguageID,
                    DistrictID = txtDistrictID.Text,
                    DistrictCode = txtDistrictCode.Text,
                    VNName = txtVNName.Text,
                    ENName = txtENName.Text,
                    ProvinceID = gluProvince.EditValue + "",
                    Rank = speRank.EditValue,
                    Used = chkUsed.Checked,
                    Note = mmoNote.EditValue + ""
                };
                strError = (isEdit) ? busDistrict.UpdateDistrict(item) : busDistrict.InsertDistrict(item);
                if (strError != "")
                {
                    Commons.ShowMessage(strError, 0);
                    txtDistrictCode.Focus();
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

        private void LoadDataToEdit(PRO_tblDistrictDTO item)
        {
            txtDistrictID.EditValue = (item == null) ? null : item.DistrictID;
            txtDistrictCode.EditValue = (item == null) ? null : item.DistrictCode;
            txtVNName.EditValue = (item == null) ? null : item.VNName;
            txtENName.EditValue = (item == null) ? null : item.ENName;
            gluProvince.EditValue = (item == null) ? null : item.ProvinceID;
            mmoNote.EditValue = (item == null) ? null : item.Note;
            chkUsed.Checked = (item == null) ? true : item.Used;
            speRank.EditValue = (item == null) ? null : item.Rank;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = (User.UserInfo.LanguageID.Equals("VN")) ? "Thêm Mới Quận Huyện" : "Insert New District";
            }
            txtDistrictCode.Focus();
        }
        #endregion

        #region [Form Events]
        public uc_DistrictDetail(uc_District parent)
        {
            InitializeComponent();
            parentForm = parent;
            Initialize();
            SetPermission();
        }

        public uc_DistrictDetail(uc_District parent, PRO_tblDistrictDTO item)
        {
            InitializeComponent();
            parentForm = parent;
            Initialize();
            SetPermission();
            LoadDataToEdit(item);
        }

        private void txtDistrictCode_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDistrictCode.Text.Contains(" "))
                depError.SetError(txtDistrictCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
            else depError.SetError(txtDistrictCode, (string.IsNullOrEmpty(txtDistrictCode.Text)) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void txtVNName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtVNName, (txtVNName.Text.Trim().Equals("")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void txtENName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtENName, (txtENName.Text.Trim().Equals("")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void gluProvince_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(gluProvince, (string.IsNullOrEmpty(gluProvince.EditValue + "")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (SaveDistrict((txtDistrictID.Text.Equals("")) ? false : true))
                    this.ParentForm.Close();
        }

        private void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (SaveDistrict((txtDistrictID.Text.Equals("")) ? false : true))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
