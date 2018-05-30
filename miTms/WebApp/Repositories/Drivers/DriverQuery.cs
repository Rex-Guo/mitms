// <copyright file="DriverQuery.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/30/2018 9:35:55 AM </date>
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
   public class DriverQuery:QueryObject<Driver>
    {
        public DriverQuery WithAnySearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.Name.Contains(search) || x.Gender.ToString().Contains(search) || x.IdentityDocumentNumber.Contains(search) || x.MobileTelephoneNumber.Contains(search) || x.TelephoneNumber.Contains(search) || x.QualificationCertificateNumber.Contains(search) || x.Remark.Contains(search) || x.Carrierid.ToString().Contains(search) || x.RegistrationDatetime.ToString().Contains(search) || x.UpdateTimeDatetime.ToString().Contains(search) || x.SynchronizationTime.ToString().Contains(search) || x.CompanyId.ToString().Contains(search) );
            return this;
        }


		public DriverQuery Withfilter(IEnumerable<filterRule> filters)
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
				    
				    
					
					
				    				
					
				    						if (rule.field == "Gender" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Gender == val);
                                break;
                            case "notequal":
                                And(x => x.Gender != val);
                                break;
                            case "less":
                                And(x => x.Gender < val);
                                break;
                            case "lessorequal":
                                And(x => x.Gender <= val);
                                break;
                            case "greater":
                                And(x => x.Gender > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Gender >= val);
                                break;
                            default:
                                And(x => x.Gender == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "IdentityDocumentNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.IdentityDocumentNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "MobileTelephoneNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.MobileTelephoneNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "TelephoneNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.TelephoneNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "QualificationCertificateNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.QualificationCertificateNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Remark"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Remark.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "Carrierid" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Carrierid == val);
                                break;
                            case "notequal":
                                And(x => x.Carrierid != val);
                                break;
                            case "less":
                                And(x => x.Carrierid < val);
                                break;
                            case "lessorequal":
                                And(x => x.Carrierid <= val);
                                break;
                            case "greater":
                                And(x => x.Carrierid > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Carrierid >= val);
                                break;
                            default:
                                And(x => x.Carrierid == val);
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



                 public  DriverQuery ByCarrieridWithfilter(int carrierid, IEnumerable<filterRule> filters)
         {
            And(x => x.Carrierid == carrierid);
            
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
				    
				    
					
					
				    				
					
				    						if (rule.field == "Gender" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Gender == val);
                                break;
                            case "notequal":
                                And(x => x.Gender != val);
                                break;
                            case "less":
                                And(x => x.Gender < val);
                                break;
                            case "lessorequal":
                                And(x => x.Gender <= val);
                                break;
                            case "greater":
                                And(x => x.Gender > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Gender >= val);
                                break;
                            default:
                                And(x => x.Gender == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "IdentityDocumentNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.IdentityDocumentNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "MobileTelephoneNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.MobileTelephoneNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "TelephoneNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.TelephoneNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "QualificationCertificateNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.QualificationCertificateNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Remark"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Remark.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "Carrierid" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Carrierid == val);
                                break;
                            case "notequal":
                                And(x => x.Carrierid != val);
                                break;
                            case "less":
                                And(x => x.Carrierid < val);
                                break;
                            case "lessorequal":
                                And(x => x.Carrierid <= val);
                                break;
                            case "greater":
                                And(x => x.Carrierid > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Carrierid >= val);
                                break;
                            default:
                                And(x => x.Carrierid == val);
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
             
                 public  DriverQuery ByCompanyIdWithfilter(int companyid, IEnumerable<filterRule> filters)
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
				    
				    
					
					
				    				
					
				    						if (rule.field == "Gender" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Gender == val);
                                break;
                            case "notequal":
                                And(x => x.Gender != val);
                                break;
                            case "less":
                                And(x => x.Gender < val);
                                break;
                            case "lessorequal":
                                And(x => x.Gender <= val);
                                break;
                            case "greater":
                                And(x => x.Gender > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Gender >= val);
                                break;
                            default:
                                And(x => x.Gender == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "IdentityDocumentNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.IdentityDocumentNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "MobileTelephoneNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.MobileTelephoneNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "TelephoneNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.TelephoneNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "QualificationCertificateNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.QualificationCertificateNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Remark"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Remark.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "Carrierid" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Carrierid == val);
                                break;
                            case "notequal":
                                And(x => x.Carrierid != val);
                                break;
                            case "less":
                                And(x => x.Carrierid < val);
                                break;
                            case "lessorequal":
                                And(x => x.Carrierid <= val);
                                break;
                            case "greater":
                                And(x => x.Carrierid > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Carrierid >= val);
                                break;
                            default:
                                And(x => x.Carrierid == val);
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



