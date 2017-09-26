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


    [Table("AppSalesTaxTable")]
    public partial class AppSalesTaxTable
    {
        public AppSalesTaxTable()
        {
            //this.AppDocumentVATTables = new HashSet<AppDocumentVATTable>();
            //this.AppDocumentVATTempTables = new HashSet<AppDocumentVATTempTable>();
        }
    
        [Key]
        public int SalesTaxID { get; set; }
        public string SalesTaxCode { get; set; }
        public string Name { get; set; }
        public decimal Percentage { get; set; }
        public string DisplayNumber { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
    
        //public virtual ICollection<AppDocumentVATTable> AppDocumentVATTables { get; set; }
        //public virtual ICollection<AppDocumentVATTempTable> AppDocumentVATTempTables { get; set; }
    }
}
