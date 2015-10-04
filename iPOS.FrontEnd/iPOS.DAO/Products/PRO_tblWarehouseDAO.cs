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
        public async static Task<PRO_tblWarehouseDRO> GetAllWarehouses(string url)
        {
            PRO_tblWarehouseDRO result = new PRO_tblWarehouseDRO();
            try
            {
                var response_data = await HttpGet(url);
                if (response_data.ToLower().StartsWith("error"))
                {
                    result.ResponseItem.IsError = true;
                    string[] tmp = response_data.Split('|');
                    result.ResponseItem.ErrorCode = tmp[1];
                    result.ResponseItem.ErrorMessage = tmp[2];
                }
                else
                {
                    var response_collection = JsonConvert.DeserializeObject<PRO_tblWarehouseDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.WarehouseList = response_collection.WarehouseList;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblWarehouseDRO> GetWarehouseItem(string url)
        {
            PRO_tblWarehouseDRO result = new PRO_tblWarehouseDRO();
            try
            {
                var response_data = await HttpGet(url);
                if (response_data.ToLower().StartsWith("error"))
                {
                    result.ResponseItem.IsError = true;
                    string[] tmp = response_data.Split('|');
                    result.ResponseItem.ErrorCode = tmp[1];
                    result.ResponseItem.ErrorMessage = tmp[2];
                }
                else
                {
                    var response_collection = JsonConvert.DeserializeObject<PRO_tblWarehouseDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.WarehouseItem = response_collection.WarehouseItem;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblWarehouseDRO> InsertUpdateWarehouse(string url, string json_data)
        {
            PRO_tblWarehouseDRO result = new PRO_tblWarehouseDRO();
            try
            {
                var response_data = await HttpPost(url, json_data);
                if (response_data.ToLower().StartsWith("error"))
                {
                    result.ResponseItem.IsError = true;
                    string[] tmp = response_data.Split('|');
                    result.ResponseItem.ErrorCode = tmp[1];
                    result.ResponseItem.ErrorMessage = tmp[2];
                }
                else
                {
                    var response_collection = JsonConvert.DeserializeObject<PRO_tblWarehouseDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.ResponseItem.Message = response_collection.ResponseItem.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        }

        public async static Task<PRO_tblWarehouseDRO> DeleteWarehouse(string url)
        {
            PRO_tblWarehouseDRO result = new PRO_tblWarehouseDRO();
            try
            {
                var response_data = await HttpGet(url);
                if (response_data.ToLower().StartsWith("error"))
                {
                    result.ResponseItem.IsError = true;
                    string[] tmp = response_data.Split('|');
                    result.ResponseItem.ErrorCode = tmp[1];
                    result.ResponseItem.ErrorMessage = tmp[2];
                }
                else
                {
                    var response_collection = JsonConvert.DeserializeObject<PRO_tblWarehouseDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.ResponseItem.Message = response_collection.ResponseItem.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result.ResponseItem.Message = ex.Message;
            }

            return result;
        } 
    }
}
