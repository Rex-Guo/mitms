/// <summary>
/// Provides functionality to the /TransactionHistory/ route.
/// <date> 5/14/2018 8:58:21 AM </date>
/// Create By SmartCode MVC5 Scaffolder for Visual Studio
/// TODO: RegisterType UnityConfig.cs
/// container.RegisterType<IRepositoryAsync<TransactionHistory>, Repository<TransactionHistory>>();
/// container.RegisterType<ITransactionHistoryService, TransactionHistoryService>();
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
    public class TransactionHistoriesController : Controller
    {
        //private StoreContext db = new StoreContext();
        private readonly ITransactionHistoryService _transactionHistoryService;
        private readonly IUnitOfWorkAsync _unitOfWork;
        public TransactionHistoriesController(ITransactionHistoryService transactionHistoryService, IUnitOfWorkAsync unitOfWork)
        {
            _transactionHistoryService = transactionHistoryService;
            _unitOfWork = unitOfWork;
        }
        // GET: TransactionHistories/Index
        //[OutputCache(Duration = 360, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
        // Get :TransactionHistories/PageList
        // For Index View Boostrap-Table load  data 
        [HttpGet]
        public async Task<JsonResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            var totalCount = 0;
            //int pagenum = offset / limit +1;
            var transactionhistories = await _transactionHistoryService
       .Query(new TransactionHistoryQuery().Withfilter(filters))
       .OrderBy(n => n.OrderBy(sort, order))
       .SelectPageAsync(page, rows, out totalCount);
            var datarows = transactionhistories.Select(n => new
            {
                Id = n.Id,
                OrderNo = n.OrderNo,
                PlateNumber = n.PlateNumber,
                Status = n.Status,
                TransactioDateTime = n.TransactioDateTime,
                Remark = n.Remark,
                Flag1 = n.Flag1,
                Flag2 = n.Flag2,
                InputUser = n.InputUser,
                Longitude = n.Longitude,
                Latitude = n.Latitude,
                PhotographPath = n.PhotographPath,
                Photograph = n.Photograph,
                Remark2 = n.Remark2,
                CreatedDate = n.CreatedDate,
                CreatedBy = n.CreatedBy,
                LastModifiedDate = n.LastModifiedDate,
                LastModifiedBy = n.LastModifiedBy
            }).ToList();
            var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> SaveData(TransactionHistoryChangeViewModel transactionhistories)
        {
            if (transactionhistories.updated != null)
            {
                foreach (var item in transactionhistories.updated)
                {
                    _transactionHistoryService.Update(item);
                }
            }
            if (transactionhistories.deleted != null)
            {
                foreach (var item in transactionhistories.deleted)
                {
                    _transactionHistoryService.Delete(item);
                }
            }
            if (transactionhistories.inserted != null)
            {
                foreach (var item in transactionhistories.inserted)
                {
                    _transactionHistoryService.Insert(item);
                }
            }
            await _unitOfWork.SaveChangesAsync();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        // GET: TransactionHistories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transactionHistory = await _transactionHistoryService.FindAsync(id);
            if (transactionHistory == null)
            {
                return HttpNotFound();
            }
            return View(transactionHistory);
        }
        // GET: TransactionHistories/Create
        public ActionResult Create()
        {
            var transactionHistory = new TransactionHistory();
            //set default value
            return View(transactionHistory);
        }
        // POST: TransactionHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OrderNo,PlateNumber,Status,TransactioDateTime,Remark,Flag1,Flag2,InputUser,Longitude,Latitude,PhotographPath,Photograph,Remark2,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] TransactionHistory transactionHistory)
        {
            if (ModelState.IsValid)
            {
                _transactionHistoryService.Insert(transactionHistory);
                await _unitOfWork.SaveChangesAsync();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has append a TransactionHistory record");
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
            return View(transactionHistory);
        }
        // GET: TransactionHistories/PopupEdit/5
        //[OutputCache(Duration = 360, VaryByParam = "id")]
        public async Task<JsonResult> PopupEdit(int? id)
        {

            var transactionHistory = await _transactionHistoryService.FindAsync(id);
            return Json(transactionHistory, JsonRequestBehavior.AllowGet);
        }

        // GET: TransactionHistories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transactionHistory = await _transactionHistoryService.FindAsync(id);
            if (transactionHistory == null)
            {
                return HttpNotFound();
            }
            return View(transactionHistory);
        }
        // POST: TransactionHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OrderNo,PlateNumber,Status,TransactioDateTime,Remark,Flag1,Flag2,InputUser,Longitude,Latitude,PhotographPath,Photograph,Remark2,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] TransactionHistory transactionHistory)
        {
            if (ModelState.IsValid)
            {
                transactionHistory.TrackingState = TrackingState.Modified;
                _transactionHistoryService.Update(transactionHistory);
                await _unitOfWork.SaveChangesAsync();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has update a TransactionHistory record");
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
            return View(transactionHistory);
        }
        // GET: TransactionHistories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transactionHistory = await _transactionHistoryService.FindAsync(id);
            if (transactionHistory == null)
            {
                return HttpNotFound();
            }
            return View(transactionHistory);
        }
        // POST: TransactionHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var transactionHistory = await _transactionHistoryService.FindAsync(id);
            _transactionHistoryService.Delete(transactionHistory);
            await _unitOfWork.SaveChangesAsync();
            if (Request.IsAjaxRequest())
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            DisplaySuccessMessage("Has delete a TransactionHistory record");
            return RedirectToAction("Index");
        }
        //获取历史状态
        public async Task<ActionResult> GetByOrderNo(string orderno)
        {
            var data = this._transactionHistoryService.Queryable().Where(x => x.OrderNo == orderno);
            var datarows = await data.Select(n => new
            {
                Id = n.Id,
                OrderNo = n.OrderNo,
                PlateNumber = n.PlateNumber,
                Status = n.Status,
                TransactioDateTime = n.TransactioDateTime,
                Remark = n.Remark,
                InputUser = n.InputUser,
                
            }).ToListAsync();
 
            return Json(datarows, JsonRequestBehavior.AllowGet);

        }

        //导出Excel
        [HttpPost]
        public ActionResult ExportExcel(string filterRules = "", string sort = "Id", string order = "asc")
        {
            var fileName = "transactionhistories_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            var stream = _transactionHistoryService.ExportExcel(filterRules, sort, order);
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
