using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DRO.Products;
using iPOS.DTO.Products;
using Newtonsoft.Json;

namespace iPOS.DAO.Products
{
    public class PRO_tblWarehouseDAO : BaseDAO
    {
        public async static Task<List<PRO_tblWarehouseDTO>> GetAllWarehouses(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<PRO_tblWarehouseDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.WarehouseList;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }

        public async static Task<PRO_tblWarehouseDTO> GetWarehouseItem(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<PRO_tblWarehouseDRO>(response_data + "");

                if (response_collection != null)
                    return response_collection.WarehouseItem;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }

        public async static Task<string> InsertUpdateWarehouse(string url, string json_data)
        {
            try
            {
                var response_data = await HttpPost(url, json_data);
                var response_collection = JsonConvert.DeserializeObject<PRO_tblWarehouseDRO>(response_data + "");

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

        public async static Task<string> DeleteWarehouse(string url)
        {
            try
            {
                var response_data = await HttpGet(url);
                var response_collection = JsonConvert.DeserializeObject<PRO_tblWarehouseDRO>(response_data + "");

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
