using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using ICT4Rails_ASP.Enumerations;
using Proftaak_test.Repository;

namespace Proftaak_test.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepo empRepo = new EmployeeRepo(new EmployeeDBContext());
        // GET: Employee
        public ActionResult Index()
        {
            employeeViewModel viewmodel = new employeeViewModel();
            viewmodel.employeeList = empRepo.GetAllEmployees();
            return View(viewmodel);
        }

        public class employeeViewModel
        {
            
            public List<Employee> employeeList { get; set; }
            public Employee employee { get; set; }

            public List<Function> functions = new List<Function>()
            {
                new Function(1, "Remisebeheerder", Rights.UpdateTrain),
                new Function(2, "Schoonmaakchef", Rights.Clean),
                new Function(3, "ReparatieChef", Rights.Repair)
            };


        }

       
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                empRepo.Create(employee);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            return RedirectToAction("Index");
        }
    }
}