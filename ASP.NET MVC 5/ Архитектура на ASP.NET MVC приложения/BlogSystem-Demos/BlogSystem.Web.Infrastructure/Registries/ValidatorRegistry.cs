namespace BlogSystem.Web.Infrastructure.Registries
{
    using Constants;
    using Ninject;
    using Ninject.Extensions.Conventions;

    public class ValidatorBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind(k => k.From(Assemblies.Validators)
                .SelectAllClasses()
                .BindSingleInterface());
        }
    }
}
