using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proftaak_test
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public Function Function { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        [Required]
        public string BankNumber { get; set; }
        

        public Employee(int id, string name, string surName, string userName, string password, Function function, string telephoneNumber, string bankNumber)
        {
            ID = id;
            Name = name;
            SurName = surName;
            UserName = userName;
            Password = password;
            Function = function;
            TelephoneNumber = telephoneNumber;
            BankNumber = bankNumber;
        }

        public Employee(int id, string name, string surName, string userName, string password, string telephoneNumber, string bankNumber)
        {
            ID = id;
            Name = name;
            SurName = surName;
            UserName = userName;
            Password = password;
            
            TelephoneNumber = telephoneNumber;
            BankNumber = bankNumber;
        }


        public Employee()
        {
            
        }
    }
}