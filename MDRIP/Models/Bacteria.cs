using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDRIP.Models
{
    public class Bacteria
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Strain { get; set; }
        public String Introduction { get; set; }
        public String Taxonomy { get; set; }
        public String Definition { get; set; }
        public String GramStaining { get; set; }
        public String Shape { get; set; }
        public String OxygenRequirement { get; set; }
        public String ClinicalCharacteristics { get; set; }
        public String Prevalance { get; set; }
        public String Occurence { get; set; }
        public String Mortality { get; set; }
        public String InvolinDiseases { get; set; }
        public String CausingInfections { get; set; }
        public String Likeness { get; set; }
        public String Treatment { get; set; }
        public String Antibiotics { get; set; }
        public String MDR { get; set; }
        public String InteractionWithOrganism { get; set; }

        public ICollection<DiagnosticCenter> Centers { get; set; }
        public ICollection<Infections> Infections { get; set; }
        public ICollection<ClinicalInformation> ClinicalInformation { get; set; }
        // add user
    }
}