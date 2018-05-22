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

namespace Diplom.Controllers
{
    public class AccountController : Controller
    {
        IProductRepository repository;

        public AccountController(IProductRepository r)
        {
            repository = r;
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
                    FormsAuthentication.SetAuthCookie(user.Name, true);
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
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
                        City = model.City
                    });
                    user = repository.Users.Where(u => u.Email == model.Email).FirstOrDefault();
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
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
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Main");
        }
    }
}