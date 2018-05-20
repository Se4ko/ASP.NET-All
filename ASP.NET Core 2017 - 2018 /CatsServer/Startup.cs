namespace CatsServer
{
    using Data;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
            => services.AddDbContext<CatsDbContext>(options =>
                options.UseSqlServer(AppSettings.DatabaseConnectionString));

        public void Configure(IApplicationBuilder app)
            => app
                .UseDatabaseMigration()
                .UseStaticFiles()
                .UseHtmlContentType()
                .UseRequestHandlers()
                .UseNotFoundHandler();
    }
}

/* 
Правиме ApplicationBuilderExtensions.cs и 
вътре са всички методи app.UseDatabaseMigration() .., в тях на 
IApplicationBuilder builder-а закачаме Middlewares
(които са класове в Middleware папка)

UseDatabaseMigration() метода, закача DatabaseMigrationMiddleware.cs class:
IApplicationBuilder builder.UseMiddleware<DatabaseMigrationMiddleware>();

UseHtmlContentType() метода, закача HtmlContentTypeMiddleware.cs class:
IApplicationBuilder builder.UseMiddleware<HtmlContentTypeMiddleware>();

Може и там да си напишем Middleware-а, както UseRequestHandlers,
който map-ва за IApplicationBuilder builder всички 

*/