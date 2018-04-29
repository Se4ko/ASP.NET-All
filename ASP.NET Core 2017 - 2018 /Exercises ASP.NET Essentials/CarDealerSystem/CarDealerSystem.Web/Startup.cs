using CarDealerSystem.Data.Models;
using CarDealerSystem.Services;
using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealerSystem.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            /* 1. Configuraciqta ot faila appsettings.json vzima informaciq za ConnectionStrings i dr. nastroiki
            na prod & dev. */
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            this.Configuration.Get<string>();  // 2. taka vzimam neshto ot configuraciqta

            //3. registrirva CarDealerDbContext-a i kazva koq baza danni
            services.AddDbContext<CarDealerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); 
            

            //4.  tova e authentikaciata izpolzva bydefault <User, IdentityRole>
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<CarDealerDbContext>()
                .AddDefaultTokenProviders();

            /*
               5.  dobavqt se Servicite 
               AddTransient kazva: vseki put podam li mu INeshtosi, shte mu suzdva nova instanciq,
               vmesto Ninject i v Controllera podpuha.
            */
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ISalesService, SalesService>();
            services.AddTransient<IPartService, PartService>();
            services.AddTransient<ISimpleLoggerService, SimpleLoggerService>();

            // Add application services.

            //6. dobavq routing-a
            services.AddRouting(options => options.LowercaseUrls = true);

            // dobavq se MVC kum samiq server, da prihvashta controllers, roulting ..
            services.AddMvc();
        }


         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //7. Tozi method registrira Middlewaeri, za da moje nasetoprilojenie da obrabotva requesti
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())  // ako prilojenieto e runnato v developement ili debug, da:
            {
                app.UseDeveloperExceptionPage();  // pokazwa pulet exception
                app.UseBrowserLink();  // da refreshv-a Browsera, pri promeni nqkoi CSS naprimer ili podobno
                app.UseDatabaseErrorPage();  // ako bazata grumne da ni se pokaje buton4e da migrirame ili podobno
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");  // ako e v Production da se izpulni tozi URL
            }

            app.UseStaticFiles();  // Kazvame 4e vsi4ko v wwwroot folder stava publi4no 
                                  //  vsi4ko public deto browsera moje da vijda TUK

            app.UseAuthentication();  // authentikciq proverqva user-a parsva cookies i dr.


            // Tova dolu se vika za da moje requestite da se machvat za controller-i, action-i ..
            // 1-vi vid routing: Ako go registriram s configuraciq: app.UseMvcWithDefaultRoute(); s defolten ralting kudeto machne ili by default 
            // 2-ri vid routing: Ako go registriram bez configuraciq: app.UseMvc se izpolzva Attributna configuraciq na routa
            // Attribute routing izri4no na vseki Action opisva kakvo se slu4va:
            /* 
               [Route("/")]
               public IActionResult index()
               {
                    return View();
               }
               
            */
            app.UseMvc(routes =>     
            {
                // v reda na raltovete MVC-to se opitva da machne nqkoe i vurvi v tozi red, dokato ne hvane neshto

                //routes.MapRoute(
                //    name: "customers",
                //    template: "customers/all/{order}",
                //    defaults: new { controller = "Customers", action = "All" }
                //    );

                //routes.MapRoute(
                //    name: "customersSummary",
                //    template: "customers/{id}",
                //    defaults: new { controller = "Customers", action = "Summary" }
                //    );

                //routes.MapRoute(
                //    name: "cars",
                //    template: "cars/{make}",
                //    defaults: new { controller = "Cars", action = "All" }
                //    );

                //routes.MapRoute(
                //    name: "carsParts",
                //    template: "cars/{id}/parts",
                //    defaults: new { controller = "Cars", action = "Parts" }
                //    );

                //routes.MapRoute(
                //     name: "suppliers",
                //     template: "suppliers/{region}",
                //     defaults: new { controller = "Suppliers", action = "All" }
                //     );
                //routes.MapRoute(
                //     name: "salesDiscounts",
                //     template: "sales/discounted/{percent?}", //machva controller: sales/discounted/12% opcionalno
                //     defaults: new { controller = "Sales", action = "Discounted" }  /ako li ne eto defaultniq
                //     );
                //routes.MapRoute(
                //     name: "sales",
                //     template: "sales/{id?}",
                //     defaults: new { controller = "Sales", action = "All" }
                //     );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}