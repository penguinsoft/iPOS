using System;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;

namespace iPOS.BUS
{
    public class BaseBUS
    {
        public static string GetBaseUrl()
        {
            string result="";
            if (!string.IsNullOrEmpty(ConfigEngine.PortNumber))
                result = ConfigEngine.Domain + ":" + ConfigEngine.PortNumber;
            else result = ConfigEngine.Domain;

            return result + "/" + ConfigEngine.ServiceName + ".svc";
        }
    }
}
