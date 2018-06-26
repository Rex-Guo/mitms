// <copyright file="ShipOrderDetailMetadata.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>6/25/2018 3:17:17 PM </date>
// <summary>Class representing a Metadata entity </summary>

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Models
{
    //[MetadataType(typeof(ShipOrderDetailMetadata))]
    public partial class ShipOrderDetail
    {
    }

    public partial class ShipOrderDetailMetadata
    {
        [Display(Name = "Order")]
        public Order Order { get; set; }

        [Display(Name = "ShipOrder")]
        public ShipOrder ShipOrder { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "OrderNo")]
        public string OrderNo { get; set; }

        [Display(Name = "OrderId")]
        public int OrderId { get; set; }

        [Display(Name = "Location1")]
        public string Location1 { get; set; }

        [Display(Name = "LoadTransportStationName")]
        public string LoadTransportStationName { get; set; }

        [Display(Name = "Location2")]
        public string Location2 { get; set; }

        [Display(Name = "ReceiptTransportStationName")]
        public string ReceiptTransportStationName { get; set; }

        [Display(Name = "Status")]
        public int Status { get; set; }

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

        [Display(Name = "ShipOrderId")]
        public int ShipOrderId { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy")]
        public string LastModifiedBy { get; set; }

    }




	public class ShipOrderDetailChangeViewModel
    {
        public IEnumerable<ShipOrderDetail> inserted { get; set; }
        public IEnumerable<ShipOrderDetail> deleted { get; set; }
        public IEnumerable<ShipOrderDetail> updated { get; set; }
    }

}
