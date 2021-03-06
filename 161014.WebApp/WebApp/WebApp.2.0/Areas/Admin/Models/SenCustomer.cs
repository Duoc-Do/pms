﻿
//------------------------------------------------------------------------------
// <auto-generated>
// gen by lotusviet.vn
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Areas.Admin.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("SenCustomer")]
    public partial class SenCustomer
    {
        public SenCustomer()
        {
            this.SenContracts = new HashSet<SenContract>(); 
        }


        [Key]
        public int CustomerId { get; set; }
        public string Address { get; set; }
        [ForeignKey("Assign")]
        public Nullable<Guid> AssignedTo { get; set; }
        public string Contact { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public string CustomerCode { get; set; }
        public string EmailAddress { get; set; }
        public string FaxNumber { get; set; }
        public bool IsActive { get; set; }
        public string LeadSource { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string TaxCode { get; set; }
        public string TelephoneNumber { get; set; }
        [ForeignKey("User")]
        public Nullable<Guid> UserId { get; set; }
        public string WebPage { get; set; }


        public virtual vw_aspnet_MembershipUsers User { get; set; }
        public virtual vw_aspnet_MembershipUsers Assign { get; set; }

        public virtual ICollection<SenContract> SenContracts { get; set; }

    }
}