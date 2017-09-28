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
    [Table("SenScheduleTask")]
    public partial class SenScheduleTask
    {
        [Key]
        public int ScheduleTaskId { get; set; }
        public bool Enabled { get; set; }
        public Nullable<System.DateTime> LastEndUtc { get; set; }
        public Nullable<System.DateTime> LastStartUtc { get; set; }
        public Nullable<System.DateTime> LastSuccessUtc { get; set; }
        public string Name { get; set; }
        public int Seconds { get; set; }
        public bool StopOnError { get; set; }
        public string Type { get; set; }

    }
}