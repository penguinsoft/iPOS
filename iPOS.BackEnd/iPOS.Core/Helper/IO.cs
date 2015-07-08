using System;
using System.Runtime.InteropServices;
using System.Text;

namespace iPOS.Core.Helper
{
    public static class IO
    {
        private static string FileName
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "Config.ini"; }
        }

        //public IO()
        //{
        //    FileName = AppDomain.CurrentDomain.BaseDirectory + "Config.ini";
        //}

        //public IO(string strFileName)
        //{
        //    FileName = AppDomain.CurrentDomain.BaseDirectory + strFileName;
        //}

        public static string Read(string strSection, string strKey)
        {
            try
            {
                StringBuilder builder = new StringBuilder(1024);
                GetPrivateProfileString(strSection, strKey, "", builder, 1024, FileName);
                return builder.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static bool Write(string strSection, string strKey, string strValue)
        {
            bool flag = false;
            try
            {
                IO.WritePrivateProfileString(strSection, strKey, strValue, FileName);
                flag = true;
            }
            catch { flag = false; }

            return flag;
        }

        [DllImport("kernel32", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern long WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
    }
}
