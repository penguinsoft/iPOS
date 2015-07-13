using System;

namespace iPOS.Core.Helper
{
    public static class ConfigEngine
    {
        public static string CaptionPath
        {
            get { return IOEngine.Read("System", "CaptionPath") + ""; }
        }

        public static string MessagePath
        {
            get { return IOEngine.Read("System", "MessagePath") + ""; }
        }

        public static string Language
        {
            get
            {
                var language = IOEngine.Read("Initialize", "Language") + "";
                if (language.ToLower().Equals("vi-vn"))
                    return "vi";
                else return "en";
            }
        }

        public static string Username
        {
            get { return IOEngine.Read("Initialize", "Username"); }
        }

        public static string Password
        {
            get { return IOEngine.Read("Initialize", "Password"); }
        }

        public static string Domain
        {
            get { return IOEngine.Read("Connection", "Domain"); }
        }

        public static string PortNumber
        {
            get { return IOEngine.Read("Connection", "PortNumber"); }
        }

        public static string ServiceName
        {
            get { return IOEngine.Read("Connection", "ServiceName"); }
        }
    }
}
