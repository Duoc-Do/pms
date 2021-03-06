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
    [Table("SysTableDetailView")]
    public partial class SysTableDetailView
    {
        [Key, Column(Order = 0)]
        [ForeignKey("SysTable")]
        public string TableName { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("SysColumn")]
        public string ColumnName { get; set; }
        public bool UType { get; set; }
        public string Des { get; set; }
        public Nullable<int> GridViewOrder { get; set; }
        public bool GridViewShow { get; set; }
        public Nullable<int> GridViewWidth { get; set; }
        public string FormatType { get; set; }
        public string FormatValue { get; set; }
        public string CultureInfo { get; set; }
        public Nullable<bool> ReadOnly { get; set; }
        public Nullable<bool> IsCarryDown { get; set; }
        public string DefaultValue { get; set; }
        public Nullable<bool> AllowDBNull { get; set; }
        public Nullable<bool> IsValid { get; set; }
        public string TableNameValid { get; set; }
        public string FilterExpression { get; set; }
        public string OrderExpression { get; set; }
        public string DATA_TYPE { get; set; }
        public Nullable<int> CHARACTER_MAXIMUM_LENGTH { get; set; }
        public string IS_NULLABLE { get; set; }

        [NotMapped]
        public decimal Summary { get; set; }

        public virtual SysTable SysTable { get; set; }
        public virtual SysColumn SysColumn { get; set; }
    }
}