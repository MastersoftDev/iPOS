using System;

namespace iPOS.DTO.Product
{
    public class PRO_tblProductGroupLevel2DTO : BaseDTO
    {
        protected string _Level2ID;
        protected string _Level2Code;
        protected string _Level2ShortCode;
        protected string _Level1ID;
        protected string _VNName;
        protected string _ENName;
        protected object _Rank;
        protected bool _Used;
        protected string _Note;
        protected string _Description;

        public PRO_tblProductGroupLevel2DTO() { }

        public string Level2ID
        {
            get { return _Level2ID; }
            set { _Level2ID = value; }
        }

        public string Level2Code
        {
            get { return _Level2Code; }
            set { _Level2Code = value; }
        }

        public string Level2ShortCode
        {
            get { return _Level2ShortCode; }
            set { _Level2ShortCode = value; }
        }

        public string Level1ID
        {
            get { return _Level1ID; }
            set { _Level1ID = value; }
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
