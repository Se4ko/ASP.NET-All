namespace BlogSystem.Web.Infrastructure.ModelBinders
{
    using BlogSystem.Data;
    using BlogSystem.Model;
    using System.Web.Mvc;

    public class EntityModelBinder<TEntity> : IModelBinder
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> repository;

        public EntityModelBinder(IRepository<TEntity> repo)
        {
            this.repository = repo;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue("id");
            var id = int.Parse(value.AttemptedValue as string);
            var entity = this.repository.GetById(id);
            return entity;
        }
    }
}
