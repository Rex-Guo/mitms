// <copyright file="VehicleService.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 1:00:29 PM </date>
// <summary>
//  实现定义的业务逻辑,通过依赖注入降低模块之间的耦合度
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
using Service.Pattern;
using WebApp.Models;
using WebApp.Repositories;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;

namespace WebApp.Services
{
    public class VehicleService : Service< Vehicle >, IVehicleService
    {

        private readonly IRepositoryAsync<Vehicle> _repository;
		 private readonly IDataTableImportMappingService _mappingservice;
        public  VehicleService(IRepositoryAsync< Vehicle> repository,IDataTableImportMappingService mappingservice)
            : base(repository)
        {
            _repository=repository;
			_mappingservice = mappingservice;
        }
        
                 public  IEnumerable<Vehicle> GetByCompanyId(int  companyid)
         {
            return _repository.GetByCompanyId(companyid);
         }
                   
        

		public void ImportDataTable(System.Data.DataTable datatable)
        {
            foreach (DataRow row in datatable.Rows)
            {
                 
                Vehicle item = new Vehicle();
				var mapping = _mappingservice.Queryable().Where(x => x.EntitySetName == "Vehicle" &&  x.IsEnabled==true).ToList();

                foreach (var field in mapping)
                {
                 
						var defval = field.DefaultValue;
						var contation = datatable.Columns.Contains((field.SourceFieldName == null ? "" : field.SourceFieldName));
						if (contation && row[field.SourceFieldName] != DBNull.Value)
						{
							Type vehicletype = item.GetType();
							PropertyInfo propertyInfo = vehicletype.GetProperty(field.FieldName);
							propertyInfo.SetValue(item, Convert.ChangeType(row[field.SourceFieldName], propertyInfo.PropertyType), null);
						}
						else if (!string.IsNullOrEmpty(defval))
						{
							Type vehicletype = item.GetType();
							PropertyInfo propertyInfo = vehicletype.GetProperty(field.FieldName);
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
		
		public Stream ExportExcel(string filterRules = "",string sort = "Id", string order = "asc")
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
                       			 
            var vehicles  = this.Query(new VehicleQuery().Withfilter(filters)).Include(p => p.Company).OrderBy(n=>n.OrderBy(sort,order)).Select().ToList();
            
                        var datarows = vehicles .Select(  n => new { 
CompanyName = (n.Company==null?"": n.Company.Name) 
 , Id = n.Id 
, OrderNo = n.OrderNo 
, ExternalNo = n.ExternalNo 
, UsingDate = n.UsingDate 
, Location1 = n.Location1 
, Location2 = n.Location2 
, Requirements = n.Requirements 
, PlateNumber = n.PlateNumber 
, PlateNumberPosition = n.PlateNumberPosition 
, VehStatus = n.VehStatus 
, CarType = n.CarType 
, VehicleType = n.VehicleType 
, VehicleProperty = n.VehicleProperty 
, CompanyId = n.CompanyId 
, Axles = n.Axles 
, ECOMark = n.ECOMark 
, StrLoadWeight = n.StrLoadWeight 
, LoadWeight = n.LoadWeight 
, LoadVolume = n.LoadVolume 
, CarriageSize = n.CarriageSize 
, Driver = n.Driver 
, DriverPhone = n.DriverPhone 
, AssistantDriver = n.AssistantDriver 
, AssistantDriverPhone = n.AssistantDriverPhone 
, VehLongSize = n.VehLongSize 
, CubicleType = n.CubicleType 
, VehUseType = n.VehUseType 
, CustomsNo = n.CustomsNo 
, VehUse = n.VehUse 
, AVGECON = n.AVGECON 
, AVGECONScale = n.AVGECONScale 
, RoadKM = n.RoadKM 
, RoadHours = n.RoadHours 
, RoadKMScale = n.RoadKMScale 
, GPSDeviceId = n.GPSDeviceId 
, Owner = n.Owner 
, OwnerContactPhone = n.OwnerContactPhone 
, Brand = n.Brand 
, RPM = n.RPM 
, PurchasedDate = n.PurchasedDate 
, PurchasedAmount = n.PurchasedAmount 
, VehLong = n.VehLong 
, VehWide = n.VehWide 
, VehHigh = n.VehHigh 
, VIN = n.VIN 
, ServiceLife = n.ServiceLife 
, MaintainKM = n.MaintainKM 
, MaintainDate = n.MaintainDate 
, MaintainMonth = n.MaintainMonth 
, ExistVehTailBoard = n.ExistVehTailBoard 
, VehTailBoardBrand = n.VehTailBoardBrand 
, VehTailBoardFactory = n.VehTailBoardFactory 
, VehTailBoardLife = n.VehTailBoardLife 
, VehTailBoardAmount = n.VehTailBoardAmount 
, VehTailBoardGPSDeviceId = n.VehTailBoardGPSDeviceId 
, DrLicenseModel = n.DrLicenseModel 
, DrLicenseUseNature = n.DrLicenseUseNature 
, DrLicenseBrand = n.DrLicenseBrand 
, DrLicenseDevId = n.DrLicenseDevId 
, DrLicenseEngineId = n.DrLicenseEngineId 
, DrLicenseRegistrationDate = n.DrLicenseRegistrationDate 
, DrLicensePubDate = n.DrLicensePubDate 
, DrLicenseRatedUsers = n.DrLicenseRatedUsers 
, DrLicenseVehWeight = n.DrLicenseVehWeight 
, DrLicenseDevWeight = n.DrLicenseDevWeight 
, DrLicenseNetWeight = n.DrLicenseNetWeight 
, DrLicenseNetVolume = n.DrLicenseNetVolume 
, DrLicenseVehWide = n.DrLicenseVehWide 
, DrLicenseVehHigh = n.DrLicenseVehHigh 
, DrLicenseVehLong = n.DrLicenseVehLong 
, DrLicenseScrapedDate = n.DrLicenseScrapedDate 
, LoLicenseManageId = n.LoLicenseManageId 
, LoLicenseId = n.LoLicenseId 
, LoLicenseBusinessScope = n.LoLicenseBusinessScope 
, LoLicensePubDate = n.LoLicensePubDate 
, LoLicenseValidDate = n.LoLicenseValidDate 
, LoLicenseCheckDate = n.LoLicenseCheckDate 
, LoLicensePlace = n.LoLicensePlace 
, InsTrafficPolicyId = n.InsTrafficPolicyId 
, InsTrafficPolicyCompany = n.InsTrafficPolicyCompany 
, InsTrafficPolicyVaildateDate = n.InsTrafficPolicyVaildateDate 
, InsTrafficPolicyAmount = n.InsTrafficPolicyAmount 
, InsThirdPartyId = n.InsThirdPartyId 
, InsThirdPartyVaildateDate = n.InsThirdPartyVaildateDate 
, InsThirdPartyAmount = n.InsThirdPartyAmount 
, InsThirdPartyLogisticsAmount = n.InsThirdPartyLogisticsAmount 
, InsThirdPartyLogisticsVaildateDate = n.InsThirdPartyLogisticsVaildateDate 
, Status = n.Status 
, CreatedDate = n.CreatedDate 
, CreatedBy = n.CreatedBy 
, LastModifiedDate = n.LastModifiedDate 
, LastModifiedBy = n.LastModifiedBy 

}).ToList();
           
            return ExcelHelper.ExportExcel(typeof(Vehicle), datarows);

        }

        public Stream OrderExportExcel(string filterRules, string sort, string order)
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);

            var vehicles = this.Query(new VehicleQuery().Withfilter(filters)).Include(p => p.Company).OrderBy(n => n.OrderBy(sort, order)).Select().ToList();

            var datarows = vehicles.Select(n => new {
                CompanyName = (n.Company == null ? "" : n.Company.Name),
                Id = n.Id,
                OrderNo = n.OrderNo,
                ExternalNo = n.ExternalNo,
                UsingDate = n.UsingDate,
                Location1 = n.Location1,
                Location2 = n.Location2,
                TimePeriod = n.TimePeriod,
                Requirements = n.Requirements,
                PlateNumber = n.PlateNumber,
                Packages=     n.Packages,
                Pallets= n.Pallets,
                Cartons =n.Cartons,
                Volume =n.Volume,
                Weight=n.Weight,
                VehStatus = n.VehStatus,
                CarType = n.CarType,
                VehicleType = n.VehicleType,
                VehicleProperty = n.VehicleProperty,
                Axles = n.Axles,
                ECOMark = n.ECOMark,
                StrLoadWeight = n.StrLoadWeight,
                LoadWeight = n.LoadWeight,
                LoadVolume = n.LoadVolume,
                CarriageSize = n.CarriageSize,
                Driver = n.Driver,
                DriverPhone = n.DriverPhone,               
                Status = n.Status,
                LastModifiedDate = n.LastModifiedDate,
                LastModifiedBy = n.LastModifiedBy
            }).ToList();

            return ExcelHelper.ExportExcel(typeof(Vehicle), datarows);
        }
    }
}



