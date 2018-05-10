// <copyright file="OrderService.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 1:01:16 PM </date>
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
    public class OrderService : Service< Order >, IOrderService
    {

        private readonly IRepositoryAsync<Order> _repository;
		 private readonly IDataTableImportMappingService _mappingservice;
        public  OrderService(IRepositoryAsync< Order> repository,IDataTableImportMappingService mappingservice)
            : base(repository)
        {
            _repository=repository;
			_mappingservice = mappingservice;
        }
        
                 public  IEnumerable<Order> GetByVehicleId(int  vehicleid)
         {
            return _repository.GetByVehicleId(vehicleid);
         }
                  public  IEnumerable<Order> GetByCustomerId(int  customerid)
         {
            return _repository.GetByCustomerId(customerid);
         }
                   
        

		public void ImportDataTable(System.Data.DataTable datatable)
        {
            foreach (DataRow row in datatable.Rows)
            {
                 
                Order item = new Order();
				var mapping = _mappingservice.Queryable().Where(x => x.EntitySetName == "Order" &&  x.IsEnabled==true).ToList();

                foreach (var field in mapping)
                {
                 
						var defval = field.DefaultValue;
						var contation = datatable.Columns.Contains((field.SourceFieldName == null ? "" : field.SourceFieldName));
						if (contation && row[field.SourceFieldName] != DBNull.Value)
						{
							Type ordertype = item.GetType();
							PropertyInfo propertyInfo = ordertype.GetProperty(field.FieldName);
							propertyInfo.SetValue(item, Convert.ChangeType(row[field.SourceFieldName], propertyInfo.PropertyType), null);
						}
						else if (!string.IsNullOrEmpty(defval))
						{
							Type ordertype = item.GetType();
							PropertyInfo propertyInfo = ordertype.GetProperty(field.FieldName);
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
                       			 
            var orders  = this.Query(new OrderQuery().Withfilter(filters)).Include(p => p.Customer).Include(p => p.Vehicle).OrderBy(n=>n.OrderBy(sort,order)).Select().ToList();
            
                        var datarows = orders .Select(  n => new { 
CustomerName = (n.Customer==null?"": n.Customer.Name) 
 ,VehicleOrderNo = (n.Vehicle==null?"": n.Vehicle.OrderNo) 
 , Id = n.Id 
, OrderNo = n.OrderNo 
, ExternalNo = n.ExternalNo 
, OrderDate = n.OrderDate 
, Location1 = n.Location1 
, Location2 = n.Location2 
, Requirements = n.Requirements 
, PlanDeliveryDate = n.PlanDeliveryDate 
, TimePeriod = n.TimePeriod 
, VehicleId = n.VehicleId 
, PlateNumber = n.PlateNumber 
, Driver = n.Driver 
, DriverPhone = n.DriverPhone 
, Packages = n.Packages 
, Weight = n.Weight 
, Volume = n.Volume 
, Cartons = n.Cartons 
, Pallets = n.Pallets 
, Status = n.Status 
, DeliveryDate = n.DeliveryDate 
, CloseDate = n.CloseDate 
, CustomerId = n.CustomerId 
, CreatedDate = n.CreatedDate 
, CreatedBy = n.CreatedBy 
, LastModifiedDate = n.LastModifiedDate 
, LastModifiedBy = n.LastModifiedBy 

}).ToList();
           
            return ExcelHelper.ExportExcel(typeof(Order), datarows);

        }
    }
}



