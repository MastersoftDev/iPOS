using System;
using System.Data;
using iPOS.DAO.Product;
using iPOS.DTO.Product;

namespace iPOS.BUS.Product
{
    public class PRO_tblWarehouseBUS : BaseBUS
    {
        protected PRO_tblWarehouseDAO daoWarehouse;

        public PRO_tblWarehouseBUS()
        {
            daoWarehouse = new PRO_tblWarehouseDAO();
        }

        public DataTable LoadAllData(string username, string language_id)
        {
            return daoWarehouse.LoadAllData(username, language_id);
        }

        public DataTable GetDataCombobox(string username, string language_id)
        {
            return daoWarehouse.GetDataCombobox(username, language_id);
        }

        public PRO_tblWarehouseDTO GetDataByID(string warehouse_id, string username, string language_id)
        {
            return daoWarehouse.GetDataByID(warehouse_id, username, language_id);
        }

        public string InsertWarehouse(PRO_tblWarehouseDTO item)
        {
            return daoWarehouse.InsertWarehouse(item);
        }

        public string UpdateWarehouse(PRO_tblWarehouseDTO item)
        {
            return daoWarehouse.UpdateWarehouse(item);
        }

        public string DeleteWarehouse(string warehouse_id, string warehouse_code, string username, string language_id)
        {
            return daoWarehouse.DeleteWarehouse(warehouse_id, warehouse_code, username, language_id);
        }

        public string DeleteListWarehouse(string warehouse_id_list, string warehouse_code_list, string username, string language_id)
        {
            return daoWarehouse.DeleteListWarehouse(warehouse_id_list, warehouse_code_list, username, language_id);
        }
    }
}
