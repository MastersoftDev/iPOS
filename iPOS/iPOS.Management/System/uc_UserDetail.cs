using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.Management.Common;
using iPOS.BUS.System;
using iPOS.DTO.System;
using Commons = iPOS.Management.Common.Common;
using iPOS.Core.Helper;
using iPOS.Core.Security;

public partial class uc_UserDetail : DevExpress.XtraEditors.XtraUserControl
{
    #region [Declare Variables]
    SYS_tblGroupUserBUS busGroupUser;
    SYS_tblUserBUS busUser;
    uc_User parentForm;
    SYS_tblPermissionDTO permission;
    SYS_tblPermissionBUS busPermission;
    #endregion

    #region [Personal Methods]
    private void Initialize()
    {
        string Language = User.UserInfo.LanguageID;
        logDetail.Text = (Language.Equals("VN")) ? "Thông Tin Người Dùng" : "User Information";
        lciUsername.Text = (Language.Equals("VN")) ? "Tên tài khoản:" : "Username:";
        lciPassword.Text = (Language.Equals("VN")) ? "Mật khẩu:" : "Password:";
        lciGroup.Text = (Language.Equals("VN")) ? "Nhóm người dùng:" : "Group user:";
        chkIsEmployee.Text = (Language.Equals("VN")) ? "Là nhân viên cửa hàng?" : "Is the store employees?";
        lciFullName.Text = (Language.Equals("VN")) ? "Họ và tên:" : "Full name:";
        lciEmployee.Text = (Language.Equals("VN")) ? "Nhân viên:" : "Employee:";
        lciEffectiveDate.Text = (Language.Equals("VN")) ? "Ngày hiệu lực:" : "Effective date:";
        lciToDate.Text = (Language.Equals("VN")) ? "Đến ngày:" : "To date:";
        chkLock.Text = (Language.Equals("VN")) ? "Khóa tài khoản?" : "Is lock account?";
        logLockAccount.Text = (Language.Equals("VN")) ? "Thông tin khóa tài khoản" : "Lock account information";
        lciLockDate.Text = (Language.Equals("VN")) ? "Ngày khóa:" : "Lock date:";
        lciUnlockDate.Text = (Language.Equals("VN")) ? "Ngày mở khóa:" : "Unlock date:";
        chkCanNotChangePassword.Text = (Language.Equals("VN")) ? "Tài khoản không thể đổi mật khẩu?" : "User can't change password?";
        chkChangePassNextTime.Text = (Language.Equals("VN")) ? "Đổi mật khẩu khi đăng nhập lần kế tiếp?" : "User must change password at next login?";
        chkPasswordNeverExpired.Text = (Language.Equals("VN")) ? "Mật khẩu không bao giờ hết hạn?" : "Password never expired?";
        lciEmail.Text = (Language.Equals("VN")) ? "Email: " : "Email:";
        lciNote.Text = (Language.Equals("VN")) ? "Ghi chú:" : "Note:";
        gluGroupUser.Properties.NullText = (Language.Equals("VN")) ? "[Chọn nhóm người dùng]" : "[Choose a group user]";

        lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        logLockAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        daeEffectiveDate.EditValue = DateTime.Now;

        busGroupUser = new SYS_tblGroupUserBUS();
        busUser = new SYS_tblUserBUS();
        busPermission = new SYS_tblPermissionBUS();
        LoadGroupUser();
    }

    private void SetPermission()
    {
        permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "9", User.UserInfo.Username);
        if (txtUsernameID.Text.Equals(""))
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

    private void LoadGroupUser()
    {
        gluGroupUser.DataBindings.Clear();
        gluGroupUser.Properties.DataSource = busGroupUser.GetDataCombobox(User.UserInfo.Username, User.UserInfo.LanguageID);
        gluGroupUser.Properties.DisplayMember = "Note";
        gluGroupUser.Properties.ValueMember = "GroupID";

        gluGroupUser.EditValue = busGroupUser.GetDefaultGroup(User.UserInfo.Username, User.UserInfo.LanguageID);
    }

    private bool CheckValidate()
    {
        if (txtUsername.Text.Equals(""))
        {
            depError.SetError(txtUsername, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
            txtUsername.Focus();
            return false;
        }
        if (txtUsername.Text.Contains(" "))
        {
            depError.SetError(txtUsername, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
            txtUsername.Focus();
            return false;
        }
        if (txtPassword.Text.Equals(""))
        {
            depError.SetError(txtPassword, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
            txtPassword.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(gluGroupUser.EditValue + ""))
        {
            depError.SetError(gluGroupUser, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
            gluGroupUser.ShowPopup();
            return false;
        }
        if (!txtEmail.Text.Equals("") && !Commons.CheckEmailValid(txtEmail.Text))
        {
            depError.SetError(txtEmail, Lang.GetMessageByLanguage("000013", Commons.Culture, Commons.ResourceMessage));
            txtEmail.Focus();
            return false;
        }

        return true;
    }

    private bool SaveUser(bool isEdit)
    {
        string strError = "";
        try
        {
            SYS_tblUserDTO item = new SYS_tblUserDTO
            {
                UserName = txtUsername.Text,
                Password = Encryption.Encrypt(txtPassword.Text),
                GroupID = gluGroupUser.EditValue + "",
                EmpID = (chkIsEmployee.Checked) ? gluEmployee.EditValue + "" : "",
                FullName = txtFullName.Text,
                EffectiveDate = daeEffectiveDate.DateTime,
                DateChangePass = null,
                ToDate = (daeToDate.EditValue == null) ? null : daeToDate.EditValue,
                Locked = chkLock.Checked,
                LockDate = (chkLock.Checked) ? daeLockDate.EditValue : null,
                UnlockDate = (daeUnlockDate.EditValue == null) ? null : daeUnlockDate.EditValue,
                CanNotChangePassword = chkCanNotChangePassword.Checked,
                ChangePassNextTime = chkChangePassNextTime.Checked,
                PassNeverExpired = chkPasswordNeverExpired.Checked,
                Email = txtEmail.Text,
                Note = mmoNote.Text,
                Activity = (isEdit) ? "Update" : "Insert",
                Username = User.UserInfo.Username,
                LanguageID = User.UserInfo.LanguageID
            };
            strError = (isEdit) ? busUser.UpdateUser(item) : busUser.InsertUser(item);
            if (strError != "")
            {
                Commons.ShowMessage(strError, 0);
                txtUsername.Focus();
                return false;
            }
            else parentForm.LoadAllData();
        }
        catch (Exception ex)
        {
            Commons.ShowExceptionMessage(ex);
            txtUsername.Focus();
            return false;
        }

        return true;
    }

    private void LoadDataToEdit(SYS_tblUserDTO item)
    {
        txtUsername.EditValue = (item == null) ? null : item.UserName;
        txtUsername.Enabled = (item == null) ? true : false;
        txtUsernameID.EditValue = (item == null) ? null : item.UserName;
        txtPassword.EditValue = (item == null) ? null : Encryption.Decrypt(item.Password);
        txtPassword.Enabled = (item == null) ? true : false;
        gluGroupUser.EditValue = (item == null) ? busGroupUser.GetDefaultGroup(User.UserInfo.Username, User.UserInfo.LanguageID) : item.GroupID;
        chkIsEmployee.Checked = (item != null && !string.IsNullOrEmpty(item.EmpID)) ? true : false;
        txtFullName.EditValue = (item == null) ? null : item.FullName;
        gluEmployee.EditValue = null;
        daeEffectiveDate.EditValue = (item == null) ? DateTime.Now : item.EffectiveDate;
        daeToDate.EditValue = (item == null) ? null : item.ToDate;
        chkLock.Checked = (item == null) ? false : item.Locked;
        daeLockDate.EditValue = (item == null) ? null : item.LockDate;
        daeUnlockDate.EditValue = (item == null) ? null : item.UnlockDate;
        chkCanNotChangePassword.Checked = (item == null) ? false : item.CanNotChangePassword;
        chkChangePassNextTime.Checked = (item == null) ? false : item.ChangePassNextTime;
        chkPasswordNeverExpired.Checked = (item == null) ? false : item.PassNeverExpired;
        txtEmail.EditValue = (item == null) ? null : item.Email;
        mmoNote.EditValue = (item == null) ? null : item.Note;
        if (item == null)
        {
            depError.ClearErrors();
            this.ParentForm.Text = (User.UserInfo.LanguageID.Equals("VN")) ? "Thêm Mới Người Dùng" : "Insert New User";
        }
        txtUsername.Focus();
    }
    #endregion

    #region [Form Events]
    public uc_UserDetail(uc_User parent)
    {
        InitializeComponent();
        Initialize();
        parentForm = parent;
        SetPermission();
    }

    public uc_UserDetail(uc_User parent, SYS_tblUserDTO item)
    {
        InitializeComponent();
        Initialize();
        parentForm = parent;
        LoadDataToEdit(item);
        SetPermission();
    }

    private void chkIsEmployee_CheckedChanged(object sender, EventArgs e)
    {
        lciEmployee.Visibility = (!chkIsEmployee.Checked) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        lciFullName.Visibility = (chkIsEmployee.Checked) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
    }

    private void chkLock_CheckedChanged(object sender, EventArgs e)
    {
        logLockAccount.Visibility = (!chkLock.Checked) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
    }

    private void txtUsername_EditValueChanged(object sender, EventArgs e)
    {
        if (txtUsername.Text.Contains(" "))
            depError.SetError(txtUsername, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
        else depError.SetError(txtUsername, (string.IsNullOrEmpty(txtUsername.Text)) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
    }

    private void txtPassword_EditValueChanged(object sender, EventArgs e)
    {
        depError.SetError(txtPassword, (txtPassword.Text.Trim().Equals("")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
    }

    private void gluGroupUser_EditValueChanged(object sender, EventArgs e)
    {
        depError.SetError(gluGroupUser, (string.IsNullOrEmpty(gluGroupUser.EditValue + "")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
    }

    private void chkCanNotChangePassword_CheckedChanged(object sender, EventArgs e)
    {
        chkChangePassNextTime.Enabled = chkPasswordNeverExpired.Enabled = !chkCanNotChangePassword.Checked;
    }

    private void txtEmail_EditValueChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtEmail.Text))
            depError.SetError(txtEmail, !Commons.CheckEmailValid(txtEmail.Text) ? Lang.GetMessageByLanguage("000013", Commons.Culture, Commons.ResourceMessage) : null);
        else depError.SetError(txtEmail, null);
    }

    private void btnSaveClose_Click(object sender, EventArgs e)
    {
        if (CheckValidate())
            if (SaveUser((txtUsernameID.Text.Equals("")) ? false : true))
                this.ParentForm.Close();
    }

    private void btnSaveInsert_Click(object sender, EventArgs e)
    {
        if (CheckValidate())
            if (SaveUser((txtUsernameID.Text.Equals("")) ? false : true))
                LoadDataToEdit(null);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.ParentForm.Close();
    }
    #endregion
}