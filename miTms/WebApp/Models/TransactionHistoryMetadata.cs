// <copyright file="TransactionHistoryMetadata.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/14/2018 8:58:22 AM </date>
// <summary>Class representing a Metadata entity </summary>

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Models
{
    //[MetadataType(typeof(TransactionHistoryMetadata))]
    public partial class TransactionHistory
    {
    }

    public partial class TransactionHistoryMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "OrderNo")]
        public string OrderNo { get; set; }

        [Display(Name = "PlateNumber")]
        public string PlateNumber { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "TransactioDateTime")]
        public DateTime TransactioDateTime { get; set; }

        [Display(Name = "Remark")]
        public string Remark { get; set; }

        [Display(Name = "Flag1")]
        public int Flag1 { get; set; }

        [Display(Name = "Flag2")]
        public int Flag2 { get; set; }

        [Display(Name = "InputUser")]
        public string InputUser { get; set; }

        [Display(Name = "Longitude")]
        public decimal Longitude { get; set; }

        [Display(Name = "Latitude")]
        public decimal Latitude { get; set; }

        [Display(Name = "PhotographPath")]
        public string PhotographPath { get; set; }

        [Display(Name = "Photograph")]
        public byte[] Photograph { get; set; }

        [Display(Name = "Remark2")]
        public string Remark2 { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy")]
        public string LastModifiedBy { get; set; }

    }




	public class TransactionHistoryChangeViewModel
    {
        public IEnumerable<TransactionHistory> inserted { get; set; }
        public IEnumerable<TransactionHistory> deleted { get; set; }
        public IEnumerable<TransactionHistory> updated { get; set; }
    }

}
