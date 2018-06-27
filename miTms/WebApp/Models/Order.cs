using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
    public partial class Order:Entity
    {
        [Key]
        public int Id { get; set; }

        #region 派车信息
        [Display(Name = "订单号", Description = "订单号")]
        [MaxLength(20)]
        public string OrderNo { get; set; }
        [Display(Name = "WMS出货单号", Description = "WMS出货单号")]
        [MaxLength(30)]
        public string ExternalNo { get; set; }
        [Display(Name = "派车时间", Description = "派车时间")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "起点", Description = "起点")]
        [MaxLength(120)]
        public string Location1 { get; set; }
        [Display(Name = "终点", Description = "终点")]
        [MaxLength(120)]
        public string Location2 { get; set; }
        [Display(Name = "额外要求", Description = "额外要求")]
        [MaxLength(120)]
        public string Requirements { get; set; }

        [Display(Name = "计划送达时间", Description = "计划送达时间")]
        public DateTime? PlanDeliveryDate { get; set; }
        [Display(Name = "时效(小时)", Description = "时效(小时)")]
        public int TimePeriod { get; set; }
        [Display(Name = "是否带票", Description = "是否带票")]
        
        public bool TakeTicketFlag { get; set; }
        [Display(Name = "价格类", Description = "价格类型（1：包车价 2：单价 )")]
        [MaxLength(1)]
        public string PriceType { get; set; }
        [Display(Name = "货物托运车型要求", Description = "货物托运车型要求")]
        [MaxLength(256)]
        public string VehicleTypeRequirement { get; set; }
        [Display(Name = "货物托运车长要求", Description = "货物托运车长要求")]
        [MaxLength(256)]
        public string VehicleLengthRequirement { get; set; }
        [Display(Name = "货运站代码", Description = "货运站代码")]
        [MaxLength(16)]
        public string LoadTransportStationCode { get; set; }
        [Display(Name = "货运站名称", Description = "货运站名称")]
        [MaxLength(50)]
        public string LoadTransportStationName { get; set; }
        [Display(Name = "卸货货运站代码", Description = "卸货货运站代码")]
        [MaxLength(16)]
        public string ReceiptTransportStationCode { get; set; }
        [Display(Name = "卸货货运站名称", Description = "卸货货运站名称")]
        [MaxLength(50)]
        public string ReceiptTransportStationName { get; set; }
        #endregion


        #region 车辆信息
        [Display(Name = "车牌号", Description = "车牌号")]
        public int? VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }
    
     
        [MaxLength(10)]
        [Display(Name = "车牌号", Description = "车牌号")]
        public string PlateNumber { get; set; }

        [MaxLength(20)]
        [Display(Name = "主驾司机", Description = "主驾司机")]
        public string Driver { get; set; }

       
        [MaxLength(50)]
        [Display(Name = "主驾司机电话", Description = "主驾司机电话")]
        public string DriverPhone { get; set; }

        #endregion
        #region 货物信息
        [Display(Name = "货物名称", Description = "货物名称")]
        [MaxLength(150)]
        public string ProductName { get; set; }
        [Display(Name = "货物类型分类代码", Description = "货物类型分类代码")]
        [MaxLength(3)]
        public string CargotypeClassificationCode { get; set; }
        [Display(Name = "包装类型代码", Description = "包装类型代码")]
        [MaxLength(3)]
        public string PackageTypeCode { get; set; }
        [Display(Name = "总件数", Description = "总件数")]
        public int? Packages { get; set; }
        [Display(Name = "重量(千克)", Description = "重量(千克)")]
        public decimal? Weight { get; set; }
        [Display(Name = "重量单位", Description = "重量单位")]
        [MaxLength(3)]
        public string MeasurementUnitCode { get; set; }
        [Display(Name = "体积(立方)", Description = "体积(立方)")]
        public decimal? Volume { get; set; }
        [Display(Name = "体积单位", Description = "体积单位")]
        [MaxLength(3)]
        public string VolumeMeasurementUnitCode { get; set; }
        [Display(Name = "箱数", Description = "箱数")]
        public int? Cartons { get; set; }
        [Display(Name = "栈板数", Description = "栈板数")]
        public int? Pallets { get; set; }
        [Display(Name = "散箱数", Description = "散箱数/散件")]
        public int? BreakCartons { get; set; }
        [Display(Name = "货值", Description = "货值(RMB)")]
        public decimal? GoodsPrice { get; set; }
        [Display(Name = "总运价", Description = "总运价(RMB)")]
        public decimal? TotalMonetaryAmount { get; set; }
        [Display(Name = "调度人员", Description = "调度人员")]
        [MaxLength(20)]
        [Required]
        public string InputUser { get; set; }
        #endregion
        #region 订单状态信息
        [Display(Name = "状态", Description = "状态")]
        [MaxLength(20)]
        public string Status { get; set; }
        [Display(Name = "要求装货起始日期", Description = "要求装货起始日期")]
        public DateTime? ResquestedLoadStartDatetime { get; set; }
        [Display(Name = "要求装货结束日期", Description = "要求装货结束日期")]
        public DateTime? ResquestedLoadEndDatetime { get; set; }

        [Display(Name = "实际送达时间", Description = "实际送达时间")]
        public DateTime? DeliveryDate { get; set; }
        [Display(Name = "结案时间", Description = "结案时间")]
        public DateTime? CloseDate { get; set; }
        [Display(Name = "POD单号", Description = "POD单号")]
        [MaxLength(20)]
        public string PodNo { get; set; }
        [Display(Name = "回单文件路径", Description = "回单文件路径")]
        [MaxLength(120)]
        public string PodPhotographPath { get; set; }
        [Display(Name = "回单文件", Description = "回单文件")]
        public byte[] PodPhotograph { get; set; }

        #endregion
        #region 客户信息
        [Display(Name = "托运人", Description = "托运人")]
        public int ShipperId { get; set; }
        [ForeignKey("ShipperId")]
        [Display(Name = "托运人", Description = "托运人")]
        public virtual Shipper Shipper { get; set; }
        [Display(Name = "联系电话", Description = "联系电话")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Display(Name = "联系移动电话", Description = "联系移动电话")]
        [MaxLength(20)]
        public string MobileTelephoneNumber { get; set; }
        [Display(Name = "联系人", Description = "联系人")]
        [MaxLength(20)]
        public string Contact { get; set; }
        [Display(Name = "个人证件类别代码", Description = "个人证件类别代码")]
        [MaxLength(3)]
        public string PersonalIdentityTypeCode { get; set; }
        [Display(Name = "个人证件", Description = "个人证件")]
        [MaxLength(35)]
        public string PersonalIdentityDocument { get; set; }
        [Required]
        [Display(Name = "所属平台", Description = "所属平台")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        [Display(Name = "所在平台", Description = "所在平台")]
        public virtual Company Company { get; set; }
        [Display(Name = "合同编号", Description = "合同编号")]
        [MaxLength(35)]
        public string ContractNumber { get; set; }

        #endregion
        #region 保险信息
        [Display(Name = "是否需要购买保险", Description = "是否需要购买保险")]
        public bool RequestedInsuranceFlag { get; set; }
        [Display(Name = "保险公司", Description = "保险公司")]
        [MaxLength(256)]
        public string InsuranceCompany { get; set; }

        [Display(Name = "保单号", Description = "保单号")]
        [MaxLength(50)]
        public string InsuranceBillCode { get; set; }
        [Display(Name = "保单地址", Description = "保单地址")]
        [MaxLength(256)]
        public string InsuranceAccessAddress { get; set; }
        #endregion
        #region 收货人信息
        [Display(Name = "收货人", Description = "收货人")]
        [MaxLength(256)]
        public string Consignee { get; set; }
        [Display(Name = "收货联系人", Description = "收货联系人")]
        [MaxLength(50)]
        public string ConsiContactName { get; set; }
        [Display(Name = "收货人电话", Description = "收货人电话")]
        [MaxLength(30)]
        public string ConsiTelephoneNumber { get; set; }
        [Display(Name = "收货人地址", Description = "收货人地址")]
        [MaxLength(256)]
        public string ConsiAddress { get; set; }
        [Display(Name = "收货人移动电话", Description = "收货人移动电话")]
        [MaxLength(30)]
        public string ConsiMobileTelephoneNumber { get; set; }
        [Display(Name = " 收货人国家行政区划代码", Description = " 收货人国家行政区划代码")]
        [MaxLength(12)]
        public string ConsiCountrySubdivisionCode { get; set; }
        [Display(Name = "收货人国家行政区名称", Description = "收货人国家行政区名称")]
        [MaxLength(70)]
        public string ConsiCountrySubdivisionName { get; set; }
 
        #endregion
    }
}