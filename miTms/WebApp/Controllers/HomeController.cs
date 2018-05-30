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
        
        public async Task<ActionResult> Index()
        {
            ViewBag.Total = await this._vehicleService.Queryable().DeferredCount().ExecuteAsync();
            ViewBag.Count1 = await this._vehicleService.Queryable().Where(x => x.Status == "空车").DeferredCount().ExecuteAsync() ;
            ViewBag.Count2 = await this._vehicleService.Queryable().Where(x => x.Status == "接单").DeferredCount().ExecuteAsync();
            ViewBag.Count3 = await this._vehicleService.Queryable().Where(x => x.Status == "在途" || x.Status== "提货" || x.Status=="发车").DeferredCount().ExecuteAsync();
            ViewBag.Count4 = await this._vehicleService.Queryable().Where(x => x.Status == "异常").DeferredCount().ExecuteAsync();
            ViewBag.Percent1 = Convert.ToInt32((Convert.ToDecimal(ViewBag.Count1) / Convert.ToDecimal(ViewBag.Total)) * 100);
            ViewBag.Percent2 = Convert.ToInt32((Convert.ToDecimal(ViewBag.Count2) / Convert.ToDecimal(ViewBag.Total)) * 100);
            ViewBag.Percent3 = Convert.ToInt32((Convert.ToDecimal(ViewBag.Count3) / Convert.ToDecimal(ViewBag.Total)) * 100);
            ViewBag.Percent4 = Convert.ToInt32((Convert.ToDecimal(ViewBag.Count4) / Convert.ToDecimal(ViewBag.Total)) * 100);

            ViewBag.UPercent1 = 100 - ViewBag.Percent1;

            var sql = @"select distinct Status, 
 stuff((select distinct ',' + t.PlateNumber from dbo.vehicle t where t.Status = t1.Status  for xml path('')) , 1 , 1 , '')  PlateNumber from dbo.vehicle t1
 order by status  ";

            ViewBag.Pools = SqlHelper2.DatabaseFactory.CreateDatabase().ExecuteDataReader<PoolsViewModel>(sql,null, (r) => {
                return new PoolsViewModel {Status=r[0].ToString(),PlateNumbers=r[1].ToString().Split(',') };
             });

            var sql2 = @"select Status, COUNT(*) / CAST( SUM(count(*)) over () as float)
  from dbo.orders
 group by Status";
            var CompletePercent = 0.0;
            SqlHelper2.DatabaseFactory.CreateDatabase().ExecuteDataReader(sql2, null, (r) => {
                if (r[0].ToString() == "卸货" || r[0].ToString() == "入仓" ||
               r[0].ToString() == "完成") {
                    CompletePercent += Convert.ToDouble(r[1]);
                }
            });
            ViewBag.CompletePercent = CompletePercent * 100;

            var customrep = this._unitOfWork.RepositoryAsync<Shipper>();
            ViewBag.Customer = new SelectList(customrep.Queryable().OrderBy(n => n.Name).ToList(), "Id", "Name");

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