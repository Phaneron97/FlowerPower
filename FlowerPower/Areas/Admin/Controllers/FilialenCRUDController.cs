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
    public class FilialenCRUDController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/FilialenCRUD
        public ActionResult Index()
        {
            return View(db.Winkels.ToList());
        }

        // GET: Admin/FilialenCRUD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Winkel winkel = db.Winkels.Find(id);
            if (winkel == null)
            {
                return HttpNotFound();
            }
            return View(winkel);
        }

        // GET: Admin/FilialenCRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BloemenCRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Winkelnaam,Straat,Postcode,Plaats")] Winkel winkel, HttpPostedFileBase plaatje)
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
                        string path = Path.Combine(Server.MapPath("~/Content/Images/Filialen"), Path.GetFileName(plaatje.FileName));
                        winkel.Plaatje = plaatje.FileName;
                        plaatje.SaveAs(path);

                    }
                    ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {

                    ViewBag.FileStatus = "Error while file uploading.";
                }

                db.Winkels.Add(winkel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(winkel);
        }

        // GET: Admin/FilialenCRUD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Winkel winkel = db.Winkels.Find(id);
            if (winkel == null)
            {
                return HttpNotFound();
            }
            return View(winkel);
        }

        // POST: Admin/FilialenCRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Straat,Postcode,Plaats,Plaatje")] Winkel winkel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(winkel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(winkel);
        }

        // GET: Admin/FilialenCRUD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Winkel winkel = db.Winkels.Find(id);
            if (winkel == null)
            {
                return HttpNotFound();
            }
            return View(winkel);
        }

        // POST: Admin/FilialenCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Winkel winkel = db.Winkels.Find(id);
            db.Winkels.Remove(winkel);
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
