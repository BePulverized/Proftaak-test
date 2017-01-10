using System;
using System.Collections.Generic;
using System.Data;
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
            
            string query = "SELECT M.ID, M.VOORNAAM, M.ACHTERNAAM, M.TELEFOONNUMMER, M.BANKREKENINGNUMMER, M.GEBRUIKERSNAAM, M.WACHTWOORD, F.ID, F.NAAM FROM MEDEWERKER M JOIN FUNCTIE F ON F.ID = M.FUNCTIE_ID";
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int employeeID = Convert.ToInt32(reader.GetDecimal(0));
                            string surname = reader.GetString(1);
                            string lastname = reader.GetString(2);
                            string phonenumber = reader.GetString(3);
                            string banknumber = reader.GetString(4);
                            string username = reader.GetString(5);
                            string password = reader.GetString(6);
                            int functionID = Convert.ToInt32(reader.GetDecimal(7));
                            string functionName = reader.GetString(8);
                           
                            Employee newEmployee = new Employee(employeeID, lastname, surname, username, password,
                                new Function(functionID, functionName, Rights.CreateUser),
                                phonenumber, banknumber);
                            returnEmployees.Add(newEmployee);
                        }
                    }
                }
            }
                return returnEmployees;
        }

        public bool Create(Employee employee)
        {
            string query = "INSERT INTO MEDEWERKER(Functie_ID, Voornaam, Achternaam, Telefoonnummer, Bankrekeningnummer, Gebruikersnaam, Wachtwoord) VALUES(1, @Surname, @name, @Phonenumber, @Banknumber, @Username, @Password)";
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Surname", employee.SurName);
                    command.Parameters.AddWithValue("@name", employee.Name);
                    command.Parameters.AddWithValue("@Phonenumber", employee.TelephoneNumber);
                    command.Parameters.AddWithValue("@Banknumber", employee.BankNumber);
                    command.Parameters.AddWithValue("@Username", employee.UserName);
                    command.Parameters.AddWithValue("@Password", employee.Password);
                    
                    try
                    {
                        command.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
            }
            return true;
        }

        public Employee GetAllEmployeeById(int id)
        {
            Employee returnEmployee = null;

            string query = "SELECT M.ID, M.VOORNAAM, M.ACHTERNAAM, M.TELEFOONNUMMER, M.BANKREKENINGNUMMER, M.GEBRUIKERSNAAM, M.WACHTWOORD, F.ID, F.NAAM FROM MEDEWERKER M JOIN FUNCTIE F ON F.ID = M.FUNCTIE_ID WHERE M.ID = @ID";
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int employeeID = Convert.ToInt32(reader.GetDecimal(0));
                            string surname = reader.GetString(1);
                            string lastname = reader.GetString(2);
                            string phonenumber = reader.GetString(3);
                            string banknumber = reader.GetString(4);
                            string username = reader.GetString(5);
                            string password = reader.GetString(6);
                            int functionID = Convert.ToInt32(reader.GetDecimal(7));
                            string functionName = reader.GetString(8);

                            returnEmployee = new Employee(employeeID, lastname, surname, username, password,
                                new Function(functionID, functionName, Rights.CreateUser),
                                phonenumber, banknumber);
                            
                        }
                    }
                }
            }
            return returnEmployee;
        }

        public bool Update(Employee employee)
        {
            string query = "UPDATE MEDEWERKER SET Voornaam=@Surname, Achternaam=@name, Telefoonnummer=@Phonenumber, Bankrekeningnummer=@Banknumber, Gebruikersnaam=@Username, Wachtwoord=@Password where id = @ID";
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", employee.ID);
                    command.Parameters.AddWithValue("@Surname", employee.SurName);
                    command.Parameters.AddWithValue("@name", employee.Name);
                    command.Parameters.AddWithValue("@Phonenumber", employee.TelephoneNumber);
                    command.Parameters.AddWithValue("@Banknumber", employee.BankNumber);
                    command.Parameters.AddWithValue("@Username", employee.UserName);
                    command.Parameters.AddWithValue("@Password", employee.Password);

                    try
                    {
                        command.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
            }
            return true;
        }
    }
}