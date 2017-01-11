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
        private TramRepo Trepo = new TramRepo(new TramDBContext());
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
                viewmodel.tram = new Tram(0, 0000, 1, false, false, false, new Tramtype(0, "Geen omschrijving"));
                return View(viewmodel);
            }
        }

        public ActionResult GetTram(int id)
        {
            SectorViewModel viewmodel = new SectorViewModel();
            viewmodel.SectorList = scRepo.GetAllSectors();
            viewmodel.SpoorList = sRepo.GetAllSporen();
            viewmodel.tram = Trepo.GetTrambyID(id);
            return View("Index", viewmodel);
        }
        
        public class SectorViewModel
        {
            public List<Sector> SectorList { get; set; }

            public List<Spoor> SpoorList { get; set; }

            public Tram tram { get; set; }

        }


    }
}