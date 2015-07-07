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
    public partial class uc_Store : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        PRO_tblStoreBUS busStore;
        DataRowView curRow;
        string storeCodeList = "", storeIDList = "";
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

            grvStore.GroupPanelText = (Language.Equals("VN")) ? "Kéo một tiêu đề cột vào đây để nhóm theo cột đó" : "Drag a column header here to group by that column";
            gcolStoreCode.Caption = Language.Equals("VN") ? "Mã cửa hàng" : "Store code";
            gcolShortCode.Caption = Language.Equals("VN") ? "Mã nội bộ" : "Internal code";
            gcolStoreName.Caption = Language.Equals("VN") ? "Tên cửa hàng" : "Store name";
            gcolStoreAddress.Caption = Language.Equals("VN") ? "Địa chỉ cửa hàng" : "Store address";
            gcolBuildDate.Caption = Language.Equals("VN") ? "Ngày thành lập" : "Date of establishment";
            gcolPhone.Caption = Language.Equals("VN") ? "Số điện thoại" : "Phone";
            gcolTaxCode.Caption = Language.Equals("VN") ? "Mã số thuế" : "Tax code";
            gcolRank.Caption = Language.Equals("VN") ? "Thứ tự" : "Rank";
            gcolRepresentatives.Caption = Language.Equals("VN") ? "Người đại diện" : "Representative";
            gcolUsedString.Caption = Language.Equals("VN") ? "Đang hoạt động?" : "Are active?";
            gcolIsRootString.Caption = Language.Equals("VN") ? "Cửa hàng chính?" : "Is primary store?";
            gcolNote.Caption = Language.Equals("VN") ? "Ghi chú" : "Note";
            gcolProvinceName.Caption = Language.Equals("VN") ? "Tỉnh thành" : "Province name";
            gcolDistrictName.Caption = Language.Equals("VN") ? "Quận huyện" : "Distict name";
            
            busStore = new PRO_tblStoreBUS();
            busPermission = new SYS_tblPermissionBUS();
        }

        private void SetPermission()
        {
            permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "13", User.UserInfo.Username);
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
                dt = busStore.LoadAllData(User.UserInfo.Username, User.UserInfo.LanguageID);
                gridStore.DataBindings.Clear();
                gridStore.DataSource = dt;
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
                curRow = (DataRowView)grvStore.GetFocusedRow();
                if (curRow != null)
                    Commons.SetDislayStringArray(new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime }, new string[] { curRow["Creater"].ToString(), curRow["CreateTime"].ToString(), curRow["Editer"].ToString(), curRow["EditTime"].ToString() });
            }
            catch (Exception ex)
            {
                Commons.ShowExceptionMessage(ex);
            }
        }

        private void DeleteStore()
        {
            string strError = "";
            if (storeIDList.Contains("$"))
            {
                if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000012", Commons.Culture, Commons.ResourceMessage).Replace("$Count$", storeIDList.Split('$').Length.ToString())))
                    strError = busStore.DeleteListStore(storeIDList, storeCodeList, User.UserInfo.Username, User.UserInfo.LanguageID);
            }
            else
            {
                if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000005", Commons.Culture, Commons.ResourceMessage)))
                    strError = busStore.DeleteStore(storeIDList, storeCodeList, User.UserInfo.Username, User.UserInfo.LanguageID);
            }

            if (strError.Equals("")) LoadAllData();
            else Commons.ShowMessage(strError, 0);
        }
        #endregion

        #region [Form Events]
        public uc_Store()
        {
            InitializeComponent();
            Initialize();
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Commons.OpenInputForm(new uc_StoreDetail(this), "Thêm Mới Cửa Hàng", "Insert New Store", new Size(660, 400));
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curRow != null)
            {
                PRO_tblStoreDTO item = busStore.GetDataByID(curRow["StoreID"] + "", User.UserInfo.Username, User.UserInfo.LanguageID);
                if (item != null)
                    Commons.OpenInputForm(new uc_StoreDetail(this, item), "Cập Nhật Cửa Hàng", "Update Store", new Size(660, 400));
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteStore();
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
            Commons.OpenImportForm("PRO_Store_FileSelect.xlsx", "PRO_spfrmStoreImport", "PRO", "13");
            LoadAllData();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Commons.QuickExportData(gridStore, grvStore);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uc_Store_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void grvStore_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Info.IsRowIndicator)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvStore_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvStore_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvStore_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvStore_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            storeCodeList = "";
            storeIDList = "";
            foreach (int index in grvStore.GetSelectedRows())
            {
                storeCodeList += grvStore.GetRowCellDisplayText(index, gcolStoreCode) + "$";
                storeIDList += grvStore.GetRowCellDisplayText(index, gcolStoreID) + "$";
            }

            if (storeCodeList.Length > 0)
                storeCodeList = storeCodeList.Substring(0, storeCodeList.Length - 1);
            if (storeIDList.Length > 0)
                storeIDList = storeIDList.Substring(0, storeIDList.Length - 1);
        }
        #endregion
    }
}
