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
    public partial class uc_Province : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        PRO_tblProvinceBUS busProvince;
        DataRowView curRow;
        string provinceCodeList = "", provinceIDList = "";
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

            grvProvince.GroupPanelText = (Language.Equals("VN")) ? "Kéo một tiêu đề cột vào đây để nhóm theo cột đó" : "Drag a column header here to group by that column";
            gcolProvinceCode.Caption = (Language.Equals("VN")) ? "Mã tỉnh thành" : "Province code";
            gcolProvinceName.Caption = (Language.Equals("VN")) ? "Tên tỉnh thành" : "Province name";
            gcolRank.Caption = (Language.Equals("VN")) ? "Thứ tự" : "Rank";
            gcolUsedString.Caption = (Language.Equals("VN")) ? "Sử dụng?" : "Is used?";
            gcolNote.Caption = (Language.Equals("VN")) ? "Ghi chú" : "Note";

            busProvince = new PRO_tblProvinceBUS();
            busPermission = new SYS_tblPermissionBUS();
        }

        private void SetPermission()
        {
            permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "8", User.UserInfo.Username);
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
                dt = busProvince.LoadAllData(User.UserInfo.Username, User.UserInfo.LanguageID);
                gridProvince.DataBindings.Clear();
                gridProvince.DataSource = dt;
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
                curRow = (DataRowView)grvProvince.GetFocusedRow();
                if (curRow != null)
                    Commons.SetDislayStringArray(new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime }, new string[] { curRow["Creater"].ToString(), curRow["CreateTime"].ToString(), curRow["Editer"].ToString(), curRow["EditTime"].ToString() });
            }
            catch (Exception ex)
            {
                Commons.ShowExceptionMessage(ex);
            }
        }

        private void DeleteProvince()
        {
            string strError = "";
            if (provinceIDList.Contains("$"))
            {
                if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000012", Commons.Culture, Commons.ResourceMessage).Replace("$Count$", provinceIDList.Split('$').Length.ToString())))
                    strError = busProvince.DeleteListProvince(provinceIDList, provinceCodeList, User.UserInfo.Username, User.UserInfo.LanguageID);
            }
            else
            {
                if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000005", Commons.Culture, Commons.ResourceMessage)))
                    strError = busProvince.DeleteProvince(provinceIDList, provinceCodeList, User.UserInfo.Username, User.UserInfo.LanguageID);
            }

            if (strError.Equals("")) LoadAllData();
            else Commons.ShowMessage(strError, 0);
        }
        #endregion

        public uc_Province()
        {
            InitializeComponent();
            Initialize();
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Commons.OpenInputForm(new uc_ProvinceDetail(this), "Thêm Mới Tỉnh Thành", "Insert New Province", new Size(435, 265));
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curRow != null)
            {
                PRO_tblProvinceDTO item = busProvince.GetDataByID(curRow["ProvinceID"] + "", User.UserInfo.Username, User.UserInfo.LanguageID);
                if (item != null)
                    Commons.OpenInputForm(new uc_ProvinceDetail(this, item), "Cập Nhật Tỉnh Thành", "Update Province", new Size(435, 265));
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteProvince();
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
            Commons.OpenImportForm("PRO_Province_FileSelect.xlsx", "PRO_spfrmProvinceImport", "PRO", "8");
            LoadAllData();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Commons.QuickExportData(gridProvince, grvProvince);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uc_Province_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void grvProvince_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Info.IsRowIndicator)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvProvince_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvProvince_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvProvince_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvProvince_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            provinceCodeList = "";
            provinceIDList = "";
            foreach (int index in grvProvince.GetSelectedRows())
            {
                provinceCodeList += grvProvince.GetRowCellDisplayText(index, gcolProvinceCode) + "$";
                provinceIDList += grvProvince.GetRowCellDisplayText(index, gcolProvinceID) + "$";
            }

            if (provinceCodeList.Length > 0)
                provinceCodeList = provinceCodeList.Substring(0, provinceCodeList.Length - 1);
            if (provinceIDList.Length > 0)
                provinceIDList = provinceIDList.Substring(0, provinceIDList.Length - 1);
        }
    }
}
