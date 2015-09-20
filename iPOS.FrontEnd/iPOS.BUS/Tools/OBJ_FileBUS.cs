using System;
using System.Drawing;
using System.Threading.Tasks;
using iPOS.DAO.Tools;
using Newtonsoft.Json;

namespace iPOS.BUS.Tools
{
    public class OBJ_FileBUS : BaseBUS
    {
        public async static Task<string> UploadImageFile(Bitmap image, string owner)
        {
            string url = string.Format(@"{0}/FileUpload", GetBaseUrl());
            var json_data = "{\"file\":" + JsonConvert.SerializeObject(new iPOS.DTO.Tools.OBJ_FileDTO() { Data = image, Key = 666,Type = "image", Owner = owner }, new iPOS.Core.Extensions.ImageConverter()) + "}";

            string tmp = await OBJ_FileDAO.UploadImageFile(url, json_data);
            if (tmp.StartsWith("Filename:")) tmp = tmp.Replace("Filename:", "");
            else tmp = "";

            return tmp;
        }
    }
}
