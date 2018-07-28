using System;
using CsvHelper.Configuration;
using MDRIP.Models;

namespace MDRIP.helper
{
    public class RecordToModelMap:ClassMap<ExcelRecord>
    {
        public RecordToModelMap()
        {
            Map(m => m.Introduction).Name("Introduction", "Sr. #", "Id");
            Map(m => m.Timeline).Name("Time line (Time period of Data collection/ Research)");
            Map(m => m.Sex).Name("Sex");
            Map(m => m.Age).Name("Age");
            Map(m => m.Bacteria).Name("Bacteria Name");
            Map(m => m.Strain).Name("Specie", "Strain");
            Map(m => m.Taxonomy).Name("Taxonomy");
            Map(m => m.Prevalance).Name("Seasonal Prevalence");
            Map(m => m.Aerobic).Name("Aerobic/ Anaerobic");
            Map(m => m.Mortality).Name("Mortality");
            Map(m => m.Infections).Name("Associated Infections");
            Map(m => m.ClinicalCharacteristics).Name("Clinical Characteristics");
            Map(m => m.Habitat).Name("Habitat/Adaptability");
            Map(m => m.Morphology).Name("Morphology");
            Map(m => m.VirulenceFactors).Name("Virulence Factors");
            Map(m => m.InteractionWithOrganism).Name("Interaction with organisms");
            Map(m => m.Antibiotics).Name("Antibiotics");
            Map(m => m.Treatment).Name("Treatment");
            Map(m => m.References).Name("References (IF ANY)");

        }
    }
}
