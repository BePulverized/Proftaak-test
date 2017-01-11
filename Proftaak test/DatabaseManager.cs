using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proftaak_test
{
    public class DatabaseManager
    {
        private static readonly string connectionString = "Server=tcp:rails.database.windows.net,1433;Initial Catalog=railsDB;Persist Security Info=False;User ID=railRunner;Password=swasennard42!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        public static MSSQLConnector connector { get; set; } = new MSSQLConnector(connectionString);

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public static SqlConnection Connection
        {
            get
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
        }
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public static SqlConnection InternalConnection
        {
            get
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
        }
    }
}