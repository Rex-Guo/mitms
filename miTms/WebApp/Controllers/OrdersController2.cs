/// <summary>
/// Provides functionality to the /Order/ route.
/// <date> 6/26/2018 8:58:05 AM </date>
/// Create By SmartCode MVC5 Scaffolder for Visual Studio
/// TODO: RegisterType UnityConfig.cs
/// container.RegisterType<IRepositoryAsync<Order>, Repository<Order>>();
/// container.RegisterType<IOrderService, OrderService>();
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
	public class OrdersController2 : Controller
	{
		private readonly IOrderService  orderService;
		private readonly IUnitOfWorkAsync unitOfWork;
		public OrdersController2 (IOrderService  orderService, IUnitOfWorkAsync unitOfWork)
		{
			this.orderService  = orderService;
			this.unitOfWork = unitOfWork;
		}
        		// GET: Orders/Index
        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public ActionResult Index()
		{
			 return View();
		}
		// Get :Orders/PageList
		// For Index View Boostrap-Table load  data 
		[HttpGet]
				 public async Task<JsonResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
				{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
			//int pagenum = offset / limit +1;
											var orders  = await this.orderService
						               .Query(new OrderQuery().Withfilter(filters)).Include(o => o.Company).Include(o => o.Shipper).Include(o => o.Vehicle)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
										var datarows = orders .Select(  n => new { 

    CompanyName = (n.Company==null?"": n.Company.Name) ,
    ShipperName = (n.Shipper==null?"": n.Shipper.Name) ,
    VehiclePlateNumber = (n.Vehicle==null?"": n.Vehicle.PlateNumber) ,
    Id = n.Id,
    OrderNo = n.OrderNo,
    ExternalNo = n.ExternalNo,
    OrderDate = n.OrderDate,
    Location1 = n.Location1,
    Location2 = n.Location2,
    Requirements = n.Requirements,
    PlanDeliveryDate = n.PlanDeliveryDate,
    TimePeriod = n.TimePeriod,
    TakeTicketFlag = n.TakeTicketFlag,
    PriceType = n.PriceType,
    VehicleTypeRequirement = n.VehicleTypeRequirement,
    VehicleLengthRequirement = n.VehicleLengthRequirement,
    LoadTransportStationCode = n.LoadTransportStationCode,
    LoadTransportStationName = n.LoadTransportStationName,
    ReceiptTransportStationCode = n.ReceiptTransportStationCode,
    ReceiptTransportStationName = n.ReceiptTransportStationName,
    VehicleId = n.VehicleId,
    PlateNumber = n.PlateNumber,
    Driver = n.Driver,
    DriverPhone = n.DriverPhone,
    ProductName = n.ProductName,
    CargotypeClassificationCode = n.CargotypeClassificationCode,
    PackageTypeCode = n.PackageTypeCode,
    Packages = n.Packages,
    Weight = n.Weight,
    MeasurementUnitCode = n.MeasurementUnitCode,
    Volume = n.Volume,
    VolumeMeasurementUnitCode = n.VolumeMeasurementUnitCode,
    Cartons = n.Cartons,
    Pallets = n.Pallets,
    BreakCartons = n.BreakCartons,
    GoodsPrice = n.GoodsPrice,
    TotalMonetaryAmount = n.TotalMonetaryAmount,
    InputUser = n.InputUser,
    Status = n.Status,
    ResquestedLoadStartDatetime = n.ResquestedLoadStartDatetime,
    ResquestedLoadEndDatetime = n.ResquestedLoadEndDatetime,
    DeliveryDate = n.DeliveryDate,
    CloseDate = n.CloseDate,
    PodNo = n.PodNo,
    PodPhotographPath = n.PodPhotographPath,
    PodPhotograph = n.PodPhotograph,
    ShipperId = n.ShipperId,
    PhoneNumber = n.PhoneNumber,
    MobileTelephoneNumber = n.MobileTelephoneNumber,
    Contact = n.Contact,
    PersonalIdentityTypeCode = n.PersonalIdentityTypeCode,
    PersonalIdentityDocument = n.PersonalIdentityDocument,
    CompanyId = n.CompanyId,
    ContractNumber = n.ContractNumber,
    RequestedInsuranceFlag = n.RequestedInsuranceFlag,
    InsuranceCompany = n.InsuranceCompany,
    InsuranceBillCode = n.InsuranceBillCode,
    InsuranceAccessAddress = n.InsuranceAccessAddress,
    Consignee = n.Consignee,
    ConsiContactName = n.ConsiContactName,
    ConsiTelephoneNumber = n.ConsiTelephoneNumber,
    ConsiAddress = n.ConsiAddress,
    ConsiMobileTelephoneNumber = n.ConsiMobileTelephoneNumber,
    ConsiCountrySubdivisionCode = n.ConsiCountrySubdivisionCode,
    ConsiCountrySubdivisionName = n.ConsiCountrySubdivisionName,
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
            			    var orders  = await this.orderService
						               .Query(new OrderQuery().ByVehicleIdWithfilter(vehicleid,filters)).Include(o => o.Company).Include(o => o.Shipper).Include(o => o.Vehicle)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = orders .Select(  n => new { 

    CompanyName = (n.Company==null?"": n.Company.Name) ,
    ShipperName = (n.Shipper==null?"": n.Shipper.Name) ,
    VehiclePlateNumber = (n.Vehicle==null?"": n.Vehicle.PlateNumber) ,
    Id = n.Id,
    OrderNo = n.OrderNo,
    ExternalNo = n.ExternalNo,
    OrderDate = n.OrderDate,
    Location1 = n.Location1,
    Location2 = n.Location2,
    Requirements = n.Requirements,
    PlanDeliveryDate = n.PlanDeliveryDate,
    TimePeriod = n.TimePeriod,
    TakeTicketFlag = n.TakeTicketFlag,
    PriceType = n.PriceType,
    VehicleTypeRequirement = n.VehicleTypeRequirement,
    VehicleLengthRequirement = n.VehicleLengthRequirement,
    LoadTransportStationCode = n.LoadTransportStationCode,
    LoadTransportStationName = n.LoadTransportStationName,
    ReceiptTransportStationCode = n.ReceiptTransportStationCode,
    ReceiptTransportStationName = n.ReceiptTransportStationName,
    VehicleId = n.VehicleId,
    PlateNumber = n.PlateNumber,
    Driver = n.Driver,
    DriverPhone = n.DriverPhone,
    ProductName = n.ProductName,
    CargotypeClassificationCode = n.CargotypeClassificationCode,
    PackageTypeCode = n.PackageTypeCode,
    Packages = n.Packages,
    Weight = n.Weight,
    MeasurementUnitCode = n.MeasurementUnitCode,
    Volume = n.Volume,
    VolumeMeasurementUnitCode = n.VolumeMeasurementUnitCode,
    Cartons = n.Cartons,
    Pallets = n.Pallets,
    BreakCartons = n.BreakCartons,
    GoodsPrice = n.GoodsPrice,
    TotalMonetaryAmount = n.TotalMonetaryAmount,
    InputUser = n.InputUser,
    Status = n.Status,
    ResquestedLoadStartDatetime = n.ResquestedLoadStartDatetime,
    ResquestedLoadEndDatetime = n.ResquestedLoadEndDatetime,
    DeliveryDate = n.DeliveryDate,
    CloseDate = n.CloseDate,
    PodNo = n.PodNo,
    PodPhotographPath = n.PodPhotographPath,
    PodPhotograph = n.PodPhotograph,
    ShipperId = n.ShipperId,
    PhoneNumber = n.PhoneNumber,
    MobileTelephoneNumber = n.MobileTelephoneNumber,
    Contact = n.Contact,
    PersonalIdentityTypeCode = n.PersonalIdentityTypeCode,
    PersonalIdentityDocument = n.PersonalIdentityDocument,
    CompanyId = n.CompanyId,
    ContractNumber = n.ContractNumber,
    RequestedInsuranceFlag = n.RequestedInsuranceFlag,
    InsuranceCompany = n.InsuranceCompany,
    InsuranceBillCode = n.InsuranceBillCode,
    InsuranceAccessAddress = n.InsuranceAccessAddress,
    Consignee = n.Consignee,
    ConsiContactName = n.ConsiContactName,
    ConsiTelephoneNumber = n.ConsiTelephoneNumber,
    ConsiAddress = n.ConsiAddress,
    ConsiMobileTelephoneNumber = n.ConsiMobileTelephoneNumber,
    ConsiCountrySubdivisionCode = n.ConsiCountrySubdivisionCode,
    ConsiCountrySubdivisionName = n.ConsiCountrySubdivisionName,
    CreatedDate = n.CreatedDate,
    CreatedBy = n.CreatedBy,
    LastModifiedDate = n.LastModifiedDate,
    LastModifiedBy = n.LastModifiedBy
}).ToList();
			var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
                [HttpGet]
        public async Task<ActionResult> GetDataByShipperId (int  shipperid ,int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {    
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
            			    var orders  = await this.orderService
						               .Query(new OrderQuery().ByShipperIdWithfilter(shipperid,filters)).Include(o => o.Company).Include(o => o.Shipper).Include(o => o.Vehicle)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = orders .Select(  n => new { 

    CompanyName = (n.Company==null?"": n.Company.Name) ,
    ShipperName = (n.Shipper==null?"": n.Shipper.Name) ,
    VehiclePlateNumber = (n.Vehicle==null?"": n.Vehicle.PlateNumber) ,
    Id = n.Id,
    OrderNo = n.OrderNo,
    ExternalNo = n.ExternalNo,
    OrderDate = n.OrderDate,
    Location1 = n.Location1,
    Location2 = n.Location2,
    Requirements = n.Requirements,
    PlanDeliveryDate = n.PlanDeliveryDate,
    TimePeriod = n.TimePeriod,
    TakeTicketFlag = n.TakeTicketFlag,
    PriceType = n.PriceType,
    VehicleTypeRequirement = n.VehicleTypeRequirement,
    VehicleLengthRequirement = n.VehicleLengthRequirement,
    LoadTransportStationCode = n.LoadTransportStationCode,
    LoadTransportStationName = n.LoadTransportStationName,
    ReceiptTransportStationCode = n.ReceiptTransportStationCode,
    ReceiptTransportStationName = n.ReceiptTransportStationName,
    VehicleId = n.VehicleId,
    PlateNumber = n.PlateNumber,
    Driver = n.Driver,
    DriverPhone = n.DriverPhone,
    ProductName = n.ProductName,
    CargotypeClassificationCode = n.CargotypeClassificationCode,
    PackageTypeCode = n.PackageTypeCode,
    Packages = n.Packages,
    Weight = n.Weight,
    MeasurementUnitCode = n.MeasurementUnitCode,
    Volume = n.Volume,
    VolumeMeasurementUnitCode = n.VolumeMeasurementUnitCode,
    Cartons = n.Cartons,
    Pallets = n.Pallets,
    BreakCartons = n.BreakCartons,
    GoodsPrice = n.GoodsPrice,
    TotalMonetaryAmount = n.TotalMonetaryAmount,
    InputUser = n.InputUser,
    Status = n.Status,
    ResquestedLoadStartDatetime = n.ResquestedLoadStartDatetime,
    ResquestedLoadEndDatetime = n.ResquestedLoadEndDatetime,
    DeliveryDate = n.DeliveryDate,
    CloseDate = n.CloseDate,
    PodNo = n.PodNo,
    PodPhotographPath = n.PodPhotographPath,
    PodPhotograph = n.PodPhotograph,
    ShipperId = n.ShipperId,
    PhoneNumber = n.PhoneNumber,
    MobileTelephoneNumber = n.MobileTelephoneNumber,
    Contact = n.Contact,
    PersonalIdentityTypeCode = n.PersonalIdentityTypeCode,
    PersonalIdentityDocument = n.PersonalIdentityDocument,
    CompanyId = n.CompanyId,
    ContractNumber = n.ContractNumber,
    RequestedInsuranceFlag = n.RequestedInsuranceFlag,
    InsuranceCompany = n.InsuranceCompany,
    InsuranceBillCode = n.InsuranceBillCode,
    InsuranceAccessAddress = n.InsuranceAccessAddress,
    Consignee = n.Consignee,
    ConsiContactName = n.ConsiContactName,
    ConsiTelephoneNumber = n.ConsiTelephoneNumber,
    ConsiAddress = n.ConsiAddress,
    ConsiMobileTelephoneNumber = n.ConsiMobileTelephoneNumber,
    ConsiCountrySubdivisionCode = n.ConsiCountrySubdivisionCode,
    ConsiCountrySubdivisionName = n.ConsiCountrySubdivisionName,
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
            			    var orders  = await this.orderService
						               .Query(new OrderQuery().ByCompanyIdWithfilter(companyid,filters)).Include(o => o.Company).Include(o => o.Shipper).Include(o => o.Vehicle)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = orders .Select(  n => new { 

    CompanyName = (n.Company==null?"": n.Company.Name) ,
    ShipperName = (n.Shipper==null?"": n.Shipper.Name) ,
    VehiclePlateNumber = (n.Vehicle==null?"": n.Vehicle.PlateNumber) ,
    Id = n.Id,
    OrderNo = n.OrderNo,
    ExternalNo = n.ExternalNo,
    OrderDate = n.OrderDate,
    Location1 = n.Location1,
    Location2 = n.Location2,
    Requirements = n.Requirements,
    PlanDeliveryDate = n.PlanDeliveryDate,
    TimePeriod = n.TimePeriod,
    TakeTicketFlag = n.TakeTicketFlag,
    PriceType = n.PriceType,
    VehicleTypeRequirement = n.VehicleTypeRequirement,
    VehicleLengthRequirement = n.VehicleLengthRequirement,
    LoadTransportStationCode = n.LoadTransportStationCode,
    LoadTransportStationName = n.LoadTransportStationName,
    ReceiptTransportStationCode = n.ReceiptTransportStationCode,
    ReceiptTransportStationName = n.ReceiptTransportStationName,
    VehicleId = n.VehicleId,
    PlateNumber = n.PlateNumber,
    Driver = n.Driver,
    DriverPhone = n.DriverPhone,
    ProductName = n.ProductName,
    CargotypeClassificationCode = n.CargotypeClassificationCode,
    PackageTypeCode = n.PackageTypeCode,
    Packages = n.Packages,
    Weight = n.Weight,
    MeasurementUnitCode = n.MeasurementUnitCode,
    Volume = n.Volume,
    VolumeMeasurementUnitCode = n.VolumeMeasurementUnitCode,
    Cartons = n.Cartons,
    Pallets = n.Pallets,
    BreakCartons = n.BreakCartons,
    GoodsPrice = n.GoodsPrice,
    TotalMonetaryAmount = n.TotalMonetaryAmount,
    InputUser = n.InputUser,
    Status = n.Status,
    ResquestedLoadStartDatetime = n.ResquestedLoadStartDatetime,
    ResquestedLoadEndDatetime = n.ResquestedLoadEndDatetime,
    DeliveryDate = n.DeliveryDate,
    CloseDate = n.CloseDate,
    PodNo = n.PodNo,
    PodPhotographPath = n.PodPhotographPath,
    PodPhotograph = n.PodPhotograph,
    ShipperId = n.ShipperId,
    PhoneNumber = n.PhoneNumber,
    MobileTelephoneNumber = n.MobileTelephoneNumber,
    Contact = n.Contact,
    PersonalIdentityTypeCode = n.PersonalIdentityTypeCode,
    PersonalIdentityDocument = n.PersonalIdentityDocument,
    CompanyId = n.CompanyId,
    ContractNumber = n.ContractNumber,
    RequestedInsuranceFlag = n.RequestedInsuranceFlag,
    InsuranceCompany = n.InsuranceCompany,
    InsuranceBillCode = n.InsuranceBillCode,
    InsuranceAccessAddress = n.InsuranceAccessAddress,
    Consignee = n.Consignee,
    ConsiContactName = n.ConsiContactName,
    ConsiTelephoneNumber = n.ConsiTelephoneNumber,
    ConsiAddress = n.ConsiAddress,
    ConsiMobileTelephoneNumber = n.ConsiMobileTelephoneNumber,
    ConsiCountrySubdivisionCode = n.ConsiCountrySubdivisionCode,
    ConsiCountrySubdivisionName = n.ConsiCountrySubdivisionName,
    CreatedDate = n.CreatedDate,
    CreatedBy = n.CreatedBy,
    LastModifiedDate = n.LastModifiedDate,
    LastModifiedBy = n.LastModifiedBy
}).ToList();
			var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
        		[HttpPost]
				public async Task<JsonResult> SaveData(OrderChangeViewModel orders)
		{
			if (orders.updated != null)
			{
				foreach (var item in orders.updated)
				{
					this.orderService.Update(item);
				}
			}
			if (orders.deleted != null)
			{
				foreach (var item in orders.deleted)
				{
					this.orderService.Delete(item);
				}
			}
			if (orders.inserted != null)
			{
				foreach (var item in orders.inserted)
				{
					this.orderService.Insert(item);
				}
			}
			await this.unitOfWork.SaveChangesAsync();
			return Json(new {success=true}, JsonRequestBehavior.AllowGet);
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
		public async Task<JsonResult> GetShippers(string q="")
		{
			var shipperRepository = this.unitOfWork.RepositoryAsync<Shipper>();
			var data = await shipperRepository.Queryable().Where(n=>n.Name.Contains(q)).OrderBy(n=>n.Name).ToListAsync();
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
								// GET: Orders/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var  order = await this.orderService.FindAsync(id);
			if (order == null)
			{
				return HttpNotFound();
			}
			return View(order);
		}
		// GET: Orders/Create
        		public ActionResult Create()
				{
			var order = new Order();
			//set default value
			var companyRepository = this.unitOfWork.RepositoryAsync<Company>();
		   			ViewBag.CompanyId = new SelectList(companyRepository.Queryable().OrderBy(n=>n.Name), "Id", "Name");
		   			var shipperRepository = this.unitOfWork.RepositoryAsync<Shipper>();
		   			ViewBag.ShipperId = new SelectList(shipperRepository.Queryable().OrderBy(n=>n.Name), "Id", "Name");
		   			var vehicleRepository = this.unitOfWork.RepositoryAsync<Vehicle>();
		   			ViewBag.VehicleId = new SelectList(vehicleRepository.Queryable().OrderBy(n=>n.PlateNumber), "Id", "PlateNumber");
		   			return View(order);
		}
		// POST: Orders/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "Company,Shipper,Vehicle,Id,OrderNo,ExternalNo,OrderDate,Location1,Location2,Requirements,PlanDeliveryDate,TimePeriod,TakeTicketFlag,PriceType,VehicleTypeRequirement,VehicleLengthRequirement,LoadTransportStationCode,LoadTransportStationName,ReceiptTransportStationCode,ReceiptTransportStationName,VehicleId,PlateNumber,Driver,DriverPhone,ProductName,CargotypeClassificationCode,PackageTypeCode,Packages,Weight,MeasurementUnitCode,Volume,VolumeMeasurementUnitCode,Cartons,Pallets,BreakCartons,GoodsPrice,TotalMonetaryAmount,InputUser,Status,ResquestedLoadStartDatetime,ResquestedLoadEndDatetime,DeliveryDate,CloseDate,PodNo,PodPhotographPath,PodPhotograph,ShipperId,PhoneNumber,MobileTelephoneNumber,Contact,PersonalIdentityTypeCode,PersonalIdentityDocument,CompanyId,ContractNumber,RequestedInsuranceFlag,InsuranceCompany,InsuranceBillCode,InsuranceAccessAddress,Consignee,ConsiContactName,ConsiTelephoneNumber,ConsiAddress,ConsiMobileTelephoneNumber,ConsiCountrySubdivisionCode,ConsiCountrySubdivisionName,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Order order)
		{
			if (ModelState.IsValid)
			{
			 				orderService.Insert(order);
		   				await this.unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has append a Order record");
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
						var companyRepository = this.unitOfWork.RepositoryAsync<Company>();
						ViewBag.CompanyId = new SelectList(await companyRepository.Queryable().OrderBy(n=>n.Name).ToListAsync(), "Id", "Name", order.CompanyId);
									var shipperRepository = this.unitOfWork.RepositoryAsync<Shipper>();
						ViewBag.ShipperId = new SelectList(await shipperRepository.Queryable().OrderBy(n=>n.Name).ToListAsync(), "Id", "Name", order.ShipperId);
									var vehicleRepository = this.unitOfWork.RepositoryAsync<Vehicle>();
						ViewBag.VehicleId = new SelectList(await vehicleRepository.Queryable().OrderBy(n=>n.PlateNumber).ToListAsync(), "Id", "PlateNumber", order.VehicleId);
									return View(order);
		}
        // GET: Orders/PopupEdit/5
        //[OutputCache(Duration = 360, VaryByParam = "id")]
		public async Task<JsonResult> PopupEdit(int? id)
		{
			
			var order = await this.orderService.FindAsync(id);
			return Json(order,JsonRequestBehavior.AllowGet);
		}

		// GET: Orders/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var order = await this.orderService.FindAsync(id);
			if (order == null)
			{
				return HttpNotFound();
			}
			var companyRepository = this.unitOfWork.RepositoryAsync<Company>();
			ViewBag.CompanyId = new SelectList(companyRepository.Queryable().OrderBy(n=>n.Name), "Id", "Name", order.CompanyId);
			var shipperRepository = this.unitOfWork.RepositoryAsync<Shipper>();
			ViewBag.ShipperId = new SelectList(shipperRepository.Queryable().OrderBy(n=>n.Name), "Id", "Name", order.ShipperId);
			var vehicleRepository = this.unitOfWork.RepositoryAsync<Vehicle>();
			ViewBag.VehicleId = new SelectList(vehicleRepository.Queryable().OrderBy(n=>n.PlateNumber), "Id", "PlateNumber", order.VehicleId);
			return View(order);
		}
		// POST: Orders/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "Company,Shipper,Vehicle,Id,OrderNo,ExternalNo,OrderDate,Location1,Location2,Requirements,PlanDeliveryDate,TimePeriod,TakeTicketFlag,PriceType,VehicleTypeRequirement,VehicleLengthRequirement,LoadTransportStationCode,LoadTransportStationName,ReceiptTransportStationCode,ReceiptTransportStationName,VehicleId,PlateNumber,Driver,DriverPhone,ProductName,CargotypeClassificationCode,PackageTypeCode,Packages,Weight,MeasurementUnitCode,Volume,VolumeMeasurementUnitCode,Cartons,Pallets,BreakCartons,GoodsPrice,TotalMonetaryAmount,InputUser,Status,ResquestedLoadStartDatetime,ResquestedLoadEndDatetime,DeliveryDate,CloseDate,PodNo,PodPhotographPath,PodPhotograph,ShipperId,PhoneNumber,MobileTelephoneNumber,Contact,PersonalIdentityTypeCode,PersonalIdentityDocument,CompanyId,ContractNumber,RequestedInsuranceFlag,InsuranceCompany,InsuranceBillCode,InsuranceAccessAddress,Consignee,ConsiContactName,ConsiTelephoneNumber,ConsiAddress,ConsiMobileTelephoneNumber,ConsiCountrySubdivisionCode,ConsiCountrySubdivisionName,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Order order)
		{
			if (ModelState.IsValid)
			{
				order.TrackingState = TrackingState.Modified;
								orderService.Update(order);
								await   this.unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has update a Order record");
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
						var companyRepository = this.unitOfWork.RepositoryAsync<Company>();
												var shipperRepository = this.unitOfWork.RepositoryAsync<Shipper>();
												var vehicleRepository = this.unitOfWork.RepositoryAsync<Vehicle>();
												return View(order);
		}
		// GET: Orders/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var order = await this.orderService.FindAsync(id);
			if (order == null)
			{
				return HttpNotFound();
			}
			return View(order);
		}
		// POST: Orders/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var order = await  this.orderService.FindAsync(id);
			 this.orderService.Delete(order);
			await this.unitOfWork.SaveChangesAsync();
		   if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
			DisplaySuccessMessage("Has delete a Order record");
			return RedirectToAction("Index");
		}
       
 
		//导出Excel
		[HttpPost]
		public ActionResult ExportExcel( string filterRules = "",string sort = "Id", string order = "asc")
		{
			var fileName = "orders_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream=  this.orderService.ExportExcel(filterRules,sort, order );
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
