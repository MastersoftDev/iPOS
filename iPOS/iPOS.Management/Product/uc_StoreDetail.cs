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
using iPOS.BUS.Product;
using iPOS.BUS.System;
using iPOS.DTO.System;
using iPOS.Management.Common;
using iPOS.DTO.Product;

namespace iPOS.Management.Product
{
    public partial class uc_StoreDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        PRO_tblProvinceBUS busProvince;
        PRO_tblDistrictBUS busDistrict;
        PRO_tblStoreBUS busStore;
        SYS_tblPermissionBUS busPermission;
        SYS_tblPermissionDTO permission;
        uc_Store parentForm;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            string LanguageID = User.UserInfo.LanguageID;
            logDetail.Text = LanguageID.Equals("VN") ? "Thông Tin Cửa Hàng" : "Store Information";
            lciStoreCode.Text = LanguageID.Equals("VN") ? "Mã cửa hàng:" : "Store code:";
            lciShortCode.Text = LanguageID.Equals("VN") ? "Mã nội bộ:" : "Internal code:";
            lciVNName.Text = LanguageID.Equals("VN") ? "Tên cửa hàng VN:" : "VN Store name:";
            lciENName.Text = LanguageID.Equals("VN") ? "Tên cửa hàng EN:" : "EN Store name:";
            picPhoto.Properties.NullText = LanguageID.Equals("VN") ? "[Chọn ảnh logo]" : "[Choose logo picture]";
            lciBuildDate.Text = LanguageID.Equals("VN") ? "Ngày thành lập:" : "Date of establishment:";
            lciEndDate.Text = LanguageID.Equals("VN") ? "Ngày ngừng hoạt động:" : "Date of decommissioned:";
            lciAddressVN.Text = LanguageID.Equals("VN") ? "Địa chỉ VN:" : "VN Address:";
            lciAddressEN.Text = LanguageID.Equals("VN") ? "Địa chỉ EN:" : "EN Address:";
            lciProvince.Text = LanguageID.Equals("VN") ? "Tỉnh thành:" : "Province:";
            lciDistrict.Text = LanguageID.Equals("VN") ? "Quận huyện:" : "District:";
            gluProvince.Properties.NullText = LanguageID.Equals("VN") ? "[Chọn tỉnh thành]" : "[Choose province]";
            gluDistrict.Properties.NullText = LanguageID.Equals("VN") ? "[Chọn quận huyện]" : "[Choose district]";
            lciPhone.Text = LanguageID.Equals("VN") ? "Số điện thoại:" : "Phone:";
            lciFax.Text = LanguageID.Equals("VN") ? "Fax:" : "Fax:";
            lciTaxCode.Text = LanguageID.Equals("VN") ? "Mã số thuế:" : "Tax code:";
            lciRank.Text = LanguageID.Equals("VN") ? "Thứ tự:" : "Rank:";
            lciRepresentives.Text = LanguageID.Equals("VN") ? "Người đại diện:" : "Representative:";
            chkIsRoot.Text = LanguageID.Equals("VN") ? "Là cửa hàng chính?" : "Is the primary store?";
            chkUsed.Text = LanguageID.Equals("VN") ? "Đang hoạt động?" : "Are active?";
            lciNote.Text = LanguageID.Equals("VN") ? "Ghi chú:" : "Note:";
            btnSaveClose.Text = (LanguageID.Equals("VN")) ? "Lưu && Đóng" : "Save && Close";
            btnSaveInsert.Text = (LanguageID.Equals("VN")) ? "Lưu && Thêm" : "Save && Insert";
            btnCancel.Text = (LanguageID.Equals("VN")) ? "Hủy Bỏ" : "Cancel";
            dteBuildDate.EditValue = DateTime.Now;

            busProvince = new PRO_tblProvinceBUS();
            busDistrict = new PRO_tblDistrictBUS();
            busPermission = new SYS_tblPermissionBUS();
            busStore = new PRO_tblStoreBUS();
            LoadProvince();
        }

        private void SetPermission()
        {
            permission = busPermission.GetPermissionByFunction(User.UserInfo.Username, User.UserInfo.LanguageID, "13", User.UserInfo.Username);
            if (txtStoreID.Text.Equals(""))
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

        private void LoadDataToEdit(PRO_tblStoreDTO item)
        {
            txtStoreID.EditValue = (item == null) ? null : item.StoreID;
            txtStoreCode.EditValue = (item == null) ? null : item.StoreCode;
            txtShortCode.EditValue = (item == null) ? null : item.ShortCode;
            txtVNName.EditValue = (item == null) ? null : item.VNName;
            txtENName.EditValue = (item == null) ? null : item.ENName;
            dteBuildDate.EditValue = (item == null) ? null : item.BuildDate;
            dteEndDate.EditValue = (item == null) ? null : item.EndDate;
            picPhoto.EditValue = (item == null) ? null : item.Photo;
            txtAddressVN.EditValue = (item == null) ? null : item.AddressVN;
            txtAddressEN.EditValue = (item == null) ? null : item.AddressEN;
            gluProvince.EditValue = (item == null) ? null : item.ProvinceID;
            gluDistrict.EditValue = (item == null) ? null : item.DistrictID;
            txtPhone.EditValue = (item == null) ? null : item.Phone;
            txtFax.EditValue = (item == null) ? null : item.Fax;
            txtTaxCode.EditValue = (item == null) ? null : item.TaxCode;
            speRank.EditValue = (item == null) ? null : item.Rank;
            txtRepresentives.EditValue = (item == null) ? null : item.Representatives;
            chkIsRoot.Checked = (item == null) ? false : item.IsRoot;
            chkUsed.Checked = (item == null) ? true : item.Used;
            mmoNote.EditValue = (item == null) ? null : item.Note;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = (User.UserInfo.LanguageID.Equals("VN")) ? "Thêm Mới Cửa Hàng" : "Insert New Store";
            }
            txtStoreCode.Focus();
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
            if (txtStoreCode.Text.Equals(""))
            {
                depError.SetError(txtStoreCode, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
                txtStoreCode.Focus();
                return false;
            }
            if (txtStoreCode.Text.Contains(" "))
            {
                depError.SetError(txtStoreCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
                txtStoreCode.Focus();
                return false;
            }
            if (txtShortCode.Text.Equals(""))
            {
                depError.SetError(txtShortCode, Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage));
                txtShortCode.Focus();
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

            return true;
        }

        private bool SaveStore(bool isEdit)
        {
            string strError = "";
            try
            {
                PRO_tblStoreDTO item = new PRO_tblStoreDTO
                {
                    Activity = (isEdit) ? "Update" : "Insert",
                    Username = User.UserInfo.Username,
                    LanguageID = User.UserInfo.LanguageID,
                    StoreID = txtStoreID.Text,
                    StoreCode = txtStoreCode.Text,
                    ShortCode = txtShortCode.Text,
                    VNName = txtVNName.Text,
                    ENName = txtENName.Text,
                    BuildDate = dteBuildDate.EditValue,
                    EndDate = dteEndDate.EditValue,
                    AddressVN = txtAddressVN.Text,
                    AddressEN = txtAddressEN.Text,
                    Phone = txtPhone.Text,
                    Fax = txtFax.Text,
                    Rank = speRank.EditValue,
                    TaxCode = txtTaxCode.Text,
                    Used = chkUsed.Checked,
                    IsRoot = chkIsRoot.Checked,
                    Representatives = txtRepresentives.Text,
                    Note = mmoNote.Text,
                    Photo = picPhoto.EditValue,
                    ProvinceID = gluProvince.EditValue + "",
                    DistrictID = gluDistrict.EditValue + ""
                };
                strError = (isEdit) ? busStore.UpdateStore(item) : busStore.InsertStore(item);
                if (strError != "")
                {
                    Commons.ShowMessage(strError, 0);
                    txtStoreCode.Focus();
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
        public uc_StoreDetail(uc_Store parent)
        {
            InitializeComponent();
            parentForm = parent;
            Initialize();
            SetPermission();
        }

        public uc_StoreDetail(uc_Store parent, PRO_tblStoreDTO item)
        {
            InitializeComponent();
            parentForm = parent;
            Initialize();
            LoadDataToEdit(item);
            SetPermission();
        }

        private void txtStoreCode_EditValueChanged(object sender, EventArgs e)
        {
            if (txtStoreCode.Text.Contains(" "))
                depError.SetError(txtStoreCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
            else depError.SetError(txtStoreCode, (string.IsNullOrEmpty(txtStoreCode.Text)) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void txtShortCode_EditValueChanged(object sender, EventArgs e)
        {
            if (txtShortCode.Text.Contains(" "))
                depError.SetError(txtShortCode, Lang.GetMessageByLanguage("000004", Commons.Culture, Commons.ResourceMessage));
            else depError.SetError(txtShortCode, (string.IsNullOrEmpty(txtShortCode.Text)) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void txtShortCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtShortCode_Leave(object sender, EventArgs e)
        {
            if (txtShortCode.Text.Length < 3)
                txtShortCode.Text = txtShortCode.Text.PadLeft(3, '0');
        }

        private void txtVNName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtVNName, (txtVNName.Text.Trim().Equals("")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void txtENName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtENName, (txtENName.Text.Trim().Equals("")) ? Lang.GetMessageByLanguage("000003", Commons.Culture, Commons.ResourceMessage) : null);
        }

        private void gluProvince_EditValueChanged(object sender, EventArgs e)
        {
            LoadDistrictByProvince(gluProvince.EditValue + "");
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (SaveStore(txtStoreID.Text.Equals("") ? false : true))
                    this.ParentForm.Close();
        }

        private void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (SaveStore(txtStoreID.Text.Equals("") ? false : true))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
