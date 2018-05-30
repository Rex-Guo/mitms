// <copyright file="ShipperService.cs" company="neozhu/SmartCode-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/30/2018 9:44:42 AM </date>
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
    public class ShipperService : Service< Shipper >, IShipperService
    {

        private readonly IRepositoryAsync<Shipper> _repository;
		 private readonly IDataTableImportMappingService _mappingservice;
        public  ShipperService(IRepositoryAsync< Shipper> repository,IDataTableImportMappingService mappingservice)
            : base(repository)
        {
            _repository=repository;
			_mappingservice = mappingservice;
        }
        
                 public  IEnumerable<Shipper> GetByCompanyId(int  companyid)
         {
            return _repository.GetByCompanyId(companyid);
         }
                   
        

		public void ImportDataTable(System.Data.DataTable datatable)
        {
            foreach (DataRow row in datatable.Rows)
            {
                 
                Shipper item = new Shipper();
				var mapping = _mappingservice.Queryable().Where(x => x.EntitySetName == "Shipper" &&  x.IsEnabled==true).ToList();

                foreach (var field in mapping)
                {
                 
						var defval = field.DefaultValue;
						var contation = datatable.Columns.Contains((field.SourceFieldName == null ? "" : field.SourceFieldName));
						if (contation && row[field.SourceFieldName] != DBNull.Value)
						{
							Type shippertype = item.GetType();
							PropertyInfo propertyInfo = shippertype.GetProperty(field.FieldName);
							propertyInfo.SetValue(item, Convert.ChangeType(row[field.SourceFieldName], propertyInfo.PropertyType), null);
						}
						else if (!string.IsNullOrEmpty(defval))
						{
							Type shippertype = item.GetType();
							PropertyInfo propertyInfo = shippertype.GetProperty(field.FieldName);
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
                       			 
            var shippers  = this.Query(new ShipperQuery().Withfilter(filters)).Include(p => p.Company).OrderBy(n=>n.OrderBy(sort,order)).Select().ToList();
            
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
           
            return ExcelHelper.ExportExcel(typeof(Shipper), datarows);

        }
    }
}



