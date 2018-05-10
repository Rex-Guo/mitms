namespace WebApp.Models
{
    using Repository.Pattern.Ef6;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    [Serializable]
    [DisplayColumn("Name")]
    public partial class Customer : Entity
    { 
        public Customer()
        {
           
        }

        [Display(Name = "系统编号", Description = "系统编号", Order = 1)]
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "企业名称", Description = "企业名称", Order = 2)]
        [StringLength(20)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Display(Name = "客服人员", Description = "客服人员", Order = 12)]
        [StringLength(30)]
        public string ServiceUser { get; set; }

        
        [Display(Name = "业务类型", Description = "业务类型", Order = 4)]
        [StringLength(20)]
        public string TradeType { get; set; }

        [Display(Name = "法人", Description = "法人", Order = 5)]
        [StringLength(10)]
        public string LegalPerson { get; set; }

        [Display(Name = "纳税注册登记号", Description = "纳税注册登记号", Order = 6)]
        [StringLength(50)]
        public string RegistrationNumber { get; set; }

   

     

        [Display(Name = "联系人", Description = "联系人" )]
        [StringLength(30)]
        public string LinkMan { get; set; }

        [Display(Name = "联系电话", Description = "联系电话", Order = 9)]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Display(Name = "电子邮件", Description = "电子邮件", Order = 10)]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "传真", Description = "传真", Order = 11)]
        [StringLength(50)]
        public string Fax { get; set; }

        [Display(Name = "客服负责人", Description = "客服负责人", Order = 12)]
        [StringLength(20)]
        public string CustomerService { get; set; }

        [Display(Name = "业务员", Description = "业务员", Order = 13)]
        [StringLength(20)]
        public string Sales { get; set; }

        [Display(Name = "付款方式", Description = "付款方式", Order = 14)]
        [StringLength(20)]
        public string Payment { get; set; }

        [Display(Name = "账期(天)", Description = "账期(天)", Order = 15)]
        public int? PaymentDays { get; set; }

        #region 开票信息

        [Display(Name = "开户银行", Description = "开户银行")]
        [StringLength(50)]
        public string BankName { get; set; }

        [Display(Name = "银行账号", Description = "银行账号")]
        [StringLength(50)]
        public string BankAccount { get; set; }

        [Display(Name = "发票标题", Description = "发票标题")]
        [StringLength(50)]
        public string InvoiceTitle { get; set; }

        [Display(Name = "结算单号", Description = "结算单号", Order = 16)]
        [StringLength(50)]
        public string PaymentNumber { get; set; }

        #endregion


        [Display(Name = "所属公司", Description = "所属公司")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        [Display(Name = "所属公司", Description = "所属公司")]
        public virtual Company Company { get; set; }
        [Display(Name = "地址", Description = "地址")]
        public string Address { get; set; }
       
    }
}
