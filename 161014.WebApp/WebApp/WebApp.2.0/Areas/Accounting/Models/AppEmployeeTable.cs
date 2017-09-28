
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
    [Table("AppEmployeeTable")]
    public partial class AppEmployeeTable
    {
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string BankAccount { get; set; }
        public Nullable<int> BankID { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Comments { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> EducationLevelID { get; set; }
        public string EmailAddress { get; set; }
        public string EmployeeCode { get; set; }
        [Key]
        public int EmployeeID { get; set; }
        public Nullable<int> EthnicID { get; set; }
        public Nullable<int> Gender { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public byte[] Image { get; set; }
        public bool IsActive { get; set; }
        public string JobTitle { get; set; }
        public Nullable<System.DateTime> LastReviewDate { get; set; }
        public string Mobilephone { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string Name { get; set; }
        public Nullable<int> NationalityID { get; set; }
        public string PIN { get; set; }
        public string PINAddress { get; set; }
        public Nullable<System.DateTime> PINDate { get; set; }
        public Nullable<int> PositionID { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public Nullable<int> ReligionID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string TaxCode { get; set; }
        public Nullable<int> TaxPIType { get; set; }
        public string TelephoneNumber { get; set; }
        public Nullable<int> UserID { get; set; }

    }
}