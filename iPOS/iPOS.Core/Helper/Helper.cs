using System;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace iPOS.Core.Helper
{
    public class Helper
    {
        public static string GetIPLAN()
        {
            try
            {
                IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(Dns.GetHostName());

                foreach (IPAddress ipAddress in ipEntry.AddressList)
                {
                    if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                    {
                        return ipAddress + "";
                    }
                }
                return "-";
            }
            catch (Exception ex)
            {
                Logger.Logger.Error(ex);
                return "-";
            }
        }

        public static string GetIPWAN()
        {
            string _strIP = "";
            try
            {
                WebClient wc = new WebClient();
                _strIP = wc.DownloadString("http://checkip.dyndns.org");
                _strIP = (new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")).Match(_strIP).Value;
                wc.Dispose();
                return _strIP;
            }
            catch (Exception ex)
            {
                Logger.Logger.Error(ex);
                return "-";
            }
        }

        public static string GetMacAddress()
        {
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                string sMacAddress = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)// only return MAC Address from first card  
                    {
                        //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                }

                string _smacAddress = "";
                _smacAddress = sMacAddress.Substring(0, 2);
                for (int i = 0; i < sMacAddress.Length - 2; i++)
                {
                    if (i % 2 != 0 && i < sMacAddress.Length)
                    {
                        _smacAddress += ":" + sMacAddress.Substring(i + 1, 2);
                    }
                }

                return _smacAddress;
            }
            catch (Exception ex)
            {
                Logger.Logger.Error(ex);
                return "-";
            }
        }

        public static SqlDbType ConvertDataType(string type_name)
        {
            string tmp = type_name.Trim().ToUpper();
            SqlDbType result = SqlDbType.NVarChar;
            switch (tmp)
            {
                case "NVARCHAR": result = SqlDbType.NVarChar; break;
                case "VARCHAR": result = SqlDbType.VarChar; break;
                case "DATETIME": result = SqlDbType.DateTime; break;
                case "BIT": result = SqlDbType.Bit; break;
                case "INT": result = SqlDbType.Int; break;
                case "MONEY": result = SqlDbType.Money; break;
                case "REAL": result = SqlDbType.Real; break;
                case "NUMERIC": result = SqlDbType.Decimal; break;
                case "NUMBER": result = SqlDbType.Real; break;
                case "SMALLINT": result = SqlDbType.SmallInt; break;
                case "FLOAT": result = SqlDbType.Float; break;
            }

            return result;
        }
    }
}