using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DAO.System;
using iPOS.DTO.System;

namespace iPOS.BUS.System
{
    public class SYS_tblGroupUserBUS : BaseBUS
    {
        public async static Task<List<SYS_tblGroupUserDTO>> GetAllGroupUsers(string username, string language)
        {
            string url = string.Format("{0}/GetAllGroupUsers?Username={1}&LanguageID={2}", GetBaseUrl(), username, language);
            return await SYS_tblGroupUserDAO.GetAllGroupUsers(url);
        }
    }
}
