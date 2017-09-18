namespace PMSContract
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTRACTS")]
    public partial class ContractModel
    {
        [Key]
        [Display(Name ="Contract ID")]
        public long ContractID { get; set; }

        [Display(Name = "Contract IDERP")]
        [Required]
        public string ContractIDERP { get; set; }

        [Display(Name = "CCE ID")]
        [Required]
        public string CCE_ID { get; set; }

        [Display(Name = "Code")]
        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage =" Code must be between 3 - 100 characters long")]
        public string ContractCode { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.MultilineText)]
        public DateTime? ContractDate { get; set; }

        [Display(Name = "Commencement Date")]
        public DateTime? CommencementDate { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Vietnamese Description")]
        public string Description_VN { get; set; }
        [Display(Name = "Format")]
        public byte? ContractFormat { get; set; }

        [Display(Name = "FC Amount")]
        public decimal? FCAmount { get; set; }

        [Display(Name = "LC Amount")]
        public decimal? LCAmount { get; set; }

        [Display(Name = "FC Amooount Extension")]
        public decimal? FCAmountExtension { get; set; }

        [Display(Name = "LC Amount Extension")]
        public decimal? LCAmountExtension { get; set; }
        [Display(Name = "Client ID")]
        public int? ClientID { get; set; }
        [Display(Name = "Contractor ID")]
        public int? ContractorID { get; set; }
        [Display(Name = "Duratin In Days")]
        public int? DurationInDays { get; set; }
        [Display(Name = "Extension In Day")]
        public int? ExtensionInDays { get; set; }
        [Display(Name = "Modify Date")]
        public DateTime? ModifyDate { get; set; }

        [Display(Name = "Currency Code")]
        public string CurrencyCode { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "For Ordering")]
        public byte? ForOrdering { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }
        [Display(Name = "Project ID")]
        public long? proj_id { get; set; }

        [Display(Name = "Project Status")]
        public string proj_status { get; set; }
    }
}
