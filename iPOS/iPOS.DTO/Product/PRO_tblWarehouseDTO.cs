using System;

namespace iPOS.DTO.Product
{
    public class PRO_tblWarehouseDTO : BaseDTO
    {
        protected string _WarehouseID;
        protected string _WarehouseCode;
        protected string _VNName;
        protected string _ENName;
        protected string _AddressVN;
        protected string _AddressEN;
        protected string _Phone;
        protected string _Fax;
        protected object _Rank;
        protected bool _Used;
        protected string _Note;
        protected string _StoreID;
        protected string _ProvinceID;
        protected string _DistrictID;

        public PRO_tblWarehouseDTO() { }

        public string WarehouseID
        {
            get { return _WarehouseID; }
            set { _WarehouseID = value; }
        }

        public string WarehouseCode
        {
            get { return _WarehouseCode; }
            set { _WarehouseCode = value; }
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

        public string AddressVN
        {
            get { return _AddressVN; }
            set { _AddressVN = value; }
        }

        public string AddressEN
        {
            get { return _AddressEN; }
            set { _AddressEN = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
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

        public string ProvinceID
        {
            get { return _ProvinceID; }
            set { _ProvinceID = value; }
        }

        public string DistrictID
        {
            get { return _DistrictID; }
            set { _DistrictID = value; }
        }
    }
}
