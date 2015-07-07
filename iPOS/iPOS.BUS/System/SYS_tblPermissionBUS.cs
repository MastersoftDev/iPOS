using iPOS.DAO.System;
using iPOS.DTO.System;
using System;
using System.Data;

namespace iPOS.BUS.System
{
    public class SYS_tblPermissionBUS : BaseBUS
    {
        protected SYS_tblPermissionDAO daoPermission;

        public SYS_tblPermissionBUS()
        {
            daoPermission = new SYS_tblPermissionDAO();
        }

        public SYS_tblPermissionDTO GetPermissionByFunction(string username, string language_id, string function_id, string userName)
        {
            return daoPermission.GetPermissionByFunction(username, language_id, function_id, userName);
        }

        public DataTable GetDataByGroupOrUser(string username, string language_id, string id, string parent_id, int type)
        {
            return daoPermission.GetDataByGroupOrUser(username, language_id, id, parent_id, type);
        }

        public string SavePermission(SYS_tblPermissionDTO item, int type)
        {
            return daoPermission.SavePermission(item, type);
        }
    }
}
