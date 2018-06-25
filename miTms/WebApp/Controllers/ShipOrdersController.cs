/// <summary>
/// Provides functionality to the /ShipOrder/ route.
/// <date> 6/25/2018 4:12:00 PM </date>
/// Create By SmartCode MVC5 Scaffolder for Visual Studio
/// TODO: RegisterType UnityConfig.cs
/// container.RegisterType<IRepositoryAsync<ShipOrder>, Repository<ShipOrder>>();
/// container.RegisterType<IShipOrderService, ShipOrderService>();
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
	public class ShipOrdersController : Controller
	{
		private readonly IShipOrderService  shipOrderService;
		private readonly IUnitOfWorkAsync unitOfWork;
		public ShipOrdersController (IShipOrderService  shipOrderService, IUnitOfWorkAsync unitOfWork)
		{
			this.shipOrderService  = shipOrderService;
			this.unitOfWork = unitOfWork;
		}
        		// GET: ShipOrders/Index
        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public ActionResult Index()
		{
			 return View();
		}
		// Get :ShipOrders/PageList
		// For Index View Boostrap-Table load  data 
		[HttpGet]
				 public async Task<JsonResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
				{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
			//int pagenum = offset / limit +1;
											var shiporders  = await this.shipOrderService
						               .Query(new ShipOrderQuery().Withfilter(filters)).Include(s => s.Carrier).Include(s => s.Company).Include(s => s.Vehicle)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
										var datarows = shiporders .Select(  n => new { 

    CarrierName = (n.Carrier==null?"": n.Carrier.Name) ,
    CompanyName = (n.Company==null?"": n.Company.Name) ,
    VehiclePlateNumber = (n.Vehicle==null?"": n.Vehicle.PlateNumber) ,
    Id = n.Id,
    ShipOrderNo = n.ShipOrderNo,
    ExternalNo = n.ExternalNo,
    OrderDate = n.OrderDate,
    BusinessType = n.BusinessType,
    Status = n.Status,
    CarrierId = n.CarrierId,
    VehicleId = n.VehicleId,
    CarType = n.CarType,
    Driver = n.Driver,
    DriverPhone = n.DriverPhone,
    ContractNumber = n.ContractNumber,
    TotalMonetaryAmount = n.TotalMonetaryAmount,
    Remark = n.Remark,
    Location1 = n.Location1,
    Location2 = n.Location2,
    Requirements = n.Requirements,
    TimePeriod = n.TimePeriod,
    PlanDepartDate = n.PlanDepartDate,
    PlanDeliveryDate = n.PlanDeliveryDate,
    DepartDate = n.DepartDate,
    DeliveryDate = n.DeliveryDate,
    ClosedDate = n.ClosedDate,
    ItemCount = n.ItemCount,
    Packages = n.Packages,
    Weight = n.Weight,
    Volume = n.Volume,
    Pallets = n.Pallets,
    Cartons = n.Cartons,
    BreakCartons = n.BreakCartons,
    InputUser = n.InputUser,
    CompanyId = n.CompanyId,
    CreatedDate = n.CreatedDate,
    CreatedBy = n.CreatedBy,
    LastModifiedDate = n.LastModifiedDate,
    LastModifiedBy = n.LastModifiedBy
}).ToList();
			var pagelist = new { total = totalCount, rows = datarows };
			return Json(pagelist, JsonRequestBehavior.AllowGet);
		}
                 [HttpGet]
        public async Task<ActionResult> GetDataByCarrierId (int  carrierid ,int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {    
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
            			    var shiporders  = await this.shipOrderService
						               .Query(new ShipOrderQuery().ByCarrierIdWithfilter(carrierid,filters)).Include(s => s.Carrier).Include(s => s.Company).Include(s => s.Vehicle)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = shiporders .Select(  n => new { 

    CarrierName = (n.Carrier==null?"": n.Carrier.Name) ,
    CompanyName = (n.Company==null?"": n.Company.Name) ,
    VehiclePlateNumber = (n.Vehicle==null?"": n.Vehicle.PlateNumber) ,
    Id = n.Id,
    ShipOrderNo = n.ShipOrderNo,
    ExternalNo = n.ExternalNo,
    OrderDate = n.OrderDate,
    BusinessType = n.BusinessType,
    Status = n.Status,
    CarrierId = n.CarrierId,
    VehicleId = n.VehicleId,
    CarType = n.CarType,
    Driver = n.Driver,
    DriverPhone = n.DriverPhone,
    ContractNumber = n.ContractNumber,
    TotalMonetaryAmount = n.TotalMonetaryAmount,
    Remark = n.Remark,
    Location1 = n.Location1,
    Location2 = n.Location2,
    Requirements = n.Requirements,
    TimePeriod = n.TimePeriod,
    PlanDepartDate = n.PlanDepartDate,
    PlanDeliveryDate = n.PlanDeliveryDate,
    DepartDate = n.DepartDate,
    DeliveryDate = n.DeliveryDate,
    ClosedDate = n.ClosedDate,
    ItemCount = n.ItemCount,
    Packages = n.Packages,
    Weight = n.Weight,
    Volume = n.Volume,
    Pallets = n.Pallets,
    Cartons = n.Cartons,
    BreakCartons = n.BreakCartons,
    InputUser = n.InputUser,
    CompanyId = n.CompanyId,
    CreatedDate = n.CreatedDate,
    CreatedBy = n.CreatedBy,
    LastModifiedDate = n.LastModifiedDate,
    LastModifiedBy = n.LastModifiedBy
}).ToList();
			var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
                [HttpGet]
        public async Task<ActionResult> GetDataByVehicleId (int  vehicleid ,int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {    
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
            			    var shiporders  = await this.shipOrderService
						               .Query(new ShipOrderQuery().ByVehicleIdWithfilter(vehicleid,filters)).Include(s => s.Carrier).Include(s => s.Company).Include(s => s.Vehicle)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = shiporders .Select(  n => new { 

    CarrierName = (n.Carrier==null?"": n.Carrier.Name) ,
    CompanyName = (n.Company==null?"": n.Company.Name) ,
    VehiclePlateNumber = (n.Vehicle==null?"": n.Vehicle.PlateNumber) ,
    Id = n.Id,
    ShipOrderNo = n.ShipOrderNo,
    ExternalNo = n.ExternalNo,
    OrderDate = n.OrderDate,
    BusinessType = n.BusinessType,
    Status = n.Status,
    CarrierId = n.CarrierId,
    VehicleId = n.VehicleId,
    CarType = n.CarType,
    Driver = n.Driver,
    DriverPhone = n.DriverPhone,
    ContractNumber = n.ContractNumber,
    TotalMonetaryAmount = n.TotalMonetaryAmount,
    Remark = n.Remark,
    Location1 = n.Location1,
    Location2 = n.Location2,
    Requirements = n.Requirements,
    TimePeriod = n.TimePeriod,
    PlanDepartDate = n.PlanDepartDate,
    PlanDeliveryDate = n.PlanDeliveryDate,
    DepartDate = n.DepartDate,
    DeliveryDate = n.DeliveryDate,
    ClosedDate = n.ClosedDate,
    ItemCount = n.ItemCount,
    Packages = n.Packages,
    Weight = n.Weight,
    Volume = n.Volume,
    Pallets = n.Pallets,
    Cartons = n.Cartons,
    BreakCartons = n.BreakCartons,
    InputUser = n.InputUser,
    CompanyId = n.CompanyId,
    CreatedDate = n.CreatedDate,
    CreatedBy = n.CreatedBy,
    LastModifiedDate = n.LastModifiedDate,
    LastModifiedBy = n.LastModifiedBy
}).ToList();
			var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
                [HttpGet]
        public async Task<ActionResult> GetDataByCompanyId (int  companyid ,int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {    
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
            			    var shiporders  = await this.shipOrderService
						               .Query(new ShipOrderQuery().ByCompanyIdWithfilter(companyid,filters)).Include(s => s.Carrier).Include(s => s.Company).Include(s => s.Vehicle)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = shiporders .Select(  n => new { 

    CarrierName = (n.Carrier==null?"": n.Carrier.Name) ,
    CompanyName = (n.Company==null?"": n.Company.Name) ,
    VehiclePlateNumber = (n.Vehicle==null?"": n.Vehicle.PlateNumber) ,
    Id = n.Id,
    ShipOrderNo = n.ShipOrderNo,
    ExternalNo = n.ExternalNo,
    OrderDate = n.OrderDate,
    BusinessType = n.BusinessType,
    Status = n.Status,
    CarrierId = n.CarrierId,
    VehicleId = n.VehicleId,
    CarType = n.CarType,
    Driver = n.Driver,
    DriverPhone = n.DriverPhone,
    ContractNumber = n.ContractNumber,
    TotalMonetaryAmount = n.TotalMonetaryAmount,
    Remark = n.Remark,
    Location1 = n.Location1,
    Location2 = n.Location2,
    Requirements = n.Requirements,
    TimePeriod = n.TimePeriod,
    PlanDepartDate = n.PlanDepartDate,
    PlanDeliveryDate = n.PlanDeliveryDate,
    DepartDate = n.DepartDate,
    DeliveryDate = n.DeliveryDate,
    ClosedDate = n.ClosedDate,
    ItemCount = n.ItemCount,
    Packages = n.Packages,
    Weight = n.Weight,
    Volume = n.Volume,
    Pallets = n.Pallets,
    Cartons = n.Cartons,
    BreakCartons = n.BreakCartons,
    InputUser = n.InputUser,
    CompanyId = n.CompanyId,
    CreatedDate = n.CreatedDate,
    CreatedBy = n.CreatedBy,
    LastModifiedDate = n.LastModifiedDate,
    LastModifiedBy = n.LastModifiedBy
}).ToList();
			var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
        		[HttpPost]
				public async Task<JsonResult> SaveData(ShipOrderChangeViewModel shiporders)
		{
			if (shiporders.updated != null)
			{
				foreach (var item in shiporders.updated)
				{
					this.shipOrderService.Update(item);
				}
			}
			if (shiporders.deleted != null)
			{
				foreach (var item in shiporders.deleted)
				{
					this.shipOrderService.Delete(item);
				}
			}
			if (shiporders.inserted != null)
			{
				foreach (var item in shiporders.inserted)
				{
					this.shipOrderService.Insert(item);
				}
			}
			await this.unitOfWork.SaveChangesAsync();
			return Json(new {success=true}, JsonRequestBehavior.AllowGet);
		}
						        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public async Task<JsonResult> GetCarriers(string q="")
		{
			var carrierRepository = this.unitOfWork.RepositoryAsync<Carrier>();
			var data = await carrierRepository.Queryable().Where(n=>n.Name.Contains(q)).OrderBy(n=>n.Name).ToListAsync();
			var rows = data.Select(n => new { Id = n.Id, Name = n.Name });
			return Json(rows, JsonRequestBehavior.AllowGet);
		}
						        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public async Task<JsonResult> GetCompanies(string q="")
		{
			var companyRepository = this.unitOfWork.RepositoryAsync<Company>();
			var data = await companyRepository.Queryable().Where(n=>n.Name.Contains(q)).OrderBy(n=>n.Name).ToListAsync();
			var rows = data.Select(n => new { Id = n.Id, Name = n.Name });
			return Json(rows, JsonRequestBehavior.AllowGet);
		}
						        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public async Task<JsonResult> GetVehicles(string q="")
		{
			var vehicleRepository = this.unitOfWork.RepositoryAsync<Vehicle>();
			var data = await vehicleRepository.Queryable().Where(n=>n.PlateNumber.Contains(q)).OrderBy(n=>n.PlateNumber).ToListAsync();
			var rows = data.Select(n => new { Id = n.Id, PlateNumber = n.PlateNumber });
			return Json(rows, JsonRequestBehavior.AllowGet);
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
						// GET: ShipOrders/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var  shipOrder = await this.shipOrderService.FindAsync(id);
			if (shipOrder == null)
			{
				return HttpNotFound();
			}
			return View(shipOrder);
		}
		// GET: ShipOrders/Create
        		public ActionResult Create()
				{
			var shipOrder = new ShipOrder();
			//set default value
			var carrierRepository = this.unitOfWork.RepositoryAsync<Carrier>();
		   			ViewBag.CarrierId = new SelectList(carrierRepository.Queryable().OrderBy(n=>n.Name), "Id", "Name");
		   			var companyRepository = this.unitOfWork.RepositoryAsync<Company>();
		   			ViewBag.CompanyId = new SelectList(companyRepository.Queryable().OrderBy(n=>n.Name), "Id", "Name");
		   			var vehicleRepository = this.unitOfWork.RepositoryAsync<Vehicle>();
		   			ViewBag.VehicleId = new SelectList(vehicleRepository.Queryable().OrderBy(n=>n.PlateNumber), "Id", "PlateNumber");
		   			return View(shipOrder);
		}
		// POST: ShipOrders/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "Carrier,Company,ShipOrderDetails,Vehicle,Id,ShipOrderNo,ExternalNo,OrderDate,BusinessType,Status,CarrierId,VehicleId,CarType,Driver,DriverPhone,ContractNumber,TotalMonetaryAmount,Remark,Location1,Location2,Requirements,TimePeriod,PlanDepartDate,PlanDeliveryDate,DepartDate,DeliveryDate,ClosedDate,ItemCount,Packages,Weight,Volume,Pallets,Cartons,BreakCartons,InputUser,CompanyId,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] ShipOrder shipOrder)
		{
			if (ModelState.IsValid)
			{
			 				shipOrder.TrackingState = TrackingState.Added;   
								foreach (var item in shipOrder.ShipOrderDetails)
				{
					item.ShipOrderId = shipOrder.Id ;
					item.TrackingState = TrackingState.Added;
				}
								shipOrderService.ApplyChanges(shipOrder);
							await this.unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has append a ShipOrder record");
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
						var carrierRepository = this.unitOfWork.RepositoryAsync<Carrier>();
						ViewBag.CarrierId = new SelectList(await carrierRepository.Queryable().OrderBy(n=>n.Name).ToListAsync(), "Id", "Name", shipOrder.CarrierId);
									var companyRepository = this.unitOfWork.RepositoryAsync<Company>();
						ViewBag.CompanyId = new SelectList(await companyRepository.Queryable().OrderBy(n=>n.Name).ToListAsync(), "Id", "Name", shipOrder.CompanyId);
									var vehicleRepository = this.unitOfWork.RepositoryAsync<Vehicle>();
						ViewBag.VehicleId = new SelectList(await vehicleRepository.Queryable().OrderBy(n=>n.PlateNumber).ToListAsync(), "Id", "PlateNumber", shipOrder.VehicleId);
									return View(shipOrder);
		}
        // GET: ShipOrders/PopupEdit/5
        //[OutputCache(Duration = 360, VaryByParam = "id")]
		public async Task<JsonResult> PopupEdit(int? id)
		{
			
			var shipOrder = await this.shipOrderService.FindAsync(id);
			return Json(shipOrder,JsonRequestBehavior.AllowGet);
		}

		// GET: ShipOrders/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var shipOrder = await this.shipOrderService.FindAsync(id);
			if (shipOrder == null)
			{
				return HttpNotFound();
			}
			var carrierRepository = this.unitOfWork.RepositoryAsync<Carrier>();
			ViewBag.CarrierId = new SelectList(carrierRepository.Queryable().OrderBy(n=>n.Name), "Id", "Name", shipOrder.CarrierId);
			var companyRepository = this.unitOfWork.RepositoryAsync<Company>();
			ViewBag.CompanyId = new SelectList(companyRepository.Queryable().OrderBy(n=>n.Name), "Id", "Name", shipOrder.CompanyId);
			var vehicleRepository = this.unitOfWork.RepositoryAsync<Vehicle>();
			ViewBag.VehicleId = new SelectList(vehicleRepository.Queryable().OrderBy(n=>n.PlateNumber), "Id", "PlateNumber", shipOrder.VehicleId);
			return View(shipOrder);
		}
		// POST: ShipOrders/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "Carrier,Company,ShipOrderDetails,Vehicle,Id,ShipOrderNo,ExternalNo,OrderDate,BusinessType,Status,CarrierId,VehicleId,CarType,Driver,DriverPhone,ContractNumber,TotalMonetaryAmount,Remark,Location1,Location2,Requirements,TimePeriod,PlanDepartDate,PlanDeliveryDate,DepartDate,DeliveryDate,ClosedDate,ItemCount,Packages,Weight,Volume,Pallets,Cartons,BreakCartons,InputUser,CompanyId,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] ShipOrder shipOrder)
		{
			if (ModelState.IsValid)
			{
				shipOrder.TrackingState = TrackingState.Modified;
												foreach (var item in shipOrder.ShipOrderDetails)
				{
					item.ShipOrderId = shipOrder.Id ;
					//set ObjectState with conditions
					if(item.Id <= 0)
						item.TrackingState = TrackingState.Added;
					else
						item.TrackingState = TrackingState.Modified;
				}
				      
				shipOrderService.ApplyChanges(shipOrder);
								await   this.unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has update a ShipOrder record");
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
						var carrierRepository = this.unitOfWork.RepositoryAsync<Carrier>();
												var companyRepository = this.unitOfWork.RepositoryAsync<Company>();
												var vehicleRepository = this.unitOfWork.RepositoryAsync<Vehicle>();
												return View(shipOrder);
		}
		// GET: ShipOrders/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var shipOrder = await this.shipOrderService.FindAsync(id);
			if (shipOrder == null)
			{
				return HttpNotFound();
			}
			return View(shipOrder);
		}
		// POST: ShipOrders/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var shipOrder = await  this.shipOrderService.FindAsync(id);
			 this.shipOrderService.Delete(shipOrder);
			await this.unitOfWork.SaveChangesAsync();
		   if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
			DisplaySuccessMessage("Has delete a ShipOrder record");
			return RedirectToAction("Index");
		}
		// Get Detail Row By Id For Edit
		// Get : ShipOrders/EditShipOrderDetail/:id
		[HttpGet]
				public async Task<ActionResult> EditShipOrderDetail(int? id)
				{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var shiporderdetailRepository = this.unitOfWork.RepositoryAsync<ShipOrderDetail>();
						var shiporderdetail = await shiporderdetailRepository.FindAsync(id);
									var orderRepository = this.unitOfWork.RepositoryAsync<Order>();             
						var shiporderRepository = this.unitOfWork.RepositoryAsync<ShipOrder>();             
						if (shiporderdetail == null)
			{
											ViewBag.OrderId = new SelectList(await orderRepository.Queryable().OrderBy(n=>n.OrderNo).ToListAsync(), "Id", "OrderNo" );
															ViewBag.ShipOrderId = new SelectList(await shiporderRepository.Queryable().OrderBy(n=>n.ShipOrderNo).ToListAsync(), "Id", "ShipOrderNo" );
											//return HttpNotFound();
				return PartialView("_ShipOrderDetailEditForm", new ShipOrderDetail());
			}
			else
			{
											 ViewBag.OrderId = new SelectList(await orderRepository.Queryable().ToListAsync(), "Id", "OrderNo" , shiporderdetail.OrderId );  
															 ViewBag.ShipOrderId = new SelectList(await shiporderRepository.Queryable().ToListAsync(), "Id", "ShipOrderNo" , shiporderdetail.ShipOrderId );  
										}
			return PartialView("_ShipOrderDetailEditForm",  shiporderdetail);
		}
		// Get Create Row By Id For Edit
		// Get : ShipOrders/CreateShipOrderDetail
		[HttpGet]
				public async Task<ActionResult> CreateShipOrderDetail()
				{
		  			  var orderRepository = this.unitOfWork.RepositoryAsync<Order>();    
			  			  ViewBag.OrderId = new SelectList(await orderRepository.Queryable().OrderBy(n=>n.OrderNo).ToListAsync(), "Id", "OrderNo" );
			  		  			  var shiporderRepository = this.unitOfWork.RepositoryAsync<ShipOrder>();    
			  			  ViewBag.ShipOrderId = new SelectList(await shiporderRepository.Queryable().OrderBy(n=>n.ShipOrderNo).ToListAsync(), "Id", "ShipOrderNo" );
			  		  			return PartialView("_ShipOrderDetailEditForm");
		}
		// Post Delete Detail Row By Id
		// Get : ShipOrders/DeleteShipOrderDetail/:id
		[HttpPost,ActionName("DeleteShipOrderDetail")]
				public async Task<ActionResult> DeleteShipOrderDetailConfirmed(int  id)
				{
			var shiporderdetailRepository = this.unitOfWork.RepositoryAsync<ShipOrderDetail>();
			shiporderdetailRepository.Delete(id);
						await this.unitOfWork.SaveChangesAsync();
						if (Request.IsAjaxRequest())
			{
				return Json(new { success = true }, JsonRequestBehavior.AllowGet);
			}
			DisplaySuccessMessage("Has delete a Order record");
			return RedirectToAction("Index");
		}
       
		// Get : ShipOrders/GetShipOrderDetailsByShipOrderId/:id
		[HttpGet]
				public async Task<ActionResult> GetShipOrderDetailsByShipOrderId(int id)
				{
			var shiporderdetails = this.shipOrderService.GetShipOrderDetailsByShipOrderId(id);
			if (Request.IsAjaxRequest())
			{
								var data = await shiporderdetails.AsQueryable().ToListAsync();
								var rows = data.Select( n => new { 

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
});
				return Json(rows, JsonRequestBehavior.AllowGet);
			}  
			return View(shiporderdetails); 
		}
 
		//导出Excel
		[HttpPost]
		public ActionResult ExportExcel( string filterRules = "",string sort = "Id", string order = "asc")
		{
			var fileName = "shiporders_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream=  this.shipOrderService.ExportExcel(filterRules,sort, order );
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
