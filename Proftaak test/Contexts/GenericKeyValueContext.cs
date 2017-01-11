using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using ICT4Rails.Contexts;
using ICT4Rails.Models;
using Proftaak_test;

namespace Proftaak_test
{
    public abstract class GenericKeyValueContext : IGenericKeyValueContext
    {
        private string _tableName;
        private List<GenericKeyValueModel> _genericKeyValues;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GenericKeyValueContext(string tableName)
        {
            _tableName = tableName;
            GetAll();
        }

        public List<GenericKeyValueModel> GenericKeyValues
        {
            get
            {
                return _genericKeyValues;
//                if (GenericKeyValues.Count > 0)
//                {
//                    return GenericKeyValues;
//                }
//                else
//                {
//                    return GetAll();
//                }
            }

            private set { _genericKeyValues = value; }
        }

        public void Create(GenericKeyValueModel genericKeyValueModel) {
            GenericKeyValues.Add(genericKeyValueModel);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"INSERT INTO {_tableName} (name)" +
                              "VALUES(@name)";
            cmd.Parameters.AddWithValue("@name", genericKeyValueModel.Name);
            DatabaseManager.connector.NonQuery(cmd);
        }

        public void Delete(GenericKeyValueModel genericKeyValueModel) {
            GenericKeyValues.Remove(genericKeyValueModel);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"DELETE FROM {_tableName}" +
                               $" WHERE {_tableName}.id = @id";
            cmd.Parameters.AddWithValue("@id", genericKeyValueModel.Id);
            DatabaseManager.connector.NonQuery(cmd);
            //todo: what if genericKeyValueModel doesnt exist?
        }

        public List<GenericKeyValueModel> GetAll() {
            GenericKeyValues = new List<GenericKeyValueModel>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * " +
                              $"FROM {_tableName}";
            using (DatabaseManager.connector)
            {
                DatabaseManager.connector.Open();
                using (DbDataReader reader = DatabaseManager.connector.Query(cmd))
                {
                    while (reader.Read())
                    {
                        GenericKeyValueModel genericKeyValueModel = new GenericKeyValueModel();
                        genericKeyValueModel.Id = reader.GetInt32(0);
                        genericKeyValueModel.Name = reader.GetString(1);
                        GenericKeyValues.Add(genericKeyValueModel);
                    }
                }
            }
            return GenericKeyValues;
        }

        public void Update(GenericKeyValueModel genericKeyValueModel) {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"UPDATE {_tableName} SET name=@name" +
                               $" WHERE{_tableName}.id = @id";
            cmd.Parameters.AddWithValue("@id", genericKeyValueModel.Id);
            cmd.Parameters.AddWithValue("@name", genericKeyValueModel.Name);
            DatabaseManager.connector.NonQuery(cmd);
        }
    }
}