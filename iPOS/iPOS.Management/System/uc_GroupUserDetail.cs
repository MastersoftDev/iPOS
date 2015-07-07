using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.BUS.System;
using iPOS.Core.Helper;
using Commons = iPOS.Management.Common.Common;
using iPOS.DTO.System;
using iPOS.Management.Common;

public partial class uc_GroupUserDetail : DevExpress.XtraEditors.XtraUserControl
{
    #region [Declare Variables]
    SYS_tblGroupUserBUS busGroupUser;
    uc_GroupUser parentForm;
    SYS_tblPermissionDTO permission;
    SYS_tblPermissionBUS busPermission;
    #endregion

    #region [Personal Methods]
    private void Initialize()
    {
        string Language = User.UserInfo.LanguageID;
        logDetail.Text = (Language.Equals("VN")) ? "Thông Tin Nhóm Người Dùng" : "Group User Information";
        lciGroupCode.Text = (Language.Equals("VN")) ? "Mã nhóm:" : "Group code:";
        lciGroupName.Text = (Language.Equals("VN")) ? "Tên nhóm:" : "Group name:";
        lciNote.Text = (Language.Equals("VN")) ? "Ghi chú:" : "Note:";
        chkIsDefault.Text = (Language.Equals("VN")) ? "Nhóm mặc định?" : "Is default group?";
        chkActive.Text = (Language.Equals("VN")) ? "Đã kích hoạt?" : "Is actived?";
        btnSaveClose.Text = (Language.Equals("VN")) ? "Lưu && Đóng" : "Save && Close";
        btnSaveInsert.Text = (Language.Equals("VN")) ? "Lưu && Thêm" : "Save && Insert";
        btnCancel.Text = (Language.Equals("VN")) ? "Hủy Bỏ" : "Cancel";

        busGroupUser = new SYS_tblGroupUserBUS();
        busPermission = new SYS_tblPermissionBUS();
    }

    private void SetPermission()
    {
        permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "9", User.UserInfo.Username);
        if (txtGroupID.Text.Equals(""))
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
        if (txtGroupCode.Text.Equals(""))
        {
            depError.SetError(txtGroupCode, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
            txtGroupCode.Focus();
            return false;
        }
        if (txtGroupCode.Text.Contains(" "))
        {
            depError.SetError(txtGroupCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
            txtGroupCode.Focus();
            return false;
        }
        if (txtGroupName.Text.Equals(""))
        {
            depError.SetError(txtGroupName, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
            txtGroupName.Focus();
            return false;
        }

        return true;
    }

    private bool SaveGroupUser(bool isEdit)
    {
        string strError = "";
        try
        {
            SYS_tblGroupUserDTO item = new SYS_tblGroupUserDTO
            {
                GroupID = txtGroupID.Text,
                GroupCode = txtGroupCode.Text,
                GroupName = txtGroupName.Text,
                Note = mmoNote.Text,
                IsDefault = chkIsDefault.Checked,
                Active = chkActive.Checked,
                Activity = (isEdit) ? "Update" : "Insert",
                Username = User.UserInfo.Username,
                LanguageID = User.UserInfo.LanguageID
            };
            strError = (isEdit) ? busGroupUser.UpdateGroupUser(item) : busGroupUser.InsertGroupUser(item);
            if (strError != "")
            {
                Commons.ShowMessage(strError, 0);
                txtGroupCode.Focus();
                return false;
            }
            else parentForm.LoadAllData();
        }
        catch (Exception ex)
        {
            Commons.ShowExceptionMessage(ex);
            txtGroupCode.Focus();
            return false;
        }
        return true;
    }

    private void LoadDataToEdit(SYS_tblGroupUserDTO item)
    {
        txtGroupID.EditValue = (item == null) ? null : item.GroupID;
        txtGroupCode.EditValue = (item == null) ? null : item.GroupCode;
        txtGroupName.EditValue = (item == null) ? null : item.GroupName;
        mmoNote.EditValue = (item == null) ? null : item.Note;
        chkIsDefault.EditValue = (item == null) ? false : item.IsDefault;
        chkActive.EditValue = (item == null) ? true : item.Active;
        if (item == null)
        {
            depError.ClearErrors();
            this.ParentForm.Text = (User.UserInfo.LanguageID.Equals("VN")) ? "Thêm Mới Nhóm Người Dùng" : "Insert New Group User";
        }
        txtGroupCode.Focus();
    }
    #endregion

    #region [Form Events]
    public uc_GroupUserDetail(uc_GroupUser _parent)
    {
        InitializeComponent();
        Initialize();
        parentForm = _parent;
        SetPermission();
    }

    public uc_GroupUserDetail(uc_GroupUser _parent, SYS_tblGroupUserDTO item)
    {
        InitializeComponent();
        Initialize();
        parentForm = _parent;
        LoadDataToEdit(item);
        SetPermission();
    }

    private void txtGroupCode_EditValueChanged(object sender, EventArgs e)
    {
        if (txtGroupCode.Text.Contains(" "))
            depError.SetError(txtGroupCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
        else depError.SetError(txtGroupCode, (string.IsNullOrEmpty(txtGroupCode.Text)) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
    }

    private void txtGroupName_EditValueChanged(object sender, EventArgs e)
    {
        depError.SetError(txtGroupName, (txtGroupName.Text.Trim().Equals("")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
    }

    private void btnSaveClose_Click(object sender, EventArgs e)
    {
        if (CheckValidate())
            if (SaveGroupUser((txtGroupID.Text.Equals("")) ? false : true))
                this.ParentForm.Close();
    }

    private void btnSaveInsert_Click(object sender, EventArgs e)
    {
        if (CheckValidate())
            if (SaveGroupUser((txtGroupID.Text.Equals("")) ? false : true))
                LoadDataToEdit(null);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.ParentForm.Close();
    }
    #endregion
}