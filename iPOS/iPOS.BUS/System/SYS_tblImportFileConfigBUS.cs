using System;
using System.Data;
using Aspose.Cells;
using iPOS.DAO.System;

namespace iPOS.BUS.System
{
    public class SYS_tblImportFileConfigBUS : BaseBUS
    {
        protected SYS_tblImportFileConfigDAO daoImport;

        public SYS_tblImportFileConfigBUS()
        {
            daoImport = new SYS_tblImportFileConfigDAO();
        }

        public bool CheckValidTemplate(string username, string language_id, string store_procedure, string file_name, string module_id, string function_id, string column_list)
        {
            return daoImport.CheckValidTemplate(username, language_id, store_procedure, file_name, module_id, function_id, column_list);
        }

        public bool CheckValidTemplate(string username, string language_id, string store_procedure, string file_name, string module_id, string function_id, Worksheet ws)
        {
            return daoImport.CheckValidTemplate(username, language_id, store_procedure, file_name, module_id, function_id, ws);
        }

        public string ImportDataRow(string username, string languge_id, DataRow data_row, string array_column, string store_procedure)
        {
            return daoImport.ImportDataRow(username, languge_id, data_row, array_column, store_procedure);
        }
    }
}
