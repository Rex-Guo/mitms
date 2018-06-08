// <copyright file="LineQuotesService.cs" company="neozhu/SmartCode-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>2018/6/8 7:56:14 </date>
// <summary>
//  根据需求定义实现具体的业务逻辑,通过依赖注入降低模块之间的耦合度
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
using Repository.Pattern.Infrastructure;
using Service.Pattern;
using WebApp.Models;
using WebApp.Repositories;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;

namespace WebApp.Services
{
    public class LineQuotesService : Service< LineQuotes >, ILineQuotesService
    {

        private readonly IRepositoryAsync<LineQuotes> _repository;
		 private readonly IDataTableImportMappingService _mappingservice;
        public  LineQuotesService(IRepositoryAsync< LineQuotes> repository,IDataTableImportMappingService mappingservice)
            : base(repository)
        {
            _repository=repository;
			_mappingservice = mappingservice;
        }
        
                 public  IEnumerable<LineQuotes> GetByCarrierId(int  carrierid)
         {
            return _repository.GetByCarrierId(carrierid);
         }
                  public  IEnumerable<LineQuotes> GetByCompanyId(int  companyid)
         {
            return _repository.GetByCompanyId(companyid);
         }
                   
        

		public void ImportDataTable(System.Data.DataTable datatable)
        {
            foreach (DataRow row in datatable.Rows)
            {
                 
                LineQuotes item = new LineQuotes();
				var mapping = _mappingservice.Queryable().Where(x => x.EntitySetName == "LineQuotes" &&  x.IsEnabled==true).ToList();

                foreach (var field in mapping)
                {
                 
						var defval = field.DefaultValue;
						var contation = datatable.Columns.Contains((field.SourceFieldName == null ? "" : field.SourceFieldName));
						if (contation && row[field.SourceFieldName] != DBNull.Value)
						{
							Type linequotestype = item.GetType();
							PropertyInfo propertyInfo = linequotestype.GetProperty(field.FieldName);
							propertyInfo.SetValue(item, Convert.ChangeType(row[field.SourceFieldName], propertyInfo.PropertyType), null);
						}
						else if (!string.IsNullOrEmpty(defval))
						{
							Type linequotestype = item.GetType();
							PropertyInfo propertyInfo = linequotestype.GetProperty(field.FieldName);
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
                       			 
            var linequotes  = this.Query(new LineQuotesQuery().Withfilter(filters)).Include(p => p.Carrier).Include(p => p.Company).OrderBy(n=>n.OrderBy(sort,order)).Select().ToList();
            
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
           
            return ExcelHelper.ExportExcel(typeof(LineQuotes), datarows);

        }
    }
}



