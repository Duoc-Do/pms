//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Areas.Accounting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AppAccountView2")]
    public partial class AppAccountView2
    {
        [Key]
        public int AccountID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string DisplayNumber { get; set; }
        public string Name { get; set; }
        public bool IsAccountObject { get; set; }
        public bool IsAccountLedger { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string ParentDisplayNumber { get; set; }
    }
}
