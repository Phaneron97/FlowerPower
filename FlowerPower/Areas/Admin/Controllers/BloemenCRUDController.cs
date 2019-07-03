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

namespace FlowerPower.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BloemenCRUDController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/BloemenCRUD
        public ActionResult Index()
        {
            return View(db.Bloems.ToList());
        }

        // GET: Admin/BloemenCRUD/Details/5
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

        // GET: Admin/BloemenCRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BloemenCRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam,Prijs,Omschrijving")] Bloem bloem, HttpPostedFileBase plaatje)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Method 1 Get file details from current request    
                    //Uncomment following code if you wants to use method 1    
                    //if (Request.Files.Count > 0)    
                    // {    
                    //     var Inputfile = Request.Files[0];    

                    //     if (Inputfile != null && Inputfile.ContentLength > 0)    
                    //     {    
                    //         var filename = Path.GetFileName(Inputfile.FileName);    
                    //       var path = Path.Combine(Server.MapPath("~/uploadedfile/"), filename);    
                    //        Inputfile.SaveAs(path);    
                    //    }    
                    // }    

                    //Method 2 Get file details from HttpPostedFileBase class    

                    if (plaatje != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/Images"), Path.GetFileName(plaatje.FileName));
                        bloem.Plaatje = plaatje.FileName;
                        plaatje.SaveAs(path);

                    }
                    ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {

                    ViewBag.FileStatus = "Error while file uploading.";
                }

                db.Bloems.Add(bloem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloem);
        }

        // GET: Admin/BloemenCRUD/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Admin/BloemenCRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,Prijs,Omschrijving,Plaatje")] Bloem bloem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloem);
        }

        // GET: Admin/BloemenCRUD/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/BloemenCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bloem bloem = db.Bloems.Find(id);
            db.Bloems.Remove(bloem);
            db.SaveChanges();
            return RedirectToAction("Index");
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
