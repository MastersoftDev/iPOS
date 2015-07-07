using System;
using System.Data;
using iPOS.DTO.Product;
using iPOS.DTO.System;

namespace iPOS.DAO.Product
{
    public class PRO_tblDistrictDAO : BaseDAO
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
                FunctionID = "12",
                DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu quận huyện.", username),
                DescriptionEN = string.Format("Account '{0}' downloaded successfully data of districts.", username)
            });

            return db.GetDataTable("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID" }, new object[] { "LoadAllData", username, language_id });
        }

        public DataTable GetDataCombobox(string username, string language_id, string province_id)
        {
            return db.GetDataTable("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID", "ProvinceID" }, new object[] { "GetDataCombobox", username, language_id, province_id });
        }

        public PRO_tblDistrictDTO GetDataByID(string district_id, string username, string language_id)
        {
            DataRow dr = db.GetDataRow("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID", "DistrictID" }, new object[] { "GetDataByID", username, language_id, district_id });
            if (dr != null)
            {
                return new PRO_tblDistrictDTO
                {
                    DistrictID = dr["DistrictID"] + "",
                    DistrictCode = dr["DistrictCode"] + "",
                    VNName = dr["VNName"] + "",
                    ENName = dr["ENName"] + "",
                    ProvinceID = dr["ProvinceID"] + "",
                    Rank = dr["Rank"],
                    Note = dr["Note"] + "",
                    Used = Convert.ToBoolean(dr["Used"])
                };
            }

            return null;
        }

        public string InsertDistrict(PRO_tblDistrictDTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID", "ProvinceID", "DistrictCode", "VNName", "ENName", "Rank", "Used", "Note" }, new object[] { item.Activity, item.Username, item.LanguageID, item.ProvinceID, item.DistrictCode, item.VNName, item.ENName, item.Rank, item.Used, item.Note });
            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = item.Activity,
                    Username = item.Username,
                    LanguageID = item.LanguageID,
                    ActionVN = "Thêm Mới",
                    ActionEN = "Insert",
                    FunctionID = "12",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa thêm mới thành công quận huyện có mã '{1}'.", item.Username, item.DistrictCode),
                    DescriptionEN = string.Format("Account '{0}' has inserted new district successfully with district code is '{1}'.", item.Username, item.DistrictCode)
                });
            }

            return strError;
        }

        public string UpdateDistrict(PRO_tblDistrictDTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID", "DistrictID", "ProvinceID", "DistrictCode", "VNName", "ENName", "Rank", "Used", "Note" }, new object[] { item.Activity, item.Username, item.LanguageID, item.DistrictID, item.ProvinceID, item.DistrictCode, item.VNName, item.ENName, item.Rank, item.Used, item.Note });
            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = item.Activity,
                    Username = item.Username,
                    LanguageID = item.LanguageID,
                    ActionVN = "Cập Nhật",
                    ActionEN = "Update",
                    FunctionID = "12",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa cập nhật thành công quận huyện có mã '{1}'.", item.Username, item.DistrictCode),
                    DescriptionEN = string.Format("Account '{0}' has updated new district successfully with district code is '{1}'.", item.Username, item.DistrictCode)
                });
            }

            return strError;
        }

        public string DeleteDistrict(string district_id, string district_code, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID", "DistrictID" }, new object[] { "Delete", username, language_id, district_id });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "12",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công quận huyện có mã '{1}'.", username, district_code),
                    DescriptionEN = string.Format("Account '{0}' has deleted district successfully with district code is '{1}'.", username, district_code)
                });
            }
            return strError;
        }

        public string DeleteListDistrict(string district_id_list, string district_code_list, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID", "DistrictIDList" }, new object[] { "DeleteList", username, language_id, district_id_list });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "12",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những quận huyện có mã '{1}'.", username, district_code_list.Replace("$", ", ")),
                    DescriptionEN = string.Format("Account '{0}' has deleted districts successfully with district code are '{1}'.", username, district_code_list.Replace("$", ", "))
                });
            }
            return strError;
        }
    }
}
