using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class FinancesController : Controller
    {
        // GET: Finances
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Billing()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }
    }
}