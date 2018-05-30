// <copyright file="CompanyQuery.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/30/2018 8:46:44 AM </date>
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
   public class CompanyQuery:QueryObject<Company>
    {
        public CompanyQuery WithAnySearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.Name.Contains(search) || x.Address.Contains(search) || x.RegisteredCapital.ToString().Contains(search) || x.UnifiedSocialCreditldentifier.Contains(search) || x.UnifiedSocialDatetime.ToString().Contains(search) || x.BusinessScope.Contains(search) || x.BusinessLicenseStartDatetime.ToString().Contains(search) || x.BusinessLicenseendDatetime.ToString().Contains(search) || x.CountrySubdivisionCode.Contains(search) || x.PermitNumber.Contains(search) || x.LegalPersonName.Contains(search) || x.LegalPersonTelehoneNumber.Contains(search) || x.ContactName.Contains(search) || x.ContactMobileTelephoneNumber.Contains(search) || x.FaxNumber.Contains(search) || x.InternetPlusProperty.Contains(search) || x.SynchronizationTime.ToString().Contains(search) );
            return this;
        }


		public CompanyQuery Withfilter(IEnumerable<filterRule> filters)
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
				    
				    
					
					
				    				
											if (rule.field == "Address"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Address.Contains(rule.value));
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
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "UnifiedSocialDatetime" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.UnifiedSocialDatetime) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.UnifiedSocialDatetime) <= 0);
						    }
						}
				   
				    				
											if (rule.field == "BusinessScope"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.BusinessScope.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "BusinessLicenseStartDatetime" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.BusinessLicenseStartDatetime) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.BusinessLicenseStartDatetime) <= 0);
						    }
						}
				   
				    				
					
				    
					
											if (rule.field == "BusinessLicenseendDatetime" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.BusinessLicenseendDatetime) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.BusinessLicenseendDatetime) <= 0);
						    }
						}
				   
				    				
											if (rule.field == "CountrySubdivisionCode"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CountrySubdivisionCode.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "PermitNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PermitNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LegalPersonName"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LegalPersonName.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LegalPersonTelehoneNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LegalPersonTelehoneNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ContactName"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ContactName.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ContactMobileTelephoneNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ContactMobileTelephoneNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "FaxNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.FaxNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "InternetPlusProperty"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InternetPlusProperty.Contains(rule.value));
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



            }
}



