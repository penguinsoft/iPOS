using iPOS.DAO.Systems;
using iPOS.DRO.Systems;
using System;
using System.Threading.Tasks;


namespace iPOS.BUS.Systems
{
    public class SYS_tblUserLevelBUS : BaseBUS
    {
        public async static Task<SYS_tblUserLevelDRO> GetAllUserLevel(string username, string language)
        {
            string url = string.Format(@"{0}/GetUserLevelList?Username={1}&LanguageID={2}", GetBaseUrl(), username, language);

            return await SYS_tblUserLevelDAO.GetAllUserLevel(url);
        }
    }
}
