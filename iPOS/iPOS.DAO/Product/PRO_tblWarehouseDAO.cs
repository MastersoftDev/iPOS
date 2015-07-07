using System;
using System.Data;
using iPOS.DTO.Product;
using iPOS.DTO.System;

namespace iPOS.DAO.Product
{
    public class PRO_tblWarehouseDAO : BaseDAO
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
                FunctionID = "18",
                DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu kho hàng.", username),
                DescriptionEN = string.Format("Account '{0}' downloaded successfully data of warehouses.", username)
            });

            return db.GetDataTable("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID" }, new object[] { "LoadAllData", username, language_id });
        }

        public DataTable GetDataCombobox(string username, string language_id)
        {
            return db.GetDataTable("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID" }, new object[] { "GetDataCombobox", username, language_id });
        }

        public PRO_tblWarehouseDTO GetDataByID(string warehouse_id, string username, string language_id)
        {
            DataRow dr = db.GetDataRow("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID", "WarehouseID" }, new object[] { "GetDataByID", username, language_id, warehouse_id });
            if (dr != null)
            {
                return new PRO_tblWarehouseDTO
                {
                    WarehouseID = dr["WarehouseID"] + "",
                    WarehouseCode = dr["WarehouseCode"] + "",
                    VNName = dr["VNName"] + "",
                    ENName = dr["ENName"] + "",
                    StoreID = dr["StoreID"] + "",
                    AddressVN = dr["AddressVN"] + "",
                    AddressEN = dr["AddressEN"] + "",
                    Phone = dr["Phone"] + "",
                    Fax = dr["Fax"] + "",
                    Used = Convert.ToBoolean(dr["Used"]),
                    Rank = dr["Rank"],
                    Note = dr["Note"] + "",
                    ProvinceID = dr["ProvinceID"] + "",
                    DistrictID = dr["DistrictID"] + ""
                };
            }

            return null;
        }

        public string InsertWarehouse(PRO_tblWarehouseDTO item)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID", "WarehouseID", "WarehouseCode", "VNName", "ENName", "AddressVN", "AddressEN", "Phone", "Fax", "Rank", "Used", "Note", "StoreID", "ProvinceID", "DistrictID" }, new object[] { item.Activity, item.Username, item.LanguageID, item.WarehouseID, item.WarehouseCode, item.VNName, item.ENName, item.AddressVN, item.AddressEN, item.Phone, item.Fax, item.Rank, item.Used, item.Note, item.StoreID, item.ProvinceID, item.DistrictID });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new DTO.System.SYS_tblActionLogDTO
                {
                    Activity = item.Activity,
                    Username = item.Username,
                    LanguageID = item.LanguageID,
                    ActionVN = "Thêm Mới",
                    ActionEN = "Insert",
                    FunctionID = "18",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa thêm mới thành công kho hàng có mã '{1}'.", item.Username, item.WarehouseCode),
                    DescriptionEN = string.Format("Account '{0}' has inserted new warehouse successfully with warehouse code is '{1}'.", item.Username, item.WarehouseCode)
                });
            }

            return strError;
        }

        public string UpdateWarehouse(PRO_tblWarehouseDTO item) 
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID", "WarehouseID", "WarehouseCode", "VNName", "ENName", "AddressVN", "AddressEN", "Phone", "Fax", "Rank", "Used", "Note", "StoreID", "ProvinceID", "DistrictID" }, new object[] { item.Activity, item.Username, item.LanguageID, item.WarehouseID, item.WarehouseCode, item.VNName, item.ENName, item.AddressVN, item.AddressEN, item.Phone, item.Fax, item.Rank, item.Used, item.Note, item.StoreID, item.ProvinceID, item.DistrictID });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new DTO.System.SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = item.Username,
                    LanguageID = item.LanguageID,
                    ActionVN = "Cập Nhật",
                    ActionEN = "Update",
                    FunctionID = "18",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa cập nhật thành công kho hàng có mã '{1}'.", item.Username, item.WarehouseCode),
                    DescriptionEN = string.Format("Account '{0}' has updated new warehouse successfully with warehouse code is '{1}'.", item.Username, item.WarehouseCode)
                });
            }

            return strError;
        }

        public string DeleteWarehouse(string warehouse_id, string warehouse_code, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID", "WarehouseID" }, new object[] { "Delete", username, language_id, warehouse_id });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "18",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công kho hàng có mã '{1}'.", username, warehouse_code),
                    DescriptionEN = string.Format("Account '{0}' has deleted warehouse successfully with warehouse code is '{1}'.", username, warehouse_code)
                });
            }
            return strError;
        }

        public string DeleteListWarehouse(string warehouse_id_list, string warehouse_code_list, string username, string language_id)
        {
            string strError = "";
            strError = db.sExecuteSQL("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID", "WarehouseIDList" }, new object[] { "DeleteList", username, language_id, warehouse_id_list });

            if (strError.Equals(""))
            {
                strError = this.InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = "Insert",
                    Username = username,
                    LanguageID = language_id,
                    ActionVN = "Xóa",
                    ActionEN = "Delete",
                    FunctionID = "18",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những kho hàng có mã '{1}'.", username, warehouse_code_list.Replace("$", ", ")),
                    DescriptionEN = string.Format("Account '{0}' has deleted warehouses successfully with warehouse code are '{1}'.", username, warehouse_code_list.Replace("$", ", "))
                });
            }
            return strError;
        }
    }
}
