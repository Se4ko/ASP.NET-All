namespace LearningSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using LearningSystem.Data;
    using LearningSystem.Web.Models.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "WebConstants.AdministratorRole")]
    public class IdentityController : Controller
    {
        private readonly LearningSystemDbContext db;

        public  IdentityController(LearningSystemDbContext db)
        {
            this.db = db;
        }

            public IActionResult All()
            {
                var users = this.db
                    .Users
                    .OrderBy(u => u.Email)
                    .Select(u => new ListUserViewModel
                    {
                        Id = u.Id,
                        Username = u.UserName,
                        Email = u.Email  
                    })
                    .ToList();
            
                return View(users);
            }

    }
}
