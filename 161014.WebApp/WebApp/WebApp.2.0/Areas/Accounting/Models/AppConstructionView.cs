
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
    [Table("AppConstructionView")]
    public partial class AppConstructionView
    {
        public AppConstructionView()
        {
            this.ConstructionDateFrom = DateTime.Today;
            this.ConstructionDateTo = DateTime.Today;
            this.IsActive = true;
        }


        public string ConstructionCode { get; set; }
        public Nullable<System.DateTime> ConstructionDateFrom { get; set; }
        public Nullable<System.DateTime> ConstructionDateTo { get; set; }
        [Key]
        public int ConstructionID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string Name { get; set; }
        public string ParentCode { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string ParentName { get; set; }
    }
}