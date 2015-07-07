using System;

namespace iPOS.DTO.System
{
    public class SYS_tblUserDTO : BaseDTO
    {
        protected string _UserName;
        protected string _Password;
        protected string _GroupID;
        protected DateTime _EffectiveDate;
        protected object _ToDate;
        protected object _DateChangePass;
        protected bool _Locked;
        protected object _LockDate;
        protected object _UnlockDate;
        protected bool _PassNeverExpired;
        protected bool _ChangePassNextTime;
        protected string _EmpID;
        protected string _FullName;
        protected bool _IsSystemAdmin;
        protected bool _CanNotChangePassword;
        protected string _Email;
        protected string _Note;
        protected string _GroupName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }

        public DateTime EffectiveDate
        {
            get { return _EffectiveDate; }
            set { _EffectiveDate = value; }
        }

        public object ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        public object DateChangePass
        {
            get { return _DateChangePass; }
            set { _DateChangePass = value; }
        }

        public bool Locked
        {
            get { return _Locked; }
            set { _Locked = value; }
        }

        public object LockDate
        {
            get { return _LockDate; }
            set { _LockDate = value; }
        }

        public object UnlockDate
        {
            get { return _UnlockDate; }
            set { _UnlockDate = value; }
        }

        public bool PassNeverExpired
        {
            get { return _PassNeverExpired; }
            set { _PassNeverExpired = value; }
        }

        public bool ChangePassNextTime
        {
            get { return _ChangePassNextTime; }
            set { _ChangePassNextTime = value; }
        }

        public string EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        public bool IsSystemAdmin
        {
            get { return _IsSystemAdmin; }
            set { _IsSystemAdmin = value; }
        }

        public bool CanNotChangePassword
        {
            get { return _CanNotChangePassword; }
            set { _CanNotChangePassword = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
    }
}
