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
    [Table("SenEmailAccount")]
    public partial class SenEmailAccount
    {
        [Key]
        public int EmailAccountId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool EnableSsl { get; set; }
        public string Host { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string Username { get; set; }

    }
}