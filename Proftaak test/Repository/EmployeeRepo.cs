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
    }
}