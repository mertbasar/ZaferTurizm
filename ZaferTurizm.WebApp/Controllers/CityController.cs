using Microsoft.AspNetCore.Mvc;
using ZaferTurizm.Business.Services.CityManagers;

namespace ZaferTurizm.WebApp.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            var cities = _cityService.GetAllCities();
            return View(cities);
        }
    }
}
