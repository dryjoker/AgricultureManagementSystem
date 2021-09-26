using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgricultureManagementSystem.Controllers
{
    public class RicePriceController : Controller
    {
        // GET: RicePrice
        public ActionResult QueryRicePriceData()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

    }
}