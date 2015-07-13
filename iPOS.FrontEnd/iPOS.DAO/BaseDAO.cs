using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace iPOS.DAO
{
    public class BaseDAO
    {
        public static async Task<object> HttpGet(string url)
        {
            var result = "";
            using(HttpClient client=new HttpClient())
            using(HttpResponseMessage response=await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                result = await content.ReadAsStringAsync();
            }

            return result;
        }
    }
}
