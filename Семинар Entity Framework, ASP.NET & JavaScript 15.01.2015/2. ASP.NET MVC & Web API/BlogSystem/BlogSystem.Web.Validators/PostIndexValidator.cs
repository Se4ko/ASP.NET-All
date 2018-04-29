namespace BlogSystem.Web.Validators
{
    using System.Web.Mvc;

    using BlogSystem.Web.Validators.Base;
    using BlogSystem.Web.ViewModels.Posts;

    public class PostIndexValidator : BaseValidator<PostIndexViewModel>
    {
        public override bool Validate(PostIndexViewModel model, ControllerContext controllerContext)
        {
            // validate model

            throw new System.NotImplementedException();
        }
    }
}
