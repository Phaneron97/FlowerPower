using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlowerPower.Models
{
    public class Winkel
    {
        public int Id { get; set; }

        [Required]
        public string Winkelnaam { get; set; }

        [Required]
        public string Straat { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string Plaats { get; set; }

        [Required]
        public string Telefoon { get; set; }

        //NIET [Required], required alleen bij input type in view
        [DataType(DataType.Upload)]
        public string Plaatje { get; set; }

        public enum WinkelNaamEnum
        {
            Spar,
            Bloemetje,
            Bloemenmarkt
        }

    }
}