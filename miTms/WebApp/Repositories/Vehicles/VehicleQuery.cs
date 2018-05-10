// <copyright file="VehicleQuery.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 1:00:28 PM </date>
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
   public class VehicleQuery:QueryObject<Vehicle>
    {
        public VehicleQuery WithAnySearch(string search)
        {
            if (!string.IsNullOrEmpty(search))
                And( x =>  x.Id.ToString().Contains(search) || x.OrderNo.Contains(search) || x.ExternalNo.Contains(search) || x.UsingDate.ToString().Contains(search) || x.Location1.Contains(search) || x.Location2.Contains(search) || x.Requirements.Contains(search) || x.PlateNumber.Contains(search) || x.PlateNumberPosition.Contains(search) || x.VehStatus.Contains(search) || x.CarType.Contains(search) || x.VehicleType.Contains(search) || x.VehicleProperty.Contains(search) || x.CompanyId.ToString().Contains(search) || x.Axles.ToString().Contains(search) || x.ECOMark.Contains(search) || x.StrLoadWeight.ToString().Contains(search) || x.LoadWeight.ToString().Contains(search) || x.LoadVolume.ToString().Contains(search) || x.CarriageSize.ToString().Contains(search) || x.Driver.Contains(search) || x.DriverPhone.Contains(search) || x.AssistantDriver.Contains(search) || x.AssistantDriverPhone.Contains(search) || x.VehLongSize.ToString().Contains(search) || x.CubicleType.Contains(search) || x.VehUseType.Contains(search) || x.CustomsNo.Contains(search) || x.VehUse.Contains(search) || x.AVGECON.ToString().Contains(search) || x.AVGECONScale.ToString().Contains(search) || x.RoadKM.ToString().Contains(search) || x.RoadHours.ToString().Contains(search) || x.RoadKMScale.ToString().Contains(search) || x.GPSDeviceId.Contains(search) || x.Owner.Contains(search) || x.OwnerContactPhone.Contains(search) || x.Brand.Contains(search) || x.RPM.ToString().Contains(search) || x.PurchasedDate.ToString().Contains(search) || x.PurchasedAmount.ToString().Contains(search) || x.VehLong.ToString().Contains(search) || x.VehWide.ToString().Contains(search) || x.VehHigh.ToString().Contains(search) || x.VIN.Contains(search) || x.ServiceLife.ToString().Contains(search) || x.MaintainKM.ToString().Contains(search) || x.MaintainDate.ToString().Contains(search) || x.MaintainMonth.ToString().Contains(search) || x.VehTailBoardBrand.Contains(search) || x.VehTailBoardFactory.Contains(search) || x.VehTailBoardLife.ToString().Contains(search) || x.VehTailBoardAmount.ToString().Contains(search) || x.VehTailBoardGPSDeviceId.Contains(search) || x.DrLicenseModel.Contains(search) || x.DrLicenseUseNature.Contains(search) || x.DrLicenseBrand.Contains(search) || x.DrLicenseDevId.Contains(search) || x.DrLicenseEngineId.Contains(search) || x.DrLicenseRegistrationDate.ToString().Contains(search) || x.DrLicensePubDate.ToString().Contains(search) || x.DrLicenseRatedUsers.ToString().Contains(search) || x.DrLicenseVehWeight.ToString().Contains(search) || x.DrLicenseDevWeight.ToString().Contains(search) || x.DrLicenseNetWeight.ToString().Contains(search) || x.DrLicenseNetVolume.ToString().Contains(search) || x.DrLicenseVehWide.ToString().Contains(search) || x.DrLicenseVehHigh.ToString().Contains(search) || x.DrLicenseVehLong.ToString().Contains(search) || x.DrLicenseScrapedDate.ToString().Contains(search) || x.LoLicenseManageId.Contains(search) || x.LoLicenseId.Contains(search) || x.LoLicenseBusinessScope.Contains(search) || x.LoLicensePubDate.ToString().Contains(search) || x.LoLicenseValidDate.ToString().Contains(search) || x.LoLicenseCheckDate.ToString().Contains(search) || x.LoLicensePlace.Contains(search) || x.InsTrafficPolicyId.Contains(search) || x.InsTrafficPolicyCompany.Contains(search) || x.InsTrafficPolicyVaildateDate.Contains(search) || x.InsTrafficPolicyAmount.ToString().Contains(search) || x.InsThirdPartyId.Contains(search) || x.InsThirdPartyVaildateDate.ToString().Contains(search) || x.InsThirdPartyAmount.ToString().Contains(search) || x.InsThirdPartyLogisticsAmount.ToString().Contains(search) || x.InsThirdPartyLogisticsVaildateDate.ToString().Contains(search) || x.Status.Contains(search) );
            return this;
        }


		public VehicleQuery Withfilter(IEnumerable<filterRule> filters)
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
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "UsingDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.UsingDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.UsingDate) <= 0);
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
				    
				    
					
					
				    				
											if (rule.field == "PlateNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PlateNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "PlateNumberPosition"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PlateNumberPosition.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "VehStatus"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehStatus.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "CarType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CarType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "VehicleType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehicleType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "VehicleProperty"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehicleProperty.Contains(rule.value));
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
				    
					
					
				    				
					
				    						if (rule.field == "Axles" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Axles == val);
                                break;
                            case "notequal":
                                And(x => x.Axles != val);
                                break;
                            case "less":
                                And(x => x.Axles < val);
                                break;
                            case "lessorequal":
                                And(x => x.Axles <= val);
                                break;
                            case "greater":
                                And(x => x.Axles > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Axles >= val);
                                break;
                            default:
                                And(x => x.Axles == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "ECOMark"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ECOMark.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "StrLoadWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.StrLoadWeight == val);
                                break;
                            case "notequal":
                                And(x => x.StrLoadWeight != val);
                                break;
                            case "less":
                                And(x => x.StrLoadWeight < val);
                                break;
                            case "lessorequal":
                                And(x => x.StrLoadWeight <= val);
                                break;
                            case "greater":
                                And(x => x.StrLoadWeight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.StrLoadWeight >= val);
                                break;
                            default:
                                And(x => x.StrLoadWeight == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "LoadWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.LoadWeight == val);
                                break;
                            case "notequal":
                                And(x => x.LoadWeight != val);
                                break;
                            case "less":
                                And(x => x.LoadWeight < val);
                                break;
                            case "lessorequal":
                                And(x => x.LoadWeight <= val);
                                break;
                            case "greater":
                                And(x => x.LoadWeight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.LoadWeight >= val);
                                break;
                            default:
                                And(x => x.LoadWeight == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "LoadVolume" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.LoadVolume == val);
                                break;
                            case "notequal":
                                And(x => x.LoadVolume != val);
                                break;
                            case "less":
                                And(x => x.LoadVolume < val);
                                break;
                            case "lessorequal":
                                And(x => x.LoadVolume <= val);
                                break;
                            case "greater":
                                And(x => x.LoadVolume > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.LoadVolume >= val);
                                break;
                            default:
                                And(x => x.LoadVolume == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
											if (rule.field == "CarriageSize" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CarriageSize == val);
                                break;
                            case "notequal":
                                And(x => x.CarriageSize != val);
                                break;
                            case "less":
                                And(x => x.CarriageSize < val);
                                break;
                            case "lessorequal":
                                And(x => x.CarriageSize <= val);
                                break;
                            case "greater":
                                And(x => x.CarriageSize > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CarriageSize >= val);
                                break;
                            default:
                                And(x => x.CarriageSize == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "Driver"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Driver.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DriverPhone"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DriverPhone.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "AssistantDriver"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.AssistantDriver.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "AssistantDriverPhone"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.AssistantDriverPhone.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "VehLongSize" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehLongSize == val);
                                break;
                            case "notequal":
                                And(x => x.VehLongSize != val);
                                break;
                            case "less":
                                And(x => x.VehLongSize < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehLongSize <= val);
                                break;
                            case "greater":
                                And(x => x.VehLongSize > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehLongSize >= val);
                                break;
                            default:
                                And(x => x.VehLongSize == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "CubicleType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CubicleType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "VehUseType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehUseType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "CustomsNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CustomsNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "VehUse"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehUse.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "AVGECON" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.AVGECON == val);
                                break;
                            case "notequal":
                                And(x => x.AVGECON != val);
                                break;
                            case "less":
                                And(x => x.AVGECON < val);
                                break;
                            case "lessorequal":
                                And(x => x.AVGECON <= val);
                                break;
                            case "greater":
                                And(x => x.AVGECON > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.AVGECON >= val);
                                break;
                            default:
                                And(x => x.AVGECON == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "AVGECONScale" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.AVGECONScale == val);
                                break;
                            case "notequal":
                                And(x => x.AVGECONScale != val);
                                break;
                            case "less":
                                And(x => x.AVGECONScale < val);
                                break;
                            case "lessorequal":
                                And(x => x.AVGECONScale <= val);
                                break;
                            case "greater":
                                And(x => x.AVGECONScale > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.AVGECONScale >= val);
                                break;
                            default:
                                And(x => x.AVGECONScale == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "RoadKM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.RoadKM == val);
                                break;
                            case "notequal":
                                And(x => x.RoadKM != val);
                                break;
                            case "less":
                                And(x => x.RoadKM < val);
                                break;
                            case "lessorequal":
                                And(x => x.RoadKM <= val);
                                break;
                            case "greater":
                                And(x => x.RoadKM > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.RoadKM >= val);
                                break;
                            default:
                                And(x => x.RoadKM == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "RoadHours" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.RoadHours == val);
                                break;
                            case "notequal":
                                And(x => x.RoadHours != val);
                                break;
                            case "less":
                                And(x => x.RoadHours < val);
                                break;
                            case "lessorequal":
                                And(x => x.RoadHours <= val);
                                break;
                            case "greater":
                                And(x => x.RoadHours > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.RoadHours >= val);
                                break;
                            default:
                                And(x => x.RoadHours == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "RoadKMScale" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.RoadKMScale == val);
                                break;
                            case "notequal":
                                And(x => x.RoadKMScale != val);
                                break;
                            case "less":
                                And(x => x.RoadKMScale < val);
                                break;
                            case "lessorequal":
                                And(x => x.RoadKMScale <= val);
                                break;
                            case "greater":
                                And(x => x.RoadKMScale > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.RoadKMScale >= val);
                                break;
                            default:
                                And(x => x.RoadKMScale == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "GPSDeviceId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.GPSDeviceId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Owner"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Owner.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "OwnerContactPhone"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.OwnerContactPhone.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Brand"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Brand.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "RPM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.RPM == val);
                                break;
                            case "notequal":
                                And(x => x.RPM != val);
                                break;
                            case "less":
                                And(x => x.RPM < val);
                                break;
                            case "lessorequal":
                                And(x => x.RPM <= val);
                                break;
                            case "greater":
                                And(x => x.RPM > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.RPM >= val);
                                break;
                            default:
                                And(x => x.RPM == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
					
											if (rule.field == "PurchasedDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.PurchasedDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.PurchasedDate) <= 0);
						    }
						}
				   
				    				
					
				    
											if (rule.field == "PurchasedAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.PurchasedAmount == val);
                                break;
                            case "notequal":
                                And(x => x.PurchasedAmount != val);
                                break;
                            case "less":
                                And(x => x.PurchasedAmount < val);
                                break;
                            case "lessorequal":
                                And(x => x.PurchasedAmount <= val);
                                break;
                            case "greater":
                                And(x => x.PurchasedAmount > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.PurchasedAmount >= val);
                                break;
                            default:
                                And(x => x.PurchasedAmount == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "VehLong" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehLong == val);
                                break;
                            case "notequal":
                                And(x => x.VehLong != val);
                                break;
                            case "less":
                                And(x => x.VehLong < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehLong <= val);
                                break;
                            case "greater":
                                And(x => x.VehLong > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehLong >= val);
                                break;
                            default:
                                And(x => x.VehLong == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "VehWide" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehWide == val);
                                break;
                            case "notequal":
                                And(x => x.VehWide != val);
                                break;
                            case "less":
                                And(x => x.VehWide < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehWide <= val);
                                break;
                            case "greater":
                                And(x => x.VehWide > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehWide >= val);
                                break;
                            default:
                                And(x => x.VehWide == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "VehHigh" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehHigh == val);
                                break;
                            case "notequal":
                                And(x => x.VehHigh != val);
                                break;
                            case "less":
                                And(x => x.VehHigh < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehHigh <= val);
                                break;
                            case "greater":
                                And(x => x.VehHigh > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehHigh >= val);
                                break;
                            default:
                                And(x => x.VehHigh == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "VIN"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VIN.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "ServiceLife" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.ServiceLife == val);
                                break;
                            case "notequal":
                                And(x => x.ServiceLife != val);
                                break;
                            case "less":
                                And(x => x.ServiceLife < val);
                                break;
                            case "lessorequal":
                                And(x => x.ServiceLife <= val);
                                break;
                            case "greater":
                                And(x => x.ServiceLife > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.ServiceLife >= val);
                                break;
                            default:
                                And(x => x.ServiceLife == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "MaintainKM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.MaintainKM == val);
                                break;
                            case "notequal":
                                And(x => x.MaintainKM != val);
                                break;
                            case "less":
                                And(x => x.MaintainKM < val);
                                break;
                            case "lessorequal":
                                And(x => x.MaintainKM <= val);
                                break;
                            case "greater":
                                And(x => x.MaintainKM > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.MaintainKM >= val);
                                break;
                            default:
                                And(x => x.MaintainKM == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
					
											if (rule.field == "MaintainDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.MaintainDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.MaintainDate) <= 0);
						    }
						}
				   
				    				
					
				    						if (rule.field == "MaintainMonth" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.MaintainMonth == val);
                                break;
                            case "notequal":
                                And(x => x.MaintainMonth != val);
                                break;
                            case "less":
                                And(x => x.MaintainMonth < val);
                                break;
                            case "lessorequal":
                                And(x => x.MaintainMonth <= val);
                                break;
                            case "greater":
                                And(x => x.MaintainMonth > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.MaintainMonth >= val);
                                break;
                            default:
                                And(x => x.MaintainMonth == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
					
					
				    						if (rule.field == "ExistVehTailBoard" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.ExistVehTailBoard == boolval);
						}
				   				
											if (rule.field == "VehTailBoardBrand"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehTailBoardBrand.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "VehTailBoardFactory"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehTailBoardFactory.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "VehTailBoardLife" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehTailBoardLife == val);
                                break;
                            case "notequal":
                                And(x => x.VehTailBoardLife != val);
                                break;
                            case "less":
                                And(x => x.VehTailBoardLife < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehTailBoardLife <= val);
                                break;
                            case "greater":
                                And(x => x.VehTailBoardLife > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehTailBoardLife >= val);
                                break;
                            default:
                                And(x => x.VehTailBoardLife == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
											if (rule.field == "VehTailBoardAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehTailBoardAmount == val);
                                break;
                            case "notequal":
                                And(x => x.VehTailBoardAmount != val);
                                break;
                            case "less":
                                And(x => x.VehTailBoardAmount < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehTailBoardAmount <= val);
                                break;
                            case "greater":
                                And(x => x.VehTailBoardAmount > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehTailBoardAmount >= val);
                                break;
                            default:
                                And(x => x.VehTailBoardAmount == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "VehTailBoardGPSDeviceId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehTailBoardGPSDeviceId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DrLicenseModel"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DrLicenseModel.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DrLicenseUseNature"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DrLicenseUseNature.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DrLicenseBrand"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DrLicenseBrand.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DrLicenseDevId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DrLicenseDevId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DrLicenseEngineId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DrLicenseEngineId.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "DrLicenseRegistrationDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.DrLicenseRegistrationDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.DrLicenseRegistrationDate) <= 0);
						    }
						}
				   
				    				
					
				    
					
											if (rule.field == "DrLicensePubDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.DrLicensePubDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.DrLicensePubDate) <= 0);
						    }
						}
				   
				    				
					
				    						if (rule.field == "DrLicenseRatedUsers" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseRatedUsers == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseRatedUsers != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseRatedUsers < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseRatedUsers <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseRatedUsers > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseRatedUsers >= val);
                                break;
                            default:
                                And(x => x.DrLicenseRatedUsers == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
											if (rule.field == "DrLicenseVehWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseVehWeight == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseVehWeight != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseVehWeight < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseVehWeight <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseVehWeight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseVehWeight >= val);
                                break;
                            default:
                                And(x => x.DrLicenseVehWeight == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "DrLicenseDevWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseDevWeight == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseDevWeight != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseDevWeight < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseDevWeight <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseDevWeight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseDevWeight >= val);
                                break;
                            default:
                                And(x => x.DrLicenseDevWeight == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "DrLicenseNetWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseNetWeight == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseNetWeight != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseNetWeight < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseNetWeight <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseNetWeight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseNetWeight >= val);
                                break;
                            default:
                                And(x => x.DrLicenseNetWeight == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "DrLicenseNetVolume" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseNetVolume == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseNetVolume != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseNetVolume < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseNetVolume <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseNetVolume > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseNetVolume >= val);
                                break;
                            default:
                                And(x => x.DrLicenseNetVolume == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "DrLicenseVehWide" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseVehWide == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseVehWide != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseVehWide < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseVehWide <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseVehWide > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseVehWide >= val);
                                break;
                            default:
                                And(x => x.DrLicenseVehWide == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "DrLicenseVehHigh" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseVehHigh == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseVehHigh != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseVehHigh < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseVehHigh <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseVehHigh > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseVehHigh >= val);
                                break;
                            default:
                                And(x => x.DrLicenseVehHigh == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "DrLicenseVehLong" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseVehLong == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseVehLong != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseVehLong < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseVehLong <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseVehLong > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseVehLong >= val);
                                break;
                            default:
                                And(x => x.DrLicenseVehLong == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
					
											if (rule.field == "DrLicenseScrapedDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.DrLicenseScrapedDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.DrLicenseScrapedDate) <= 0);
						    }
						}
				   
				    				
											if (rule.field == "LoLicenseManageId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LoLicenseManageId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LoLicenseId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LoLicenseId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LoLicenseBusinessScope"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LoLicenseBusinessScope.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "LoLicensePubDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.LoLicensePubDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.LoLicensePubDate) <= 0);
						    }
						}
				   
				    				
					
				    
					
											if (rule.field == "LoLicenseValidDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.LoLicenseValidDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.LoLicenseValidDate) <= 0);
						    }
						}
				   
				    				
					
				    
					
											if (rule.field == "LoLicenseCheckDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.LoLicenseCheckDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.LoLicenseCheckDate) <= 0);
						    }
						}
				   
				    				
											if (rule.field == "LoLicensePlace"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LoLicensePlace.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "InsTrafficPolicyId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InsTrafficPolicyId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "InsTrafficPolicyCompany"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InsTrafficPolicyCompany.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "InsTrafficPolicyVaildateDate"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InsTrafficPolicyVaildateDate.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "InsTrafficPolicyAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.InsTrafficPolicyAmount == val);
                                break;
                            case "notequal":
                                And(x => x.InsTrafficPolicyAmount != val);
                                break;
                            case "less":
                                And(x => x.InsTrafficPolicyAmount < val);
                                break;
                            case "lessorequal":
                                And(x => x.InsTrafficPolicyAmount <= val);
                                break;
                            case "greater":
                                And(x => x.InsTrafficPolicyAmount > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.InsTrafficPolicyAmount >= val);
                                break;
                            default:
                                And(x => x.InsTrafficPolicyAmount == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "InsThirdPartyId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InsThirdPartyId.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "InsThirdPartyVaildateDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.InsThirdPartyVaildateDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.InsThirdPartyVaildateDate) <= 0);
						    }
						}
				   
				    				
					
				    
											if (rule.field == "InsThirdPartyAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.InsThirdPartyAmount == val);
                                break;
                            case "notequal":
                                And(x => x.InsThirdPartyAmount != val);
                                break;
                            case "less":
                                And(x => x.InsThirdPartyAmount < val);
                                break;
                            case "lessorequal":
                                And(x => x.InsThirdPartyAmount <= val);
                                break;
                            case "greater":
                                And(x => x.InsThirdPartyAmount > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.InsThirdPartyAmount >= val);
                                break;
                            default:
                                And(x => x.InsThirdPartyAmount == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "InsThirdPartyLogisticsAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.InsThirdPartyLogisticsAmount == val);
                                break;
                            case "notequal":
                                And(x => x.InsThirdPartyLogisticsAmount != val);
                                break;
                            case "less":
                                And(x => x.InsThirdPartyLogisticsAmount < val);
                                break;
                            case "lessorequal":
                                And(x => x.InsThirdPartyLogisticsAmount <= val);
                                break;
                            case "greater":
                                And(x => x.InsThirdPartyLogisticsAmount > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.InsThirdPartyLogisticsAmount >= val);
                                break;
                            default:
                                And(x => x.InsThirdPartyLogisticsAmount == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
					
											if (rule.field == "InsThirdPartyLogisticsVaildateDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.InsThirdPartyLogisticsVaildateDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.InsThirdPartyLogisticsVaildateDate) <= 0);
						    }
						}
				   
				    				
											if (rule.field == "Status"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Status.Contains(rule.value));
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



                 public  VehicleQuery ByCompanyIdWithfilter(int companyid, IEnumerable<filterRule> filters)
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
				    
					
					
				    				
											if (rule.field == "OrderNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.OrderNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "ExternalNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ExternalNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "UsingDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.UsingDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.UsingDate) <= 0);
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
				    
				    
					
					
				    				
											if (rule.field == "PlateNumber"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PlateNumber.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "PlateNumberPosition"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PlateNumberPosition.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "VehStatus"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehStatus.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "CarType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CarType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "VehicleType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehicleType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "VehicleProperty"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehicleProperty.Contains(rule.value));
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
				    
					
					
				    				
					
				    						if (rule.field == "Axles" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Axles == val);
                                break;
                            case "notequal":
                                And(x => x.Axles != val);
                                break;
                            case "less":
                                And(x => x.Axles < val);
                                break;
                            case "lessorequal":
                                And(x => x.Axles <= val);
                                break;
                            case "greater":
                                And(x => x.Axles > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Axles >= val);
                                break;
                            default:
                                And(x => x.Axles == val);
                                break;
                        }
						}
				    
					
					
				    				
											if (rule.field == "ECOMark"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ECOMark.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "StrLoadWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.StrLoadWeight == val);
                                break;
                            case "notequal":
                                And(x => x.StrLoadWeight != val);
                                break;
                            case "less":
                                And(x => x.StrLoadWeight < val);
                                break;
                            case "lessorequal":
                                And(x => x.StrLoadWeight <= val);
                                break;
                            case "greater":
                                And(x => x.StrLoadWeight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.StrLoadWeight >= val);
                                break;
                            default:
                                And(x => x.StrLoadWeight == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "LoadWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.LoadWeight == val);
                                break;
                            case "notequal":
                                And(x => x.LoadWeight != val);
                                break;
                            case "less":
                                And(x => x.LoadWeight < val);
                                break;
                            case "lessorequal":
                                And(x => x.LoadWeight <= val);
                                break;
                            case "greater":
                                And(x => x.LoadWeight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.LoadWeight >= val);
                                break;
                            default:
                                And(x => x.LoadWeight == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "LoadVolume" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.LoadVolume == val);
                                break;
                            case "notequal":
                                And(x => x.LoadVolume != val);
                                break;
                            case "less":
                                And(x => x.LoadVolume < val);
                                break;
                            case "lessorequal":
                                And(x => x.LoadVolume <= val);
                                break;
                            case "greater":
                                And(x => x.LoadVolume > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.LoadVolume >= val);
                                break;
                            default:
                                And(x => x.LoadVolume == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
											if (rule.field == "CarriageSize" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CarriageSize == val);
                                break;
                            case "notequal":
                                And(x => x.CarriageSize != val);
                                break;
                            case "less":
                                And(x => x.CarriageSize < val);
                                break;
                            case "lessorequal":
                                And(x => x.CarriageSize <= val);
                                break;
                            case "greater":
                                And(x => x.CarriageSize > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CarriageSize >= val);
                                break;
                            default:
                                And(x => x.CarriageSize == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "Driver"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Driver.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DriverPhone"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DriverPhone.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "AssistantDriver"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.AssistantDriver.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "AssistantDriverPhone"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.AssistantDriverPhone.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "VehLongSize" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehLongSize == val);
                                break;
                            case "notequal":
                                And(x => x.VehLongSize != val);
                                break;
                            case "less":
                                And(x => x.VehLongSize < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehLongSize <= val);
                                break;
                            case "greater":
                                And(x => x.VehLongSize > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehLongSize >= val);
                                break;
                            default:
                                And(x => x.VehLongSize == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "CubicleType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CubicleType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "VehUseType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehUseType.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "CustomsNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CustomsNo.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "VehUse"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehUse.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "AVGECON" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.AVGECON == val);
                                break;
                            case "notequal":
                                And(x => x.AVGECON != val);
                                break;
                            case "less":
                                And(x => x.AVGECON < val);
                                break;
                            case "lessorequal":
                                And(x => x.AVGECON <= val);
                                break;
                            case "greater":
                                And(x => x.AVGECON > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.AVGECON >= val);
                                break;
                            default:
                                And(x => x.AVGECON == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "AVGECONScale" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.AVGECONScale == val);
                                break;
                            case "notequal":
                                And(x => x.AVGECONScale != val);
                                break;
                            case "less":
                                And(x => x.AVGECONScale < val);
                                break;
                            case "lessorequal":
                                And(x => x.AVGECONScale <= val);
                                break;
                            case "greater":
                                And(x => x.AVGECONScale > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.AVGECONScale >= val);
                                break;
                            default:
                                And(x => x.AVGECONScale == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "RoadKM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.RoadKM == val);
                                break;
                            case "notequal":
                                And(x => x.RoadKM != val);
                                break;
                            case "less":
                                And(x => x.RoadKM < val);
                                break;
                            case "lessorequal":
                                And(x => x.RoadKM <= val);
                                break;
                            case "greater":
                                And(x => x.RoadKM > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.RoadKM >= val);
                                break;
                            default:
                                And(x => x.RoadKM == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "RoadHours" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.RoadHours == val);
                                break;
                            case "notequal":
                                And(x => x.RoadHours != val);
                                break;
                            case "less":
                                And(x => x.RoadHours < val);
                                break;
                            case "lessorequal":
                                And(x => x.RoadHours <= val);
                                break;
                            case "greater":
                                And(x => x.RoadHours > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.RoadHours >= val);
                                break;
                            default:
                                And(x => x.RoadHours == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "RoadKMScale" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.RoadKMScale == val);
                                break;
                            case "notequal":
                                And(x => x.RoadKMScale != val);
                                break;
                            case "less":
                                And(x => x.RoadKMScale < val);
                                break;
                            case "lessorequal":
                                And(x => x.RoadKMScale <= val);
                                break;
                            case "greater":
                                And(x => x.RoadKMScale > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.RoadKMScale >= val);
                                break;
                            default:
                                And(x => x.RoadKMScale == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "GPSDeviceId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.GPSDeviceId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Owner"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Owner.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "OwnerContactPhone"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.OwnerContactPhone.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "Brand"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Brand.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "RPM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.RPM == val);
                                break;
                            case "notequal":
                                And(x => x.RPM != val);
                                break;
                            case "less":
                                And(x => x.RPM < val);
                                break;
                            case "lessorequal":
                                And(x => x.RPM <= val);
                                break;
                            case "greater":
                                And(x => x.RPM > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.RPM >= val);
                                break;
                            default:
                                And(x => x.RPM == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
					
											if (rule.field == "PurchasedDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.PurchasedDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.PurchasedDate) <= 0);
						    }
                        }
				   
				    				
					
				    
											if (rule.field == "PurchasedAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.PurchasedAmount == val);
                                break;
                            case "notequal":
                                And(x => x.PurchasedAmount != val);
                                break;
                            case "less":
                                And(x => x.PurchasedAmount < val);
                                break;
                            case "lessorequal":
                                And(x => x.PurchasedAmount <= val);
                                break;
                            case "greater":
                                And(x => x.PurchasedAmount > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.PurchasedAmount >= val);
                                break;
                            default:
                                And(x => x.PurchasedAmount == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "VehLong" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehLong == val);
                                break;
                            case "notequal":
                                And(x => x.VehLong != val);
                                break;
                            case "less":
                                And(x => x.VehLong < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehLong <= val);
                                break;
                            case "greater":
                                And(x => x.VehLong > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehLong >= val);
                                break;
                            default:
                                And(x => x.VehLong == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "VehWide" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehWide == val);
                                break;
                            case "notequal":
                                And(x => x.VehWide != val);
                                break;
                            case "less":
                                And(x => x.VehWide < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehWide <= val);
                                break;
                            case "greater":
                                And(x => x.VehWide > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehWide >= val);
                                break;
                            default:
                                And(x => x.VehWide == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "VehHigh" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehHigh == val);
                                break;
                            case "notequal":
                                And(x => x.VehHigh != val);
                                break;
                            case "less":
                                And(x => x.VehHigh < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehHigh <= val);
                                break;
                            case "greater":
                                And(x => x.VehHigh > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehHigh >= val);
                                break;
                            default:
                                And(x => x.VehHigh == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "VIN"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VIN.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "ServiceLife" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.ServiceLife == val);
                                break;
                            case "notequal":
                                And(x => x.ServiceLife != val);
                                break;
                            case "less":
                                And(x => x.ServiceLife < val);
                                break;
                            case "lessorequal":
                                And(x => x.ServiceLife <= val);
                                break;
                            case "greater":
                                And(x => x.ServiceLife > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.ServiceLife >= val);
                                break;
                            default:
                                And(x => x.ServiceLife == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    						if (rule.field == "MaintainKM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.MaintainKM == val);
                                break;
                            case "notequal":
                                And(x => x.MaintainKM != val);
                                break;
                            case "less":
                                And(x => x.MaintainKM < val);
                                break;
                            case "lessorequal":
                                And(x => x.MaintainKM <= val);
                                break;
                            case "greater":
                                And(x => x.MaintainKM > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.MaintainKM >= val);
                                break;
                            default:
                                And(x => x.MaintainKM == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
					
											if (rule.field == "MaintainDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.MaintainDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.MaintainDate) <= 0);
						    }
                        }
				   
				    				
					
				    						if (rule.field == "MaintainMonth" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.MaintainMonth == val);
                                break;
                            case "notequal":
                                And(x => x.MaintainMonth != val);
                                break;
                            case "less":
                                And(x => x.MaintainMonth < val);
                                break;
                            case "lessorequal":
                                And(x => x.MaintainMonth <= val);
                                break;
                            case "greater":
                                And(x => x.MaintainMonth > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.MaintainMonth >= val);
                                break;
                            default:
                                And(x => x.MaintainMonth == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
					
					
				    						if (rule.field == "ExistVehTailBoard" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.ExistVehTailBoard == boolval);
						}
				   				
											if (rule.field == "VehTailBoardBrand"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehTailBoardBrand.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "VehTailBoardFactory"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehTailBoardFactory.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    						if (rule.field == "VehTailBoardLife" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehTailBoardLife == val);
                                break;
                            case "notequal":
                                And(x => x.VehTailBoardLife != val);
                                break;
                            case "less":
                                And(x => x.VehTailBoardLife < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehTailBoardLife <= val);
                                break;
                            case "greater":
                                And(x => x.VehTailBoardLife > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehTailBoardLife >= val);
                                break;
                            default:
                                And(x => x.VehTailBoardLife == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
											if (rule.field == "VehTailBoardAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.VehTailBoardAmount == val);
                                break;
                            case "notequal":
                                And(x => x.VehTailBoardAmount != val);
                                break;
                            case "less":
                                And(x => x.VehTailBoardAmount < val);
                                break;
                            case "lessorequal":
                                And(x => x.VehTailBoardAmount <= val);
                                break;
                            case "greater":
                                And(x => x.VehTailBoardAmount > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.VehTailBoardAmount >= val);
                                break;
                            default:
                                And(x => x.VehTailBoardAmount == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "VehTailBoardGPSDeviceId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.VehTailBoardGPSDeviceId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DrLicenseModel"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DrLicenseModel.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DrLicenseUseNature"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DrLicenseUseNature.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DrLicenseBrand"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DrLicenseBrand.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DrLicenseDevId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DrLicenseDevId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "DrLicenseEngineId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DrLicenseEngineId.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "DrLicenseRegistrationDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.DrLicenseRegistrationDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.DrLicenseRegistrationDate) <= 0);
						    }
                        }
				   
				    				
					
				    
					
											if (rule.field == "DrLicensePubDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.DrLicensePubDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.DrLicensePubDate) <= 0);
						    }
                        }
				   
				    				
					
				    						if (rule.field == "DrLicenseRatedUsers" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseRatedUsers == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseRatedUsers != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseRatedUsers < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseRatedUsers <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseRatedUsers > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseRatedUsers >= val);
                                break;
                            default:
                                And(x => x.DrLicenseRatedUsers == val);
                                break;
                        }
						}
				    
					
					
				    				
					
				    
											if (rule.field == "DrLicenseVehWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseVehWeight == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseVehWeight != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseVehWeight < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseVehWeight <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseVehWeight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseVehWeight >= val);
                                break;
                            default:
                                And(x => x.DrLicenseVehWeight == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "DrLicenseDevWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseDevWeight == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseDevWeight != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseDevWeight < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseDevWeight <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseDevWeight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseDevWeight >= val);
                                break;
                            default:
                                And(x => x.DrLicenseDevWeight == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "DrLicenseNetWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseNetWeight == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseNetWeight != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseNetWeight < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseNetWeight <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseNetWeight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseNetWeight >= val);
                                break;
                            default:
                                And(x => x.DrLicenseNetWeight == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "DrLicenseNetVolume" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseNetVolume == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseNetVolume != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseNetVolume < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseNetVolume <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseNetVolume > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseNetVolume >= val);
                                break;
                            default:
                                And(x => x.DrLicenseNetVolume == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "DrLicenseVehWide" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseVehWide == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseVehWide != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseVehWide < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseVehWide <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseVehWide > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseVehWide >= val);
                                break;
                            default:
                                And(x => x.DrLicenseVehWide == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "DrLicenseVehHigh" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseVehHigh == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseVehHigh != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseVehHigh < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseVehHigh <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseVehHigh > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseVehHigh >= val);
                                break;
                            default:
                                And(x => x.DrLicenseVehHigh == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "DrLicenseVehLong" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.DrLicenseVehLong == val);
                                break;
                            case "notequal":
                                And(x => x.DrLicenseVehLong != val);
                                break;
                            case "less":
                                And(x => x.DrLicenseVehLong < val);
                                break;
                            case "lessorequal":
                                And(x => x.DrLicenseVehLong <= val);
                                break;
                            case "greater":
                                And(x => x.DrLicenseVehLong > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.DrLicenseVehLong >= val);
                                break;
                            default:
                                And(x => x.DrLicenseVehLong == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
					
											if (rule.field == "DrLicenseScrapedDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.DrLicenseScrapedDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.DrLicenseScrapedDate) <= 0);
						    }
                        }
				   
				    				
											if (rule.field == "LoLicenseManageId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LoLicenseManageId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LoLicenseId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LoLicenseId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "LoLicenseBusinessScope"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LoLicenseBusinessScope.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "LoLicensePubDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.LoLicensePubDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.LoLicensePubDate) <= 0);
						    }
                        }
				   
				    				
					
				    
					
											if (rule.field == "LoLicenseValidDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.LoLicenseValidDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.LoLicenseValidDate) <= 0);
						    }
                        }
				   
				    				
					
				    
					
											if (rule.field == "LoLicenseCheckDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.LoLicenseCheckDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.LoLicenseCheckDate) <= 0);
						    }
                        }
				   
				    				
											if (rule.field == "LoLicensePlace"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LoLicensePlace.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "InsTrafficPolicyId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InsTrafficPolicyId.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "InsTrafficPolicyCompany"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InsTrafficPolicyCompany.Contains(rule.value));
						}
				    
				    
					
					
				    				
											if (rule.field == "InsTrafficPolicyVaildateDate"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InsTrafficPolicyVaildateDate.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
											if (rule.field == "InsTrafficPolicyAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.InsTrafficPolicyAmount == val);
                                break;
                            case "notequal":
                                And(x => x.InsTrafficPolicyAmount != val);
                                break;
                            case "less":
                                And(x => x.InsTrafficPolicyAmount < val);
                                break;
                            case "lessorequal":
                                And(x => x.InsTrafficPolicyAmount <= val);
                                break;
                            case "greater":
                                And(x => x.InsTrafficPolicyAmount > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.InsTrafficPolicyAmount >= val);
                                break;
                            default:
                                And(x => x.InsTrafficPolicyAmount == val);
                                break;
                        }
						}
				    
					
				    				
											if (rule.field == "InsThirdPartyId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.InsThirdPartyId.Contains(rule.value));
						}
				    
				    
					
					
				    				
					
				    
					
											if (rule.field == "InsThirdPartyVaildateDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.InsThirdPartyVaildateDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.InsThirdPartyVaildateDate) <= 0);
						    }
                        }
				   
				    				
					
				    
											if (rule.field == "InsThirdPartyAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.InsThirdPartyAmount == val);
                                break;
                            case "notequal":
                                And(x => x.InsThirdPartyAmount != val);
                                break;
                            case "less":
                                And(x => x.InsThirdPartyAmount < val);
                                break;
                            case "lessorequal":
                                And(x => x.InsThirdPartyAmount <= val);
                                break;
                            case "greater":
                                And(x => x.InsThirdPartyAmount > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.InsThirdPartyAmount >= val);
                                break;
                            default:
                                And(x => x.InsThirdPartyAmount == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
											if (rule.field == "InsThirdPartyLogisticsAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.InsThirdPartyLogisticsAmount == val);
                                break;
                            case "notequal":
                                And(x => x.InsThirdPartyLogisticsAmount != val);
                                break;
                            case "less":
                                And(x => x.InsThirdPartyLogisticsAmount < val);
                                break;
                            case "lessorequal":
                                And(x => x.InsThirdPartyLogisticsAmount <= val);
                                break;
                            case "greater":
                                And(x => x.InsThirdPartyLogisticsAmount > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.InsThirdPartyLogisticsAmount >= val);
                                break;
                            default:
                                And(x => x.InsThirdPartyLogisticsAmount == val);
                                break;
                        }
						}
				    
					
				    				
					
				    
					
											if (rule.field == "InsThirdPartyLogisticsVaildateDate" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.InsThirdPartyLogisticsVaildateDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.InsThirdPartyLogisticsVaildateDate) <= 0);
						    }
                        }
				   
				    				
											if (rule.field == "Status"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Status.Contains(rule.value));
						}
				    
				    
					
					
				    				
               }
            }
            return this;
         }
             
            }
}



