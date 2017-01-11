using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proftaak_test.Repository;

namespace Proftaak_test.Controllers
{
    public class DriveInController : Controller
    {
        private TramRepo repo = new TramRepo(new TramDBContext());
        // GET: DriveIn
        [HttpGet]
        public ActionResult Index(int? id)
        {
            TramViewModel viewmodel = new TramViewModel();
            if (Session["curEmployeeID"] == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            else
            {
                if (id != null)
                {
                    
                    viewmodel.sector = repo.GetDriveInSector();
                    viewmodel.TramList = repo.GetAllTrams();
                    return View(viewmodel);
                }
                else
                {
                    viewmodel.sector = new Sector(000, new Spoor(00), null);
                    viewmodel.TramList = repo.GetAllTrams();
                    return View(viewmodel);
                }
            }
        }

        public class TramViewModel
        {
            public Sector sector { get; set; }

            public List<Tram> TramList { get; set; }

        }

        public ActionResult GetSectorForTram()
        {
            if (Session["curEmployeeID"] == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            else
            {
                
                return RedirectToAction("Index", "DriveIn", new {id = 1});
            }
        }
    }
}