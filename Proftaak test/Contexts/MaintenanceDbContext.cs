using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using ICT4Rails;

namespace Proftaak_test
{
    class MaintenanceDbContext : IMaintenanceContext
    {

        public List<TramOnderhoud> Maintenances
        {
            get
            {
                if (_maintenances != null)
                {
                    _maintenances = _maintenances.OrderByDescending(m => m.DatumTijdstip.GetValueOrDefault().Date).ThenByDescending(m => m.Onderhoudstypeid).ToList();
                    return _maintenances;
                }
                else
                {
                    return GetAll();
                }
//                if (_maintenances.Count > 0)
//                {
//                    return _maintenances;
//                }
//                else
//                {
//                    return GetAll();
//                }
            }

            private set { _maintenances = value; }
        }

        private List<TramOnderhoud> _maintenances = null;

        public void Create(TramOnderhoud maintenance)
        {
            Maintenances.Add(maintenance);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO TRAM_ONDERHOUD (BeschikbaarDatum, DatumTijdstip, Tram_ID, ONDERHOUDSTYPEID, Medewerker_ID)" +
                              " VALUES(@maintainedDate, @scheduledDate, @tramId, @priorityId, @employeeId)";
            if (maintenance.BeschikbaarDatum != null)
            {
                cmd.Parameters.AddWithValue("@maintainedDate", maintenance.BeschikbaarDatum);
            }
            else
            {
                cmd.Parameters.AddWithValue("@maintainedDate", DBNull.Value);
            }
            if (maintenance.DatumTijdstip != null)
            {
                cmd.Parameters.AddWithValue("@scheduledDate", maintenance.DatumTijdstip);
            }
            else
            {
                cmd.Parameters.AddWithValue("@scheduledDate", DBNull.Value);
            }
            if (maintenance.TramId != null)
            {
                cmd.Parameters.AddWithValue("@tramId", maintenance.TramId);
            }
            else
            {
                cmd.Parameters.AddWithValue("@tramId", DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@priorityId", maintenance.Onderhoudstypeid);

            if (maintenance.MedewerkerId != null)
            {
                cmd.Parameters.AddWithValue("@employeeId", maintenance.MedewerkerId);
            }
            else
            {
                cmd.Parameters.AddWithValue("@employeeId", DBNull.Value);
            }
            DatabaseManager.connector.NonQuery(cmd);
        }

        public void Delete(TramOnderhoud maintenance)
        {
            Maintenances.Remove(maintenance);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM TRAM_ONDERHOUD" +
                               " WHERE TRAM_ONDERHOUD.ID = @id";
            cmd.Parameters.AddWithValue("@id", maintenance.Id);
            DatabaseManager.connector.NonQuery(cmd);
            //todo: what if maint doesnt exist?
        }

        public List<TramOnderhoud> GetAll()
        {
            Maintenances = new List<TramOnderhoud>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * " +
                              "FROM TRAM_ONDERHOUD";
            using (DatabaseManager.connector)
            {
                using (DbDataReader reader = DatabaseManager.connector.Query(cmd))
                {
                    while (reader.Read())
                    {
                        TramOnderhoud maintenance = new TramOnderhoud();
                        maintenance.Id = reader.GetDecimal(0);
                        if (!reader.IsDBNull(1))
                        {
                            maintenance.MedewerkerId = reader.GetDecimal(1);
                        }
                        else
                        {
                            maintenance.MedewerkerId = null;
                        }
                        if (!reader.IsDBNull(2))
                        {
                            maintenance.TramId = reader.GetDecimal(2);
                        }
                        else
                        {
                            maintenance.TramId = null;
                        }
                        if (!reader.IsDBNull(3))
                        {
                            maintenance.DatumTijdstip = reader.GetDateTime(3);
                        }
                        else
                        {
                            maintenance.DatumTijdstip = null;
                        }
                        if (!reader.IsDBNull(4))
                        {
                            maintenance.BeschikbaarDatum = reader.GetDateTime(4);
                        }
                        else
                        {
                            maintenance.BeschikbaarDatum = null;
                        }
                        maintenance.Onderhoudstypeid = reader.GetInt32(5);
                        Maintenances.Add(maintenance);
                    }
                }
            }
            return Maintenances;
        }

        public void Update(TramOnderhoud maintenance)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE TRAM_ONDERHOUD " +
                              "SET" +
                              " BeschikbaarDatum=@maintainedDate," +
                              " DatumTijdstip=@scheduledDate," +
                              " Medewerker_ID=@medewerkerId," +
                              " Tram_ID=@tramId," +
                              " ONDERHOUDSTYPEID=@priorityId" +
                               " WHERE TRAM_ONDERHOUD.ID = @id";
            cmd.Parameters.AddWithValue("@id", maintenance.Id);
            if (maintenance.MedewerkerId != null)
            {
                cmd.Parameters.AddWithValue("@medewerkerId", maintenance.MedewerkerId);
            }
            else
            {
                cmd.Parameters.AddWithValue("@medewerkerId", DBNull.Value);
            }
            if (maintenance.TramId != null)
            {
                cmd.Parameters.AddWithValue("@tramId", maintenance.TramId);
            }
            else
            {
                cmd.Parameters.AddWithValue("@tramId", DBNull.Value);
            }
            if (maintenance.DatumTijdstip != null)
            {
                cmd.Parameters.AddWithValue("@scheduledDate", maintenance.DatumTijdstip);
            }
            else
            {
                cmd.Parameters.AddWithValue("@scheduledDate", DBNull.Value);
            }
            if (maintenance.BeschikbaarDatum != null)
            {
                cmd.Parameters.AddWithValue("@maintainedDate", maintenance.BeschikbaarDatum);
            }
            else
            {
                cmd.Parameters.AddWithValue("@maintainedDate", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@priorityId", maintenance.Onderhoudstypeid);
            DatabaseManager.connector.NonQuery(cmd);
        }
    }
}