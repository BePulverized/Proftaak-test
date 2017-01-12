using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proftaak_test.Repository;

namespace Proftaak_test.Controllers
{
    public class MapsController : Controller
    {
        private SectorRepo scRepo = new SectorRepo(new SectorDBContext());
        // GET: Maps
        public ActionResult Index()
        {
            if (Session["curEmployeeID"] == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            else
            {
                List<Sector> sectoren = scRepo.GetAllSectors();
                TramController.SectorViewModel viewmodel = new TramController.SectorViewModel();
                viewmodel.SectorList = sectoren;
                return View(viewmodel);
            }
        }
    }
}