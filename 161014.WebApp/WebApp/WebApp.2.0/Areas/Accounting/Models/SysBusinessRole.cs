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

    [Table("SysBusinessRole")]
    public partial class SysBusinessRole
    {
        [Key, Column(Order = 0)]
        public int RoleID { get; set; }
        [Key, Column(Order = 1)]
        public string BusinessCode { get; set; }
        public bool IsAdd { get; set; }
        public bool IsDelete { get; set; }
        public bool IsEdit { get; set; }
    
        //public virtual SysBusiness SysBusiness { get; set; }
        //public virtual SysRole SysRole { get; set; }
    }
}