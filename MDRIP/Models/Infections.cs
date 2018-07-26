using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDRIP.Models
{
    public class Infections
    {
        public int ID { get; set; }
        public String Type { get; set; }
        public String Name { get; set; }
        public String Definition { get; set; }
        public String Classification { get; set; }
        public String Symptoms { get; set; }
        public String Seasonal { get; set; }
        public String Pathophysiology { get; set; }
        public String MyProperty { get; set; }
        public String CausingBacteria { get; set; }
        public String ModeOfTransmission { get; set; }
        public String Diagnosis { get; set; }
        public String Prevention { get; set; }
        public String Treatment { get; set; }
        public String Epidimology { get; set; }
        public String DeathRate { get; set; }
        public String History { get; set; }
        public String ReportingInstitute { get; set; }
        public String ReportAuthor { get; set; }

        public ICollection<DiagnosticCenter> Centers { get; set; }
        public ICollection<ClinicalInformation> ClinicalInformation { get; set; }
        public ICollection<MDR> MDRs { get; set; }
        public ICollection<Bacteria> Bacterias { get; set; }
    }
}