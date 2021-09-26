using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgricultureManagementSystem.Controllers
{
    public class FarmerDataController : Controller
    {
        // GET: CreateData
        public ActionResult CreateData()
        {
            return View();
        }



        // GET: QueryEditData
        public ActionResult QueryEditData()
        {
            return View();
        }


        public ActionResult Edit()
        {
            return View();
        }


    }
}