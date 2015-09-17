using System;
using System.Drawing;
using System.Threading.Tasks;
using iPOS.Core.Logger;
using iPOS.DAO;
using iPOS.DRO.Systems;
using iPOS.DTO.Systems;
using Newtonsoft.Json;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;

namespace iPOS.BUS
{
    public class BaseBUS
    {
        protected static ILogEngine logger = new LogEngine();

        public static string GetBaseUrl()
        {
            string result = "";
            try
            {
                if (!string.IsNullOrEmpty(ConfigEngine.PortNumber))
                    result = ConfigEngine.Domain + ":" + ConfigEngine.PortNumber;
                else result = ConfigEngine.Domain;

                return result + "/" + ConfigEngine.ServiceName + ".svc";
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return "";
        }

        public static async Task<string> Upload(Bitmap bitmap)
        {
            try
            {
                string url = string.Format(@"{0}/FileUpload", GetBaseUrl());
                var json_data = "{\"bitmap\":" + JsonConvert.SerializeObject(new iPOS.DTO.Tools.OBJ_ImageDTO() { Image = bitmap, I = 666 }, new ImageConverter()) + "}";
                return await BaseDAO.HttpPost(url, json_data);
            }
            catch
            {
            }
            return "";
        }
    }

    public class ImageConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Bitmap);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var m = new System.IO.MemoryStream(Convert.FromBase64String((string)reader.Value));
            return (Bitmap)Bitmap.FromStream(m);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Bitmap bmp = (Bitmap)value;
            System.IO.MemoryStream m = new System.IO.MemoryStream();
            bmp.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);

            writer.WriteValue(Convert.ToBase64String(m.ToArray()));
        }
    }
}
