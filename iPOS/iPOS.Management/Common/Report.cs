using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Aspose.Cells;
using iPOS.BUS.System;
using iPOS.Core.Extension;
using iPOS.Core.Logger;

namespace iPOS.Management.Common
{
    public class Report
    {
        private static string Temp = @"D:\Softs\Hell Demons\iPOS\trunk\iPOS\iPOS.Management\Template";

        public static void SaveExportCustom(Workbook wb, string report_name)
        {
            try
            {
                SaveOptions saveOptions = new XlsSaveOptions(SaveFormat.Xlsx);
                wb.Worksheets.RemoveAt(wb.Worksheets.Count - 1);
                wb.Save(Temp + @"\" + report_name + "abc.xlsx", saveOptions);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return;
            }
        }

        public static void LoadReportCaption(string username, string language_id, string template, string function_id)
        {
            SYS_tblReportCaptionBUS busReport = new SYS_tblReportCaptionBUS();
            DataTable dt = busReport.LoadImportCaption(username, language_id, function_id, true);
            Workbook wb = new Workbook(Temp + string.Format(@"\{0}", template));
            Worksheet ws = wb.Worksheets[0];
            int index = 0;
            int count = wb.Worksheets.Count;
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    FindOptions opts = new FindOptions();
                    opts.LookInType = LookInType.Values;
                    opts.LookAtType = LookAtType.EntireContent;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Cell cell = ws.Cells.Find("$" + dt.Rows[i]["ControlID"].ToString() + "$", null, opts);
                        if (cell != null)
                        {
                            int column = cell.Column;
                            ws.Replace("$" + dt.Rows[i]["ControlID"].ToString() + "$", dt.Rows[i]["Caption"].ToString());
                            if (Convert.ToBoolean(dt.Rows[i]["IsList"]) && cell != null)
                            {
                                string tmp = "";
                                tmp = ws.Cells[cell.Row + 1, cell.Column].Value + "";
                                DataTable dt2 = busReport.LoadComboDynamicList(username, language_id, "", dt.Rows[i]["TableName"] + "", "Code");
                                index++;
                                if (dt2 != null && dt2.Rows.Count > 0)
                                {
                                    wb.Worksheets[index].Name = dt.Rows[i]["TableName"] + "";
                                    Worksheet ws1 = wb.Worksheets[index];
                                    ws1.Cells.ImportDataTable(dt2, true, 0, 0, true, false);
                                    Range range = ws1.Cells.CreateRange(1, 0, dt2.Rows.Count, 1);
                                    range.Name = tmp;
                                    for (int j = 0; j < dt2.Rows.Count; j++)
                                    {
                                        AsposeCellsStyle.Cells.BackgroundColor(ws1.Cells[0, j], Color.Yellow);
                                        AsposeCellsStyle.Cells.Font.Color(ws1.Cells[0, j], Color.Red);
                                    }
                                    ws1.AutoFitColumns();
                                }
                                CellArea cellArea;
                                cellArea.StartRow = 2;
                                cellArea.EndRow = ws.Cells.MaxRow;
                                cellArea.StartColumn = cell.Column;
                                cellArea.EndColumn = cell.Column;
                                ValidationCollection validations = ws.Validations;
                                Validation validation = validations[validations.Add(cellArea)];
                                validation.Type = ValidationType.List;
                                validation.Operator = OperatorType.None;
                                validation.InCellDropDown = true;
                                validation.Formula1 = "=" + tmp;
                                validation.ShowError = false;
                                validation.AreaList.Add(cellArea);
                            }
                        }
                        if (Convert.ToBoolean(dt.Rows[i]["IsRequire"]))
                            AsposeCellsStyle.Cells.Font.Color(cell, Color.Red);
                    }
                    SaveExportCustom(wb, "HellDemons");
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    return;
                }


            }
        }
    }
}
