namespace iPOS.Management
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.btnShutdown = new DevExpress.XtraBars.BarButtonItem();
            this.btnLockScreen = new DevExpress.XtraBars.BarButtonItem();
            this.btnGroupUserList = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserList = new DevExpress.XtraBars.BarButtonItem();
            this.btnPermission = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestart = new DevExpress.XtraBars.BarButtonItem();
            this.btnStore = new DevExpress.XtraBars.BarButtonItem();
            this.btnWarehouse = new DevExpress.XtraBars.BarButtonItem();
            this.btnStall = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            this.btnLevel1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
            this.btnProvince = new DevExpress.XtraBars.BarButtonItem();
            this.btnDistrict = new DevExpress.XtraBars.BarButtonItem();
            this.ribSystemModule = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribSystemPage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribUserPermissionPage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribProductModule = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribStorePage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribProductPage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribProviderUnit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribProvincePage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tabMain = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbon.ApplicationIcon = global::iPOS.Management.Properties.Resources.logo;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnShutdown,
            this.btnLockScreen,
            this.btnGroupUserList,
            this.btnUserList,
            this.btnPermission,
            this.barButtonItem6,
            this.barButtonItem7,
            this.btnChangePassword,
            this.barButtonItem9,
            this.barButtonItem10,
            this.btnRestart,
            this.btnStore,
            this.btnWarehouse,
            this.btnStall,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem8,
            this.barButtonItem11,
            this.barButtonItem12,
            this.btnLevel1,
            this.barButtonItem14,
            this.barButtonItem15,
            this.btnProvince,
            this.btnDistrict});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 30;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribSystemModule,
            this.ribProductModule});
            this.ribbon.Size = new System.Drawing.Size(1266, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.barButtonItem9);
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbon;
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "Đổi Mật Khẩu";
            this.barButtonItem9.Id = 9;
            this.barButtonItem9.LargeGlyph = global::iPOS.Management.Properties.Resources.change_password_32;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // btnShutdown
            // 
            this.btnShutdown.Caption = "Đăng Xuất";
            this.btnShutdown.Id = 1;
            this.btnShutdown.LargeGlyph = global::iPOS.Management.Properties.Resources.shutdown_32;
            this.btnShutdown.LargeWidth = 70;
            this.btnShutdown.Name = "btnShutdown";
            // 
            // btnLockScreen
            // 
            this.btnLockScreen.Caption = "Tạm Khóa Màn Hình";
            this.btnLockScreen.Id = 2;
            this.btnLockScreen.LargeGlyph = global::iPOS.Management.Properties.Resources.lockscreen_32;
            this.btnLockScreen.LargeWidth = 70;
            this.btnLockScreen.Name = "btnLockScreen";
            // 
            // btnGroupUserList
            // 
            this.btnGroupUserList.Caption = "Nhóm Người Dùng";
            this.btnGroupUserList.Id = 3;
            this.btnGroupUserList.LargeGlyph = global::iPOS.Management.Properties.Resources.group_user_32;
            this.btnGroupUserList.LargeWidth = 70;
            this.btnGroupUserList.Name = "btnGroupUserList";
            this.btnGroupUserList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGroupUserList_ItemClick);
            // 
            // btnUserList
            // 
            this.btnUserList.Caption = "Người Dùng";
            this.btnUserList.Id = 4;
            this.btnUserList.LargeGlyph = global::iPOS.Management.Properties.Resources.user_32;
            this.btnUserList.LargeWidth = 70;
            this.btnUserList.Name = "btnUserList";
            this.btnUserList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUserList_ItemClick);
            // 
            // btnPermission
            // 
            this.btnPermission.Caption = "Phân Quyền Dữ Liệu";
            this.btnPermission.Id = 5;
            this.btnPermission.LargeGlyph = global::iPOS.Management.Properties.Resources.permission_32;
            this.btnPermission.LargeWidth = 75;
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPermission_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Sao Lưu Dữ Liệu";
            this.barButtonItem6.Id = 6;
            this.barButtonItem6.LargeGlyph = global::iPOS.Management.Properties.Resources.backup_database_32;
            this.barButtonItem6.LargeWidth = 70;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Phục Hồi Dữ Liệu";
            this.barButtonItem7.Id = 7;
            this.barButtonItem7.LargeGlyph = global::iPOS.Management.Properties.Resources.restore_database_32;
            this.barButtonItem7.LargeWidth = 70;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Caption = "Đổi Mật Khẩu";
            this.btnChangePassword.Id = 8;
            this.btnChangePassword.LargeGlyph = global::iPOS.Management.Properties.Resources.change_password_32;
            this.btnChangePassword.LargeWidth = 70;
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangePassword_ItemClick);
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "Tinh Chỉnh Dữ Liệu";
            this.barButtonItem10.Id = 10;
            this.barButtonItem10.LargeGlyph = global::iPOS.Management.Properties.Resources.refine_database_32;
            this.barButtonItem10.LargeWidth = 70;
            this.barButtonItem10.Name = "barButtonItem10";
            // 
            // btnRestart
            // 
            this.btnRestart.Caption = "Khởi Động Lại";
            this.btnRestart.Id = 14;
            this.btnRestart.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRestart.LargeGlyph")));
            this.btnRestart.LargeWidth = 70;
            this.btnRestart.Name = "btnRestart";
            // 
            // btnStore
            // 
            this.btnStore.Caption = "Cửa Hàng";
            this.btnStore.Id = 15;
            this.btnStore.LargeGlyph = global::iPOS.Management.Properties.Resources.shop_32;
            this.btnStore.LargeWidth = 70;
            this.btnStore.Name = "btnStore";
            this.btnStore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStore_ItemClick);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.Caption = "Kho Hàng";
            this.btnWarehouse.Id = 16;
            this.btnWarehouse.LargeGlyph = global::iPOS.Management.Properties.Resources.inventory_32;
            this.btnWarehouse.LargeWidth = 70;
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWarehouse_ItemClick);
            // 
            // btnStall
            // 
            this.btnStall.Caption = "Quầy Bán Hàng";
            this.btnStall.Id = 17;
            this.btnStall.LargeGlyph = global::iPOS.Management.Properties.Resources.cashier_32;
            this.btnStall.LargeWidth = 70;
            this.btnStall.Name = "btnStall";
            this.btnStall.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStall_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Cửa Hàng Chính";
            this.barButtonItem4.Glyph = global::iPOS.Management.Properties.Resources.shop_16;
            this.barButtonItem4.Id = 18;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Nhà Cung Cấp";
            this.barButtonItem5.Id = 19;
            this.barButtonItem5.LargeGlyph = global::iPOS.Management.Properties.Resources.providers_32;
            this.barButtonItem5.LargeWidth = 70;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Đơn Vị Tính";
            this.barButtonItem8.Id = 20;
            this.barButtonItem8.LargeGlyph = global::iPOS.Management.Properties.Resources.units_32;
            this.barButtonItem8.LargeWidth = 70;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "Phương Thức Nhập Xuất";
            this.barButtonItem11.Id = 21;
            this.barButtonItem11.LargeGlyph = global::iPOS.Management.Properties.Resources.import_export_method_32;
            this.barButtonItem11.LargeWidth = 80;
            this.barButtonItem11.Name = "barButtonItem11";
            // 
            // barButtonItem12
            // 
            this.barButtonItem12.Caption = "Hàng Hóa";
            this.barButtonItem12.Id = 22;
            this.barButtonItem12.LargeGlyph = global::iPOS.Management.Properties.Resources.product_32;
            this.barButtonItem12.LargeWidth = 70;
            this.barButtonItem12.Name = "barButtonItem12";
            // 
            // btnLevel1
            // 
            this.btnLevel1.Caption = "Ngành Hàng";
            this.btnLevel1.Id = 23;
            this.btnLevel1.LargeGlyph = global::iPOS.Management.Properties.Resources.level1_32;
            this.btnLevel1.LargeWidth = 70;
            this.btnLevel1.Name = "btnLevel1";
            this.btnLevel1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLevel1_ItemClick);
            // 
            // barButtonItem14
            // 
            this.barButtonItem14.Caption = "Nhóm Hàng";
            this.barButtonItem14.Id = 24;
            this.barButtonItem14.LargeGlyph = global::iPOS.Management.Properties.Resources.level2_32;
            this.barButtonItem14.LargeWidth = 70;
            this.barButtonItem14.Name = "barButtonItem14";
            // 
            // barButtonItem15
            // 
            this.barButtonItem15.Caption = "Phân Nhóm Hàng";
            this.barButtonItem15.Id = 25;
            this.barButtonItem15.LargeGlyph = global::iPOS.Management.Properties.Resources.level3_32;
            this.barButtonItem15.LargeWidth = 70;
            this.barButtonItem15.Name = "barButtonItem15";
            // 
            // btnProvince
            // 
            this.btnProvince.Caption = "Tỉnh Thành";
            this.btnProvince.Id = 28;
            this.btnProvince.LargeGlyph = global::iPOS.Management.Properties.Resources.province_32;
            this.btnProvince.LargeWidth = 70;
            this.btnProvince.Name = "btnProvince";
            this.btnProvince.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProvince_ItemClick);
            // 
            // btnDistrict
            // 
            this.btnDistrict.Caption = "Quận Huyện";
            this.btnDistrict.Id = 29;
            this.btnDistrict.LargeGlyph = global::iPOS.Management.Properties.Resources.district_32;
            this.btnDistrict.LargeWidth = 70;
            this.btnDistrict.Name = "btnDistrict";
            this.btnDistrict.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDistrict_ItemClick);
            // 
            // ribSystemModule
            // 
            this.ribSystemModule.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribSystemPage,
            this.ribUserPermissionPage,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribSystemModule.Name = "ribSystemModule";
            this.ribSystemModule.Text = "Hệ Thống";
            // 
            // ribSystemPage
            // 
            this.ribSystemPage.ItemLinks.Add(this.btnShutdown);
            this.ribSystemPage.ItemLinks.Add(this.btnRestart);
            this.ribSystemPage.ItemLinks.Add(this.btnLockScreen, true);
            this.ribSystemPage.Name = "ribSystemPage";
            this.ribSystemPage.ShowCaptionButton = false;
            this.ribSystemPage.Text = "Hệ Thống";
            // 
            // ribUserPermissionPage
            // 
            this.ribUserPermissionPage.ItemLinks.Add(this.btnGroupUserList);
            this.ribUserPermissionPage.ItemLinks.Add(this.btnUserList);
            this.ribUserPermissionPage.ItemLinks.Add(this.btnPermission, true);
            this.ribUserPermissionPage.ItemLinks.Add(this.btnChangePassword);
            this.ribUserPermissionPage.Name = "ribUserPermissionPage";
            this.ribUserPermissionPage.ShowCaptionButton = false;
            this.ribUserPermissionPage.Text = "Người Dùng - Bảo Mật";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem10, true);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "Dữ Liệu";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "Cấu Hình";
            // 
            // ribProductModule
            // 
            this.ribProductModule.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribStorePage,
            this.ribProductPage,
            this.ribProviderUnit,
            this.ribProvincePage});
            this.ribProductModule.Name = "ribProductModule";
            this.ribProductModule.Text = "Hàng Hóa";
            // 
            // ribStorePage
            // 
            this.ribStorePage.ItemLinks.Add(this.btnStore);
            this.ribStorePage.ItemLinks.Add(this.btnWarehouse);
            this.ribStorePage.ItemLinks.Add(this.btnStall);
            this.ribStorePage.Name = "ribStorePage";
            this.ribStorePage.ShowCaptionButton = false;
            this.ribStorePage.Text = "Cửa Hàng - Kho Hàng";
            // 
            // ribProductPage
            // 
            this.ribProductPage.ItemLinks.Add(this.btnLevel1);
            this.ribProductPage.ItemLinks.Add(this.barButtonItem14);
            this.ribProductPage.ItemLinks.Add(this.barButtonItem15);
            this.ribProductPage.ItemLinks.Add(this.barButtonItem12, true);
            this.ribProductPage.Name = "ribProductPage";
            this.ribProductPage.ShowCaptionButton = false;
            this.ribProductPage.Text = "Hàng Hóa";
            // 
            // ribProviderUnit
            // 
            this.ribProviderUnit.ItemLinks.Add(this.barButtonItem5);
            this.ribProviderUnit.ItemLinks.Add(this.barButtonItem8, true);
            this.ribProviderUnit.Name = "ribProviderUnit";
            this.ribProviderUnit.ShowCaptionButton = false;
            this.ribProviderUnit.Text = "Nhà Cung Cấp - Đơn Vị Tính";
            // 
            // ribProvincePage
            // 
            this.ribProvincePage.ItemLinks.Add(this.btnProvince);
            this.ribProvincePage.ItemLinks.Add(this.btnDistrict);
            this.ribProvincePage.ItemLinks.Add(this.barButtonItem11, true);
            this.ribProvincePage.Name = "ribProvincePage";
            this.ribProvincePage.ShowCaptionButton = false;
            this.ribProvincePage.Text = "Danh Mục Khác";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 568);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1266, 31);
            // 
            // tabMain
            // 
            this.tabMain.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.tabMain.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next) 
            | DevExpress.XtraTab.TabButtons.Close) 
            | DevExpress.XtraTab.TabButtons.Default)));
            this.tabMain.MdiParent = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 599);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "iPOS Management 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribSystemModule;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribSystemPage;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribUserPermissionPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnShutdown;
        private DevExpress.XtraBars.BarButtonItem btnLockScreen;
        private DevExpress.XtraBars.BarButtonItem btnGroupUserList;
        private DevExpress.XtraBars.BarButtonItem btnUserList;
        private DevExpress.XtraBars.BarButtonItem btnPermission;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem btnChangePassword;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabMain;
        private DevExpress.XtraBars.BarButtonItem btnRestart;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribProductModule;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribStorePage;
        private DevExpress.XtraBars.BarButtonItem btnStore;
        private DevExpress.XtraBars.BarButtonItem btnWarehouse;
        private DevExpress.XtraBars.BarButtonItem btnStall;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribProviderUnit;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribProductPage;
        private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        private DevExpress.XtraBars.BarButtonItem btnLevel1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        private DevExpress.XtraBars.BarButtonItem barButtonItem15;
        private DevExpress.XtraBars.BarButtonItem btnProvince;
        private DevExpress.XtraBars.BarButtonItem btnDistrict;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribProvincePage;
    }
}