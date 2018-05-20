namespace CatsServer.Infrastructure.Extensions
{
    using CatsServer.Handlers;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Middleware;
    using System;
    using System.Linq;
    using System.Reflection;

    public static class ApplicationBuilderExtensions
    {
		/* builder.UseMiddleware<>
		   Adds a middleware type to the application's request pipeline */
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder builder)
            => builder.UseMiddleware<DatabaseMigrationMiddleware>();

        public static IApplicationBuilder UseHtmlContentType(this IApplicationBuilder builder)
            => builder.UseMiddleware<HtmlContentTypeMiddleware>();

        public static IApplicationBuilder UseRequestHandlers(this IApplicationBuilder builder)
        {
            var handlers = Assembly
                .GetExecutingAssembly()
				.GetTypes() 
                .Where(t => t.IsClass && typeof(IHandler).IsAssignableFrom(t))
                .Select(Activator.CreateInstance)
                .Cast<IHandler>()
                .OrderBy(h => h.Order);
			
            foreach (var handler in handlers)
			{/*всеки handler има public Func<HttpContext, bool> Condition => .. тва е ралта 
               има и делегат RequestDelegate RequestHandler => в който се изпълняват нещата..                                                               */
                builder.MapWhen(handler.Condition, app =>//на конкретния ралт
                {
					app.Run(handler.RequestHandler);// app.Run(..) изпълни каквото има и приключвай
                });
            }

            return builder;
        }

        public static void UseNotFoundHandler(this IApplicationBuilder builder)
        {
            builder.Run(async (context) =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("404 Page Was Not Found!");
            });
        }
    }
}