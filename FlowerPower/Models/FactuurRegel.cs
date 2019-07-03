using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlowerPower.Models
{
    public class FactuurRegel
    {
        public int Id { get; set; }
        //public FiliaalKeuzeEnum FiliaalKeuze { get; set; }
        public string FiliaalKeuze { get; set; }
        public virtual Bloem BloemId { get; set; }
        public virtual Factuur FactuurId { get; set; }
        //public int Stuks { get; set; }        

        //public enum FiliaalKeuzeEnum
        //{
        //    [Display(Name = "Winkel1")]
        //    Winkel1,
        //    [Display(Name = "Winkel2")]
        //    Winkel2,
        //    [Display(Name = "Winkel3")]
        //    Winkel3
        //}
    }
}