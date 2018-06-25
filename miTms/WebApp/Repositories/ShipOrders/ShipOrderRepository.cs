// <copyright file="ShipOrderRepository.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>6/25/2018 4:13:36 PM </date>
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
  public static class ShipOrderRepository  
    {
 
                 public static IEnumerable<ShipOrder> GetByCarrierId(this IRepositoryAsync<ShipOrder> repository, int carrierid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.CarrierId==carrierid);
             return query;

         }
             
                 public static IEnumerable<ShipOrder> GetByVehicleId(this IRepositoryAsync<ShipOrder> repository, int vehicleid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.VehicleId==vehicleid);
             return query;

         }
             
                 public static IEnumerable<ShipOrder> GetByCompanyId(this IRepositoryAsync<ShipOrder> repository, int companyid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.CompanyId==companyid);
             return query;

         }
             
        
                public static IEnumerable<ShipOrderDetail>   GetShipOrderDetailsByShipOrderId (this IRepositoryAsync<ShipOrder> repository,int shiporderid)
        {
			var shiporderdetailRepository = repository.GetRepository<ShipOrderDetail>(); 
            return shiporderdetailRepository.Queryable().Include(x => x.Order).Include(x => x.ShipOrder).Where(n => n.ShipOrderId == shiporderid);
        }
         
	}
}



