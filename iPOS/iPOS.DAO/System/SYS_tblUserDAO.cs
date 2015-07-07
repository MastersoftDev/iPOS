using iPOS.Core.Helper;
using iPOS.Core.SQLServer;
using iPOS.DTO.System;
using System;
using System.Data;

namespace iPOS.DAO.System
{
    public class SYS_tblUserDAO : BaseDAO
    {
        public DataTable LoadAllData(string username, string language_id)
        {
            SYS_tblActionLogDTO log = new SYS_tblActionLogDTO();
            log.Activity = "Insert";
            log.Username = username;
            log.LanguageID = language_id;
            log.ActionVN = "Tải Tất Cả Dữ Liệu";
            log.ActionEN = "Load All Data";
            log.FunctionID = "10";
            log.DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu người dùng.", username);
            log.DescriptionEN = string.Format("Account '{0}' downloaded successfully data of users.", username);
            this.InsertActionLog(log);

            return db.GetDataTable("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID" }, new object[] { "LoadAllData", log.Username, log.LanguageID });
        }

        public DataTable LoadAllData(string username, string language_id, string group_id)
        {
            SYS_tblActionLogDTO log = new SYS_tblActionLogDTO();
            log.Activity = "Insert";
            log.Username = username;
            log.LanguageID = language_id;
            log.ActionVN = "Tải Tất Cả Dữ Liệu";
            log.ActionEN = "Load All Data";
            log.FunctionID = "10";
            log.DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu người dùng.", username);
            log.DescriptionEN = string.Format("Account '{0}' downloaded successfully data of users.", username);
            this.InsertActionLog(log);

            return db.GetDataTable("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "GroupID" }, new object[] { "LoadAllData", log.Username, log.LanguageID, group_id });
        }

        public SYS_tblUserDTO GetDataByID(string userName, string username, string language_id)
        {
            DataRow dr = db.GetDataRow("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "UsernameOther" }, new object[] { "GetDataByID", username, language_id, userName });
            if (dr != null)
            {
                return new SYS_tblUserDTO
                {
                    UserName = dr["Username"] + "",
                    Password = dr["Password"] + "",
                    GroupID = dr["GroupID"] + "",
                    EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]),
                    ToDate = dr["ToDate"],
                    DateChangePass = dr["DateChangePass"],
                    Locked = Convert.ToBoolean(dr["Locked"]),
                    LockDate = dr["LockDate"],
                    UnlockDate = dr["UnlockDate"],
                    PassNeverExpired = Convert.ToBoolean(dr["PassNeverExpired"]),
                    ChangePassNextTime = Convert.ToBoolean(dr["ChangePassNextTime"]),
                    EmpID = dr["EmpID"] + "",
                    FullName = dr["FullName"] + "",
                    IsSystemAdmin = Convert.ToBoolean(dr["IsSystemAdmin"]),
                    CanNotChangePassword = Convert.ToBoolean(dr["CanNotChangePassword"]),
                    Email = dr["Email"] + "",
                    Note = dr["Note"] + ""
                };
            }

            return null;
        }

        public string InsertUser(SYS_tblUserDTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "UsernameOther", "Password", "GroupID", "EffectiveDate", "ToDate", "DateChangePass", "Locked", "LockDate", "UnlockDate", "PassNeverExpired", "ChangePassNextTime", "EmpID", "FullName", "CanNotChangePassword", "Email", "Note" }, new object[] { item.Activity, item.Username, item.LanguageID, item.UserName, item.Password, item.GroupID, item.EffectiveDate, item.ToDate, item.DateChangePass, item.Locked, item.LockDate, item.UnlockDate, item.PassNeverExpired, item.ChangePassNextTime, item.EmpID, item.FullName, item.CanNotChangePassword, item.Email, item.Note });
            if (strError.Equals(""))
            {
                SYS_tblActionLogDTO log = new SYS_tblActionLogDTO();
                log.Activity = item.Activity;
                log.Username = item.Username;
                log.LanguageID = item.LanguageID;
                log.ActionVN = "Thêm Mới";
                log.ActionEN = "Insert";
                log.FunctionID = "10";
                log.DescriptionVN = string.Format("Tài khoản '{0}' vừa thêm mới thành công người dùng có tên tài khoản '{1}'.", item.Username, item.UserName);
                log.DescriptionEN = string.Format("Account '{0}' has inserted new user successfully with username is '{1}'.", item.Username, item.UserName);
                strError = this.InsertActionLog(log);
            }

            return strError;
        }

        public string UpdateUser(SYS_tblUserDTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "UsernameOther", "GroupID", "EffectiveDate", "ToDate", "DateChangePass", "Locked", "LockDate", "UnlockDate", "PassNeverExpired", "ChangePassNextTime", "EmpID", "FullName", "CanNotChangePassword", "Email", "Note" }, new object[] { item.Activity, item.Username, item.LanguageID, item.UserName, item.GroupID, item.EffectiveDate, item.ToDate, item.DateChangePass, item.Locked, item.LockDate, item.UnlockDate, item.PassNeverExpired, item.ChangePassNextTime, item.EmpID, item.FullName, item.CanNotChangePassword, item.Email, item.Note });
            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = item.Username,
                    LanguageID = item.LanguageID,
                    ActionVN = "Cập Nhật",
                    ActionEN = "Update",
                    FunctionID = "10",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa cập nhật thành công người dùng có tên tài khoản '{1}'.", item.Username, item.UserName),
                    DescriptionEN = string.Format("Account '{0}' has updated user successfully with username is '{1}'.", item.Username, item.UserName)
                });
            }

            return strError;
        }

        public string DeleteUser(string userName, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "UsernameOther" }, new object[] { "Delete", username, language_id, userName });
            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "10",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công người dùng có tên tài khoản '{1}'.", username, userName),
                    DescriptionEN = string.Format("Account '{0}' has deleted user successfully with username is '{1}'.", username, userName)
                });
            }

            return strError;
        }

        public string DeleteListUser(string userList, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "UsernameList" }, new object[] { "DeleteList", username, language_id, userList });
            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "10",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công người dùng có tên tài khoản '{1}'.", username, userList.Replace("$", ", ")),
                    DescriptionEN = string.Format("Account '{0}' has deleted user successfully with username are '{1}'.", username, userList.Replace("$", ", "))
                });
            }

            return strError;
        }

        public SYS_tblUserDTO CheckLogin(string username, string password)
        {
            DataRow _dr = db.GetDataRow("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "Password" }, new object[] { "CheckLogin", username, new Configuration().Language, password });
            if (_dr != null)
            {
                return new SYS_tblUserDTO
                {
                    Username = _dr["Username"] + "",
                    Password = _dr["Password"] + "",
                    Locked = Convert.ToBoolean(_dr["Locked"]),
                    IsSystemAdmin = Convert.ToBoolean(_dr["IsSystemAdmin"]),
                    GroupName = _dr["GroupName"] + ""
                };
            }

            return null;
        }

        public string ChangePassword(string username, string language_id, string password)
        {
            string strError = "";
            strError = db.sExecuteSQL("SYS_spfrmUser", new string[] { "Activity", "Username", "LanguageID", "Password" }, new object[] { "ChangePassword", username, language_id, password });
            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Đổi Mật Khẩu",
                    ActionEN = "Change Password",
                    FunctionID = "",
                    FunctionNameVN = "Đổi Mật Khẩu",
                    FunctionNameEN = "Change Password",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa đổi mật khẩu thành công vào lúc {1}.", username, DateTime.Now),
                    DescriptionEN = string.Format("Account '{0}' has change password successfully at {1}.", username, DateTime.Now)
                });
            }

            return strError;
        }
    }
}
