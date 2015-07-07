using System;

namespace iPOS.DTO.Product
{
    public class PRO_tblProductGroupLevel1DTO : BaseDTO
    {
        protected string _Level1ID;
        protected string _Level1Code;
        protected string _Level1ShortCode;
        protected string _VNName;
        protected string _ENName;
        protected object _Rank;
        protected bool _Used;
        protected string _Note;
        protected string _Description;

        public PRO_tblProductGroupLevel1DTO() { }

        public string Level1ID
        {
            get { return _Level1ID; }
            set { _Level1ID = value; }
        }

        public string Level1Code
        {
            get { return _Level1Code; }
            set { _Level1Code = value; }
        }

        public string Level1ShortCode
        {
            get { return _Level1ShortCode; }
            set { _Level1ShortCode = value; }
        }

        public string VNName
        {
            get { return _VNName; }
            set { _VNName = value; }
        }

        public string ENName
        {
            get { return _ENName; }
            set { _ENName = value; }
        }

        public object Rank
        {
            get { return _Rank; }
            set { _Rank = value; }
        }

        public bool Used
        {
            get { return _Used; }
            set { _Used = value; }
        }

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
    }
}
