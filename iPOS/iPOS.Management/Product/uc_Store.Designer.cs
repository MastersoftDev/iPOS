namespace iPOS.Management.Product
{
    partial class uc_Store
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gcolStoreID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEditer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCreater = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolUsedString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolRank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvStore = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolEditTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridStore = new DevExpress.XtraGrid.GridControl();
            this.barMain = new DevExpress.XtraBars.BarManager(this.components);
            this.barHeader = new DevExpress.XtraBars.Bar();
            this.btnInsert = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnUpdate = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnImport = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barFooter = new DevExpress.XtraBars.Bar();
            this.lblCreater = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreateTime = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditer = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditTime = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gcolShortCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStoreAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolIsRootString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolBuildDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDistrictName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolProvinceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolTaxCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolRepresentatives = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grvStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).BeginInit();
            this.SuspendLayout();
            // 
            // gcolStoreID
            // 
            this.gcolStoreID.Caption = "StoreID";
            this.gcolStoreID.FieldName = "StoreID";
            this.gcolStoreID.Name = "gcolStoreID";
            // 
            // gcolEditer
            // 
            this.gcolEditer.Caption = "Editer";
            this.gcolEditer.FieldName = "Editer";
            this.gcolEditer.Name = "gcolEditer";
            // 
            // gcolCreateTime
            // 
            this.gcolCreateTime.Caption = "CreateTime";
            this.gcolCreateTime.FieldName = "CreateTime";
            this.gcolCreateTime.Name = "gcolCreateTime";
            // 
            // gcolCreater
            // 
            this.gcolCreater.Caption = "Creater";
            this.gcolCreater.FieldName = "Creater";
            this.gcolCreater.Name = "gcolCreater";
            // 
            // gcolUsedString
            // 
            this.gcolUsedString.AppearanceCell.Options.UseTextOptions = true;
            this.gcolUsedString.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolUsedString.Caption = "Sử dụng?";
            this.gcolUsedString.FieldName = "UsedString";
            this.gcolUsedString.Name = "gcolUsedString";
            this.gcolUsedString.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolUsedString.Visible = true;
            this.gcolUsedString.VisibleIndex = 13;
            this.gcolUsedString.Width = 72;
            // 
            // gcolNote
            // 
            this.gcolNote.Caption = "Ghi chú";
            this.gcolNote.FieldName = "Note";
            this.gcolNote.Name = "gcolNote";
            this.gcolNote.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolNote.Visible = true;
            this.gcolNote.VisibleIndex = 14;
            this.gcolNote.Width = 332;
            // 
            // gcolRank
            // 
            this.gcolRank.AppearanceCell.Options.UseTextOptions = true;
            this.gcolRank.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcolRank.Caption = "Thứ tự";
            this.gcolRank.DisplayFormat.FormatString = "N0";
            this.gcolRank.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcolRank.FieldName = "Rank";
            this.gcolRank.Name = "gcolRank";
            this.gcolRank.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolRank.Visible = true;
            this.gcolRank.VisibleIndex = 11;
            this.gcolRank.Width = 65;
            // 
            // gcolStoreName
            // 
            this.gcolStoreName.Caption = "Tên cửa hàng";
            this.gcolStoreName.FieldName = "StoreName";
            this.gcolStoreName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcolStoreName.Name = "gcolStoreName";
            this.gcolStoreName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolStoreName.Visible = true;
            this.gcolStoreName.VisibleIndex = 2;
            this.gcolStoreName.Width = 240;
            // 
            // gcolStoreCode
            // 
            this.gcolStoreCode.Caption = "Mã cửa hàng";
            this.gcolStoreCode.FieldName = "StoreCode";
            this.gcolStoreCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcolStoreCode.Name = "gcolStoreCode";
            this.gcolStoreCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolStoreCode.Visible = true;
            this.gcolStoreCode.VisibleIndex = 0;
            this.gcolStoreCode.Width = 116;
            // 
            // grvStore
            // 
            this.grvStore.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvStore.Appearance.GroupRow.Options.UseFont = true;
            this.grvStore.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolStoreCode,
            this.gcolShortCode,
            this.gcolStoreName,
            this.gcolStoreAddress,
            this.gcolIsRootString,
            this.gcolBuildDate,
            this.gcolPhone,
            this.gcolFax,
            this.gcolTaxCode,
            this.gcolRepresentatives,
            this.gcolDistrictName,
            this.gcolProvinceName,
            this.gcolUsedString,
            this.gcolRank,
            this.gcolNote,
            this.gcolCreater,
            this.gcolCreateTime,
            this.gcolEditer,
            this.gcolEditTime,
            this.gcolStoreID});
            this.grvStore.GridControl = this.gridStore;
            this.grvStore.IndicatorWidth = 40;
            this.grvStore.Name = "grvStore";
            this.grvStore.OptionsBehavior.Editable = false;
            this.grvStore.OptionsSelection.MultiSelect = true;
            this.grvStore.OptionsView.ColumnAutoWidth = false;
            this.grvStore.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvStore_CustomDrawRowIndicator);
            this.grvStore.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvStore_SelectionChanged);
            this.grvStore.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvStore_FocusedRowChanged);
            this.grvStore.FocusedRowLoaded += new DevExpress.XtraGrid.Views.Base.RowEventHandler(this.grvStore_FocusedRowLoaded);
            this.grvStore.DoubleClick += new System.EventHandler(this.grvStore_DoubleClick);
            // 
            // gcolEditTime
            // 
            this.gcolEditTime.Caption = "EditTime";
            this.gcolEditTime.FieldName = "EditTime";
            this.gcolEditTime.Name = "gcolEditTime";
            // 
            // gridStore
            // 
            this.gridStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStore.Location = new System.Drawing.Point(0, 42);
            this.gridStore.MainView = this.grvStore;
            this.gridStore.MenuManager = this.barMain;
            this.gridStore.Name = "gridStore";
            this.gridStore.Size = new System.Drawing.Size(836, 407);
            this.gridStore.TabIndex = 11;
            this.gridStore.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStore});
            // 
            // barMain
            // 
            this.barMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barHeader,
            this.barFooter});
            this.barMain.DockControls.Add(this.barDockControlTop);
            this.barMain.DockControls.Add(this.barDockControlBottom);
            this.barMain.DockControls.Add(this.barDockControlLeft);
            this.barMain.DockControls.Add(this.barDockControlRight);
            this.barMain.Form = this;
            this.barMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnInsert,
            this.btnUpdate,
            this.btnDelete,
            this.btnPrint,
            this.btnReload,
            this.btnImport,
            this.btnExport,
            this.btnClose,
            this.lblCreater,
            this.lblCreateTime,
            this.lblEditer,
            this.lblEditTime});
            this.barMain.MainMenu = this.barHeader;
            this.barMain.MaxItemId = 12;
            this.barMain.StatusBar = this.barFooter;
            // 
            // barHeader
            // 
            this.barHeader.BarName = "Main menu";
            this.barHeader.DockCol = 0;
            this.barHeader.DockRow = 0;
            this.barHeader.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barHeader.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInsert),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUpdate),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReload),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose, true)});
            this.barHeader.OptionsBar.AllowQuickCustomization = false;
            this.barHeader.OptionsBar.DrawBorder = false;
            this.barHeader.OptionsBar.DrawDragBorder = false;
            this.barHeader.OptionsBar.UseWholeRow = true;
            this.barHeader.Text = "Main menu";
            // 
            // btnInsert
            // 
            this.btnInsert.Caption = "Thêm";
            this.btnInsert.Id = 0;
            this.btnInsert.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnInsert.LargeGlyph = global::iPOS.Management.Properties.Resources.add_16;
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInsert_ItemClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Caption = "Sửa Chữa";
            this.btnUpdate.Glyph = global::iPOS.Management.Properties.Resources.update_16;
            this.btnUpdate.Id = 1;
            this.btnUpdate.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnUpdate.LargeGlyph = global::iPOS.Management.Properties.Resources.update_16;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdate_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Id = 2;
            this.btnDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnDelete.LargeGlyph = global::iPOS.Management.Properties.Resources.delete_16;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Id = 3;
            this.btnPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnPrint.LargeGlyph = global::iPOS.Management.Properties.Resources.print_16;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Tải Lại";
            this.btnReload.Id = 4;
            this.btnReload.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnReload.LargeGlyph = global::iPOS.Management.Properties.Resources.reload_16;
            this.btnReload.Name = "btnReload";
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnImport
            // 
            this.btnImport.Caption = "Nhập";
            this.btnImport.Id = 5;
            this.btnImport.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I));
            this.btnImport.LargeGlyph = global::iPOS.Management.Properties.Resources.import_16;
            this.btnImport.Name = "btnImport";
            this.btnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImport_ItemClick);
            // 
            // btnExport
            // 
            this.btnExport.Caption = "Xuất";
            this.btnExport.Id = 6;
            this.btnExport.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.btnExport.LargeGlyph = global::iPOS.Management.Properties.Resources.export_16;
            this.btnExport.Name = "btnExport";
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Id = 7;
            this.btnClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W));
            this.btnClose.LargeGlyph = global::iPOS.Management.Properties.Resources.close_16;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barFooter
            // 
            this.barFooter.BarName = "Status bar";
            this.barFooter.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barFooter.DockCol = 0;
            this.barFooter.DockRow = 0;
            this.barFooter.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barFooter.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreater),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreateTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditer),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditTime)});
            this.barFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFooter.OptionsBar.DrawDragBorder = false;
            this.barFooter.OptionsBar.UseWholeRow = true;
            this.barFooter.Text = "Status bar";
            // 
            // lblCreater
            // 
            this.lblCreater.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblCreater.Caption = "Người tạo: <b><color=RED>admin</color></b>";
            this.lblCreater.Id = 8;
            this.lblCreater.Name = "lblCreater";
            this.lblCreater.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblCreateTime.Caption = "Ngày tạo: <b><color=RED>.</color></b>";
            this.lblCreateTime.Id = 9;
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditer
            // 
            this.lblEditer.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditer.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblEditer.Caption = "Người cập nhật: <b><color=RED>admin</color></b>";
            this.lblEditer.Id = 10;
            this.lblEditer.Name = "lblEditer";
            this.lblEditer.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditTime
            // 
            this.lblEditTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditTime.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblEditTime.Caption = "Ngày cập nhật: <b><color=RED>.</color></b>";
            this.lblEditTime.Id = 11;
            this.lblEditTime.Name = "lblEditTime";
            this.lblEditTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(836, 42);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 449);
            this.barDockControlBottom.Size = new System.Drawing.Size(836, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 42);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 407);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(836, 42);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 407);
            // 
            // gcolShortCode
            // 
            this.gcolShortCode.Caption = "Mã nội bộ";
            this.gcolShortCode.FieldName = "ShortCode";
            this.gcolShortCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcolShortCode.Name = "gcolShortCode";
            this.gcolShortCode.Visible = true;
            this.gcolShortCode.VisibleIndex = 1;
            // 
            // gcolStoreAddress
            // 
            this.gcolStoreAddress.Caption = "Địa chỉ cửa hàng";
            this.gcolStoreAddress.FieldName = "StoreAddress";
            this.gcolStoreAddress.Name = "gcolStoreAddress";
            this.gcolStoreAddress.Visible = true;
            this.gcolStoreAddress.VisibleIndex = 3;
            this.gcolStoreAddress.Width = 301;
            // 
            // gcolIsRootString
            // 
            this.gcolIsRootString.AppearanceCell.Options.UseTextOptions = true;
            this.gcolIsRootString.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolIsRootString.Caption = "Cửa hàng chính?";
            this.gcolIsRootString.FieldName = "IsRootString";
            this.gcolIsRootString.Name = "gcolIsRootString";
            this.gcolIsRootString.Visible = true;
            this.gcolIsRootString.VisibleIndex = 12;
            this.gcolIsRootString.Width = 97;
            // 
            // gcolBuildDate
            // 
            this.gcolBuildDate.Caption = "Ngày thành lập";
            this.gcolBuildDate.FieldName = "BuildDate";
            this.gcolBuildDate.Name = "gcolBuildDate";
            this.gcolBuildDate.Visible = true;
            this.gcolBuildDate.VisibleIndex = 4;
            this.gcolBuildDate.Width = 122;
            // 
            // gcolDistrictName
            // 
            this.gcolDistrictName.Caption = "Quận huyện";
            this.gcolDistrictName.FieldName = "DistrictName";
            this.gcolDistrictName.Name = "gcolDistrictName";
            this.gcolDistrictName.Visible = true;
            this.gcolDistrictName.VisibleIndex = 9;
            this.gcolDistrictName.Width = 102;
            // 
            // gcolProvinceName
            // 
            this.gcolProvinceName.Caption = "Tỉnh thành";
            this.gcolProvinceName.FieldName = "ProvinceName";
            this.gcolProvinceName.Name = "gcolProvinceName";
            this.gcolProvinceName.Visible = true;
            this.gcolProvinceName.VisibleIndex = 10;
            this.gcolProvinceName.Width = 116;
            // 
            // gcolPhone
            // 
            this.gcolPhone.Caption = "Số điện thoại";
            this.gcolPhone.FieldName = "Phone";
            this.gcolPhone.Name = "gcolPhone";
            this.gcolPhone.Visible = true;
            this.gcolPhone.VisibleIndex = 5;
            this.gcolPhone.Width = 88;
            // 
            // gcolFax
            // 
            this.gcolFax.Caption = "Fax";
            this.gcolFax.FieldName = "Fax";
            this.gcolFax.Name = "gcolFax";
            this.gcolFax.Visible = true;
            this.gcolFax.VisibleIndex = 6;
            // 
            // gcolTaxCode
            // 
            this.gcolTaxCode.Caption = "Mã số thuế";
            this.gcolTaxCode.FieldName = "TaxCode";
            this.gcolTaxCode.Name = "gcolTaxCode";
            this.gcolTaxCode.Visible = true;
            this.gcolTaxCode.VisibleIndex = 7;
            // 
            // gcolRepresentatives
            // 
            this.gcolRepresentatives.Caption = "Người đại diện";
            this.gcolRepresentatives.FieldName = "Representatives";
            this.gcolRepresentatives.Name = "gcolRepresentatives";
            this.gcolRepresentatives.Visible = true;
            this.gcolRepresentatives.VisibleIndex = 8;
            this.gcolRepresentatives.Width = 150;
            // 
            // uc_Store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridStore);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "uc_Store";
            this.Size = new System.Drawing.Size(836, 473);
            this.Load += new System.EventHandler(this.uc_Store_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gcolStoreID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolEditer;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCreater;
        private DevExpress.XtraGrid.Columns.GridColumn gcolUsedString;
        private DevExpress.XtraGrid.Columns.GridColumn gcolNote;
        private DevExpress.XtraGrid.Columns.GridColumn gcolRank;
        private DevExpress.XtraGrid.Columns.GridColumn gcolStoreName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolStoreCode;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStore;
        private DevExpress.XtraGrid.Columns.GridColumn gcolEditTime;
        private DevExpress.XtraGrid.GridControl gridStore;
        private DevExpress.XtraBars.BarManager barMain;
        private DevExpress.XtraBars.Bar barHeader;
        private DevExpress.XtraBars.BarLargeButtonItem btnInsert;
        private DevExpress.XtraBars.BarLargeButtonItem btnUpdate;
        private DevExpress.XtraBars.BarLargeButtonItem btnDelete;
        private DevExpress.XtraBars.BarLargeButtonItem btnPrint;
        private DevExpress.XtraBars.BarLargeButtonItem btnReload;
        private DevExpress.XtraBars.BarLargeButtonItem btnImport;
        private DevExpress.XtraBars.BarLargeButtonItem btnExport;
        private DevExpress.XtraBars.BarLargeButtonItem btnClose;
        private DevExpress.XtraBars.Bar barFooter;
        private DevExpress.XtraBars.BarStaticItem lblCreater;
        private DevExpress.XtraBars.BarStaticItem lblCreateTime;
        private DevExpress.XtraBars.BarStaticItem lblEditer;
        private DevExpress.XtraBars.BarStaticItem lblEditTime;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn gcolShortCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcolStoreAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gcolIsRootString;
        private DevExpress.XtraGrid.Columns.GridColumn gcolBuildDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcolPhone;
        private DevExpress.XtraGrid.Columns.GridColumn gcolFax;
        private DevExpress.XtraGrid.Columns.GridColumn gcolTaxCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcolRepresentatives;
        private DevExpress.XtraGrid.Columns.GridColumn gcolDistrictName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolProvinceName;
    }
}
