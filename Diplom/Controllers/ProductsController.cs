using AutoMapper;
using Diplom.Models;
using Domain.Entities;
using Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;

namespace Diplom.Controllers
{
    public class ProductsController : Controller
    {
        IProductRepository repository;

        public ProductsController(IProductRepository r)
        {
            repository = r;
        }

        public ActionResult Categories()
        {
            List<Category> menu = repository.Categories.ToList();
            return PartialView(menu);
        }

        public ActionResult AddProduct()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddProduct(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(map => map.CreateMap<AddProductViewModel, Product>());
                Product product = Mapper.Map<AddProductViewModel, Product>(model);
                product.DateUpdate = DateTime.Now;
                product.UserID = (from one_user in repository.Users
                                  where one_user.Name == User.Identity.Name
                                  select one_user.ID).FirstOrDefault(); ;
                product.CategoryID = 1;
                repository.AddProduct(product);
            }
            return PartialView(model);
        }
    }
}