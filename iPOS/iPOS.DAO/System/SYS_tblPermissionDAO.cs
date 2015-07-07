using iPOS.DTO.System;
using System;
using System.Data;

namespace iPOS.DAO.System
{
    public class SYS_tblPermissionDAO : BaseDAO
    {
        public SYS_tblPermissionDTO GetPermissionByFunction(string username, string language_id, string function_id, string userName)
        {
            DataRow dr = db.GetDataRow("SYS_spfrmPermission", new string[] { "Activity", "Username", "LanguageID", "UsernameOther", "FunctionID" }, new object[] { "GetPermissionByFunction", username, language_id, userName, function_id });
            if (dr != null)
            {
                return new SYS_tblPermissionDTO
                {
                    UserName = dr["Username"] + "",
                    FunctionID = dr["FunctionID"] + "",
                    AllowInsert = Convert.ToBoolean(dr["AllowInsert"]),
                    AllowUpdate = Convert.ToBoolean(dr["AllowUpdate"]),
                    AllowDelete = Convert.ToBoolean(dr["AllowDelete"]),
                    AllowAccess = Convert.ToBoolean(dr["AllowAccess"]),
                    AllowPrint = Convert.ToBoolean(dr["AllowPrint"]),
                    AllowImport = Convert.ToBoolean(dr["AllowImport"]),
                    AllowExport = Convert.ToBoolean(dr["AllowExport"]),
                    UserLevelID = dr["UserLevelID"] + "",
                    Note = dr["UserLevelID"] + ""
                };
            }

            return null;
        }

        public DataTable GetDataByGroupOrUser(string username, string language_id, string id, string parent_id, int type)
        {
            string strParameter = "", strActivity = "";
            strParameter = (type == 0) ? "GroupID" : "UsernameOther";
            strActivity = (type == 0) ? "GetDataByGroupUser" : "GetDataByUser";

            return db.GetDataTable("SYS_spfrmPermission", new string[] { "Activity", "Username", "LanguageID", strParameter, "FunctionID" }, new object[] { strActivity, username, language_id, id, parent_id });
        }

        public string SavePermission(SYS_tblPermissionDTO item, int type)
        {
            string strParameter = "", strActivity = "", strValue = "";
            strParameter = (type == 0) ? "GroupID" : "UsernameOther";
            strActivity = (type == 0) ? "UpdateGroupUserPermission" : "UpdateUserPermission";
            strValue = (type == 0) ? item.GroupID : item.UserName;

            return db.sExecuteSQL("SYS_spfrmPermission", new string[] { "Activity", "Username", "LanguageID", strParameter, "FunctionID", "AllowInsert", "AllowUpdate", "AllowDelete", "AllowAccess", "AllowPrint", "AllowImport", "AllowExport", "UserLevelID", "Note" }, new object[] { strActivity, item.Username, item.LanguageID, strValue, item.FunctionID, item.AllowInsert, item.AllowUpdate, item.AllowDelete, item.AllowAccess, item.AllowPrint, item.AllowImport, item.AllowExport, item.UserLevelID, item.Note });
        }
    }
}
