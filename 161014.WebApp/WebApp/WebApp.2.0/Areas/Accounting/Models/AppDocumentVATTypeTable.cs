
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
    [Table("AppDocumentVATTypeTable")]
    public partial class AppDocumentVATTypeTable
    {
        [Key]
        public int EnumValue { get; set; }
        public string EnumName { get; set; }

    }
}