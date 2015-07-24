using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DRO.System;
using iPOS.DTO.System;
using Newtonsoft.Json;

namespace iPOS.DAO.System
{
    public class SYS_tblGroupUserDAO : BaseDAO
    {
        public async static Task<List<SYS_tblGroupUserDTO>> GetAllGroupUsers(string url)
        {
            List<SYS_tblGroupUserDTO> result = new List<SYS_tblGroupUserDTO>();
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<SYS_tblGroupUserDRO>(response_data + "");

                if (response_collection != null)
                    result = response_collection.GroupUserList;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }
    }
}
