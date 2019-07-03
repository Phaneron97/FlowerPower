using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlowerPower.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FlowerPower.Controllers
{
    [Authorize(Roles = "Admin, Medewerker")]
    public class FactuurRegelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        public ActionResult FacturenLijst()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            string AccountId = currentUser.Id;
            List<Factuur> factuur = db.Factuurs.Where(x => x.User.Id == AccountId).ToList();
            
            //return View("Factuur", factuur);
            return View(factuur);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AlleFacturen()
        {
            List<Factuur> factuur = db.Factuurs.ToList();

            //return View("Factuur", factuur);
            return View(factuur);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factuur Factuur = db.Factuurs.Find(id);
            if (Factuur == null)
            {
                return HttpNotFound();
            }
            return View(Factuur);
        }

        // GET: Admin/BloemenCRUD/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FactuurRegel FactuurRegel = db.FactuurRegels.Find(id);
            if (FactuurRegel == null)
            {
                return HttpNotFound();
            }
            return View(FactuurRegel);
        }

        // POST: Admin/FilialenCRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BestelDatum,User,Gereed")] Factuur Factuur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Factuur).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(Factuur);
        }
    }
}
