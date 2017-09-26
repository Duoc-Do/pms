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
    [Table("aspnet_Membership")]
    public partial class aspnet_Membership
    {
        [Key]
        public Guid UserId { get; set; }
        public Guid ApplicationId { get; set; }
        public string Comment { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string Email { get; set; }
        public int FailedPasswordAnswerAttemptCount { get; set; }
        public System.DateTime FailedPasswordAnswerAttemptWindowStart { get; set; }
        public int FailedPasswordAttemptCount { get; set; }
        public System.DateTime FailedPasswordAttemptWindowStart { get; set; }
        public bool IsApproved { get; set; }
        public bool IsLockedOut { get; set; }
        public System.DateTime LastLockoutDate { get; set; }
        public System.DateTime LastLoginDate { get; set; }
        public System.DateTime LastPasswordChangedDate { get; set; }
        public string LoweredEmail { get; set; }
        public string MobilePIN { get; set; }
        public string Password { get; set; }
        public string PasswordAnswer { get; set; }
        public int PasswordFormat { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordSalt { get; set; }

    }
}