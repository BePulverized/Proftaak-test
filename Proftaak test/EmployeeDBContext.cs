using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;



namespace Proftaak_test
{
    public class EmployeeDBContext
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> returnEmployees = new List<Employee>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT M.ID, M.VOORNAAM, M.ACHTERNAAM, M.TELEFOONNUMMER, M.BANKREKENINGNUMMER, M.GEBRUIKERSNAAM, M.WACHTWOORD, F.ID, F.NAAM, R.OMSCHRIJVING FROM MEDEWERKER M JOIN FUNCTIE F ON F.ID = M.FUNCTIE_ID JOIN FUNCTIE_RECHT FR ON FR.FUNCTIE_ID = F.ID JOIN RECHT R ON FR.RECHT_ID = R.ID";
            using (DatabaseManager.Connector)
            {
                DatabaseManager.Connector.Open();
                using (DbDataReader reader = DatabaseManager.Connector.Query(cmd))
                {
                    while (reader.Read())
                    {
                        int employeeID = reader.GetInt32(0);
                        string surname = reader.GetString(1);
                        string lastname = reader.GetString(2);
                        string phonenumber = reader.GetString(3);
                        string banknumber = reader.GetString(4);
                        string username = reader.GetString(5);
                        string password = reader.GetString(6);
                        string functionID = re
                    }
                }
            }
                return returnEmployees;
        }
    }
}