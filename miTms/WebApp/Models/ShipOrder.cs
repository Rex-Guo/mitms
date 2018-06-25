using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
    public partial class ShipOrder:Entity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "派车单号", Description = "派车单号")]
        [MaxLength(20)]
        [Required]
        public string OrderNo { get; set; }
        [Display(Name = "对账单号", Description = "对账单号")]
        [MaxLength(30)]
        public string ExternalNo { get; set; }
        [Display(Name = "派车时间", Description = "派车时间")]
        public DateTime OrderDate { get; set; }
        #region 承运人信息
        [Display(Name = "承运人", Description = "承运人")]
        public int CarrierId { get; set; }
        [ForeignKey("CarrierId")]
        [Display(Name = "承运人", Description = "承运人")]
        public virtual Carrier Carrier { get; set; }
        [Display(Name = "承运车", Description = "承运车")]
        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        [Display(Name = "承运车", Description = "承运车")]
        public virtual Vehicle Vehicle { get; set; }
        [Display(Name = "车辆类型", Description = "车辆类型")]
        public string CarType { get; set; }
        #endregion
        #region 可选跟踪信息
        [Display(Name = "起点", Description = "起点")]
        [MaxLength(120)]
        public string Location1 { get; set; }
        [Display(Name = "终点", Description = "终点")]
        [MaxLength(120)]
        public string Location2 { get; set; }
        [Display(Name = "额外要求", Description = "额外要求")]
        [MaxLength(120)]
        public string Requirements { get; set; }
        [Display(Name = "时效(小时)", Description = "时效(小时)")]
        public int TimePeriod { get; set; }
        [Display(Name = "计划发车时间", Description = "计划发车时间")]
        public DateTime? PlanDepartDate { get; set; }
        [Display(Name = "计划送达时间", Description = "计划送达时间")]
        public DateTime? PlanDeliveryDate { get; set; }
        [Display(Name = "实际发车时间", Description = "实际发车时间")]
        public DateTime? DepartDate { get; set; }
        [Display(Name = "实际送达时间", Description = "实际送达时间")]
        public DateTime? DeliveryDate { get; set; }
        [Display(Name = "回单时间", Description = "回单时间")]
        public DateTime? ClosedDate { get; set; }
        #endregion
        #region 明细汇总信息
        [Display(Name = "订单数", Description = "订单数")]
        public int ItemCount { get; set; }
        [Display(Name = "总件数", Description = "总件数")]
        public int? Packages { get; set; }
        [Display(Name = "重量(千克)", Description = "重量(千克)")]
        public decimal? Weight { get; set; }
        [Display(Name = "体积(立方)", Description = "体积(立方)")]
        public decimal? Volume { get; set; }
        [Display(Name = "栈板数", Description = "栈板数")]
        public int? Pallets { get; set; }
        [Display(Name = "箱数", Description = "箱数")]
        public int? Cartons { get; set; }
        [Display(Name = "散箱数", Description = "散箱数/散件")]
        public int? BreakCartons { get; set; }
        #endregion

        [Display(Name = "调度人员", Description = "调度人员")]
        [MaxLength(20)]
        [Required]
        public string InputUser { get; set; }
        [Required]
        [Display(Name = "所属平台", Description = "所属平台")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        [Display(Name = "所在平台", Description = "所在平台")]
        public virtual Company Company { get; set; }


    }
}