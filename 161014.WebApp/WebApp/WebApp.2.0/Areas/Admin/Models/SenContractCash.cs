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
    [Table("SenContractCash")]
    public partial class SenContractCash
    {
        [Key]
        public int ContractCashId { get; set; }
        public decimal Amount { get; set; }
        public int CashType { get; set; }
        public int ContractId { get; set; }
        public Nullable<Guid> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Description { get; set; }
        public System.DateTime VoucherDate { get; set; }

    }
}