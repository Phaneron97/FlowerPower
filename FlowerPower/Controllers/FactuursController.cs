using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlowerPower.Models;

namespace FlowerPower.Controllers
{
    public class FactuursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Create(string KlantId, int BloemId, string FiliaalKeuze)
        {
            if (Session["BloemIds"] == null)
            {
                List<int> bloem = new List<int>();
                bloem.Add(BloemId);
                Session["BloemIds"] = bloem;
            }
            else
            {
                List<int> bloemen = (List<int>)Session["BloemIds"];
                List<int> bloem = new List<int>();
                foreach (var item in bloemen)
                {
                    bloem.Add(item);
                }
                bloem.Add(BloemId);
                Session["BloemIds"] = bloem;
            }

            List<Bloem> AutoID = new List<Bloem>();
            List<int> IDs = (List<int>)Session["BloemIds"];
            foreach (var item in IDs)
            {
                AutoID.Add(db.Bloems.Where(x => x.Id == item).FirstOrDefault());
            }

            ViewBag.FiliaalKeuze = FiliaalKeuze;
            ViewBag.KlantId = KlantId;
            return View(AutoID.ToList());
        }

        public ActionResult Remove(int BloemId)
        {
            List<int> BloemIds = (List<int>)Session["BloemIds"];
            BloemIds.Remove(BloemId);

            if (BloemIds.Count == 0)
            {
                Session["BloemId"] = null;
                return RedirectToAction("Bestellen", "Bloemen");
            }

            Session["BloemId"] = BloemIds;
            return RedirectToAction("Create");
        }

        public ActionResult Further()
        {
            return RedirectToAction("Resultaat", "Bloemen");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(string KlantId, string FiliaalKeuze)
        {
            List<Bloem> bloem = new List<Bloem>();
            List<int> bloemIDs = (List<int>)Session["BloemIds"];
            foreach (var id in bloemIDs)
            {
                bloem.Add(db.Bloems.Where(x => x.Id == id).FirstOrDefault());
            }

            List<ApplicationUser> klant = new List<ApplicationUser>();
            klant.Add(db.Users.Where(x => x.Id == KlantId).FirstOrDefault());

            DateTime BestelDatum = DateTime.Now;

            Factuur factuur = new Factuur();
            FactuurRegel factuurRegel = new FactuurRegel();

            factuur.BestelDatum = BestelDatum;
            factuur.User = klant.FirstOrDefault();
            db.Factuurs.Add(factuur);

            foreach (var item in bloem)
            {
                factuurRegel.FiliaalKeuze = FiliaalKeuze;
                factuurRegel.BloemId = item;
                factuurRegel.FactuurId = factuur;
                db.FactuurRegels.Add(factuurRegel);
                db.SaveChanges();
            }

            Session["BloemIds"] = null;
            int Factuur_Id = db.Factuurs.Where(x => x.User.Id == KlantId).Select(x => x.Id).FirstOrDefault();
            return RedirectToAction("FacturenLijst", "FactuurRegel", new { Fac_Id = Factuur_Id });
        }

        [Authorize]
        public ActionResult Factuur(int Fac_Id)
        {
            List<FactuurRegel> factuurRegel = new List<FactuurRegel>();
            var factuurGevonden = db.FactuurRegels.Where(x => x.FactuurId.Id == Fac_Id);
            List<decimal> DateInbetween = new List<decimal>();
            foreach (var item in factuurGevonden)
            {
                factuurRegel.Add(item);
            }

            Factuur factuur = db.Factuurs.Where(x => x.Id == Fac_Id).FirstOrDefault();

            ViewBag.Bill = factuur.BestelDatum;
            ViewBag.FactuurNr = Fac_Id;
            //ViewBag.Id = factuur.User.Id;
            ViewBag.Voornaam = factuur.User.Voornaam;
            ViewBag.Tussenvoegsel = factuur.User.Tussenvoegsel;
            ViewBag.AccName = factuur.User.Achternaam;
            ViewBag.AccAdress = factuur.User.Straat;
            ViewBag.AccZipcode = factuur.User.Postcode;
            ViewBag.AccPlaats = factuur.User.Plaats;

            ViewBag.i = 0;

            ViewBag.Totaal = DateInbetween;

            double Totaal = 0;
            foreach (var item in factuurRegel)
            {
                Totaal = Totaal + item.BloemId.Prijs;
            }
            double TotaalBtw = Totaal / 100 * 21;

            ViewBag.Btw = TotaalBtw;

            ViewBag.TotaalAll = Totaal + TotaalBtw;

            return View(factuurRegel);
        }
    }
}
