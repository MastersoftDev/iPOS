using System;

namespace iPOS.DTO.Product
{
    public class PRO_tblDistrictDTO : BaseDTO
    {
        protected string _DistrictID;
        protected string _DistrictCode;
        protected string _ProvinceID;
        protected string _VNName;
        protected string _ENName;
        protected object _Rank;
        protected bool _Used;
        protected string _Note;

        public PRO_tblDistrictDTO() { }

        public string DistrictID
        {
            get { return _DistrictID; }
            set { _DistrictID = value; }
        }

        public string DistrictCode
        {
            get { return _DistrictCode; }
            set { _DistrictCode = value; }
        }

        public string ProvinceID
        {
            get { return _ProvinceID; }
            set { _ProvinceID = value; }
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
    }
}
