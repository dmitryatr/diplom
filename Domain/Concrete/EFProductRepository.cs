using System.Collections.Generic;
using Domain.Entities;
using Domain.Abstract;

namespace Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        AppDBContext context = new AppDBContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products.Include("Category"); }
        }

        public IEnumerable<Category> Categories
        {
            get { return context.Categories; }
        }

        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
