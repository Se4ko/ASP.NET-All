namespace BlogSystem.ConsoleClient
{
    using System.Linq;

    using BlogSystem.Data;
    using BlogSystem.Model;
    using System;
    using System.Data.Entity;
    using BlogSystem.Data.Migrations;

    public class Client
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogSystemDbContext, Configuration>());
            var data = new BlogSystemDbContext();

            var post = new Post
            {
                Title = "Hi 3 dsadasdasdasdasdasd",
                PostedOn = DateTime.Now,
            };

            data.Posts.Add(post);
            data.SaveChanges();

            var posts = data.Posts.AsQueryable();

            if (true)
            {
                posts = posts.Where(p => p.Title == "gosho");
            }

            if (true)
            {
                posts = posts.Where(p => p.Subtitle == "pesho");
            }

            var result = posts.ToList();
        }
    }
}
