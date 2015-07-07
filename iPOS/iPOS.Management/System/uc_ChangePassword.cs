using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.Management.Common;
using Commons = iPOS.Management.Common.Common;
using iPOS.Core.Helper;
using iPOS.Core.Security;
using iPOS.BUS.System;

public partial class uc_ChangePassword : DevExpress.XtraEditors.XtraUserControl
{
    #region [Declare Variables]
    private SYS_tblUserBUS busUser;
    #endregion

    #region [Personal Methods]
    private void Initialize()
    {
        string Language = User.UserInfo.LanguageID;
        logMain.Text = (Language.Equals("VN")) ? "Thông Tin Mật Khẩu" : "Password Information";
        lciUsername.Text = (Language.Equals("VN")) ? "Tên tài khoản:" : "Username:";
        lciGroupName.Text = (Language.Equals("VN")) ? "Nhóm người dùng:" : "Group name:";
        lciOldPassword.Text = (Language.Equals("VN")) ? "Mật khẩu cũ:" : "Old password:";
        lciNewPassword.Text = (Language.Equals("VN")) ? "Mật khẩu mới:" : "New password:";
        lciConfirmPassword.Text = (Language.Equals("VN")) ? "Xác nhận mật khẩu mới:" : "Confirm new passowrd:";
        btnSave.Text = (Language.Equals("VN")) ? "Lưu Lại" : "Save";
        btnCancel.Text = (Language.Equals("VN")) ? "Hủy Bỏ" : "Cancel";

        txtUsername.Text = User.UserInfo.Username;
        txtGroupName.Text = User.UserInfo.GroupName;
        txtOldPassword.Focus();

        busUser = new SYS_tblUserBUS();
    }

    private bool CheckValidate()
    {
        if (string.IsNullOrEmpty(txtOldPassword.Text))
        {
            depError.SetError(txtOldPassword, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
            txtOldPassword.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtNewPassword.Text))
        {
            depError.SetError(txtNewPassword, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
            txtNewPassword.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtConfirmPassword.Text))
        {
            depError.SetError(txtConfirmPassword, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
            txtConfirmPassword.Focus();
            return false;
        }
        if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
        {
            depError.SetError(txtConfirmPassword, Lang.GetMessageByLanguage("000014", Commons.Culture, Commons.ResourceMessage));
            txtConfirmPassword.Focus();
            return false;
        }
        if (!Encryption.Encrypt(txtOldPassword.Text).Equals(User.UserInfo.Password))
        {
            depError.SetError(txtOldPassword, Lang.GetMessageByLanguage("000015", Commons.Culture, Commons.ResourceMessage));
            txtOldPassword.Focus();
            return false;
        }

        return true;
    }
    #endregion

    #region [Form Events]
    public uc_ChangePassword()
    {
        InitializeComponent();
        Initialize();
    }

    private void txtOldPassword_EditValueChanged(object sender, EventArgs e)
    {
        depError.SetError(txtOldPassword, (!txtOldPassword.Text.Equals("")) ? null : Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
    }

    private void txtNewPassword_EditValueChanged(object sender, EventArgs e)
    {
        if (txtNewPassword.Text.Equals(""))
            depError.SetError(txtNewPassword, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
        else if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
            depError.SetError(txtNewPassword, Lang.GetMessageByLanguage("000014", Commons.Culture, Commons.ResourceMessage));
        else
        {
            depError.SetError(txtNewPassword, null);
            depError.SetError(txtConfirmPassword, null);
        }
    }

    private void txtConfirmPassword_EditValueChanged(object sender, EventArgs e)
    {
        if (txtConfirmPassword.Text.Equals(""))
            depError.SetError(txtConfirmPassword, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
        else if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
            depError.SetError(txtConfirmPassword, Lang.GetMessageByLanguage("000014", Commons.Culture, Commons.ResourceMessage));
        else
        {
            depError.SetError(txtNewPassword, null);
            depError.SetError(txtConfirmPassword, null);
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (CheckValidate())
        {
            string strError = "";
            try
            {
                strError = busUser.ChangePassword(txtUsername.Text, User.UserInfo.LanguageID, Encryption.Encrypt(txtNewPassword.Text));
                if (strError.Equals(""))
                {
                    txtOldPassword.EditValue = txtNewPassword.EditValue = txtConfirmPassword.EditValue = null;
                    Commons.ShowMessage((User.UserInfo.LanguageID.Equals("VN")) ? "Đổi mật khẩu thành công." : "Change password successfully.", 1);
                    User.UserInfo = busUser.GetDataByID(txtUsername.Text, txtUsername.Text, User.UserInfo.LanguageID);
                    txtOldPassword.Focus();
                    depError.ClearErrors();
                }
                else
                {
                    Commons.ShowMessage(strError, 0);
                    txtOldPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                Commons.ShowExceptionMessage(ex);
                txtOldPassword.Focus();
            }
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.ParentForm.Close();
    }
    #endregion
}