﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using iPOS.Core.Logger;
using iPOS.DRO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;
using iPOS.Core.Helper;

namespace iPOS.DAO
{
    public class BaseDAO
    {
        protected static ILogEngine logger = new LogEngine();

        public static async Task<string> HttpGet(string url)
        {
            var result = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Basic aGVsbGRlbW9uczpfUEBzc3cwcmRz");
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    using (HttpContent content = response.Content)
                    {
                        result = MessageEngine.GetHTTPStatusCodes(response.StatusCode);
                        if (string.IsNullOrEmpty(result))
                            result = await content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public static async Task<string> HttpPost(string url, string json_data)
        {
            var result = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Basic aGVsbGRlbW9uczpfUEBzc3cwcmRz");
                    using (HttpResponseMessage response = await client.PostAsync(url, new StringContent(json_data, Encoding.UTF8, "application/json")))
                    using (HttpContent content = response.Content)
                    {
                        result = await content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public static async Task<string> ManageActionLog(string url, string json_data)
        {
            string result = "";
            try
            {
                var response_data = await HttpPost(url, json_data) + "";
                var response_collection = JsonConvert.DeserializeObject<SYS_tblActionLogDRO>(response_data + "");

                if (response_collection != null)
                    result = "";
            }
            catch (Exception ex)
            {
                result = ex.Message;
                logger.Error(ex);
            }

            return result;
        }
    }
}
