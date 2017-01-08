using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_test.Repository
{
    public class EmployeeRepo
    {
        private EmployeeDBContext context;

        public EmployeeRepo(EmployeeDBContext context)
        {
            this.context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return context.GetAllEmployees();
        }

        public bool Create(Employee employee)
        {
            return context.Create(employee);
        }

        public bool Login(string _username, string _password)
        {
            return context.Login(_username, _password);
        }

        public Employee EmployeeByUsername(string _username)
        {
            return context.EmployeeByUsername(_username);
        }
    }
}