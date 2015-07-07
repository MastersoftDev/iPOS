using iPOS.DAO.System;
using iPOS.DTO.System;
using System;

namespace iPOS.BUS.System
{
    public class SYS_tblActionLogBUS
    {
        protected SYS_tblActionLogDAO dao;

        public SYS_tblActionLogBUS()
        {
            dao = new SYS_tblActionLogDAO();
        }

        public string InsertActionLog(SYS_tblActionLogDTO log)
        {
            return dao.InsertActionLog(log);
        }
    }
}
