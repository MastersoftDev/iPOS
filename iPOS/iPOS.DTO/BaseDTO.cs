using iPOS.Core.Helper;
using iPOS.DTO.System;
using System;

namespace iPOS.DTO
{
    public class BaseDTO
    {
        protected string _Activity;
        protected string _Username;
        protected string _LanguageID;
        protected bool _Visible;
        protected string _Creater;
        protected DateTime _CreateTime;
        protected string _Editer;
        protected DateTime _EditTime;

        public SYS_tblActionLogDTO Log { get; set; }

        public string Activity
        {
            get { return _Activity; }
            set { _Activity = value; }
        }

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public string LanguageID
        {
            get { return _LanguageID; }
            set
            {
                _LanguageID = new Configuration().Language.Equals("vi-VN") ? "VN" : "EN";
            }
        }

        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }

        public string Creater
        {
            get { return _Creater; }
            set { _Creater = value; }
        }

        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        public string Editer
        {
            get { return _Editer; }
            set { _Editer = value; }
        }

        public DateTime EditTime
        {
            get { return _EditTime; }
            set { _EditTime = value; }
        }
    }
}
