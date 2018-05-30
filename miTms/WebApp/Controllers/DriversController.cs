/// <summary>
/// Provides functionality to the /Driver/ route.
/// <date> 5/30/2018 9:35:57 AM </date>
/// Create By SmartCode MVC5 Scaffolder for Visual Studio
/// TODO: RegisterType UnityConfig.cs
/// container.RegisterType<IRepositoryAsync<Driver>, Repository<Driver>>();
/// container.RegisterType<IDriverService, DriverService>();
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
	public class DriversController : Controller
	{
		//private StoreContext db = new StoreContext();
		private readonly IDriverService  _driverService;
		private readonly IUnitOfWorkAsync _unitOfWork;
		public DriversController (IDriverService  driverService, IUnitOfWorkAsync unitOfWork)
		{
			_driverService  = driverService;
			_unitOfWork = unitOfWork;
		}
        		// GET: Drivers/Index
        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public ActionResult Index()
		{
			 return View();
		}
		// Get :Drivers/PageList
		// For Index View Boostrap-Table load  data 
		[HttpGet]
				 public async Task<JsonResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
				{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
			//int pagenum = offset / limit +1;
											var drivers  = await _driverService
						               .Query(new DriverQuery().Withfilter(filters)).Include(d => d.Carrier).Include(d => d.Company)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
										var datarows = drivers .Select(  n => new { 

    CarrierName = (n.Carrier==null?"": n.Carrier.Name) ,
    CompanyName = (n.Company==null?"": n.Company.Name) ,
    Id = n.Id,
    Name = n.Name,
    Gender = n.Gender,
    IdentityDocumentNumber = n.IdentityDocumentNumber,
    MobileTelephoneNumber = n.MobileTelephoneNumber,
    TelephoneNumber = n.TelephoneNumber,
    QualificationCertificateNumber = n.QualificationCertificateNumber,
    Remark = n.Remark,
    Carrierid = n.Carrierid,
    RegistrationDatetime = n.RegistrationDatetime,
    UpdateTimeDatetime = n.UpdateTimeDatetime,
    IsBlaclkList = n.IsBlaclkList,
    IsDeleteFlag = n.IsDeleteFlag,
    SynchronizationTime = n.SynchronizationTime,
    IsException = n.IsException,
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
        public async Task<ActionResult> GetDataByCarrierid (int  carrierid ,int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {    
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
            			    var drivers  = await _driverService
						               .Query(new DriverQuery().ByCarrieridWithfilter(carrierid,filters)).Include(d => d.Carrier).Include(d => d.Company)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = drivers .Select(  n => new { 

    CarrierName = (n.Carrier==null?"": n.Carrier.Name) ,
    CompanyName = (n.Company==null?"": n.Company.Name) ,
    Id = n.Id,
    Name = n.Name,
    Gender = n.Gender,
    IdentityDocumentNumber = n.IdentityDocumentNumber,
    MobileTelephoneNumber = n.MobileTelephoneNumber,
    TelephoneNumber = n.TelephoneNumber,
    QualificationCertificateNumber = n.QualificationCertificateNumber,
    Remark = n.Remark,
    Carrierid = n.Carrierid,
    RegistrationDatetime = n.RegistrationDatetime,
    UpdateTimeDatetime = n.UpdateTimeDatetime,
    IsBlaclkList = n.IsBlaclkList,
    IsDeleteFlag = n.IsDeleteFlag,
    SynchronizationTime = n.SynchronizationTime,
    IsException = n.IsException,
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
            			    var drivers  = await _driverService
						               .Query(new DriverQuery().ByCompanyIdWithfilter(companyid,filters)).Include(d => d.Carrier).Include(d => d.Company)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = drivers .Select(  n => new { 

    CarrierName = (n.Carrier==null?"": n.Carrier.Name) ,
    CompanyName = (n.Company==null?"": n.Company.Name) ,
    Id = n.Id,
    Name = n.Name,
    Gender = n.Gender,
    IdentityDocumentNumber = n.IdentityDocumentNumber,
    MobileTelephoneNumber = n.MobileTelephoneNumber,
    TelephoneNumber = n.TelephoneNumber,
    QualificationCertificateNumber = n.QualificationCertificateNumber,
    Remark = n.Remark,
    Carrierid = n.Carrierid,
    RegistrationDatetime = n.RegistrationDatetime,
    UpdateTimeDatetime = n.UpdateTimeDatetime,
    IsBlaclkList = n.IsBlaclkList,
    IsDeleteFlag = n.IsDeleteFlag,
    SynchronizationTime = n.SynchronizationTime,
    IsException = n.IsException,
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
				public async Task<JsonResult> SaveData(DriverChangeViewModel drivers)
		{
			if (drivers.updated != null)
			{
				foreach (var item in drivers.updated)
				{
					_driverService.Update(item);
				}
			}
			if (drivers.deleted != null)
			{
				foreach (var item in drivers.deleted)
				{
					_driverService.Delete(item);
				}
			}
			if (drivers.inserted != null)
			{
				foreach (var item in drivers.inserted)
				{
					_driverService.Insert(item);
				}
			}
			await _unitOfWork.SaveChangesAsync();
			return Json(new {Success=true}, JsonRequestBehavior.AllowGet);
		}
						        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public async Task<JsonResult> GetCarriers(string q="")
		{
			var carrierRepository = _unitOfWork.RepositoryAsync<Carrier>();
			var data = await carrierRepository.Queryable().Where(n=>n.Name.Contains(q)).ToListAsync();
			var rows = data.Select(n => new { Id = n.Id, Name = n.Name });
			return Json(rows, JsonRequestBehavior.AllowGet);
		}
						        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public async Task<JsonResult> GetCompanies(string q="")
		{
			var companyRepository = _unitOfWork.RepositoryAsync<Company>();
			var data = await companyRepository.Queryable().Where(n=>n.Name.Contains(q)).ToListAsync();
			var rows = data.Select(n => new { Id = n.Id, Name = n.Name });
			return Json(rows, JsonRequestBehavior.AllowGet);
		}
								// GET: Drivers/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var  driver = await _driverService.FindAsync(id);
			if (driver == null)
			{
				return HttpNotFound();
			}
			return View(driver);
		}
		// GET: Drivers/Create
        		public ActionResult Create()
				{
			var driver = new Driver();
			//set default value
			var carrierRepository = _unitOfWork.RepositoryAsync<Carrier>();
		   			ViewBag.Carrierid = new SelectList(carrierRepository.Queryable(), "Id", "Name");
		   			var companyRepository = _unitOfWork.RepositoryAsync<Company>();
		   			ViewBag.CompanyId = new SelectList(companyRepository.Queryable(), "Id", "Name");
		   			return View(driver);
		}
		// POST: Drivers/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "Carrier,Company,Id,Name,Gender,IdentityDocumentNumber,MobileTelephoneNumber,TelephoneNumber,QualificationCertificateNumber,Remark,Carrierid,RegistrationDatetime,UpdateTimeDatetime,IsBlaclkList,IsDeleteFlag,SynchronizationTime,IsException,CompanyId,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Driver driver)
		{
			if (ModelState.IsValid)
			{
			 				_driverService.Insert(driver);
		   				await _unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has append a Driver record");
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
						var carrierRepository = _unitOfWork.RepositoryAsync<Carrier>();
						ViewBag.Carrierid = new SelectList(await carrierRepository.Queryable().ToListAsync(), "Id", "Name", driver.Carrierid);
									var companyRepository = _unitOfWork.RepositoryAsync<Company>();
						ViewBag.CompanyId = new SelectList(await companyRepository.Queryable().ToListAsync(), "Id", "Name", driver.CompanyId);
									return View(driver);
		}
        // GET: Drivers/PopupEdit/5
        //[OutputCache(Duration = 360, VaryByParam = "id")]
		public async Task<JsonResult> PopupEdit(int? id)
		{
			
			var driver = await _driverService.FindAsync(id);
			return Json(driver,JsonRequestBehavior.AllowGet);
		}

		// GET: Drivers/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var driver = await _driverService.FindAsync(id);
			if (driver == null)
			{
				return HttpNotFound();
			}
			var carrierRepository = _unitOfWork.RepositoryAsync<Carrier>();
			ViewBag.Carrierid = new SelectList(carrierRepository.Queryable(), "Id", "Name", driver.Carrierid);
			var companyRepository = _unitOfWork.RepositoryAsync<Company>();
			ViewBag.CompanyId = new SelectList(companyRepository.Queryable(), "Id", "Name", driver.CompanyId);
			return View(driver);
		}
		// POST: Drivers/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "Carrier,Company,Id,Name,Gender,IdentityDocumentNumber,MobileTelephoneNumber,TelephoneNumber,QualificationCertificateNumber,Remark,Carrierid,RegistrationDatetime,UpdateTimeDatetime,IsBlaclkList,IsDeleteFlag,SynchronizationTime,IsException,CompanyId,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Driver driver)
		{
			if (ModelState.IsValid)
			{
				driver.TrackingState = TrackingState.Modified;
								_driverService.Update(driver);
								await   _unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has update a Driver record");
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
						var carrierRepository = _unitOfWork.RepositoryAsync<Carrier>();
						ViewBag.Carrierid = new SelectList( await carrierRepository.Queryable().ToListAsync(), "Id", "Name", driver.Carrierid);
									var companyRepository = _unitOfWork.RepositoryAsync<Company>();
						ViewBag.CompanyId = new SelectList( await companyRepository.Queryable().ToListAsync(), "Id", "Name", driver.CompanyId);
									return View(driver);
		}
		// GET: Drivers/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var driver = await _driverService.FindAsync(id);
			if (driver == null)
			{
				return HttpNotFound();
			}
			return View(driver);
		}
		// POST: Drivers/Delete/5
		[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var driver = await  _driverService.FindAsync(id);
			 _driverService.Delete(driver);
			await _unitOfWork.SaveChangesAsync();
		   if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
			DisplaySuccessMessage("Has delete a Driver record");
			return RedirectToAction("Index");
		}
       
 
		//导出Excel
		[HttpPost]
		public ActionResult ExportExcel( string filterRules = "",string sort = "Id", string order = "asc")
		{
			var fileName = "drivers_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream=  _driverService.ExportExcel(filterRules,sort, order );
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
