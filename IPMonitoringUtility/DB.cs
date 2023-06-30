using System;
using System.Data.SqlClient;

namespace pong
{
    public class PONGDB
    {
        public class dbconfig
        {
            public const String DataSource = "";
            public const String UserID = "";
            public const String Password = "!";
            public const String InitialCatalog = "";

        }
        public class dbdispositivo
        {
            public Int64 ID;
            public String IP;
            public String chequearPreviamenteIP;
        }
    }
}