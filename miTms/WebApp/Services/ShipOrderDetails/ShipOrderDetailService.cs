// <copyright file="ShipOrderDetailService.cs" company="neozhu/SmartCode-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>6/25/2018 4:01:08 PM </date>
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
    public class ShipOrderDetailService : Service< ShipOrderDetail >, IShipOrderDetailService
    {

        private readonly IRepositoryAsync<ShipOrderDetail> _repository;
		 private readonly IDataTableImportMappingService _mappingservice;
        public  ShipOrderDetailService(IRepositoryAsync< ShipOrderDetail> repository,IDataTableImportMappingService mappingservice)
            : base(repository)
        {
            _repository=repository;
			_mappingservice = mappingservice;
        }
        
                 public  IEnumerable<ShipOrderDetail> GetByOrderId(int  orderid)
         {
            return _repository.GetByOrderId(orderid);
         }
                  public  IEnumerable<ShipOrderDetail> GetByShipOrderId(int  shiporderid)
         {
            return _repository.GetByShipOrderId(shiporderid);
         }
                   
        

		public void ImportDataTable(System.Data.DataTable datatable)
        {
            foreach (DataRow row in datatable.Rows)
            {
                 
                ShipOrderDetail item = new ShipOrderDetail();
				var mapping = _mappingservice.Queryable().Where(x => x.EntitySetName == "ShipOrderDetail" &&  x.IsEnabled==true).ToList();
                var requiredfield = mapping.Where(x => x.IsRequired == true).FirstOrDefault()?.SourceFieldName;
                if (requiredfield != null && !row.IsNull(requiredfield) &&  row[requiredfield] != DBNull.Value && Convert.ToString(row[requiredfield]).Trim() != string.Empty)
                {
                    foreach (var field in mapping)
                    {
						var defval = field.DefaultValue;
						var contation = datatable.Columns.Contains((field.SourceFieldName == null ? "" : field.SourceFieldName));
						if (contation && !row.IsNull(field.SourceFieldName) && row[field.SourceFieldName] != DBNull.Value )
						{
							Type shiporderdetailtype = item.GetType();
							PropertyInfo propertyInfo = shiporderdetailtype.GetProperty(field.FieldName);
							propertyInfo.SetValue(item, Convert.ChangeType(row[field.SourceFieldName], propertyInfo.PropertyType), null);
						}
						else if (!string.IsNullOrEmpty(defval))
						{
							Type shiporderdetailtype = item.GetType();
							PropertyInfo propertyInfo = shiporderdetailtype.GetProperty(field.FieldName);
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
        }
		
		public Stream ExportExcel(string filterRules = "",string sort = "Id", string order = "asc")
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
                       			 
            var shiporderdetails  = this.Query(new ShipOrderDetailQuery().Withfilter(filters)).Include(p => p.Order).Include(p => p.ShipOrder).OrderBy(n=>n.OrderBy(sort,order)).Select().ToList();
            
                        var datarows = shiporderdetails .Select(  n => new { 

    OrderOrderNo = (n.Order==null?"": n.Order.OrderNo) ,
    ShipOrderShipOrderNo = (n.ShipOrder==null?"": n.ShipOrder.ShipOrderNo) ,
    Id = n.Id,
    OrderNo = n.OrderNo,
    OrderId = n.OrderId,
    Location1 = n.Location1,
    LoadTransportStationName = n.LoadTransportStationName,
    Location2 = n.Location2,
    ReceiptTransportStationName = n.ReceiptTransportStationName,
    Status = n.Status,
    Packages = n.Packages,
    Weight = n.Weight,
    Volume = n.Volume,
    Pallets = n.Pallets,
    Cartons = n.Cartons,
    BreakCartons = n.BreakCartons,
    ShipOrderId = n.ShipOrderId,
    ShipOrderNo = n.ShipOrderNo,
    CreatedDate = n.CreatedDate,
    CreatedBy = n.CreatedBy,
    LastModifiedDate = n.LastModifiedDate,
    LastModifiedBy = n.LastModifiedBy
}).ToList();
           
            return ExcelHelper.ExportExcel(typeof(ShipOrderDetail), datarows);

        }
    }
}



