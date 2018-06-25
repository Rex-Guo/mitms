/// <summary>
/// Provides functionality to the /LineQuotes/ route.
/// <date> 2018/6/8 7:56:14 </date>
/// Create By SmartCode MVC5 Scaffolder for Visual Studio
/// TODO: RegisterType UnityConfig.cs
/// container.RegisterType<IRepositoryAsync<LineQuotes>, Repository<LineQuotes>>();
/// container.RegisterType<ILineQuotesService, LineQuotesService>();
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
	public class LineQuotesesController : Controller
	{
		private readonly ILineQuotesService  lineQuotesService;
		private readonly IUnitOfWorkAsync unitOfWork;
		public LineQuotesesController (ILineQuotesService  lineQuotesService, IUnitOfWorkAsync unitOfWork)
		{
			this.lineQuotesService  = lineQuotesService;
			this.unitOfWork = unitOfWork;
		}
        		// GET: LineQuoteses/Index
        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public ActionResult Index()
		{
			 return View();
		}
		// Get :LineQuoteses/PageList
		// For Index View Boostrap-Table load  data 
		[HttpGet]
				 public async Task<JsonResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
				{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
			//int pagenum = offset / limit +1;
											var linequotes  = await this.lineQuotesService
						               .Query(new LineQuotesQuery().Withfilter(filters)).Include(l => l.Carrier).Include(l => l.Company)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
										var datarows = linequotes .Select(  n => new { 

    CarrierName = (n.Carrier==null?"": n.Carrier.Name) ,
    CompanyName = (n.Company==null?"": n.Company.Name) ,
    Id = n.Id,
    Name = n.Name,
    Location1 = n.Location1,
    Location2 = n.Location2,
    TimePeriod = n.TimePeriod,
    PiceVehicleType = n.PiceVehicleType,
    PiceType = n.PiceType,
    Price = n.Price,
    Remark = n.Remark,
    Description = n.Description,
    InputUser = n.InputUser,
    CarrierId = n.CarrierId,
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
            			    var linequotes  = await this.lineQuotesService
						               .Query(new LineQuotesQuery().ByCarrierIdWithfilter(carrierid,filters)).Include(l => l.Carrier).Include(l => l.Company)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = linequotes .Select(  n => new { 

    CarrierName = (n.Carrier==null?"": n.Carrier.Name) ,
    CompanyName = (n.Company==null?"": n.Company.Name) ,
    Id = n.Id,
    Name = n.Name,
    Location1 = n.Location1,
    Location2 = n.Location2,
    TimePeriod = n.TimePeriod,
    PiceVehicleType = n.PiceVehicleType,
    PiceType = n.PiceType,
    Price = n.Price,
    Remark = n.Remark,
    Description = n.Description,
    InputUser = n.InputUser,
    CarrierId = n.CarrierId,
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
            			    var linequotes  = await this.lineQuotesService
						               .Query(new LineQuotesQuery().ByCompanyIdWithfilter(companyid,filters)).Include(l => l.Carrier).Include(l => l.Company)
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
				            var datarows = linequotes .Select(  n => new { 

    CarrierName = (n.Carrier==null?"": n.Carrier.Name) ,
    CompanyName = (n.Company==null?"": n.Company.Name) ,
    Id = n.Id,
    Name = n.Name,
    Location1 = n.Location1,
    Location2 = n.Location2,
    TimePeriod = n.TimePeriod,
    PiceVehicleType = n.PiceVehicleType,
    PiceType = n.PiceType,
    Price = n.Price,
    Remark = n.Remark,
    Description = n.Description,
    InputUser = n.InputUser,
    CarrierId = n.CarrierId,
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
				public async Task<JsonResult> SaveData(LineQuotesChangeViewModel linequotes)
		{
			if (linequotes.updated != null)
			{
				foreach (var item in linequotes.updated)
				{
					this.lineQuotesService.Update(item);
				}
			}
			if (linequotes.deleted != null)
			{
				foreach (var item in linequotes.deleted)
				{
					this.lineQuotesService.Delete(item);
				}
			}
			if (linequotes.inserted != null)
			{
				foreach (var item in linequotes.inserted)
				{
					this.lineQuotesService.Insert(item);
				}
			}
            try
            {
                await this.unitOfWork.SaveChangesAsync();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e) {
                return Json(new { success = false,err=e.Message }, JsonRequestBehavior.AllowGet);
            }
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
			var data = await companyRepository.Queryable().Where(n=>n.Name.Contains(q)).OrderBy(n => n.Name).ToListAsync();
			var rows = data.Select(n => new { Id = n.Id, Name = n.Name });
			return Json(rows, JsonRequestBehavior.AllowGet);
		}
								// GET: LineQuoteses/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var  lineQuotes = await this.lineQuotesService.FindAsync(id);
			if (lineQuotes == null)
			{
				return HttpNotFound();
			}
			return View(lineQuotes);
		}
		// GET: LineQuoteses/Create
        		public ActionResult Create()
				{
			var lineQuotes = new LineQuotes();
			//set default value
			var carrierRepository = this.unitOfWork.RepositoryAsync<Carrier>();
		   			ViewBag.CarrierId = new SelectList(carrierRepository.Queryable().OrderBy(n=>n.Name), "Id", "Name");
		   			var companyRepository = this.unitOfWork.RepositoryAsync<Company>();
		   			ViewBag.CompanyId = new SelectList(companyRepository.Queryable().OrderBy(n => n.Name), "Id", "Name");
		   			return View(lineQuotes);
		}
        // POST: LineQuoteses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Carrier,Company,Id,Name,Location1,Location2,TimePeriod,PiceVehicleType,PiceType,Price,Remark,Description,InputUser,CarrierId,CompanyId,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] LineQuotes lineQuotes)
        {
            if (ModelState.IsValid)
            {
                lineQuotesService.Insert(lineQuotes);
                await this.unitOfWork.SaveChangesAsync();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has append a LineQuotes record");
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
            var carrierRepository = this.unitOfWork.RepositoryAsync<Carrier>();
            ViewBag.CarrierId = new SelectList(await carrierRepository.Queryable().OrderBy(n=>n.Name).ToListAsync(), "Id", "Name", lineQuotes.CarrierId);
            var companyRepository = this.unitOfWork.RepositoryAsync<Company>();
            ViewBag.CompanyId = new SelectList(await companyRepository.Queryable().OrderBy(n => n.Name).ToListAsync(), "Id", "Name", lineQuotes.CompanyId);
            return View(lineQuotes);
        }
        // GET: LineQuoteses/PopupEdit/5
        //[OutputCache(Duration = 360, VaryByParam = "id")]
		public async Task<JsonResult> PopupEdit(int? id)
		{
			
			var lineQuotes = await this.lineQuotesService.FindAsync(id);
			return Json(lineQuotes,JsonRequestBehavior.AllowGet);
		}

		// GET: LineQuoteses/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var lineQuotes = await this.lineQuotesService.FindAsync(id);
			if (lineQuotes == null)
			{
				return HttpNotFound();
			}
			var carrierRepository = this.unitOfWork.RepositoryAsync<Carrier>();
			ViewBag.CarrierId = new SelectList(carrierRepository.Queryable(), "Id", "Name", lineQuotes.CarrierId);
			var companyRepository = this.unitOfWork.RepositoryAsync<Company>();
			ViewBag.CompanyId = new SelectList(companyRepository.Queryable(), "Id", "Name", lineQuotes.CompanyId);
			return View(lineQuotes);
		}
		// POST: LineQuoteses/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "Carrier,Company,Id,Name,Location1,Location2,TimePeriod,PiceVehicleType,PiceType,Price,Remark,Description,InputUser,CarrierId,CompanyId,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] LineQuotes lineQuotes)
		{
			if (ModelState.IsValid)
			{
				lineQuotes.TrackingState = TrackingState.Modified;
								lineQuotesService.Update(lineQuotes);
								await   this.unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has update a LineQuotes record");
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
						ViewBag.CarrierId = new SelectList( await carrierRepository.Queryable().ToListAsync(), "Id", "Name", lineQuotes.CarrierId);
									var companyRepository = this.unitOfWork.RepositoryAsync<Company>();
						ViewBag.CompanyId = new SelectList( await companyRepository.Queryable().ToListAsync(), "Id", "Name", lineQuotes.CompanyId);
									return View(lineQuotes);
		}
		// GET: LineQuoteses/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var lineQuotes = await this.lineQuotesService.FindAsync(id);
			if (lineQuotes == null)
			{
				return HttpNotFound();
			}
			return View(lineQuotes);
		}
		// POST: LineQuoteses/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var lineQuotes = await  this.lineQuotesService.FindAsync(id);
			 this.lineQuotesService.Delete(lineQuotes);
			await this.unitOfWork.SaveChangesAsync();
		   if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
			DisplaySuccessMessage("Has delete a LineQuotes record");
			return RedirectToAction("Index");
		}
       
 
		//导出Excel
		[HttpPost]
		public ActionResult ExportExcel( string filterRules = "",string sort = "Id", string order = "asc")
		{
			var fileName = "linequotes_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream=  this.lineQuotesService.ExportExcel(filterRules,sort, order );
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
