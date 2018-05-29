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
using Diplom.HtmlHelpers;

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

        public ActionResult Details(int id = 0)
        {
            Product product = repository.Products.FirstOrDefault(x => x.ProductId == id);
            ViewBag.Role = User.IsInRole("admin");
            ViewBag.ProductsCount = repository.Products.Where(x => x.UserID == product.UserID).Count();
            return View(product);
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
                Mapper.Reset();
                Mapper.Initialize(map => map.CreateMap<AddProductViewModel, Product>());
                Product product = Mapper.Map<AddProductViewModel, Product>(model);
                product.DateUpdate = DateTime.Now;
                product.Payment = String.Empty;
                product.Delivery = String.Empty;
                foreach (var item in model.Delivery)
                {
                    product.Delivery += item + "; ";
                }
                foreach (var item in model.Payment)
                {
                    product.Payment += item + "; ";
                }

                product.UserID = User.Identity.GetUserId<int>();
                product.CategoryID = (from one_category in repository.Categories
                                      where one_category.CategoryName == model.CategoryName
                                      select one_category.CategoryID).FirstOrDefault();
                repository.SaveProduct(product);
                return Json(new { success = true, id = User.Identity.GetUserId<int>() });
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int ProductId, int UserId)
        {
            Product deletedProduct = repository.DeleteProduct(ProductId);

            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Объявление \"{0}\" было удалено", deletedProduct.Name);
            }
            return RedirectToAction("Products", "Account", new { id = UserId });
        }

        public PartialViewResult EditProduct(int id)
        {
            Product product = repository.Products.FirstOrDefault(m => m.ProductId == id);
            Mapper.Reset();
            Mapper.Initialize(map => map.CreateMap<Product, AddProductViewModel>());
            var model = Mapper.Map<Product, AddProductViewModel>(product);
            model.CategoryName = product.Category.CategoryName;
            return PartialView("AddProduct", model);
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            ViewBag.Search = search;
            var products = repository.Products.Where(m => m.Name.Contains(search) || m.Description.Contains(search) || m.User.City.Contains(search));
            return View(products);
        }
    }
}