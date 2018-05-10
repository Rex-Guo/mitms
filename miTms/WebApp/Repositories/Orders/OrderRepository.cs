// <copyright file="OrderRepository.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 1:01:14 PM </date>
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
  public static class OrderRepository  
    {
 
                 public static IEnumerable<Order> GetByVehicleId(this IRepositoryAsync<Order> repository, int vehicleid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.VehicleId==vehicleid);
             return query;

         }
             
                 public static IEnumerable<Order> GetByCustomerId(this IRepositoryAsync<Order> repository, int customerid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.CustomerId==customerid);
             return query;

         }
             
        
         
	}
}



