using System;

namespace iPOS.DTO.System
{
    public class SYS_tblGroupUserDTO : BaseDTO
    {
        protected string _GroupID;
        protected string _GroupCode;
        protected string _GroupName;
        protected string _Note;
        protected bool _Active;
        protected bool _IsDefault;
        protected bool _IsRoot;

        public SYS_tblGroupUserDTO() { }

        public SYS_tblGroupUserDTO(string group_code, string group_name, string note, bool active, bool is_default, bool is_root)
        {
            GroupCode = group_code;
            GroupName = group_name;
            Note = note;
            Active = active;
            IsDefault = is_default;
            IsRoot = is_root;
        }

        public string GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }

        public string GroupCode
        {
            get { return _GroupCode; }
            set { _GroupCode = value; }
        }

        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public bool IsDefault
        {
            get { return _IsDefault; }
            set { _IsDefault = value; }
        }

        public bool IsRoot
        {
            get { return _IsRoot; }
            set { _IsRoot = value; }
        }
    }
}
