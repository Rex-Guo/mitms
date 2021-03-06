﻿/// <summary>
/// Provides functionality to the /Order/ route.
/// <date> 5/10/2018 1:01:17 PM </date>
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
using WebApp.Models;
using WebApp.Services;
using WebApp.Repositories;
using TrackableEntities;

namespace WebApp.Controllers
{
    //[Authorize]
    public class OrdersController : Controller
    {
        //private StoreContext db = new StoreContext();
        private readonly IOrderService _orderService;
        private readonly IUnitOfWorkAsync _unitOfWork;
        public OrdersController(IOrderService orderService, IUnitOfWorkAsync unitOfWork)
        {
            _orderService = orderService;
            _unitOfWork = unitOfWork;
        }
        // GET: Orders/Index
        //[OutputCache(Duration = 360, VaryByParam = "none")]
        public ActionResult Index()
        {
            var customrep = this._unitOfWork.RepositoryAsync<Shipper>();
            ViewBag.Shipper = new SelectList(customrep.Queryable().OrderBy(n => n.Name).ToList(), "Id", "Name");
            var coderep = this._unitOfWork.RepositoryAsync<CodeItem>();
            ViewBag.TimePeriod = new SelectList(coderep.Queryable().Where(x => x.CodeType == "TimePeriod").OrderBy(n => n.Code).ToList(), "Code", "Text");
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
            var orders = await this._orderService
       .Query(new OrderQuery().Withfilter(filters)).Include(o => o.Company).Include(o => o.Shipper).Include(o => o.Vehicle)
       .OrderBy(n => n.OrderBy(sort, order))
       .SelectPageAsync(page, rows, out totalCount);
            var datarows = orders.Select(n => new {

                CompanyName = (n.Company == null ? "" : n.Company.Name),
                ShipperName = (n.Shipper == null ? "" : n.Shipper.Name),
                VehiclePlateNumber = (n.Vehicle == null ? "" : n.Vehicle.PlateNumber),
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
        public async Task<ActionResult> GetDataByVehicleId(int vehicleid, int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            var totalCount = 0;
            var orders = await this._orderService
                       .Query(new OrderQuery().ByVehicleIdWithfilter(vehicleid, filters)).Include(o => o.Company).Include(o => o.Shipper).Include(o => o.Vehicle)
                       .OrderBy(n => n.OrderBy(sort, order))
                       .SelectPageAsync(page, rows, out totalCount);
            var datarows = orders.Select(n => new {

                CompanyName = (n.Company == null ? "" : n.Company.Name),
                ShipperName = (n.Shipper == null ? "" : n.Shipper.Name),
                VehiclePlateNumber = (n.Vehicle == null ? "" : n.Vehicle.PlateNumber),
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
        public async Task<ActionResult> GetDataByShipperId(int Shipperid, int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            var totalCount = 0;
            var orders = await _orderService
                       .Query(new OrderQuery().ByShipperIdWithfilter(Shipperid, filters)).Include(o => o.Shipper).Include(o => o.Vehicle)
                       .OrderBy(n => n.OrderBy(sort, order))
                       .SelectPageAsync(page, rows, out totalCount);
            var datarows = orders.Select(n => new
            {
                ShipperName = (n.Shipper == null ? "" : n.Shipper.Name),
                VehiclePlateNumber = (n.Vehicle == null ? "" : n.Vehicle.PlateNumber),
                Id = n.Id,
                OrderNo = n.OrderNo,
                ExternalNo = n.ExternalNo,
                OrderDate = n.OrderDate,
                Location1 = n.Location1,
                Location2 = n.Location2,
                Requirements = n.Requirements,
                PlanDeliveryDate = n.PlanDeliveryDate,
                TimePeriod = n.TimePeriod,
                VehicleId = n.VehicleId,
                PlateNumber = n.PlateNumber,
                Driver = n.Driver,
                DriverPhone = n.DriverPhone,
                Packages = n.Packages,
                Weight = n.Weight,
                Volume = n.Volume,
                Cartons = n.Cartons,
                Pallets = n.Pallets,
                Status = n.Status,
                DeliveryDate = n.DeliveryDate,
                CloseDate = n.CloseDate,
                ShipperId = n.ShipperId,
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
                    _orderService.ShippingOrder(item);
                }
            }
            if (orders.deleted != null)
            {
                foreach (var item in orders.deleted)
                {
                    _orderService.Delete(item);
                }
            }
            if (orders.inserted != null)
            {
                foreach (var item in orders.inserted)
                {
                    _orderService.Insert(item);
                }
            }
            try
            {
                await _unitOfWork.SaveChangesAsync();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e) {
                return Json(new { success = false,err=e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        //[OutputCache(Duration = 360, VaryByParam = "none")]
        public async Task<JsonResult> GetShippers(string q = "")
        {
            var ShipperRepository = _unitOfWork.RepositoryAsync<Shipper>();
            var data = await ShipperRepository.Queryable().Where(n => n.Name.Contains(q)).ToListAsync();
            var rows = data.Select(n => new { Id = n.Id, Name = n.Name });
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
        //[OutputCache(Duration = 360, VaryByParam = "none")]
        public async Task<JsonResult> GetVehicles(string q = "")
        {
            var vehicleRepository = _unitOfWork.RepositoryAsync<Vehicle>();
            var data = await vehicleRepository.Queryable().Where(n => n.PlateNumber.Contains(q)).ToListAsync();
            var rows = data.Select(n => new { Id = n.Id, PlateNumber = n.PlateNumber });
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> GetAvailableVehicles(string q = "")
        {
            var vehicleRepository = _unitOfWork.RepositoryAsync<Vehicle>();
            var data = await vehicleRepository.Queryable().Where(n => (n.Status=="空车" || n.Status=="接单") && n.PlateNumber.Contains(q)).ToListAsync();
            var rows = data.Select(n => new
            {
                Id = n.Id,
                PlateNumber = n.PlateNumber,
                Status = n.Status,
                CarType = n.CarType,
                StrLoadWeight = n.StrLoadWeight,
                Driver =n.Driver,
                DriverPhone = n.DriverPhone

            });
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetAvailableVehiclesWithCarrierId(int carrierid,string q = "")
        {
            var vehicleRepository = _unitOfWork.RepositoryAsync<Vehicle>();
            var data = await vehicleRepository.Queryable().Where(n => n.CarrierId==carrierid && (n.Status == "空车" || n.Status == "接单") && n.PlateNumber.Contains(q)).ToListAsync();
            var rows = data.Select(n => new
            {
                Id = n.Id,
                PlateNumber = n.PlateNumber,
                Status = n.Status,
                CarType = n.CarType,
                StrLoadWeight = n.StrLoadWeight,
                Driver = n.Driver,
                DriverPhone = n.DriverPhone

            });
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = await _orderService.FindAsync(id);
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
            var ShipperRepository = _unitOfWork.RepositoryAsync<Shipper>();
            ViewBag.ShipperId = new SelectList(ShipperRepository.Queryable(), "Id", "Name");
            var vehicleRepository = _unitOfWork.RepositoryAsync<Vehicle>();
            ViewBag.VehicleId = new SelectList(vehicleRepository.Queryable(), "Id", "OrderNo");
            return View(order);
        }
        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( Order order)
        {
            if (ModelState.IsValid)
            {
                 
                _orderService.Create(order);
                await _unitOfWork.SaveChangesAsync();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true,message="订单号:[" + order.OrderNo + "]创建成功!" }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has append a Order record");
                return RedirectToAction("Index");
            }
            else
            {
                var modelStateErrors = String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
                }
                DisplayErrorMessage(modelStateErrors);
            }
            var ShipperRepository = _unitOfWork.RepositoryAsync<Shipper>();
            ViewBag.ShipperId = new SelectList(await ShipperRepository.Queryable().ToListAsync(), "Id", "Name", order.ShipperId);
            var vehicleRepository = _unitOfWork.RepositoryAsync<Vehicle>();
            ViewBag.VehicleId = new SelectList(await vehicleRepository.Queryable().ToListAsync(), "Id", "OrderNo", order.VehicleId);
            return View(order);
        }
        // GET: Orders/PopupEdit/5
        //[OutputCache(Duration = 360, VaryByParam = "id")]
        public async Task<JsonResult> PopupEdit(int? id)
        {

            var order = await _orderService.FindAsync(id);
            return Json(order, JsonRequestBehavior.AllowGet);
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = await _orderService.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            var ShipperRepository = _unitOfWork.RepositoryAsync<Shipper>();
            ViewBag.ShipperId = new SelectList(ShipperRepository.Queryable(), "Id", "Name", order.ShipperId);
            var vehicleRepository = _unitOfWork.RepositoryAsync<Vehicle>();
            ViewBag.VehicleId = new SelectList(vehicleRepository.Queryable(), "Id", "OrderNo", order.VehicleId);
            return View(order);
        }
        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Shipper,Vehicle,Id,OrderNo,ExternalNo,OrderDate,Location1,Location2,Requirements,PlanDeliveryDate,TimePeriod,VehicleId,PlateNumber,Driver,DriverPhone,Packages,Weight,Volume,Cartons,Pallets,Status,DeliveryDate,CloseDate,ShipperId,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.TrackingState = TrackingState.Modified;
                _orderService.Update(order);
                await _unitOfWork.SaveChangesAsync();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has update a Order record");
                return RedirectToAction("Index");
            }
            else
            {
                var modelStateErrors = String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
                }
                DisplayErrorMessage(modelStateErrors);
            }
            var ShipperRepository = _unitOfWork.RepositoryAsync<Shipper>();
            ViewBag.ShipperId = new SelectList(await ShipperRepository.Queryable().ToListAsync(), "Id", "Name", order.ShipperId);
            var vehicleRepository = _unitOfWork.RepositoryAsync<Vehicle>();
            ViewBag.VehicleId = new SelectList(await vehicleRepository.Queryable().ToListAsync(), "Id", "OrderNo", order.VehicleId);
            return View(order);
        }
        // GET: Orders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = await _orderService.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var order = await _orderService.FindAsync(id);
            _orderService.Delete(order);
            await _unitOfWork.SaveChangesAsync();
            if (Request.IsAjaxRequest())
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            DisplaySuccessMessage("Has delete a Order record");
            return RedirectToAction("Index");
        }
        public ActionResult Shipping() {

            var customrep = this._unitOfWork.RepositoryAsync<Shipper>();
            ViewBag.Shipper = new SelectList(customrep.Queryable().OrderBy(n=>n.Name).ToList(), "Id", "Name");
            var coderep = this._unitOfWork.RepositoryAsync<CodeItem>();
            ViewBag.TimePeriod = new SelectList(coderep.Queryable().Where(x=>x.CodeType== "TimePeriod").OrderBy(n => n.Code).ToList(), "Code", "Text");
            return View();
        }

        
        //生存派车单
        public async Task<ActionResult> DoShippingOrder(Order order) {

            if (ModelState.IsValid)
            {
                try
                {
                    this._orderService.DoShippingOrder(order);
                    var result = await this._unitOfWork.SaveChangesAsync();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e) {
                    return Json(new { success = false,err = e.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else {
                var modelStateErrors = String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
              
                    return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
               
            }
        }
        
        //POD查询
        public ActionResult Pod()
        {
            var customrep = this._unitOfWork.RepositoryAsync<Shipper>();
            ViewBag.Shipper = new SelectList(customrep.Queryable().OrderBy(n => n.Name).ToList(), "Id", "Name");
            var coderep = this._unitOfWork.RepositoryAsync<CodeItem>();
            ViewBag.TimePeriod = new SelectList(coderep.Queryable().Where(x => x.CodeType == "TimePeriod").OrderBy(n => n.Code).ToList(), "Code", "Text");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> DoPod(int[] id) {

            this._orderService.DoPod(id);
            await this._unitOfWork.SaveChangesAsync();
            return Json(new { success = true}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Bidding() {
            var customrep = this._unitOfWork.RepositoryAsync<Shipper>();
            ViewBag.Shipper = new SelectList(customrep.Queryable().OrderBy(n => n.Name).ToList(), "Id", "Name");
            var coderep = this._unitOfWork.RepositoryAsync<CodeItem>();
            ViewBag.TimePeriod = new SelectList(coderep.Queryable().Where(x => x.CodeType == "TimePeriod").OrderBy(n => n.Code).ToList(), "Code", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult DoBidding(int[] id)
        {
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        //首页托运人新建订单
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrderByShipper(Order order) {
            if (ModelState.IsValid)
            {
                this._orderService.CreateByShipper(order);
                this._unitOfWork.SaveChanges();
            }
            else {
                var modelStateErrors = String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { success = true,orderno=order.OrderNo }, JsonRequestBehavior.AllowGet);
        }

        //导出Excel
        [HttpPost]
        public ActionResult ExportExcel(string filterRules = "", string sort = "Id", string order = "asc")
        {
            var fileName = "orders_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            var stream = _orderService.ExportExcel(filterRules, sort, order);
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
