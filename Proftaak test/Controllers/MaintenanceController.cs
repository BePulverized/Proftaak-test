using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proftaak_test.Contexts;
using Proftaak_test.Enumerations;
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

        [HttpGet]
        public ActionResult List(SortMode sort = SortMode.Default)
        {
            ViewBag.SortMode = sort;
            dbContext.Maintenances.ForEach(t => 
            t.Employee = employeeRepo.GetEmployeebyID(Convert.ToInt32(t.MedewerkerId.GetValueOrDefault())));
            dbContext.Maintenances.ForEach(t =>
                    t.Tram = tramDbContext.GetAllTrams().First(tram => tram.Id == t.TramId.GetValueOrDefault()));
            var maints = dbContext.Maintenances;
            if (sort == SortMode.DateFinishedAsc)
            {
                maints =
                    dbContext.Maintenances.Where(m => m.BeschikbaarDatum != null)
                        .OrderBy(m => m.BeschikbaarDatum.Value)
                        .ToList();
                maints.AddRange(dbContext.Maintenances.Where(m => m.BeschikbaarDatum == null));
            }
            else if (sort == SortMode.DateFinishedDesc)
            {
                maints = dbContext.Maintenances.Where(m => m.BeschikbaarDatum == null).ToList();
                maints.AddRange(dbContext.Maintenances.Where(m => m.BeschikbaarDatum != null)
        .OrderByDescending(m => m.BeschikbaarDatum.Value)
        .ToList());
            } else if (sort == SortMode.DateStartedAsc)
            {
                maints =
    dbContext.Maintenances.Where(m => m.DatumTijdstip != null)
        .OrderBy(m => m.DatumTijdstip.Value)
        .ToList();
                maints.AddRange(dbContext.Maintenances.Where(m => m.DatumTijdstip == null));
            } else if (sort == SortMode.DateStartedDesc)
            {
                maints = dbContext.Maintenances.Where(m => m.DatumTijdstip == null).ToList();
                maints.AddRange(dbContext.Maintenances.Where(m => m.DatumTijdstip != null)
        .OrderByDescending(m => m.DatumTijdstip.Value)
        .ToList());
            } else if (sort == SortMode.Type)
            {
                maints = maints.OrderBy(m => m.Onderhoudstypeid).ToList();
            }
            return View(maints);
        }

        public ActionResult PrintList()
        {
            dbContext.Maintenances.ForEach(t =>
            t.Employee = employeeRepo.GetEmployeebyID(Convert.ToInt32(t.MedewerkerId.GetValueOrDefault())));
            dbContext.Maintenances.ForEach(t =>
                    t.Tram = tramDbContext.GetAllTrams().First(tram => tram.Id == t.TramId.GetValueOrDefault()));
            var maints = dbContext.Maintenances
                .Where(m =>
                    m.BeschikbaarDatum == null
                    && m.DatumTijdstip < DateTime.Now.AddHours(12));
            return View(maints);
        }
        public ActionResult MyList()
        {
            if (Session["curEmployeeID"] == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            var maints =
                dbContext.Maintenances.Where(
                    m => m.MedewerkerId != null && m.MedewerkerId == Convert.ToInt32(Session["curEmployeeID"]) && m.BeschikbaarDatum == null && m.BeschikbaarDatum < DateTime.Now.AddHours(12)).OrderBy(s => s.Onderhoudstypeid);
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