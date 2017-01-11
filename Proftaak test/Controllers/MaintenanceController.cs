using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proftaak_test.Contexts;
using Proftaak_test.Repository;

namespace Proftaak_test.Controllers
{
    public class MaintenanceController : Controller
    {
        private MaintenanceDbContext dbContext; //how does DI work in asp.net 4.6???
        private TramDBContext tramDbContext;
        private EmployeeRepo employeeRepo;
        private GenericKeyValueContext onderhoudsTypeContext;

        public MaintenanceController()
        {
            dbContext = new MaintenanceDbContext();
            tramDbContext = new TramDBContext();
            onderhoudsTypeContext = new OnderhoudsTypeContext();
            employeeRepo = new EmployeeRepo(new EmployeeDBContext());
        }
        // GET: Maintenance
        public ActionResult Index()
        {
            //if (Session["curEmployeeID"] == null)
            //{
            //    return RedirectToAction("Login", "Employee");
            //}
            //else
            //{
            PopulateViewBag();
            return View();
            //}
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Maintenance
        public ActionResult Index(TramOnderhoud maintenance)
        {
            //if (Session["curEmployeeID"] == null)
            //{
            //    return RedirectToAction("Login", "Employee");
            //}
            //else
            //{
            if (ModelState.IsValid)
            {
                dbContext.Create(maintenance);
            }
            PopulateViewBag();
            return View();
            //}
        }

        private void PopulateViewBag()
        {
            ViewBag.Schoonmaaks = dbContext.Maintenances
                .Where(m =>
                m.Onderhoudstypeid < 2
                && m.BeschikbaarDatum == null
                && m.DatumTijdstip < DateTime.Now.AddHours(12));
            ViewBag.Repairs = dbContext.Maintenances
                .Where(m =>
                m.Onderhoudstypeid > 1
                && m.BeschikbaarDatum == null
                && m.DatumTijdstip < DateTime.Now.AddHours(12));
            ViewBag.TramId = tramDbContext.GetAllTrams().Select(t
               => new SelectListItem() { Text = t.Nummer.ToString(), Value = t.Id.ToString() });
            ViewBag.Onderhoudstypeid = onderhoudsTypeContext.GetAll().Where(o => o.Id > 1).Select(s =>
            new SelectListItem() { Text = s.Name, Value = s.Id.ToString() });
            ViewBag.MedewerkerId = employeeRepo.GetAllEmployees().Where(sr => sr.Function.ID == 3 || sr.Function.ID == 4).Select(e =>
                    new SelectListItem() { Text = e.SurName + " " + e.LastName, Value = e.ID.ToString() });
        }

        public ActionResult Delete(decimal id)
        {
            dbContext.Delete(new TramOnderhoud() { Id = id});
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var maints = dbContext.Maintenances;
            return View(maints);
        }

        public ActionResult Complete(decimal id)
        {
            var maint = dbContext.Maintenances.First(m => m.Id == id);
            maint.BeschikbaarDatum = DateTime.Now;
         dbContext.Update(maint);   
            return RedirectToAction("List");
        }
    }
}