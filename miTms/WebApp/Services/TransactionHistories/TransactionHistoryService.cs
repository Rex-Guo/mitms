// <copyright file="TransactionHistoryService.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/14/2018 8:58:19 AM </date>
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
    public class TransactionHistoryService : Service< TransactionHistory >, ITransactionHistoryService
    {

        private readonly IRepositoryAsync<TransactionHistory> _repository;
		 private readonly IDataTableImportMappingService _mappingservice;
        public  TransactionHistoryService(IRepositoryAsync< TransactionHistory> repository,IDataTableImportMappingService mappingservice)
            : base(repository)
        {
            _repository=repository;
			_mappingservice = mappingservice;
        }
        
                  
        

		public void ImportDataTable(System.Data.DataTable datatable)
        {
            foreach (DataRow row in datatable.Rows)
            {
                 
                TransactionHistory item = new TransactionHistory();
				var mapping = _mappingservice.Queryable().Where(x => x.EntitySetName == "TransactionHistory" &&  x.IsEnabled==true).ToList();

                foreach (var field in mapping)
                {
                 
						var defval = field.DefaultValue;
						var contation = datatable.Columns.Contains((field.SourceFieldName == null ? "" : field.SourceFieldName));
						if (contation && row[field.SourceFieldName] != DBNull.Value)
						{
							Type transactionhistorytype = item.GetType();
							PropertyInfo propertyInfo = transactionhistorytype.GetProperty(field.FieldName);
							propertyInfo.SetValue(item, Convert.ChangeType(row[field.SourceFieldName], propertyInfo.PropertyType), null);
						}
						else if (!string.IsNullOrEmpty(defval))
						{
							Type transactionhistorytype = item.GetType();
							PropertyInfo propertyInfo = transactionhistorytype.GetProperty(field.FieldName);
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
                                   var transactionhistories  = this.Query(new TransactionHistoryQuery().Withfilter(filters)).OrderBy(n=>n.OrderBy(sort,order)).Select().ToList();
                        var datarows = transactionhistories .Select(  n => new { 
 Id = n.Id 
, OrderNo = n.OrderNo 
, PlateNumber = n.PlateNumber 
, Status = n.Status 
, TransactioDateTime = n.TransactioDateTime 
, Remark = n.Remark 
, Flag1 = n.Flag1 
, Flag2 = n.Flag2 
, InputUser = n.InputUser 
, Longitude = n.Longitude 
, Latitude = n.Latitude 
, PhotographPath = n.PhotographPath 
, Photograph = n.Photograph 
, Remark2 = n.Remark2 
, CreatedDate = n.CreatedDate 
, CreatedBy = n.CreatedBy 
, LastModifiedDate = n.LastModifiedDate 
, LastModifiedBy = n.LastModifiedBy 

}).ToList();
           
            return ExcelHelper.ExportExcel(typeof(TransactionHistory), datarows);

        }
    }
}



