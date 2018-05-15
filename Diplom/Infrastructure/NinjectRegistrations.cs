using Ninject.Modules;
using Domain.Concrete;
using Domain.Abstract;

namespace Diplom.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}