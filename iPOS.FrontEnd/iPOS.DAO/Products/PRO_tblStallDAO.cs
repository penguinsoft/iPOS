using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DRO.Products;
using iPOS.DTO.Products;
using Newtonsoft.Json;

namespace iPOS.DAO.Products
{
    public class PRO_tblStallDAO : BaseDAO
    {
        public async static Task<List<PRO_tblStallDTO>> GetAllStalls(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<PRO_tblStallDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.StallList;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }

        public async static Task<PRO_tblStallDTO> GetStallItem(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<PRO_tblStallDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.StallItem;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }

        public async static Task<string> InsertUpdateStall(string url, string json_data)
        {
            try
            {
                var response_data = await HttpPost(url, json_data);
                var response_collection = JsonConvert.DeserializeObject<PRO_tblStallDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.Message;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }

            return "";
        }

        public async static Task<string> DeleteStall(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<PRO_tblStallDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.Message;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }

            return "";
        } 
    }
}
