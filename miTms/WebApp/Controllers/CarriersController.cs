/// <summary>
/// Provides functionality to the /Carrier/ route.
/// <date> 5/30/2018 9:43:50 AM </date>
/// Create By SmartCode MVC5 Scaffolder for Visual Studio
/// TODO: RegisterType UnityConfig.cs
/// container.RegisterType<IRepositoryAsync<Carrier>, Repository<Carrier>>();
/// container.RegisterType<ICarrierService, CarrierService>();
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
	public class CarriersController : Controller
	{
		//private StoreContext db = new StoreContext();
		private readonly ICarrierService  _carrierService;
		private readonly IUnitOfWorkAsync _unitOfWork;
		public CarriersController (ICarrierService  carrierService, IUnitOfWorkAsync unitOfWork)
		{
			_carrierService  = carrierService;
			_unitOfWork = unitOfWork;
		}
        		// GET: Carriers/Index
        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public ActionResult Index()
		{
			 return View();
		}
		// Get :Carriers/PageList
		// For Index View Boostrap-Table load  data 
		[HttpGet]
				 public async Task<JsonResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
				{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
			//int pagenum = offset / limit +1;
											var carriers  = await _carrierService
						               .Query(new CarrierQuery().Withfilter(filters)).Include(c => c.Company)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
										var datarows = carriers .Select(  n => new { 

    CompanyName = (n.Company==null?"": n.Company.Name) ,
    Id = n.Id,
    Name = n.Name,
    Type = n.Type,
    ContactName = n.ContactName,
    ContactMobileTelephoneNumber = n.ContactMobileTelephoneNumber,
    RegisteredAddress = n.RegisteredAddress,
    PermitNumber = n.PermitNumber,
    CountrySubdivisionCode = n.CountrySubdivisionCode,
    RegisteredCapital = n.RegisteredCapital,
    UnifiedSocialCreditldentifier = n.UnifiedSocialCreditldentifier,
    BusinessScope = n.BusinessScope,
    Description = n.Description,
    LogoPicture = n.LogoPicture,
    CompanyId = n.CompanyId,
    RegistrationDatetime = n.RegistrationDatetime,
    UpdateTimeDatetime = n.UpdateTimeDatetime,
    IsBlaclkList = n.IsBlaclkList,
    IsDeleteFlag = n.IsDeleteFlag,
    SynchronizationTime = n.SynchronizationTime,
    IsException = n.IsException,
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
            			    var carriers  = await _carrierService
						               .Query(new CarrierQuery().ByCompanyIdWithfilter(companyid,filters)).Include(c => c.Company)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = carriers .Select(  n => new { 

    CompanyName = (n.Company==null?"": n.Company.Name) ,
    Id = n.Id,
    Name = n.Name,
    Type = n.Type,
    ContactName = n.ContactName,
    ContactMobileTelephoneNumber = n.ContactMobileTelephoneNumber,
    RegisteredAddress = n.RegisteredAddress,
    PermitNumber = n.PermitNumber,
    CountrySubdivisionCode = n.CountrySubdivisionCode,
    RegisteredCapital = n.RegisteredCapital,
    UnifiedSocialCreditldentifier = n.UnifiedSocialCreditldentifier,
    BusinessScope = n.BusinessScope,
    Description = n.Description,
    LogoPicture = n.LogoPicture,
    CompanyId = n.CompanyId,
    RegistrationDatetime = n.RegistrationDatetime,
    UpdateTimeDatetime = n.UpdateTimeDatetime,
    IsBlaclkList = n.IsBlaclkList,
    IsDeleteFlag = n.IsDeleteFlag,
    SynchronizationTime = n.SynchronizationTime,
    IsException = n.IsException,
    CreatedDate = n.CreatedDate,
    CreatedBy = n.CreatedBy,
    LastModifiedDate = n.LastModifiedDate,
    LastModifiedBy = n.LastModifiedBy
}).ToList();
			var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
        		[HttpPost]
				public async Task<JsonResult> SaveData(CarrierChangeViewModel carriers)
		{
			if (carriers.updated != null)
			{
				foreach (var item in carriers.updated)
				{
					_carrierService.Update(item);
				}
			}
			if (carriers.deleted != null)
			{
				foreach (var item in carriers.deleted)
				{
					_carrierService.Delete(item);
				}
			}
			if (carriers.inserted != null)
			{
				foreach (var item in carriers.inserted)
				{
					_carrierService.Insert(item);
				}
			}
			await _unitOfWork.SaveChangesAsync();
			return Json(new {Success=true}, JsonRequestBehavior.AllowGet);
		}
						        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public async Task<JsonResult> GetCompanies(string q="")
		{
			var companyRepository = _unitOfWork.RepositoryAsync<Company>();
			var data = await companyRepository.Queryable().Where(n=>n.Name.Contains(q)).ToListAsync();
			var rows = data.Select(n => new { Id = n.Id, Name = n.Name });
			return Json(rows, JsonRequestBehavior.AllowGet);
		}
								// GET: Carriers/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var  carrier = await _carrierService.FindAsync(id);
			if (carrier == null)
			{
				return HttpNotFound();
			}
			return View(carrier);
		}
		// GET: Carriers/Create
        		public ActionResult Create()
				{
			var carrier = new Carrier();
			//set default value
			var companyRepository = _unitOfWork.RepositoryAsync<Company>();
		   			ViewBag.CompanyId = new SelectList(companyRepository.Queryable(), "Id", "Name");
		   			return View(carrier);
		}
		// POST: Carriers/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "Company,Id,Name,Type,ContactName,ContactMobileTelephoneNumber,RegisteredAddress,PermitNumber,CountrySubdivisionCode,RegisteredCapital,UnifiedSocialCreditldentifier,BusinessScope,Description,LogoPicture,CompanyId,RegistrationDatetime,UpdateTimeDatetime,IsBlaclkList,IsDeleteFlag,SynchronizationTime,IsException,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Carrier carrier)
		{
			if (ModelState.IsValid)
			{
			 				_carrierService.Insert(carrier);
		   				await _unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has append a Carrier record");
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
						var companyRepository = _unitOfWork.RepositoryAsync<Company>();
						ViewBag.CompanyId = new SelectList(await companyRepository.Queryable().ToListAsync(), "Id", "Name", carrier.CompanyId);
									return View(carrier);
		}
        // GET: Carriers/PopupEdit/5
        //[OutputCache(Duration = 360, VaryByParam = "id")]
		public async Task<JsonResult> PopupEdit(int? id)
		{
			
			var carrier = await _carrierService.FindAsync(id);
			return Json(carrier,JsonRequestBehavior.AllowGet);
		}

		// GET: Carriers/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var carrier = await _carrierService.FindAsync(id);
			if (carrier == null)
			{
				return HttpNotFound();
			}
			var companyRepository = _unitOfWork.RepositoryAsync<Company>();
			ViewBag.CompanyId = new SelectList(companyRepository.Queryable(), "Id", "Name", carrier.CompanyId);
			return View(carrier);
		}
		// POST: Carriers/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "Company,Id,Name,Type,ContactName,ContactMobileTelephoneNumber,RegisteredAddress,PermitNumber,CountrySubdivisionCode,RegisteredCapital,UnifiedSocialCreditldentifier,BusinessScope,Description,LogoPicture,CompanyId,RegistrationDatetime,UpdateTimeDatetime,IsBlaclkList,IsDeleteFlag,SynchronizationTime,IsException,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Carrier carrier)
		{
			if (ModelState.IsValid)
			{
				carrier.TrackingState = TrackingState.Modified;
								_carrierService.Update(carrier);
								await   _unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has update a Carrier record");
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
						var companyRepository = _unitOfWork.RepositoryAsync<Company>();
						ViewBag.CompanyId = new SelectList( await companyRepository.Queryable().ToListAsync(), "Id", "Name", carrier.CompanyId);
									return View(carrier);
		}
		// GET: Carriers/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var carrier = await _carrierService.FindAsync(id);
			if (carrier == null)
			{
				return HttpNotFound();
			}
			return View(carrier);
		}
		// POST: Carriers/Delete/5
		[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var carrier = await  _carrierService.FindAsync(id);
			 _carrierService.Delete(carrier);
			await _unitOfWork.SaveChangesAsync();
		   if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
			DisplaySuccessMessage("Has delete a Carrier record");
			return RedirectToAction("Index");
		}
       
 
		//导出Excel
		[HttpPost]
		public ActionResult ExportExcel( string filterRules = "",string sort = "Id", string order = "asc")
		{
			var fileName = "carriers_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream=  _carrierService.ExportExcel(filterRules,sort, order );
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
