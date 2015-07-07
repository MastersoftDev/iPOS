using System;

namespace iPOS.DTO.Product
{
    public class PRO_tblStallDTO : BaseDTO
    {
        protected string _StallID;
        protected string _StallCode;
        protected string _VNName;
        protected string _ENName;
        protected object _Rank;
        protected bool _Used;
        protected string _Note;
        protected string _StoreID;
        protected string _WarehouseID;

        public PRO_tblStallDTO() { }

        public string StallID
        {
            get { return _StallID; }
            set { _StallID = value; }
        }

        public string StallCode
        {
            get { return _StallCode; }
            set { _StallCode = value; }
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

        public string StoreID
        {
            get { return _StoreID; }
            set { _StoreID = value; }
        }

        public string WarehouseID
        {
            get { return _WarehouseID; }
            set { _WarehouseID = value; }
        }
    }
}
