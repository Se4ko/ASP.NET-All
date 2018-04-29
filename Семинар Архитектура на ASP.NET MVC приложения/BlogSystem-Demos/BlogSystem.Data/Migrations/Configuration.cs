namespace BlogSystem.Data.Migrations
{
    using BlogSystem.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BlogSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "BlogSystem.Data.BlogSystemDbContext";
        }

        protected override void Seed(BlogSystemDbContext context)
        {
            
        }
    }
}
