// <copyright file="ShipOrderDetailQuery.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>6/25/2018 4:01:07 PM </date>
// <summary>
// 配合 easyui datagrid filter 组件使用,实现对datagrid 所有字段筛选功能
// 也可以对特定的业务逻辑查询进行封装
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
   public class ShipOrderDetailQuery:QueryObject<ShipOrderDetail>
    {
        public ShipOrderDetailQuery WithAnySearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.OrderNo.Contains(search) || x.OrderId.ToString().Contains(search) || x.Location1.Contains(search) || x.LoadTransportStation.Contains(search) || x.Location2.Contains(search) || x.ReceiptTransportStation.Contains(search) || x.Status.ToString().Contains(search) || x.Packages.ToString().Contains(search) || x.Weight.ToString().Contains(search) || x.Volume.ToString().Contains(search) || x.Pallets.ToString().Contains(search) || x.Cartons.ToString().Contains(search) || x.BreakCartons.ToString().Contains(search) || x.ShipOrderId.ToString().Contains(search) || x.ShipOrderNo.Contains(search) );
            return this;
        }


		public ShipOrderDetailQuery Withfilter(IEnumerable<filterRule> filters)
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
				    
				    
					
					
				    				
					
				    						if (rule.field == "OrderId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.OrderId == val);
                                break;
                            case "notequal":
                                And(x => x.OrderId != val);
                                break;
                            case "less":
                                And(x => x.OrderId < val);
                                break;
                            case "lessorequal":
                                And(x => x.OrderId <= val);
                                break;
                            case "greater":
                                And(x => x.OrderId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.OrderId >= val);
                                break;
                            default:
                                And(x => x.OrderId == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "Location1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location1.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LoadTransportStation"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LoadTransportStation.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Location2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location2.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ReceiptTransportStation"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ReceiptTransportStation.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "Status" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Status == val);
                                break;
                            case "notequal":
                                And(x => x.Status != val);
                                break;
                            case "less":
                                And(x => x.Status < val);
                                break;
                            case "lessorequal":
                                And(x => x.Status <= val);
                                break;
                            case "greater":
                                And(x => x.Status > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Status >= val);
                                break;
                            default:
                                And(x => x.Status == val);
                                break;
                        }
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
				    
					
					
				    				
					
				    						if (rule.field == "BreakCartons" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.BreakCartons == val);
                                break;
                            case "notequal":
                                And(x => x.BreakCartons != val);
                                break;
                            case "less":
                                And(x => x.BreakCartons < val);
                                break;
                            case "lessorequal":
                                And(x => x.BreakCartons <= val);
                                break;
                            case "greater":
                                And(x => x.BreakCartons > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.BreakCartons >= val);
                                break;
                            default:
                                And(x => x.BreakCartons == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "ShipOrderId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.ShipOrderId == val);
                                break;
                            case "notequal":
                                And(x => x.ShipOrderId != val);
                                break;
                            case "less":
                                And(x => x.ShipOrderId < val);
                                break;
                            case "lessorequal":
                                And(x => x.ShipOrderId <= val);
                                break;
                            case "greater":
                                And(x => x.ShipOrderId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.ShipOrderId >= val);
                                break;
                            default:
                                And(x => x.ShipOrderId == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "ShipOrderNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ShipOrderNo.Contains(rule.value));
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



                 public  ShipOrderDetailQuery ByOrderIdWithfilter(int orderid, IEnumerable<filterRule> filters)
         {
            And(x => x.OrderId == orderid);
            
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
				    
				    
					
					
				    				
					
				    						if (rule.field == "OrderId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.OrderId == val);
                                break;
                            case "notequal":
                                And(x => x.OrderId != val);
                                break;
                            case "less":
                                And(x => x.OrderId < val);
                                break;
                            case "lessorequal":
                                And(x => x.OrderId <= val);
                                break;
                            case "greater":
                                And(x => x.OrderId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.OrderId >= val);
                                break;
                            default:
                                And(x => x.OrderId == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "Location1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location1.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LoadTransportStation"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LoadTransportStation.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Location2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location2.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ReceiptTransportStation"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ReceiptTransportStation.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "Status" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Status == val);
                                break;
                            case "notequal":
                                And(x => x.Status != val);
                                break;
                            case "less":
                                And(x => x.Status < val);
                                break;
                            case "lessorequal":
                                And(x => x.Status <= val);
                                break;
                            case "greater":
                                And(x => x.Status > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Status >= val);
                                break;
                            default:
                                And(x => x.Status == val);
                                break;
                        }
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
				    
					
					
				    				
					
				    						if (rule.field == "BreakCartons" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.BreakCartons == val);
                                break;
                            case "notequal":
                                And(x => x.BreakCartons != val);
                                break;
                            case "less":
                                And(x => x.BreakCartons < val);
                                break;
                            case "lessorequal":
                                And(x => x.BreakCartons <= val);
                                break;
                            case "greater":
                                And(x => x.BreakCartons > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.BreakCartons >= val);
                                break;
                            default:
                                And(x => x.BreakCartons == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "ShipOrderId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.ShipOrderId == val);
                                break;
                            case "notequal":
                                And(x => x.ShipOrderId != val);
                                break;
                            case "less":
                                And(x => x.ShipOrderId < val);
                                break;
                            case "lessorequal":
                                And(x => x.ShipOrderId <= val);
                                break;
                            case "greater":
                                And(x => x.ShipOrderId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.ShipOrderId >= val);
                                break;
                            default:
                                And(x => x.ShipOrderId == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "ShipOrderNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ShipOrderNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
               }
            }
            return this;
         }
             
                 public  ShipOrderDetailQuery ByShipOrderIdWithfilter(int shiporderid, IEnumerable<filterRule> filters)
         {
            And(x => x.ShipOrderId == shiporderid);
            
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
				    
				    
					
					
				    				
					
				    						if (rule.field == "OrderId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.OrderId == val);
                                break;
                            case "notequal":
                                And(x => x.OrderId != val);
                                break;
                            case "less":
                                And(x => x.OrderId < val);
                                break;
                            case "lessorequal":
                                And(x => x.OrderId <= val);
                                break;
                            case "greater":
                                And(x => x.OrderId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.OrderId >= val);
                                break;
                            default:
                                And(x => x.OrderId == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "Location1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location1.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LoadTransportStation"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LoadTransportStation.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Location2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location2.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ReceiptTransportStation"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ReceiptTransportStation.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "Status" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Status == val);
                                break;
                            case "notequal":
                                And(x => x.Status != val);
                                break;
                            case "less":
                                And(x => x.Status < val);
                                break;
                            case "lessorequal":
                                And(x => x.Status <= val);
                                break;
                            case "greater":
                                And(x => x.Status > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Status >= val);
                                break;
                            default:
                                And(x => x.Status == val);
                                break;
                        }
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
				    
					
					
				    				
					
				    						if (rule.field == "BreakCartons" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.BreakCartons == val);
                                break;
                            case "notequal":
                                And(x => x.BreakCartons != val);
                                break;
                            case "less":
                                And(x => x.BreakCartons < val);
                                break;
                            case "lessorequal":
                                And(x => x.BreakCartons <= val);
                                break;
                            case "greater":
                                And(x => x.BreakCartons > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.BreakCartons >= val);
                                break;
                            default:
                                And(x => x.BreakCartons == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "ShipOrderId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.ShipOrderId == val);
                                break;
                            case "notequal":
                                And(x => x.ShipOrderId != val);
                                break;
                            case "less":
                                And(x => x.ShipOrderId < val);
                                break;
                            case "lessorequal":
                                And(x => x.ShipOrderId <= val);
                                break;
                            case "greater":
                                And(x => x.ShipOrderId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.ShipOrderId >= val);
                                break;
                            default:
                                And(x => x.ShipOrderId == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "ShipOrderNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ShipOrderNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
               }
            }
            return this;
         }
             
            }
}



