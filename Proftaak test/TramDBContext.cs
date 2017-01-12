using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;



namespace Proftaak_test
{
    public class TramDBContext
    {
        public Sector GetDriveInSector()
        {
            Sector returnSector = null;
            string query = "SELECT TOP 1 SP.NUMMER, S.NUMMER FROM SECTOR S JOIN SPOOR SP ON SP.ID = S.SPOOR_ID WHERE S.BESCHIKBAAR = 1 AND SP.BESCHIKBAAR = 1 AND S.BLOKKADE = 0 AND S.TRAM_ID IS NULL ORDER BY SP.ID ASC";
            using (SqlConnection connection = DatabaseManager.Connection) {
                 using (SqlCommand command = new SqlCommand(query, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int spoornummer = Convert.ToInt32(reader.GetDecimal(0));
                            int sectornummer = Convert.ToInt32(reader.GetDecimal(1));

                            Spoor spoor = new Spoor(spoornummer);
                           returnSector = new Sector(sectornummer, spoor, null);

                        }
                    }

                }
             }

            return returnSector;
        }

        public List<Tram> GetAllTrams()
        {
            List<Tram> returnList = new List<Tram>();
            string query = "SELECT T.ID, T.NUMMER, TT.ID, TT.OMSCHRIJVING, T.LENGTE, T.VERVUILD, T.DEFECT, T.CONDUCTEURGESCHIKT  FROM TRAM T JOIN TRAMTYPE TT ON T.TRAMTYPE_ID = TT.ID WHERE BESCHIKBAAR = 0";
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal tramid = reader.GetDecimal(0);
                            decimal nummer = reader.GetDecimal(1);
                            decimal typeid = reader.GetDecimal(2);
                            string typeomschrijving = reader.GetString(3);
                            decimal lengte = reader.GetDecimal(4);
                            bool vervuild = reader.GetBoolean(5);
                            bool defect = reader.GetBoolean(6);
                            bool conducteurgeschikt = reader.GetBoolean(7);

                            Tram tram = new Tram(tramid, nummer,lengte, vervuild, defect, conducteurgeschikt, new Tramtype(typeid, typeomschrijving));
                            returnList.Add(tram);


                        }
                    }

                }
            }

            return returnList;
        }

        public Tram GetTrambyID(int id)
        {
            Tram tram = null;
            string query = "SELECT T.ID, T.NUMMER, TT.ID, TT.OMSCHRIJVING, T.LENGTE, T.VERVUILD, T.DEFECT, T.CONDUCTEURGESCHIKT  FROM TRAM T JOIN TRAMTYPE TT ON T.TRAMTYPE_ID = TT.ID WHERE T.ID = @ID";
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal tramid = reader.GetDecimal(0);
                            decimal nummer = reader.GetDecimal(1);
                            decimal typeid = reader.GetDecimal(2);
                            string typeomschrijving = reader.GetString(3);
                            decimal lengte = reader.GetDecimal(4);
                            bool vervuild = reader.GetBoolean(5);
                            bool defect = reader.GetBoolean(6);
                            bool conducteurgeschikt = reader.GetBoolean(7);

                            tram = new Tram(tramid, nummer, lengte, vervuild, defect, conducteurgeschikt, new Tramtype(typeid, typeomschrijving));
                           


                        }
                    }
                    
                }

                
            }

            return tram;
        }
    }
}