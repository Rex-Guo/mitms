// <copyright file="VehicleMetadata.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 1:00:30 PM </date>
// <summary>Class representing a Metadata entity </summary>

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Models
{
    //[MetadataType(typeof(VehicleMetadata))]
    public partial class Vehicle
    {
    }

    public partial class VehicleMetadata
    {
        [Display(Name = "Company")]
        public Company Company { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "OrderNo")]
        public string OrderNo { get; set; }

        [Display(Name = "ExternalNo")]
        public string ExternalNo { get; set; }

        [Display(Name = "UsingDate")]
        public DateTime UsingDate { get; set; }

        [Display(Name = "Location1")]
        public string Location1 { get; set; }

        [Display(Name = "Location2")]
        public string Location2 { get; set; }

        [Display(Name = "Requirements")]
        public string Requirements { get; set; }

        [Display(Name = "PlateNumber")]
        public string PlateNumber { get; set; }

        [Display(Name = "PlateNumberPosition")]
        public string PlateNumberPosition { get; set; }

        [Display(Name = "VehStatus")]
        public string VehStatus { get; set; }

        [Display(Name = "CarType")]
        public string CarType { get; set; }

        [Display(Name = "VehicleType")]
        public string VehicleType { get; set; }

        [Display(Name = "VehicleProperty")]
        public string VehicleProperty { get; set; }

        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

        [Display(Name = "Axles")]
        public int Axles { get; set; }

        [Display(Name = "ECOMark")]
        public string ECOMark { get; set; }

        [Display(Name = "StrLoadWeight")]
        public int StrLoadWeight { get; set; }

        [Display(Name = "LoadWeight")]
        public int LoadWeight { get; set; }

        [Display(Name = "LoadVolume")]
        public int LoadVolume { get; set; }

        [Display(Name = "CarriageSize")]
        public decimal CarriageSize { get; set; }

        [Display(Name = "Driver")]
        public string Driver { get; set; }

        [Display(Name = "DriverPhone")]
        public string DriverPhone { get; set; }

        [Display(Name = "AssistantDriver")]
        public string AssistantDriver { get; set; }

        [Display(Name = "AssistantDriverPhone")]
        public string AssistantDriverPhone { get; set; }

        [Display(Name = "VehLongSize")]
        public decimal VehLongSize { get; set; }

        [Display(Name = "CubicleType")]
        public string CubicleType { get; set; }

        [Display(Name = "VehUseType")]
        public string VehUseType { get; set; }

        [Display(Name = "CustomsNo")]
        public string CustomsNo { get; set; }

        [Display(Name = "VehUse")]
        public string VehUse { get; set; }

        [Display(Name = "AVGECON")]
        public decimal AVGECON { get; set; }

        [Display(Name = "AVGECONScale")]
        public decimal AVGECONScale { get; set; }

        [Display(Name = "RoadKM")]
        public decimal RoadKM { get; set; }

        [Display(Name = "RoadHours")]
        public decimal RoadHours { get; set; }

        [Display(Name = "RoadKMScale")]
        public decimal RoadKMScale { get; set; }

        [Display(Name = "GPSDeviceId")]
        public string GPSDeviceId { get; set; }

        [Display(Name = "Owner")]
        public string Owner { get; set; }

        [Display(Name = "OwnerContactPhone")]
        public string OwnerContactPhone { get; set; }

        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Display(Name = "RPM")]
        public int RPM { get; set; }

        [Display(Name = "PurchasedDate")]
        public DateTime PurchasedDate { get; set; }

        [Display(Name = "PurchasedAmount")]
        public decimal PurchasedAmount { get; set; }

        [Display(Name = "VehLong")]
        public decimal VehLong { get; set; }

        [Display(Name = "VehWide")]
        public decimal VehWide { get; set; }

        [Display(Name = "VehHigh")]
        public decimal VehHigh { get; set; }

        [Display(Name = "VIN")]
        public string VIN { get; set; }

        [Display(Name = "ServiceLife")]
        public int ServiceLife { get; set; }

        [Display(Name = "MaintainKM")]
        public int MaintainKM { get; set; }

        [Display(Name = "MaintainDate")]
        public DateTime MaintainDate { get; set; }

        [Display(Name = "MaintainMonth")]
        public int MaintainMonth { get; set; }

        [Display(Name = "ExistVehTailBoard")]
        public bool ExistVehTailBoard { get; set; }

        [Display(Name = "VehTailBoardBrand")]
        public string VehTailBoardBrand { get; set; }

        [Display(Name = "VehTailBoardFactory")]
        public string VehTailBoardFactory { get; set; }

        [Display(Name = "VehTailBoardLife")]
        public int VehTailBoardLife { get; set; }

        [Display(Name = "VehTailBoardAmount")]
        public decimal VehTailBoardAmount { get; set; }

        [Display(Name = "VehTailBoardGPSDeviceId")]
        public string VehTailBoardGPSDeviceId { get; set; }

        [Display(Name = "DrLicenseModel")]
        public string DrLicenseModel { get; set; }

        [Display(Name = "DrLicenseUseNature")]
        public string DrLicenseUseNature { get; set; }

        [Display(Name = "DrLicenseBrand")]
        public string DrLicenseBrand { get; set; }

        [Display(Name = "DrLicenseDevId")]
        public string DrLicenseDevId { get; set; }

        [Display(Name = "DrLicenseEngineId")]
        public string DrLicenseEngineId { get; set; }

        [Display(Name = "DrLicenseRegistrationDate")]
        public DateTime DrLicenseRegistrationDate { get; set; }

        [Display(Name = "DrLicensePubDate")]
        public DateTime DrLicensePubDate { get; set; }

        [Display(Name = "DrLicenseRatedUsers")]
        public int DrLicenseRatedUsers { get; set; }

        [Display(Name = "DrLicenseVehWeight")]
        public decimal DrLicenseVehWeight { get; set; }

        [Display(Name = "DrLicenseDevWeight")]
        public decimal DrLicenseDevWeight { get; set; }

        [Display(Name = "DrLicenseNetWeight")]
        public decimal DrLicenseNetWeight { get; set; }

        [Display(Name = "DrLicenseNetVolume")]
        public decimal DrLicenseNetVolume { get; set; }

        [Display(Name = "DrLicenseVehWide")]
        public decimal DrLicenseVehWide { get; set; }

        [Display(Name = "DrLicenseVehHigh")]
        public decimal DrLicenseVehHigh { get; set; }

        [Display(Name = "DrLicenseVehLong")]
        public decimal DrLicenseVehLong { get; set; }

        [Display(Name = "DrLicenseScrapedDate")]
        public DateTime DrLicenseScrapedDate { get; set; }

        [Display(Name = "LoLicenseManageId")]
        public string LoLicenseManageId { get; set; }

        [Display(Name = "LoLicenseId")]
        public string LoLicenseId { get; set; }

        [Display(Name = "LoLicenseBusinessScope")]
        public string LoLicenseBusinessScope { get; set; }

        [Display(Name = "LoLicensePubDate")]
        public DateTime LoLicensePubDate { get; set; }

        [Display(Name = "LoLicenseValidDate")]
        public DateTime LoLicenseValidDate { get; set; }

        [Display(Name = "LoLicenseCheckDate")]
        public DateTime LoLicenseCheckDate { get; set; }

        [Display(Name = "LoLicensePlace")]
        public string LoLicensePlace { get; set; }

        [Display(Name = "InsTrafficPolicyId")]
        public string InsTrafficPolicyId { get; set; }

        [Display(Name = "InsTrafficPolicyCompany")]
        public string InsTrafficPolicyCompany { get; set; }

        [Display(Name = "InsTrafficPolicyVaildateDate")]
        public string InsTrafficPolicyVaildateDate { get; set; }

        [Display(Name = "InsTrafficPolicyAmount")]
        public decimal InsTrafficPolicyAmount { get; set; }

        [Display(Name = "InsThirdPartyId")]
        public string InsThirdPartyId { get; set; }

        [Display(Name = "InsThirdPartyVaildateDate")]
        public DateTime InsThirdPartyVaildateDate { get; set; }

        [Display(Name = "InsThirdPartyAmount")]
        public decimal InsThirdPartyAmount { get; set; }

        [Display(Name = "InsThirdPartyLogisticsAmount")]
        public decimal InsThirdPartyLogisticsAmount { get; set; }

        [Display(Name = "InsThirdPartyLogisticsVaildateDate")]
        public DateTime InsThirdPartyLogisticsVaildateDate { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy")]
        public string LastModifiedBy { get; set; }

    }




	public class VehicleChangeViewModel
    {
        public IEnumerable<Vehicle> inserted { get; set; }
        public IEnumerable<Vehicle> deleted { get; set; }
        public IEnumerable<Vehicle> updated { get; set; }
    }

}
