﻿// <copyright file="CompanyService.cs" company="neozhu/SmartCode-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/30/2018 8:46:45 AM </date>
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
    public class CompanyService : Service< Company >, ICompanyService
    {

        private readonly IRepositoryAsync<Company> _repository;
		 private readonly IDataTableImportMappingService _mappingservice;
        public  CompanyService(IRepositoryAsync< Company> repository,IDataTableImportMappingService mappingservice)
            : base(repository)
        {
            _repository=repository;
			_mappingservice = mappingservice;
        }
        
                  
        

		public void ImportDataTable(System.Data.DataTable datatable)
        {
            foreach (DataRow row in datatable.Rows)
            {
                 
                Company item = new Company();
				var mapping = _mappingservice.Queryable().Where(x => x.EntitySetName == "Company" &&  x.IsEnabled==true).ToList();

                foreach (var field in mapping)
                {
                 
						var defval = field.DefaultValue;
						var contation = datatable.Columns.Contains((field.SourceFieldName == null ? "" : field.SourceFieldName));
						if (contation && row[field.SourceFieldName] != DBNull.Value)
						{
							Type companytype = item.GetType();
							PropertyInfo propertyInfo = companytype.GetProperty(field.FieldName);
							propertyInfo.SetValue(item, Convert.ChangeType(row[field.SourceFieldName], propertyInfo.PropertyType), null);
						}
						else if (!string.IsNullOrEmpty(defval))
						{
							Type companytype = item.GetType();
							PropertyInfo propertyInfo = companytype.GetProperty(field.FieldName);
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
                                   var companies  = this.Query(new CompanyQuery().Withfilter(filters)).OrderBy(n=>n.OrderBy(sort,order)).Select().ToList();
                        var datarows = companies .Select(  n => new { 

    Id = n.Id,
    Name = n.Name,
    Address = n.Address,
    RegisteredCapital = n.RegisteredCapital,
    UnifiedSocialCreditldentifier = n.UnifiedSocialCreditldentifier,
    UnifiedSocialDatetime = n.UnifiedSocialDatetime,
    BusinessScope = n.BusinessScope,
    BusinessLicenseStartDatetime = n.BusinessLicenseStartDatetime,
    BusinessLicenseendDatetime = n.BusinessLicenseendDatetime,
    CountrySubdivisionCode = n.CountrySubdivisionCode,
    PermitNumber = n.PermitNumber,
    LegalPersonName = n.LegalPersonName,
    LegalPersonTelehoneNumber = n.LegalPersonTelehoneNumber,
    ContactName = n.ContactName,
    ContactMobileTelephoneNumber = n.ContactMobileTelephoneNumber,
    FaxNumber = n.FaxNumber,
    InternetPlusProperty = n.InternetPlusProperty,
    IsDeleteFlag = n.IsDeleteFlag,
    SynchronizationTime = n.SynchronizationTime,
    IsException = n.IsException,
    CreatedDate = n.CreatedDate,
    CreatedBy = n.CreatedBy,
    LastModifiedDate = n.LastModifiedDate,
    LastModifiedBy = n.LastModifiedBy
}).ToList();
           
            return ExcelHelper.ExportExcel(typeof(Company), datarows);

        }
    }
}



