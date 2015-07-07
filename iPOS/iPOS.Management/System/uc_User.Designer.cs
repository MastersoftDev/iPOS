partial class uc_User
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
            this.gcolGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEditer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCreater = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEmpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEditTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridUser = new DevExpress.XtraGrid.GridControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.grvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).BeginInit();
            this.SuspendLayout();
            // 
            // gcolGroupName
            // 
            this.gcolGroupName.Caption = "Nhóm người dùng";
            this.gcolGroupName.FieldName = "GroupName";
            this.gcolGroupName.Name = "gcolGroupName";
            this.gcolGroupName.Visible = true;
            this.gcolGroupName.VisibleIndex = 1;
            this.gcolGroupName.Width = 141;
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
            // gcolEmail
            // 
            this.gcolEmail.AppearanceCell.Options.UseTextOptions = true;
            this.gcolEmail.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gcolEmail.Caption = "Email";
            this.gcolEmail.FieldName = "Email";
            this.gcolEmail.Name = "gcolEmail";
            this.gcolEmail.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolEmail.Visible = true;
            this.gcolEmail.VisibleIndex = 5;
            this.gcolEmail.Width = 121;
            // 
            // gcolEffectiveDate
            // 
            this.gcolEffectiveDate.AppearanceCell.Options.UseTextOptions = true;
            this.gcolEffectiveDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcolEffectiveDate.Caption = "Ngày hiệu lực";
            this.gcolEffectiveDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gcolEffectiveDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcolEffectiveDate.FieldName = "EffectiveDate";
            this.gcolEffectiveDate.Name = "gcolEffectiveDate";
            this.gcolEffectiveDate.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolEffectiveDate.Visible = true;
            this.gcolEffectiveDate.VisibleIndex = 4;
            this.gcolEffectiveDate.Width = 103;
            // 
            // gcolEmpCode
            // 
            this.gcolEmpCode.Caption = "Mã nhân viên";
            this.gcolEmpCode.FieldName = "EmpCode";
            this.gcolEmpCode.Name = "gcolEmpCode";
            this.gcolEmpCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolEmpCode.Visible = true;
            this.gcolEmpCode.VisibleIndex = 3;
            this.gcolEmpCode.Width = 99;
            // 
            // gcolFullName
            // 
            this.gcolFullName.Caption = "Họ và tên";
            this.gcolFullName.FieldName = "FullName";
            this.gcolFullName.Name = "gcolFullName";
            this.gcolFullName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolFullName.Visible = true;
            this.gcolFullName.VisibleIndex = 2;
            this.gcolFullName.Width = 169;
            // 
            // gcolUsername
            // 
            this.gcolUsername.Caption = "Tên người dùng";
            this.gcolUsername.FieldName = "Username";
            this.gcolUsername.Name = "gcolUsername";
            this.gcolUsername.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolUsername.Visible = true;
            this.gcolUsername.VisibleIndex = 0;
            this.gcolUsername.Width = 125;
            // 
            // grvUser
            // 
            this.grvUser.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvUser.Appearance.GroupRow.Options.UseFont = true;
            this.grvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolUsername,
            this.gcolGroupName,
            this.gcolFullName,
            this.gcolEmpCode,
            this.gcolEffectiveDate,
            this.gcolEmail,
            this.gcolNote,
            this.gcolCreater,
            this.gcolCreateTime,
            this.gcolEditer,
            this.gcolEditTime});
            this.grvUser.GridControl = this.gridUser;
            this.grvUser.IndicatorWidth = 40;
            this.grvUser.Name = "grvUser";
            this.grvUser.OptionsBehavior.Editable = false;
            this.grvUser.OptionsSelection.MultiSelect = true;
            this.grvUser.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvUser_CustomDrawRowIndicator);
            this.grvUser.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvUser_SelectionChanged);
            this.grvUser.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvUser_FocusedRowChanged);
            this.grvUser.FocusedRowLoaded += new DevExpress.XtraGrid.Views.Base.RowEventHandler(this.grvUser_FocusedRowLoaded);
            this.grvUser.DoubleClick += new System.EventHandler(this.grvUser_DoubleClick);
            // 
            // gcolNote
            // 
            this.gcolNote.Caption = "Ghi chú";
            this.gcolNote.FieldName = "Note";
            this.gcolNote.Name = "gcolNote";
            this.gcolNote.Visible = true;
            this.gcolNote.VisibleIndex = 6;
            this.gcolNote.Width = 336;
            // 
            // gcolEditTime
            // 
            this.gcolEditTime.Caption = "EditTime";
            this.gcolEditTime.FieldName = "EditTime";
            this.gcolEditTime.Name = "gcolEditTime";
            // 
            // gridUser
            // 
            this.gridUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUser.Location = new System.Drawing.Point(0, 42);
            this.gridUser.MainView = this.grvUser;
            this.gridUser.MenuManager = this.barMain;
            this.gridUser.Name = "gridUser";
            this.gridUser.Size = new System.Drawing.Size(912, 497);
            this.gridUser.TabIndex = 5;
            this.gridUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUser});
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
            this.barDockControlTop.Size = new System.Drawing.Size(912, 42);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 539);
            this.barDockControlBottom.Size = new System.Drawing.Size(912, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 42);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 497);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(912, 42);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 497);
            // 
            // uc_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridUser);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "uc_User";
            this.Size = new System.Drawing.Size(912, 563);
            this.Load += new System.EventHandler(this.uc_User_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.Columns.GridColumn gcolGroupName;
    private DevExpress.XtraGrid.Columns.GridColumn gcolEditer;
    private DevExpress.XtraGrid.Columns.GridColumn gcolCreateTime;
    private DevExpress.XtraGrid.Columns.GridColumn gcolCreater;
    private DevExpress.XtraGrid.Columns.GridColumn gcolEmail;
    private DevExpress.XtraGrid.Columns.GridColumn gcolEffectiveDate;
    private DevExpress.XtraGrid.Columns.GridColumn gcolEmpCode;
    private DevExpress.XtraGrid.Columns.GridColumn gcolFullName;
    private DevExpress.XtraGrid.Columns.GridColumn gcolUsername;
    private DevExpress.XtraGrid.Views.Grid.GridView grvUser;
    private DevExpress.XtraGrid.Columns.GridColumn gcolEditTime;
    private DevExpress.XtraGrid.GridControl gridUser;
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
    private DevExpress.XtraGrid.Columns.GridColumn gcolNote;
}