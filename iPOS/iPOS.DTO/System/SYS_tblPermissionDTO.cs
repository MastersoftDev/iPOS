using System;

namespace iPOS.DTO.System
{
    public class SYS_tblPermissionDTO : BaseDTO
    {
        protected string _UserName;
        protected string _GroupID;
        protected string _FunctionID;
        protected string _FunctionName;
        protected bool _AllowInsert;
        protected bool _AllowUpdate;
        protected bool _AllowDelete;
        protected bool _AllowAccess;
        protected bool _AllowPrint;
        protected bool _AllowImport;
        protected bool _AllowExport;
        protected bool _AllowAll;
        protected string _UserLevelID;
        protected string _Note;

        public SYS_tblPermissionDTO() { }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }

        public string FunctionID
        {
            get { return _FunctionID; }
            set { _FunctionID = value; }
        }

        public string FunctionName
        {
            get { return _FunctionName; }
            set { _FunctionName = value; }
        }

        public bool AllowInsert
        {
            get { return _AllowInsert; }
            set { _AllowInsert = value; }
        }

        public bool AllowUpdate
        {
            get { return _AllowUpdate; }
            set { _AllowUpdate = value; }
        }

        public bool AllowDelete
        {
            get { return _AllowDelete; }
            set { _AllowDelete = value; }
        }

        public bool AllowAccess
        {
            get { return _AllowAccess; }
            set { _AllowAccess = value; }
        }

        public bool AllowPrint
        {
            get { return _AllowPrint; }
            set { _AllowPrint = value; }
        }

        public bool AllowImport
        {
            get { return _AllowImport; }
            set { _AllowImport = value; }
        }

        public bool AllowExport
        {
            get { return _AllowExport; }
            set { _AllowExport = value; }
        }

        public bool AllowAll
        {
            get { return _AllowAll; }
            set { _AllowAll = value; }
        }

        public string UserLevelID
        {
            get { return _UserLevelID; }
            set { _UserLevelID = value; }
        }

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
    }
}
