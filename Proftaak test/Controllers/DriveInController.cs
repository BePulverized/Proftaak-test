using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proftaak_test.Controllers
{
    public class DriveInController : Controller
    {
        // GET: DriveIn
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult GetSectorForTram()
        {
            throw new NotImplementedException();
        }
    }
}