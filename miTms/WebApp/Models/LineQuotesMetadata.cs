// <copyright file="LineQuotesMetadata.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>2018/6/8 7:56:15 </date>
// <summary>Class representing a Metadata entity </summary>

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Models
{
    //[MetadataType(typeof(LineQuotesMetadata))]
    public partial class LineQuotes
    {
    }

    public partial class LineQuotesMetadata
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

        [Display(Name = "Location1")]
        public string Location1 { get; set; }

        [Display(Name = "Location2")]
        public string Location2 { get; set; }

        [Display(Name = "TimePeriod")]
        public int TimePeriod { get; set; }

        [Display(Name = "PiceVehicleType")]
        public string PiceVehicleType { get; set; }

        [Display(Name = "PiceType")]
        public string PiceType { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Remark")]
        public string Remark { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "InputUser")]
        public string InputUser { get; set; }

        [Display(Name = "CarrierId")]
        public int CarrierId { get; set; }

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




	public class LineQuotesChangeViewModel
    {
        public IEnumerable<LineQuotes> inserted { get; set; }
        public IEnumerable<LineQuotes> deleted { get; set; }
        public IEnumerable<LineQuotes> updated { get; set; }
    }

}
