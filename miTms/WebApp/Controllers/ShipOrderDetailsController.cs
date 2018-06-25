/// <summary>
/// Provides functionality to the /ShipOrderDetail/ route.
/// <date> 6/25/2018 4:01:08 PM </date>
/// Create By SmartCode MVC5 Scaffolder for Visual Studio
/// TODO: RegisterType UnityConfig.cs
/// container.RegisterType<IRepositoryAsync<ShipOrderDetail>, Repository<ShipOrderDetail>>();
/// container.RegisterType<IShipOrderDetailService, ShipOrderDetailService>();
/// 
/// Copyright (c) 2012-2018 neo.zhu
/// Dual licensed under the MIT (http://www.opensource.org/licenses/mit-license.php)
/// and GPL (http://www.opensource.org/licenses/gpl-license.php) licenses.
/// </summary>
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Infrastructure;
using Z.EntityFramework.Plus;
using TrackableEntities;
using WebApp.Models;
using WebApp.Services;
using WebApp.Repositories;
namespace WebApp.Controllers
{
    //[Authorize]
	public class ShipOrderDetailsController : Controller
	{
		private readonly IShipOrderDetailService  shipOrderDetailService;
		private readonly IUnitOfWorkAsync unitOfWork;
		public ShipOrderDetailsController (IShipOrderDetailService  shipOrderDetailService, IUnitOfWorkAsync unitOfWork)
		{
			this.shipOrderDetailService  = shipOrderDetailService;
			this.unitOfWork = unitOfWork;
		}
        		// GET: ShipOrderDetails/Index
        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public ActionResult Index()
		{
			 return View();
		}
		// Get :ShipOrderDetails/PageList
		// For Index View Boostrap-Table load  data 
		[HttpGet]
				 public async Task<JsonResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
				{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
			//int pagenum = offset / limit +1;
											var shiporderdetails  = await this.shipOrderDetailService
						               .Query(new ShipOrderDetailQuery().Withfilter(filters)).Include(s => s.Order).Include(s => s.ShipOrder)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
										var datarows = shiporderdetails .Select(  n => new { 

    OrderOrderNo = (n.Order==null?"": n.Order.OrderNo) ,
    ShipOrderShipOrderNo = (n.ShipOrder==null?"": n.ShipOrder.ShipOrderNo) ,
    Id = n.Id,
    OrderNo = n.OrderNo,
    OrderId = n.OrderId,
    Location1 = n.Location1,
    LoadTransportStation = n.LoadTransportStation,
    Location2 = n.Location2,
    ReceiptTransportStation = n.ReceiptTransportStation,
    Status = n.Status,
    Packages = n.Packages,
    Weight = n.Weight,
    Volume = n.Volume,
    Pallets = n.Pallets,
    Cartons = n.Cartons,
    BreakCartons = n.BreakCartons,
    ShipOrderId = n.ShipOrderId,
    ShipOrderNo = n.ShipOrderNo,
    CreatedDate = n.CreatedDate,
    CreatedBy = n.CreatedBy,
    LastModifiedDate = n.LastModifiedDate,
    LastModifiedBy = n.LastModifiedBy
}).ToList();
			var pagelist = new { total = totalCount, rows = datarows };
			return Json(pagelist, JsonRequestBehavior.AllowGet);
		}
                 [HttpGet]
        public async Task<ActionResult> GetDataByOrderId (int  orderid ,int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {    
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
            			    var shiporderdetails  = await this.shipOrderDetailService
						               .Query(new ShipOrderDetailQuery().ByOrderIdWithfilter(orderid,filters)).Include(s => s.Order).Include(s => s.ShipOrder)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = shiporderdetails .Select(  n => new { 

    OrderOrderNo = (n.Order==null?"": n.Order.OrderNo) ,
    ShipOrderShipOrderNo = (n.ShipOrder==null?"": n.ShipOrder.ShipOrderNo) ,
    Id = n.Id,
    OrderNo = n.OrderNo,
    OrderId = n.OrderId,
    Location1 = n.Location1,
    LoadTransportStation = n.LoadTransportStation,
    Location2 = n.Location2,
    ReceiptTransportStation = n.ReceiptTransportStation,
    Status = n.Status,
    Packages = n.Packages,
    Weight = n.Weight,
    Volume = n.Volume,
    Pallets = n.Pallets,
    Cartons = n.Cartons,
    BreakCartons = n.BreakCartons,
    ShipOrderId = n.ShipOrderId,
    ShipOrderNo = n.ShipOrderNo,
    CreatedDate = n.CreatedDate,
    CreatedBy = n.CreatedBy,
    LastModifiedDate = n.LastModifiedDate,
    LastModifiedBy = n.LastModifiedBy
}).ToList();
			var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
                [HttpGet]
        public async Task<ActionResult> GetDataByShipOrderId (int  shiporderid ,int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {    
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
            			    var shiporderdetails  = await this.shipOrderDetailService
						               .Query(new ShipOrderDetailQuery().ByShipOrderIdWithfilter(shiporderid,filters)).Include(s => s.Order).Include(s => s.ShipOrder)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = shiporderdetails .Select(  n => new { 

    OrderOrderNo = (n.Order==null?"": n.Order.OrderNo) ,
    ShipOrderShipOrderNo = (n.ShipOrder==null?"": n.ShipOrder.ShipOrderNo) ,
    Id = n.Id,
    OrderNo = n.OrderNo,
    OrderId = n.OrderId,
    Location1 = n.Location1,
    LoadTransportStation = n.LoadTransportStation,
    Location2 = n.Location2,
    ReceiptTransportStation = n.ReceiptTransportStation,
    Status = n.Status,
    Packages = n.Packages,
    Weight = n.Weight,
    Volume = n.Volume,
    Pallets = n.Pallets,
    Cartons = n.Cartons,
    BreakCartons = n.BreakCartons,
    ShipOrderId = n.ShipOrderId,
    ShipOrderNo = n.ShipOrderNo,
    CreatedDate = n.CreatedDate,
    CreatedBy = n.CreatedBy,
    LastModifiedDate = n.LastModifiedDate,
    LastModifiedBy = n.LastModifiedBy
}).ToList();
			var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
        		[HttpPost]
				public async Task<JsonResult> SaveData(ShipOrderDetailChangeViewModel shiporderdetails)
		{
			if (shiporderdetails.updated != null)
			{
				foreach (var item in shiporderdetails.updated)
				{
					this.shipOrderDetailService.Update(item);
				}
			}
			if (shiporderdetails.deleted != null)
			{
				foreach (var item in shiporderdetails.deleted)
				{
					this.shipOrderDetailService.Delete(item);
				}
			}
			if (shiporderdetails.inserted != null)
			{
				foreach (var item in shiporderdetails.inserted)
				{
					this.shipOrderDetailService.Insert(item);
				}
			}
			await this.unitOfWork.SaveChangesAsync();
			return Json(new {success=true}, JsonRequestBehavior.AllowGet);
		}
						        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public async Task<JsonResult> GetOrders(string q="")
		{
			var orderRepository = this.unitOfWork.RepositoryAsync<Order>();
			var data = await orderRepository.Queryable().Where(n=>n.OrderNo.Contains(q)).OrderBy(n=>n.OrderNo).ToListAsync();
			var rows = data.Select(n => new { Id = n.Id, OrderNo = n.OrderNo });
			return Json(rows, JsonRequestBehavior.AllowGet);
		}
						        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public async Task<JsonResult> GetShipOrders(string q="")
		{
			var shiporderRepository = this.unitOfWork.RepositoryAsync<ShipOrder>();
			var data = await shiporderRepository.Queryable().Where(n=>n.ShipOrderNo.Contains(q)).OrderBy(n=>n.ShipOrderNo).ToListAsync();
			var rows = data.Select(n => new { Id = n.Id, ShipOrderNo = n.ShipOrderNo });
			return Json(rows, JsonRequestBehavior.AllowGet);
		}
								// GET: ShipOrderDetails/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var  shipOrderDetail = await this.shipOrderDetailService.FindAsync(id);
			if (shipOrderDetail == null)
			{
				return HttpNotFound();
			}
			return View(shipOrderDetail);
		}
		// GET: ShipOrderDetails/Create
        		public ActionResult Create()
				{
			var shipOrderDetail = new ShipOrderDetail();
			//set default value
			var orderRepository = this.unitOfWork.RepositoryAsync<Order>();
		   			ViewBag.OrderId = new SelectList(orderRepository.Queryable().OrderBy(n=>n.OrderNo), "Id", "OrderNo");
		   			var shiporderRepository = this.unitOfWork.RepositoryAsync<ShipOrder>();
		   			ViewBag.ShipOrderId = new SelectList(shiporderRepository.Queryable().OrderBy(n=>n.ShipOrderNo), "Id", "ShipOrderNo");
		   			return View(shipOrderDetail);
		}
		// POST: ShipOrderDetails/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "Order,ShipOrder,Id,OrderNo,OrderId,Location1,LoadTransportStation,Location2,ReceiptTransportStation,Status,Packages,Weight,Volume,Pallets,Cartons,BreakCartons,ShipOrderId,ShipOrderNo,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] ShipOrderDetail shipOrderDetail)
		{
			if (ModelState.IsValid)
			{
			 				shipOrderDetailService.Insert(shipOrderDetail);
		   				await this.unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has append a ShipOrderDetail record");
				return RedirectToAction("Index");
			}
			else {
			 var modelStateErrors =String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			 if (Request.IsAjaxRequest())
			 {
			   return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			 }
			 DisplayErrorMessage(modelStateErrors);
			}
						var orderRepository = this.unitOfWork.RepositoryAsync<Order>();
						ViewBag.OrderId = new SelectList(await orderRepository.Queryable().OrderBy(n=>n.OrderNo).ToListAsync(), "Id", "OrderNo", shipOrderDetail.OrderId);
									var shiporderRepository = this.unitOfWork.RepositoryAsync<ShipOrder>();
						ViewBag.ShipOrderId = new SelectList(await shiporderRepository.Queryable().OrderBy(n=>n.ShipOrderNo).ToListAsync(), "Id", "ShipOrderNo", shipOrderDetail.ShipOrderId);
									return View(shipOrderDetail);
		}
        // GET: ShipOrderDetails/PopupEdit/5
        //[OutputCache(Duration = 360, VaryByParam = "id")]
		public async Task<JsonResult> PopupEdit(int? id)
		{
			
			var shipOrderDetail = await this.shipOrderDetailService.FindAsync(id);
			return Json(shipOrderDetail,JsonRequestBehavior.AllowGet);
		}

		// GET: ShipOrderDetails/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var shipOrderDetail = await this.shipOrderDetailService.FindAsync(id);
			if (shipOrderDetail == null)
			{
				return HttpNotFound();
			}
			var orderRepository = this.unitOfWork.RepositoryAsync<Order>();
			ViewBag.OrderId = new SelectList(orderRepository.Queryable().OrderBy(n=>n.OrderNo), "Id", "OrderNo", shipOrderDetail.OrderId);
			var shiporderRepository = this.unitOfWork.RepositoryAsync<ShipOrder>();
			ViewBag.ShipOrderId = new SelectList(shiporderRepository.Queryable().OrderBy(n=>n.ShipOrderNo), "Id", "ShipOrderNo", shipOrderDetail.ShipOrderId);
			return View(shipOrderDetail);
		}
		// POST: ShipOrderDetails/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "Order,ShipOrder,Id,OrderNo,OrderId,Location1,LoadTransportStation,Location2,ReceiptTransportStation,Status,Packages,Weight,Volume,Pallets,Cartons,BreakCartons,ShipOrderId,ShipOrderNo,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] ShipOrderDetail shipOrderDetail)
		{
			if (ModelState.IsValid)
			{
				shipOrderDetail.TrackingState = TrackingState.Modified;
								shipOrderDetailService.Update(shipOrderDetail);
								await   this.unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has update a ShipOrderDetail record");
				return RedirectToAction("Index");
			}
			else {
			var modelStateErrors =String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			if (Request.IsAjaxRequest())
			{
				return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			}
			DisplayErrorMessage(modelStateErrors);
			}
						var orderRepository = this.unitOfWork.RepositoryAsync<Order>();
												var shiporderRepository = this.unitOfWork.RepositoryAsync<ShipOrder>();
												return View(shipOrderDetail);
		}
		// GET: ShipOrderDetails/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var shipOrderDetail = await this.shipOrderDetailService.FindAsync(id);
			if (shipOrderDetail == null)
			{
				return HttpNotFound();
			}
			return View(shipOrderDetail);
		}
		// POST: ShipOrderDetails/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var shipOrderDetail = await  this.shipOrderDetailService.FindAsync(id);
			 this.shipOrderDetailService.Delete(shipOrderDetail);
			await this.unitOfWork.SaveChangesAsync();
		   if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
			DisplaySuccessMessage("Has delete a ShipOrderDetail record");
			return RedirectToAction("Index");
		}
       
 
		//导出Excel
		[HttpPost]
		public ActionResult ExportExcel( string filterRules = "",string sort = "Id", string order = "asc")
		{
			var fileName = "shiporderdetails_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream=  this.shipOrderDetailService.ExportExcel(filterRules,sort, order );
			return File(stream, "application/vnd.ms-excel", fileName);
		}
		private void DisplaySuccessMessage(string msgText)
		{
			TempData["SuccessMessage"] = msgText;
		}
		private void DisplayErrorMessage(string msgText)
		{
			TempData["ErrorMessage"] = msgText;
		}
		 
	}
}
