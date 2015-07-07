using iPOS.DAO;
using iPOS.DTO.System;
using System;

namespace iPOS.BUS
{
    public class BaseBUS
    {
        protected BaseDAO dao;

        public BaseBUS()
        {
            dao = new BaseDAO();
        }

        public string InsertActionLog(SYS_tblActionLogDTO log)
        {
            return dao.InsertActionLog(log);
        }
    }
}
