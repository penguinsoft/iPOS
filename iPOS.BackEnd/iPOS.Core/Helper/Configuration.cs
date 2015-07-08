using System;

namespace iPOS.Core.Helper
{
    public static class Configuration
    {
        public static string ServerName
        {
            get { return IO.Read("Database", "ServerName"); }
            set
            {
                if (IO.Write("Database", "ServerName", value))
                    ServerName = value;
            }
        }

        public static string UserName
        {
            get { return IO.Read("Database", "UserName"); }
            set
            {
                if (IO.Write("Database", "UserName", value))
                    UserName = value;
            }
        }

        public static string Password
        {
            get { return IO.Read("Database", "Password"); }
            set
            {
                if (IO.Write("Database", "Password", value))
                    Password = value;
            }
        }

        public static string Database
        {
            get { return IO.Read("Database", "Database"); }
            set
            {
                if (IO.Write("Database", "Database", value))
                    Database = value;
            }
        }

        public static string IsEncrypt
        {
            get { return IO.Read("Database", "IsEncrypt"); }
            set
            {
                if (IO.Write("Database", "IsEncrypt", value))
                    IsEncrypt = value;
            }
        }
    }
}
