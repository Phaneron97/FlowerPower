using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlowerPower.Models
{
    public class Bloem
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Bloemnaam")]
        public string Naam { get; set; }

        [Required]
        [Display(Name = "Prijs")]
        public int Prijs { get; set; }

        [Required]
        [Display(Name = "Productomschrijving")]
        public string Omschrijving { get; set; }

        //NIET [Required], required alleen bij input type in view
        [DataType(DataType.Upload)]
        public string Plaatje { get; set; }


    }
}