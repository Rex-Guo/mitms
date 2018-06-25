// <copyright file="ShipOrderMetadata.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>6/25/2018 3:19:21 PM </date>
// <summary>Class representing a Metadata entity </summary>

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Models
{
    //[MetadataType(typeof(ShipOrderMetadata))]
    public partial class ShipOrder
    {
    }

    public partial class ShipOrderMetadata
    {
        [Display(Name = "Carrier")]
        public Carrier Carrier { get; set; }

        [Display(Name = "Company")]
        public Company Company { get; set; }

        [Display(Name = "Vehicle")]
        public Vehicle Vehicle { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "OrderNo")]
        public string OrderNo { get; set; }

        [Display(Name = "ExternalNo")]
        public string ExternalNo { get; set; }

        [Display(Name = "OrderDate")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "BusinessType")]
        public string BusinessType { get; set; }

        [Display(Name = "Status")]
        public int Status { get; set; }

        [Display(Name = "CarrierId")]
        public int CarrierId { get; set; }

        [Display(Name = "VehicleId")]
        public int VehicleId { get; set; }

        [Display(Name = "CarType")]
        public string CarType { get; set; }

        [Display(Name = "Driver")]
        public string Driver { get; set; }

        [Display(Name = "DriverPhone")]
        public string DriverPhone { get; set; }

        [Display(Name = "ContractNumber")]
        public string ContractNumber { get; set; }

        [Display(Name = "TotalMonetaryAmount")]
        public decimal TotalMonetaryAmount { get; set; }

        [Display(Name = "Remark")]
        public string Remark { get; set; }

        [Display(Name = "Location1")]
        public string Location1 { get; set; }

        [Display(Name = "Location2")]
        public string Location2 { get; set; }

        [Display(Name = "Requirements")]
        public string Requirements { get; set; }

        [Display(Name = "TimePeriod")]
        public int TimePeriod { get; set; }

        [Display(Name = "PlanDepartDate")]
        public DateTime PlanDepartDate { get; set; }

        [Display(Name = "PlanDeliveryDate")]
        public DateTime PlanDeliveryDate { get; set; }

        [Display(Name = "DepartDate")]
        public DateTime DepartDate { get; set; }

        [Display(Name = "DeliveryDate")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "ClosedDate")]
        public DateTime ClosedDate { get; set; }

        [Display(Name = "ItemCount")]
        public int ItemCount { get; set; }

        [Display(Name = "Packages")]
        public int Packages { get; set; }

        [Display(Name = "Weight")]
        public decimal Weight { get; set; }

        [Display(Name = "Volume")]
        public decimal Volume { get; set; }

        [Display(Name = "Pallets")]
        public int Pallets { get; set; }

        [Display(Name = "Cartons")]
        public int Cartons { get; set; }

        [Display(Name = "BreakCartons")]
        public int BreakCartons { get; set; }

        [Display(Name = "InputUser")]
        public string InputUser { get; set; }

        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy")]
        public string LastModifiedBy { get; set; }

    }




	public class ShipOrderChangeViewModel
    {
        public IEnumerable<ShipOrder> inserted { get; set; }
        public IEnumerable<ShipOrder> deleted { get; set; }
        public IEnumerable<ShipOrder> updated { get; set; }
    }

}
