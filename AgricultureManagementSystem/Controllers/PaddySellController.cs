using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgricultureManagementSystem.Controllers
{
    public class PaddySellController : Controller
    {
        // GET: PaddySell
        public ActionResult QueryPaddySellData()
        {
            return View();
        }
    }
}