using System;

namespace iPOS.DTO.Product
{
    public class PRO_tblStoreDTO : BaseDTO
    {
        protected string _StoreID;
        protected string _StoreCode;
        protected string _ShortCode;
        protected string _VNName;
        protected string _ENName;
        protected object _BuildDate;
        protected object _EndDate;
        protected string _AddressVN;
        protected string _AddressEN;
        protected string _Phone;
        protected string _Fax;
        protected object _Rank;
        protected string _TaxCode;
        protected bool _Used;
        protected bool _IsRoot;
        protected string _Representatives;
        protected string _Note;
        protected object _Photo;
        protected string _ProvinceID;
        protected string _DistrictID;

        public PRO_tblStoreDTO() { }

        public string StoreID
        {
            get { return _StoreID; }
            set { _StoreID = value; }
        }

        public string StoreCode
        {
            get { return _StoreCode; }
            set { _StoreCode = value; }
        }

        public string ShortCode
        {
            get { return _ShortCode; }
            set { _ShortCode = value; }
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

        public object BuildDate
        {
            get { return _BuildDate; }
            set { _BuildDate = value; }
        }

        public object EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
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

        public string TaxCode
        {
            get { return _TaxCode; }
            set { _TaxCode = value; }
        }

        public bool Used
        {
            get { return _Used; }
            set { _Used = value; }
        }

        public bool IsRoot
        {
            get { return _IsRoot; }
            set { _IsRoot = value; }
        }

        public string Representatives
        {
            get { return _Representatives; }
            set { _Representatives = value; }
        }

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        public object Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
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
