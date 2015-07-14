using System;
using System.Threading.Tasks;
using iPOS.DAO.System;
using iPOS.DTO.System;

namespace iPOS.BUS.System
{
    public class SYS_tblUserBUS : BaseBUS
    {
        public async static Task<SYS_tblUserDTO> CheckLogin(string username, string password, string language)
        {
            if (language.Equals("vi")) language = "VN";
            else if (language.Equals("en")) language = "EN";
            string url = string.Format("{0}/CheckLogin?Username={1}&Password={2}&LanguageID={3}", GetBaseUrl(), username, password, language);

            return await SYS_tblUserDAO.CheckLogin(url);
        }
    }
}
