using System;

namespace iPOS.DTO.System
{
    public class SYS_tblImportFileConfigDTO : BaseDTO
    {
        protected string _ImportFileConfigID;
        protected string _ModuleID;
        protected string _ExcelFile;
        protected string _FilePath;
        protected string _FunctionID;
        protected string _Note;

        public string ImportFileConfigID
        {
            get { return _ImportFileConfigID; }
            set { _ImportFileConfigID = value; }
        }

        public string ModuleID
        {
            get { return _ModuleID; }
            set { _ModuleID = value; }
        }

        public string ExcelFile
        {
            get { return _ExcelFile; }
            set { _ExcelFile = value; }
        }

        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }

        public string FunctionID
        {
            get { return _FunctionID; }
            set { _FunctionID = value; }
        }

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
    }
}
