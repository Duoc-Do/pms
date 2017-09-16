namespace PMSContract
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=ConnectionStringName")
        {
        }

        public virtual DbSet<ContractModel> CONTRACTS { get; set; }
        public virtual DbSet<ContractConditionModel> CONTRACTCONDITION { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

    }
}
