// <copyright file="OrderMetadata.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 1:01:17 PM </date>
// <summary>Class representing a Metadata entity </summary>

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Models
{
    //[MetadataType(typeof(OrderMetadata))]
    public partial class Order
    {
    }

    public partial class OrderMetadata
    {
        

    }




	public class OrderChangeViewModel
    {
        public IEnumerable<Order> inserted { get; set; }
        public IEnumerable<Order> deleted { get; set; }
        public IEnumerable<Order> updated { get; set; }
    }

}
