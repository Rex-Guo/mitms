using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PublicPara.CodeText.Data;
using Repository.Pattern.UnitOfWork;
using WebApp.Models;
using WebApp.Services;
using Z.EntityFramework.Plus;
namespace WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IOrderService _orderService;
        private readonly IUnitOfWorkAsync _unitOfWork;
        public HomeController(IVehicleService _vehicleService,IUnitOfWorkAsync _unitOfWork, IOrderService _orderService)
        {
            this._unitOfWork = _unitOfWork;
            this._vehicleService = _vehicleService;
            this._orderService = _orderService;
        }
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var codep = this._unitOfWork.RepositoryAsync<Models.CodeItem>();
            var color = await codep.Queryable().Where(x => x.CodeType == "VehicleColor").Select(n => new SelectListItem() { Value = n.Code, Text = n.Text }).ToArrayAsync();
            var vtype = await codep.Queryable().Where(x => x.CodeType == "VehicleType").Select(n => new SelectListItem() { Value = n.Code, Text = n.Text }).ToArrayAsync();
            var ctype = await codep.Queryable().Where(x => x.CodeType == "CarType").Select(n => new SelectListItem() { Value = n.Code, Text = n.Text }).ToArrayAsync();
            var regionp = this._unitOfWork.RepositoryAsync<Region>();
            var region = await regionp.Queryable().Select(n => new SelectListItem() { Value = n.Code, Text = n.Name }).ToArrayAsync();
            ViewBag.CountrySubdivisionCode = region;
            ViewBag.VehicleClassificationCode = ctype;
            ViewBag.LicenseplateTypeCode = vtype;
            ViewBag.VehicleLicensePlateColor = color;
            return View();
        }
        public async Task<ActionResult> GetEvents() {
            var query =await this._orderService.Queryable().Where(x => x.Status != "完成" && x.Status != "关闭").Select(x=>new { OrderNo=x.OrderNo,OrderDate =x.OrderDate,Status=x.Status, DeliveryDate = x.DeliveryDate, TimePeriod=x.TimePeriod, PlateNumber = x.PlateNumber }).ToListAsync();
            var list = new List<EventViewModel>();
            foreach (var item in query) {
                var ev = new EventViewModel();
                ev.title = item.PlateNumber + " " + item.OrderNo + " " + item.Status;
                ev.start = item.OrderDate;
                ev.allDay = false;
                if (item.Status == "在途")
                {
                    var array = new string[] { "event", "bg-color-green" };
                    ev.className = array;
                    ev.icon = "fa-paper-plane";
                }
                else if (item.Status == "接单")
                {
                    var array = new string[] { "event", "bg-color-green" };
                    ev.className = array;
                    ev.icon = "fa-check";
                }
                else if (item.Status == "卸货" || item.Status == "入库")
                {
                    var array = new string[] { "event", "bg-color-darken" };
                    ev.className = array;
                    ev.icon = "fa-chevron-down";
                }
                else if (item.Status == "异常"  )
                {
                    var array = new string[] { "event", "bg-color-redLight" };
                    ev.className = array;
                    ev.icon = "fa-lock";
                    ev.description = "该订单有异常，请及时关注!";
                }
                else
                {
                    var array = new string[] { "event", "bg-color-blue" };
                    ev.className = array;
                }
                if (item.DeliveryDate != null)
                {
                    ev.end = item.DeliveryDate;
                    if ((item.OrderDate.AddHours(item.TimePeriod) - item.DeliveryDate.Value).Minutes < 0)
                    {
                        var t = Math.Abs((item.OrderDate.AddHours(item.TimePeriod) - item.DeliveryDate.Value).Minutes);
                        var array = new string[] { "event", "bg-color-yellow" };
                        ev.className = array;
                        ev.icon = "fa-clock-o";
                        ev.description = "超过定制的时间[" + t.ToString() + "]";
                    }
                }
                else {
                    if ((item.OrderDate.AddHours(item.TimePeriod) - DateTime.Now).Minutes < 0)
                    {
                        var t = Math.Abs((item.OrderDate.AddHours(item.TimePeriod) - DateTime.Now).Minutes);
                        var array = new string[] { "event", "bg-color-yellow" };
                        ev.className = array;
                        ev.icon = "fa-clock-o";
                        ev.description = "超过定制的时间[" + t.ToString() + "]";
                    }
                }
                
                list.Add(ev);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GetTime()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult BlankPage() {
            return View();
        }
        public ActionResult AgileBoard() {
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Chat()
        {
            return View();
        }
       
    }
}