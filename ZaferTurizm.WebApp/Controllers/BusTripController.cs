using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using ZaferTurizm.Business.Services.BusTripManagers;
using ZaferTurizm.Business.Services.RouteManagers;
using ZaferTurizm.Business.Services.VehicleManagers;
using ZaferTurizm.DTOs.BusTripAllDtos;

namespace ZaferTurizm.WebApp.Controllers
{
    public class BusTripController : Controller
    {
        private readonly IBusTripService _busTripService;
        private readonly IVehicleService _vehicleService;
        private readonly IRouteService _routeService;
        private readonly IToastNotification _toastNotification;

        public BusTripController(
            IBusTripService busTripService,
            IVehicleService vehicleService,
            IRouteService routeService,
            IToastNotification toastNotification)
        {
            _busTripService = busTripService;
            _vehicleService = vehicleService;
            _routeService = routeService;
            _toastNotification = toastNotification;
        }
        //Mediatr
        //CQRS
        public IActionResult Index()
        {
            if (TempData["SuccessMessage"]!=null)
            {
                var messages = TempData["SuccessMessage"];
                _toastNotification.AddSuccessToastMessage(messages?.ToString());
            }
            return View(_busTripService.GetSummaries());
        }
        public IActionResult Create()
        {
            FillRouteAndVehicleValues();
            // Action değişiyorsa ViewBag kullanamıyoruz
            //Actionlar arası data taşımak istiyorsak ==> TempData.. TempData hiç okunmazsa veri ölmüyor kendini saklıyor sürekli
            //ViewData bak..
            return View();//içinde model göndermeyle farkını sor
        }
        [HttpPost]
        public IActionResult Create(BusTripDto busTripDto)
        {
            if (busTripDto == null)
            {
                _toastNotification.AddErrorToastMessage("Veri boş");
                FillRouteAndVehicleValues();
                return View();
            }
            var result = _busTripService.Create(busTripDto);
            if (result.IsSuccess)
            {
                
                TempData["SuccessMessage"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                FillRouteAndVehicleValues();
                var errors = string.Join('\n', result.Message);
                _toastNotification.AddAlertToastMessage(errors.Replace("\n", "<br>"));
                
                return View(busTripDto);
            }
            
        }
        private void FillRouteAndVehicleValues()
        {
            var vehiclesInfo = _vehicleService.GetSummaries();
            ViewBag.arac = new SelectList(vehiclesInfo, "Id", "VehicleDefinitionInfo");

            var routesInfo = _routeService.GetSummaries();
            ViewBag.route = new SelectList(routesInfo, "Id", "RouteName");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id==0)
            {
                _toastNotification.AddErrorToastMessage("Id değeri boş..");
                return RedirectToAction("Index");   
            }
            var result = _busTripService.Delete(id);
            return Json(result.Message);

        }
    }
}
