using System.Collections.Generic;
using Domain.Entities;
using Domain.Abstract;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        AppDBContext context = new AppDBContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products.Include("Category").Include("User"); }
        }

        public IEnumerable<Category> Categories
        {
            get { return context.Categories; }
        }

        public IEnumerable<User> Users
        {
            get { return context.Users.Include("Role"); }
        }

        public IEnumerable<Role> Roles
        {
            get { return context.Roles; }
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public Product DeleteProduct(int id)
        {
            Product product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                context.Entry(product).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void EditUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
