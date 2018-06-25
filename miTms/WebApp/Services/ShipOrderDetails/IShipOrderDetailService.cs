// <copyright file="IShipOrderDetailService.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>6/25/2018 4:01:08 PM </date>
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
    public interface IShipOrderDetailService:IService<ShipOrderDetail>
    {

                  IEnumerable<ShipOrderDetail> GetByOrderId(int  orderid);
                 IEnumerable<ShipOrderDetail> GetByShipOrderId(int  shiporderid);
        
         
 
		void ImportDataTable(DataTable datatable);
		Stream ExportExcel( string filterRules = "",string sort = "Id", string order = "asc");
	}
}