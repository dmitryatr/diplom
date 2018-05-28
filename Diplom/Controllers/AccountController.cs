using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Diplom.Models;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace Diplom.Controllers
{
    public class AccountController : Controller
    {
        IProductRepository repository;

        public AccountController(IProductRepository r)
        {
            repository = r;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                user = repository.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    ClaimsIdentity claim = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString(), ClaimValueTypes.String));
                    claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email, ClaimValueTypes.String));
                    claim.AddClaim(new Claim(ClaimTypes.Role, user.Role.RoleName, ClaimValueTypes.String));
                    claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                        "OWIN Provider", ClaimValueTypes.String));

                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
            }
            return PartialView(model);
        }

        public ActionResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                user = repository.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user == null)
                {
                    repository.AddUser(new User
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password,
                        City = model.City,
                        Phone = model.Phone,
                        RoleID = 2
                    });
                    user = repository.Users.Where(u => u.Email == model.Email).FirstOrDefault();
                    if (user != null)
                    {

                        ClaimsIdentity claim = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                        claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString(), ClaimValueTypes.String));
                        claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email, ClaimValueTypes.String));
                        claim.AddClaim(new Claim(ClaimTypes.Role, user.Role.RoleName, ClaimValueTypes.String));
                        claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                            "OWIN Provider", ClaimValueTypes.String));
                        AuthenticationManager.SignIn(new AuthenticationProperties
                        {
                            IsPersistent = true
                        }, claim);
                        return Json(new { success = true });
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким email уже существует");
                }
            }
            return PartialView(model);
        }

        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut();
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Products(int id = 0)
        {
            ViewBag.ProductsCount = repository.Products.Where(x => x.UserID == id).Count();
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products.Where(m => m.UserID == id),
                User = repository.Users.FirstOrDefault(m => m.ID == id)
            };
            return View(model);
        }
    }
}