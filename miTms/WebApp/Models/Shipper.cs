using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
    public partial class Shipper:Entity
    {
        [Key]
        public int Id { get; set; }
       
        [Display(Name = "托运人", Description = "托运人")]
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        [Display(Name = "托运人类别", Description = "托运人类别(1：个体托运人 2：企业托运人)")]
        [Required]
        public int Type { get; set; }
        [Display(Name = "联系人", Description = "联系人")]
        [MaxLength(50)]
        [Required]
        public string ContactName { get; set; }
        [Display(Name = "联系人身份证号", Description = "联系人身份证号")]
        [MaxLength(18)]
        [Required]
        public string ContactIdCard { get; set; }
        [Display(Name = "联系人移动电话", Description = "联系人移动电话")]
        [MaxLength(18)]
        [Required]
        public string ContactMobileTelephoneNumber { get; set; }
        [Display(Name = "联系人电话", Description = "联系人移动电话")]
        [MaxLength(18)]
    
        public string ContactTelephoneNumber { get; set; }
        [Display(Name = "证件号", Description = "证件号")]
        [MaxLength(35)]
        public string PersonalIdentityDocument { get; set; }
        [Display(Name = "注册地", Description = "注册地")]
        [MaxLength(256)]
        public string RegisteredAddress { get; set; }
        [Display(Name = "注册资金", Description = "注册资金(单位万元)")]

        public decimal RegisteredCapital { get; set; }
        [Display(Name = "统一社会信用代码 ", Description = "统一社会信用代码 ")]
        [MaxLength(18)]
        public string UnifiedSocialCreditldentifier { get; set; }
        [Display(Name = "统一社会信用代码注册时间", Description = "统一社会信用代码注册时间 ")]
        public DateTime? UnifiedsocialDatetime { get; set; }

        [Display(Name = "描述", Description = "描述")]
        [MaxLength(512)]
        public string Description { get; set; }
        [Display(Name = "图片路径", Description = "图片路径")]
        [MaxLength(256)]
        public string LogoPicture { get; set; }

        [Display(Name = "所在平台", Description = "所在平台")]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [Display(Name = "所在平台", Description = "所在平台")]
        public virtual Company Company { get; set; }



        [Display(Name = "注册日期")]
        public DateTime RegistrationDatetime { get; set; }
        [Display(Name = "注册日期")]
        public DateTime? UpdateTimeDatetime { get; set; }
        [Display(Name = "黑名单")]
        public bool IsBlaclkList { get; set; }
        [Display(Name = "删除标志")]
        public bool IsDeleteFlag { get; set; }
        [Display(Name = "同步时间")]
        public DateTime? SynchronizationTime { get; set; }
        [Display(Name = "同步异常")]
        public bool IsException { get; set; }
    }
}