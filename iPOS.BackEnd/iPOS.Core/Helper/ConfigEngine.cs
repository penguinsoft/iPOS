using System;

namespace iPOS.Core.Helper
{
    public static class ConfigEngine
    {
        public static string ServerName
        {
            get { return IOEngine.Read("Database", "ServerName"); }
            set
            {
                if (IOEngine.Write("Database", "ServerName", value))
                    ServerName = value;
            }
        }

        public static string UserName
        {
            get { return IOEngine.Read("Database", "UserName"); }
            set
            {
                if (IOEngine.Write("Database", "UserName", value))
                    UserName = value;
            }
        }

        public static string Password
        {
            get { return IOEngine.Read("Database", "Password"); }
            set
            {
                if (IOEngine.Write("Database", "Password", value))
                    Password = value;
            }
        }

        public static string Database
        {
            get { return IOEngine.Read("Database", "Database"); }
            set
            {
                if (IOEngine.Write("Database", "Database", value))
                    Database = value;
            }
        }

        public static string IsEncrypt
        {
            get { return IOEngine.Read("Database", "IsEncrypt"); }
            set
            {
                if (IOEngine.Write("Database", "IsEncrypt", value))
                    IsEncrypt = value;
            }
        }

        public static string LogPath
        {
            get { return IOEngine.Read("Extensions", "LogPath") ?? @"C:\iPOSLog"; }
        }
    }
}
