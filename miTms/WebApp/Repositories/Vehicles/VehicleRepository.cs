// <copyright file="VehicleRepository.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 1:00:27 PM </date>
// <summary>
//  Repository封装了对业务模型数据查询和存储逻辑(CRUD数据操作)
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
  public static class VehicleRepository  
    {
 
                 public static IEnumerable<Vehicle> GetByCompanyId(this IRepositoryAsync<Vehicle> repository, int companyid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.CompanyId==companyid);
             return query;

         }
             
        
         
	}
}



