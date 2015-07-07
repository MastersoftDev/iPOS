using iPOS.DTO.System;
using System;
using System.Collections.Generic;
using System.Data;

namespace iPOS.DAO.System
{
    public class SYS_tblGroupUserDAO : BaseDAO
    {
        public DataTable LoadAllData(string username, string language_id)
        {
            SYS_tblActionLogDTO log = new SYS_tblActionLogDTO();
            log.Activity = "Insert";
            log.Username = username;
            log.LanguageID = language_id;
            log.ActionVN = "Tải Tất Cả Dữ Liệu";
            log.ActionEN = "Load All Data";
            log.FunctionID = "9";
            log.DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu nhóm người dùng.", username);
            log.DescriptionEN = string.Format("Account '{0}' downloaded successfully data of group users.", username);
            this.InsertActionLog(log);

            return db.GetDataTable("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID" }, new object[] { "LoadAllData", log.Username, log.LanguageID });
        }

        public SYS_tblGroupUserDTO GetDataByID(string group_id, string username, string language_id)
        {
            DataRow dr = db.GetDataRow("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupID" }, new object[] { "GetDataByID", username, language_id, group_id });
            SYS_tblGroupUserDTO result = new SYS_tblGroupUserDTO();
            if (dr != null)
            {
                result.GroupID = dr["GroupID"] + "";
                result.GroupCode = dr["GroupCode"] + "";
                result.GroupName = dr["GroupName"] + "";
                result.Note = dr["Note"] + "";
                result.IsDefault = Convert.ToBoolean(dr["IsDefault"]);
                result.Active = Convert.ToBoolean(dr["Active"]);
                result.IsRoot = Convert.ToBoolean(dr["IsRoot"]);

                return result;
            }

            return null;
        }

        public List<SYS_tblGroupUserDTO> GetDataCombobox(string username, string language_id)
        {
            List<SYS_tblGroupUserDTO> result = new List<SYS_tblGroupUserDTO>();
            DataTable dt = db.GetDataTable("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID" }, new object[] { "GetDataCombobox", username, language_id });
            foreach (DataRow dr in dt.Rows)
            {
                result.Add(new SYS_tblGroupUserDTO
                {
                    GroupID = dr["GroupID"] + "",
                    GroupCode = dr["GroupCode"] + "",
                    GroupName = dr["GroupName"] + "",
                    IsDefault = Convert.ToBoolean(dr["IsDefault"]),
                    Note = dr["Note"] + ""
                });
            }

            return result;
        }

        public string GetDefaultGroup(string username, string language_id)
        {
            DataRow dr = db.GetDataRow("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID" }, new object[] { "GetDefaultGroup", username, language_id });
            if (dr != null)
            {
                return dr["GroupID"] + "";
            }
            return "";
        }

        public string InsertGroupUser(SYS_tblGroupUserDTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupCode", "GroupName", "Note", "Active", "IsDefault", "IsRoot" }, new object[] { item.Activity, item.Username, item.LanguageID, item.GroupCode, item.GroupName, item.Note, item.Active, item.IsDefault, item.IsRoot });
            if (strError.Equals(""))
            {
                SYS_tblActionLogDTO log = new SYS_tblActionLogDTO();
                log.Activity = item.Activity;
                log.Username = item.Username;
                log.LanguageID = item.LanguageID;
                log.ActionVN = "Thêm Mới";
                log.ActionEN = "Insert";
                log.FunctionID = "9";
                log.DescriptionVN = string.Format("Tài khoản '{0}' vừa thêm mới thành công nhóm người dùng có mã '{1}'.", item.Username, item.GroupCode);
                log.DescriptionEN = string.Format("Account '{0}' has inserted new group user successfully with group code is '{1}'.", item.Username, item.GroupCode);
                strError = this.InsertActionLog(log);
            }

            return strError;
        }

        public string UpdateGroupUser(SYS_tblGroupUserDTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupID", "GroupCode", "GroupName", "Note", "Active", "IsDefault", "IsRoot" }, new object[] { item.Activity, item.Username, item.LanguageID, item.GroupID, item.GroupCode, item.GroupName, item.Note, item.Active, item.IsDefault, item.IsRoot });
            if (strError.Equals(""))
            {
                SYS_tblActionLogDTO log = new SYS_tblActionLogDTO();
                log.Activity = "Insert";
                log.Username = item.Username;
                log.LanguageID = item.LanguageID;
                log.ActionVN = "Cập Nhật";
                log.ActionEN = "Update";
                log.FunctionID = "9";
                log.DescriptionVN = string.Format("Tài khoản '{0}' vừa cập nhật thành công nhóm người dùng có mã '{1}'.", item.Username, item.GroupCode);
                log.DescriptionEN = string.Format("Account '{0}' has updated group user successfully with group code is '{1}'.", item.Username, item.GroupCode);
                strError = this.InsertActionLog(log);
            }

            return strError;
        }

        public string DeleteGroupUser(string group_id, string group_code, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupID" }, new object[] { "Delete", username, language_id, group_id });
            if (strError.Equals(""))
            {
                SYS_tblActionLogDTO log = new SYS_tblActionLogDTO();
                log.Activity = "Insert";
                log.Username = username;
                log.LanguageID = language_id;
                log.ActionVN = "Xóa";
                log.ActionEN = "Delete";
                log.FunctionID = "9";
                log.DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công nhóm người dùng có mã '{1}'.", username, group_code);
                log.DescriptionEN = string.Format("Account '{0}' has deleted group user successfully with group code is '{1}'.", username, group_code);
                strError = this.InsertActionLog(log);
            }

            return strError;
        }

        public string DeleteListGroupUser(string group_id_list, string group_code_list, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupIDList" }, new object[] { "DeleteList", username, language_id, group_id_list });
            if (strError.Equals(""))
            {
                SYS_tblActionLogDTO log = new SYS_tblActionLogDTO();
                log.Activity = "Insert";
                log.Username = username;
                log.LanguageID = language_id;
                log.ActionVN = "Xóa";
                log.ActionEN = "Delete";
                log.FunctionID = "9";
                log.DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công nhóm người dùng có mã '{1}'.", username, group_code_list.Replace("$", ", "));
                log.DescriptionEN = string.Format("Account '{0}' has deleted group user successfully with group code are '{1}'.", username, group_code_list.Replace("$", ", "));
                strError = this.InsertActionLog(log);
            }

            return strError;
        }
    }
}
