/// <summary>
/// Provides functionality to the /Vehicle/ route.
/// <date> 5/10/2018 1:00:30 PM </date>
/// Create By SmartCode MVC5 Scaffolder for Visual Studio
/// TODO: RegisterType UnityConfig.cs
/// container.RegisterType<IRepositoryAsync<Vehicle>, Repository<Vehicle>>();
/// container.RegisterType<IVehicleService, VehicleService>();
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
namespace WebApp.Controllers
{
    //[Authorize]
    public class VehiclesController : Controller
    {
        //private StoreContext db = new StoreContext();
        private readonly IVehicleService _vehicleService;
        private readonly IUnitOfWorkAsync _unitOfWork;
        public VehiclesController(IVehicleService vehicleService, IUnitOfWorkAsync unitOfWork)
        {
            _vehicleService = vehicleService;
            _unitOfWork = unitOfWork;
        }
        // GET: Vehicles/Index
        //[OutputCache(Duration = 360, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
        // Get :Vehicles/PageList
        // For Index View Boostrap-Table load  data 
        [HttpGet]
        public async Task<JsonResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            var totalCount = 0;
            //int pagenum = offset / limit +1;
            var vehicles = await _vehicleService
       .Query(new VehicleQuery().Withfilter(filters)).Include(v => v.Company)
       .OrderBy(n => n.OrderBy(sort, order))
       .SelectPageAsync(page, rows, out totalCount);
            var datarows = vehicles.Select(n => new
            {
                CompanyName = (n.Company == null ? "" : n.Company.Name),
                Id = n.Id,
                OrderId = n.OrderId,
                OrderNo = n.OrderNo,
                ExternalNo = n.ExternalNo,
                UsingDate = n.UsingDate,
                TimePeriod = n.TimePeriod,
                Location1 = n.Location1,
                Location2 = n.Location2,
                Requirements = n.Requirements,
                Packages = n.Packages,
                Weight = n.Weight,
                Volume = n.Volume,
                Cartons = n.Cartons,
                Pallets = n.Pallets,
                InputUser = n.InputUser,
                CustomerId = n.CustomerId,
                PlateNumber = n.PlateNumber,
                PlateNumberPosition = n.PlateNumberPosition,
                VehStatus = n.VehStatus,
                CarType = n.CarType,
                VehicleType = n.VehicleType,
                VehicleProperty = n.VehicleProperty,
                CompanyId = n.CompanyId,
                Axles = n.Axles,
                ECOMark = n.ECOMark,
                StrLoadWeight = n.StrLoadWeight,
                LoadWeight = n.LoadWeight,
                LoadVolume = n.LoadVolume,
                CarriageSize = n.CarriageSize,
                Driver = n.Driver,
                DriverPhone = n.DriverPhone,
                AssistantDriver = n.AssistantDriver,
                AssistantDriverPhone = n.AssistantDriverPhone,
                VehLongSize = n.VehLongSize,
                CubicleType = n.CubicleType,
                VehUseType = n.VehUseType,
                CustomsNo = n.CustomsNo,
                VehUse = n.VehUse,
                AVGECON = n.AVGECON,
                AVGECONScale = n.AVGECONScale,
                RoadKM = n.RoadKM,
                RoadHours = n.RoadHours,
                RoadKMScale = n.RoadKMScale,
                GPSDeviceId = n.GPSDeviceId,
                Owner = n.Owner,
                OwnerContactPhone = n.OwnerContactPhone,
                Brand = n.Brand,
                RPM = n.RPM,
                PurchasedDate = n.PurchasedDate,
                PurchasedAmount = n.PurchasedAmount,
                VehLong = n.VehLong,
                VehWide = n.VehWide,
                VehHigh = n.VehHigh,
                VIN = n.VIN,
                ServiceLife = n.ServiceLife,
                MaintainKM = n.MaintainKM,
                MaintainDate = n.MaintainDate,
                MaintainMonth = n.MaintainMonth,
                ExistVehTailBoard = n.ExistVehTailBoard,
                VehTailBoardBrand = n.VehTailBoardBrand,
                VehTailBoardFactory = n.VehTailBoardFactory,
                VehTailBoardLife = n.VehTailBoardLife,
                VehTailBoardAmount = n.VehTailBoardAmount,
                VehTailBoardGPSDeviceId = n.VehTailBoardGPSDeviceId,
                DrLicenseModel = n.DrLicenseModel,
                DrLicenseUseNature = n.DrLicenseUseNature,
                DrLicenseBrand = n.DrLicenseBrand,
                DrLicenseDevId = n.DrLicenseDevId,
                DrLicenseEngineId = n.DrLicenseEngineId,
                DrLicenseRegistrationDate = n.DrLicenseRegistrationDate,
                DrLicensePubDate = n.DrLicensePubDate,
                DrLicenseRatedUsers = n.DrLicenseRatedUsers,
                DrLicenseVehWeight = n.DrLicenseVehWeight,
                DrLicenseDevWeight = n.DrLicenseDevWeight,
                DrLicenseNetWeight = n.DrLicenseNetWeight,
                DrLicenseNetVolume = n.DrLicenseNetVolume,
                DrLicenseVehWide = n.DrLicenseVehWide,
                DrLicenseVehHigh = n.DrLicenseVehHigh,
                DrLicenseVehLong = n.DrLicenseVehLong,
                DrLicenseScrapedDate = n.DrLicenseScrapedDate,
                LoLicenseManageId = n.LoLicenseManageId,
                LoLicenseId = n.LoLicenseId,
                LoLicenseBusinessScope = n.LoLicenseBusinessScope,
                LoLicensePubDate = n.LoLicensePubDate,
                LoLicenseValidDate = n.LoLicenseValidDate,
                LoLicenseCheckDate = n.LoLicenseCheckDate,
                LoLicensePlace = n.LoLicensePlace,
                InsTrafficPolicyId = n.InsTrafficPolicyId,
                InsTrafficPolicyCompany = n.InsTrafficPolicyCompany,
                InsTrafficPolicyVaildateDate = n.InsTrafficPolicyVaildateDate,
                InsTrafficPolicyAmount = n.InsTrafficPolicyAmount,
                InsThirdPartyId = n.InsThirdPartyId,
                InsThirdPartyVaildateDate = n.InsThirdPartyVaildateDate,
                InsThirdPartyAmount = n.InsThirdPartyAmount,
                InsThirdPartyLogisticsAmount = n.InsThirdPartyLogisticsAmount,
                InsThirdPartyLogisticsVaildateDate = n.InsThirdPartyLogisticsVaildateDate,
                Status = n.Status,
                CreatedDate = n.CreatedDate,
                CreatedBy = n.CreatedBy,
                LastModifiedDate = n.LastModifiedDate,
                LastModifiedBy = n.LastModifiedBy
            }).ToList();

            var group = this._vehicleService.Queryable().GroupBy(x => x.Status).Select(x => new { Footer=true, PlateNumber = "汇总:", Status = x.Key, ExternalNo = x.Count() }).ToList();
            var pagelist = new { total = totalCount, rows = datarows, footer = group };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> GetDataByCompanyId(int companyid, int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            var totalCount = 0;
            var vehicles = await _vehicleService
                       .Query(new VehicleQuery().ByCompanyIdWithfilter(companyid, filters)).Include(v => v.Company)
                       .OrderBy(n => n.OrderBy(sort, order))
                       .SelectPageAsync(page, rows, out totalCount);
            var datarows = vehicles.Select(n => new
            {
                CompanyName = (n.Company == null ? "" : n.Company.Name),
                Id = n.Id,
                OrderId = n.OrderId,
                OrderNo = n.OrderNo,
                ExternalNo = n.ExternalNo,
                UsingDate = n.UsingDate,
                TimePeriod = n.TimePeriod,
                Location1 = n.Location1,
                Location2 = n.Location2,
                Requirements = n.Requirements,
                Packages = n.Packages,
                Weight = n.Weight,
                Volume = n.Volume,
                Cartons = n.Cartons,
                Pallets = n.Pallets,
                InputUser = n.InputUser,
                PlateNumber = n.PlateNumber,
                PlateNumberPosition = n.PlateNumberPosition,
                VehStatus = n.VehStatus,
                CarType = n.CarType,
                VehicleType = n.VehicleType,
                VehicleProperty = n.VehicleProperty,
                CompanyId = n.CompanyId,
                Axles = n.Axles,
                ECOMark = n.ECOMark,                StrLoadWeight = n.StrLoadWeight,
                LoadWeight = n.LoadWeight,
                LoadVolume = n.LoadVolume,
                CarriageSize = n.CarriageSize,
                Driver = n.Driver,
                DriverPhone = n.DriverPhone,
                AssistantDriver = n.AssistantDriver,
                AssistantDriverPhone = n.AssistantDriverPhone,
                VehLongSize = n.VehLongSize,
                CubicleType = n.CubicleType,
                VehUseType = n.VehUseType,
                CustomsNo = n.CustomsNo,
                VehUse = n.VehUse,
                AVGECON = n.AVGECON,
                AVGECONScale = n.AVGECONScale,
                RoadKM = n.RoadKM,
                RoadHours = n.RoadHours,
                RoadKMScale = n.RoadKMScale,
                GPSDeviceId = n.GPSDeviceId,
                Owner = n.Owner,
                OwnerContactPhone = n.OwnerContactPhone,
                Brand = n.Brand,
                RPM = n.RPM,
                PurchasedDate = n.PurchasedDate,
                PurchasedAmount = n.PurchasedAmount,
                VehLong = n.VehLong,
                VehWide = n.VehWide,
                VehHigh = n.VehHigh,
                VIN = n.VIN,
                ServiceLife = n.ServiceLife,
                MaintainKM = n.MaintainKM,
                MaintainDate = n.MaintainDate,
                MaintainMonth = n.MaintainMonth,
                ExistVehTailBoard = n.ExistVehTailBoard,
                VehTailBoardBrand = n.VehTailBoardBrand,
                VehTailBoardFactory = n.VehTailBoardFactory,
                VehTailBoardLife = n.VehTailBoardLife,
                VehTailBoardAmount = n.VehTailBoardAmount,
                VehTailBoardGPSDeviceId = n.VehTailBoardGPSDeviceId,
                DrLicenseModel = n.DrLicenseModel,
                DrLicenseUseNature = n.DrLicenseUseNature,
                DrLicenseBrand = n.DrLicenseBrand,                DrLicenseDevId = n.DrLicenseDevId,
                DrLicenseEngineId = n.DrLicenseEngineId,
                DrLicenseRegistrationDate = n.DrLicenseRegistrationDate,
                DrLicensePubDate = n.DrLicensePubDate,
                DrLicenseRatedUsers = n.DrLicenseRatedUsers,
                DrLicenseVehWeight = n.DrLicenseVehWeight,
                DrLicenseDevWeight = n.DrLicenseDevWeight,                DrLicenseNetWeight = n.DrLicenseNetWeight,
                DrLicenseNetVolume = n.DrLicenseNetVolume,
                DrLicenseVehWide = n.DrLicenseVehWide,
                DrLicenseVehHigh = n.DrLicenseVehHigh,
                DrLicenseVehLong = n.DrLicenseVehLong,
                DrLicenseScrapedDate = n.DrLicenseScrapedDate,
                LoLicenseManageId = n.LoLicenseManageId,
                LoLicenseId = n.LoLicenseId,
                LoLicenseBusinessScope = n.LoLicenseBusinessScope,
                LoLicensePubDate = n.LoLicensePubDate,
                LoLicenseValidDate = n.LoLicenseValidDate,
                LoLicenseCheckDate = n.LoLicenseCheckDate,
                LoLicensePlace = n.LoLicensePlace,
                InsTrafficPolicyId = n.InsTrafficPolicyId,
                InsTrafficPolicyCompany = n.InsTrafficPolicyCompany,
                InsTrafficPolicyVaildateDate = n.InsTrafficPolicyVaildateDate,
                InsTrafficPolicyAmount = n.InsTrafficPolicyAmount,
                InsThirdPartyId = n.InsThirdPartyId,
                InsThirdPartyVaildateDate = n.InsThirdPartyVaildateDate,
                InsThirdPartyAmount = n.InsThirdPartyAmount,
                InsThirdPartyLogisticsAmount = n.InsThirdPartyLogisticsAmount,
                InsThirdPartyLogisticsVaildateDate = n.InsThirdPartyLogisticsVaildateDate,
                Status = n.Status,
                CreatedDate = n.CreatedDate,
                CreatedBy = n.CreatedBy,
                LastModifiedDate = n.LastModifiedDate,
                LastModifiedBy = n.LastModifiedBy
            }).ToList();

            //统计状态
            var group = this._vehicleService.Queryable().GroupBy(x => x.Status).Select(x => new { PlateNumber = "汇总:", Status = x.Key, ExternalNo = x.Count() }).ToList() ;



            var pagelist = new { total = totalCount, rows = datarows, footer = group };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> SaveData(VehicleChangeViewModel vehicles)
        {
            if (vehicles.updated != null)
            {
                foreach (var item in vehicles.updated)
                {
                    _vehicleService.Update(item);
                }
            }
            if (vehicles.deleted != null)
            {
                foreach (var item in vehicles.deleted)
                {
                    _vehicleService.Delete(item);
                }
            }
            if (vehicles.inserted != null)
            {
                foreach (var item in vehicles.inserted)
                {
                    _vehicleService.Insert(item);
                }
            }
            await _unitOfWork.SaveChangesAsync();
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }
        //[OutputCache(Duration = 360, VaryByParam = "none")]
        public async Task<JsonResult> GetCompanies(string q = "")
        {
            var companyRepository = _unitOfWork.RepositoryAsync<Company>();
            var data = await companyRepository.Queryable().Where(n => n.Name.Contains(q)).ToListAsync();
            var rows = data.Select(n => new { Id = n.Id, Name = n.Name });
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
        // GET: Vehicles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicle = await _vehicleService.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }
        // GET: Vehicles/Create
        public ActionResult Create()
        {
            var vehicle = new Vehicle();
            //set default value
            var companyRepository = _unitOfWork.RepositoryAsync<Company>();
            ViewBag.CompanyId = new SelectList(companyRepository.Queryable(), "Id", "Name");
            return View(vehicle);
        }
        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Company,Id,OrderNo,ExternalNo,UsingDate,Location1,Location2,Requirements,PlateNumber,PlateNumberPosition,VehStatus,CarType,VehicleType,VehicleProperty,CompanyId,Axles,ECOMark,StrLoadWeight,LoadWeight,LoadVolume,CarriageSize,Driver,DriverPhone,AssistantDriver,AssistantDriverPhone,VehLongSize,CubicleType,VehUseType,CustomsNo,VehUse,AVGECON,AVGECONScale,RoadKM,RoadHours,RoadKMScale,GPSDeviceId,Owner,OwnerContactPhone,Brand,RPM,PurchasedDate,PurchasedAmount,VehLong,VehWide,VehHigh,VIN,ServiceLife,MaintainKM,MaintainDate,MaintainMonth,ExistVehTailBoard,VehTailBoardBrand,VehTailBoardFactory,VehTailBoardLife,VehTailBoardAmount,VehTailBoardGPSDeviceId,DrLicenseModel,DrLicenseUseNature,DrLicenseBrand,DrLicenseDevId,DrLicenseEngineId,DrLicenseRegistrationDate,DrLicensePubDate,DrLicenseRatedUsers,DrLicenseVehWeight,DrLicenseDevWeight,DrLicenseNetWeight,DrLicenseNetVolume,DrLicenseVehWide,DrLicenseVehHigh,DrLicenseVehLong,DrLicenseScrapedDate,LoLicenseManageId,LoLicenseId,LoLicenseBusinessScope,LoLicensePubDate,LoLicenseValidDate,LoLicenseCheckDate,LoLicensePlace,InsTrafficPolicyId,InsTrafficPolicyCompany,InsTrafficPolicyVaildateDate,InsTrafficPolicyAmount,InsThirdPartyId,InsThirdPartyVaildateDate,InsThirdPartyAmount,InsThirdPartyLogisticsAmount,InsThirdPartyLogisticsVaildateDate,Status,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.Insert(vehicle);
                await _unitOfWork.SaveChangesAsync();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has append a Vehicle record");
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
            var companyRepository = _unitOfWork.RepositoryAsync<Company>();
            ViewBag.CompanyId = new SelectList(await companyRepository.Queryable().ToListAsync(), "Id", "Name", vehicle.CompanyId);
            return View(vehicle);
        }
        // GET: Vehicles/PopupEdit/5
        //[OutputCache(Duration = 360, VaryByParam = "id")]
        public async Task<JsonResult> PopupEdit(int? id)
        {

            var vehicle = await _vehicleService.FindAsync(id);
            return Json(vehicle, JsonRequestBehavior.AllowGet);
        }

        // GET: Vehicles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicle = await _vehicleService.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            var companyRepository = _unitOfWork.RepositoryAsync<Company>();
            ViewBag.CompanyId = new SelectList(companyRepository.Queryable(), "Id", "Name", vehicle.CompanyId);
            return View(vehicle);
        }
        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Company,Id,OrderNo,ExternalNo,UsingDate,Location1,Location2,Requirements,PlateNumber,PlateNumberPosition,VehStatus,CarType,VehicleType,VehicleProperty,CompanyId,Axles,ECOMark,StrLoadWeight,LoadWeight,LoadVolume,CarriageSize,Driver,DriverPhone,AssistantDriver,AssistantDriverPhone,VehLongSize,CubicleType,VehUseType,CustomsNo,VehUse,AVGECON,AVGECONScale,RoadKM,RoadHours,RoadKMScale,GPSDeviceId,Owner,OwnerContactPhone,Brand,RPM,PurchasedDate,PurchasedAmount,VehLong,VehWide,VehHigh,VIN,ServiceLife,MaintainKM,MaintainDate,MaintainMonth,ExistVehTailBoard,VehTailBoardBrand,VehTailBoardFactory,VehTailBoardLife,VehTailBoardAmount,VehTailBoardGPSDeviceId,DrLicenseModel,DrLicenseUseNature,DrLicenseBrand,DrLicenseDevId,DrLicenseEngineId,DrLicenseRegistrationDate,DrLicensePubDate,DrLicenseRatedUsers,DrLicenseVehWeight,DrLicenseDevWeight,DrLicenseNetWeight,DrLicenseNetVolume,DrLicenseVehWide,DrLicenseVehHigh,DrLicenseVehLong,DrLicenseScrapedDate,LoLicenseManageId,LoLicenseId,LoLicenseBusinessScope,LoLicensePubDate,LoLicenseValidDate,LoLicenseCheckDate,LoLicensePlace,InsTrafficPolicyId,InsTrafficPolicyCompany,InsTrafficPolicyVaildateDate,InsTrafficPolicyAmount,InsThirdPartyId,InsThirdPartyVaildateDate,InsThirdPartyAmount,InsThirdPartyLogisticsAmount,InsThirdPartyLogisticsVaildateDate,Status,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.ObjectState = ObjectState.Modified;
                _vehicleService.Update(vehicle);
                await _unitOfWork.SaveChangesAsync();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has update a Vehicle record");
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
            var companyRepository = _unitOfWork.RepositoryAsync<Company>();
            ViewBag.CompanyId = new SelectList(await companyRepository.Queryable().ToListAsync(), "Id", "Name", vehicle.CompanyId);
            return View(vehicle);
        }
        // GET: Vehicles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicle = await _vehicleService.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }
        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _vehicleService.FindAsync(id);
            _vehicleService.Delete(vehicle);
            await _unitOfWork.SaveChangesAsync();
            if (Request.IsAjaxRequest())
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            DisplaySuccessMessage("Has delete a Vehicle record");
            return RedirectToAction("Index");
        }


        //导出Excel
        [HttpPost]
        public ActionResult ExportExcel(string filterRules = "", string sort = "Id", string order = "asc")
        {
            var fileName = "vehicles_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            var stream = _vehicleService.ExportExcel(filterRules, sort, order);
            return File(stream, "application/vnd.ms-excel", fileName);
        }
        //导出Excel
        [HttpPost]
        public ActionResult OrderExportExcel(string filterRules = "", string sort = "Id", string order = "asc")
        {
            var fileName = "vehicles_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            var stream = _vehicleService.OrderExportExcel(filterRules, sort, order);
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
