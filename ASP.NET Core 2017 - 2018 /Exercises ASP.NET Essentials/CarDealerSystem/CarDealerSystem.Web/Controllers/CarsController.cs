using CarDealerSystem.Data.Models;
using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Services.Models.Cars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerSystem.Web.Controllers
{
    /* 
      
    Za da otgovarq edin class na url-i trqbwa: ili da 1. zavurshva na Controller,
    ili da 2. nasledqva Controller class-a,
    ili da 3. ima otgore attribut [Controller] Togava moje da go hvashta route-inga i da ba4ka kato controller.
    Nasldq li Controller class: moga ve4e da vrushtav View-ta, primerno return View(), Redirect(), NotFound(),
    Unauthorized() .. Standartno Actionite vrushtat IActionResult(), tova e abstrakciq, 
    nad vsqko neshto, koeto bazovia Controller ni dava: View(), Redirect(), NotFound(),
    Unauthorized() .. View-to predstavlqva renderiran html, vrushta go i browser-a zapo4va da go vijda.
    Moje da ima i ednoredovi Action-i: public IActionResult Create() => View();
    Ako: return RedirectToAction(nameof(Create)); tova vrushta kum Create Action-a, ili
    return RedirectToAction(nameof(Create), "Home"); vrushta kum Contoller Home, Action Create ili
    return RedirectToAction(nameof(Create), new { id = 5, Name = "Sechko" }); ako Create o4akva id i Name, go polu4avam,
    moje sloja i Controller ime da prashta.

    Nai-dobrata praktika e prez viewModelite da davam danni, ponqkoga moje i prez: ViewBag & ViewData,
    ViewData("Name") = "Ivan";

    Vij view: Parts.cshtml sega! 
    Setvaiki kato Attribute v html-a:  asp-validation-summary="All"
    eto taka: 
    
    <div asp-validation-summary="All"></div> 
    
    i vsi4ki greshko v ViewModel-a shte se pokazvat v div-a.
    Moga da hvashtam greshki i za konkretno property, eto taka:
    
     <input asp-for="@Model.Id" /> <span asp-validation-for="Id"></span>
     
     za Id-to greshkata se vizualizira, do poleto deto se vkarva Id-to.
     Ako formata e golqma e hubavo greshkide da sa do input-ite, 
     za da vizualizira greshkite tam deto se populva, moje i da se style-izirva s CSS

     Tuka ne e pravqt custom attributes, podurja se vsi4ko:
     Vij SEGA! TestViewModel.cs .. IValidatableObject se implementira i 
     taka se deistva za po custom vurhu ViewModel-a.

     Imame i generirane na URL:
     
     var url = this.Url.Action("index", "Home"); 
     
     Tova shte ni generira URL na bazata na route-inga, 
     za tozi actionz: index itozi contoller: Home i
     ako route-inga e registriran: {controller}/{action} togava go hvashta: Home/index, 
     oba4e ako route-inga e registriran: Admin/{controller}/{action} togava stava: Admin/Home/index

     Mojem da vurnem fail:
     Ako sushtetvuva, shte go vurne, kato za Download
     return File("/images/sechko.jpg", "image/jpeg");

     */
    // Ako ima takuv route: [Route("")]  tova zna4i 4e go hvashta: /Home
    [Route("cars")]  // Attribute Routing: izri4no na vseki Action opisva kakvo se slu4va. Vij StartUp.cs Line 90
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        private readonly ISimpleLoggerService simpleLoggerService;

        public CarsController(ICarService carService, ISimpleLoggerService simpleLoggerService)
        {
            this.carService = carService;
            this.simpleLoggerService = simpleLoggerService;
        }

        [Route("{make}")]  // Kazva ako ima {make} kato parameter v All i go machva
        public IActionResult All(string make)
        {
            // Ako imam collekciq: return new [] {1, 2, 3, 4, 5}; tova automati4no shte bude vurnato v json ili XML,
            // V zavisimost ot request-a: ako v request-a ne pishe kakvo o4akva browser-a shte vurne json

            if (string.IsNullOrEmpty(make))
            {
                return RedirectToAction("Index", "Home");
            }

            AllCarsFromMakeModel model = this.carService.AllFromMake(make);

            return View(model);
        }

        /*  
          Ako imam v url-a po Query String:  ?search=dasdas&ivan=duroduro&sechko=oppa 
          i v methoda si imam i 3-te parametura i mach-va
        */
         
        public IActionResult QueryStringTest(string search, string ivan, string sechko)
        {
            return StatusCode(200);
        }

        [Route("{id}/parts")]  // tozi Action e kombinaciq ot Controllera: cars/id/parts kudeto id e parametura
        public IActionResult Parts(int id)
        {
            /* 
               Moje vmesto StartUp.cs nastroikite za services.AddTransient<INeshtosi> ..
               Moje i taka:
               var carService = this.HttpContext.RequestServices.GetService(typeof(ICatService));
            */

            if (id <= 0)
            {
                return NotFound();
            }

            var model = this.carService.CarWithParts(id);
            if (model is null)
            {
                return NotFound();
            }

            this.ViewData["CarId"] = id;
            return View(model);
        }

        [Authorize]
        [Route(nameof(Add))]
        public IActionResult Add()
        {
            AddCarModel model = this.carService.GetAddCarInfo();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [Route(nameof(Add))]
        public IActionResult Add(AddCarModel addCarModel)
        {
            this.simpleLoggerService.LogToDb(this.User.Identity.Name, LogType.Add, "Cars");

            if (this.ModelState.IsValid)
            {
                this.carService.AddNewCar(addCarModel);

                return RedirectToAction("All", new { make = addCarModel.Make });
            }

            addCarModel.AvailableParts = this.carService.GetAddCarInfo().AvailableParts;

            return this.View(addCarModel);
        }
    }
}