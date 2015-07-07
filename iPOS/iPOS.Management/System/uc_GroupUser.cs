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
using iPOS.BUS.System;
using iPOS.Core.Logger;
using iPOS.Management.Common;
using iPOS.DTO.System;

public partial class uc_GroupUser : DevExpress.XtraEditors.XtraUserControl
{
    #region [Declare Variables]
    SYS_tblGroupUserBUS busGroupUser;
    DataRowView curRow;
    string groupCodeList = "", groupIDList = "";
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

        grvGroupUser.GroupPanelText = (Language.Equals("VN")) ? "Kéo một tiêu đề cột vào đây để nhóm theo cột đó" : "Drag a column header here to group by that column";
        gcolGroupCode.Caption = (Language.Equals("VN")) ? "Mã nhóm" : "Group code";
        gcolGroupName.Caption = (Language.Equals("VN")) ? "Tên nhóm" : "Group name";
        gcolActiveString.Caption = (Language.Equals("VN")) ? "Kích hoạt?" : "Active?";
        gcolIsDefaultString.Caption = (Language.Equals("VN")) ? "Mặc định?" : "Is default?";
        gcolNote.Caption = (Language.Equals("VN")) ? "Ghi chú" : "Note";

        busGroupUser = new SYS_tblGroupUserBUS();
        busPermission = new SYS_tblPermissionBUS();
    }

    private void SetPermission()
    {
        permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "9", User.UserInfo.Username);
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
            dt = busGroupUser.LoadAllData(User.UserInfo.Username, User.UserInfo.LanguageID);
            gridGroupUser.DataBindings.Clear();
            gridGroupUser.DataSource = dt;
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
            curRow = (DataRowView)grvGroupUser.GetFocusedRow();
            if (curRow != null)
                Commons.SetDislayStringArray(new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime }, new string[] { curRow["Creater"].ToString(), curRow["CreateTime"].ToString(), curRow["Editer"].ToString(), curRow["EditTime"].ToString() });
        }
        catch (Exception ex)
        {
            Commons.ShowExceptionMessage(ex);
        }
    }

    private void DeleteGroupUser()
    {
        string strError = "";
        if (groupIDList.Contains("$"))
        {
            if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000012", Commons.Culture, Commons.ResourceMessage).Replace("$Count$", groupIDList.Split('$').Length.ToString())))
                strError = busGroupUser.DeleteListGroupUser(groupIDList, groupCodeList, User.UserInfo.Username, User.UserInfo.LanguageID);
        }
        else
        {
            if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000005", Commons.Culture, Commons.ResourceMessage)))
                strError = busGroupUser.DeleteGroupUser(groupIDList, groupCodeList, User.UserInfo.Username, User.UserInfo.LanguageID);
        }

        if (strError.Equals("")) LoadAllData();
        else Commons.ShowMessage(strError, 0);
    }
    #endregion

    #region [Form Events]
    public uc_GroupUser()
    {
        InitializeComponent();
        Initialize();
    }

    private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        Commons.OpenInputForm(new uc_GroupUserDetail(this), "Thêm Mới Nhóm Người Dùng", "Insert New Group User", new Size(450, 290));
    }

    private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        if (curRow != null)
        {
            SYS_tblGroupUserDTO item = busGroupUser.GetDataByID(curRow["GroupID"] + "", User.UserInfo.Username, User.UserInfo.LanguageID);
            if (item != null)
                Commons.OpenInputForm(new uc_GroupUserDetail(this, item), "Cập Nhật Nhóm Người Dùng", "Update Group User", new Size(450, 290));
        }
    }

    private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        DeleteGroupUser();
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
        Commons.QuickExportData(gridGroupUser, grvGroupUser);
    }

    private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        this.ParentForm.Close();
    }

    private void uc_GroupUser_Load(object sender, EventArgs e)
    {
        LoadAllData();
    }

    private void grvGroupUser_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
        if (e.RowHandle >= 0 && e.Info.IsRowIndicator)
            e.Info.DisplayText = e.RowHandle + 1 + "";
    }

    private void grvGroupUser_DoubleClick(object sender, EventArgs e)
    {
        btnUpdate_ItemClick(null, null);
    }

    private void grvGroupUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
        GetCurrentRow();
    }

    private void grvGroupUser_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
    {
        GetCurrentRow();
    }

    private void grvGroupUser_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
    {
        groupCodeList = "";
        groupIDList = "";
        foreach (int index in grvGroupUser.GetSelectedRows())
        {
            groupCodeList += grvGroupUser.GetRowCellDisplayText(index, gcolGroupCode) + "$";
            groupIDList += grvGroupUser.GetRowCellDisplayText(index, gcolGroupID) + "$";
        }

        if (groupCodeList.Length > 0)
            groupCodeList = groupCodeList.Substring(0, groupCodeList.Length - 1);
        if (groupIDList.Length > 0)
            groupIDList = groupIDList.Substring(0, groupIDList.Length - 1);
    }
    #endregion
}