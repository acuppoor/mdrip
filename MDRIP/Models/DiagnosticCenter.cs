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

        public ICollection<Infections> infections { get; set; }
        public ICollection<ClinicalInformation> clinicalInfection { get; set; }
        public ICollection<Bacteria> bacteria { get; set; }
        public ICollection<MDR> mdr { get; set; }
        public ICollection<ManagingInfections> manageinfections { get; set; }
        public ICollection<EmergencyPreparation> emergencypreparation { get; set; }
    }
}