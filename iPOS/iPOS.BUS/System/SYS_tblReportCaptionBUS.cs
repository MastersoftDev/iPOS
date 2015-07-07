using System;
using System.Data;
using iPOS.DAO.System;

namespace iPOS.BUS.System
{
    public class SYS_tblReportCaptionBUS : BaseBUS
    {
        protected SYS_tblReportCaptionDAO daoReportCaption;

        public SYS_tblReportCaptionBUS()
        {
            daoReportCaption = new SYS_tblReportCaptionDAO();
        }

        public DataTable LoadImportCaption(string username, string language_id, string function_id, bool is_import)
        {
            return daoReportCaption.LoadImportCaption(username, language_id, function_id, is_import);
        }

        public DataTable LoadComboDynamicList(string username, string language_id, string code, string table_name, string get_by)
        {
            return daoReportCaption.LoadComboDynamicList(username, language_id, code, table_name, get_by);
        }
    }
}
