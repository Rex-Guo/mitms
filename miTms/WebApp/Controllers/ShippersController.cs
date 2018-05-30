/// <summary>
/// Provides functionality to the /Shipper/ route.
/// <date> 5/30/2018 9:44:43 AM </date>
/// Create By SmartCode MVC5 Scaffolder for Visual Studio
/// TODO: RegisterType UnityConfig.cs
/// container.RegisterType<IRepositoryAsync<Shipper>, Repository<Shipper>>();
/// container.RegisterType<IShipperService, ShipperService>();
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
	public class ShippersController : Controller
	{
		//private StoreContext db = new StoreContext();
		private readonly IShipperService  _shipperService;
		private readonly IUnitOfWorkAsync _unitOfWork;
		public ShippersController (IShipperService  shipperService, IUnitOfWorkAsync unitOfWork)
		{
			_shipperService  = shipperService;
			_unitOfWork = unitOfWork;
		}
        		// GET: Shippers/Index
        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public ActionResult Index()
		{
			 return View();
		}
		// Get :Shippers/PageList
		// For Index View Boostrap-Table load  data 
		[HttpGet]
				 public async Task<JsonResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
				{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
			//int pagenum = offset / limit +1;
											var shippers  = await _shipperService
						               .Query(new ShipperQuery().Withfilter(filters)).Include(s => s.Company)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
										var datarows = shippers .Select(  n => new { 

    CompanyName = (n.Company==null?"": n.Company.Name) ,
    Id = n.Id,
    Name = n.Name,
    Type = n.Type,
    ContactName = n.ContactName,
    ContactIdCard = n.ContactIdCard,
    ContactMobileTelephoneNumber = n.ContactMobileTelephoneNumber,
    RegisteredAddress = n.RegisteredAddress,
    RegisteredCapital = n.RegisteredCapital,
    UnifiedSocialCreditldentifier = n.UnifiedSocialCreditldentifier,
    UnifiedsocialDatetime = n.UnifiedsocialDatetime,
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
            			    var shippers  = await _shipperService
						               .Query(new ShipperQuery().ByCompanyIdWithfilter(companyid,filters)).Include(s => s.Company)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = shippers .Select(  n => new { 

    CompanyName = (n.Company==null?"": n.Company.Name) ,
    Id = n.Id,
    Name = n.Name,
    Type = n.Type,
    ContactName = n.ContactName,
    ContactIdCard = n.ContactIdCard,
    ContactMobileTelephoneNumber = n.ContactMobileTelephoneNumber,
    RegisteredAddress = n.RegisteredAddress,
    RegisteredCapital = n.RegisteredCapital,
    UnifiedSocialCreditldentifier = n.UnifiedSocialCreditldentifier,
    UnifiedsocialDatetime = n.UnifiedsocialDatetime,
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
				public async Task<JsonResult> SaveData(ShipperChangeViewModel shippers)
		{
			if (shippers.updated != null)
			{
				foreach (var item in shippers.updated)
				{
					_shipperService.Update(item);
				}
			}
			if (shippers.deleted != null)
			{
				foreach (var item in shippers.deleted)
				{
					_shipperService.Delete(item);
				}
			}
			if (shippers.inserted != null)
			{
				foreach (var item in shippers.inserted)
				{
					_shipperService.Insert(item);
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
								// GET: Shippers/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var  shipper = await _shipperService.FindAsync(id);
			if (shipper == null)
			{
				return HttpNotFound();
			}
			return View(shipper);
		}
		// GET: Shippers/Create
        		public ActionResult Create()
				{
			var shipper = new Shipper();
			//set default value
			var companyRepository = _unitOfWork.RepositoryAsync<Company>();
		   			ViewBag.CompanyId = new SelectList(companyRepository.Queryable(), "Id", "Name");
		   			return View(shipper);
		}
		// POST: Shippers/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "Company,Id,Name,Type,ContactName,ContactIdCard,ContactMobileTelephoneNumber,RegisteredAddress,RegisteredCapital,UnifiedSocialCreditldentifier,UnifiedsocialDatetime,Description,LogoPicture,CompanyId,RegistrationDatetime,UpdateTimeDatetime,IsBlaclkList,IsDeleteFlag,SynchronizationTime,IsException,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Shipper shipper)
		{
			if (ModelState.IsValid)
			{
			 				_shipperService.Insert(shipper);
		   				await _unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has append a Shipper record");
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
						ViewBag.CompanyId = new SelectList(await companyRepository.Queryable().ToListAsync(), "Id", "Name", shipper.CompanyId);
									return View(shipper);
		}
        // GET: Shippers/PopupEdit/5
        //[OutputCache(Duration = 360, VaryByParam = "id")]
		public async Task<JsonResult> PopupEdit(int? id)
		{
			
			var shipper = await _shipperService.FindAsync(id);
			return Json(shipper,JsonRequestBehavior.AllowGet);
		}

		// GET: Shippers/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var shipper = await _shipperService.FindAsync(id);
			if (shipper == null)
			{
				return HttpNotFound();
			}
			var companyRepository = _unitOfWork.RepositoryAsync<Company>();
			ViewBag.CompanyId = new SelectList(companyRepository.Queryable(), "Id", "Name", shipper.CompanyId);
			return View(shipper);
		}
		// POST: Shippers/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "Company,Id,Name,Type,ContactName,ContactIdCard,ContactMobileTelephoneNumber,RegisteredAddress,RegisteredCapital,UnifiedSocialCreditldentifier,UnifiedsocialDatetime,Description,LogoPicture,CompanyId,RegistrationDatetime,UpdateTimeDatetime,IsBlaclkList,IsDeleteFlag,SynchronizationTime,IsException,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Shipper shipper)
		{
			if (ModelState.IsValid)
			{
				shipper.TrackingState = TrackingState.Modified;
								_shipperService.Update(shipper);
								await   _unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has update a Shipper record");
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
						ViewBag.CompanyId = new SelectList( await companyRepository.Queryable().ToListAsync(), "Id", "Name", shipper.CompanyId);
									return View(shipper);
		}
		// GET: Shippers/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var shipper = await _shipperService.FindAsync(id);
			if (shipper == null)
			{
				return HttpNotFound();
			}
			return View(shipper);
		}
		// POST: Shippers/Delete/5
		[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var shipper = await  _shipperService.FindAsync(id);
			 _shipperService.Delete(shipper);
			await _unitOfWork.SaveChangesAsync();
		   if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
			DisplaySuccessMessage("Has delete a Shipper record");
			return RedirectToAction("Index");
		}
       
 
		//导出Excel
		[HttpPost]
		public ActionResult ExportExcel( string filterRules = "",string sort = "Id", string order = "asc")
		{
			var fileName = "shippers_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream=  _shipperService.ExportExcel(filterRules,sort, order );
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
