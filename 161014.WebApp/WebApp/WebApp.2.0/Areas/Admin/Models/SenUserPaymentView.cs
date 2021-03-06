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
    [Table("SenUserPaymentView")]
    public partial class SenUserPaymentView
    {
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Nullable<Guid> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Description { get; set; }
        public string PackageName { get; set; }
        public string UserName { get; set; }
        [Key]
        public int UserPaymentId { get; set; }
        public System.DateTime VoucherDate { get; set; }

        public Nullable<Guid> UserId { get; set; }

    }
}