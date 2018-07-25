using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MDRIP.Models
{
    public class MDRIPContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MDRIPContext() : base("name=MDRIPContext")
        {
        }

        public System.Data.Entity.DbSet<MDRIP.Models.EmergencyPreparation> EmergencyPreparations { get; set; }

        public System.Data.Entity.DbSet<MDRIP.Models.Bacteria> Bacteria { get; set; }

        public System.Data.Entity.DbSet<MDRIP.Models.BacterialEcology> BacterialEcologies { get; set; }

        public System.Data.Entity.DbSet<MDRIP.Models.ClinicalInformation> ClinicalInformations { get; set; }

        public System.Data.Entity.DbSet<MDRIP.Models.DiagnosticCenter> DiagnosticCenters { get; set; }

        public System.Data.Entity.DbSet<MDRIP.Models.Infections> Infections { get; set; }

        public System.Data.Entity.DbSet<MDRIP.Models.ManagingInfections> ManagingInfections { get; set; }

        public System.Data.Entity.DbSet<MDRIP.Models.MDR> MDRs { get; set; }
    }
}
