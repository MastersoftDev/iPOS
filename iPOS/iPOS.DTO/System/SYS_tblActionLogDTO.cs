using iPOS.Core.Helper;
using System;

namespace iPOS.DTO.System
{
    public class SYS_tblActionLogDTO : BaseDTO
    {
        protected string _ID { get; set; }
        protected string _FullName { get; set; }
        protected string _ComputerName { get; set; }
        protected string _AccountWindows { get; set; }
        protected string _ActionVN { get; set; }
        protected string _ActionEN { get; set; }
        protected DateTime _ActionTime { get; set; }
        protected string _FunctionID { get; set; }
        protected string _FunctionNameVN { get; set; }
        protected string _FunctionNameEN { get; set; }
        protected string _IPLAN { get; set; }
        protected string _IPWAN { get; set; }
        protected string _MacAddress { get; set; }
        protected string _DescriptionVN { get; set; }
        protected string _DescriptionEN { get; set; }

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        public string ComputerName
        {
            get { return (string.IsNullOrEmpty(_ComputerName) ? Environment.MachineName : _ComputerName); }
            set { _ComputerName = value; }
        }

        public string AccountWindows
        {
            get { return (string.IsNullOrEmpty(_AccountWindows) ? Environment.UserName : _AccountWindows); }
            set { _AccountWindows = value; }
        }

        public string ActionVN
        {
            get { return _ActionVN; }
            set { _ActionVN = value; }
        }

        public string ActionEN
        {
            get { return _ActionEN; }
            set { _ActionEN = value; }
        }

        public DateTime ActionTime
        {
            get { return _ActionTime; }
            set { _ActionTime = value; }
        }

        public string FunctionID
        {
            get { return _FunctionID; }
            set { _FunctionID = value; }
        }

        public string FunctionNameVN
        {
            get { return _FunctionNameVN; }
            set { _FunctionNameVN = value; }
        }

        public string FunctionNameEN
        {
            get { return _FunctionNameEN; }
            set { _FunctionNameEN = value; }
        }

        public string IPLAN
        {
            get { return (string.IsNullOrEmpty(_IPLAN) ? new Configuration().IPLAN : _IPLAN); }
            set { _IPLAN = value; }
        }

        public string IPWAN
        {
            get { return (string.IsNullOrEmpty(_IPWAN) ? new Configuration().IPWAN : _IPWAN); }
            set { _IPWAN = value; }
        }

        public string MacAddress
        {
            get { return (string.IsNullOrEmpty(_MacAddress) ? new Configuration().MacAddress : _MacAddress); }
            set { _MacAddress = value; }
        }

        public string DescriptionVN
        {
            get { return _DescriptionVN; }
            set { _DescriptionVN = value; }
        }

        public string DescriptionEN
        {
            get { return _DescriptionEN; }
            set { _DescriptionEN = value; }
        }
    }
}
