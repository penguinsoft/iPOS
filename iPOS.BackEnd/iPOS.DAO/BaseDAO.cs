using System;
using iPOS.Core.SQLServer;

namespace iPOS.DAO
{
    public class BaseDAO
    {
        protected SQLEngine db;

        public BaseDAO()
        {
            db = new SQLEngine();
        }
    }
}
