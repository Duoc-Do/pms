
//------------------------------------------------------------------------------
// <auto-generated>
// gen by lotusviet.vn
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Areas.Accounting.Models
{
    using System;
    using System.Collections.Generic;

    public partial class AppVCA03PrintView
    {

        public Nullable<int> AccountCreditID { get; set; }
        public Nullable<int> AccountDebitID { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public string CurrencyCompanyName { get; set; }
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public string CustomerCode { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public string DisplayNumberCredit { get; set; }
        public string DisplayNumberDebit { get; set; }
        public long DocumentID { get; set; }
        public decimal ExchangeRate { get; set; }
        public string IsoCode { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string NumberToWords { get; set; }
        public string NumberToWordsFC { get; set; }
        public Nullable<int> NumberVAT { get; set; }
        public Nullable<long> ParentID { get; set; }
        public Nullable<int> PostType { get; set; }
        public Nullable<decimal> SumAmount { get; set; }
        public Nullable<decimal> SumAmountFC { get; set; }
        public Nullable<decimal> SumAmountVAT { get; set; }
        public Nullable<decimal> SumAmountVATFC { get; set; }
        public Nullable<decimal> SumTotal { get; set; }
        public Nullable<decimal> SumTotalFC { get; set; }
        public string VoucherCode { get; set; }
        public System.DateTime VoucherDate { get; set; }
        public int VoucherID { get; set; }
        public string VoucherName { get; set; }
        public string VoucherNumber { get; set; }

    }
}