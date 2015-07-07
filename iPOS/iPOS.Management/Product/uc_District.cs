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
    public partial class uc_District : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        PRO_tblDistrictBUS busDistrict;
        DataRowView curRow;
        string districtCodeList = "", districtIDList = "";
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

            grvDistrict.GroupPanelText = (Language.Equals("VN")) ? "Kéo một tiêu đề cột vào đây để nhóm theo cột đó" : "Drag a column header here to group by that column";
            gcolDistrictCode.Caption = (Language.Equals("VN")) ? "Mã quận huyện" : "District code";
            gcolProvinceName.Caption = (Language.Equals("VN")) ? "Tỉnh thành" : "Province name";
            gcolDistrictName.Caption = (Language.Equals("VN")) ? "Tên quận huyện" : "District name";
            gcolRank.Caption = (Language.Equals("VN")) ? "Thứ tự" : "Rank";
            gcolUsedString.Caption = (Language.Equals("VN")) ? "Sử dụng?" : "Is used?";
            gcolNote.Caption = (Language.Equals("VN")) ? "Ghi chú" : "Note";

            busDistrict = new PRO_tblDistrictBUS();
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
                dt = busDistrict.LoadAllData(User.UserInfo.Username, User.UserInfo.LanguageID);
                gridDistrict.DataBindings.Clear();
                gridDistrict.DataSource = dt;
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
                curRow = (DataRowView)grvDistrict.GetFocusedRow();
                if (curRow != null)
                    Commons.SetDislayStringArray(new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime }, new string[] { curRow["Creater"].ToString(), curRow["CreateTime"].ToString(), curRow["Editer"].ToString(), curRow["EditTime"].ToString() });
            }
            catch (Exception ex)
            {
                Commons.ShowExceptionMessage(ex);
            }
        }

        private void DeleteDistrict()
        {
            string strError = "";
            if (districtIDList.Contains("$"))
            {
                if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000012", Commons.Culture, Commons.ResourceMessage).Replace("$Count$", districtIDList.Split('$').Length.ToString())))
                    strError = busDistrict.DeleteListDistrict(districtIDList, districtCodeList, User.UserInfo.Username, User.UserInfo.LanguageID);
            }
            else
            {
                if (Commons.ShowConfirmMessage(Lang.GetMessageByLanguage("000005", Commons.Culture, Commons.ResourceMessage)))
                    strError = busDistrict.DeleteDistrict(districtIDList, districtCodeList, User.UserInfo.Username, User.UserInfo.LanguageID);
            }

            if (strError.Equals("")) LoadAllData();
            else Commons.ShowMessage(strError, 0);
        }
        #endregion

        #region [Form Events]
        public uc_District()
        {
            InitializeComponent();
            Initialize();
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Commons.OpenInputForm(new uc_DistrictDetail(this), "Thêm Mới Quận Huyện", "Insert New District", new Size(435, 270));
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curRow != null)
            {
                PRO_tblDistrictDTO item = busDistrict.GetDataByID(curRow["DistrictID"] + "", User.UserInfo.Username, User.UserInfo.LanguageID);
                if (item != null)
                    Commons.OpenInputForm(new uc_DistrictDetail(this, item), "Cập Nhật Quận Huyện", "Update District", new Size(435, 270));
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteDistrict();
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

            Commons.OpenImportForm("PRO_District_FileSelect.xlsx", "PRO_spfrmDistrictImport", "PRO", "12");
            LoadAllData();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Commons.QuickExportData(gridDistrict, grvDistrict);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uc_District_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void grvDistrict_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Info.IsRowIndicator)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvDistrict_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvDistrict_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvDistrict_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvDistrict_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            districtCodeList = "";
            districtIDList = "";
            foreach (int index in grvDistrict.GetSelectedRows())
            {
                districtCodeList += grvDistrict.GetRowCellDisplayText(index, gcolDistrictCode) + "$";
                districtIDList += grvDistrict.GetRowCellDisplayText(index, gcolDistrictID) + "$";
            }

            if (districtCodeList.Length > 0)
                districtCodeList = districtCodeList.Substring(0, districtCodeList.Length - 1);
            if (districtIDList.Length > 0)
                districtIDList = districtIDList.Substring(0, districtIDList.Length - 1);
        }
        #endregion
    }
}
