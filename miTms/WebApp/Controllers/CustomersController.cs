/// <summary>
/// Provides functionality to the /Customer/ route.
/// <date> 5/10/2018 12:58:47 PM </date>
/// Create By SmartCode MVC5 Scaffolder for Visual Studio
/// TODO: RegisterType UnityConfig.cs
/// container.RegisterType<IRepositoryAsync<Customer>, Repository<Customer>>();
/// container.RegisterType<ICustomerService, CustomerService>();
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
    public class CustomersController : Controller
    {
        //private StoreContext db = new StoreContext();
        private readonly ICustomerService _customerService;
        private readonly IUnitOfWorkAsync _unitOfWork;
        public CustomersController(ICustomerService customerService, IUnitOfWorkAsync unitOfWork)
        {
            _customerService = customerService;
            _unitOfWork = unitOfWork;
        }
        // GET: Customers/Index
        //[OutputCache(Duration = 360, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
        // Get :Customers/PageList
        // For Index View Boostrap-Table load  data 
        [HttpGet]
        public async Task<JsonResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            var totalCount = 0;
            //int pagenum = offset / limit +1;
            var customers = await _customerService
       .Query(new CustomerQuery().Withfilter(filters)).Include(c => c.Company)
       .OrderBy(n => n.OrderBy(sort, order))
       .SelectPageAsync(page, rows, out totalCount);
            var datarows = customers.Select(n => new
            {
                CompanyName = (n.Company == null ? "" : n.Company.Name),
                Id = n.Id,
                Name = n.Name,
                ServiceUser = n.ServiceUser,
                TradeType = n.TradeType,
                LegalPerson = n.LegalPerson,
                RegistrationNumber = n.RegistrationNumber,
                LinkMan = n.LinkMan,
                PhoneNumber = n.PhoneNumber,
                Email = n.Email,
                Fax = n.Fax,
                CustomerService = n.CustomerService,
                Sales = n.Sales,
                Payment = n.Payment,
                PaymentDays = n.PaymentDays,
                BankName = n.BankName,
                BankAccount = n.BankAccount,
                InvoiceTitle = n.InvoiceTitle,
                PaymentNumber = n.PaymentNumber,
                CompanyId = n.CompanyId,
                Address = n.Address,
                CreatedDate = n.CreatedDate,
                CreatedBy = n.CreatedBy,
                LastModifiedDate = n.LastModifiedDate,
                LastModifiedBy = n.LastModifiedBy
            }).ToList();
            var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> GetDataByCompanyId(int companyid, int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            var totalCount = 0;
            var customers = await _customerService
                       .Query(new CustomerQuery().ByCompanyIdWithfilter(companyid, filters)).Include(c => c.Company)
                       .OrderBy(n => n.OrderBy(sort, order))
                       .SelectPageAsync(page, rows, out totalCount);
            var datarows = customers.Select(n => new
            {
                CompanyName = (n.Company == null ? "" : n.Company.Name),
                Id = n.Id,
                Name = n.Name,
                ServiceUser = n.ServiceUser,
                TradeType = n.TradeType,
                LegalPerson = n.LegalPerson,
                RegistrationNumber = n.RegistrationNumber,
                LinkMan = n.LinkMan,
                PhoneNumber = n.PhoneNumber,
                Email = n.Email,
                Fax = n.Fax,
                CustomerService = n.CustomerService,
                Sales = n.Sales,
                Payment = n.Payment,
                PaymentDays = n.PaymentDays,
                BankName = n.BankName,
                BankAccount = n.BankAccount,
                InvoiceTitle = n.InvoiceTitle,
                PaymentNumber = n.PaymentNumber,
                CompanyId = n.CompanyId,
                Address = n.Address,
                CreatedDate = n.CreatedDate,
                CreatedBy = n.CreatedBy,
                LastModifiedDate = n.LastModifiedDate,
                LastModifiedBy = n.LastModifiedBy
            }).ToList();
            var pagelist = new { total = totalCount, rows = datarows };
            return Json(pagelist, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> SaveData(CustomerChangeViewModel customers)
        {
            if (customers.updated != null)
            {
                foreach (var item in customers.updated)
                {
                    _customerService.Update(item);
                }
            }
            if (customers.deleted != null)
            {
                foreach (var item in customers.deleted)
                {
                    _customerService.Delete(item);
                }
            }
            if (customers.inserted != null)
            {
                foreach (var item in customers.inserted)
                {
                    _customerService.Insert(item);
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
        // GET: Customers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = await _customerService.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        // GET: Customers/Create
        public ActionResult Create()
        {
            var customer = new Customer();
            //set default value
            var companyRepository = _unitOfWork.RepositoryAsync<Company>();
            ViewBag.CompanyId = new SelectList(companyRepository.Queryable(), "Id", "Name");
            return View(customer);
        }
        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Company,Id,Name,ServiceUser,TradeType,LegalPerson,RegistrationNumber,LinkMan,PhoneNumber,Email,Fax,CustomerService,Sales,Payment,PaymentDays,BankName,BankAccount,InvoiceTitle,PaymentNumber,CompanyId,Address,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.Insert(customer);
                await _unitOfWork.SaveChangesAsync();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has append a Customer record");
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
            ViewBag.CompanyId = new SelectList(await companyRepository.Queryable().ToListAsync(), "Id", "Name", customer.CompanyId);
            return View(customer);
        }
        // GET: Customers/PopupEdit/5
        //[OutputCache(Duration = 360, VaryByParam = "id")]
        public async Task<JsonResult> PopupEdit(int? id)
        {

            var customer = await _customerService.FindAsync(id);
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        // GET: Customers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = await _customerService.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var companyRepository = _unitOfWork.RepositoryAsync<Company>();
            ViewBag.CompanyId = new SelectList(companyRepository.Queryable(), "Id", "Name", customer.CompanyId);
            return View(customer);
        }
        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Company,Id,Name,ServiceUser,TradeType,LegalPerson,RegistrationNumber,LinkMan,PhoneNumber,Email,Fax,CustomerService,Sales,Payment,PaymentDays,BankName,BankAccount,InvoiceTitle,PaymentNumber,CompanyId,Address,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.TrackingState = TrackingState.Modified;
                _customerService.Update(customer);
                await _unitOfWork.SaveChangesAsync();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has update a Customer record");
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
            ViewBag.CompanyId = new SelectList(await companyRepository.Queryable().ToListAsync(), "Id", "Name", customer.CompanyId);
            return View(customer);
        }
        // GET: Customers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = await _customerService.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var customer = await _customerService.FindAsync(id);
            _customerService.Delete(customer);
            await _unitOfWork.SaveChangesAsync();
            if (Request.IsAjaxRequest())
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            DisplaySuccessMessage("Has delete a Customer record");
            return RedirectToAction("Index");
        }


        //导出Excel
        [HttpPost]
        public ActionResult ExportExcel(string filterRules = "", string sort = "Id", string order = "asc")
        {
            var fileName = "customers_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            var stream = _customerService.ExportExcel(filterRules, sort, order);
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
