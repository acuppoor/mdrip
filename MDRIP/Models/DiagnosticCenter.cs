using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDRIP.Models
{
    public class DiagnosticCenter
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String District { get; set; }
        public String Address { get; set; }
        public String EmailID { get; set; }
        public String Contact { get; set; }
        public String ReproInfection { get; set; }
        public String MDRPathogen { get; set; }
        public String PatientInfection { get; set; }
        public String AntibioticResistence { get; set; }

        public ICollection<Infections> Infections { get; set; }
        public ICollection<ClinicalInformation> ClinicalInformation { get; set; }
        public ICollection<Bacteria> Bacterias { get; set; }
        public ICollection<MDR> MDRs { get; set; }
        public ICollection<ManagingInfections> ManagingInfections { get; set; }
        public ICollection<EmergencyPreparation> EmergencyPreparations { get; set; }
    }
}