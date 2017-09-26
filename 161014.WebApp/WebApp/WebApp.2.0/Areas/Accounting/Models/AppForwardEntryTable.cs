//------------------------------------------------------------------------------
// <auto-generated>
// gen by lotusviet.vn
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Areas.Accounting.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("AppForwardEntryTable")]
    public partial class AppForwardEntryTable
    {
        public Nullable<int> AccountCreditLineID { get; set; }
        public Nullable<int> AccountDebitLineID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<bool> DebitToCredit { get; set; }
        public string ForwardEntryCode { get; set; }
        [Key]
        public int ForwardEntryID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string Name { get; set; }

    }
}
