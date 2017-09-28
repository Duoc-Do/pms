
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
    using System.Linq;

    [Table("AppItemTable")]
    public partial class AppItemTable
    {

        public Nullable<int> AccountCreditID { get; set; }
        public Nullable<int> AccountDebitID { get; set; }
        public Nullable<int> AccountID { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsInventory { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> ItemGroupID { get; set; }
        [Key]
        public int ItemID { get; set; }
        public int ItemMethodType { get; set; }
        public int ItemType { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> QuantityMax { get; set; }
        public Nullable<decimal> QuantityMin { get; set; }
        public int UOMID { get; set; }


        //public virtual ICollection<AppItemExTable> AppItemExTables { get; set; }
        [NotMapped]
        public string ItemPicture { get; set; }

        [NotMapped]
        public Nullable<int> IsolationDay { get; set; }

        [NotMapped]
        public Nullable<decimal> CurrentQuantity { get; set; }


    }
}
