using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDRIP.Models
{
    public class Region
    {
        [Display(Name = "Country")]
        [Required]
        public string CountryId { get; set; }

        [ForeignKey("CountryId")]
        [Required]
        public virtual Country Country { get; set; }


        [Display(Name = "Region")]
        [Required]
        public string Name { get; set; }
    }
}
