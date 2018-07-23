using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDRIP.Models
{
    public class BacterialEcology
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String District { get; set; }
        public String Habitat { get; set; }
        public String Infections { get; set; }
        public String Diseases { get; set; }
        public String DeathRate { get; set; }
        public String ModeOfTransmission { get; set; }
        public String Prevention { get; set; }
        public String Treatment { get; set; }
    }
}