// <copyright file="LineQuotesQuery.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>2018/6/8 7:56:13 </date>
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
   public class LineQuotesQuery:QueryObject<LineQuotes>
    {
        public LineQuotesQuery WithAnySearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.Name.Contains(search) || x.Location1.Contains(search) || x.Location2.Contains(search) || x.TimePeriod.ToString().Contains(search) || x.PiceVehicleType.Contains(search) || x.PiceType.Contains(search) || x.Price.ToString().Contains(search) || x.Remark.Contains(search) || x.Description.Contains(search) || x.InputUser.Contains(search) || x.CarrierId.ToString().Contains(search) || x.CompanyId.ToString().Contains(search) );
            return this;
        }


		public LineQuotesQuery Withfilter(IEnumerable<filterRule> filters)
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
				    
					
					
				    				
											if (rule.field == "Name"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Name.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Location1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location1.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Location2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location2.Contains(rule.value));
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
				    
					
					
				    				
											if (rule.field == "PiceVehicleType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PiceVehicleType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "PiceType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PiceType.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "Price" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Price == val);
                                break;
                            case "notequal":
                                And(x => x.Price != val);
                                break;
                            case "less":
                                And(x => x.Price < val);
                                break;
                            case "lessorequal":
                                And(x => x.Price <= val);
                                break;
                            case "greater":
                                And(x => x.Price > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Price >= val);
                                break;
                            default:
                                And(x => x.Price == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "Remark"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Remark.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Description"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Description.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "InputUser"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InputUser.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "CarrierId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CarrierId == val);
                                break;
                            case "notequal":
                                And(x => x.CarrierId != val);
                                break;
                            case "less":
                                And(x => x.CarrierId < val);
                                break;
                            case "lessorequal":
                                And(x => x.CarrierId <= val);
                                break;
                            case "greater":
                                And(x => x.CarrierId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CarrierId >= val);
                                break;
                            default:
                                And(x => x.CarrierId == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "CompanyId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CompanyId == val);
                                break;
                            case "notequal":
                                And(x => x.CompanyId != val);
                                break;
                            case "less":
                                And(x => x.CompanyId < val);
                                break;
                            case "lessorequal":
                                And(x => x.CompanyId <= val);
                                break;
                            case "greater":
                                And(x => x.CompanyId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CompanyId >= val);
                                break;
                            default:
                                And(x => x.CompanyId == val);
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



                 public  LineQuotesQuery ByCarrierIdWithfilter(int carrierid, IEnumerable<filterRule> filters)
         {
            And(x => x.CarrierId == carrierid);
            
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
				    
					
					
				    				
											if (rule.field == "Name"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Name.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Location1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location1.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Location2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location2.Contains(rule.value));
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
				    
					
					
				    				
											if (rule.field == "PiceVehicleType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PiceVehicleType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "PiceType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PiceType.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "Price" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Price == val);
                                break;
                            case "notequal":
                                And(x => x.Price != val);
                                break;
                            case "less":
                                And(x => x.Price < val);
                                break;
                            case "lessorequal":
                                And(x => x.Price <= val);
                                break;
                            case "greater":
                                And(x => x.Price > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Price >= val);
                                break;
                            default:
                                And(x => x.Price == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "Remark"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Remark.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Description"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Description.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "InputUser"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InputUser.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "CarrierId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CarrierId == val);
                                break;
                            case "notequal":
                                And(x => x.CarrierId != val);
                                break;
                            case "less":
                                And(x => x.CarrierId < val);
                                break;
                            case "lessorequal":
                                And(x => x.CarrierId <= val);
                                break;
                            case "greater":
                                And(x => x.CarrierId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CarrierId >= val);
                                break;
                            default:
                                And(x => x.CarrierId == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "CompanyId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CompanyId == val);
                                break;
                            case "notequal":
                                And(x => x.CompanyId != val);
                                break;
                            case "less":
                                And(x => x.CompanyId < val);
                                break;
                            case "lessorequal":
                                And(x => x.CompanyId <= val);
                                break;
                            case "greater":
                                And(x => x.CompanyId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CompanyId >= val);
                                break;
                            default:
                                And(x => x.CompanyId == val);
                                break;
                        }
						}
				    
					
					
				    				
               }
            }
            return this;
         }
             
                 public  LineQuotesQuery ByCompanyIdWithfilter(int companyid, IEnumerable<filterRule> filters)
         {
            And(x => x.CompanyId == companyid);
            
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
				    
					
					
				    				
											if (rule.field == "Name"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Name.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Location1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location1.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Location2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Location2.Contains(rule.value));
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
				    
					
					
				    				
											if (rule.field == "PiceVehicleType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PiceVehicleType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "PiceType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PiceType.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "Price" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Price == val);
                                break;
                            case "notequal":
                                And(x => x.Price != val);
                                break;
                            case "less":
                                And(x => x.Price < val);
                                break;
                            case "lessorequal":
                                And(x => x.Price <= val);
                                break;
                            case "greater":
                                And(x => x.Price > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Price >= val);
                                break;
                            default:
                                And(x => x.Price == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "Remark"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Remark.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Description"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Description.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "InputUser"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InputUser.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "CarrierId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CarrierId == val);
                                break;
                            case "notequal":
                                And(x => x.CarrierId != val);
                                break;
                            case "less":
                                And(x => x.CarrierId < val);
                                break;
                            case "lessorequal":
                                And(x => x.CarrierId <= val);
                                break;
                            case "greater":
                                And(x => x.CarrierId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CarrierId >= val);
                                break;
                            default:
                                And(x => x.CarrierId == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "CompanyId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CompanyId == val);
                                break;
                            case "notequal":
                                And(x => x.CompanyId != val);
                                break;
                            case "less":
                                And(x => x.CompanyId < val);
                                break;
                            case "lessorequal":
                                And(x => x.CompanyId <= val);
                                break;
                            case "greater":
                                And(x => x.CompanyId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CompanyId >= val);
                                break;
                            default:
                                And(x => x.CompanyId == val);
                                break;
                        }
						}
				    
					
					
				    				
               }
            }
            return this;
         }
             
            }
}



