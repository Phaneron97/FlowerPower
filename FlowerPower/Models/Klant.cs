using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlowerPower.Models
{
    public class Klant
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Voornaam")]
        public string Voornaam { get; set; }

        [Display(Name = "Tussenvoegsel")]
        public string Tussenvoegsel { get; set; }

        [Required]
        [Display(Name = "Achternaam")]
        public string Achternaam { get; set; }

        [Required]
        [Display(Name = "Straat")]
        public string Straat { get; set; }

        [Required]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [Required]
        [Display(Name = "Plaats")]
        public string Plaats { get; set; }

        [Required]
        [Display(Name = "Geboortdatum")]
        public DateTime? GeboorteDatum { get; set; }
    }
}