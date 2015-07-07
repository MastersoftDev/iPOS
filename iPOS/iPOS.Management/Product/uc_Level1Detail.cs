using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.Core.Helper;
using Commons = iPOS.Management.Common.Common;
using iPOS.BUS.Product;
using iPOS.BUS.System;
using iPOS.DTO.System;
using iPOS.Management.Common;

namespace iPOS.Management.Product
{
    public partial class uc_Level1Detail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        PRO_tblProductGroupLevel1BUS busLevel1;
        SYS_tblPermissionBUS busPermission;
        SYS_tblPermissionDTO permission;
        uc_Level1 parentForm;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            string LanguageID = User.UserInfo.LanguageID;
            logDetail.Text = LanguageID.Equals("VN") ? "Thông Tin Ngành Hàng" : "Product Sector Information";
            lciLevel1Code.Text = LanguageID.Equals("VN") ? "Mã ngành hàng:" : "Product sector code:";
            lciLevel1ShortCode.Text = LanguageID.Equals("VN") ? "Mã nội bộ:" : "Internal code:";
            lciVNName.Text = LanguageID.Equals("VN") ? "Tên ngành hàng VN:" : "VN Sector name:";
            lciENName.Text = LanguageID.Equals("VN") ? "Tên ngành hàng EN:" : "EN Sector name:";
            lciRank.Text = LanguageID.Equals("VN") ? "Thứ tự:" : "Rank:";
            chkUsed.Text = LanguageID.Equals("VN") ? "Đang hoạt động?" : "Are active?";
            lciNote.Text = LanguageID.Equals("VN") ? "Ghi chú:" : "Note:";
            lciDescription.Text = LanguageID.Equals("VN") ? "Mô tả:" : "Description:";
            btnSaveClose.Text = (LanguageID.Equals("VN")) ? "Lưu && Đóng" : "Save && Close";
            btnSaveInsert.Text = (LanguageID.Equals("VN")) ? "Lưu && Thêm" : "Save && Insert";
            btnCancel.Text = (LanguageID.Equals("VN")) ? "Hủy Bỏ" : "Cancel";

            busLevel1 = new PRO_tblProductGroupLevel1BUS();
            busPermission = new SYS_tblPermissionBUS();
        }

        private void SetPermission()
        {
            permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "20", User.UserInfo.Username);
            if (txtLevel1ID.Text.Equals(""))
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
        #endregion

        public uc_Level1Detail(uc_Level1 parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void txtLevel1Code_EditValueChanged(object sender, EventArgs e)
        {
            if (txtLevel1Code.Text.Contains(" "))
                depError.SetError(txtLevel1Code, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
            else depError.SetError(txtLevel1Code, (string.IsNullOrEmpty(txtLevel1Code.Text)) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void txtLevel1ShortCode_EditValueChanged(object sender, EventArgs e)
        {
            if (txtLevel1ShortCode.Text.Contains(" "))
                depError.SetError(txtLevel1ShortCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
            else depError.SetError(txtLevel1ShortCode, (string.IsNullOrEmpty(txtLevel1ShortCode.Text)) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void txtLevel1ShortCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtLevel1ShortCode_Leave(object sender, EventArgs e)
        {
            if (txtLevel1ShortCode.Text.Length < 2)
                txtLevel1ShortCode.Text = txtLevel1ShortCode.Text.PadLeft(2, '0');
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

        }

        private void btnSaveInsert_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
