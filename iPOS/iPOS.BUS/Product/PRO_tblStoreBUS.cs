using System;
using System.Data;
using iPOS.DAO.Product;
using iPOS.DTO.Product;

namespace iPOS.BUS.Product
{
    public class PRO_tblStoreBUS : BaseBUS
    {
        protected PRO_tblStoreDAO daoStore;

        public PRO_tblStoreBUS()
        {
            daoStore = new PRO_tblStoreDAO();
        }

        public DataTable LoadAllData(string username, string language_id)
        {
            return daoStore.LoadAllData(username, language_id);
        }

        public DataTable GetDataCombobox(string username, string language_id)
        {
            return daoStore.GetDataCombobox(username, language_id);
        }

        public PRO_tblStoreDTO GetDataByID(string store_id, string username, string language_id)
        {
            return daoStore.GetDataByID(store_id, username, language_id);
        }

        public string InsertStore(PRO_tblStoreDTO item)
        {
            return daoStore.InsertStore(item);
        }

        public string UpdateStore(PRO_tblStoreDTO item)
        {
            return daoStore.UpdateStore(item);
        }

        public string DeleteStore(string store_id, string store_code, string username, string language_id)
        {
            return daoStore.DeleteStore(store_id, store_code, username, language_id);
        }

        public string DeleteListStore(string store_id_list, string store_code_list, string username, string language_id)
        {
            return daoStore.DeleteListStore(store_id_list, store_code_list, username, language_id);
        }
    }
}
