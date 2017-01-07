using System;
using System.Data.Common;

namespace Proftaak_test
{
    public interface IDatabaseConnector : IDisposable
    {
        void Connect(string connectionString);
        DbDataReader Query(DbCommand command);
        DbDataReader Query(string query);
        void NonQuery(DbCommand command);
        void NonQuery(string query);
        void Open();
        void Close();
    }
}