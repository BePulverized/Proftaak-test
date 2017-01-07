using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Proftaak_test
{
    static class DatabaseManager
    {
        public static IDatabaseConnector Connector { get; set; }

        public static string ConnectionString { get; set; }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        static DatabaseManager()
        {

            Connector = new MSSQLConnector(ConfigurationManager.ConnectionStrings["Azure"].ConnectionString);
        }
    }
}