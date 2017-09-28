using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Areas.PMSContracts.Models
{
    [Table("CONTRACTS_CLIENTS")]
    public class ClientModel
    {
        public ClientModel()
        {
            ContractModel = new HashSet<ContractModel>();
        }
        [Key]
        public int ClientID { get; set; }

       
        public string ResName { get; set; }

        public int? Territory { get; set; }

       
        public string AccountNumber { get; set; }

       
        public string Bank { get; set; }

       
        public string CompanyAddress { get; set; }

       
        public string DeskPhone { get; set; }

       
        public string Email { get; set; }

  
        public string Type { get; set; }

       
        public string CompanyName { get; set; }

       
        public string Fax { get; set; }

       
        public string HandPhone { get; set; }

        public bool? Status { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<ContractModel> ContractModel { get; set; }
    }
}