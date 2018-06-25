// <copyright file="ShipOrderDetailRepository.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>6/25/2018 4:01:07 PM </date>
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
  public static class ShipOrderDetailRepository  
    {
 
                 public static IEnumerable<ShipOrderDetail> GetByOrderId(this IRepositoryAsync<ShipOrderDetail> repository, int orderid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.OrderId==orderid);
             return query;

         }
             
                 public static IEnumerable<ShipOrderDetail> GetByShipOrderId(this IRepositoryAsync<ShipOrderDetail> repository, int shiporderid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.ShipOrderId==shiporderid);
             return query;

         }
             
        
         
	}
}



