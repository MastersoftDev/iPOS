using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTabbedMdi;
using iPOS.Core.Helper;
using iPOS.Core.Logger;
using iPOS.DTO.System;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.OleDb;
using Aspose.Cells;

namespace iPOS.Management.Common
{
    public class Common
    {
        public static CultureInfo Culture;
        public static ResourceManager ResourceMessage = new ResourceManager("iPOS.Management.Language.Message", typeof(frmMain).Assembly);
        public static ResourceManager ResourceLanguage = new ResourceManager("iPOS.Management.Language.Language", typeof(frmMain).Assembly);

        public static void ShowMessage(string _message, byte _type)
        {
            string _title = "";
            if (_type == 0) _title = (new Configuration().Language.Equals("vi-VN")) ? "Thông Báo Lỗi" : "Error Message";
            else _title = (new Configuration().Language.Equals("vi-VN")) ? "Thông Báo" : "Message";

            if (_type == 0) Logger.Error(_message);
            XtraMessageBox.Show(_message, _title, MessageBoxButtons.OK, (_type == 0) ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        public static void ShowExceptionMessage(Exception ex)
        {
            Logger.Error(ex);
            XtraMessageBox.Show(ex.Message, (new Configuration().Language.Equals("vi-VN")) ? "Lỗi Hệ Thống" : "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool ShowConfirmMessage(string _message)
        {
            if (XtraMessageBox.Show(_message, (new Configuration().Language.Equals("vi-VN")) ? "Thông Báo" : "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                return true;
            return false;
        }

        public static void OpenForm(frmMain index, XtraUserControl uc, string name)
        {
            XtraForm frm = new XtraForm();
            frm.Text = name;
            frm.MdiParent = index;
            uc.Dock = DockStyle.Fill;
            frm.Controls.Clear();
            frm.Controls.Add(uc);
            frm.Show();
        }

        public static void OpenForm(frmMain index, XtraUserControl uc, string vnTitle, string enTitle, XtraTabbedMdiManager tabMain)
        {
            string languageID = new Configuration().Language;
            bool found = false;
            foreach (XtraForm frm in index.MdiChildren)
            {
                if (frm.Text.Equals((languageID.Equals("vi-VN")) ? vnTitle : enTitle))
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                foreach (XtraMdiTabPage tab in tabMain.Pages)
                {
                    if (tab.Text.Equals((languageID.Equals("vi-VN")) ? vnTitle : enTitle))
                    {
                        tabMain.SelectedPage = tab;
                        break;
                    }
                }
            }
            else
            {
                XtraForm frm = new XtraForm();
                frm.Text = (languageID.Equals("vi-VN")) ? vnTitle : enTitle;
                frm.MdiParent = index;
                uc.Dock = DockStyle.Fill;
                frm.Controls.Clear();
                frm.Controls.Add(uc);
                frm.Show();
            }
        }

        public static void OpenInputForm(XtraUserControl uc, string vnTitle, string enTitle, Size size)
        {
            string languageID = new Configuration().Language;
            frmOpen frm = new frmOpen();
            frm.Text = (languageID.Equals("vi-VN")) ? vnTitle : enTitle;
            frm.Size = size;
            frm.MaximumSize = size;
            frm.MinimumSize = size;
            frm.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            frm.Controls.Add(uc);
            uc.Show();
            frm.ShowDialog();
        }

        public static void OpenImportForm(string template, string store_procedure, string module_id, string function_id)
        {
            OpenInputForm(new iPOS.Management.Common.uc_ImportExcel(template, store_procedure, module_id, function_id), "Nhập dữ liệu từ tập tin Excel", "Import data from Excel files", new System.Drawing.Size(900, 600));
        }

        private static void SetDisplayString(BarStaticItem item, string value, int type)
        {
            Configuration config = new Configuration();
            string result = "";
            switch (type)
            {
                case 0: result = (config.Language.Equals("vi-VN")) ? "Người tạo: " : "Creater: "; break;
                case 1: result = (config.Language.Equals("vi-VN")) ? "Giờ tạo: " : "Create time: "; break;
                case 2: result = (config.Language.Equals("vi-VN")) ? "Người cập nhật: " : "Editer: "; break;
                default: result = (config.Language.Equals("vi-VN")) ? "Ngày cập nhật: " : "Edit time: "; break;
            }

            item.Caption = result + "<b><color=RED>" + value + "</color></b>";
            if (string.IsNullOrEmpty(value))
                item.Visibility = BarItemVisibility.Never;
            else item.Visibility = BarItemVisibility.Always;
        }

        public static void SetDislayStringArray(BarStaticItem[] items, string[] objs)
        {
            for (int i = items.Length - 1; i >= 0; i--)
                SetDisplayString(items[i], objs[i], i);
        }

        public static DataTable GetDataTableAfterFilter(GridControl _grid, GridView _gridview)
        {
            try
            {
                DataTable _source = _grid.DataSource as DataTable;
                DataView _filter = new DataView(_source);
                _filter.RowFilter = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(_gridview.ActiveFilterCriteria);
                _source = _filter.ToTable();
                return _source;
            }
            catch { return null; }
        }

        public static void ExportData(DataTable _dt, GridView _grid)
        {
            if (_dt != null && _dt.Rows.Count > 0)
            {
                SaveFileDialog sDialog = new SaveFileDialog();
                sDialog.Filter = "Microsoft Excel (*.xls)|*.xls|Microsoft Excel 2007 (*.xlsx)|*.xlsx|PDF (*.pdf)|*.pdf|Rich Text Format (*.rtf)|*.rtf|Webpage (*.html)|*.html|Rich Text File (*.rtf)|*.rtf|Text File (*.txt)|*.txt";
                sDialog.Title = Lang.GetMessageByLanguage("000007", Culture, ResourceMessage);
                if (sDialog.ShowDialog() == DialogResult.OK)
                {
                    switch (sDialog.FilterIndex)
                    {
                        case 1:
                            _grid.ExportToXls(sDialog.FileName);
                            break;
                        case 2:
                            _grid.ExportToXlsx(sDialog.FileName);
                            break;
                        case 3:
                            _grid.ExportToPdf(sDialog.FileName);
                            break;
                        case 4:
                            _grid.ExportToText(sDialog.FileName);
                            break;
                        case 5:
                            _grid.ExportToHtml(sDialog.FileName);
                            break;
                        case 6:
                            _grid.ExportToRtf(sDialog.FileName);
                            break;
                        case 7:
                            _grid.ExportToText(sDialog.FileName);
                            break;
                    }
                    if (XtraMessageBox.Show(Lang.GetMessageByLanguage("000006", Culture, ResourceMessage).Replace("$FileName$", sDialog.FileName), (User.UserInfo.LanguageID.Equals("VN")) ? "Thông Báo" : "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Process.Start(sDialog.FileName);
                    }
                }
            }
            else
            {
                return;
            }
        }

        public static void QuickExportData(GridControl grid, GridView grv)
        {
            ExportData(GetDataTableAfterFilter(grid, grv), grv);
        }

        public static bool CheckEmailValid(string strEmail)
        {
            Regex re = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (re.IsMatch(strEmail))
                return true;
            else
                return false;
        }

        [DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
        public static extern long StrFormatByteSize(long fileSize, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer, int bufferSize);
        public static string StrFormatByteSize(long filesize)
        {
            StringBuilder sb = new StringBuilder(11);
            StrFormatByteSize(filesize, sb, sb.Capacity);
            return sb.ToString();
        }

        public static int GetEndColumn(Worksheet ws)
        {
            int num = 0;
            while (true)
            {
                string temp = "";
                temp = (ws.Cells[1, num].Value == null) ? "" : ws.Cells[1, num].Value + "";
                if (temp == "")
                    break;

                num++;
            }

            return num;
        }

        public static int GetEndRow(Worksheet ws)
        {
            int num = 2;
            while (true)
            {
                string temp = "";
                temp = (ws.Cells[num, 0].Value == null) ? "" : ws.Cells[num, 0].Value + "";
                if (temp == "")
                    break;

                num++;
            }

            return num;
        }

        public static void GetDataExcel(ref DataSet ds, string file_path, string table_name, string sheet_name)
        {
            string connection_string = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file_path + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
            OleDbDataAdapter ole_adapter;
            try
            {
                ole_adapter = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}$]", sheet_name), connection_string);
                ole_adapter.Fill(ds, table_name);
                ole_adapter.Dispose();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public static string GetDataExcel(ref DataSet ds, string function_id, string file_path, string table_name, string sheet_name, ref string column_array)
        {
            string result = "", temp1="", temp2="";
            try
            {
                if (!File.Exists(file_path))
                {
                    result = "File not exists!";
                }
                else
                {
                    Workbook wb = new Workbook(file_path);
                    Worksheet ws = wb.Worksheets[sheet_name];
                    DataTable dt = new DataTable();
                    dt.TableName = table_name;
                    int endCol = GetEndColumn(ws);
                    int endRow = GetEndRow(ws);

                    try
                    {
                        for (int i = 1; i < endCol; i++)
                        {
                            string temp3 = "";
                            if (ws.Cells[0, i].Value != null)
                            {
                                temp3 = ws.Cells[0, i].Value.ToString().Trim();
                                if (temp1.IndexOf(temp3 + "#") > 0)
                                    temp2 = "Trùng header: " + temp3;
                                temp1 += temp3 + "#";
                            }
                            dt.Columns.Add(new DataColumn(temp3, typeof(string)));
                        }
                        dt.Columns.Add(new DataColumn("Return Message", typeof(string)));

                        for (int j = 1; j < endRow; j++)
                        {
                            DataRow dr = dt.NewRow();
                            for (int i = 1; i < endCol; i++)
                            {
                                string value = (ws.Cells[j, i].Value == null) ? "" : ws.Cells[j, i].Value.ToString().Trim();
                                if (j == 1) column_array += value + "#";
                                if (ws.Cells[j, i].Value != null && ws.Cells[j, i].Value.GetType().Equals(typeof(DateTime)))
                                    value = ((DateTime)ws.Cells[j, i].Value).ToString("dd/MM/yyyy");
                                dr[i - 1] = value;
                            }

                            if (j > 1) dt.Rows.Add(dr);
                        }

                        int num = 0;
                        while (ws.Cells.Find("$HideColumn$", null, new FindOptions { LookInType = LookInType.Values, LookAtType = LookAtType.EntireContent }) != null)
                        {
                            Cell cell = ws.Cells.Find("$HideColumn$", null, new FindOptions { LookInType = LookInType.Values, LookAtType = LookAtType.EntireContent });
                            dt.Columns.RemoveAt(cell.Column - num);
                            cell.PutValue("");
                            num++;
                        }

                        ds.Tables.Add(dt);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex);
                        result = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                result = ex.Message;
            }

            return result;
        }

        public static byte[] ConvertImageToByte(PictureEdit picture_edit)
        {
            byte[] _array_byte = null;
            if (picture_edit.EditValue == null)
                return null;
            try
            {
                MemoryStream _ms = new MemoryStream();
                picture_edit.Image.Save(_ms, System.Drawing.Imaging.ImageFormat.Png);
                _array_byte = new byte[_ms.Length];
                _ms.Position = 0;
                _ms.Read(_array_byte, 0, Convert.ToInt32(_ms.Length));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }

            return _array_byte;
        }
    }
}
