using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
    public partial class LineQuotes:Entity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        [Display(Name = "方案", Description = "方案(整车/拼车)")]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Display(Name = "起点", Description = "起点")]
        [Required]
        public string Location1 { get; set; }
        [MaxLength(50)]
        [Display(Name = "终点", Description = "终点")]
        [Required]
        public string Location2 { get; set; }
         
        [Display(Name = "时效", Description = "时效(当日达/次日达/隔日达)")]
        [Required]
        public int TimePeriod { get; set; }
        [MaxLength(20)]
        [Display(Name = "计费车型", Description = "车型(吨位/尺寸)")]
        public string PiceVehicleType { get; set; }
        [MaxLength(20)]
        [Display(Name = "计费方式", Description = "计费方式(每吨/每立方)")]
        public string PiceType { get; set; }
        [Display(Name = "单价", Description = "单价")]
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "备注", Description = "备注")]
        [MaxLength(520)]
        public string Remark { get; set; }
        [Display(Name = "详细说明", Description = "详细说明")]
        public string Description { get; set; }
        [MaxLength(20)]
        [Display(Name = "输入人员", Description = "输入人员")]
        public string InputUser { get; set; }

        [Display(Name = "承运人", Description = "承运人")]
        public int? CarrierId { get; set; }
        [Display(Name = "承运人", Description = "承运人")]
        [ForeignKey("CarrierId")]
        public virtual Carrier Carrier { get; set; }

        [Display(Name = "平台", Description = "平台")]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [Display(Name = "平台", Description = "平台")]
        public virtual Company Company { get; set; }

    }
}