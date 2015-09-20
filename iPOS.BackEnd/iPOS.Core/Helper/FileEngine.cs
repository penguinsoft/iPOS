using System;
using System.IO;

namespace iPOS.Core.Helper
{
    public class FileEngine
    {
        public static bool CheckExistDirectory(string strPath)
        {
            return Directory.Exists(strPath);
        }

        public static bool CheckExistFile(string strPath)
        {
            return File.Exists(strPath);
        }

        public static void CreateDirectory(string strPath)
        {
            if (!CheckExistDirectory(strPath))
                Directory.CreateDirectory(strPath);
        }

        public static void CreateFile(string strPath)
        {
            if (!CheckExistFile(strPath))
            {
                FileStream f = File.Create(strPath);
                f.Flush();
                f.Close();
            }
        }

        public static string CreateFileName(string type)
        {
            string extension = "";
            switch (type)
            {
                case "image": extension = "png"; break;
            }
            string fileName = string.Format(@"{0:D4}{1:D2}{2:D2}{3:D2}{4:D2}{5:D2}{6}.{7}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Ticks, extension);

            return fileName;
        }

        public static string CreateFile(string data, string type, string owner)
        {
            string result = "", directory = AppDomain.CurrentDomain.BaseDirectory;
            switch (type)
            {
                case "image": 
                    result = @"Data\Images\" + owner;
                    directory += result;
                    break;
            }
            CreateDirectory(directory);
            string tmp = @"\" + CreateFileName(type);
            result += tmp;
            directory += tmp;
            using (System.IO.FileStream file = new System.IO.FileStream(directory, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                var m = new System.IO.MemoryStream(Convert.FromBase64String(data));
                m.WriteTo(file);
            }

            return result;
        }
    }
}
