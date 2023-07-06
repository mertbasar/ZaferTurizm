using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using ZaferTurizm.Business.Services.VehicleDefinitionManagers;

using ZaferTurizm.Business.Services.VehicleManagers;
using ZaferTurizm.Business.Services.VehicleModelManagers;
using ZaferTurizm.DTOs.VehicleAllDtos;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IVehicleDefinitionService _vehicleDefinitonService;
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IToastNotification _toastNotification;
        public VehicleController(
            IVehicleService vehicleService, 
            IVehicleDefinitionService vehicleDefinitonService,
            IVehicleModelService vehicleModelService,
            IWebHostEnvironment webHostEnvironment,
            IToastNotification toastNotification)
        {
            _vehicleService = vehicleService;
            _vehicleDefinitonService = vehicleDefinitonService;
            _vehicleModelService = vehicleModelService;
            _webHostEnvironment = webHostEnvironment;
            _toastNotification= toastNotification;
        }
        public IActionResult Index()
        {
            return View(_vehicleService.GetSummaries());
        }
        public IActionResult Details()
        {
            return View(_vehicleService.GetSummaries());  
        }
        public IActionResult Create()
        {
            var list = _vehicleDefinitonService.GetSummaries();
            ViewBag.Det = new SelectList(list,"Id", "VehicleAllInfo");

            return View();
        }
        [HttpPost] 
        public IActionResult Create(VehicleDto model)
        {
            if (model==null)
            {
                return Ok();
            }
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
            {
                var fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(_webHostEnvironment.WebRootPath, @"OtobusResimleri");
                var ext = Path.GetExtension(files[0].FileName);

                if (model.ImagesUrl != null)
                {
                    var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, model.ImagesUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    { System.IO.File.Delete(imagePath); }
                }
                using (FileStream filesStreams = new FileStream(Path.Combine(uploads, fileName + ext), FileMode.Create))
                {
                    files[0].CopyTo(filesStreams);
                }
                model.ImagesUrl = @"\OtobusResimleri\" + fileName + ext;
            }
            
            var result = _vehicleService.Create(model);
            
            if (result.IsSuccess)
            {
                _toastNotification.AddSuccessToastMessage("Araç başarıyla eklendi");
                return RedirectToAction("Index");
            }
            else
            {
                _toastNotification.AddErrorToastMessage("Yükleme başarısız, tekrar dene.");
                var list = _vehicleService.GetSummaries();
                ViewBag.Det = new SelectList(list, "VehicleDefId", "VehicleDefinitionInfo");
                return View();
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                _toastNotification.AddAlertToastMessage("Hangi aracı sileyim knk");
                return RedirectToAction("Index");
            }
            var result = _vehicleService.Delete(id);

            return Json(result.Message);
        }


                
            
    }
}
