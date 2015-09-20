using System;
using System.Drawing;
using Newtonsoft.Json;

namespace iPOS.Core.Extensions
{
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
