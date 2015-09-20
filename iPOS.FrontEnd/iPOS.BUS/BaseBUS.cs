using System;
using System.Drawing;
using System.Threading.Tasks;
using iPOS.Core.Logger;
using iPOS.DAO;
using iPOS.DRO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;

namespace iPOS.BUS
{
    public class BaseBUS
    {
        protected static ILogEngine logger = new LogEngine();

        public static string GetBaseUrl(bool is_service = true)
        {
            string result = "";
            try
            {
                if (!string.IsNullOrEmpty(ConfigEngine.PortNumber))
                    result = ConfigEngine.Domain + ":" + ConfigEngine.PortNumber;
                else result = ConfigEngine.Domain;

                result += "/";
                if (is_service)
                    result += ConfigEngine.ServiceName;

                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return "";
        }
    }
}
