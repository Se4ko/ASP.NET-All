namespace BlogSystem.Web.Infrastructure.Registries
{
    using ActionResults.Contracts;
    using Constants;
    using Ninject;
    using Ninject.Extensions.Conventions;

    public class ActionHandlerBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind(k => k.From(Assemblies.ActionHandlers)
                .SelectAllClasses()
                .InheritedFromAny(typeof(IActionHandler<>), typeof(IActionHandlerWithModel<>), typeof(IPostedDataActionHandler<>))
                .BindSingleInterface());
        }
    }
}
