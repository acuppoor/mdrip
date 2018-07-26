using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDRIP.Models
{
    public class MDR
    {
        public int ID { get; set; }
        public String AccessionID { get; set; }
        public String BacteriaName { get; set; }
        public String Antibiotics { get; set; }
        public String DeathRate { get; set; }
        public String Enviromental { get; set; }
        public String Adaptability { get; set; }
        public String Genetics { get; set; }
        public String District { get; set; }
        public String History { get; set; }

        public ICollection<DiagnosticCenter> Centers { get; set; }
        public ICollection<Bacteria> Bacterias { get; set; }
        public ICollection<ClinicalInformation> ClinicalInformation { get; set; }
        public ICollection<Infections> Infections { get; set; }
    }
}