using System;
using System.Data;
using iPOS.DAO.Product;
using iPOS.DTO.Product;

namespace iPOS.BUS.Product
{
    public class PRO_tblStallBUS : BaseBUS
    {
        protected PRO_tblStallDAO daoStall;

        public PRO_tblStallBUS()
        {
            daoStall = new PRO_tblStallDAO();
        }

        public DataTable LoadAllData(string username, string language_id)
        {
            return daoStall.LoadAllData(username, language_id);
        }

        public PRO_tblStallDTO GetDataByID(string stall_id, string username, string language_id)
        {
            return daoStall.GetDataByID(stall_id, username, language_id);
        }

        public string InsertStall(PRO_tblStallDTO item)
        {
            return daoStall.InsertStall(item);
        }

        public string UpdateStall(PRO_tblStallDTO item)
        {
            return daoStall.UpdateStall(item);
        }

        public string DeleteStall(string stall_id, string stall_code, string username, string language_id)
        {
            return daoStall.DeleteStall(stall_id, stall_code, username, language_id);
        }

        public string DeleteListStall(string stall_id_list, string stall_code_list, string username, string language_id)
        {
            return daoStall.DeleteListStall(stall_id_list, stall_code_list, username, language_id);
        }
    }
}
