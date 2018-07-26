using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDRIP.Models
{
    public class EmergencyPreparation
    {
        public int ID { get; set; }
        public String CoordinatingHealthRegionalState { get; set; }
        public String Developing_DisseminatingInformationToMedicalCommunnity { get; set; }
        public String PartnersToImplementPHDContainmentMeaseures { get; set; }
        public String CoordinteWithMCS { get; set; }
        public String EpidemiologyInvestigationActivities { get; set; }
        public String CollectingAndAnalysingDataToDevelopObjectives { get; set; }

        public ICollection<DiagnosticCenter> Centers { get; set; }
        // add  appplication user
    }
}