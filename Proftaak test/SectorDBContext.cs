using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;



namespace Proftaak_test
{
    public class SectorDBContext
    {
        public List<Sector> GetAllSectors()
        {
            List<Sector> returnList = new List<Sector>();

            string query =
                "SELECT S.ID, S.SPOOR_ID, T.ID, T.NUMMER, TT.ID, TT.OMSCHRIJVING, T.LENGTE, T.VERVUILD, T.DEFECT, T.CONDUCTEURGESCHIKT, S.NUMMER, S.BESCHIKBAAR, S.BLOKKADE FROM SECTOR S left JOIN TRAM T ON S.TRAM_ID = T.ID left JOIN TRAMTYPE TT ON T.TRAMTYPE_ID = TT.ID";
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal sectorid = reader.GetDecimal(0);
                            decimal spoorid = reader.GetDecimal(1);
                            Tram tram = null;
                            if (!reader.IsDBNull(2))
                            {
                                decimal tramid = reader.GetDecimal(2);
                                decimal tramnummer = reader.GetDecimal(3);
                                decimal tramtypeid = reader.GetDecimal(4);
                                string tramtypeomschrijving = reader.GetString(5);
                                decimal tramlengte = reader.GetDecimal(6);
                                bool vervuild = reader.GetBoolean(7);
                                bool defect = reader.GetBoolean(8);
                                bool conducteur = reader.GetBoolean(9);
                                tram = new Tram(tramid, tramnummer, tramlengte, vervuild, defect, conducteur,
                                    new Tramtype(tramtypeid, tramtypeomschrijving));
                            }
                            decimal sectornummer = reader.GetDecimal(10);
                            bool sectorbeschikbaar = reader.GetBoolean(11);
                            bool sectorblokkade = reader.GetBoolean(12);

                            Sector sector = new Sector(sectorid, sectornummer, spoorid,
                                tram, sectorbeschikbaar, sectorblokkade);

                            returnList.Add(sector);
                        }
                    }
                }
            }
            return returnList;



        }
    }
}