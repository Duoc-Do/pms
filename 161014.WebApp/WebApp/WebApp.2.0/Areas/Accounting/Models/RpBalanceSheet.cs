
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
    [Table("RpBalanceSheet")]
    public partial class RpBalanceSheet
    {
        public Nullable<decimal> AmountBG { get; set; }
        public Nullable<decimal> AmountEnd { get; set; }
        public Nullable<decimal> AmountFCBG { get; set; }
        public Nullable<decimal> AmountFCEnd { get; set; }
        public string DisplayNumber { get; set; }
        public string Explanation { get; set; }
        public string Formula { get; set; }
        public Nullable<int> FormulaOrder { get; set; }
        public Nullable<bool> IsAccountObject { get; set; }
        public Nullable<bool> IsAsset { get; set; }
        public Nullable<bool> IsBold { get; set; }
        public Nullable<bool> IsNegative { get; set; }
        public Nullable<bool> IsPrint { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int ReportID { get; set; }
        public Nullable<int> ReportOrder { get; set; }

    }
}