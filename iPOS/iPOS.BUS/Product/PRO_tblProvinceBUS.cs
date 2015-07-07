using iPOS.DAO.Product;
using iPOS.DTO.Product;
using System;
using System.Data;

namespace iPOS.BUS.Product
{
    public class PRO_tblProvinceBUS : BaseBUS
    {
        protected PRO_tblProvinceDAO daoProvince;

        public PRO_tblProvinceBUS()
        {
            daoProvince = new PRO_tblProvinceDAO();
        }

        public DataTable LoadAllData(string username, string language_id)
        {
            return daoProvince.LoadAllData(username, language_id);
        }

        public DataTable GetDataCombobox(string username, string language_id)
        {
            return daoProvince.GetDataCombobox(username, language_id);
        }

        public PRO_tblProvinceDTO GetDataByID(string province_id, string username, string language_id)
        {
            return daoProvince.GetDataByID(province_id, username, language_id);
        }

        public string InsertProvince(PRO_tblProvinceDTO item)
        {
            return daoProvince.InsertProvince(item);
        }

        public string UpdateProvince(PRO_tblProvinceDTO item)
        {
            return daoProvince.UpdateProvince(item);
        }

        public string DeleteProvince(string province_id, string province_code, string username, string language_id)
        {
            return daoProvince.DeleteProvince(province_id, province_code, username, language_id);
        }

        public string DeleteListProvince(string province_id_list, string province_code_list, string username, string language_id)
        {
            return daoProvince.DeleteListProvince(province_id_list, province_code_list, username, language_id);
        }
    }
}
