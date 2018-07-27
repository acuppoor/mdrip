using MDRIP.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MDRIP.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext context;

        public AdminController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {

            if ((!User.Identity.IsAuthenticated) || (User.Identity.IsAuthenticated && !IsAdminUser()))
            {
                return RedirectToAction("Index", "Home");
            }

            var RolesList = context.Roles.ToList();
            var AccountsList = context.Users.ToList();
            return View(new AdminModel()
            {
                Accounts = AccountsList,
                Roles = RolesList
            });
        }

        public Boolean IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public ActionResult CreateRole()
        {
            if ((!User.Identity.IsAuthenticated) || (User.Identity.IsAuthenticated && !IsAdminUser()))
            {
                return RedirectToAction("Index", "Home");
            }

            var Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        public ActionResult CreateRole(IdentityRole Role)
        {
            if ((!User.Identity.IsAuthenticated) || (User.Identity.IsAuthenticated && !IsAdminUser()))
            {
                return RedirectToAction("Index", "Home");
            }

            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateAccount()
        {
            if ((!User.Identity.IsAuthenticated) || (User.Identity.IsAuthenticated && !IsAdminUser()))
            {
                return RedirectToAction("Index", "Home");
            }
            var RolesList = context.Roles.ToList();
            return View(new CreateAccountAdminModel() { Roles = RolesList });
        }

        [HttpPost]
        public ActionResult CreateAccount(CreateAccountAdminModel models)
        {
            var model = models.Account;

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                HouseAndStreet = model.HouseAndStreet,
                Region = model.Region,
                Activated = model.Activated,
                Country = model.Country
            };


            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            if (manager == null) {
                var store = new UserStore<ApplicationUser>(context);
                manager = (ApplicationUserManager) new UserManager<ApplicationUser, string>(store);
            }

            var result = manager.Create(user, model.Password);

            string code = manager.GenerateEmailConfirmationToken(user.Id);
            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
            manager.SendEmail(user.Id, "Confirm your account", "An account has been created for you in MDRIP. Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    
            if (!result.Succeeded)
            {
                AddErrors(result);
            }

            result = manager.AddToRole(user.Id, model.Role);
            if (!result.Succeeded) {
                AddErrors(result);
            }
            return RedirectToAction("Index");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}