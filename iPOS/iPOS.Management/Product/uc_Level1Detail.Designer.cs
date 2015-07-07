namespace iPOS.Management.Product
{
    partial class uc_Level1Detail
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
            this.locMain = new DevExpress.XtraLayout.LayoutControl();
            this.logMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.logDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtLevel1Code = new DevExpress.XtraEditors.TextEdit();
            this.lciLevel1Code = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtLevel1ShortCode = new DevExpress.XtraEditors.TextEdit();
            this.lciLevel1ShortCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtVNName = new DevExpress.XtraEditors.TextEdit();
            this.lciVNName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtENName = new DevExpress.XtraEditors.TextEdit();
            this.lciENName = new DevExpress.XtraLayout.LayoutControlItem();
            this.speRank = new DevExpress.XtraEditors.SpinEdit();
            this.lciRank = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkUsed = new DevExpress.XtraEditors.CheckEdit();
            this.lciUsed = new DevExpress.XtraLayout.LayoutControlItem();
            this.mmoDescription = new DevExpress.XtraEditors.MemoEdit();
            this.lciDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.mmoNote = new DevExpress.XtraEditors.MemoEdit();
            this.lciNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lciButtonCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnSaveInsert = new DevExpress.XtraEditors.SimpleButton();
            this.lciButtonSaveInsert = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            this.lciButtonSaveClose = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtLevel1ID = new DevExpress.XtraEditors.TextEdit();
            this.lciLevel1ID = new DevExpress.XtraLayout.LayoutControlItem();
            this.depError = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).BeginInit();
            this.locMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel1Code.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLevel1Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel1ShortCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLevel1ShortCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVNName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVNName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtENName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciENName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speRank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUsed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel1ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLevel1ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depError)).BeginInit();
            this.SuspendLayout();
            // 
            // locMain
            // 
            this.locMain.Controls.Add(this.txtLevel1ID);
            this.locMain.Controls.Add(this.btnSaveClose);
            this.locMain.Controls.Add(this.btnSaveInsert);
            this.locMain.Controls.Add(this.btnCancel);
            this.locMain.Controls.Add(this.mmoNote);
            this.locMain.Controls.Add(this.mmoDescription);
            this.locMain.Controls.Add(this.chkUsed);
            this.locMain.Controls.Add(this.speRank);
            this.locMain.Controls.Add(this.txtENName);
            this.locMain.Controls.Add(this.txtVNName);
            this.locMain.Controls.Add(this.txtLevel1ShortCode);
            this.locMain.Controls.Add(this.txtLevel1Code);
            this.locMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locMain.Location = new System.Drawing.Point(0, 0);
            this.locMain.Name = "locMain";
            this.locMain.Root = this.logMain;
            this.locMain.Size = new System.Drawing.Size(407, 295);
            this.locMain.TabIndex = 0;
            this.locMain.Text = "layoutControl1";
            // 
            // logMain
            // 
            this.logMain.CustomizationFormText = "layoutControlGroup1";
            this.logMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.logMain.GroupBordersVisible = false;
            this.logMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.logDetail,
            this.lciButtonCancel,
            this.lciButtonSaveInsert,
            this.lciButtonSaveClose,
            this.lciLevel1ID});
            this.logMain.Location = new System.Drawing.Point(0, 0);
            this.logMain.Name = "logMain";
            this.logMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.logMain.Size = new System.Drawing.Size(407, 295);
            this.logMain.Text = "logMain";
            this.logMain.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 269);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(50, 26);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(50, 26);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(50, 26);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // logDetail
            // 
            this.logDetail.CustomizationFormText = "logDetail";
            this.logDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciLevel1Code,
            this.lciLevel1ShortCode,
            this.lciVNName,
            this.lciENName,
            this.lciRank,
            this.lciUsed,
            this.lciDescription,
            this.lciNote});
            this.logDetail.Location = new System.Drawing.Point(0, 0);
            this.logDetail.Name = "logDetail";
            this.logDetail.Size = new System.Drawing.Size(407, 269);
            this.logDetail.Text = "logDetail";
            // 
            // txtLevel1Code
            // 
            this.txtLevel1Code.Location = new System.Drawing.Point(115, 33);
            this.txtLevel1Code.Name = "txtLevel1Code";
            this.txtLevel1Code.Size = new System.Drawing.Size(164, 20);
            this.txtLevel1Code.StyleController = this.locMain;
            this.txtLevel1Code.TabIndex = 4;
            this.txtLevel1Code.EditValueChanged += new System.EventHandler(this.txtLevel1Code_EditValueChanged);
            // 
            // lciLevel1Code
            // 
            this.lciLevel1Code.Control = this.txtLevel1Code;
            this.lciLevel1Code.CustomizationFormText = "Mã ngành hàng:";
            this.lciLevel1Code.Location = new System.Drawing.Point(0, 0);
            this.lciLevel1Code.Name = "lciLevel1Code";
            this.lciLevel1Code.Size = new System.Drawing.Size(269, 24);
            this.lciLevel1Code.Text = "Mã ngành hàng:";
            this.lciLevel1Code.TextSize = new System.Drawing.Size(98, 13);
            // 
            // txtLevel1ShortCode
            // 
            this.txtLevel1ShortCode.Location = new System.Drawing.Point(343, 33);
            this.txtLevel1ShortCode.Name = "txtLevel1ShortCode";
            this.txtLevel1ShortCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLevel1ShortCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtLevel1ShortCode.Properties.MaxLength = 2;
            this.txtLevel1ShortCode.Size = new System.Drawing.Size(50, 20);
            this.txtLevel1ShortCode.StyleController = this.locMain;
            this.txtLevel1ShortCode.TabIndex = 5;
            this.txtLevel1ShortCode.EditValueChanged += new System.EventHandler(this.txtLevel1ShortCode_EditValueChanged);
            this.txtLevel1ShortCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLevel1ShortCode_KeyPress);
            this.txtLevel1ShortCode.Leave += new System.EventHandler(this.txtLevel1ShortCode_Leave);
            // 
            // lciLevel1ShortCode
            // 
            this.lciLevel1ShortCode.Control = this.txtLevel1ShortCode;
            this.lciLevel1ShortCode.CustomizationFormText = "Mã nội bộ:";
            this.lciLevel1ShortCode.Location = new System.Drawing.Point(269, 0);
            this.lciLevel1ShortCode.Name = "lciLevel1ShortCode";
            this.lciLevel1ShortCode.Size = new System.Drawing.Size(114, 24);
            this.lciLevel1ShortCode.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 0, 0, 0);
            this.lciLevel1ShortCode.Text = "Mã nội bộ:";
            this.lciLevel1ShortCode.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciLevel1ShortCode.TextSize = new System.Drawing.Size(50, 13);
            this.lciLevel1ShortCode.TextToControlDistance = 5;
            // 
            // txtVNName
            // 
            this.txtVNName.Location = new System.Drawing.Point(115, 57);
            this.txtVNName.Name = "txtVNName";
            this.txtVNName.Size = new System.Drawing.Size(278, 20);
            this.txtVNName.StyleController = this.locMain;
            this.txtVNName.TabIndex = 6;
            this.txtVNName.EditValueChanged += new System.EventHandler(this.txtVNName_EditValueChanged);
            // 
            // lciVNName
            // 
            this.lciVNName.Control = this.txtVNName;
            this.lciVNName.CustomizationFormText = "Tên ngành hàng VN:";
            this.lciVNName.Location = new System.Drawing.Point(0, 24);
            this.lciVNName.Name = "lciVNName";
            this.lciVNName.Size = new System.Drawing.Size(383, 24);
            this.lciVNName.Text = "Tên ngành hàng VN:";
            this.lciVNName.TextSize = new System.Drawing.Size(98, 13);
            // 
            // txtENName
            // 
            this.txtENName.Location = new System.Drawing.Point(115, 81);
            this.txtENName.Name = "txtENName";
            this.txtENName.Size = new System.Drawing.Size(278, 20);
            this.txtENName.StyleController = this.locMain;
            this.txtENName.TabIndex = 7;
            this.txtENName.EditValueChanged += new System.EventHandler(this.txtENName_EditValueChanged);
            // 
            // lciENName
            // 
            this.lciENName.Control = this.txtENName;
            this.lciENName.CustomizationFormText = "Tên ngành hàng EN:";
            this.lciENName.Location = new System.Drawing.Point(0, 48);
            this.lciENName.Name = "lciENName";
            this.lciENName.Size = new System.Drawing.Size(383, 24);
            this.lciENName.Text = "Tên ngành hàng EN:";
            this.lciENName.TextSize = new System.Drawing.Size(98, 13);
            // 
            // speRank
            // 
            this.speRank.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speRank.Location = new System.Drawing.Point(115, 105);
            this.speRank.Name = "speRank";
            this.speRank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.speRank.Size = new System.Drawing.Size(164, 20);
            this.speRank.StyleController = this.locMain;
            this.speRank.TabIndex = 8;
            // 
            // lciRank
            // 
            this.lciRank.Control = this.speRank;
            this.lciRank.CustomizationFormText = "Thứ tự:";
            this.lciRank.Location = new System.Drawing.Point(0, 72);
            this.lciRank.Name = "lciRank";
            this.lciRank.Size = new System.Drawing.Size(269, 24);
            this.lciRank.Text = "Thứ tự:";
            this.lciRank.TextSize = new System.Drawing.Size(98, 13);
            // 
            // chkUsed
            // 
            this.chkUsed.Location = new System.Drawing.Point(289, 105);
            this.chkUsed.Name = "chkUsed";
            this.chkUsed.Properties.Caption = "Đang sử dụng?";
            this.chkUsed.Size = new System.Drawing.Size(104, 19);
            this.chkUsed.StyleController = this.locMain;
            this.chkUsed.TabIndex = 9;
            // 
            // lciUsed
            // 
            this.lciUsed.Control = this.chkUsed;
            this.lciUsed.CustomizationFormText = "lciUsed";
            this.lciUsed.Location = new System.Drawing.Point(269, 72);
            this.lciUsed.Name = "lciUsed";
            this.lciUsed.Size = new System.Drawing.Size(114, 24);
            this.lciUsed.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 0, 0, 0);
            this.lciUsed.Text = "lciUsed";
            this.lciUsed.TextSize = new System.Drawing.Size(0, 0);
            this.lciUsed.TextToControlDistance = 0;
            this.lciUsed.TextVisible = false;
            // 
            // mmoDescription
            // 
            this.mmoDescription.Location = new System.Drawing.Point(115, 129);
            this.mmoDescription.Name = "mmoDescription";
            this.mmoDescription.Size = new System.Drawing.Size(278, 59);
            this.mmoDescription.StyleController = this.locMain;
            this.mmoDescription.TabIndex = 10;
            // 
            // lciDescription
            // 
            this.lciDescription.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lciDescription.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lciDescription.Control = this.mmoDescription;
            this.lciDescription.CustomizationFormText = "Mô tả:";
            this.lciDescription.Location = new System.Drawing.Point(0, 96);
            this.lciDescription.Name = "lciDescription";
            this.lciDescription.Size = new System.Drawing.Size(383, 63);
            this.lciDescription.Text = "Mô tả:";
            this.lciDescription.TextSize = new System.Drawing.Size(98, 13);
            // 
            // mmoNote
            // 
            this.mmoNote.Location = new System.Drawing.Point(115, 192);
            this.mmoNote.Name = "mmoNote";
            this.mmoNote.Size = new System.Drawing.Size(278, 63);
            this.mmoNote.StyleController = this.locMain;
            this.mmoNote.TabIndex = 11;
            // 
            // lciNote
            // 
            this.lciNote.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lciNote.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lciNote.Control = this.mmoNote;
            this.lciNote.CustomizationFormText = "Ghi chú:";
            this.lciNote.Location = new System.Drawing.Point(0, 159);
            this.lciNote.Name = "lciNote";
            this.lciNote.Size = new System.Drawing.Size(383, 67);
            this.lciNote.Text = "Ghi chú:";
            this.lciNote.TextSize = new System.Drawing.Size(98, 13);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::iPOS.Management.Properties.Resources.cancel_16;
            this.btnCancel.Location = new System.Drawing.Point(308, 271);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 22);
            this.btnCancel.StyleController = this.locMain;
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lciButtonCancel
            // 
            this.lciButtonCancel.Control = this.btnCancel;
            this.lciButtonCancel.CustomizationFormText = "lciButtonCancel";
            this.lciButtonCancel.Location = new System.Drawing.Point(306, 269);
            this.lciButtonCancel.Name = "lciButtonCancel";
            this.lciButtonCancel.Size = new System.Drawing.Size(101, 26);
            this.lciButtonCancel.Text = "lciButtonCancel";
            this.lciButtonCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonCancel.TextToControlDistance = 0;
            this.lciButtonCancel.TextVisible = false;
            // 
            // btnSaveInsert
            // 
            this.btnSaveInsert.Image = global::iPOS.Management.Properties.Resources.save_add_16;
            this.btnSaveInsert.Location = new System.Drawing.Point(208, 271);
            this.btnSaveInsert.Name = "btnSaveInsert";
            this.btnSaveInsert.Size = new System.Drawing.Size(96, 22);
            this.btnSaveInsert.StyleController = this.locMain;
            this.btnSaveInsert.TabIndex = 13;
            this.btnSaveInsert.Text = "Lưu && Thêm";
            this.btnSaveInsert.Click += new System.EventHandler(this.btnSaveInsert_Click);
            // 
            // lciButtonSaveInsert
            // 
            this.lciButtonSaveInsert.Control = this.btnSaveInsert;
            this.lciButtonSaveInsert.CustomizationFormText = "lciButtonSaveInsert";
            this.lciButtonSaveInsert.Location = new System.Drawing.Point(206, 269);
            this.lciButtonSaveInsert.Name = "lciButtonSaveInsert";
            this.lciButtonSaveInsert.Size = new System.Drawing.Size(100, 26);
            this.lciButtonSaveInsert.Text = "lciButtonSaveInsert";
            this.lciButtonSaveInsert.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonSaveInsert.TextToControlDistance = 0;
            this.lciButtonSaveInsert.TextVisible = false;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Image = global::iPOS.Management.Properties.Resources.save_end_16;
            this.btnSaveClose.Location = new System.Drawing.Point(109, 271);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(95, 22);
            this.btnSaveClose.StyleController = this.locMain;
            this.btnSaveClose.TabIndex = 14;
            this.btnSaveClose.Text = "Lưu && Đóng";
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // lciButtonSaveClose
            // 
            this.lciButtonSaveClose.Control = this.btnSaveClose;
            this.lciButtonSaveClose.CustomizationFormText = "lciButtonSaveClose";
            this.lciButtonSaveClose.Location = new System.Drawing.Point(107, 269);
            this.lciButtonSaveClose.Name = "lciButtonSaveClose";
            this.lciButtonSaveClose.Size = new System.Drawing.Size(99, 26);
            this.lciButtonSaveClose.Text = "lciButtonSaveClose";
            this.lciButtonSaveClose.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonSaveClose.TextToControlDistance = 0;
            this.lciButtonSaveClose.TextVisible = false;
            // 
            // txtLevel1ID
            // 
            this.txtLevel1ID.Location = new System.Drawing.Point(52, 271);
            this.txtLevel1ID.Name = "txtLevel1ID";
            this.txtLevel1ID.Size = new System.Drawing.Size(53, 20);
            this.txtLevel1ID.StyleController = this.locMain;
            this.txtLevel1ID.TabIndex = 15;
            // 
            // lciLevel1ID
            // 
            this.lciLevel1ID.ContentVisible = false;
            this.lciLevel1ID.Control = this.txtLevel1ID;
            this.lciLevel1ID.CustomizationFormText = "lciLevel1ID";
            this.lciLevel1ID.Location = new System.Drawing.Point(50, 269);
            this.lciLevel1ID.MaxSize = new System.Drawing.Size(57, 26);
            this.lciLevel1ID.MinSize = new System.Drawing.Size(57, 26);
            this.lciLevel1ID.Name = "lciLevel1ID";
            this.lciLevel1ID.Size = new System.Drawing.Size(57, 26);
            this.lciLevel1ID.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciLevel1ID.Text = "lciLevel1ID";
            this.lciLevel1ID.TextSize = new System.Drawing.Size(0, 0);
            this.lciLevel1ID.TextToControlDistance = 0;
            this.lciLevel1ID.TextVisible = false;
            // 
            // depError
            // 
            this.depError.ContainerControl = this;
            // 
            // uc_Level1Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.locMain);
            this.Name = "uc_Level1Detail";
            this.Size = new System.Drawing.Size(407, 295);
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).EndInit();
            this.locMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel1Code.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLevel1Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel1ShortCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLevel1ShortCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVNName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVNName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtENName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciENName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speRank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUsed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel1ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLevel1ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl locMain;
        private DevExpress.XtraLayout.LayoutControlGroup logMain;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlGroup logDetail;
        private DevExpress.XtraEditors.TextEdit txtLevel1Code;
        private DevExpress.XtraLayout.LayoutControlItem lciLevel1Code;
        private DevExpress.XtraEditors.TextEdit txtLevel1ShortCode;
        private DevExpress.XtraLayout.LayoutControlItem lciLevel1ShortCode;
        private DevExpress.XtraEditors.TextEdit txtVNName;
        private DevExpress.XtraLayout.LayoutControlItem lciVNName;
        private DevExpress.XtraEditors.TextEdit txtENName;
        private DevExpress.XtraLayout.LayoutControlItem lciENName;
        private DevExpress.XtraEditors.CheckEdit chkUsed;
        private DevExpress.XtraEditors.SpinEdit speRank;
        private DevExpress.XtraLayout.LayoutControlItem lciRank;
        private DevExpress.XtraLayout.LayoutControlItem lciUsed;
        private DevExpress.XtraEditors.MemoEdit mmoNote;
        private DevExpress.XtraEditors.MemoEdit mmoDescription;
        private DevExpress.XtraLayout.LayoutControlItem lciDescription;
        private DevExpress.XtraLayout.LayoutControlItem lciNote;
        private DevExpress.XtraEditors.TextEdit txtLevel1ID;
        private DevExpress.XtraEditors.SimpleButton btnSaveClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveInsert;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonCancel;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonSaveInsert;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonSaveClose;
        private DevExpress.XtraLayout.LayoutControlItem lciLevel1ID;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider depError;
    }
}
