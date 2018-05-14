// <copyright file="IVehicleService.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 1:00:29 PM </date>
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
    public interface IVehicleService:IService<Vehicle>
    {

                  IEnumerable<Vehicle> GetByCompanyId(int  companyid);
        
         
 
		void ImportDataTable(DataTable datatable);
		Stream ExportExcel( string filterRules = "",string sort = "Id", string order = "asc");
        Stream OrderExportExcel(string filterRules, string sort, string order);
    }
}