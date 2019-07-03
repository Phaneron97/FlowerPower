using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerPower.Models
{
    public class Factuur
    {
        public int Id { get; set; }
        public DateTime BestelDatum { get; set; } = DateTime.Now;
        public virtual ApplicationUser User { get; set; }
        public bool Gereed { get; set; }
    }
}