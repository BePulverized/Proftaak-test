﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proftaak_test.Controllers
{
    public class TramController : Controller
    {
        // GET: Tram
        public ActionResult Index()
        {
            if (Session["curEmployeeID"] == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            else
            {
                return View();
            }
        }
    }
}