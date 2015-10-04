using iPOS.DRO.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPOS.DAO.Products
{
    public class PRO_tblLevel1DAO : BaseDAO
    {
        public async static Task<PRO_tblLevel1DRO> GetAllLevel1(string url)
        {
            PRO_tblLevel1DRO result = new PRO_tblLevel1DRO();
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
                    var response_collection = JsonConvert.DeserializeObject<PRO_tblLevel1DRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.Level1List = response_collection.Level1List;
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

        public async static Task<PRO_tblLevel1DRO> GetLevel1ByID(string url)
        {
            PRO_tblLevel1DRO result = new PRO_tblLevel1DRO();
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
                    var response_collection = JsonConvert.DeserializeObject<PRO_tblLevel1DRO>(response_data + "");

                    if (response_collection != null)
                    {
                        result.Level1Item = response_collection.Level1Item;
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

        public async static Task<PRO_tblLevel1DRO> InsertUpdateLevel1(string url, string json_data)
        {
            PRO_tblLevel1DRO result = new PRO_tblLevel1DRO();
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
                    var response_collection = JsonConvert.DeserializeObject<PRO_tblLevel1DRO>(response_data + "");

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

        public async static Task<PRO_tblLevel1DRO> DeleteLevel1(string url)
        {
            PRO_tblLevel1DRO result = new PRO_tblLevel1DRO();
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
                    var response_collection = JsonConvert.DeserializeObject<PRO_tblLevel1DRO>(response_data + "");

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
