using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FlowerPower.Models
{
    // You can add klant data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public string Straat { get; set; }
        public string Postcode { get; set; }
        public string Plaats { get; set; }
        public DateTime? GeboorteDatum { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<FlowerPower.Models.Bloem> Bloems { get; set; }

        public System.Data.Entity.DbSet<FlowerPower.Models.Factuur> Factuurs { get; set; }

        public System.Data.Entity.DbSet<FlowerPower.Models.FactuurRegel> FactuurRegels { get; set; }

        public System.Data.Entity.DbSet<FlowerPower.Models.Winkel> Winkels { get; set; }

        public System.Data.Entity.DbSet<FlowerPower.Models.Klant> Klants { get; set; }

        public System.Data.Entity.DbSet<FlowerPower.Models.Medewerker> Medewerkers { get; set; }

        public System.Data.Entity.DbSet<FlowerPower.Models.Bestelling> Bestellings { get; set; }
    }
}