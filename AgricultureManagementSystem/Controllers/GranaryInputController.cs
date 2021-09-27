using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgricultureManagementSystem.Controllers
{
    public class GranaryInputController : Controller
    {
        // GET: GranaryInput
        [HttpGet]
        public ActionResult QueryGranaryInputData()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddGranaryInputData()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
    }
}