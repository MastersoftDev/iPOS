using System;
using System.Data;
using iPOS.DTO.Product;
using iPOS.DTO.System;

namespace iPOS.DAO.Product
{
    public class PRO_tblStallDAO : BaseDAO
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
                FunctionID = "19",
                DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu quầy bán.", username),
                DescriptionEN = string.Format("Account '{0}' downloaded successfully data of stalls.", username)
            });

            return db.GetDataTable("PRO_spfrmStall", new string[] { "Activity", "Username", "LanguageID" }, new object[] { "LoadAllData", username, language_id });
        }

        public PRO_tblStallDTO GetDataByID(string stall_id, string username, string language_id)
        {
            DataRow dr = db.GetDataRow("PRO_spfrmStall", new string[] { "Activity", "Username", "LanguageID", "StallID" }, new object[] { "GetDataByID", username, language_id, stall_id });
            if (dr != null)
            {
                return new PRO_tblStallDTO
                {
                    StallID = dr["StallID"] + "",
                    StallCode = dr["StallCode"] + "",
                    VNName = dr["VNName"] + "",
                    ENName = dr["ENName"] + "",
                    Rank = dr["Rank"],
                    Used = Convert.ToBoolean(dr["Used"]),
                    Note = dr["Note"] + "",
                    WarehouseID = dr["WarehouseID"] + ""
                };
            }

            return null;
        }

        public string InsertStall(PRO_tblStallDTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmStall", new string[] { "Activity", "Username", "LanguageID", "StallID", "StallCode", "VNName", "ENName", "WarehouseID", "Rank", "Used", "Note" }, new object[] { item.Activity, item.Username, item.LanguageID, item.StallID, item.StallCode, item.VNName, item.ENName, item.WarehouseID, item.Rank, item.Used, item.Note });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new DTO.System.SYS_tblActionLogDTO
                {
                    Activity = item.Activity,
                    Username = item.Username,
                    LanguageID = item.LanguageID,
                    ActionVN = "Thêm Mới",
                    ActionEN = "Insert",
                    FunctionID = "19",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa thêm mới thành công quầy bán có mã '{1}'.", item.Username, item.StallCode),
                    DescriptionEN = string.Format("Account '{0}' has inserted new stall successfully with stall code is '{1}'.", item.Username, item.StallCode)
                });
            }

            return strError;
        }

        public string UpdateStall(PRO_tblStallDTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmStall", new string[] { "Activity", "Username", "LanguageID", "StallID", "StallCode", "VNName", "ENName", "WarehouseID", "Rank", "Used", "Note" }, new object[] { item.Activity, item.Username, item.LanguageID, item.StallID, item.StallCode, item.VNName, item.ENName, item.WarehouseID, item.Rank, item.Used, item.Note });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new DTO.System.SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = item.Username,
                    LanguageID = item.LanguageID,
                    ActionVN = "Cập Nhật",
                    ActionEN = "Update",
                    FunctionID = "19",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa cập nhật thành công quầy bán có mã '{1}'.", item.Username, item.StallCode),
                    DescriptionEN = string.Format("Account '{0}' has updated new stall successfully with stall code is '{1}'.", item.Username, item.StallCode)
                });
            }

            return strError;
        }

        public string DeleteStall(string stall_id, string stall_code, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmStall", new string[] { "Activity", "Username", "LanguageID", "StallID" }, new object[] { "Delete", username, language_id, stall_id });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "19",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công quầy bán có mã '{1}'.", username, stall_code),
                    DescriptionEN = string.Format("Account '{0}' has deleted stall successfully with stall code is '{1}'.", username, stall_code)
                });
            }
            return strError;
        }

        public string DeleteListStall(string stall_id_list, string stall_code_list, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmStall", new string[] { "Activity", "Username", "LanguageID", "StallIDList" }, new object[] { "DeleteList", username, language_id, stall_id_list });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "19",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những quầy bán có mã '{1}'.", username, stall_code_list.Replace("$", ", ")),
                    DescriptionEN = string.Format("Account '{0}' has deleted stalls successfully with stall code are '{1}'.", username, stall_code_list.Replace("$", ", "))
                });
            }
            return strError;
        }
    }
}
