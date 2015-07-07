using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.BUS.Product;
using iPOS.BUS.System;
using iPOS.DTO.System;
using Commons = iPOS.Management.Common.Common;
using iPOS.Management.Common;
using iPOS.DTO.Product;
using iPOS.Core.Helper;

namespace iPOS.Management.Product
{
    public partial class uc_WarehouseDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        PRO_tblProvinceBUS busProvince;
        PRO_tblDistrictBUS busDistrict;
        PRO_tblStoreBUS busStore;
        PRO_tblWarehouseBUS busWarehouse;
        SYS_tblPermissionBUS busPermission;
        SYS_tblPermissionDTO permission;
        uc_Warehouse parentForm;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            string LanguageID = User.UserInfo.LanguageID;
            logDetail.Text = LanguageID.Equals("VN") ? "Thông Tin Kho Hàng" : "Warehouse Information";
            lciWarehouseCode.Text = LanguageID.Equals("VN") ? "Mã kho hàng:" : "Warehouse code:";
            lciVNName.Text = LanguageID.Equals("VN") ? "Tên kho hàng VN:" : "VN Warehouse name:";
            lciENName.Text = LanguageID.Equals("VN") ? "Tên kho hàng EN:" : "EN Warehouse name:";
            lciStore.Text = LanguageID.Equals("VN") ? "Cửa hàng:" : "Store:";
            gluStore.Properties.NullText = LanguageID.Equals("VN") ? "[Chọn cửa hàng]" : "[Choose store]";
            lciAddressVN.Text = LanguageID.Equals("VN") ? "Địa chỉ VN:" : "VN Address:";
            lciAddressEN.Text = LanguageID.Equals("VN") ? "Địa chỉ EN:" : "EN Address:";
            lciProvince.Text = LanguageID.Equals("VN") ? "Tỉnh thành:" : "Province:";
            lciDistrict.Text = LanguageID.Equals("VN") ? "Quận huyện:" : "District:";
            gluProvince.Properties.NullText = LanguageID.Equals("VN") ? "[Chọn tỉnh thành]" : "[Choose province]";
            gluDistrict.Properties.NullText = LanguageID.Equals("VN") ? "[Chọn quận huyện]" : "[Choose district]";
            lciPhone.Text = LanguageID.Equals("VN") ? "Số điện thoại:" : "Phone:";
            lciFax.Text = LanguageID.Equals("VN") ? "Fax:" : "Fax:";
            lciRank.Text = LanguageID.Equals("VN") ? "Thứ tự:" : "Rank:";
            chkUsed.Text = LanguageID.Equals("VN") ? "Đang hoạt động?" : "Are active?";
            lciNote.Text = LanguageID.Equals("VN") ? "Ghi chú:" : "Note:";
            btnSaveClose.Text = (LanguageID.Equals("VN")) ? "Lưu && Đóng" : "Save && Close";
            btnSaveInsert.Text = (LanguageID.Equals("VN")) ? "Lưu && Thêm" : "Save && Insert";
            btnCancel.Text = (LanguageID.Equals("VN")) ? "Hủy Bỏ" : "Cancel";

            busProvince = new PRO_tblProvinceBUS();
            busDistrict = new PRO_tblDistrictBUS();
            busStore = new PRO_tblStoreBUS();
            busPermission = new SYS_tblPermissionBUS();
            busWarehouse = new PRO_tblWarehouseBUS();
            LoadStore();
            LoadProvince();
        }

        private void SetPermission()
        {
            permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "18", User.UserInfo.Username);
            if (txtWarehouseID.Text.Equals(""))
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

        private void LoadDataToEdit(PRO_tblWarehouseDTO item)
        {
            txtWarehouseID.EditValue = (item == null) ? null : item.WarehouseID;
            txtWarehouseCode.EditValue = (item == null) ? null : item.WarehouseCode;
            txtVNName.EditValue = (item == null) ? null : item.VNName;
            txtENName.EditValue = (item == null) ? null : item.ENName;
            txtAddressVN.EditValue = (item == null) ? null : item.AddressVN;
            txtAddressEN.EditValue = (item == null) ? null : item.AddressEN;
            txtPhone.EditValue = (item == null) ? null : item.Phone;
            txtFax.EditValue = (item == null) ? null : item.Fax;
            gluStore.EditValue = (item == null) ? null : item.StoreID;
            mmoNote.EditValue = (item == null) ? null : item.Note;
            speRank.EditValue = (item == null) ? null : item.Rank;
            chkUsed.Checked = (item == null) ? true : item.Used;
            gluProvince.EditValue = (item == null) ? null : item.ProvinceID;
            gluDistrict.EditValue = (item == null) ? null : item.DistrictID;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = (User.UserInfo.LanguageID.Equals("VN")) ? "Thêm Mới Kho Hàng" : "Insert New Warehouse";
            }
            txtWarehouseCode.Focus();
        }

        private void LoadStore()
        {
            DataTable dt = busStore.GetDataCombobox(User.UserInfo.Username, User.UserInfo.LanguageID);
            if (dt != null && dt.Rows.Count > 0)
            {
                gluStore.DataBindings.Clear();
                gluStore.Properties.DataSource = dt;
                gluStore.Properties.ValueMember = "StoreID";
                gluStore.Properties.DisplayMember = "FullStoreName";
            }
        }

        private void LoadProvince()
        {
            DataTable dt = busProvince.GetDataCombobox(User.UserInfo.Username, User.UserInfo.LanguageID);
            if (dt != null && dt.Rows.Count > 0)
            {
                gluProvince.DataBindings.Clear();
                gluProvince.Properties.DataSource = dt;
                gluProvince.Properties.ValueMember = "ProvinceID";
                gluProvince.Properties.DisplayMember = "FullProvinceName";
            }
        }

        private void LoadDistrictByProvince(string province_id)
        {
            DataTable dt = busDistrict.GetDataCombobox(User.UserInfo.Username, User.UserInfo.LanguageID, province_id);
            if (dt != null && dt.Rows.Count > 0)
            {
                gluDistrict.DataBindings.Clear();
                gluDistrict.Properties.DataSource = dt;
                gluDistrict.Properties.ValueMember = "DistrictID";
                gluDistrict.Properties.DisplayMember = "FullDistrictName";
            }
        }

        private bool CheckValidate()
        {
            if (txtWarehouseCode.Text.Equals(""))
            {
                depError.SetError(txtWarehouseCode, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
                txtWarehouseCode.Focus();
                return false;
            }
            if (txtWarehouseCode.Text.Contains(" "))
            {
                depError.SetError(txtWarehouseCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
                txtWarehouseCode.Focus();
                return false;
            }
            if (txtVNName.Text.Equals(""))
            {
                depError.SetError(txtVNName, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
                txtVNName.Focus();
                return false;
            }
            if (txtENName.Text.Equals(""))
            {
                depError.SetError(txtENName, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
                txtENName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(gluStore.EditValue + ""))
            {
                depError.SetError(gluStore, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
                gluStore.Focus();
                gluStore.ShowPopup();
                return false;
            }

            return true;
        }

        private bool SaveWarehouse(bool isEdit)
        {
            string strError = "";
            try
            {
                PRO_tblWarehouseDTO item = new PRO_tblWarehouseDTO
                {
                    Activity = (isEdit) ? "Update" : "Insert",
                    Username = User.UserInfo.Username,
                    LanguageID = User.UserInfo.LanguageID,
                    WarehouseID = txtWarehouseID.Text,
                    WarehouseCode = txtWarehouseCode.Text,
                    VNName = txtVNName.Text,
                    ENName = txtENName.Text,
                    StoreID = gluStore.EditValue + "",
                    AddressVN = txtAddressVN.Text,
                    AddressEN = txtAddressEN.Text,
                    Phone = txtPhone.Text,
                    Fax = txtFax.Text,
                    ProvinceID = gluProvince.EditValue + "",
                    DistrictID = gluDistrict.EditValue + "",
                    Rank = speRank.EditValue,
                    Used = chkUsed.Checked,
                    Note = mmoNote.Text
                };
                strError = (isEdit) ? busWarehouse.UpdateWarehouse(item) : busWarehouse.InsertWarehouse(item);
                if (strError != "")
                {
                    Commons.ShowMessage(strError, 0);
                    txtWarehouseCode.Focus();
                    return false;
                }
                else parentForm.LoadAllData();
            }
            catch (Exception ex)
            {
                Commons.ShowExceptionMessage(ex);
                return false;
            }

            return true;
        }
        #endregion

        #region [Form Events]
        public uc_WarehouseDetail(uc_Warehouse parent)
        {
            InitializeComponent();
            parentForm = parent;
            Initialize();
            SetPermission();
        }

        public uc_WarehouseDetail(uc_Warehouse parent, PRO_tblWarehouseDTO item)
        {
            InitializeComponent();
            parentForm = parent;
            Initialize();
            LoadDataToEdit(item);
            SetPermission();
        }

        private void txtWarehouseCode_EditValueChanged(object sender, EventArgs e)
        {
            if (txtWarehouseCode.Text.Contains(" "))
                depError.SetError(txtWarehouseCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
            else depError.SetError(txtWarehouseCode, (string.IsNullOrEmpty(txtWarehouseCode.Text)) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void txtVNName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtVNName, (txtVNName.Text.Trim().Equals("")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void txtENName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtENName, (txtENName.Text.Trim().Equals("")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void gluStore_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(gluStore, (string.IsNullOrEmpty(gluStore.EditValue + "")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void gluProvince_EditValueChanged(object sender, EventArgs e)
        {
            LoadDistrictByProvince(gluProvince.EditValue + "");
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (SaveWarehouse(txtWarehouseID.Text.Equals("") ? false : true))
                    this.ParentForm.Close();
        }

        private void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (SaveWarehouse(txtWarehouseID.Text.Equals("") ? false : true))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
