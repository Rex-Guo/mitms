using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
    public partial class ShipOrderDetail : Entity
    {
        [Key]
        public int Id { get; set; }
        #region 订单信息
        [Display(Name = "订单号", Description = "订单号")]
        [MaxLength(20)]
        public string OrderNo{get;set;}
        [Display(Name = "订单", Description = "订单")]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        [Display(Name = "订单", Description = "订单")]
        public virtual Order Order { get; set; }
        [Display(Name = "起点", Description = "起点")]
        [MaxLength(120)]
        public string Location1 { get; set; }
        [Display(Name = "装货点", Description = "装货点")]
        [MaxLength(50)]
        public string LoadTransportStationName { get; set; }
        [Display(Name = "终点", Description = "终点")]
        [MaxLength(120)]
        public string Location2 { get; set; }
    
        [Display(Name = "卸货点", Description = "卸货点")]
        [MaxLength(50)]
        public string ReceiptTransportStationName { get; set; }
        [Display(Name = "订单状态", Description = "订单状态")]
        public int Status { get; set; }
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
        [Display(Name = "发运单", Description = "发运单")]
        public int ShipOrderId { get; set; }
        [Display(Name = "发运单号", Description = "发运单号")]
        [MaxLength(20)]
        public string ShipOrderNo { get; set; }
        [ForeignKey("ShipOrderId")]
        [Display(Name = "发运单", Description = "发运单")]
        public virtual ShipOrder ShipOrder { get; set; }
    }
}