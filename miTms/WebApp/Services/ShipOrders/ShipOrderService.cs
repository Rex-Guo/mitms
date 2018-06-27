// <copyright file="ShipOrderService.cs" company="neozhu/SmartCode-Scaffolder">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>6/25/2018 4:13:37 PM </date>
// <summary>
//  根据需求定义实现具体的业务逻辑,通过依赖注入降低模块之间的耦合度
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
using Repository.Pattern.Infrastructure;
using Service.Pattern;
using WebApp.Models;
using WebApp.Repositories;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;

namespace WebApp.Services
{
    public class ShipOrderService : Service<ShipOrder>, IShipOrderService
    {
        private readonly IOrderService orderService;
        private readonly IVehicleService vehicleService;
        private readonly ITransactionHistoryService transactionHistoryService;
        private readonly IRepositoryAsync<ShipOrder> _repository;
        private readonly IShipOrderDetailService shipOrderDetailService;
        private readonly IDataTableImportMappingService _mappingservice;
        public ShipOrderService(
            IShipOrderDetailService shipOrderDetailService,
            IOrderService orderService,
            IVehicleService vehicleService,
            ITransactionHistoryService transactionHistoryService,
            IRepositoryAsync<ShipOrder> repository, IDataTableImportMappingService mappingservice)
            : base(repository)
        {
            this.shipOrderDetailService = shipOrderDetailService;
            this.orderService = orderService;
            this.vehicleService = vehicleService;
            this.transactionHistoryService = transactionHistoryService;
            _repository = repository;
            _mappingservice = mappingservice;
        }

        public IEnumerable<ShipOrder> GetByCarrierId(int carrierid)
        {
            return _repository.GetByCarrierId(carrierid);
        }
        public IEnumerable<ShipOrder> GetByVehicleId(int vehicleid)
        {
            return _repository.GetByVehicleId(vehicleid);
        }
        public IEnumerable<ShipOrder> GetByCompanyId(int companyid)
        {
            return _repository.GetByCompanyId(companyid);
        }
        public IEnumerable<ShipOrderDetail> GetShipOrderDetailsByShipOrderId(int shiporderid)
        {
            return _repository.GetShipOrderDetailsByShipOrderId(shiporderid);
        }



        public void ImportDataTable(System.Data.DataTable datatable)
        {
            foreach (DataRow row in datatable.Rows)
            {

                ShipOrder item = new ShipOrder();
                var mapping = _mappingservice.Queryable().Where(x => x.EntitySetName == "ShipOrder" && x.IsEnabled == true).ToList();
                var requiredfield = mapping.Where(x => x.IsRequired == true).FirstOrDefault()?.SourceFieldName;
                if (requiredfield != null && !row.IsNull(requiredfield) && row[requiredfield] != DBNull.Value && Convert.ToString(row[requiredfield]).Trim() != string.Empty)
                {
                    foreach (var field in mapping)
                    {
                        var defval = field.DefaultValue;
                        var contation = datatable.Columns.Contains((field.SourceFieldName == null ? "" : field.SourceFieldName));
                        if (contation && !row.IsNull(field.SourceFieldName) && row[field.SourceFieldName] != DBNull.Value)
                        {
                            Type shipordertype = item.GetType();
                            PropertyInfo propertyInfo = shipordertype.GetProperty(field.FieldName);
                            propertyInfo.SetValue(item, Convert.ChangeType(row[field.SourceFieldName], propertyInfo.PropertyType), null);
                        }
                        else if (!string.IsNullOrEmpty(defval))
                        {
                            Type shipordertype = item.GetType();
                            PropertyInfo propertyInfo = shipordertype.GetProperty(field.FieldName);
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
        }

        public Stream ExportExcel(string filterRules = "", string sort = "Id", string order = "asc")
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);

            var shiporders = this.Query(new ShipOrderQuery().Withfilter(filters)).Include(p => p.Carrier).Include(p => p.Company).Include(p => p.Vehicle).OrderBy(n => n.OrderBy(sort, order)).Select().ToList();

            var datarows = shiporders.Select(n => new
            {

                CarrierName = (n.Carrier == null ? "" : n.Carrier.Name),
                CompanyName = (n.Company == null ? "" : n.Company.Name),
                VehiclePlateNumber = (n.Vehicle == null ? "" : n.Vehicle.PlateNumber),
                Id = n.Id,
                ShipOrderNo = n.ShipOrderNo,
                ExternalNo = n.ExternalNo,
                OrderDate = n.OrderDate,
                BusinessType = n.BusinessType,
                Status = n.Status,
                CarrierId = n.CarrierId,
                VehicleId = n.VehicleId,
                CarType = n.CarType,
                Driver = n.Driver,
                DriverPhone = n.DriverPhone,
                ContractNumber = n.ContractNumber,
                TotalMonetaryAmount = n.TotalMonetaryAmount,
                Remark = n.Remark,
                Location1 = n.Location1,
                Location2 = n.Location2,
                Requirements = n.Requirements,
                TimePeriod = n.TimePeriod,
                PlanDepartDate = n.PlanDepartDate,
                PlanDeliveryDate = n.PlanDeliveryDate,
                DepartDate = n.DepartDate,
                DeliveryDate = n.DeliveryDate,
                ClosedDate = n.ClosedDate,
                ItemCount = n.ItemCount,
                Packages = n.Packages,
                Weight = n.Weight,
                Volume = n.Volume,
                Pallets = n.Pallets,
                Cartons = n.Cartons,
                BreakCartons = n.BreakCartons,
                InputUser = n.InputUser,
                CompanyId = n.CompanyId,
                CreatedDate = n.CreatedDate,
                CreatedBy = n.CreatedBy,
                LastModifiedDate = n.LastModifiedDate,
                LastModifiedBy = n.LastModifiedBy
            }).ToList();

            return ExcelHelper.ExportExcel(typeof(ShipOrder), datarows);

        }

        public void Create(ShipOrder shiporder)
        {
            shiporder.TrackingState = TrackableEntities.TrackingState.Added;
            shiporder.Status = 1;
            var shipperid = 0;
            foreach (var item in shiporder.ShipOrderDetails) {
                item.ShipOrder = shiporder;
                item.ShipOrderId = shiporder.Id;
                item.ShipOrderNo = shiporder.ShipOrderNo;
               
                item.TrackingState = TrackableEntities.TrackingState.Added;
                var order = this.orderService.Find(item.Id);
                order.Status = "接单";
                order.VehicleId = shiporder.VehicleId;
                order.Driver = shiporder.Driver;
                order.DriverPhone = shiporder.DriverPhone;
                var v=this.vehicleService.Find(shiporder.VehicleId);
                order.PlateNumber = v.PlateNumber;
                this.orderService.Update(order);
                item.OrderId = order.Id;
                shipperid = shipperid==0 ? order.ShipperId: shipperid;
                item.Id = 0;
            }
            this.ApplyChanges(shiporder);
            var veh = this.vehicleService.Find(shiporder.VehicleId);
            veh.OrderId = shiporder.Id;
            veh.OrderNo = shiporder.ShipOrderNo;
            veh.Status = "接单";
            veh.Location1 = shiporder.Location1;
            veh.ShipperId = shipperid;
            veh.Location2 = shiporder.Location2;
            veh.UsingDate = shiporder.OrderDate;
            veh.ExternalNo = shiporder.ExternalNo;
            veh.Requirements = shiporder.Remark;
            veh.TimePeriod = shiporder.TimePeriod;
            veh.Packages = shiporder.Packages;
            veh.Pallets = shiporder.Pallets;
            veh.Cartons = shiporder.Cartons;
            veh.InputUser = shiporder.InputUser;
            veh.Volume = shiporder.Volume;
            veh.Weight = shiporder.Weight;
            this.vehicleService.Update(veh);
        }

        private int ConvertStatus(string status) {
            if (status == "新增")
                return 0;
            if (status == "接单")
                return 1;
            if (status == "发车")
                return 2;
            if (status == "提货")
                return 3;
            if (status == "在途")
                return 4;
            if (status == "卸货")
                return 5;
            if (status == "入库")
                return 6;
            if (status == "异常")
                return 7;
            if (status == "完成")
                return 8;
            if (status == "关闭")
                return 9;
            return 0;
        }
        public void UpdateStatus(Order order)
        {
            var item = this.Queryable().Where(x => x.ShipOrderNo == order.OrderNo).First();
            var details = this.shipOrderDetailService.Queryable().Where(x => x.ShipOrderId == item.Id).ToList();
            foreach (var detail in details) {
                detail.Status = ConvertStatus(order.Status);
                this.shipOrderDetailService.Update(detail);
                var orderitem = this.orderService.Find(detail.OrderId);
                orderitem.Status = order.Status;
                if (order.Status == "入库" || order.Status == "完成" ||
                order.Status == "卸货")
                {
                    orderitem.DeliveryDate = DateTime.Now;

                }
               
                this.orderService.Update(orderitem);
            }
            item.Status = ConvertStatus(order.Status);
            item.InputUser = order.InputUser;
            item.Requirements = order.Requirements;
            item.Remark = item.Remark + order.Requirements;
            if (order.Status == "入库" || order.Status == "完成" ||
                order.Status == "卸货")
            {
                item.DeliveryDate = DateTime.Now;
            }
            else if (order.Status == "发车") {
                item.DepartDate = DateTime.Now;
            }
            this.Update(item);
            var veh = this.vehicleService.Find(order.VehicleId);
            veh.OrderId = item.Id;
            veh.Status = order.Status;
            veh.Requirements = order.Requirements;
            veh.InputUser = order.InputUser;
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
            this.vehicleService.Update(veh);
            TransactionHistory tran = new TransactionHistory();
            tran.InputUser = item.InputUser;
            tran.OrderNo = item.ShipOrderNo;
            tran.PlateNumber = veh.PlateNumber;
            tran.Status = order.Status;
            tran.TransactioDateTime = DateTime.Now;
            this.transactionHistoryService.Insert(tran);
        }
    }
}



