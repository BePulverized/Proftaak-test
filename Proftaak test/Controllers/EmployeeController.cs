using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Proftaak_test.Repository;

namespace Proftaak_test.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepo empRepo = new EmployeeRepo(new EmployeeDBContext());
        // GET: Employee
        public ActionResult Index(int? id)
        {
            employeeViewModel viewmodel = new employeeViewModel();
            viewmodel.employeeList = empRepo.GetAllEmployees();
            //viewmodel.employee = empRepo
            if (id != null)
            {
                viewmodel.editemployee = empRepo.GetEmployeebyID(Convert.ToInt32(id));
                return View(viewmodel);
            }
            
            return View(viewmodel);
        }

        

        public class employeeViewModel
        {
            
            public List<Employee> employeeList { get; set; }
            public Employee employee { get; set; }
            public Employee editemployee { get; set; }

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
        public ActionResult Update(Employee editemployee)
        {
            if (ModelState.IsValid)
            {
                empRepo.Update(editemployee);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            try {
                string username = Request.Form["username"];
                string password = Request.Form["password"];

                if (empRepo.Login(username, password)) {
                    Employee curEmployee = new Employee();
                    curEmployee = empRepo.EmployeeByUsername(username);

                    Session["curEmployeeID"] = curEmployee.ID;

                    //TODO: Fix link below
                    return RedirectToAction("Index", "Employee");
                }
                else {
                    return RedirectToAction("Login", "Employee");
                }
            }
            catch {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}