using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proftaak_test.Repository;

namespace Proftaak_test.Controllers
{
    public class TramController : Controller
    {
        private SectorRepo scRepo = new SectorRepo(new SectorDBContext());
        private SpoorRepo sRepo = new SpoorRepo(new SpoorDBContext());
        // GET: Tram
        public ActionResult Index(int? id, bool? block)
        {
            if (Session["curEmployeeID"] == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            else
            {
                if (id != null)
                {
                    if (block == false)
                    {
                        scRepo.BlockSector(id);
                    }
                    else
                    {
                        scRepo.UnBlockSector(id);
                    }
                }
                List<Sector> sectoren = scRepo.GetAllSectors();
                List<Spoor> sporen = sRepo.GetAllSporen();
                SectorViewModel viewmodel = new SectorViewModel();
                viewmodel.SectorList = sectoren;
                viewmodel.SpoorList = sporen;
                return View(viewmodel);
            }
        }
        
        public class SectorViewModel
        {
            public List<Sector> SectorList { get; set; }

            public List<Spoor> SpoorList { get; set; }

        }


    }
}