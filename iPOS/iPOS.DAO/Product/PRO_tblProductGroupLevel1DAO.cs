using System;
using iPOS.DTO.Product;
using iPOS.DTO.System;

namespace iPOS.DAO.Product
{
    public class PRO_tblProductGroupLevel1DAO : BaseDAO
    {
        public string InsertProductGroupLevel1(PRO_tblProductGroupLevel1DTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel1", new string[] { "Activity", "Username", "LanguageID", "Level1ID", "Level1Code", "Level1ShortCode", "VNName", "ENName", "Rank", "Used", "Note", "Description" }, new object[] { item.Activity, item.Username, item.LanguageID, item.Level1ID, item.Level1Code, item.Level1ShortCode, item.VNName, item.ENName, item.Rank, item.Used, item.Note, item.Description });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new DTO.System.SYS_tblActionLogDTO
                {
                    Activity = item.Activity,
                    Username = item.Username,
                    LanguageID = item.LanguageID,
                    ActionVN = "Thêm Mới",
                    ActionEN = "Insert",
                    FunctionID = "20",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa thêm mới thành công ngành hàng có mã '{1}'.", item.Username, item.Level1Code),
                    DescriptionEN = string.Format("Account '{0}' has inserted new product sector successfully with sector code is '{1}'.", item.Username, item.Level1Code)
                });
            }

            return strError;
        }

        public string UpdateProductGroupLevel1(PRO_tblProductGroupLevel1DTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel1", new string[] { "Activity", "Username", "LanguageID", "Level1ID", "Level1Code", "Level1ShortCode", "VNName", "ENName", "Rank", "Used", "Note", "Description" }, new object[] { item.Activity, item.Username, item.LanguageID, item.Level1ID, item.Level1Code, item.Level1ShortCode, item.VNName, item.ENName, item.Rank, item.Used, item.Note, item.Description });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new DTO.System.SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = item.Username,
                    LanguageID = item.LanguageID,
                    ActionVN = "Cập Nhật",
                    ActionEN = "Update",
                    FunctionID = "20",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa cập nhật thành công ngành hàng có mã '{1}'.", item.Username, item.Level1Code),
                    DescriptionEN = string.Format("Account '{0}' has updated product sector successfully with sector code is '{1}'.", item.Username, item.Level1Code)
                });
            }

            return strError;
        }

        public string DeleteProductGroupLevel1(string level1_id, string level1_code, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel1", new string[] { "Activity", "Username", "LanguageID", "Level1ID" }, new object[] { "Delete", username, language_id, level1_id });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "20",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công ngành hàng có mã '{1}'.", username, level1_code),
                    DescriptionEN = string.Format("Account '{0}' has deleted product sector successfully with sector code is '{1}'.", username, level1_code)
                });
            }
            return strError;
        }

        public string DeleteListProductGroupLevel1(string level1_id_list, string level1_code_list, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel1", new string[] { "Activity", "Username", "LanguageID", "Level1IDList" }, new object[] { "DeleteList", username, language_id, level1_id_list });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "20",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những ngành hàng có mã '{1}'.", username, level1_code_list.Replace("$", ", ")),
                    DescriptionEN = string.Format("Account '{0}' has deleted product sectors successfully with sector code are '{1}'.", username, level1_code_list.Replace("$", ", "))
                });
            }
            return strError;
        }
    }
}
