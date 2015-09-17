using System;
using System.Runtime.InteropServices;
using System.Text;

namespace iPOS.Core.Helper
{
    public static class IOEngine
    {
        private static string FileName
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "Config.ini"; }
        }

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

        public static T Read<T>(string strSection, string strKey, T default_value)
        {
            string tmp = Read(strSection, strKey);
            if (string.IsNullOrEmpty(tmp)) return default_value;
            else return (T)(object)tmp;
        }

        public static bool Write(string strSection, string strKey, string strValue)
        {
            bool flag = false;
            try
            {
                IOEngine.WritePrivateProfileString(strSection, strKey, strValue, FileName);
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
