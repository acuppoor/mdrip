using System;
using System.IO;
using Csv;

namespace MDRIP.helper
{
    public class WritingFileToDb
    {
        public WritingFileToDb()
        {
        }

        public static string Write(Stream inputStream, string extension, string path){
            string message = "";
            if (extension.Equals("csv"))
            {
                var csv = System.IO.File.ReadAllText(path);
                foreach (var line in CsvReader.ReadFromText(csv))
                {
                    var byName = line["Test"];
                    message += byName.ToString();
                }

            }
            else
            {
                var excelReader = new ExcelReader(inputStream);

                var items = excelReader.getData("Sheet1");

                foreach (var v in items)
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

                    message += v["Age"].ToString() + "  --  ";

                }
            }

            return message;
        }
    }
}
