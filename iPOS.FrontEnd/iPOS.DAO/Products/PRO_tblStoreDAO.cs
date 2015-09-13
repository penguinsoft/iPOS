using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DRO.Products;
using iPOS.DTO.Products;
using Newtonsoft.Json;

namespace iPOS.DAO.Products
{
    public class PRO_tblStoreDAO : BaseDAO
    {
        public async static Task<List<PRO_tblStoreDTO>> GetAllStores(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<PRO_tblStoreDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.StoreList;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }

        public async static Task<PRO_tblStoreDTO> GetStoreItem(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<PRO_tblStoreDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.StoreItem;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }

        public async static Task<string> InsertUpdateStore(string url, string json_data)
        {
            try
            {
                var response_data = await HttpPost(url, json_data);
                var response_collection = JsonConvert.DeserializeObject<PRO_tblStoreDRO>(response_data + "");

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

        public async static Task<string> DeleteStore(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<PRO_tblStoreDRO>(response_data + "");

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
