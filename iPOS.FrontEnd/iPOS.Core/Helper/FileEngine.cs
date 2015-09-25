using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

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

        public static string CreateUniqueFileName()
        {
            return string.Format("{0:D4}{1:D2}{2:D2}{3:D2}{4:D2}{5:D2}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Ticks);
        }

        public static string CreateUniqueFileName(string prefix)
        {
            return string.Format("{0}_{1}", prefix, CreateUniqueFileName());
        }

        public static string GetImageFilterOpenFile()
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            return string.Format("({0})|{0}", string.Join(";", codecs.Select(codec => codec.FilenameExtension.ToLower()).ToArray())).Replace(";", "; ");
        }
    }
}
