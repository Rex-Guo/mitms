/// <summary>
/// Provides functionality to the /Region/ route.
/// <date> 6/1/2018 3:23:34 PM </date>
/// Create By SmartCode MVC5 Scaffolder for Visual Studio
/// TODO: RegisterType UnityConfig.cs
/// container.RegisterType<IRepositoryAsync<Region>, Repository<Region>>();
/// container.RegisterType<IRegionService, RegionService>();
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
	public class RegionsController : Controller
	{
		//private StoreContext db = new StoreContext();
		private readonly IRegionService  _regionService;
		private readonly IUnitOfWorkAsync _unitOfWork;
		public RegionsController (IRegionService  regionService, IUnitOfWorkAsync unitOfWork)
		{
			_regionService  = regionService;
			_unitOfWork = unitOfWork;
		}
        		// GET: Regions/Index
        //[OutputCache(Duration = 360, VaryByParam = "none")]
		public ActionResult Index()
		{
			 return View();
		}
		// Get :Regions/PageList
		// For Index View Boostrap-Table load  data 
		[HttpGet]
				 public async Task<JsonResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
				{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var totalCount = 0;
			//int pagenum = offset / limit +1;
											var regions  = await  _regionService
						               .Query(new RegionQuery().Withfilter(filters))
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out totalCount);
      									var datarows = regions .Select(  n => new { 

    Id = n.Id,
    Code = n.Code,
    Name = n.Name,
    ParentId = n.ParentId,
    CreatedDate = n.CreatedDate,
    CreatedBy = n.CreatedBy,
    LastModifiedDate = n.LastModifiedDate,
    LastModifiedBy = n.LastModifiedBy
}).ToList();
			var pagelist = new { total = totalCount, rows = datarows };
			return Json(pagelist, JsonRequestBehavior.AllowGet);
		}
         		[HttpPost]
				public async Task<JsonResult> SaveData(RegionChangeViewModel regions)
		{
			if (regions.updated != null)
			{
				foreach (var item in regions.updated)
				{
					_regionService.Update(item);
				}
			}
			if (regions.deleted != null)
			{
				foreach (var item in regions.deleted)
				{
					_regionService.Delete(item);
				}
			}
			if (regions.inserted != null)
			{
				foreach (var item in regions.inserted)
				{
					_regionService.Insert(item);
				}
			}
			await _unitOfWork.SaveChangesAsync();
			return Json(new {Success=true}, JsonRequestBehavior.AllowGet);
		}
								// GET: Regions/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var  region = await _regionService.FindAsync(id);
			if (region == null)
			{
				return HttpNotFound();
			}
			return View(region);
		}
		// GET: Regions/Create
        		public ActionResult Create()
				{
			var region = new Region();
			//set default value
			return View(region);
		}
		// POST: Regions/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "Id,Code,Name,ParentId,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Region region)
		{
			if (ModelState.IsValid)
			{
			 				_regionService.Insert(region);
		   				await _unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has append a Region record");
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
						return View(region);
		}
        // GET: Regions/PopupEdit/5
        //[OutputCache(Duration = 360, VaryByParam = "id")]
		public async Task<JsonResult> PopupEdit(int? id)
		{
			
			var region = await _regionService.FindAsync(id);
			return Json(region,JsonRequestBehavior.AllowGet);
		}

		// GET: Regions/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var region = await _regionService.FindAsync(id);
			if (region == null)
			{
				return HttpNotFound();
			}
			return View(region);
		}
		// POST: Regions/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "Id,Code,Name,ParentId,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Region region)
		{
			if (ModelState.IsValid)
			{
				region.TrackingState = TrackingState.Modified;
								_regionService.Update(region);
								await   _unitOfWork.SaveChangesAsync();
				if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
				DisplaySuccessMessage("Has update a Region record");
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
						return View(region);
		}
		// GET: Regions/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var region = await _regionService.FindAsync(id);
			if (region == null)
			{
				return HttpNotFound();
			}
			return View(region);
		}
		// POST: Regions/Delete/5
		[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var region = await  _regionService.FindAsync(id);
			 _regionService.Delete(region);
			await _unitOfWork.SaveChangesAsync();
		   if (Request.IsAjaxRequest())
				{
					return Json(new { success = true }, JsonRequestBehavior.AllowGet);
				}
			DisplaySuccessMessage("Has delete a Region record");
			return RedirectToAction("Index");
		}
       
 
		//导出Excel
		[HttpPost]
		public ActionResult ExportExcel( string filterRules = "",string sort = "Id", string order = "asc")
		{
			var fileName = "regions_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream=  _regionService.ExportExcel(filterRules,sort, order );
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
