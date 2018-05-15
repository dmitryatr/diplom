using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Abstract;

namespace Diplom.Controllers
{
    public class NavController : Controller
    {
        IProductRepository repository;
        public NavController(IProductRepository r)
        {
            repository = r;
        }

        public ActionResult Menu(string category = null)
        {
            List<Category> menu = repository.Categories.ToList();
            return PartialView(menu);
        }
    }
}