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
    public class BloemenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //public ActionResult KiesLocatie()
        //{
        //    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        //    var currentUser = manager.FindById(User.Identity.GetUserId());

        //    return View();
        //}

        //// GET: Bloemen
        //public ActionResult Index()
        //{
        //    return View(db.Bloems.ToList());
        //}

        //// GET: Bloemen/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Bloem bloem = db.Bloems.Find(id);
        //    if (bloem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bloem);
        //}        

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}


        // GET: Auto
        public ActionResult Index()
        {
            return View(db.Bloems.ToList());
        }
        [Authorize]
        public ActionResult Bestellen(string FiliaalKeuze)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());

            ViewBag.FiliaalKeuze = db.Winkels.ToList(); 


            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            //var currentUser = manager.FindById(User.Identity.GetUserId());
            //if (currentUser != null)
            //{

            //    return RedirectToAction("Resultaat");
            //}
            return View();
        }
        [Authorize]
        public ActionResult Resultaat(string FiliaalKeuze)
        {
            List<int> Id = new List<int>();
            List<Bloem> bloem = new List<Bloem>();
            List<Bloem> Bloemen = new List<Bloem>();

            ViewBag.FiliaalKeuze = db.Winkels.ToList();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());

            ViewBag.KlantId = currentUser.Id;

            if (FiliaalKeuze == null)
            {
                ViewBag.Error = "Vul alstublieft het filiaal in waar u de bloemen op wilt halen";
                return RedirectToAction("KiesLocatie");
            }

            var query = from C in db.Bloems
                        select C.Id;

            //Zet alle id's van alle auto's in een list<int>
            foreach (var item in query)
            {
                Id.Add(item);
            }
            //foreach (var item in db.FactuurRegels)
            //{
            //    int id = item.AutoId.Id;
            //    if (item.EindDatum < EindDatum && item.EindDatum > BeginDatum || item.BeginDatum < EindDatum && item.BeginDatum > BeginDatum)
            //    {
            //        Id.Remove(id);
            //    }
            //}
            foreach (var id in Id)
            {
                bloem.Add(db.Bloems.Where(x => x.Id == id).FirstOrDefault());
            }

            return View(bloem);
        }

        // GET: Bloemen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloem bloem = db.Bloems.Find(id);
            if (bloem == null)
            {
                return HttpNotFound();
            }
            return View(bloem);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
