// <copyright file="CustomerQuery.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 12:58:45 PM </date>
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
   public class CustomerQuery:QueryObject<Customer>
    {
        public CustomerQuery WithAnySearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.Name.Contains(search) || x.ServiceUser.Contains(search) || x.TradeType.Contains(search) || x.LegalPerson.Contains(search) || x.RegistrationNumber.Contains(search) || x.LinkMan.Contains(search) || x.PhoneNumber.Contains(search) || x.Email.Contains(search) || x.Fax.Contains(search) || x.CustomerService.Contains(search) || x.Sales.Contains(search) || x.Payment.Contains(search) || x.PaymentDays.ToString().Contains(search) || x.BankName.Contains(search) || x.BankAccount.Contains(search) || x.InvoiceTitle.Contains(search) || x.PaymentNumber.Contains(search) || x.CompanyId.ToString().Contains(search) || x.Address.Contains(search) );
            return this;
        }


		public CustomerQuery Withfilter(IEnumerable<filterRule> filters)
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
				    
				    
					
					
				    				
											if (rule.field == "ServiceUser"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ServiceUser.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "TradeType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.TradeType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LegalPerson"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LegalPerson.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "RegistrationNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.RegistrationNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LinkMan"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LinkMan.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "PhoneNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PhoneNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Email"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Email.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Fax"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Fax.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "CustomerService"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CustomerService.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Sales"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Sales.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Payment"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Payment.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "PaymentDays" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.PaymentDays == val);
                                break;
                            case "notequal":
                                And(x => x.PaymentDays != val);
                                break;
                            case "less":
                                And(x => x.PaymentDays < val);
                                break;
                            case "lessorequal":
                                And(x => x.PaymentDays <= val);
                                break;
                            case "greater":
                                And(x => x.PaymentDays > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.PaymentDays >= val);
                                break;
                            default:
                                And(x => x.PaymentDays == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "BankName"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.BankName.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "BankAccount"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.BankAccount.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "InvoiceTitle"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InvoiceTitle.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "PaymentNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PaymentNumber.Contains(rule.value));
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
				    
					
					
				    				
											if (rule.field == "Address"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Address.Contains(rule.value));
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



                 public  CustomerQuery ByCompanyIdWithfilter(int companyid, IEnumerable<filterRule> filters)
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
				    
				    
					
					
				    				
											if (rule.field == "ServiceUser"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ServiceUser.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "TradeType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.TradeType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LegalPerson"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LegalPerson.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "RegistrationNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.RegistrationNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LinkMan"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LinkMan.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "PhoneNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PhoneNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Email"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Email.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Fax"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Fax.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "CustomerService"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CustomerService.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Sales"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Sales.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Payment"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Payment.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "PaymentDays" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.PaymentDays == val);
                                break;
                            case "notequal":
                                And(x => x.PaymentDays != val);
                                break;
                            case "less":
                                And(x => x.PaymentDays < val);
                                break;
                            case "lessorequal":
                                And(x => x.PaymentDays <= val);
                                break;
                            case "greater":
                                And(x => x.PaymentDays > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.PaymentDays >= val);
                                break;
                            default:
                                And(x => x.PaymentDays == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "BankName"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.BankName.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "BankAccount"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.BankAccount.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "InvoiceTitle"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InvoiceTitle.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "PaymentNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PaymentNumber.Contains(rule.value));
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
				    
					
					
				    				
											if (rule.field == "Address"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Address.Contains(rule.value));
						}
				    
				    
					
					
				    				
               }
            }
            return this;
         }
             
            }
}



