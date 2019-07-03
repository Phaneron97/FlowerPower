using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FlowerPower.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FlowerPower.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MedewerkersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Employee
        public async Task<ActionResult> Index()
        {
            var users = new List<ApplicationUser>();

            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(db);
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(store);

            // Get the list of Users in this Role
            foreach (var user in manager.Users.ToList())
            {
                if (await manager.IsInRoleAsync(user.Id, "Medewerker"))
                {
                    users.Add(user);
                }
            }

            return View(users);
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(MedewerkerRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                user.Voornaam = model.Voornaam;
                user.Tussenvoegsel = model.Tussenvoegsel;
                user.Achternaam = model.Achternaam;

                UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(db);
                UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(store);

                var result = manager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    manager.AddToRole(user.Id, "Medewerker");
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}
