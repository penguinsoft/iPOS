using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPOS.DRO.Products;
using iPOS.DTO.Products;
using Newtonsoft.Json;

namespace iPOS.DAO.Products
{
    public class PRO_tblDistrictDAO : BaseDAO
    {
        public async static Task<PRO_tblDistrictDRO> GetAllDistricts(string url)
        {
            PRO_tblDistrictDRO result = new PRO_tblDistrictDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<PRO_tblDistrictDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.DistrictList = response_collection.DistrictList;
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

        public async static Task<PRO_tblDistrictDRO> GetDistrictItem(string url)
        {
            PRO_tblDistrictDRO result = new PRO_tblDistrictDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<PRO_tblDistrictDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.DistrictItem = response_collection.DistrictItem;
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

        public async static Task<PRO_tblDistrictDRO> InsertUpdateDistrict(string url, string json_data)
        {
            PRO_tblDistrictDRO result = new PRO_tblDistrictDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<PRO_tblDistrictDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.ResponseItem = response_collection.ResponseItem;
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

        public async static Task<PRO_tblDistrictDRO> DeleteDistrict(string url)
        {
            PRO_tblDistrictDRO result = new PRO_tblDistrictDRO();
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
                    var response_collection = JsonConvert.DeserializeObject<PRO_tblDistrictDRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.ResponseItem = response_collection.ResponseItem;
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
