// <copyright file="TransactionHistoryQuery.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/14/2018 8:58:18 AM </date>
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
   public class TransactionHistoryQuery:QueryObject<TransactionHistory>
    {
        public TransactionHistoryQuery WithAnySearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.OrderNo.Contains(search) || x.PlateNumber.Contains(search) || x.Status.Contains(search) || x.TransactioDateTime.ToString().Contains(search) || x.Remark.Contains(search) || x.Flag1.ToString().Contains(search) || x.Flag2.ToString().Contains(search) || x.InputUser.Contains(search) || x.Longitude.ToString().Contains(search) || x.Latitude.ToString().Contains(search) || x.PhotographPath.Contains(search) || x.Remark2.Contains(search) );
            return this;
        }


		public TransactionHistoryQuery Withfilter(IEnumerable<filterRule> filters)
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
				    
				    
					
					
				    				
											if (rule.field == "PlateNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PlateNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Status"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Status.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "TransactioDateTime" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.TransactioDateTime) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.TransactioDateTime) <= 0);
						    }
						}
				   
				    				
											if (rule.field == "Remark"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Remark.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "Flag1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Flag1 == val);
                                break;
                            case "notequal":
                                And(x => x.Flag1 != val);
                                break;
                            case "less":
                                And(x => x.Flag1 < val);
                                break;
                            case "lessorequal":
                                And(x => x.Flag1 <= val);
                                break;
                            case "greater":
                                And(x => x.Flag1 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Flag1 >= val);
                                break;
                            default:
                                And(x => x.Flag1 == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "Flag2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Flag2 == val);
                                break;
                            case "notequal":
                                And(x => x.Flag2 != val);
                                break;
                            case "less":
                                And(x => x.Flag2 < val);
                                break;
                            case "lessorequal":
                                And(x => x.Flag2 <= val);
                                break;
                            case "greater":
                                And(x => x.Flag2 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Flag2 >= val);
                                break;
                            default:
                                And(x => x.Flag2 == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "InputUser"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InputUser.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "Longitude" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Longitude == val);
                                break;
                            case "notequal":
                                And(x => x.Longitude != val);
                                break;
                            case "less":
                                And(x => x.Longitude < val);
                                break;
                            case "lessorequal":
                                And(x => x.Longitude <= val);
                                break;
                            case "greater":
                                And(x => x.Longitude > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Longitude >= val);
                                break;
                            default:
                                And(x => x.Longitude == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "Latitude" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Latitude == val);
                                break;
                            case "notequal":
                                And(x => x.Latitude != val);
                                break;
                            case "less":
                                And(x => x.Latitude < val);
                                break;
                            case "lessorequal":
                                And(x => x.Latitude <= val);
                                break;
                            case "greater":
                                And(x => x.Latitude > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Latitude >= val);
                                break;
                            default:
                                And(x => x.Latitude == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "PhotographPath"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PhotographPath.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
					
				    				
											if (rule.field == "Remark2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Remark2.Contains(rule.value));
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



            }
}



