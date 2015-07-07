using System;
using System.Data;
using Aspose.Cells;

namespace iPOS.DAO.System
{
    public class SYS_tblImportFileConfigDAO : BaseDAO
    {
        public bool CheckValidTemplate(string username, string language_id, string store_procedure, string file_name, string module_id, string function_id, string column_list)
        {
            bool result = false;
            DataRow dr = db.GetDataRow("SYS_spfrmImportFileConfig", new string[] { "Activity", "Username", "LanguageID", "ExcelFile", "FunctionID", "ModuleID" }, new object[] { "CheckValidTemplate", username, language_id, file_name, function_id, module_id });
            if (dr != null)
                result = true;
            else
            {
                DataTable dt = db.GetDataTable("SYS_spCommon", new string[] { "ObjectName" }, new object[] { store_procedure });
                if (dt != null && dt.Rows.Count > 0)
                {
                    string[] columns = column_list.Trim(new char[] { '$' }).Split('$');
                    int count = 0;
                    for (int i = 0; i < columns.Length; i++)
                    {
                        if (columns.GetValue(i).ToString().Trim() != "")
                        {
                            DataRow[] rows = dt.Select("ColumnName = '@" + columns.GetValue(i).ToString().Trim() + "'");
                            if (rows != null && rows.Length == 0)
                                count++;
                        }
                    }

                    result = (count < 3);
                }
                else result = false;
            }

            return result;
        }

        public bool CheckValidTemplate(string username, string language_id, string store_procedure, string file_name, string module_id, string function_id, Worksheet ws)
        {
            bool result = false;
            DataRow dr = db.GetDataRow("SYS_spfrmImportFileConfig", new string[] { "Activity", "Username", "LanguageID", "ExcelFile", "FunctionID", "ModuleID" }, new object[] { "CheckValidTemplate", username, language_id, file_name, function_id, module_id });
            if (dr != null)
                result = true;
            else
            {
                DataTable dt = db.GetDataTable("SYS_spCommon", new string[] { "ObjectName" }, new object[] { store_procedure });
                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = 0;
                    for (int i = 0; i < ws.Cells.MaxColumn; i++)
                    {
                        if (string.IsNullOrEmpty(ws.Cells[1, i].Value + ""))
                            break;
                        string tmp = ws.Cells[1, i].Value.ToString().ToLower().Trim();
                        if (string.IsNullOrEmpty(tmp))
                            break;
                        if (tmp != "stt" && tmp != "$hidecolumn$" && tmp != "$deletecolumn$")
                        {
                            DataRow[] rows = dt.Select("ColumnName='@" + tmp + "'");
                            if (rows.Length == 0) count++;
                        }
                    }
                    result = (count < 3);
                }
                else result = false;
            }

            return result;
        }

        public string ImportDataRow(string username, string languge_id, DataRow data_row, string array_column, string store_procedure)
        {
            string strError = "";
            string[] columns = { };
            columns = array_column.Trim().Split('#');
            string[] parameters = new string[columns.Length + 2];
            object[] values = new string[columns.Length + 2];
            if (data_row != null && columns.Length > 0)
            {
                parameters[0] = "Username";
                parameters[1] = "LanguageID";
                values[0] = username;
                values[1] = languge_id;
                for (int i = 0; i < columns.Length; i++)
                {
                    parameters[i + 2] = columns[i];
                    values[i + 2] = data_row[i];
                }

                strError = db.sExecuteSQL(store_procedure, parameters, values);
            }

            return strError;
        }
    }
}
