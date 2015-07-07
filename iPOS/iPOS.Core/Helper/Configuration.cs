using iPOS.Core.Helper;
using System;

namespace iPOS.Core.Helper
{
    public class Configuration
    {
        public string ServerName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        public string IsEncryptPassword { get; set; }
        public string Language { get; set; }
        public string LogPath { get; set; }
        public string IPWAN { get; set; }
        public string IPLAN { get; set; }
        public string MacAddress { get; set; }
        public string TemplatePath { get; set; }
        protected IO _helper;

        public Configuration()
        {
            _helper = new IO();
            #region [Database]
            ServerName = _helper.Read("Database", "ServerName");
            UserName = _helper.Read("Database", "UserName");
            Password = _helper.Read("Database", "Password");
            DatabaseName = _helper.Read("Database", "Database");
            IsEncryptPassword = _helper.Read("Database", "IsEncrypt");
            #endregion

            #region [Extensions]
            LogPath = _helper.Read("Extensions", "LogPath");
            IPWAN = _helper.Read("Extensions", "IPWAN");
            IPLAN = _helper.Read("Extensions", "IPLAN");
            MacAddress = _helper.Read("Extensions", "MacAddress");
            TemplatePath = _helper.Read("Extensions", "TemplatePath");
            #endregion

            #region [Initialize]
            Language = _helper.Read("Initialize", "Language");
            #endregion
        }
    }
}
