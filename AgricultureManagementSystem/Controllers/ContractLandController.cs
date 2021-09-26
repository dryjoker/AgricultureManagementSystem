using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgricultureManagementSystem.Controllers
{
    public class ContractLandController : Controller
    {
        // GET: ContractLand
        public ActionResult QueryContratLandData()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

    }
}