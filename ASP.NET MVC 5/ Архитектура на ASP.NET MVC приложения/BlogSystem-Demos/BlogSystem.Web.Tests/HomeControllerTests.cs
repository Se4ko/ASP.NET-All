namespace BlogSystem.Web.Tests
{
    using BlogSystem.Web.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestStack.FluentMVCTesting;

    using Moq;
    using BlogSystem.Data;
    using BlogSystem.Model;

    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexShouldReturnView()
        {
            var controller = new ManageController();

            controller
                .WithCallTo(c => c.AddPhoneNumber())
                .ShouldRenderDefaultView();
        }
    }
}
