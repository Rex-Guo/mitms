// <copyright file="LineQuotesRepository.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>2018/6/8 7:56:12 </date>
// <summary>
//  Repository封装了对业务实体数据的查询和存储逻辑(CRUD数据操作)
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
using WebApp.Models;

namespace WebApp.Repositories
{
  public static class LineQuotesRepository  
    {
 
                 public static IEnumerable<LineQuotes> GetByCarrierId(this IRepositoryAsync<LineQuotes> repository, int carrierid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.CarrierId==carrierid);
             return query;

         }
             
                 public static IEnumerable<LineQuotes> GetByCompanyId(this IRepositoryAsync<LineQuotes> repository, int companyid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.CompanyId==companyid);
             return query;

         }
             
        
         
	}
}



