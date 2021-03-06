﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Areas.PMSContracts.Models;

namespace WebApp.Areas.PMSContracts
{
    public class PMSDataContext:DbContext
    {
        public PMSDataContext() : base("name=WebAppAccEntities2") { }

        //public object CLIENTS { get; internal set; }
        public  DbSet<GeneralModel> CONTRACTS_CONDITIONS_GENERAL { get; set; }
        public  DbSet<ClientModel> CONTRACTS_CLIENTS { get; set; }
        public  DbSet<ContractModel> CONTRACTS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}