﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplom.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult AddProduct()
        {
            return PartialView();
        }
    }
}