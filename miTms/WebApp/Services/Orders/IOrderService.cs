// <copyright file="IOrderService.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 1:01:15 PM </date>
// <summary>
//  定义具体的业务逻辑接口
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
using System.IO;

namespace WebApp.Services
{
    public interface IOrderService:IService<Order>
    {

                  IEnumerable<Order> GetByVehicleId(int  vehicleid);
                 IEnumerable<Order> GetByShipperId(int  customerid);
        
         
 
		void ImportDataTable(DataTable datatable);
		Stream ExportExcel( string filterRules = "",string sort = "Id", string order = "asc");
        void DoShippingOrder(Order order);
        void UpdateStatus(Order order);
        void Create(Order order);
        void ShippingOrder(Order item);
        void DoPod(int[] id);
        void CreateByShipper(Order order);
    }
}