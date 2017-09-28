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

    [Table("AppVoucherView")]
    public partial class AppVoucherView
    {
        public string AssemblyName { get; set; }
        public string AssemblyTypeName { get; set; }
        [Key]
        public int VoucherID { get; set; }
        public string VoucherCode { get; set; }
        public string VoucherName { get; set; }
        public string AlphaPart { get; set; }
        public Nullable<int> IntegerPart { get; set; }
        public string PostStoreProcedure { get; set; }
        public string BusinessCode { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
    }
}