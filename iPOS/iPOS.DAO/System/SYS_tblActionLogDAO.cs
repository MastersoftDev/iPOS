using iPOS.Core.SQLServer;
using iPOS.DTO.System;
using System;

namespace iPOS.DAO.System
{
    public class SYS_tblActionLogDAO
    {
        protected SQL db;

        public SYS_tblActionLogDAO()
        {
            db = new SQL();
        }

        public string InsertActionLog(SYS_tblActionLogDTO log)
        {
            return db.sExecuteSQL("SYS_spfrmActionLog", new string[] { "Activity", "Username", "LanguageID", "FullName", "ComputerName", "AccountWindows", "ActionVN", "ActionEN", "ActionTime", "FunctionID", "FunctionNameVN", "FunctionNameEN", "IPLAN", "IPWAN", "MacAddress", "DescriptionVN", "DescriptionEN" }, new object[] { log.Activity, log.Username, log.LanguageID, log.FullName, log.ComputerName, log.AccountWindows, log.ActionVN, log.ActionEN, DateTime.Now, log.FunctionID, log.FunctionNameVN, log.FunctionNameEN, log.IPLAN, log.IPWAN, log.MacAddress, log.DescriptionVN, log.DescriptionEN });
        }
    }
}
