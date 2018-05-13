using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
    public partial class TransactionHistory:Entity
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "订单号", Description = "订单号")]
        [MaxLength(20)]
        public string OrderNo { get; set; }
        [Display(Name = "车牌号", Description = "车牌号")]
        [MaxLength(10)]
        public string PlateNumber { get; set; }
        [Display(Name = "状态", Description = "状态")]
        [MaxLength(20)]
        public string Status { get; set; }
        [Display(Name = "更新时间", Description = "更新时间")]
        public DateTime TransactioDateTime { get; set; }
        [Display(Name = "备注", Description = "备注")]
        [MaxLength(120)]
        public string Remark { get; set; }
        [Display(Name = "标识1", Description = "标识1")]
       
        public int Flag1 { get; set; }
        [Display(Name = "标识2", Description = "标识2")]

        public int Flag2 { get; set; }
        [Display(Name = "操作人员", Description = "操作人员")]
        [MaxLength(20)]
        public string InputUser { get; set; }


    }
}