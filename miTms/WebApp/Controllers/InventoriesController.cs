using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class InventoriesController : Controller
    {
        // GET: Inventories
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Input() {
            return View();
        }
        public ActionResult Output()
        {
            return View();
        }
    }
}