using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDRIP.Models
{
    public enum RecordSex
    {
        Male, Female, Both
    }

    public class ExcelRecord
    {

        // introduction
        // timeline
        // sex
        // age
        // area
        // bacteria
        // strain
        // taxonomy
        // seasonal prevalence
        // aerobic
        // mortality
        // associated infections
        // clinical characteristics
        // habitat/daptability
        // morphology
        // virulence factors
        // interaction
        // antibiotics
        // treatments
        // references
        public String Introduction { get; set; }
        public String Timeline { get; set; }
        public RecordSex Sex { get; set; }
        public int Age { get; set; }
        public String Area { get; set; }
        public String Bacteria { get; set; }
        public String Strain { get; set; }
        public String Taxonomy { get; set; }
        public String Prevalance { get; set; }
        public String Aerobic { get; set; }
        public int Mortality { get; set; }
        public String Infections { get; set; }
        public String Treatment { get; set; }
        public String Antibiotics { get; set; }
        public String ClinicalCharacteristics { get; set; }
        public String Habitat { get; set; }
        public String InteractionWithOrganism { get; set; }
        public String Morphology { get; set; }
        public String VirulenceFactors { get; set; }
        public String References { get; set; }

    }
}