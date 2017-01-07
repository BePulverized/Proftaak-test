using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;


namespace Proftaak_test
{
    internal class MSSQLConnector : IDatabaseConnector
    {
        private DbConnection connection;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        /// <param name="connectionString">The connectionstring to use to connect to the database</param>
        public MSSQLConnector(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Manually change the connection string. Please don't do this. Be gentle. 
        /// Opens a connection after as a test. Closes it, too.
        /// </summary>
        /// <param name="connectionString">Connectionstring to use to connect to the database</param>
        public void Connect(string connectionString)
        {
            connection.ConnectionString = connectionString;
            Open();
            Close();
        }

        /// <summary>
        /// Queries the database with a command and receives a response
        /// </summary>
        /// <param name="command">The SqlCommand</param>
        /// <returns>The SqlDataReader that can be used to read the results</returns>
        public DbDataReader Query(DbCommand command)
        {
            using (command)
            {
                Open();
                command.Connection = connection;
                var returns = command.ExecuteReader();
                //return command.ExecuteReader();
                return returns;
            }
            Close();
        }

        /// <summary>
        /// Queries the Database with a string. For sanity and security reasons, please use command instead.
        /// </summary>
        /// <param name="query">The MSSQL Query string to use</param>
        /// <returns>The SqlDataReader that can be used to read the results</returns>
        public DbDataReader Query(string query) {
            using (DbCommand command = new SqlCommand(query, (SqlConnection)connection)) {
                Open();
                return command.ExecuteReader();
            }
            Close();
        }

        /// <summary>
        /// Queries the database with a command but receives no response. 
        /// Handles Opening and Closing the connection itself.
        /// </summary>
        /// <param name="command">The SqlCommand</param>
        public void NonQuery(DbCommand command)
        {
            Open();
            using (command)
            {
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
            Close();
        }

        /// <summary>
        /// Queries the Database with a string but receives no response. For sanity and security reasons, please use command instead.
        /// Handles opening and closing the connection itself.
        /// </summary>
        /// <param name="query">The MSSQL Query string to use</param>
        public void NonQuery(string query)
        {
            Open();
            using (DbCommand command = new SqlCommand(query, (SqlConnection)connection)) {
            command.ExecuteNonQuery();
            }
            Close();
        }

        /// <summary>
        /// Tries to open the database connection
        /// </summary>
        public void Open()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            else
            {
                Console.WriteLine("Tried to open connection, state was: " + connection.State);
            }
        }

        /// <summary>
        /// Tries to close the database connection.
        /// </summary>
        public void Close()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            else
            {
                Console.WriteLine("Closed a connection that wasn't open, trying to proceed anyway. State was: " + connection.State);
                connection.Close();
            }
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Close();
        }
    }
}