using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDRIP.Models
{
    public class RegionModel
    {
        [Display(Name = "Country")]
        [Required]
        public string CountryId { get; set; }

        [ForeignKey("CountryId")]
        [Required]
        public virtual Country Country { get; set; }

    }
}
