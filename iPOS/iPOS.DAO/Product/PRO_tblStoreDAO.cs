using System;
using System.Data;
using iPOS.DTO.Product;
using iPOS.DTO.System;

namespace iPOS.DAO.Product
{
    public class PRO_tblStoreDAO : BaseDAO
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
                FunctionID = "13",
                DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu cửa hàng.", username),
                DescriptionEN = string.Format("Account '{0}' downloaded successfully data of stores.", username)
            });

            return db.GetDataTable("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID" }, new object[] { "LoadAllData", username, language_id });
        }

        public DataTable GetDataCombobox(string username, string language_id)
        {
            return db.GetDataTable("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID" }, new object[] { "GetDataCombobox", username, language_id });
        }

        public PRO_tblStoreDTO GetDataByID(string store_id, string username, string language_id)
        {
            DataRow dr = db.GetDataRow("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID", "StoreID" }, new object[] { "GetDataByID", username, language_id, store_id });
            if (dr != null)
            {
                return new PRO_tblStoreDTO
                {
                    StoreID = dr["StoreID"] + "",
                    StoreCode = dr["StoreCode"] + "",
                    ShortCode = dr["ShortCode"] + "",
                    VNName = dr["VNName"] + "",
                    ENName = dr["ENName"] + "",
                    BuildDate = dr["BuildDate"],
                    EndDate = dr["EndDate"],
                    AddressVN = dr["AddressVN"] + "",
                    AddressEN = dr["AddressEN"] + "",
                    Phone = dr["Phone"] + "",
                    Fax = dr["Fax"] + "",
                    TaxCode = dr["TaxCode"] + "",
                    Rank = dr["Rank"],
                    IsRoot = Convert.ToBoolean(dr["IsRoot"]),
                    Used = Convert.ToBoolean(dr["Used"]),
                    Representatives = dr["Representatives"] + "",
                    Note = dr["Note"] + "",
                    ProvinceID = dr["ProvinceID"] + "",
                    DistrictID = dr["DistrictID"] + "",
                    Photo = dr["Photo"]
                };
            }

            return null;
        }

        public string InsertStore(PRO_tblStoreDTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID", "StoreID", "StoreCode", "ShortCode", "VNName", "ENName", "BuildDate", "EndDate", "AddressVN", "AddressEN", "Phone", "Fax", "Rank", "TaxCode", "Used", "IsRoot", "Representives", "Note", "Photo", "ProvinceID", "DistrictID" }, new object[] { item.Activity, item.Username, item.LanguageID, item.StoreID, item.StoreCode, item.ShortCode, item.VNName, item.ENName, item.BuildDate, item.EndDate, item.AddressVN, item.AddressEN, item.Phone, item.Fax, item.Rank, item.TaxCode, item.Used, item.IsRoot, item.Representatives, item.Note, item.Photo, item.ProvinceID, item.DistrictID });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new DTO.System.SYS_tblActionLogDTO
                {
                    Activity = item.Activity,
                    Username = item.Username,
                    LanguageID = item.LanguageID,
                    ActionVN = "Thêm Mới",
                    ActionEN = "Insert",
                    FunctionID = "13",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa thêm mới thành công cửa hàng có mã '{1}'.", item.Username, item.StoreCode),
                    DescriptionEN = string.Format("Account '{0}' has inserted new store successfully with store code is '{1}'.", item.Username, item.StoreCode)
                });
            }

            return strError;
        }

        public string UpdateStore(PRO_tblStoreDTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID", "StoreID", "StoreCode", "ShortCode", "VNName", "ENName", "BuildDate", "EndDate", "AddressVN", "AddressEN", "Phone", "Fax", "Rank", "TaxCode", "Used", "IsRoot", "Representives", "Note", "Photo", "ProvinceID", "DistrictID" }, new object[] { item.Activity, item.Username, item.LanguageID, item.StoreID, item.StoreCode, item.ShortCode, item.VNName, item.ENName, item.BuildDate, item.EndDate, item.AddressVN, item.AddressEN, item.Phone, item.Fax, item.Rank, item.TaxCode, item.Used, item.IsRoot, item.Representatives, item.Note, item.Photo, item.ProvinceID, item.DistrictID });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new DTO.System.SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = item.Username,
                    LanguageID = item.LanguageID,
                    ActionVN = "Cập Nhật",
                    ActionEN = "Update",
                    FunctionID = "13",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa cập nhật thành công cửa hàng có mã '{1}'.", item.Username, item.StoreCode),
                    DescriptionEN = string.Format("Account '{0}' has updated store successfully with store code is '{1}'.", item.Username, item.StoreCode)
                });
            }

            return strError;
        }

        public string DeleteStore(string store_id, string store_code, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID", "StoreID" }, new object[] { "Delete", username, language_id, store_id });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "13",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công cửa hàng có mã '{1}'.", username, store_code),
                    DescriptionEN = string.Format("Account '{0}' has deleted store successfully with store code is '{1}'.", username, store_code)
                });
            }
            return strError;
        }

        public string DeleteListStore(string store_id_list, string store_code_list, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID", "StoreIDList" }, new object[] { "DeleteList", username, language_id, store_id_list });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "13",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những cửa hàng có mã '{1}'.", username, store_code_list.Replace("$", ", ")),
                    DescriptionEN = string.Format("Account '{0}' has deleted stores successfully with store code are '{1}'.", username, store_code_list.Replace("$", ", "))
                });
            }
            return strError;
        }
    }
}
