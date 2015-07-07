using iPOS.DTO.Product;
using iPOS.DTO.System;
using System;
using System.Data;

namespace iPOS.DAO.Product
{
    public class PRO_tblProvinceDAO : BaseDAO
    {
        public DataTable LoadAllData(string username, string language_id)
        {
            this.InsertActionLog(new SYS_tblActionLogDTO
            {
                Activity = "Insert",
                Username = username,
                LanguageID = language_id,
                ActionVN = "Tải Tất Cả Dữ Liệu",
                ActionEN = "Load All Data",
                FunctionID = "8",
                DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu tỉnh thành.", username),
                DescriptionEN = string.Format("Account '{0}' downloaded successfully data of provinces.", username)
            });

            return db.GetDataTable("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID" }, new object[] { "LoadAllData", username, language_id });
        }

        public DataTable GetDataCombobox(string username, string language_id)
        {
            return db.GetDataTable("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID" }, new object[] { "GetDataCombobox", username, language_id });
        }

        public PRO_tblProvinceDTO GetDataByID(string province_id, string username, string language_id)
        {
            DataRow dr = db.GetDataRow("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID", "ProvinceID" }, new object[] { "GetDataByID", username, language_id, province_id });
            if (dr != null)
            {
                return new PRO_tblProvinceDTO
                {
                    ProvinceID = dr["ProvinceID"] + "",
                    ProvinceCode = dr["ProvinceCode"] + "",
                    VNName = dr["VNName"] + "",
                    ENName = dr["ENName"] + "",
                    Rank = dr["Rank"],
                    Used = Convert.ToBoolean(dr["Used"]),
                    Note = dr["Note"] + ""
                };
            }

            return null;
        }

        public string InsertProvince(PRO_tblProvinceDTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID", "ProvinceCode", "VNName", "ENName", "Rank", "Used", "Note" }, new object[] { item.Activity, item.Username, item.LanguageID, item.ProvinceCode, item.VNName, item.ENName, item.Rank, item.Used, item.Note });
            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = item.Activity,
                    Username = item.Username,
                    LanguageID = item.LanguageID,
                    ActionVN = "Thêm Mới",
                    ActionEN = "Insert",
                    FunctionID = "8",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa thêm mới thành công tỉnh thành có mã '{1}'.", item.Username, item.ProvinceCode),
                    DescriptionEN = string.Format("Account '{0}' has inserted new province successfully with province code is '{1}'.", item.Username, item.ProvinceCode)
                });
            }

            return strError;
        }

        public string UpdateProvince(PRO_tblProvinceDTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID", "ProvinceID", "ProvinceCode", "VNName", "ENName", "Rank", "Used", "Note" }, new object[] { item.Activity, item.Username, item.LanguageID, item.ProvinceID, item.ProvinceCode, item.VNName, item.ENName, item.Rank, item.Used, item.Note });
            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = item.Username,
                    LanguageID = item.LanguageID,
                    ActionVN = "Cập Nhật",
                    ActionEN = "Update",
                    FunctionID = "8",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa cập nhật thành công tỉnh thành có mã '{1}'.", item.Username, item.ProvinceCode),
                    DescriptionEN = string.Format("Account '{0}' has updated new province successfully with province code is '{1}'.", item.Username, item.ProvinceCode)
                });
            }

            return strError;
        }

        public string DeleteProvince(string province_id, string province_code, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID", "ProvinceID" }, new object[] { "Delete", username, language_id, province_id });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "8",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công tỉnh thành có mã '{1}'.", username, province_code),
                    DescriptionEN = string.Format("Account '{0}' has deleted province successfully with province code is '{1}'.", username, province_code)
                });
            }
            return strError;
        }

        public string DeleteListProvince(string province_id_list, string province_code_list, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID", "ProvinceIDList" }, new object[] { "DeleteList", username, language_id, province_id_list });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "8",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những tỉnh thành có mã '{1}'.", username, province_code_list.Replace("$", ", ")),
                    DescriptionEN = string.Format("Account '{0}' has deleted provinces successfully with province code are '{1}'.", username, province_code_list.Replace("$", ", "))
                });
            }
            return strError;
        }
    }
}
