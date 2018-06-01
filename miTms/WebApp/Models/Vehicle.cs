using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    [Table("Vehicle")]
    [Serializable]
    public partial class Vehicle : Entity
    {
        [Display(Name = "系统编号", Description = "系统编号")]
        [Key]
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(10)]
        [Display(Name = "车牌号", Description = "车牌号")]
        public string PlateNumber { get; set; }
        #region 派车信息
        [Display(Name = "派车单编号", Description = "派车单编号")]
        public int? OrderId { get; set; }
        [Display(Name = "派车单号", Description = "派车单号")]
        [MaxLength(20)]
        public string OrderNo { get; set; }
        [Display(Name = "对账单号", Description = "对账单号")]
        [MaxLength(20)]
        public string ExternalNo { get; set; }
        [Display(Name = "派车时间", Description = "派车时间")]
        public DateTime? UsingDate { get; set; }
        [Display(Name = "时效(小时)", Description = "时效(小时)")]
        public int TimePeriod { get; set; }

        [Display(Name = "起点", Description = "起点")]
        [MaxLength(120)]
        public string Location1 { get; set; }
        [Display(Name = "终点", Description = "终点")]
        [MaxLength(120)]
        public string Location2 { get; set; }
        [Display(Name = "额外要求", Description = "额外要求")]
        [MaxLength(120)]
        public string Requirements { get; set; }
        [Display(Name = "总件数", Description = "总件数")]
        public int? Packages { get; set; }
        [Display(Name = "重量(千克)", Description = "重量(千克)")]
        public decimal? Weight { get; set; }
        [Display(Name = "体积(立方)", Description = "体积(立方)")]
        public decimal? Volume { get; set; }
        [Display(Name = "箱数", Description = "箱数")]
        public int? Cartons { get; set; }
        [Display(Name = "栈板数", Description = "栈板数")]
        public int? Pallets { get; set; }
        [Display(Name = "调度人员", Description = "调度人员")]
        [MaxLength(20)]
    
        public string InputUser { get; set; }
         

        [Display(Name = "托运人", Description = "托运人")]
        public int? ShipperId { get; set; }

        #endregion

        #region 车辆基本信息

        #region 必填字段



        [Required]
        [Display(Name = "车头/车挂", Description = "车头/车挂/一体车")]
        [MaxLength(10)]
        public string PlateNumberPosition { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "车辆状态", Description = "车辆状态(停用/启用)")]
        public string VehStatus { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "车辆类型", Description = "车辆类型(厢式车（默认）/平板车/轿车/面包车/高栏车/飞翼车等)")]
        public string CarType { get; set; }


        //[Required]
        [MaxLength(20)]
        [Display(Name = "车牌种类", Description = "车牌种类(大型汽车号牌/小型汽车号牌/其他号牌)")]
        public string VehicleType { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "车辆性质", Description = "车辆性质(公车/外租车)")]
        public string VehicleProperty { get; set; }

        [Required]
        [Display(Name = "所属平台", Description = "所属平台")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        [Display(Name = "所属平台", Description = "所属平台")]
        public virtual Company Company { get; set; }


        [Display(Name = "所属承运人", Description = "所属承运人")]
        public int? CarrierId { get; set; }

        [ForeignKey("CarrierId")]
        [Display(Name = "所属承运人", Description = "所属承运人")]
        public virtual Carrier Carrier { get; set; }

        [Display(Name = "轴数", Description = "轴数(2/3)")]
        public int? Axles { get; set; }

        [Required]
        [Display(Name = "环保标志", Description = "环保标志（黄标/绿标）")]
        public string ECOMark { get; set; }

        [Display(Name = "额定载重", Description = "额定载重(吨)")]
        public int? StrLoadWeight { get; set; }


        [Display(Name = "收费吨位", Description = "运输车型(吨,尺等等),收费吨位")]
        public int? LoadWeight { get; set; }

   
        [Display(Name = "额定体积", Description = "额定体积(立方米)")]
        public int? LoadVolume { get; set; }
        


        [Display(Name = "车厢尺寸(尺)", Description = "车厢尺寸(尺)")]
        public decimal? CarriageSize { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "主驾司机", Description = "主驾司机")]
        public string Driver { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "主驾司机电话", Description = "主驾司机电话")]
        public string DriverPhone { get; set; }

        #endregion

        [MaxLength(20)]
        [Display(Name = "副驾司机", Description = "副驾司机")]
        public string AssistantDriver { get; set; }

        [MaxLength(50)]
        [Display(Name = "副驾司机电话", Description = "副驾司机电话")]
        public string AssistantDriverPhone { get; set; }

        //[Display(Name = "挂靠公司", Description = "挂靠公司")]
        //public int? VendorId { get; set; }

        //[ForeignKey("VendorId")]
        //[Display(Name = "挂靠公司", Description = "挂靠公司")]
        //public virtual Vendor Vendor { get; set; }

        [Display(Name = "车长(米)", Description = "车长(米)")]
        public decimal? VehLongSize { get; set; }

        [MaxLength(20)]
        [Display(Name = "箱型", Description = "箱型")]
        public string CubicleType { get; set; }

        [MaxLength(20)]
        [Display(Name = "车辆使用类型", Description = "车辆使用类型")]
        public string VehUseType { get; set; }

        [MaxLength(20)]
        [Display(Name = "海关编号", Description = "海关编号")]
        public string CustomsNo { get; set; }

        [MaxLength(20)]
        [Display(Name = "车辆用途", Description = "车辆用途")]
        public string VehUse { get; set; }

        [Display(Name = "平均油耗(L/100)", Description = "平均油耗(L/100)")]
        public decimal? AVGECON { get; set; }

        [Display(Name = "油耗因子", Description = "油耗因子")]
        public decimal? AVGECONScale { get; set; }

        [Display(Name = "总行驶里程", Description = "总行驶里程")]
        public decimal? RoadKM { get; set; }

        [Display(Name = "行驶时间", Description = "行驶时间")]
        public decimal? RoadHours { get; set; }

        [Display(Name = "里程因子", Description = "里程因子")]
        public decimal? RoadKMScale { get; set; }

        [MaxLength(50)]
        [Display(Name = "GPS设备编号", Description = "GPS设备编号")]
        public string GPSDeviceId { get; set; }

        [MaxLength(20)]
        [Display(Name = "车主", Description = "车主")]
        public string Owner { get; set; }

        [MaxLength(50)]
        [Display(Name = "车主联系电话", Description = "联系人电话")]
        public string OwnerContactPhone { get; set; }

        #endregion

        #region 档案信息

        [Display(Name = "品牌", Description = "品牌")]
        [MaxLength(20)]
        public string Brand { get; set; }

        [Display(Name = "额定转速", Description = "额定转速")]
        public int? RPM { get; set; }

        [Display(Name = "购买日期", Description = "购买日期")]
        public DateTime? PurchasedDate { get; set; }

        [Display(Name = "购买金额", Description = "购买金额")]
        public decimal? PurchasedAmount { get; set; }

        [Display(Name = "车厢长(米)", Description = "车厢长(米)")]
        public decimal? VehLong { get; set; }

        [Display(Name = "车厢宽(米)", Description = "车厢宽(米)")]
        public decimal? VehWide { get; set; }

        [Display(Name = "车厢高(米)", Description = "车厢高(米)")]
        public decimal? VehHigh { get; set; }

        [Display(Name = "车架号", Description = "车架号")]
        [MaxLength(50)]
        public string VIN { get; set; }

        [Display(Name = "使用年限", Description = "使用年限")]
        public int? ServiceLife { get; set; }

        [Display(Name = "保养公里数", Description = "保养公里数")]
        public int? MaintainKM { get; set; }

        [Display(Name = "下次保养日期", Description = "下次保养日期")]
        public DateTime? MaintainDate { get; set; }

        [Display(Name = "保养周期(月)", Description = "保养周期(月)")]
        public int? MaintainMonth { get; set; }

        #endregion

        #region 附加信息

        [Display(Name = "车辆尾板", Description = "车辆尾板")]
        public bool ExistVehTailBoard { get; set; }

        [Display(Name = "尾板品牌", Description = "尾板品牌")]
        [MaxLength(30)]
        public string VehTailBoardBrand { get; set; }

        [Display(Name = "尾板厂家", Description = "尾板厂家")]
        [MaxLength(30)]
        public string VehTailBoardFactory { get; set; }

        [Display(Name = "尾板使用年限", Description = "尾板使用年限")]
        public int? VehTailBoardLife { get; set; }

        [Display(Name = "尾板价值", Description = "尾板价值")]
        public decimal? VehTailBoardAmount { get; set; }

        [Display(Name = "尾板GPS设备编号", Description = "尾板GPS设备编号")]
        [MaxLength(50)]
        public string VehTailBoardGPSDeviceId { get; set; }

        #endregion

        #region 行驶证信息

        [Display(Name = "型号代码", Description = "型号代码")]
        [MaxLength(50)]
        public string DrLicenseModel { get; set; }

        [Display(Name = "使用性质", Description = "使用性质")]
        [MaxLength(50)]
        public string DrLicenseUseNature { get; set; }

        [Display(Name = "品牌", Description = "品牌")]
        [MaxLength(50)]
        public string DrLicenseBrand { get; set; }

        [Display(Name = "识别代码", Description = "识别代码")]
        [MaxLength(50)]
        public string DrLicenseDevId { get; set; }

        [Display(Name = "发动机号", Description = "发动机号")]
        [MaxLength(50)]
        public string DrLicenseEngineId { get; set; }

        [Display(Name = "注册日期", Description = "注册日期")]
        public DateTime? DrLicenseRegistrationDate { get; set; }

        [Display(Name = "发证日期", Description = "发证日期")]
        public DateTime? DrLicensePubDate { get; set; }

        [Display(Name = "额定人数", Description = "额定人数")]
        public int? DrLicenseRatedUsers { get; set; }

        [Display(Name = "车辆重量(吨)", Description = "车辆重量(吨)")]
        public decimal? DrLicenseVehWeight { get; set; }

        [Display(Name = "整备重量(吨)", Description = "整备重量(吨)")]
        public decimal? DrLicenseDevWeight { get; set; }

        [Display(Name = "净重(吨)", Description = "净重(吨)")]
        public decimal? DrLicenseNetWeight { get; set; }

        [Display(Name = "净空(立方)", Description = "净空(立方)")]
        public decimal? DrLicenseNetVolume { get; set; }

        [Display(Name = "外限宽(米)", Description = "外限宽(米)")]
        public decimal? DrLicenseVehWide { get; set; }

        [Display(Name = "外限高(米)", Description = "外限高(米)")]
        public decimal? DrLicenseVehHigh { get; set; }

        [Display(Name = "外限长(米)", Description = "外限长(米)")]
        public decimal? DrLicenseVehLong { get; set; }

        [Display(Name = "强制报废日期", Description = "强制报废日期")]
        public DateTime? DrLicenseScrapedDate { get; set; }

        #endregion

        #region 道路行驶证

        [Display(Name = "文管子号", Description = "文管子号")]
        [MaxLength(50)]
        public string LoLicenseManageId { get; set; }

        [Display(Name = "运营许可证号", Description = "运营许可证号")]
        [MaxLength(50)]
        public string LoLicenseId { get; set; }

        [Display(Name = "经营范围", Description = "经营范围")]
        [MaxLength(50)]
        public string LoLicenseBusinessScope { get; set; }

        [Display(Name = "发证日期", Description = "发证日期")]
        public DateTime? LoLicensePubDate { get; set; }

        [Display(Name = "二级有效期", Description = "二级有效期")]
        public DateTime? LoLicenseValidDate { get; set; }

        [Display(Name = "年检日期", Description = "年检日期")]
        public DateTime? LoLicenseCheckDate { get; set; }

        [Display(Name = "注册地", Description = "注册地")]
        [MaxLength(30)]
        public string LoLicensePlace { get; set; }

        #endregion

        #region 保险卡信息

        [Display(Name = "交强险保单", Description = "交强险保单")]
        [MaxLength(50)]
        public string InsTrafficPolicyId { get; set; }

        [Display(Name = "保险公司", Description = "保险公司")]
        [MaxLength(50)]
        public string InsTrafficPolicyCompany { get; set; }

        [Display(Name = "交强险保单有效期", Description = "交强险保单有效期")]
        [MaxLength(50)]
        public string InsTrafficPolicyVaildateDate { get; set; }

        [Display(Name = "交强险保额", Description = "交强险保额")]
        public decimal? InsTrafficPolicyAmount { get; set; }

        [Display(Name = "第三者保单号", Description = "第三者保单号")]
        [MaxLength(50)]
        public string InsThirdPartyId { get; set; }

        [Display(Name = "第三者保单有效期", Description = "第三者保单有效期")]
        public DateTime? InsThirdPartyVaildateDate { get; set; }

        [Display(Name = "第三者保单额", Description = "第三者保单额")]
        public decimal? InsThirdPartyAmount { get; set; }

        [Display(Name = "物流责任险保额", Description = "物流责任险保额")]
        public decimal? InsThirdPartyLogisticsAmount { get; set; }

        [Display(Name = "物流责任险有效期", Description = "物流责任险有效期")]
        public DateTime? InsThirdPartyLogisticsVaildateDate { get; set; }

        #endregion

     
        [Display(Name = "状态", Description = "状态(空车,配载,完成)")]
        [MaxLength(20)]
        public string Status { get; set; }
    }


}