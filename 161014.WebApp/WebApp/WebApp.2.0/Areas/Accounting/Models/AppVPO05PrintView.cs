//------------------------------------------------------------------------------
// <auto-generated>
// gen by lotusviet.vn
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Areas.Accounting.Models
{
    using System;
    using System.Collections.Generic;
    public partial class AppVPO05PrintView
    {

        public Nullable<int> AccountCreditID { get; set; }
        public Nullable<int> AccountCreditLine1ID { get; set; }
        public Nullable<int> AccountCreditLineID { get; set; }
        public Nullable<int> AccountDebitID { get; set; }
        public Nullable<int> AccountDebitLine1ID { get; set; }
        public Nullable<int> AccountDebitLineID { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> AmountCost { get; set; }
        public Nullable<decimal> AmountCostFC { get; set; }
        public Nullable<decimal> AmountFC { get; set; }
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
        public string DescriptionLine { get; set; }
        public string DisplayNumberCredit { get; set; }
        public string DisplayNumberDebit { get; set; }
        public string DisplayNumberLine1Credit { get; set; }
        public string DisplayNumberLine1Debit { get; set; }
        public string DisplayNumberLineCredit { get; set; }
        public string DisplayNumberLineDebit { get; set; }
        public Nullable<long> DocumentID { get; set; }
        public Nullable<long> DocumentLineID { get; set; }
        public Nullable<int> DocumentLineType { get; set; }
        public string DocumentLineTypeName { get; set; }
        public Nullable<decimal> Duty { get; set; }
        public Nullable<decimal> DutyFC { get; set; }
        public Nullable<decimal> DutyPercentage { get; set; }
        public decimal ExchangeRate { get; set; }
        public string IsoCode { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> ItemID { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> MeasureRate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string NumberToWords { get; set; }
        public string NumberToWordsFC { get; set; }
        public Nullable<int> NumberVAT { get; set; }
        public Nullable<long> ParentID { get; set; }
        public Nullable<System.DateTime> ParentLineDate { get; set; }
        public Nullable<int> ParentLineID { get; set; }
        public string ParentLineNumber { get; set; }

        public Nullable<int> PostType { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Quantity0 { get; set; }
        public decimal SumAmount { get; set; }
        public decimal SumAmountCost { get; set; }
        public decimal SumAmountCostFC { get; set; }
        public decimal SumAmountFC { get; set; }
        public decimal SumAmountVAT { get; set; }
        public decimal SumAmountVATFC { get; set; }
        public decimal SumDuty { get; set; }
        public decimal SumDutyFC { get; set; }
        public Nullable<decimal> SumTotal { get; set; }
        public Nullable<decimal> SumTotalFC { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> UnitPriceFC { get; set; }
        public string UOMCode { get; set; }
        public Nullable<int> UOMID { get; set; }
        public string VoucherCode { get; set; }
        public System.DateTime VoucherDate { get; set; }
        public int VoucherID { get; set; }
        public string VoucherName { get; set; }
        public string VoucherNumber { get; set; }
        public string WarehouseLineCode { get; set; }
        public Nullable<int> WarehouseLineID { get; set; }
        public string WarehouseLineName { get; set; }
    }
}