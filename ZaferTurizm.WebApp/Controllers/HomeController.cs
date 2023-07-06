using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using ZaferTurizm.Business.Services.BusTripManagers;
using ZaferTurizm.Business.Services.PassengerManagers;
using ZaferTurizm.Business.Services.RouteManagers;
using ZaferTurizm.Business.Services.TicketManagers;
using ZaferTurizm.DTOs.TicketAllDtos;
using ZaferTurizm.WebApp.Models;

namespace ZaferTurizm.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRouteService _routeService;
        private readonly IBusTripService _busTripService;
        private readonly ITicketService _ticketService;
        private readonly IPassengerService _passengerService;

        public HomeController(
            ILogger<HomeController> logger,
            IRouteService routeService,
            IBusTripService busTripService,
            ITicketService ticketService,
            IPassengerService passengerService)
        {
            _logger = logger;
            _routeService = routeService;
            _busTripService = busTripService;
            _ticketService = ticketService;
            _passengerService = passengerService;

        }

        public IActionResult Index()
        {
            var routes = _routeService.GetSummaries();
            ViewBag.Dnm = new SelectList(routes, "Id", "RouteName");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult GetBusTripWithRoute(int routeId)
        {
            var list = _busTripService.GetTripsWithRouteId(routeId);
            return Json(list);


        }
        public IActionResult PassengerAdd(int busTripId,int seatNumber) 
        {
            var secilmisTrip = _busTripService.GetById(busTripId);

            ViewBag.SeatNumber = seatNumber;

            return View(secilmisTrip);
        }
        [HttpPost]
        public IActionResult PassengerAdd(TicketDto ticketDto)
        {
            var result = _ticketService.Create(ticketDto);

            return Json(result);
        }
        public IActionResult PassengerList()
        {
            return View(_passengerService.GetAll());
        }

    }
}