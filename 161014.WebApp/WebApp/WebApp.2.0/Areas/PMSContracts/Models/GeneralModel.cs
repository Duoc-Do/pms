namespace WebApp.Areas.PMSContracts.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Table("CONTRACTS_CONDITIONS_GENERAL")]
    public partial class GeneralModel
    {
        [key]
        public long Id { get; set; }

        public long ContractID { get; set; }


        public string ClauseCode { get; set; }

        public string ClauseContent { get; set; }


        public string OriginalLanguage { get; set; }

        public long? ParentId { get; set; }


        public string BookType { get; set; }

        public DateTime? CreationDate { get; set; }
 

        public string Type { get; set; }
    }
}
