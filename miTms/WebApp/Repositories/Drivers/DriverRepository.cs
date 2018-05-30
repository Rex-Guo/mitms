// <copyright file="DriverRepository.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/30/2018 9:35:54 AM </date>
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
  public static class DriverRepository  
    {
 
                 public static IEnumerable<Driver> GetByCarrierid(this IRepositoryAsync<Driver> repository, int carrierid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.Carrierid==carrierid);
             return query;

         }
             
                 public static IEnumerable<Driver> GetByCompanyId(this IRepositoryAsync<Driver> repository, int companyid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.CompanyId==companyid);
             return query;

         }
             
        
         
	}
}



