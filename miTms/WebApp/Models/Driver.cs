using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
    public partial class Driver : Entity
    {
        public int Id { get; set; }
        [Display(Name = "姓名")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Display(Name = "性别")]
        public int Gender { get; set; }
        [Display(Name = "性别")]
        [MaxLength(18)]
        public string IdentityDocumentNumber { get; set; }
        [Display(Name = "移动电话")]
        [MaxLength(18)]
        public string MobileTelephoneNumber { get; set; }
        [Display(Name = "电话")]
        [MaxLength(18)]
        public string TelephoneNumber { get; set; }
        [Display(Name = "从业资格信息证号")]
        [MaxLength(19)]
        public string QualificationCertificateNumber { get; set; }
        [Display(Name = "从业资格信息证号")]
        [MaxLength(512)]
        public string Remark { get; set; }
        [Display(Name = "描述", Description = "描述")]
        [MaxLength(512)]
        public string Description { get; set; }
        [Display(Name = "图片路径", Description = "图片路径")]
        [MaxLength(256)]
        public string LogoPicture { get; set; }

        [Display(Name = "承运人")]
        public int Carrierid { get; set; }
        [ForeignKey("Carrierid")]
        public virtual Carrier Carrier { get;set;}
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

        [Display(Name = "所属公司", Description = "所属公司")]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [Display(Name = "所属公司", Description = "所属公司")]
        public virtual Company Company { get; set; }

    }
}