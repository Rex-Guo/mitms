// <copyright file="ILineQuotesService.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>2018/6/8 7:56:13 </date>
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
    public interface ILineQuotesService:IService<LineQuotes>
    {

                  IEnumerable<LineQuotes> GetByCarrierId(int  carrierid);
                 IEnumerable<LineQuotes> GetByCompanyId(int  companyid);
        
         
 
		void ImportDataTable(DataTable datatable);
		Stream ExportExcel( string filterRules = "",string sort = "Id", string order = "asc");
	}
}