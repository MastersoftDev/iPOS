using System;
using iPOS.DAO.Product;
using iPOS.DTO.Product;

namespace iPOS.BUS.Product
{
    public class PRO_tblProductGroupLevel1BUS : BaseBUS
    {
        protected PRO_tblProductGroupLevel1DAO daoLevel1;

        public PRO_tblProductGroupLevel1BUS()
        {
            daoLevel1 = new PRO_tblProductGroupLevel1DAO();
        }

        public string InsertProductGroupLevel1(PRO_tblProductGroupLevel1DTO item)
        {
            return daoLevel1.InsertProductGroupLevel1(item);
        }

        public string UpdateProductGroupLevel1(PRO_tblProductGroupLevel1DTO item)
        {
            return daoLevel1.UpdateProductGroupLevel1(item);
        }

        public string DeleteProductGroupLevel1(string level1_id, string level1_code, string username, string language_id)
        {
            return daoLevel1.DeleteProductGroupLevel1(level1_id, level1_code, username, language_id);
        }

        public string DeleteListProductGroupLevel1(string level1_id_list, string level1_code_list, string username, string language_id)
        {
            return daoLevel1.DeleteListProductGroupLevel1(level1_id_list, level1_code_list, username, language_id);
        }
    }
}
