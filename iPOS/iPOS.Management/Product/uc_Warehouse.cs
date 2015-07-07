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
using iPOS.DTO.Product;
using iPOS.Core.Helper;

namespace iPOS.Management.Product
{
    public partial class uc_Warehouse : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        PRO_tblWarehouseBUS busWarehouse;
        DataRowView curRow;
        string warehouseCodeList = "", warehouseIDList = "";
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

            grvWarehouse.GroupPanelText = (Language.Equals("VN")) ? "Kéo một tiêu đề cột vào đây để nhóm theo cột đó" : "Drag a column header here to group by that column";
            gcolWarehouseCode.Caption = Language.Equals("VN") ? "Mã kho hàng" : "Warehouse code";
            gcolWarehouseName.Caption = Language.Equals("VN") ? "Tên kho hàng" : "Warehouse name";
            gcolWarehouseAddress.Caption = Language.Equals("VN") ? "Địa chỉ kho hàng" : "Warehouse address";
            gcolPhone.Caption = Language.Equals("VN") ? "Số điện thoại" : "Phone";
            gcolRank.Caption = Language.Equals("VN") ? "Thứ tự" : "Rank";
            gcolUsedString.Caption = Language.Equals("VN") ? "Đang hoạt động?" : "Are active?";
            gcolNote.Caption = Language.Equals("VN") ? "Ghi chú" : "Note";
            gcolProvinceName.Caption = Language.Equals("VN") ? "Tỉnh thành" : "Province name";
            gcolDistrictName.Caption = Language.Equals("VN") ? "Quận huyện" : "Distict name";
            gcolStoreName.Caption = Language.Equals("VN") ? "Cửa hàng" : "Store";

            busWarehouse = new PRO_tblWarehouseBUS();
            busPermission = new SYS_tblPermissionBUS();
        }

        private void SetPermission()
        {
            permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "18", User.UserInfo.Username);
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
                dt = busWarehouse.LoadAllData(User.UserInfo.Username, User.UserInfo.LanguageID);
                gridWarehouse.DataBindings.Clear();
                gridWarehouse.DataSource = dt;
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
                curRow = (DataRowView)grvWarehouse.GetFocusedRow();
                if (curRow != null)
                    Commons.SetDislayStringArray(new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime }, new string[] { curRow["Creater"].ToString(), curRow["CreateTime"].ToString(), curRow["Editer"].ToString(), curRow["EditTime"].ToString() });
            }
            catch (Exception ex)
            {
                Commons.ShowExceptionMessage(ex);
            }
        }

        private void DeleteWarehouse()
        {
            string strError = "";
            if (warehouseIDList.Contains("$"))
            {
                if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000012", Commons.Culture, Commons.ResourceMessage).Replace("$Count$", warehouseIDList.Split('$').Length.ToString())))
                    strError = busWarehouse.DeleteListWarehouse(warehouseIDList, warehouseIDList, User.UserInfo.Username, User.UserInfo.LanguageID);
            }
            else
            {
                if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000005", Commons.Culture, Commons.ResourceMessage)))
                    strError = busWarehouse.DeleteWarehouse(warehouseIDList, warehouseIDList, User.UserInfo.Username, User.UserInfo.LanguageID);
            }

            if (strError.Equals("")) LoadAllData();
            else Commons.ShowMessage(strError, 0);
        }
        #endregion

        #region [Form Events]
        public uc_Warehouse()
        {
            InitializeComponent();
            Initialize();
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Commons.OpenInputForm(new uc_WarehouseDetail(this), "Thêm Mới Kho Hàng", "Insert New Warehouse", new Size(410, 400));
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curRow != null)
            {
                PRO_tblWarehouseDTO item = busWarehouse.GetDataByID(curRow["StoreID"] + "", User.UserInfo.Username, User.UserInfo.LanguageID);
                if (item != null)
                    Commons.OpenInputForm(new uc_WarehouseDetail(this, item), "Cập Nhật Kho Hàng", "Update Warehouse", new Size(410, 400));
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteWarehouse();
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
            Commons.OpenImportForm("PRO_Warehouse_FileSelect.xlsx", "PRO_spfrmWarehouseImport", "PRO", "18");
            LoadAllData();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Commons.QuickExportData(gridWarehouse, grvWarehouse);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uc_Warehouse_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void grvWarehouse_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Info.IsRowIndicator)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvWarehouse_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvWarehouse_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvWarehouse_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvWarehouse_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            warehouseCodeList = "";
            warehouseIDList = "";
            foreach (int index in grvWarehouse.GetSelectedRows())
            {
                warehouseCodeList += grvWarehouse.GetRowCellDisplayText(index, gcolWarehouseCode) + "$";
                warehouseIDList += grvWarehouse.GetRowCellDisplayText(index, gcolWarehouseID) + "$";
            }

            if (warehouseCodeList.Length > 0)
                warehouseCodeList = warehouseCodeList.Substring(0, warehouseCodeList.Length - 1);
            if (warehouseIDList.Length > 0)
                warehouseIDList = warehouseIDList.Substring(0, warehouseIDList.Length - 1);
        }
        #endregion
    }
}
