using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlowerPower.Models
{
    public class Medewerker
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string TijdelijkWachtwoord { get; set; }
    }
}