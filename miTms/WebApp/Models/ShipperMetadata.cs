﻿// <copyright file="ShipperMetadata.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/30/2018 9:44:43 AM </date>
// <summary>Class representing a Metadata entity </summary>

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Models
{
   // [MetadataType(typeof(ShipperMetadata))]
    public partial class Shipper
    {
    }

    public partial class ShipperMetadata
    {
        [Display(Name = "Company")]
        public Company Company { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Type")]
        public int Type { get; set; }

        [Display(Name = "ContactName")]
        public string ContactName { get; set; }

        [Display(Name = "ContactIdCard")]
        public string ContactIdCard { get; set; }

        [Display(Name = "ContactMobileTelephoneNumber")]
        public string ContactMobileTelephoneNumber { get; set; }

        [Display(Name = "RegisteredAddress")]
        public string RegisteredAddress { get; set; }

        [Display(Name = "RegisteredCapital")]
        public decimal RegisteredCapital { get; set; }

        [Display(Name = "UnifiedSocialCreditldentifier")]
        public string UnifiedSocialCreditldentifier { get; set; }

        [Display(Name = "UnifiedsocialDatetime")]
        public DateTime UnifiedsocialDatetime { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "LogoPicture")]
        public string LogoPicture { get; set; }

        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

        [Display(Name = "RegistrationDatetime")]
        public DateTime RegistrationDatetime { get; set; }

        [Display(Name = "UpdateTimeDatetime")]
        public DateTime UpdateTimeDatetime { get; set; }

        [Display(Name = "IsBlaclkList")]
        public bool IsBlaclkList { get; set; }

        [Display(Name = "IsDeleteFlag")]
        public bool IsDeleteFlag { get; set; }

        [Display(Name = "SynchronizationTime")]
        public DateTime SynchronizationTime { get; set; }

        [Display(Name = "IsException")]
        public bool IsException { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy")]
        public string LastModifiedBy { get; set; }

    }




	public class ShipperChangeViewModel
    {
        public IEnumerable<Shipper> inserted { get; set; }
        public IEnumerable<Shipper> deleted { get; set; }
        public IEnumerable<Shipper> updated { get; set; }
    }

}