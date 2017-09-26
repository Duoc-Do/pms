﻿//------------------------------------------------------------------------------
// <auto-generated>
// gen by lotusviet.vn
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("SenCompanyView")]
    public partial class SenCompanyView
    {
        public string Address { get; set; }
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string Comment { get; set; }
        [Key]
        public int CompanyId { get; set; }
        public string ConnectionString { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }

        public string Description { get; set; }
        public string Email { get; set; }
        public string FaxNumber { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<bool> IsLockedOut { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public Nullable<int> PackageId { get; set; }
        public string PackageName { get; set; }
        public string TaxCode { get; set; }
        public string Telephone { get; set; }
        public string UserEmail { get; set; }
        public Nullable<Guid> UserId { get; set; }
        public string UserName { get; set; }
        public string Website { get; set; }

    }
}