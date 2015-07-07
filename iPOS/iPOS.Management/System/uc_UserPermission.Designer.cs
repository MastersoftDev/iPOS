partial class uc_UserPermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_UserPermission));
            this.barMain = new DevExpress.XtraBars.BarManager(this.components);
            this.barHeader = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barLargeButtonItem2 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barFooter = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grpGroupUser = new DevExpress.XtraEditors.GroupControl();
            this.trlUser = new DevExpress.XtraTreeList.TreeList();
            this.tlcName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imcGroupUser = new DevExpress.Utils.ImageCollection(this.components);
            this.grpUserPermission = new DevExpress.XtraEditors.GroupControl();
            this.trlPermission = new DevExpress.XtraTreeList.TreeList();
            this.tlcFunctionName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcAllowAll = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkAll = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowInsert = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkInsert = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowUpdate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkUpdate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowDelete = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkDelete = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowAccess = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkAccess = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowPrint = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkPrint = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowImport = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkImport = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowExport = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkExport = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcUserLevelID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcNote = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.txtNote = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tlcID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcFunctionID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.sccMain = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroupUser)).BeginInit();
            this.grpGroupUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imcGroupUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpUserPermission)).BeginInit();
            this.grpUserPermission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).BeginInit();
            this.sccMain.SuspendLayout();
            this.SuspendLayout();
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
            this.btnSave,
            this.barLargeButtonItem2});
            this.barMain.MainMenu = this.barHeader;
            this.barMain.MaxItemId = 10;
            this.barMain.StatusBar = this.barFooter;
            // 
            // barHeader
            // 
            this.barHeader.BarName = "Main menu";
            this.barHeader.DockCol = 0;
            this.barHeader.DockRow = 0;
            this.barHeader.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barHeader.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItem2)});
            this.barHeader.OptionsBar.DisableClose = true;
            this.barHeader.OptionsBar.DisableCustomization = true;
            this.barHeader.OptionsBar.DrawDragBorder = false;
            this.barHeader.OptionsBar.DrawSizeGrip = true;
            this.barHeader.OptionsBar.UseWholeRow = true;
            this.barHeader.Text = "Main menu";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu Lại";
            this.btnSave.Id = 8;
            this.btnSave.LargeGlyph = global::iPOS.Management.Properties.Resources.save_end_16;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // barLargeButtonItem2
            // 
            this.barLargeButtonItem2.Caption = "Đóng";
            this.barLargeButtonItem2.Id = 9;
            this.barLargeButtonItem2.LargeGlyph = global::iPOS.Management.Properties.Resources.close_16;
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            // 
            // barFooter
            // 
            this.barFooter.BarName = "Status bar";
            this.barFooter.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barFooter.DockCol = 0;
            this.barFooter.DockRow = 0;
            this.barFooter.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFooter.OptionsBar.DrawDragBorder = false;
            this.barFooter.OptionsBar.UseWholeRow = true;
            this.barFooter.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1318, 42);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 495);
            this.barDockControlBottom.Size = new System.Drawing.Size(1318, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 42);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 453);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1318, 42);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 453);
            // 
            // grpGroupUser
            // 
            this.grpGroupUser.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpGroupUser.AppearanceCaption.Options.UseFont = true;
            this.grpGroupUser.Controls.Add(this.trlUser);
            this.grpGroupUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGroupUser.Location = new System.Drawing.Point(0, 0);
            this.grpGroupUser.Name = "grpGroupUser";
            this.grpGroupUser.Size = new System.Drawing.Size(280, 453);
            this.grpGroupUser.TabIndex = 4;
            this.grpGroupUser.Text = "Danh Sách Người Dùng";
            // 
            // trlUser
            // 
            this.trlUser.Appearance.FocusedCell.BackColor = System.Drawing.Color.Wheat;
            this.trlUser.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Orange;
            this.trlUser.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Red;
            this.trlUser.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.trlUser.Appearance.FocusedCell.Options.UseBackColor = true;
            this.trlUser.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.trlUser.Appearance.FocusedCell.Options.UseForeColor = true;
            this.trlUser.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.trlUser.Appearance.FocusedRow.Options.UseFont = true;
            this.trlUser.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.trlUser.Appearance.SelectedRow.Options.UseFont = true;
            this.trlUser.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcName,
            this.tlcCode});
            this.trlUser.ColumnsImageList = this.imcGroupUser;
            this.trlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlUser.HtmlImages = this.imcGroupUser;
            this.trlUser.Location = new System.Drawing.Point(2, 21);
            this.trlUser.Name = "trlUser";
            this.trlUser.OptionsBehavior.Editable = false;
            this.trlUser.OptionsView.ShowColumns = false;
            this.trlUser.OptionsView.ShowHorzLines = false;
            this.trlUser.OptionsView.ShowVertLines = false;
            this.trlUser.SelectImageList = this.imcGroupUser;
            this.trlUser.Size = new System.Drawing.Size(276, 430);
            this.trlUser.TabIndex = 0;
            this.trlUser.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trlUser_FocusedNodeChanged);
            // 
            // tlcName
            // 
            this.tlcName.FieldName = "Name";
            this.tlcName.MinWidth = 51;
            this.tlcName.Name = "tlcName";
            this.tlcName.Visible = true;
            this.tlcName.VisibleIndex = 0;
            this.tlcName.Width = 110;
            // 
            // tlcCode
            // 
            this.tlcCode.Caption = "Code";
            this.tlcCode.FieldName = "Code";
            this.tlcCode.Name = "tlcCode";
            // 
            // imcGroupUser
            // 
            this.imcGroupUser.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imcGroupUser.ImageStream")));
            this.imcGroupUser.InsertImage(global::iPOS.Management.Properties.Resources.group_user_16, "group_user_16", typeof(global::iPOS.Management.Properties.Resources), 0);
            this.imcGroupUser.Images.SetKeyName(0, "group_user_16");
            this.imcGroupUser.InsertImage(global::iPOS.Management.Properties.Resources.user_16, "user_16", typeof(global::iPOS.Management.Properties.Resources), 1);
            this.imcGroupUser.Images.SetKeyName(1, "user_16");
            // 
            // grpUserPermission
            // 
            this.grpUserPermission.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpUserPermission.AppearanceCaption.Options.UseFont = true;
            this.grpUserPermission.Controls.Add(this.trlPermission);
            this.grpUserPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUserPermission.Location = new System.Drawing.Point(0, 0);
            this.grpUserPermission.Name = "grpUserPermission";
            this.grpUserPermission.Size = new System.Drawing.Size(1033, 453);
            this.grpUserPermission.TabIndex = 6;
            this.grpUserPermission.Text = "Thông Tin Phân Quyền Dữ Liệu";
            // 
            // trlPermission
            // 
            this.trlPermission.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcFunctionName,
            this.tlcAllowAll,
            this.tlcAllowInsert,
            this.tlcAllowUpdate,
            this.tlcAllowDelete,
            this.tlcAllowAccess,
            this.tlcAllowPrint,
            this.tlcAllowImport,
            this.tlcAllowExport,
            this.tlcUserLevelID,
            this.tlcNote,
            this.tlcID,
            this.tlcFunctionID});
            this.trlPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlPermission.Location = new System.Drawing.Point(2, 21);
            this.trlPermission.Name = "trlPermission";
            this.trlPermission.OptionsBehavior.PopulateServiceColumns = true;
            this.trlPermission.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkAll,
            this.chkInsert,
            this.chkUpdate,
            this.chkDelete,
            this.chkAccess,
            this.chkPrint,
            this.chkImport,
            this.chkExport,
            this.txtNote});
            this.trlPermission.Size = new System.Drawing.Size(1029, 430);
            this.trlPermission.TabIndex = 0;
            // 
            // tlcFunctionName
            // 
            this.tlcFunctionName.Caption = "Chức năng";
            this.tlcFunctionName.FieldName = "FunctionName";
            this.tlcFunctionName.Name = "tlcFunctionName";
            this.tlcFunctionName.OptionsColumn.AllowEdit = false;
            this.tlcFunctionName.Visible = true;
            this.tlcFunctionName.VisibleIndex = 0;
            this.tlcFunctionName.Width = 371;
            // 
            // tlcAllowAll
            // 
            this.tlcAllowAll.AppearanceCell.Options.UseTextOptions = true;
            this.tlcAllowAll.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowAll.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowAll.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowAll.Caption = "Tất cả";
            this.tlcAllowAll.ColumnEdit = this.chkAll;
            this.tlcAllowAll.FieldName = "AllowAll";
            this.tlcAllowAll.Name = "tlcAllowAll";
            this.tlcAllowAll.Visible = true;
            this.tlcAllowAll.VisibleIndex = 1;
            this.tlcAllowAll.Width = 53;
            // 
            // chkAll
            // 
            this.chkAll.AutoHeight = false;
            this.chkAll.Name = "chkAll";
            // 
            // tlcAllowInsert
            // 
            this.tlcAllowInsert.AppearanceCell.Options.UseTextOptions = true;
            this.tlcAllowInsert.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowInsert.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowInsert.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowInsert.Caption = "Thêm";
            this.tlcAllowInsert.ColumnEdit = this.chkInsert;
            this.tlcAllowInsert.FieldName = "AllowInsert";
            this.tlcAllowInsert.Name = "tlcAllowInsert";
            this.tlcAllowInsert.Visible = true;
            this.tlcAllowInsert.VisibleIndex = 2;
            this.tlcAllowInsert.Width = 53;
            // 
            // chkInsert
            // 
            this.chkInsert.AutoHeight = false;
            this.chkInsert.Name = "chkInsert";
            // 
            // tlcAllowUpdate
            // 
            this.tlcAllowUpdate.AppearanceCell.Options.UseTextOptions = true;
            this.tlcAllowUpdate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowUpdate.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowUpdate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowUpdate.Caption = "Sửa";
            this.tlcAllowUpdate.ColumnEdit = this.chkUpdate;
            this.tlcAllowUpdate.FieldName = "AllowUpdate";
            this.tlcAllowUpdate.Name = "tlcAllowUpdate";
            this.tlcAllowUpdate.Visible = true;
            this.tlcAllowUpdate.VisibleIndex = 3;
            this.tlcAllowUpdate.Width = 53;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoHeight = false;
            this.chkUpdate.Name = "chkUpdate";
            // 
            // tlcAllowDelete
            // 
            this.tlcAllowDelete.AppearanceCell.Options.UseTextOptions = true;
            this.tlcAllowDelete.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowDelete.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowDelete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowDelete.Caption = "Xóa";
            this.tlcAllowDelete.ColumnEdit = this.chkDelete;
            this.tlcAllowDelete.FieldName = "AllowDelete";
            this.tlcAllowDelete.Name = "tlcAllowDelete";
            this.tlcAllowDelete.Visible = true;
            this.tlcAllowDelete.VisibleIndex = 4;
            this.tlcAllowDelete.Width = 54;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoHeight = false;
            this.chkDelete.Name = "chkDelete";
            // 
            // tlcAllowAccess
            // 
            this.tlcAllowAccess.AppearanceCell.Options.UseTextOptions = true;
            this.tlcAllowAccess.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowAccess.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowAccess.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowAccess.Caption = "Truy cập";
            this.tlcAllowAccess.ColumnEdit = this.chkAccess;
            this.tlcAllowAccess.FieldName = "AllowAccess";
            this.tlcAllowAccess.Name = "tlcAllowAccess";
            this.tlcAllowAccess.Visible = true;
            this.tlcAllowAccess.VisibleIndex = 5;
            this.tlcAllowAccess.Width = 81;
            // 
            // chkAccess
            // 
            this.chkAccess.AutoHeight = false;
            this.chkAccess.Name = "chkAccess";
            // 
            // tlcAllowPrint
            // 
            this.tlcAllowPrint.AppearanceCell.Options.UseTextOptions = true;
            this.tlcAllowPrint.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowPrint.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowPrint.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowPrint.Caption = "In";
            this.tlcAllowPrint.ColumnEdit = this.chkPrint;
            this.tlcAllowPrint.FieldName = "AllowPrint";
            this.tlcAllowPrint.Name = "tlcAllowPrint";
            this.tlcAllowPrint.Visible = true;
            this.tlcAllowPrint.VisibleIndex = 6;
            this.tlcAllowPrint.Width = 46;
            // 
            // chkPrint
            // 
            this.chkPrint.AutoHeight = false;
            this.chkPrint.Name = "chkPrint";
            // 
            // tlcAllowImport
            // 
            this.tlcAllowImport.AppearanceCell.Options.UseTextOptions = true;
            this.tlcAllowImport.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowImport.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowImport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowImport.Caption = "Nhập";
            this.tlcAllowImport.ColumnEdit = this.chkImport;
            this.tlcAllowImport.FieldName = "AllowImport";
            this.tlcAllowImport.Name = "tlcAllowImport";
            this.tlcAllowImport.Visible = true;
            this.tlcAllowImport.VisibleIndex = 7;
            this.tlcAllowImport.Width = 47;
            // 
            // chkImport
            // 
            this.chkImport.AutoHeight = false;
            this.chkImport.Name = "chkImport";
            // 
            // tlcAllowExport
            // 
            this.tlcAllowExport.AppearanceCell.Options.UseTextOptions = true;
            this.tlcAllowExport.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowExport.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowExport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowExport.Caption = "Xuất";
            this.tlcAllowExport.ColumnEdit = this.chkExport;
            this.tlcAllowExport.FieldName = "AllowExport";
            this.tlcAllowExport.Name = "tlcAllowExport";
            this.tlcAllowExport.Visible = true;
            this.tlcAllowExport.VisibleIndex = 8;
            this.tlcAllowExport.Width = 48;
            // 
            // chkExport
            // 
            this.chkExport.AutoHeight = false;
            this.chkExport.Name = "chkExport";
            // 
            // tlcUserLevelID
            // 
            this.tlcUserLevelID.Caption = "UserLevelID";
            this.tlcUserLevelID.FieldName = "UserLevelID";
            this.tlcUserLevelID.Name = "tlcUserLevelID";
            // 
            // tlcNote
            // 
            this.tlcNote.Caption = "Ghi chú";
            this.tlcNote.ColumnEdit = this.txtNote;
            this.tlcNote.FieldName = "Note";
            this.tlcNote.Name = "tlcNote";
            this.tlcNote.Visible = true;
            this.tlcNote.VisibleIndex = 9;
            this.tlcNote.Width = 205;
            // 
            // txtNote
            // 
            this.txtNote.AutoHeight = false;
            this.txtNote.Name = "txtNote";
            // 
            // tlcID
            // 
            this.tlcID.Caption = "ID";
            this.tlcID.FieldName = "ID";
            this.tlcID.Name = "tlcID";
            // 
            // tlcFunctionID
            // 
            this.tlcFunctionID.Caption = "FunctionID";
            this.tlcFunctionID.FieldName = "FunctionID";
            this.tlcFunctionID.Name = "tlcFunctionID";
            // 
            // sccMain
            // 
            this.sccMain.AllowTouchScroll = true;
            this.sccMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccMain.Location = new System.Drawing.Point(0, 42);
            this.sccMain.Name = "sccMain";
            this.sccMain.Panel1.Controls.Add(this.grpGroupUser);
            this.sccMain.Panel1.MinSize = 280;
            this.sccMain.Panel1.Text = "Panel1";
            this.sccMain.Panel2.Controls.Add(this.grpUserPermission);
            this.sccMain.Panel2.MinSize = 500;
            this.sccMain.Panel2.Text = "Panel2";
            this.sccMain.Size = new System.Drawing.Size(1318, 453);
            this.sccMain.SplitterPosition = 218;
            this.sccMain.TabIndex = 7;
            this.sccMain.Text = "sscMain";
            // 
            // uc_UserPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sccMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.Name = "uc_UserPermission";
            this.Size = new System.Drawing.Size(1318, 518);
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGroupUser)).EndInit();
            this.grpGroupUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imcGroupUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpUserPermission)).EndInit();
            this.grpUserPermission.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).EndInit();
            this.sccMain.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraBars.BarManager barMain;
    private DevExpress.XtraBars.Bar barHeader;
    private DevExpress.XtraBars.Bar barFooter;
    private DevExpress.XtraBars.BarDockControl barDockControlTop;
    private DevExpress.XtraBars.BarDockControl barDockControlBottom;
    private DevExpress.XtraBars.BarDockControl barDockControlLeft;
    private DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraEditors.GroupControl grpGroupUser;
    private DevExpress.XtraEditors.GroupControl grpUserPermission;
    private DevExpress.XtraEditors.SplitContainerControl sccMain;
    private DevExpress.XtraTreeList.TreeList trlUser;
    private DevExpress.Utils.ImageCollection imcGroupUser;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcName;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcCode;
    private DevExpress.XtraTreeList.TreeList trlPermission;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcFunctionName;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowAll;
    private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkAll;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowInsert;
    private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkInsert;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowUpdate;
    private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUpdate;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowDelete;
    private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkDelete;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowAccess;
    private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkAccess;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowPrint;
    private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkPrint;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowImport;
    private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkImport;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowExport;
    private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkExport;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcUserLevelID;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcNote;
    private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtNote;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcID;
    private DevExpress.XtraTreeList.Columns.TreeListColumn tlcFunctionID;
    private DevExpress.XtraBars.BarLargeButtonItem btnSave;
    private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem2;
}