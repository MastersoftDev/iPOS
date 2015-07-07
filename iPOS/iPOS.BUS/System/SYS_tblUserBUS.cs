using iPOS.DAO.System;
using iPOS.DTO.System;
using System;
using System.Data;

namespace iPOS.BUS.System
{
    public class SYS_tblUserBUS : BaseBUS
    {
        protected SYS_tblUserDAO daoUser;

        public SYS_tblUserBUS()
        {
            daoUser = new SYS_tblUserDAO();
        }

        public DataTable LoadAllData(string username, string language_id)
        {
            return daoUser.LoadAllData(username, language_id);
        }

        public DataTable LoadAllData(string username, string language_id, string group_id)
        {
            return daoUser.LoadAllData(username, language_id, group_id);
        }

        public SYS_tblUserDTO GetDataByID(string userName, string username, string language_id)
        {
            return daoUser.GetDataByID(userName, username, language_id);
        }

        public string InsertUser(SYS_tblUserDTO item)
        {
            return daoUser.InsertUser(item);
        }

        public string UpdateUser(SYS_tblUserDTO item)
        {
            return daoUser.UpdateUser(item);
        }

        public string DeleteUser(string userName, string username, string language_id)
        {
            return daoUser.DeleteUser(userName, username, language_id);
        }

        public string DeleteListUser(string userList, string username, string language_id)
        {
            return daoUser.DeleteListUser(userList, username, language_id);
        }

        public SYS_tblUserDTO CheckLogin(string _username, string _password)
        {
            return daoUser.CheckLogin(_username, _password);
        }

        public string ChangePassword(string username, string language_id, string password)
        {
            return daoUser.ChangePassword(username, language_id, password);
        }
    }
}
