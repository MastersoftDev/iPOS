using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Commons = iPOS.Management.Common.Common;
using iPOS.BUS.Product;
using iPOS.DTO.System;
using iPOS.BUS.System;
using iPOS.Management.Common;
using iPOS.Core.Logger;
using iPOS.Core.Helper;
using iPOS.DTO.Product;

namespace iPOS.Management.Product
{
    public partial class uc_Stall : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        PRO_tblStallBUS busStall;
        DataRowView curRow;
        string stallCodeList = "", stallIDList = "";
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

            grvStall.GroupPanelText = (Language.Equals("VN")) ? "Kéo một tiêu đề cột vào đây để nhóm theo cột đó" : "Drag a column header here to group by that column";
            gcolStallCode.Caption = Language.Equals("VN") ? "Mã quầy bán" : "Stall code";
            gcolStallName.Caption = Language.Equals("VN") ? "Tên quầy bán" : "Stall name";
            gcolStoreName.Caption = Language.Equals("VN") ? "Cửa hàng" : "Store";
            gcolWarehouseName.Caption = Language.Equals("VN") ? "Kho hàng" : "Warehouse";
            gcolRank.Caption = Language.Equals("VN") ? "Thứ tự" : "Rank";
            gcolUsedString.Caption = Language.Equals("VN") ? "Đang hoạt động?" : "Are active?";
            gcolNote.Caption = Language.Equals("VN") ? "Ghi chú" : "Note";

            busStall = new PRO_tblStallBUS();
            busPermission = new SYS_tblPermissionBUS();
        }

        private void SetPermission()
        {
            permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "19", User.UserInfo.Username);
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
                dt = busStall.LoadAllData(User.UserInfo.Username, User.UserInfo.LanguageID);
                gridStall.DataBindings.Clear();
                gridStall.DataSource = dt;
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
                curRow = (DataRowView)grvStall.GetFocusedRow();
                if (curRow != null)
                    Commons.SetDislayStringArray(new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime }, new string[] { curRow["Creater"].ToString(), curRow["CreateTime"].ToString(), curRow["Editer"].ToString(), curRow["EditTime"].ToString() });
            }
            catch (Exception ex)
            {
                Commons.ShowExceptionMessage(ex);
            }
        }

        private void DeleteStall()
        {
            string strError = "";
            if (stallIDList.Contains("$"))
            {
                if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000012", Commons.Culture, Commons.ResourceMessage).Replace("$Count$", stallIDList.Split('$').Length.ToString())))
                    strError = busStall.DeleteListStall(stallIDList, stallCodeList, User.UserInfo.Username, User.UserInfo.LanguageID);
            }
            else
            {
                if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000005", Commons.Culture, Commons.ResourceMessage)))
                    strError = busStall.DeleteStall(stallIDList, stallCodeList, User.UserInfo.Username, User.UserInfo.LanguageID);
            }

            if (strError.Equals("")) LoadAllData();
            else Commons.ShowMessage(strError, 0);
        }
        #endregion

        #region [Form Events]
        public uc_Stall()
        {
            InitializeComponent();
            Initialize();
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Commons.OpenInputForm(new uc_StallDetail(this), "Thêm Mới Quầy Bán", "Insert New Stall", new Size(395, 280));
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curRow != null)
            {
                PRO_tblStallDTO item = busStall.GetDataByID(curRow["StallID"] + "", User.UserInfo.Username, User.UserInfo.LanguageID);
                if (item != null)
                    Commons.OpenInputForm(new uc_StallDetail(this, item), "Cập Nhật Quầy Bán", "Update Stall", new Size(395, 280));
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteStall();
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
            Commons.OpenImportForm("PRO_Stall_FileSelect.xlsx", "PRO_spfrmStallImport", "PRO", "19");
            LoadAllData();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Commons.QuickExportData(gridStall, grvStall);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uc_Stall_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void grvStall_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvStall_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvStall_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvStall_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvStall_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            stallCodeList = "";
            stallIDList = "";
            foreach (int index in grvStall.GetSelectedRows())
            {
                stallCodeList += grvStall.GetRowCellDisplayText(index, gcolStallCode) + "$";
                stallIDList += grvStall.GetRowCellDisplayText(index, gcolStallID) + "$";
            }

            if (stallCodeList.Length > 0)
                stallCodeList = stallCodeList.Substring(0, stallCodeList.Length - 1);
            if (stallIDList.Length > 0)
                stallIDList = stallIDList.Substring(0, stallIDList.Length - 1);
        }
        #endregion
    }
}
