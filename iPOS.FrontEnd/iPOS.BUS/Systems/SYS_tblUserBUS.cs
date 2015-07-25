using System;
using System.Threading.Tasks;
using iPOS.DAO.Systems;
using iPOS.DTO.Systems;

namespace iPOS.BUS.Systems
{
    public class SYS_tblUserBUS : BaseBUS
    {
        public async static Task<SYS_tblUserDTO> CheckLogin(string username, string password, string language)
        {
            string url = string.Format("{0}/CheckLogin?Username={1}&Password={2}&LanguageID={3}", GetBaseUrl(), username, password, language);

            return await SYS_tblUserDAO.CheckLogin(url);
        }
    }
}
