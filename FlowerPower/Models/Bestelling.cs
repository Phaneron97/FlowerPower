using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerPower.Models
{
    public class Bestelling
    {
        public int Id { get; set; }
        public Winkel WinkelId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual FactuurRegel FactuurRegel { get; set; }
        //public virtual Medewerker medewerker{ get; set; }
        public bool Klaar { get; set; }
    }
}