// <copyright file="CustomerService.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 12:58:47 PM </date>
// <summary>
//  实现定义的业务逻辑,通过依赖注入降低模块之间的耦合度
//   
//  
//  
// </summary>

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Repository.Pattern.Repositories;
using Service.Pattern;
using WebApp.Models;
using WebApp.Repositories;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;

namespace WebApp.Services
{
    public class CustomerService : Service< Customer >, ICustomerService
    {

        private readonly IRepositoryAsync<Customer> _repository;
		 private readonly IDataTableImportMappingService _mappingservice;
        public  CustomerService(IRepositoryAsync< Customer> repository,IDataTableImportMappingService mappingservice)
            : base(repository)
        {
            _repository=repository;
			_mappingservice = mappingservice;
        }
        
                 public  IEnumerable<Customer> GetByCompanyId(int  companyid)
         {
            return _repository.GetByCompanyId(companyid);
         }
                   
        

		public void ImportDataTable(System.Data.DataTable datatable)
        {
            foreach (DataRow row in datatable.Rows)
            {
                 
                Customer item = new Customer();
				var mapping = _mappingservice.Queryable().Where(x => x.EntitySetName == "Customer" &&  x.IsEnabled==true).ToList();

                foreach (var field in mapping)
                {
                 
						var defval = field.DefaultValue;
						var contation = datatable.Columns.Contains((field.SourceFieldName == null ? "" : field.SourceFieldName));
						if (contation && row[field.SourceFieldName] != DBNull.Value)
						{
							Type customertype = item.GetType();
							PropertyInfo propertyInfo = customertype.GetProperty(field.FieldName);
							propertyInfo.SetValue(item, Convert.ChangeType(row[field.SourceFieldName], propertyInfo.PropertyType), null);
						}
						else if (!string.IsNullOrEmpty(defval))
						{
							Type customertype = item.GetType();
							PropertyInfo propertyInfo = customertype.GetProperty(field.FieldName);
							if (defval.ToLower() == "now" && propertyInfo.PropertyType ==typeof(DateTime))
                            {
                                propertyInfo.SetValue(item, Convert.ChangeType(DateTime.Now, propertyInfo.PropertyType), null);
                            }
                            else
                            {
                                propertyInfo.SetValue(item, Convert.ChangeType(defval, propertyInfo.PropertyType), null);
                            }
						}
                }
                
                this.Insert(item);
               

            }
        }
		
		public Stream ExportExcel(string filterRules = "",string sort = "Id", string order = "asc")
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
                       			 
            var customers  = this.Query(new CustomerQuery().Withfilter(filters)).Include(p => p.Company).OrderBy(n=>n.OrderBy(sort,order)).Select().ToList();
            
                        var datarows = customers .Select(  n => new { 
CompanyName = (n.Company==null?"": n.Company.Name) 
 , Id = n.Id 
, Name = n.Name 
, ServiceUser = n.ServiceUser 
, TradeType = n.TradeType 
, LegalPerson = n.LegalPerson 
, RegistrationNumber = n.RegistrationNumber 
, LinkMan = n.LinkMan 
, PhoneNumber = n.PhoneNumber 
, Email = n.Email 
, Fax = n.Fax 
, CustomerService = n.CustomerService 
, Sales = n.Sales 
, Payment = n.Payment 
, PaymentDays = n.PaymentDays 
, BankName = n.BankName 
, BankAccount = n.BankAccount 
, InvoiceTitle = n.InvoiceTitle 
, PaymentNumber = n.PaymentNumber 
, CompanyId = n.CompanyId 
, Address = n.Address 
, CreatedDate = n.CreatedDate 
, CreatedBy = n.CreatedBy 
, LastModifiedDate = n.LastModifiedDate 
, LastModifiedBy = n.LastModifiedBy 

}).ToList();
           
            return ExcelHelper.ExportExcel(typeof(Customer), datarows);

        }
    }
}



