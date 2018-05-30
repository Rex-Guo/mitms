// <copyright file="DriverMetadata.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/30/2018 9:35:58 AM </date>
// <summary>Class representing a Metadata entity </summary>

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Models
{
    //[MetadataType(typeof(DriverMetadata))]
    public partial class Driver
    {
    }

    public partial class DriverMetadata
    {
        [Display(Name = "Carrier")]
        public Carrier Carrier { get; set; }

        [Display(Name = "Company")]
        public Company Company { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Gender")]
        public int Gender { get; set; }

        [Display(Name = "IdentityDocumentNumber")]
        public string IdentityDocumentNumber { get; set; }

        [Display(Name = "MobileTelephoneNumber")]
        public string MobileTelephoneNumber { get; set; }

        [Display(Name = "TelephoneNumber")]
        public string TelephoneNumber { get; set; }

        [Display(Name = "QualificationCertificateNumber")]
        public string QualificationCertificateNumber { get; set; }

        [Display(Name = "Remark")]
        public string Remark { get; set; }

        [Display(Name = "Carrierid")]
        public int Carrierid { get; set; }

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




	public class DriverChangeViewModel
    {
        public IEnumerable<Driver> inserted { get; set; }
        public IEnumerable<Driver> deleted { get; set; }
        public IEnumerable<Driver> updated { get; set; }
    }

}
