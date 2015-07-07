using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Commons = iPOS.Management.Common.Common;
using iPOS.BUS.System;
using Aspose.Cells;
using DevExpress.XtraTreeList.StyleFormatConditions;

namespace iPOS.Management.Common
{
    public partial class uc_ImportExcel : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable dtSelectedFile;
        string strTemplate = "", strStoreProcedute = "", strFunctionID = "", strModuleID = "";
        bool isClickCheckFile = false;
        int total_file = 0, correct_file = 0, invalid_file = 0, total_row = 0, inserted_row = 0, updated_row = 0, invalid_row = 0, none_row = 0;
        DataSet mainData;
        SYS_tblImportFileConfigBUS busImport;
        SYS_tblReportCaptionBUS busReport;

        private void Initialize()
        {
            string Language = User.UserInfo.LanguageID;
            busImport = new SYS_tblImportFileConfigBUS();
            busReport = new SYS_tblReportCaptionBUS();

            dtSelectedFile = CreateSeletedFileTable();
            gridSeletedFiles.DataBindings.Clear();
            gridSeletedFiles.DataSource = dtSelectedFile;
            wwpStepOne.AllowNext = false;
            bteBrowseFile.Properties.Buttons[1].Enabled = false;
            mainData = new DataSet();

            DevExpress.XtraGrid.StyleFormatCondition styleInsertFormat = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleUpdateFormat = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleNormalFormat = new DevExpress.XtraGrid.StyleFormatCondition();
            #region [Inserted Style Format]
            styleInsertFormat.Appearance.BackColor = System.Drawing.Color.Green;
            styleInsertFormat.Appearance.BorderColor = Color.Black;
            styleInsertFormat.Appearance.ForeColor = Color.White;
            styleInsertFormat.Appearance.Options.UseBackColor = true;
            styleInsertFormat.Appearance.Options.UseBorderColor = true;
            styleInsertFormat.Appearance.Options.UseForeColor = true;
            styleInsertFormat.Column = grvMainData.Columns["Return Message"];
            styleInsertFormat.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleInsertFormat.Value1 = "Inserted";
            styleInsertFormat.ApplyToRow = true;
            #endregion
            #region [Updated Style Format]
            styleUpdateFormat.Appearance.BackColor = Color.Yellow;
            styleUpdateFormat.Appearance.BorderColor = Color.Black;
            styleUpdateFormat.Appearance.ForeColor = Color.Black;
            styleUpdateFormat.Appearance.Options.UseBackColor = true;
            styleUpdateFormat.Appearance.Options.UseBorderColor = true;
            styleUpdateFormat.Appearance.Options.UseForeColor = true;
            styleUpdateFormat.Column = grvMainData.Columns["Return Message"];
            styleUpdateFormat.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleUpdateFormat.Value1 = "Updated";
            styleUpdateFormat.ApplyToRow = true;
            #endregion
            this.grvMainData.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleInsertFormat, styleUpdateFormat });

            lciBrowseFile.Text = (Language.Equals("VN")) ? "Chọn tệp tin dữ liệu:" : "Choose data file:";
            btnDownloadTemplate.Text = Language.Equals("VN") ? "Tải Template" : "Download template";
            btnCheckTemplate.Text = Language.Equals("VN") ? "Kiểm Tra" : "Check Files";
            grvSeletedFiles.GroupPanelText = Language.Equals("VN") ? "Kéo một tiêu đề cột vào đây để nhóm theo cột đó" : "Drag a column header here to group by that column";
            gcolSelectedFileName.Caption = Language.Equals("VN") ? "Tên tệp tin" : "File name";
            gcolSelectedDateModified.Caption = Language.Equals("VN") ? "Ngày cập nhật" : "Date modified";
            gcolSelectedFileSize.Caption = Language.Equals("VN") ? "Kích thước" : "File size";
            gcolSelectedNote.Caption = Language.Equals("VN") ? "Ghi chú" : "Note";
            gcolSeletedFilePath.Caption = Language.Equals("VN") ? "Đường dẫn" : "File path";
            lciGridMainData.Text = Language.Equals("VN") ? "Dữ liệu nhập tổng quát" : "Input data overview";
            lciSelectedFiles.Text = Language.Equals("VN") ? "Chọn tệp dữ liệu:" : "Choose data file:";
            btnImportAllFiles.Text = Language.Equals("VN") ? "Nhập Tất Cả Tập Tin" : "Import all files";
            btnImportSelectedFile.Text = Language.Equals("VN") ? "Nhập Tệp Đã Chọn" : "Import selected file";
            wzcMain.CancelText = Language.Equals("VN") ? "Hủy Bỏ" : "Cancel";
            wzcMain.NextText = Language.Equals("VN") ? "Tiếp Tục >" : "Next >";
            wzcMain.FinishText = Language.Equals("VN") ? "Hoàn Tất" : "Finish";
            wzcMain.Text = Language.Equals("VN") ? "Trình hướng dẫn nhập dữ liệu từ file Excel" : "Wizard import data from Excel file";
            wwpStepOne.Text = Language.Equals("VN") ? "Chọn tệp dữ liệu Excel cần nhập" : "Choose Excel file want to import";
            wwpStepTwo.Text = Language.Equals("VN") ? "Quá trình thực hiện" : "Implementation process";
            wwpStepThree.Text = Language.Equals("VN") ? "Tóm tắt thông tin nhập liệu" : "Summary import information";
            logSelectedFiles.Text = Language.Equals("VN") ? "Tệp tin đã chọn từ máy tính" : "Selected files from your computer";
        }

        private DataTable CreateSeletedFileTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FileName", typeof(string));
            dt.Columns.Add("DateModified", typeof(DateTime));
            dt.Columns.Add("FileSize", typeof(string));
            dt.Columns.Add("FilePath", typeof(string));
            dt.Columns.Add("Note", typeof(string));
            dt.Columns.Add("IsValid", typeof(bool));
            dt.Columns.Add("SheetName", typeof(string));
            dt.Columns.Add("TableName", typeof(string));
            dt.Columns.Add("ColumnArray", typeof(string));

            return dt;
        }

        private void ShowDataTable(DataTable dt)
        {
            grvMainData.Columns.Clear();
            grvMainData.OptionsBehavior.AutoPopulateColumns = true;
            gridMainData.DataBindings.Clear();
            gridMainData.DataSource = dt;
            grvMainData.Columns["Return Message"].VisibleIndex = 0;
            grvMainData.Columns["Return Message"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            grvMainData.BestFitColumns();
        }

        private void ShowRequireColumn()
        {
            DataTable dt = busReport.LoadImportCaption("admin", "VN", strFunctionID, true);
            for (int i = 0; i < grvMainData.Columns.Count; i++)
            {
                string filter = string.Concat(new string[]{
                        " [Caption] = '" + grvMainData.Columns[i].FieldName.Trim() + "'"
                    });
                DataRow[] array = dt.Select(filter);
                if (array.Length > 0)
                {
                    if (Convert.ToBoolean(array[0]["IsRequire"]))
                        grvMainData.Columns[i].AppearanceHeader.ForeColor = Color.Red;
                }
            }
        }

        private void AddSelectedFile(string[] files)
        {
            FileInfo file;
            foreach (object item in files)
            {
                file = new FileInfo(item.ToString());
                if (file.Exists)
                {
                    if (dtSelectedFile.Select("FilePath='" + item + "'").Length == 0)
                        dtSelectedFile.Rows.Add(new object[] { file.Name, file.LastWriteTime, Commons.StrFormatByteSize(file.Length), file.FullName, "", false });
                }
            }
        }

        private void GetDataImport()
        {
            total_file = dtSelectedFile.Rows.Count;
            correct_file = dtSelectedFile.Select("IsValid=True").Length;
            invalid_file = total_file - correct_file;

            DataRow[] drDeleted = dtSelectedFile.Select("IsValid=False");
            foreach (DataRow dr in drDeleted)
            {
                dr.Delete();
            }
            dtSelectedFile.AcceptChanges();

            gluSeletedFiles.DataBindings.Clear();
            gluSeletedFiles.Properties.DataSource = dtSelectedFile;
            gluSeletedFiles.Properties.ValueMember = "TableName";
            gluSeletedFiles.Properties.DisplayMember = "FileName";
            if (dtSelectedFile.Rows.Count > 0) gluSeletedFiles.EditValue = dtSelectedFile.Rows[0]["TableName"];

            DataSet temp = new DataSet();
            string column_array = "";
            foreach (DataRow dr in dtSelectedFile.Rows)
            {
                column_array = "";
                Commons.GetDataExcel(ref mainData, strFunctionID, dr["FilePath"] + "", dr["TableName"] + "", dr["SheetName"] + "", ref column_array);
                dr["ColumnArray"] = column_array.Substring(0, column_array.Length - 1);
            }

            if (mainData.Tables.Count > 0)
            {
                ShowDataTable(mainData.Tables[gluSeletedFiles.EditValue + ""]);
                ShowRequireColumn();
            }
        }

        private bool CheckValidTemplateList()
        {
            if (dtSelectedFile.Rows.Count > 0)
            {
                DataRow[] dr = dtSelectedFile.Select("IsValid=True");
                if (dr != null && dr.Length > 0)
                    return true;
            }
            return false;
        }

        public uc_ImportExcel()
        {
            InitializeComponent();
            Initialize();
        }

        public uc_ImportExcel(string template_name, string store_procedure, string module_id, string function_id)
        {
            InitializeComponent();
            strTemplate = template_name;
            strStoreProcedute = store_procedure;
            strModuleID = module_id;
            strFunctionID = function_id;
            Initialize();
        }

        private void bteBrowseFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                string files = "";
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Microsoft Excel 2007 (*.xlsx)|*.xlsx|Microsoft Excel 97 - 2003 (*.xls)|*.xls";
                ofd.Title = User.UserInfo.LanguageID.Equals("VN") ? "Chọn tệp dữ liệu" : "Choose data file";
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                        files += file + ";";
                    bteBrowseFile.EditValue = files.Equals("") ? string.Empty : files.Substring(0, files.Length - 1);
                    bteBrowseFile.Properties.Buttons[1].Enabled = files.Equals("") ? false : true;
                }
            }
            else if (e.Button.Index == 1)
            {
                FileInfo file;
                foreach (string item in bteBrowseFile.EditValue.ToString().Split(';'))
                {
                    file = new FileInfo(item.ToString());
                    if (file.Exists)
                        if (dtSelectedFile.Select("FilePath='" + item + "'").Length == 0)
                            dtSelectedFile.Rows.Add(new object[] { file.Name, file.LastWriteTime, Commons.StrFormatByteSize(file.Length), file.FullName, "", false });
                }
                wwpStepOne.AllowNext = dtSelectedFile.Rows.Count > 0;
            }
        }

        private void gridSeletedFiles_DragDrop(object sender, DragEventArgs e)
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                FileInfo file;
                Object data = e.Data.GetData(DataFormats.FileDrop);
                
                foreach (object obj in (string[])data)
                {
                    file = new FileInfo(obj.ToString());
                    if (file.Exists)
                        if (dtSelectedFile.Select("FilePath='" + obj + "'").Length == 0)
                            dtSelectedFile.Rows.Add(new object[] { file.Name, file.LastWriteTime, Commons.StrFormatByteSize(file.Length), file.FullName, "" });
                }
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
            wwpStepOne.AllowNext = dtSelectedFile.Rows.Count > 0;
        }

        private void gridSeletedFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grvSeletedFiles_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void wzcMain_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            if (e.Page == wwpStepTwo && e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                if (!isClickCheckFile)
                {
                    Commons.ShowMessage(User.UserInfo.LanguageID.Equals("VN") ? "Hệ thống sẽ tự động kiểm tra tệp dữ liệu." : "System will automatically check data files.", 1);
                    btnCheckTemplate_Click(null, null);
                }
                if (isClickCheckFile)
                {
                    if (dtSelectedFile.Select("IsValid=False").Length > 0)
                    {
                        if (Commons.ShowConfirmMessage(User.UserInfo.LanguageID.Equals("VN") ? "Có tập tin bị lỗi, bạn có muốn tiếp tục không?" : "Having corrupted file, do you want to continue?"))
                        {
                            e.Cancel = false;
                            GetDataImport();
                        }
                        else e.Cancel = true;
                    }
                    else GetDataImport();
                }
            }
            else if (e.Page == wwpStepOne && e.Direction == DevExpress.XtraWizard.Direction.Backward)
            {
                if (XtraMessageBox.Show(User.UserInfo.LanguageID.Equals("VN") ? "Tất cả dữ liệu sẽ bị mất, bạn có muốn tiếp tục không?" : "All data will be lost, do you want to continue?", User.UserInfo.LanguageID.Equals("VN") ? "Thông Báo" : "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    mainData = new DataSet();
                    e.Cancel = false;
                }
                else e.Cancel = true;
            }
            else if (e.Page == wwpStepThree && e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                lblResult1.Text = User.UserInfo.LanguageID.Equals("VN") ? string.Format("Tổng số tập tin đã chọn: <b>{0}</b> tệp, trong đó có <b><color=RED>{1}</color></b> tệp tin lỗi, <b><color=GREEN>{2}</color></b> tệp tin hợp lệ.", total_file, invalid_file, correct_file) : string.Format("Total selected file: <b>{0}</b> file(s), including <b><color=RED>{1}</color></b> invalid file(s), <b><color=GREEN>{2}</color></b> valid file(s).", total_file, invalid_file, correct_file);

                total_row = inserted_row = updated_row = none_row = invalid_row = 0;
                foreach (DataTable dt in mainData.Tables)
                {
                    total_row += dt.Rows.Count;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["Return Message"].Equals("Inserted"))
                            inserted_row += 1;
                        else if (dr["Return Message"].Equals("Updated"))
                            updated_row += 1;
                        else if (string.IsNullOrEmpty(dr["Return Message"] + ""))
                            none_row += 1;
                        else invalid_row += 1;
                    }
                }

                lblResult2.Text = User.UserInfo.LanguageID.Equals("VN") ? string.Format("Tổng số dòng dữ liệu cần nhập: <b>{0}</b> dòng, trong đó:", total_row) : string.Format("Total row of data need to import: <b>{0}</b> rows, in which:", total_row);
                lblResult3.Text = User.UserInfo.LanguageID.Equals("VN") ? string.Format("Tổng số dòng dữ liệu đã thêm mới:") : string.Format("Total row of data inserted:");
                lblResult4.Text = User.UserInfo.LanguageID.Equals("VN") ? string.Format("Tổng số dòng dữ liệu đã cập nhật:") : string.Format("Total row of data updated");
                lblResult5.Text = User.UserInfo.LanguageID.Equals("VN") ? string.Format("Tổng số dòng dữ liệu bị lỗi:") : string.Format("Total row of faulty data:");
                lblResult6.Text = User.UserInfo.LanguageID.Equals("VN") ? string.Format("Tổng số dòng dữ liệu chưa nhập:") : string.Format("Total row of data not import:");
                lblSummary3.Text = User.UserInfo.LanguageID.Equals("VN") ? string.Format("<b><color=GREEN>{0}</color></b> dòng.", inserted_row) : string.Format("<b><color=GREEN>{0}</color></b> row(s).", inserted_row);
                lblSummary4.Text = User.UserInfo.LanguageID.Equals("VN") ? string.Format("<b><color=YELLOW>{0}</color></b> dòng.", updated_row) : string.Format("<b><color=YELLOW>{0}</color></b> row(s).", updated_row);
                lblSummary5.Text = User.UserInfo.LanguageID.Equals("VN") ? string.Format("<b><color=RED>{0}</color></b> dòng.", invalid_row) : string.Format("<b><color=RED>{0}</color></b> row(s).", invalid_row);
                lblSummary6.Text = User.UserInfo.LanguageID.Equals("VN") ? string.Format("<b>{0}</b> dòng.", none_row) : string.Format("<b>{0}</b> row(s).", none_row);
            }
        }

        private void grvSeletedFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (dtSelectedFile.Rows.Count > 0)
                if (e.KeyData == Keys.Delete)
                    dtSelectedFile.Rows.RemoveAt(grvSeletedFiles.FocusedRowHandle);
        }

        private void btnCheckTemplate_Click(object sender, EventArgs e)
        {
            Workbook wb;
            bool temp = false;
            foreach (DataRow dr in dtSelectedFile.Rows)
            {
                try
                {
                    if (new FileInfo(dr["FilePath"] + "").Exists)
                    {
                        wb = new Workbook(dr["FilePath"] + "");
                        temp = busImport.CheckValidTemplate("admin", "VN", strStoreProcedute, dr["FileName"] + "", strModuleID, strFunctionID, wb.Worksheets[0]);
                        if (!temp)
                        {
                            dr["IsValid"] = false;
                            dr["Note"] = "Invalid template!";
                        }
                        else
                        {
                            dr["IsValid"] = true;
                            dr["Note"] = "OK!";
                            dr["SheetName"] = wb.Worksheets[0].Name;
                            string tmp = dr["FileName"] + "";
                            tmp = tmp.Substring(0, tmp.LastIndexOf('.')).Replace(".", "").Replace("-", "").Replace(" ", "");
                            dr["TableName"] = tmp;
                        }
                    }
                    else
                    {
                        dr["IsValid"] = false;
                        dr["Note"] = "File not exists!";
                    }
                }
                catch (Exception ex)
                {
                    Commons.ShowExceptionMessage(ex);
                }
            }
            isClickCheckFile = true;
        }

        private void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            //Report.LoadReportCaption("admin", "VN", @"PRO\PRO_District_FileSelect.xlsx", strFunctionID);
            Report.LoadReportCaption(User.UserInfo.Username, User.UserInfo.LanguageID, string.Concat(new string[] { strModuleID, @"\", strTemplate }), strFunctionID);
        }

        private void gluSeletedFiles_EditValueChanged(object sender, EventArgs e)
        {
            if (mainData.Tables.Count > 0)
            {
                ShowDataTable(mainData.Tables[gluSeletedFiles.EditValue + ""]);
                ShowRequireColumn();
            }
        }

        private void grvMainData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void btnImportSelectedFile_Click(object sender, EventArgs e)
        {
            DataTable dt = busReport.LoadImportCaption(User.UserInfo.Username, User.UserInfo.LanguageID, strFunctionID, true);
            if (dt.Rows.Count > 0)
            {
                DataTable _dt = mainData.Tables[gluSeletedFiles.EditValue + ""];
                DataRow[] dr = dtSelectedFile.Select("TableName='" + gluSeletedFiles.EditValue + "'");
                if (dr.Length > 0)
                {
                    string tmp = dr[0]["ColumnArray"] + "";
                    if (tmp.Length > 0)
                    {
                        for (int i = 0; i < _dt.Rows.Count; i++)
                        {
                            _dt.Rows[i]["Return Message"] = busImport.ImportDataRow(User.UserInfo.Username, User.UserInfo.LanguageID, _dt.Rows[i], tmp, strStoreProcedute);
                        }
                    }
                    grvMainData.BestFitColumns();
                }
            }
        }

        private void btnImportAllFiles_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in dtSelectedFile.Rows)
            {
                DataTable dt = busReport.LoadImportCaption("admin", "VN", strFunctionID, true);
                if (dt.Rows.Count > 0)
                {
                    DataTable _dt = mainData.Tables[dr["TableName"] + ""];
                    string tmp = dr["ColumnArray"] + "";
                    if (tmp.Length > 0)
                    {
                        for (int i = 0; i < _dt.Rows.Count; i++)
                        {
                            _dt.Rows[i]["Return Message"] = busImport.ImportDataRow(User.UserInfo.Username, User.UserInfo.LanguageID, _dt.Rows[i], tmp, strStoreProcedute);
                        }
                    }
                    grvMainData.BestFitColumns();
                }
            }
        }
    }
}
