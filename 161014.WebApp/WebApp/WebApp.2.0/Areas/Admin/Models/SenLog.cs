﻿//------------------------------------------------------------------------------
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
    [Table("SenLog")]
    public partial class SenLog
    {
        [Key]
        public int LogId { get; set; }
        public System.DateTime CreatedOnUtc { get; set; }
        public string FullMessage { get; set; }
        public string IpAddress { get; set; }
        public int LogLevelId { get; set; }
        public string PageUrl { get; set; }
        public string ReferrerUrl { get; set; }
        public string ShortMessage { get; set; }
        public Nullable<Guid> UserId { get; set; }

    }
}