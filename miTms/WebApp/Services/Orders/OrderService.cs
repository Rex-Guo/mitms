// <copyright file="OrderService.cs" company="neozhu/MVC5-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>5/10/2018 1:01:16 PM </date>
// <summary>
//  实现定义的业务逻辑,通过依赖注入降低模块之间的耦合度
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
using System.Reflection;
using Newtonsoft.Json;
using System.IO;

namespace WebApp.Services
{
    public class OrderService : Service<Order>, IOrderService
    {

        private readonly IRepositoryAsync<Order> _repository;
        private readonly IDataTableImportMappingService _mappingservice;
        private readonly IVehicleService _vehicleService;
        private readonly ITransactionHistoryService historyService;
        private readonly IShipperService shipperService;
        public OrderService(IShipperService shipperService,ITransactionHistoryService historyService,IVehicleService _vehicleService,IRepositoryAsync<Order> repository, IDataTableImportMappingService mappingservice)
            : base(repository)
        {
            this.shipperService = shipperService;
            _repository = repository;
            _mappingservice = mappingservice;
            this._vehicleService = _vehicleService;
            this.historyService = historyService;
        }

        public IEnumerable<Order> GetByVehicleId(int vehicleid)
        {
            return _repository.GetByVehicleId(vehicleid);
        }
        public IEnumerable<Order> GetByShipperId(int Shipperid)
        {
            return _repository.GetByShipperId(Shipperid);
        }



        public void ImportDataTable(System.Data.DataTable datatable)
        {
            foreach (DataRow row in datatable.Rows)
            {

                Order item = new Order();
                var mapping = _mappingservice.Queryable().Where(x => x.EntitySetName == "Order" && x.IsEnabled == true).ToList();

                foreach (var field in mapping)
                {

                    var defval = field.DefaultValue;
                    var contation = datatable.Columns.Contains((field.SourceFieldName == null ? "" : field.SourceFieldName));
                    if (contation && row[field.SourceFieldName] != DBNull.Value)
                    {
                        Type ordertype = item.GetType();
                        PropertyInfo propertyInfo = ordertype.GetProperty(field.FieldName);
                        propertyInfo.SetValue(item, Convert.ChangeType(row[field.SourceFieldName], propertyInfo.PropertyType), null);
                    }
                    else if (!string.IsNullOrEmpty(defval))
                    {
                        Type ordertype = item.GetType();
                        PropertyInfo propertyInfo = ordertype.GetProperty(field.FieldName);
                        if (defval.ToLower() == "now" && propertyInfo.PropertyType == typeof(DateTime))
                        {
                            propertyInfo.SetValue(item, Convert.ChangeType(DateTime.Now, propertyInfo.PropertyType), null);
                        }
                        else
                        {
                            propertyInfo.SetValue(item, Convert.ChangeType(defval, propertyInfo.PropertyType), null);
                        }
                    }
                }

                this.Insert(item);


            }
        }

        public Stream ExportExcel(string filterRules = "", string sort = "Id", string order = "asc")
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);

            var orders = this.Query(new OrderQuery().Withfilter(filters)).Include(p => p.Shipper).Include(p => p.Vehicle).OrderBy(n => n.OrderBy(sort, order)).Select().ToList();

            var datarows = orders.Select(n => new
            {
                ShipperName = (n.Shipper == null ? "" : n.Shipper.Name),
                VehiclePlateNumber = (n.Vehicle == null ? "" : n.Vehicle.PlateNumber),
                Id = n.Id,
                OrderNo = n.OrderNo,
                ExternalNo = n.ExternalNo,
                OrderDate = n.OrderDate,
                Location1 = n.Location1,
                Location2 = n.Location2,
                Requirements = n.Requirements,
                PlanDeliveryDate = n.PlanDeliveryDate,
                TimePeriod = n.TimePeriod,
                VehicleId = n.VehicleId,
                PlateNumber = n.PlateNumber,
                Driver = n.Driver,
                DriverPhone = n.DriverPhone,
                Packages = n.Packages,
                Weight = n.Weight,
                Volume = n.Volume,
                Cartons = n.Cartons,
                Pallets = n.Pallets,
                Status = n.Status,
                DeliveryDate = n.DeliveryDate,
                CloseDate = n.CloseDate,
                ShipperId = n.ShipperId,
                CreatedDate = n.CreatedDate,
                CreatedBy = n.CreatedBy,
                LastModifiedDate = n.LastModifiedDate,
                LastModifiedBy = n.LastModifiedBy

            }).ToList();

            return ExcelHelper.ExportExcel(typeof(Order), datarows);

        }

        public void DoShippingOrder(Order order)
        {
            order.OrderNo = DbSequence.GetNextOrderNo();
            order.OrderDate = DateTime.Now;
            order.PlanDeliveryDate = order.OrderDate.AddHours(order.TimePeriod);
            order.Status = "接单";
            this.Insert(order);
            var veh = this._vehicleService.Find(order.VehicleId);
            veh.OrderId = order.Id;
            veh.OrderNo = order.OrderNo;
            veh.Status = "接单";
            veh.Location1 = order.Location1;
            veh.ShipperId = order.ShipperId;
            veh.Location2 = order.Location2;
            veh.UsingDate = order.OrderDate;
            veh.ExternalNo = order.ExternalNo;
            veh.Requirements = order.Requirements;
            veh.TimePeriod = order.TimePeriod;
            veh.Packages = order.Packages;
            veh.Pallets = order.Pallets;
            veh.Cartons = order.Cartons;
            veh.InputUser = order.InputUser;
            veh.Volume = order.Volume;
            veh.Weight = order.Weight;
            this._vehicleService.Update(veh);
            TransactionHistory item = new TransactionHistory();
            item.InputUser = order.InputUser;
            item.OrderNo = order.OrderNo;
            item.PlateNumber = order.PlateNumber;
            item.Status = order.Status;
            item.TransactioDateTime = order.OrderDate;
            this.historyService.Insert(item);

            

        }

        public void UpdateStatus(Order order)
        {
            var item =  this.Queryable().Where(x=>x.OrderNo == order.OrderNo).First();
            item.Status = order.Status;
            item.Location1 = order.Location1;
            item.Location2 = order.Location2;
            item.Packages = order.Packages;
            item.Pallets = order.Pallets;
            item.Cartons = order.Cartons;
            item.Weight = order.Weight;
            item.Volume = order.Volume;
            item.TimePeriod = order.TimePeriod;
            item.PlanDeliveryDate = item.OrderDate.AddHours(order.TimePeriod);
            item.InputUser = order.InputUser;
            item.Requirements = order.Requirements;
            if(order.Status=="入库" || order.Status == "完成" ||
                order.Status == "卸货")
            {
                item.DeliveryDate = DateTime.Now;
            } 

            this.Update(item);
            var veh = this._vehicleService.Find(order.VehicleId);
            veh.OrderId = item.Id;
            veh.ShipperId = order.ShipperId;
            veh.OrderNo = order.OrderNo;
            veh.Status = order.Status;
            veh.Location1 = order.Location1;
            veh.Location2 = order.Location2;
            veh.ExternalNo = order.ExternalNo;
            veh.Requirements = order.Requirements;
            veh.TimePeriod = order.TimePeriod;
            veh.Packages = order.Packages;
            veh.Pallets = order.Pallets;
            veh.Cartons = order.Cartons;
            veh.InputUser = order.InputUser;
            veh.Volume = order.Volume;
            veh.Weight = order.Weight;
            
            if (order.Status == "入库" || order.Status == "完成" ||
                order.Status == "卸货")
            {
                veh.Status = "空车";
                veh.OrderId = null;
                veh.OrderNo = "";
            
                veh.Location1 = "";
                veh.Location2 = "";
                veh.UsingDate = null;
                veh.ExternalNo = "";
                veh.Requirements = "";
                veh.TimePeriod = 0;
                veh.Packages = null;
                veh.Pallets = null;
                veh.Cartons = null;
                veh.InputUser = "";
                veh.Volume = null;
                veh.Weight = null;
            }
            this._vehicleService.Update(veh);
            TransactionHistory tran = new TransactionHistory();
            tran.InputUser = order.InputUser;
            tran.OrderNo = order.OrderNo;
            tran.PlateNumber = order.PlateNumber;
            tran.Status = order.Status;
            tran.TransactioDateTime = DateTime.Now;
            this.historyService.Insert(tran);
        }

        public void Create(Order order)
        {
            order.OrderNo = DbSequence.GetNextOrderNo();
            order.OrderDate = DateTime.Now;
            order.PlanDeliveryDate = order.OrderDate.AddHours(order.TimePeriod);
            order.Status = "新增";
            TransactionHistory tran = new TransactionHistory();
            tran.InputUser = order.InputUser;
            tran.OrderNo = order.OrderNo;
            tran.PlateNumber = order.PlateNumber;
            tran.Status = order.Status;
            tran.TransactioDateTime = order.OrderDate;
            this.historyService.Insert(tran);
            this.Insert(order);
        }

        public void ShippingOrder(Order order)
        {
            var orderitem = this.Find(order.Id);
            orderitem.VehicleId = order.VehicleId;
            orderitem.Driver = order.Driver;
            orderitem.PlateNumber = order.PlateNumber;
            orderitem.DriverPhone = order.DriverPhone;
            orderitem.Packages = order.Packages;
            orderitem.Pallets = order.Pallets;
            orderitem.Cartons = order.Cartons;
            orderitem.Volume = order.Volume;
            orderitem.Weight = order.Weight;
            orderitem.Status = "接单";
            this.Update(orderitem);
            var veh = this._vehicleService.Find(order.VehicleId);
            veh.OrderId = orderitem.Id;
            veh.OrderNo = orderitem.OrderNo;
            veh.Status = "接单";
            veh.Location1 = orderitem.Location1;
            veh.ShipperId = orderitem.ShipperId;
            veh.Location2 = orderitem.Location2;
            veh.UsingDate = orderitem.OrderDate;
            veh.ExternalNo = orderitem.ExternalNo;
            veh.Requirements = orderitem.Requirements;
            veh.TimePeriod = orderitem.TimePeriod;
            veh.Packages = orderitem.Packages;
            veh.Pallets = orderitem.Pallets;
            veh.Cartons = orderitem.Cartons;
            veh.InputUser = orderitem.InputUser;
            veh.Volume = orderitem.Volume;
            veh.Weight = orderitem.Weight;
            this._vehicleService.Update(veh);
            TransactionHistory item = new TransactionHistory();
            item.InputUser = orderitem.InputUser;
            item.OrderNo = orderitem.OrderNo;
            item.PlateNumber = orderitem.PlateNumber;
            item.Status = orderitem.Status;
            item.TransactioDateTime = DateTime.Now;
            this.historyService.Insert(item);
        }

        public void DoPod(int[] id)
        {
            var orders = this.Queryable().Where(x => id.Contains(x.Id)).ToList();
            foreach (var order in orders) {
                order.Status = "关闭";
                order.CloseDate = DateTime.Now;
                this.Update(order);
                TransactionHistory item = new TransactionHistory();
                item.InputUser = order.InputUser;
                item.OrderNo = order.OrderNo;
                item.PlateNumber = order.PlateNumber;
                item.Status = order.Status;
                item.TransactioDateTime = order.CloseDate.Value;
                this.historyService.Insert(item);
            }
        }

        public void CreateByShipper(Order order)
        {
            var shipper = this.shipperService.Find(order.ShipperId);
            if (shipper != null) {
                order.PhoneNumber = shipper.ContactTelephoneNumber;
                order.MobileTelephoneNumber = shipper.ContactMobileTelephoneNumber;
                order.Contact = shipper.ContactName;
                order.PersonalIdentityDocument = shipper.PersonalIdentityDocument;
                order.PersonalIdentityTypeCode = "001";
            }
            order.OrderNo = DbSequence.GetNextOrderNo();
            order.ExternalNo = "-";
            order.OrderDate = DateTime.Now;
            order.PlanDeliveryDate = order.OrderDate.AddHours(order.TimePeriod);
            order.Status = "新增";
            TransactionHistory tran = new TransactionHistory();
            tran.InputUser = order.InputUser;
            tran.OrderNo = order.OrderNo;
            tran.PlateNumber = order.PlateNumber;
            tran.Status = order.Status;
            tran.TransactioDateTime = order.OrderDate;
            this.historyService.Insert(tran);
            this.Insert(order);
        }
    }
}



