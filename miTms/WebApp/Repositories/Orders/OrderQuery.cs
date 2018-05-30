// <copyright file="OrderQuery.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 1:01:15 PM </date>
// <summary>
// 配合 easyui datagrid filter 组件使用,实现对datagrid 所有字段筛选功能
// 也可以对特定的查询进行封装使用 
//  
//  
// </summary>

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.SqlServer;
using Repository.Pattern.Repositories;
using Repository.Pattern.Ef6;
using System.Web.WebPages;
using WebApp.Models;
 

namespace WebApp.Repositories
{
   public class OrderQuery:QueryObject<Order>
    {
        public OrderQuery WithAnySearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.OrderNo.Contains(search) || x.ExternalNo.Contains(search) || x.OrderDate.ToString().Contains(search) || x.Location1.Contains(search) || x.Location2.Contains(search) || x.Requirements.Contains(search) || x.PlanDeliveryDate.ToString().Contains(search) || x.TimePeriod.ToString().Contains(search) || x.VehicleId.ToString().Contains(search) || x.PlateNumber.Contains(search) || x.Driver.Contains(search) || x.DriverPhone.Contains(search) || x.Packages.ToString().Contains(search) || x.Weight.ToString().Contains(search) || x.Volume.ToString().Contains(search) || x.Cartons.ToString().Contains(search) || x.Pallets.ToString().Contains(search) || x.Status.Contains(search) || x.DeliveryDate.ToString().Contains(search) || x.CloseDate.ToString().Contains(search) || x.ShipperId.ToString().Contains(search) );
            return this;
        }


		public OrderQuery Withfilter(IEnumerable<filterRule> filters)
        {
           if (filters != null)
           {
               foreach (var rule in filters)
               {
                  
					
				    						if (rule.field == "Id" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Id == val);
                                break;
                            case "notequal":
                                And(x => x.Id != val);
                                break;
                            case "less":
                                And(x => x.Id < val);
                                break;
                            case "lessorequal":
                                And(x => x.Id <= val);
                                break;
                            case "greater":
                                And(x => x.Id > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Id >= val);
                                break;
                            default:
                                And(x => x.Id == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "OrderNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.OrderNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ExternalNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ExternalNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "OrderDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.OrderDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.OrderDate) <= 0);
						    }
						}
				   
				    				
											if (rule.field == "Location1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location1.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Location2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location2.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Requirements"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Requirements.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "PlanDeliveryDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.PlanDeliveryDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.PlanDeliveryDate) <= 0);
						    }
						}
				   
				    				
					
				    						if (rule.field == "TimePeriod" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.TimePeriod == val);
                                break;
                            case "notequal":
                                And(x => x.TimePeriod != val);
                                break;
                            case "less":
                                And(x => x.TimePeriod < val);
                                break;
                            case "lessorequal":
                                And(x => x.TimePeriod <= val);
                                break;
                            case "greater":
                                And(x => x.TimePeriod > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.TimePeriod >= val);
                                break;
                            default:
                                And(x => x.TimePeriod == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "VehicleId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehicleId == val);
                                break;
                            case "notequal":
                                And(x => x.VehicleId != val);
                                break;
                            case "less":
                                And(x => x.VehicleId < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehicleId <= val);
                                break;
                            case "greater":
                                And(x => x.VehicleId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehicleId >= val);
                                break;
                            default:
                                And(x => x.VehicleId == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "PlateNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PlateNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Driver"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Driver.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DriverPhone"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DriverPhone.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "Packages" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Packages == val);
                                break;
                            case "notequal":
                                And(x => x.Packages != val);
                                break;
                            case "less":
                                And(x => x.Packages < val);
                                break;
                            case "lessorequal":
                                And(x => x.Packages <= val);
                                break;
                            case "greater":
                                And(x => x.Packages > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Packages >= val);
                                break;
                            default:
                                And(x => x.Packages == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
											if (rule.field == "Weight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Weight == val);
                                break;
                            case "notequal":
                                And(x => x.Weight != val);
                                break;
                            case "less":
                                And(x => x.Weight < val);
                                break;
                            case "lessorequal":
                                And(x => x.Weight <= val);
                                break;
                            case "greater":
                                And(x => x.Weight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Weight >= val);
                                break;
                            default:
                                And(x => x.Weight == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "Volume" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Volume == val);
                                break;
                            case "notequal":
                                And(x => x.Volume != val);
                                break;
                            case "less":
                                And(x => x.Volume < val);
                                break;
                            case "lessorequal":
                                And(x => x.Volume <= val);
                                break;
                            case "greater":
                                And(x => x.Volume > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Volume >= val);
                                break;
                            default:
                                And(x => x.Volume == val);
                                break;
                        }
						}
				    
					
				    				
					
				    						if (rule.field == "Cartons" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Cartons == val);
                                break;
                            case "notequal":
                                And(x => x.Cartons != val);
                                break;
                            case "less":
                                And(x => x.Cartons < val);
                                break;
                            case "lessorequal":
                                And(x => x.Cartons <= val);
                                break;
                            case "greater":
                                And(x => x.Cartons > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Cartons >= val);
                                break;
                            default:
                                And(x => x.Cartons == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "Pallets" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Pallets == val);
                                break;
                            case "notequal":
                                And(x => x.Pallets != val);
                                break;
                            case "less":
                                And(x => x.Pallets < val);
                                break;
                            case "lessorequal":
                                And(x => x.Pallets <= val);
                                break;
                            case "greater":
                                And(x => x.Pallets > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Pallets >= val);
                                break;
                            default:
                                And(x => x.Pallets == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "Status"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Status.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "DeliveryDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.DeliveryDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.DeliveryDate) <= 0);
						    }
						}
				   
				    				
					
				    
					
											if (rule.field == "CloseDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.CloseDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.CloseDate) <= 0);
						    }
						}
				   
				    				
					
				    						if (rule.field == "ShipperId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.ShipperId == val);
                                break;
                            case "notequal":
                                And(x => x.ShipperId != val);
                                break;
                            case "less":
                                And(x => x.ShipperId < val);
                                break;
                            case "lessorequal":
                                And(x => x.ShipperId <= val);
                                break;
                            case "greater":
                                And(x => x.ShipperId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.ShipperId >= val);
                                break;
                            default:
                                And(x => x.ShipperId == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
					
											if (rule.field == "CreatedDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.CreatedDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.CreatedDate) <= 0);
						    }
						}
				   
				    				
											if (rule.field == "CreatedBy"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CreatedBy.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "LastModifiedDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.LastModifiedDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.LastModifiedDate) <= 0);
						    }
						}
				   
				    				
											if (rule.field == "LastModifiedBy"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LastModifiedBy.Contains(rule.value));
						}
				    
				    
					
					
				    									
                   
               }
           }
            return this;
        }



                 public  OrderQuery ByVehicleIdWithfilter(int vehicleid, IEnumerable<filterRule> filters)
         {
            And(x => x.VehicleId == vehicleid);
            
            if (filters != null)
           {
               foreach (var rule in filters)
               {
                     
                
					
				    						if (rule.field == "Id" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Id == val);
                                break;
                            case "notequal":
                                And(x => x.Id != val);
                                break;
                            case "less":
                                And(x => x.Id < val);
                                break;
                            case "lessorequal":
                                And(x => x.Id <= val);
                                break;
                            case "greater":
                                And(x => x.Id > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Id >= val);
                                break;
                            default:
                                And(x => x.Id == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "OrderNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.OrderNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ExternalNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ExternalNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "OrderDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.OrderDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.OrderDate) <= 0);
						    }
                        }
				   
				    				
											if (rule.field == "Location1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location1.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Location2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location2.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Requirements"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Requirements.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "PlanDeliveryDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.PlanDeliveryDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.PlanDeliveryDate) <= 0);
						    }
                        }
				   
				    				
					
				    						if (rule.field == "TimePeriod" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.TimePeriod == val);
                                break;
                            case "notequal":
                                And(x => x.TimePeriod != val);
                                break;
                            case "less":
                                And(x => x.TimePeriod < val);
                                break;
                            case "lessorequal":
                                And(x => x.TimePeriod <= val);
                                break;
                            case "greater":
                                And(x => x.TimePeriod > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.TimePeriod >= val);
                                break;
                            default:
                                And(x => x.TimePeriod == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "VehicleId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehicleId == val);
                                break;
                            case "notequal":
                                And(x => x.VehicleId != val);
                                break;
                            case "less":
                                And(x => x.VehicleId < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehicleId <= val);
                                break;
                            case "greater":
                                And(x => x.VehicleId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehicleId >= val);
                                break;
                            default:
                                And(x => x.VehicleId == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "PlateNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PlateNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Driver"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Driver.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DriverPhone"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DriverPhone.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "Packages" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Packages == val);
                                break;
                            case "notequal":
                                And(x => x.Packages != val);
                                break;
                            case "less":
                                And(x => x.Packages < val);
                                break;
                            case "lessorequal":
                                And(x => x.Packages <= val);
                                break;
                            case "greater":
                                And(x => x.Packages > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Packages >= val);
                                break;
                            default:
                                And(x => x.Packages == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
											if (rule.field == "Weight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Weight == val);
                                break;
                            case "notequal":
                                And(x => x.Weight != val);
                                break;
                            case "less":
                                And(x => x.Weight < val);
                                break;
                            case "lessorequal":
                                And(x => x.Weight <= val);
                                break;
                            case "greater":
                                And(x => x.Weight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Weight >= val);
                                break;
                            default:
                                And(x => x.Weight == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "Volume" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Volume == val);
                                break;
                            case "notequal":
                                And(x => x.Volume != val);
                                break;
                            case "less":
                                And(x => x.Volume < val);
                                break;
                            case "lessorequal":
                                And(x => x.Volume <= val);
                                break;
                            case "greater":
                                And(x => x.Volume > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Volume >= val);
                                break;
                            default:
                                And(x => x.Volume == val);
                                break;
                        }
						}
				    
					
				    				
					
				    						if (rule.field == "Cartons" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Cartons == val);
                                break;
                            case "notequal":
                                And(x => x.Cartons != val);
                                break;
                            case "less":
                                And(x => x.Cartons < val);
                                break;
                            case "lessorequal":
                                And(x => x.Cartons <= val);
                                break;
                            case "greater":
                                And(x => x.Cartons > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Cartons >= val);
                                break;
                            default:
                                And(x => x.Cartons == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "Pallets" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Pallets == val);
                                break;
                            case "notequal":
                                And(x => x.Pallets != val);
                                break;
                            case "less":
                                And(x => x.Pallets < val);
                                break;
                            case "lessorequal":
                                And(x => x.Pallets <= val);
                                break;
                            case "greater":
                                And(x => x.Pallets > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Pallets >= val);
                                break;
                            default:
                                And(x => x.Pallets == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "Status"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Status.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "DeliveryDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.DeliveryDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.DeliveryDate) <= 0);
						    }
                        }
				   
				    				
					
				    
					
											if (rule.field == "CloseDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.CloseDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.CloseDate) <= 0);
						    }
                        }
				   
				    				
					
				    						if (rule.field == "ShipperId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.ShipperId == val);
                                break;
                            case "notequal":
                                And(x => x.ShipperId != val);
                                break;
                            case "less":
                                And(x => x.ShipperId < val);
                                break;
                            case "lessorequal":
                                And(x => x.ShipperId <= val);
                                break;
                            case "greater":
                                And(x => x.ShipperId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.ShipperId >= val);
                                break;
                            default:
                                And(x => x.ShipperId == val);
                                break;
                        }
						}
				    
					
					
				    				
               }
            }
            return this;
         }
             
                 public  OrderQuery ByShipperIdWithfilter(int Shipperid, IEnumerable<filterRule> filters)
         {
            And(x => x.ShipperId == Shipperid);
            
            if (filters != null)
           {
               foreach (var rule in filters)
               {
                     
                
					
				    						if (rule.field == "Id" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Id == val);
                                break;
                            case "notequal":
                                And(x => x.Id != val);
                                break;
                            case "less":
                                And(x => x.Id < val);
                                break;
                            case "lessorequal":
                                And(x => x.Id <= val);
                                break;
                            case "greater":
                                And(x => x.Id > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Id >= val);
                                break;
                            default:
                                And(x => x.Id == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "OrderNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.OrderNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ExternalNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ExternalNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "OrderDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.OrderDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.OrderDate) <= 0);
						    }
                        }
				   
				    				
											if (rule.field == "Location1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location1.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Location2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location2.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Requirements"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Requirements.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "PlanDeliveryDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.PlanDeliveryDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.PlanDeliveryDate) <= 0);
						    }
                        }
				   
				    				
					
				    						if (rule.field == "TimePeriod" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.TimePeriod == val);
                                break;
                            case "notequal":
                                And(x => x.TimePeriod != val);
                                break;
                            case "less":
                                And(x => x.TimePeriod < val);
                                break;
                            case "lessorequal":
                                And(x => x.TimePeriod <= val);
                                break;
                            case "greater":
                                And(x => x.TimePeriod > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.TimePeriod >= val);
                                break;
                            default:
                                And(x => x.TimePeriod == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "VehicleId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehicleId == val);
                                break;
                            case "notequal":
                                And(x => x.VehicleId != val);
                                break;
                            case "less":
                                And(x => x.VehicleId < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehicleId <= val);
                                break;
                            case "greater":
                                And(x => x.VehicleId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehicleId >= val);
                                break;
                            default:
                                And(x => x.VehicleId == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "PlateNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PlateNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Driver"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Driver.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DriverPhone"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DriverPhone.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "Packages" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Packages == val);
                                break;
                            case "notequal":
                                And(x => x.Packages != val);
                                break;
                            case "less":
                                And(x => x.Packages < val);
                                break;
                            case "lessorequal":
                                And(x => x.Packages <= val);
                                break;
                            case "greater":
                                And(x => x.Packages > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Packages >= val);
                                break;
                            default:
                                And(x => x.Packages == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
											if (rule.field == "Weight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Weight == val);
                                break;
                            case "notequal":
                                And(x => x.Weight != val);
                                break;
                            case "less":
                                And(x => x.Weight < val);
                                break;
                            case "lessorequal":
                                And(x => x.Weight <= val);
                                break;
                            case "greater":
                                And(x => x.Weight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Weight >= val);
                                break;
                            default:
                                And(x => x.Weight == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "Volume" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Volume == val);
                                break;
                            case "notequal":
                                And(x => x.Volume != val);
                                break;
                            case "less":
                                And(x => x.Volume < val);
                                break;
                            case "lessorequal":
                                And(x => x.Volume <= val);
                                break;
                            case "greater":
                                And(x => x.Volume > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Volume >= val);
                                break;
                            default:
                                And(x => x.Volume == val);
                                break;
                        }
						}
				    
					
				    				
					
				    						if (rule.field == "Cartons" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Cartons == val);
                                break;
                            case "notequal":
                                And(x => x.Cartons != val);
                                break;
                            case "less":
                                And(x => x.Cartons < val);
                                break;
                            case "lessorequal":
                                And(x => x.Cartons <= val);
                                break;
                            case "greater":
                                And(x => x.Cartons > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Cartons >= val);
                                break;
                            default:
                                And(x => x.Cartons == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "Pallets" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Pallets == val);
                                break;
                            case "notequal":
                                And(x => x.Pallets != val);
                                break;
                            case "less":
                                And(x => x.Pallets < val);
                                break;
                            case "lessorequal":
                                And(x => x.Pallets <= val);
                                break;
                            case "greater":
                                And(x => x.Pallets > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Pallets >= val);
                                break;
                            default:
                                And(x => x.Pallets == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "Status"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Status.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "DeliveryDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.DeliveryDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.DeliveryDate) <= 0);
						    }
                        }
				   
				    				
					
				    
					
											if (rule.field == "CloseDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.CloseDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.CloseDate) <= 0);
						    }
                        }
				   
				    				
					
				    						if (rule.field == "ShipperId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.ShipperId == val);
                                break;
                            case "notequal":
                                And(x => x.ShipperId != val);
                                break;
                            case "less":
                                And(x => x.ShipperId < val);
                                break;
                            case "lessorequal":
                                And(x => x.ShipperId <= val);
                                break;
                            case "greater":
                                And(x => x.ShipperId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.ShipperId >= val);
                                break;
                            default:
                                And(x => x.ShipperId == val);
                                break;
                        }
						}
				    
					
					
				    				
               }
            }
            return this;
         }
             
            }
}



