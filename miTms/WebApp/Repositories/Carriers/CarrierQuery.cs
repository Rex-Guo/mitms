// <copyright file="CarrierQuery.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/30/2018 9:43:49 AM </date>
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
   public class CarrierQuery:QueryObject<Carrier>
    {
        public CarrierQuery WithAnySearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.Name.Contains(search) || x.Type.ToString().Contains(search) || x.ContactName.Contains(search) || x.ContactMobileTelephoneNumber.Contains(search) || x.RegisteredAddress.Contains(search) || x.PermitNumber.Contains(search) || x.CountrySubdivisionCode.Contains(search) || x.RegisteredCapital.ToString().Contains(search) || x.UnifiedSocialCreditldentifier.Contains(search) || x.BusinessScope.Contains(search) || x.Description.Contains(search) || x.LogoPicture.Contains(search) || x.CompanyId.ToString().Contains(search) || x.RegistrationDatetime.ToString().Contains(search) || x.UpdateTimeDatetime.ToString().Contains(search) || x.SynchronizationTime.ToString().Contains(search) );
            return this;
        }


		public CarrierQuery Withfilter(IEnumerable<filterRule> filters)
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
				    
				    
					
					
				    				
					
				    						if (rule.field == "Type" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Type == val);
                                break;
                            case "notequal":
                                And(x => x.Type != val);
                                break;
                            case "less":
                                And(x => x.Type < val);
                                break;
                            case "lessorequal":
                                And(x => x.Type <= val);
                                break;
                            case "greater":
                                And(x => x.Type > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Type >= val);
                                break;
                            default:
                                And(x => x.Type == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "ContactName"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ContactName.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ContactMobileTelephoneNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ContactMobileTelephoneNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "RegisteredAddress"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.RegisteredAddress.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "PermitNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PermitNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "CountrySubdivisionCode"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CountrySubdivisionCode.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "RegisteredCapital" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.RegisteredCapital == val);
                                break;
                            case "notequal":
                                And(x => x.RegisteredCapital != val);
                                break;
                            case "less":
                                And(x => x.RegisteredCapital < val);
                                break;
                            case "lessorequal":
                                And(x => x.RegisteredCapital <= val);
                                break;
                            case "greater":
                                And(x => x.RegisteredCapital > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.RegisteredCapital >= val);
                                break;
                            default:
                                And(x => x.RegisteredCapital == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "UnifiedSocialCreditldentifier"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.UnifiedSocialCreditldentifier.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "BusinessScope"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.BusinessScope.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Description"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Description.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LogoPicture"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LogoPicture.Contains(rule.value));
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
				    
					
					
				    				
					
				    
					
											if (rule.field == "RegistrationDatetime" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.RegistrationDatetime) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.RegistrationDatetime) <= 0);
						    }
						}
				   
				    				
					
				    
					
											if (rule.field == "UpdateTimeDatetime" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.UpdateTimeDatetime) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.UpdateTimeDatetime) <= 0);
						    }
						}
				   
				    				
					
				    
					
					
				    						if (rule.field == "IsBlaclkList" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.IsBlaclkList == boolval);
						}
				   				
					
				    
					
					
				    						if (rule.field == "IsDeleteFlag" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.IsDeleteFlag == boolval);
						}
				   				
					
				    
					
											if (rule.field == "SynchronizationTime" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.SynchronizationTime) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.SynchronizationTime) <= 0);
						    }
						}
				   
				    				
					
				    
					
					
				    						if (rule.field == "IsException" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.IsException == boolval);
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



                 public  CarrierQuery ByCompanyIdWithfilter(int companyid, IEnumerable<filterRule> filters)
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
				    
				    
					
					
				    				
					
				    						if (rule.field == "Type" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Type == val);
                                break;
                            case "notequal":
                                And(x => x.Type != val);
                                break;
                            case "less":
                                And(x => x.Type < val);
                                break;
                            case "lessorequal":
                                And(x => x.Type <= val);
                                break;
                            case "greater":
                                And(x => x.Type > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Type >= val);
                                break;
                            default:
                                And(x => x.Type == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "ContactName"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ContactName.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ContactMobileTelephoneNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ContactMobileTelephoneNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "RegisteredAddress"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.RegisteredAddress.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "PermitNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PermitNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "CountrySubdivisionCode"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CountrySubdivisionCode.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "RegisteredCapital" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.RegisteredCapital == val);
                                break;
                            case "notequal":
                                And(x => x.RegisteredCapital != val);
                                break;
                            case "less":
                                And(x => x.RegisteredCapital < val);
                                break;
                            case "lessorequal":
                                And(x => x.RegisteredCapital <= val);
                                break;
                            case "greater":
                                And(x => x.RegisteredCapital > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.RegisteredCapital >= val);
                                break;
                            default:
                                And(x => x.RegisteredCapital == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "UnifiedSocialCreditldentifier"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.UnifiedSocialCreditldentifier.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "BusinessScope"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.BusinessScope.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Description"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Description.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LogoPicture"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LogoPicture.Contains(rule.value));
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
				    
					
					
				    				
					
				    
					
											if (rule.field == "RegistrationDatetime" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.RegistrationDatetime) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.RegistrationDatetime) <= 0);
						    }
                        }
				   
				    				
					
				    
					
											if (rule.field == "UpdateTimeDatetime" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.UpdateTimeDatetime) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.UpdateTimeDatetime) <= 0);
						    }
                        }
				   
				    				
					
				    
					
					
				    						if (rule.field == "IsBlaclkList" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.IsBlaclkList == boolval);
						}
				   				
					
				    
					
					
				    						if (rule.field == "IsDeleteFlag" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.IsDeleteFlag == boolval);
						}
				   				
					
				    
					
											if (rule.field == "SynchronizationTime" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.SynchronizationTime) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.SynchronizationTime) <= 0);
						    }
                        }
				   
				    				
					
				    
					
					
				    						if (rule.field == "IsException" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.IsException == boolval);
						}
				   				
               }
            }
            return this;
         }
             
            }
}



