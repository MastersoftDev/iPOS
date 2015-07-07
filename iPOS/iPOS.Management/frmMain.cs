using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Commons = iPOS.Management.Common.Common;
using iPOS.Management.Product;

namespace iPOS.Management
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGroupUserList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Commons.OpenForm(this, new uc_GroupUser(), "Nhóm Người Dùng", "Group User", tabMain);
        }

        private void btnUserList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Commons.OpenForm(this, new uc_User(), "Người Dùng", "User", tabMain);
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            Commons.OpenInputForm(new uc_ChangePassword(), "Đổi Mật Khẩu Người Dùng", "Change User Password", new System.Drawing.Size(400, 225));
        }

        private void btnPermission_ItemClick(object sender, ItemClickEventArgs e)
        {
            Commons.OpenForm(this, new uc_UserPermission(), "Phân Quyền Dữ Liệu", "User Permission", tabMain);
        }

        private void btnProvince_ItemClick(object sender, ItemClickEventArgs e)
        {
            Commons.OpenForm(this, new uc_Province(), "Tỉnh Thành", "Province", tabMain);
        }

        private void btnDistrict_ItemClick(object sender, ItemClickEventArgs e)
        {
            Commons.OpenForm(this, new uc_District(), "Quận Huyện", "District", tabMain);
        }

        private void btnStore_ItemClick(object sender, ItemClickEventArgs e)
        {
            Commons.OpenForm(this, new uc_Store(), "Cửa Hàng", "Store", tabMain);
        }

        private void btnWarehouse_ItemClick(object sender, ItemClickEventArgs e)
        {
            Commons.OpenForm(this, new uc_Warehouse(), "Kho Hàng", "Warehouse", tabMain);
        }

        private void btnStall_ItemClick(object sender, ItemClickEventArgs e)
        {
            Commons.OpenForm(this, new uc_Stall(), "Quầy Bán Hàng", "Stall", tabMain);
        }

        private void btnLevel1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Commons.OpenForm(this, new uc_Level1(), "Ngành Hàng", "Product Sector", tabMain);
        }
    }
}