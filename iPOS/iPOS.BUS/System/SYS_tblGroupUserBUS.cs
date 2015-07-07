using iPOS.DAO.System;
using iPOS.DTO.System;
using System;
using System.Collections.Generic;
using System.Data;

namespace iPOS.BUS.System
{
    public class SYS_tblGroupUserBUS : BaseBUS
    {
        protected SYS_tblGroupUserDAO daoGroupUser;

        public SYS_tblGroupUserBUS()
        {
            daoGroupUser = new SYS_tblGroupUserDAO();
        }

        public DataTable LoadAllData(string username, string language_id)
        {
            return daoGroupUser.LoadAllData(username, language_id);
        }

        public List<SYS_tblGroupUserDTO> GetDataCombobox(string username, string language_id)
        {
            return daoGroupUser.GetDataCombobox(username, language_id);
        }

        public SYS_tblGroupUserDTO GetDataByID(string group_id, string username, string language_id)
        {
            return daoGroupUser.GetDataByID(group_id, username, language_id);
        }

        public string GetDefaultGroup(string username, string language_id)
        {
            return daoGroupUser.GetDefaultGroup(username, language_id);
        }

        public string InsertGroupUser(SYS_tblGroupUserDTO item)
        {
            return daoGroupUser.InsertGroupUser(item);
        }

        public string UpdateGroupUser(SYS_tblGroupUserDTO item)
        {
            return daoGroupUser.UpdateGroupUser(item);
        }

        public string DeleteGroupUser(string group_id, string group_code, string username, string language_id)
        {
            return daoGroupUser.DeleteGroupUser(group_id, group_code, username, language_id);
        }

        public string DeleteListGroupUser(string group_id_list, string group_code_list, string username, string language_id)
        {
            return daoGroupUser.DeleteListGroupUser(group_id_list, group_code_list, username, language_id);
        }
    }
}
