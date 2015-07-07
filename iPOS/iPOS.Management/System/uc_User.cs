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
using iPOS.BUS.System;
using iPOS.Core.Logger;
using iPOS.DTO.System;
using iPOS.Core.Helper;

public partial class uc_User : DevExpress.XtraEditors.XtraUserControl
{
    #region [Declare Variables]
    SYS_tblUserBUS busUser;
    DataRowView curRow;
    string userList = "";
    SYS_tblPermissionDTO permission;
    SYS_tblPermissionBUS busPermission;
    #endregion

    #region [Personal Methods]
    private void Initialize()
    {
        string Language = User.UserInfo.LanguageID;
        btnInsert.Caption = (Language.Equals("VN")) ? "Thêm" : "Insert";
        btnUpdate.Caption = (Language.Equals("VN")) ? "Cập Nhật" : "Update";
        btnDelete.Caption = (Language.Equals("VN")) ? "Xóa" : "Delete";
        btnPrint.Caption = (Language.Equals("VN")) ? "In" : "Print";
        btnReload.Caption = (Language.Equals("VN")) ? "Tải Lại" : "Reload";
        btnImport.Caption = (Language.Equals("VN")) ? "Nhập" : "Import";
        btnExport.Caption = (Language.Equals("VN")) ? "Xuất" : "Export";
        btnClose.Caption = (Language.Equals("VN")) ? "Đóng" : "Close";

        grvUser.GroupPanelText = (Language.Equals("VN")) ? "Kéo một tiêu đề cột vào đây để nhóm theo cột đó" : "Drag a column header here to group by that column";
        gcolUsername.Caption = (Language.Equals("VN")) ? "Tên người dùng" : "Username";
        gcolGroupName.Caption = (Language.Equals("VN")) ? "Nhóm người dùng" : "Group name";
        gcolFullName.Caption = (Language.Equals("VN")) ? "Họ và tên" : "Fullname";
        gcolEmpCode.Caption = (Language.Equals("VN")) ? "Mã nhân viên" : "Employee code";
        gcolEffectiveDate.Caption = (Language.Equals("VN")) ? "Ngày hiệu lực" : "Effective date";
        gcolEmail.Caption = (Language.Equals("VN")) ? "Email" : "Email";
        gcolNote.Caption = (Language.Equals("VN")) ? "Ghi chú" : "Note";

        busUser = new SYS_tblUserBUS();
        busPermission = new SYS_tblPermissionBUS();
    }

    private void SetPermission()
    {
        permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "10", User.UserInfo.Username);
        btnInsert.Enabled = permission.AllowInsert;
        btnDelete.Enabled = permission.AllowDelete;
        btnPrint.Enabled = permission.AllowPrint;
        btnImport.Enabled = permission.AllowImport;
        btnExport.Enabled = permission.AllowExport;
    }

    public void LoadAllData()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = busUser.LoadAllData(User.UserInfo.Username, User.UserInfo.LanguageID);
            gridUser.DataBindings.Clear();
            gridUser.DataSource = dt;
            barFooter.Visible = (dt.Rows.Count > 0) ? true : false;

            SetPermission();
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }
    }

    private void GetCurrentRow()
    {
        try
        {
            curRow = (DataRowView)grvUser.GetFocusedRow();
            if (curRow != null)
                Commons.SetDislayStringArray(new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime }, new string[] { curRow["Creater"].ToString(), curRow["CreateTime"].ToString(), curRow["Editer"].ToString(), curRow["EditTime"].ToString() });
        }
        catch (Exception ex)
        {
            Commons.ShowExceptionMessage(ex);
        }
    }

    private void DeleteUser()
    {
        string strError = "";
        if (userList.Contains("$"))
        {
            if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000012", Commons.Culture, Commons.ResourceMessage).Replace("$Count$", userList.Split('$').Length.ToString())))
                strError = busUser.DeleteListUser(userList, User.UserInfo.Username, User.UserInfo.LanguageID);
        }
        else
        {
            if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000005", Commons.Culture, Commons.ResourceMessage)))
                strError = busUser.DeleteUser(userList, User.UserInfo.Username, User.UserInfo.LanguageID);
        }

        if (strError.Equals("")) LoadAllData();
        else Commons.ShowMessage(strError, 0);
    }
    #endregion

    #region [Form Events]
    public uc_User()
    {
        InitializeComponent();
        Initialize();
    }

    private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        Commons.OpenInputForm(new uc_UserDetail(this), "Thêm Mới Người Dùng", "Insert New User", new System.Drawing.Size(455, 460));
    }

    private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        if (curRow != null)
        {
            SYS_tblUserDTO item = busUser.GetDataByID(curRow["Username"] + "", User.UserInfo.Username, User.UserInfo.LanguageID);
            if(item!=null)
                Commons.OpenInputForm(new uc_UserDetail(this, item), "Cập Nhật Người Dùng", "Update User", new System.Drawing.Size(455, 460));
        }
    }

    private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        DeleteUser();
    }

    private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        LoadAllData();
    }

    private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        Commons.QuickExportData(gridUser, grvUser);
    }

    private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        this.ParentForm.Close();
    }

    private void grvUser_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
        if (e.RowHandle >= 0 && e.Info.IsRowIndicator)
            e.Info.DisplayText = e.RowHandle + 1 + "";
    }

    private void grvUser_DoubleClick(object sender, EventArgs e)
    {
        btnUpdate_ItemClick(null, null);
    }

    private void grvUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
        GetCurrentRow();
    }

    private void grvUser_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
    {
        GetCurrentRow();
    }

    private void grvUser_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
    {
        userList = "";
        foreach (int index in grvUser.GetSelectedRows())
            userList += grvUser.GetRowCellDisplayText(index, gcolUsername) + "$";

        if (userList.Length > 0)
            userList = userList.Substring(0, userList.Length - 1);
    }

    private void uc_User_Load(object sender, EventArgs e)
    {
        LoadAllData();
    }
    #endregion
}