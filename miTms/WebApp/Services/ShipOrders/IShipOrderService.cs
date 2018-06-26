// <copyright file="IShipOrderService.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>6/25/2018 4:13:37 PM </date>
// <summary>
//  根据业务需求定义具体的业务逻辑接口
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
    public interface IShipOrderService:IService<ShipOrder>
    {

                  IEnumerable<ShipOrder> GetByCarrierId(int  carrierid);
                 IEnumerable<ShipOrder> GetByVehicleId(int  vehicleid);
                 IEnumerable<ShipOrder> GetByCompanyId(int  companyid);
        
                 IEnumerable<ShipOrderDetail>   GetShipOrderDetailsByShipOrderId (int shiporderid);
         
         
 
		void ImportDataTable(DataTable datatable);
		Stream ExportExcel( string filterRules = "",string sort = "Id", string order = "asc");
        void Create(ShipOrder shiporder);
        void UpdateStatus(Order order);
    }
}