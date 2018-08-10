using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDRIP.Models
{
    public class Region
    {
        public int ID { get; set; }

        [Display(Name = "Region")]
        [Required]
        public string Name { get; set; }

        public Country Country { get; set; }
    }
}
