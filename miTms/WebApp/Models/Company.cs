using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public partial class Company : Entity
    {
        public Company()
        {
             
        }
        [Key]
        public int Id { get; set; }
        [Display(Name="企业名称")]
        [MaxLength(256)]
        [Required]
        
        public string Name { get; set; }
        [Display(Name = "企业注册地址")]
        [MaxLength(256)]
        [Required]
        public string Address { get; set; }
        [Display(Name = "注册资金")]
        public decimal RegisteredCapital { get; set; }
        
            [Display(Name = "统一社会信用代码")]
        [MaxLength(18)]
        [Required]
        public string UnifiedSocialCreditldentifier { get; set; }
        [Display(Name = "统一社会信用代码注册时间")]
        public DateTime UnifiedSocialDatetime { get; set; }
        [Display(Name = "经营范围")]
        [MaxLength(512)]
        [Required]
        public string BusinessScope { get; set; }
        [Display(Name = "营业执照期限开始日期")]
        public DateTime BusinessLicenseStartDatetime { get; set; }
        [Display(Name = "营业执照期限结束日期")]
        public DateTime BusinessLicenseendDatetime { get; set; }
        [Display(Name = "所属辖区")]
        [MaxLength(12)]
        [Required]
        public string CountrySubdivisionCode { get; set; }
       
            [Display(Name = "道路运输经营许可证号码")]
        [MaxLength(50)]
        [Required]
        public string PermitNumber { get; set; }
        [Display(Name = "法人")]
        [MaxLength(18)]
        [Required]
        public string LegalPersonName { get; set; }
        [Display(Name = "法人联系电话")]
        [MaxLength(18)]
        [Required]
        public string LegalPersonTelehoneNumber { get; set; }
        [Display(Name = "联系人")]
        [MaxLength(18)]
        [Required]
        public string ContactName { get; set; }
        [Display(Name = "联系人移动电话")]
        [MaxLength(18)]
        [Required]
        public string ContactMobileTelephoneNumber { get; set; }
        [Display(Name = "传真")]
        [MaxLength(18)]
        public string FaxNumber { get; set; }
        [Display(Name = "互联网识别代码")]
        [MaxLength(18)]
        public string InternetPlusProperty { get; set; }
        [Display(Name = "删除标志")]
        public bool IsDeleteFlag { get; set; }
        [Display(Name = "同步时间")]
        public DateTime? SynchronizationTime { get; set; }
        [Display(Name = "同步异常")]
        public bool IsException { get; set; }
      
    }


    public class CompanyViewModel
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public int Type { get; set; }
    }
}