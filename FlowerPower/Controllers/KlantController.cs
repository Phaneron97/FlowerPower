using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlowerPower.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FlowerPower.Controllers
{
    public class KlantController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        //Eigen profiel bekijken
        public ActionResult Index()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            string AccountId = currentUser.Id;
            List<Klant> Klant = db.Klants.Where(x => x.User.Id == AccountId).ToList();

            //return View("Factuur", factuur);
            return View(Klant);
        }

        [Authorize]
        //Eigen profiel wijzigen
        public ActionResult Edit()
        {
            // ingelogde user ophalen via usermanager
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());

            // bijbehorend profiel ophalen uit de DB
            Klant klant = db.Klants.SingleOrDefault(p => p.User.Id == currentUser.Id);

            if (klant == null)
            {
                // is er geen profiel, dan maken we een lege
                klant = new Models.Klant();
            }

            return View(klant);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Klant klant)
        {
            // server side validatie van het model object
            if (ModelState.IsValid)
            {
                // ingelogde user ophalen via usermanager
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var currentUser = manager.FindById(User.Identity.GetUserId());

                // profiel dat bij de user hoort uit de DB halen
                Klant storedKlant = db.Klants.SingleOrDefault(p => p.User.Id == currentUser.Id);

                // geen profiel = nieuwe aanmaken en bewaren in de DB
                if (storedKlant == null)
                {
                    storedKlant = klant;
                    klant.User = currentUser;
                    db.Klants.Add(storedKlant);
                }

                // data overzetten van geposte object naar database object
                storedKlant.Voornaam       = klant.Voornaam;
                storedKlant.Tussenvoegsel  = klant.Tussenvoegsel;
                storedKlant.Achternaam     = klant.Achternaam;
                storedKlant.Straat         = klant.Straat;
                storedKlant.Postcode       = klant.Postcode;
                storedKlant.Plaats         = klant.Plaats;
                storedKlant.GeboorteDatum  = klant.GeboorteDatum;

                // alle wijzigingen opslaan in de DB
                db.SaveChanges();
                return View(storedKlant);
            }
            return View(klant);
        }
    }
}
