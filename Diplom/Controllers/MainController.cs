using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using Diplom.Models;

namespace Diplom.Controllers
{
    public class MainController : Controller
    {
        IProductRepository repository;
        public int pageSize = 2;

        public MainController(IProductRepository r)
        {
            repository = r;
        }
        public ActionResult Index(string category, int page = 1)
        {
            int categoryID = (from one_category in repository.Categories
                              where one_category.CategoryUrl == category
                              select one_category.CategoryID).FirstOrDefault();

            int categoryIDPrev = (from one_category in repository.Categories
                                  where one_category.CategoryID == categoryID
                                  select one_category.ParentID.GetValueOrDefault()).FirstOrDefault();
     
            var products = repository.Products
                       .Where(p => category == null || p.CategoryID == categoryID || p.Category.ParentID == categoryID);
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = products
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                pagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = products.Count()
                },
                CurrentCategory = (from one_category in repository.Categories
                                   where one_category.CategoryUrl == category
                                   select one_category.CategoryName).FirstOrDefault(),
                PrevCategory = (from one_category in repository.Categories
                                where one_category.CategoryID == categoryIDPrev
                                select one_category.CategoryName).FirstOrDefault(),
                PrevCategoryUrl = (from one_category in repository.Categories
                                   where one_category.CategoryID == categoryIDPrev
                                   select one_category.CategoryUrl).FirstOrDefault(),
                CurrentCategoryUrl = category
        };
            return View(model); 
        }

        [HttpPost]
        public ActionResult Index()
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct();
                return RedirectToAction("Index");
            }
            else return View();
        }
    }
}