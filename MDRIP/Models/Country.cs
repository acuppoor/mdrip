using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MDRIP.Models
{
    public class Country{

        [Key]
        [Required]
        public string id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Region> Regions { get; set; }

    }
}
