using System;
using System.Data;
using iPOS.Core.Logger;

namespace iPOS.DAO.System
{
    public class SYS_tblReportCaptionDAO : BaseDAO
    {
        public DataTable LoadImportCaption(string username, string language_id, string function_id, bool is_import)
        {
            try
            {
                return db.GetDataTable("SYS_spfrmReportCaption", new string[] { "Activity", "Username", "LanguageID", "FunctionID", "IsImport" }, new object[] { "LoadImportCaption", username, language_id, function_id, is_import });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public DataTable LoadComboDynamicList(string username, string language_id, string code, string table_name, string get_by)
        {
            try
            {
                return db.GetDataTable("SYS_spfrmComboDynamic", new string[] { "Username", "LanguageID", "Code", "TableName", "GetBy" }, new object[] { username, language_id, code, table_name, get_by });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }
    }
}
