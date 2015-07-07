using System;
using System.Data;
using iPOS.DAO.Product;
using iPOS.DTO.Product;

namespace iPOS.BUS.Product
{
    public class PRO_tblDistrictBUS : BaseBUS
    {
        protected PRO_tblDistrictDAO daoDistrict;

        public PRO_tblDistrictBUS()
        {
            daoDistrict = new PRO_tblDistrictDAO();
        }

        public DataTable LoadAllData(string username, string language_id)
        {
            return daoDistrict.LoadAllData(username, language_id);
        }

        public DataTable GetDataCombobox(string username, string language_id, string province_id)
        {
            return daoDistrict.GetDataCombobox(username, language_id, province_id);
        }

        public PRO_tblDistrictDTO GetDataByID(string district_id, string username, string language_id)
        {
            return daoDistrict.GetDataByID(district_id, username, language_id);
        }

        public string InsertDistrict(PRO_tblDistrictDTO item)
        {
            return daoDistrict.InsertDistrict(item);
        }

        public string UpdateDistrict(PRO_tblDistrictDTO item)
        {
            return daoDistrict.UpdateDistrict(item);
        }

        public string DeleteDistrict(string district_id, string district_code, string username, string language_id)
        {
            return daoDistrict.DeleteDistrict(district_id, district_code, username, language_id);
        }

        public string DeleteListDistrict(string district_id_list, string district_code_list, string username, string language_id)
        {
            return daoDistrict.DeleteListDistrict(district_id_list, district_code_list, username, language_id);
        }
    }
}
