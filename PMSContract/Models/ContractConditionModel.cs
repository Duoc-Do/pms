namespace PMSContract
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTRACTCONDITION")]
    public partial class ContractConditionModel
    {
        [Key]

        public long Id { get; set; }

        public long ContractID { get; set; }

        [StringLength(50)]
        public string ClauseCode { get; set; }

        [StringLength(500)]
        public string ClauseContent { get; set; }

        [StringLength(2)]
        public string OriginalLanguage { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(6)]
        public string Type { get; set; }

    }
}
