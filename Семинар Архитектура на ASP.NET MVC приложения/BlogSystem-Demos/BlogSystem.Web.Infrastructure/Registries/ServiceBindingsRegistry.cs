namespace BlogSystem.Web.Infrastructure.Registries
{
    using BlogSystem.Services.Contracts;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    public class ServiceBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind(k => k.FromAssemblyContaining<IService>()
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(b => b.InRequestScope()));
        }
    }
}
