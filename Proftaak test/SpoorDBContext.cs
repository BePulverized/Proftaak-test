using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;



namespace Proftaak_test
{
    public class SpoorDBContext
    {
        public List<Spoor> GetAllSporen()
        {
            List<Spoor> returnList = new List<Spoor>();
            
            string query = "SELECT S.ID, S.NUMMER, S.LENGTE, S.BESCHIKBAAR, S.INUITRIJSPOOR FROM SPOOR S";
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal spoorid = reader.GetDecimal(0);
                            decimal spoornummer = reader.GetDecimal(1);
                            int lengte = Convert.ToInt32(reader.GetDecimal(2));
                            bool beschikbaar = reader.GetBoolean(3);
                            bool inuitrij = reader.GetBoolean(4);
                            Spoor newSpoor = new Spoor(spoorid, spoornummer, lengte, beschikbaar, inuitrij);
                            
                            returnList.Add(newSpoor);
                        }
                    }
                }
            }
            return returnList;
        }

        
    }
}