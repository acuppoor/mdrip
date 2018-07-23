using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDRIP.Models
{
    public class ClinicalInformation
    {
        public int ID { get; set; }
        public String ClinicName { get; set; }
        public String ClinicAddress { get; set; }
        public int ClincFormNumber { get; set; }
        public String ClinicRecords { get; set; }
        public String ClincRecordsProviderID { get; set; }
        public String ClinicalInfectionsInformation { get; set; }
    }
}