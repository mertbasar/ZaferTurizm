using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using ZaferTurizm.Business.Services.CityManagers;
using ZaferTurizm.Business.Services.RouteManagers;
using ZaferTurizm.DTOs.RouteAllDtos;

namespace ZaferTurizm.WebApp.Controllers
{
    public class RouteController : Controller
    {
        private readonly IRouteService _routeService;
        private readonly ICityService _cityService;
        private readonly IToastNotification _toastr;

        public RouteController(IRouteService routeService,ICityService cityService,IToastNotification toastr)
        {
            _routeService = routeService;
            _cityService = cityService;
            _toastr = toastr;
        }

        public IActionResult Index()
        {
            return View(_routeService.GetSummaries());
        }
        public IActionResult Create()
        {
            FillCities();
            return View();
        }
        [HttpPost]
        public IActionResult Create(RouteDto route) 
        {
            if (route==null)
            {
                _toastr.AddErrorToastMessage("Ekleme işlemi başarısız");
                return View();
            }
            var result = _routeService.Create(route);
            
            if (result.IsSuccess)
            {
                _toastr.AddSuccessToastMessage(result.Message.Replace("\n", "<br>"));
                return RedirectToAction("Index");
            }
            else
            {
                _toastr.AddErrorToastMessage(result.Message.Replace("\n", "<br>"));
                FillCities();
                return View();
            }
        
        }
        private void FillCities()
        {
            var cities = _cityService.GetAllCities();
            ViewBag.sehirler = new SelectList(cities, "Id", "Name");
        }
        public IActionResult Delete(int id)
        {
            if (id==0)
            {
                _toastr.AddErrorToastMessage("Silme işlemi yapılamadı");
                return RedirectToAction("Index");
            }
            var deletedResult = _routeService.Delete(id);
            if (deletedResult.IsSuccess)
            {
                _toastr.AddSuccessToastMessage("Silindi sir/maam");
                return RedirectToAction("Index");
            }
            else
            {
                _toastr.AddErrorToastMessage("İşlem başarısız");
                return RedirectToAction(nameof(Index));
            }


        }
    }
}
