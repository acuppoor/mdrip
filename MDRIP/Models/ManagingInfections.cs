using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDRIP.Models
{
    public class ManagingInfections
    {
        public int ID { get; set; }
        public String SeasonalInfection { get; set; }
        public String SpreadOfInfection { get; set; }
        public String CauseOfBaterialInfection  { get; set; }
        public String WhereToGetHelp { get; set; }
        public String BacteriaEntrance { get; set; }
        public String Handwashing { get; set; }
        public String ReducingHospitalInfection { get; set; }
        public String MedicinesSideEffects { get; set; }
        public String SafetyIssues { get; set; }
        public String PrescriptionMedicines { get; set; }
        public String WorkPlaceSafetey { get; set; }

        public ICollection<DiagnosticCenter> Centers { get; set; }
        // add application user

    }
}