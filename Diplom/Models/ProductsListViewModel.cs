using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public User User { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string PrevCategory { get; set; }
        public string CurrentCategoryUrl { get; set; }
        public string PrevCategoryUrl { get; set; }
    }
}