using System;

namespace iPOS.Core.Helper
{
    public static class ConfigEngine
    {
        #region [System]
        public static string CaptionPath
        {
            get { return IOEngine.Read("System", "CaptionPath") + ""; }
        }

        public static string MessagePath
        {
            get { return IOEngine.Read("System", "MessagePath") + ""; }
        }
        #endregion

        #region [Extensions]
        public static string LogPath
        {
            get { return IOEngine.Read("Extensions", "LogPath") ?? @"C:\iPOSLog"; }
        }

        public static string IPWAN
        {
            get { return IOEngine.Read("Extensions", "IPWAN"); }
        }

        public static string IPLAN
        {
            get { return IOEngine.Read("Extensions", "IPLAN"); }
        }

        public static string MacAddress
        {
            get { return IOEngine.Read("Extensions", "MacAddress"); }
        }
        #endregion

        #region [Initialize]
        public static string Language
        {
            get
            {
                var language = IOEngine.Read<string>("Initialize", "Language", "vi-VN");
                if (language.ToLower().Equals("vi-vn"))
                    return "vi";
                else return "en";
            }
        }

        public static string Username
        {
            get { return IOEngine.Read<string>("Initialize", "Username", ""); }
        }

        public static string Password
        {
            get { return IOEngine.Read<string>("Initialize", "Password", ""); }
        }
        #endregion

        #region [Connection]
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
            get { return IOEngine.Read("Connection", "ServiceName") + ".svc"; }
        }

        public static string ServerUri(bool is_service = true)
        {
            string result = "";
            if (!string.IsNullOrEmpty(PortNumber))
                result = Domain + ":" + PortNumber;
            else result = Domain;

            result += "/";
            if (is_service)
                result += ServiceName;

            return result;
        }
        #endregion

        #region [Format]
        public static string DateFormat
        {
            get { return IOEngine.Read<string>("Format", "DateFormat", "dd/MM/yyyy"); }
        }

        public static string TimeFormat
        {
            get { return IOEngine.Read("Format", "TimeFormat", "HH:mm:ss tt"); }
        }

        public static string DateTimeFormat
        {
            get { return IOEngine.Read("Format", "DateTimeFormat", "dd/MM/yyyy HH:mm:ss tt"); }
        }
        #endregion
    }
}
