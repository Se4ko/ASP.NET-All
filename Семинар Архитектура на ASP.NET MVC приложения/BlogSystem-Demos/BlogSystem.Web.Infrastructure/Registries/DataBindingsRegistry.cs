namespace BlogSystem.Web.Infrastructure.Registries
{
    using BlogSystem.Data;
    using Ninject;
    using Ninject.Web.Common;

    public class DataBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<IBlogSystemDbContext>().To<BlogSystemDbContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));
            kernel.Bind<IBlogSystemData>().To<BlogSystemData>();
        }
    }
}
