using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
    public partial class LineOffer:Entity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        [Display(Name = "方案", Description = "方案(整车/拼车)")]
        public string Project { get; set; }
        [MaxLength(50)]
        [Display(Name = "起点", Description = "起点")]
        public string Location1 { get; set; }
        [MaxLength(50)]
        [Display(Name = "终点", Description = "终点")]
        public string Location2 { get; set; }
        [MaxLength(20)]
        [Display(Name = "时效", Description = "时效(当日达/次日达/隔日达)")]
        public string TimeLimit { get; set; }
        [MaxLength(20)]
        [Display(Name = "车型", Description = "车型(吨位/尺寸)")]
        public string VehicleType { get; set; }
        [MaxLength(20)]
        [Display(Name = "计费方式", Description = "计费方式(每吨/每立方)")]
        public string PiceType { get; set; }
        [Display(Name = "单价", Description = "单价")]
        public decimal Price { get; set; }
        [Display(Name = "详细备注", Description = "详细备注")]
        [MaxLength(520)]
        public string Remark { get; set; }

    }
}