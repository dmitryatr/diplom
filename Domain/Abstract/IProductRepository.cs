using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Category> Categories { get; }
        IEnumerable<User> Users { get; }
        IEnumerable<Role> Roles { get; }
        void AddUser(User user);
        void AddProduct(Product product);
        Product DeleteProduct(int id);
        void SaveProduct(Product product);
        void EditUser(User user);
    }
}
