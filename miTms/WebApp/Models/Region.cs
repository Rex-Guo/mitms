using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
    public partial class Region:Entity
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="邮政编码")]
        [MaxLength(10)]
        public string Code { get; set; }
        [Display(Name = "名称")]
        [MaxLength(50)]
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}