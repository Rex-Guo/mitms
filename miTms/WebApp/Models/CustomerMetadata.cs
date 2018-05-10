// <copyright file="CustomerMetadata.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 12:58:48 PM </date>
// <summary>Class representing a Metadata entity </summary>

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Models
{
    //[MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {
    }

    public partial class CustomerMetadata
    {
        [Display(Name = "Company")]
        public Company Company { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "ServiceUser")]
        public string ServiceUser { get; set; }

        [Display(Name = "TradeType")]
        public string TradeType { get; set; }

        [Display(Name = "LegalPerson")]
        public string LegalPerson { get; set; }

        [Display(Name = "RegistrationNumber")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "LinkMan")]
        public string LinkMan { get; set; }

        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Display(Name = "CustomerService")]
        public string CustomerService { get; set; }

        [Display(Name = "Sales")]
        public string Sales { get; set; }

        [Display(Name = "Payment")]
        public string Payment { get; set; }

        [Display(Name = "PaymentDays")]
        public int PaymentDays { get; set; }

        [Display(Name = "BankName")]
        public string BankName { get; set; }

        [Display(Name = "BankAccount")]
        public string BankAccount { get; set; }

        [Display(Name = "InvoiceTitle")]
        public string InvoiceTitle { get; set; }

        [Display(Name = "PaymentNumber")]
        public string PaymentNumber { get; set; }

        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy")]
        public string LastModifiedBy { get; set; }

    }




	public class CustomerChangeViewModel
    {
        public IEnumerable<Customer> inserted { get; set; }
        public IEnumerable<Customer> deleted { get; set; }
        public IEnumerable<Customer> updated { get; set; }
    }

}
