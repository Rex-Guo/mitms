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
        [Display(Name = "派车单号", Description = "派车单号")]
        [MaxLength(20)]
        public string OrderNo { get; set; }
        [Display(Name = "对账单号", Description = "对账单号")]
        [MaxLength(20)]
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
        [Required]
        public string InputUser { get; set; }
        #endregion
        #region 订单状态信息
        [Display(Name = "状态", Description = "状态")]
        [MaxLength(20)]
        public string Status { get; set; }
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
        [Display(Name = "联系人", Description = "联系人")]
        [MaxLength(20)]
        public string Contact { get; set; }
        [Required]
        [Display(Name = "所属公司", Description = "所属公司")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        [Display(Name = "所属公司", Description = "所属公司")]
        public virtual Company Company { get; set; }

        #endregion
    }
}