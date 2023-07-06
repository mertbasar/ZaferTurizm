using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using System.Reflection.Metadata.Ecma335;
using ZaferTurizm.Business.Services.VehicleMakeManagers;
using ZaferTurizm.Business.Services.VehicleModelManagers;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs.VehicleModelAllDtos;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly IToastNotification _toastNotification;

        public VehicleModelController(
            IVehicleModelService vehicleModelService,
            IVehicleMakeService vehicleMakeService,
            IToastNotification toastNotification)
        {
            _vehicleModelService = vehicleModelService;
            _vehicleMakeService = vehicleMakeService;
            _toastNotification = toastNotification;
        }

        public IActionResult Create()

        {
            FillVehicleMakeList();

            return View();
        }
        [HttpPost]
        public IActionResult Create(VehicleModelDto vmo)
        {
            if(vmo.Name==null)
            {
                //Thread.Sleep(3000); -> Altındaki kod bloğunun 3 sn boyunca çalışması direkt bloke eder.
                _toastNotification.AddWarningToastMessage("Model ismi boş,tekrar deneyiniz");
                FillVehicleMakeList();

                return View();
            }
           var result = _vehicleModelService.Create(vmo);
            if (result.IsSuccess)
            {
                _toastNotification.AddSuccessToastMessage("Model başarıyla eklendi.");
                return RedirectToAction("Index");
            }
            else
            {
                _toastNotification.AddErrorToastMessage("Ekleme İşlemi Başarısız");
                FillVehicleMakeList();
                return View();
            }
        }
        private void FillVehicleMakeList()
        {
            var vehicleMakes = _vehicleMakeService.GetAll();
            
            ViewBag.VehicleMakeSelectList = new SelectList(vehicleMakes, "Id", "Name");
        }
        public IActionResult Index()
        {
            
            return View(_vehicleModelService.GetSummaries());
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var result = _vehicleModelService.Delete(id);
            //if (result.IsSuccess)  return RedirectToAction("Index");
            //else
            //{
            //    ViewBag.msg =result.Message; 
            //    return RedirectToAction("Index");
            //} 
            return Json(result.Message);
        }
        public IActionResult Edit(int id)
        {
            FillVehicleMakeList();
            var vehModel = _vehicleModelService.GetById(id);
          
            return View(vehModel);
        }

        [HttpPost]
        public IActionResult Edit(VehicleModelDto vmo)
        {
            var result = _vehicleModelService.Update(vmo);
            if (result.IsSuccess)
            {
                _toastNotification.AddSuccessToastMessage("Model Başarıyla Güncellendi.");
                return RedirectToAction(nameof(Index));
            }

            else 
            {

                FillVehicleMakeList();
                return View(vmo);

            }

            
            
        }
        public IActionResult GetVehicleModelsById(int vehicleMakeId)
        {
            var modelsByVehiclesId = _vehicleModelService.GetByMakeId(vehicleMakeId);
            return Json(modelsByVehiclesId);
        }
    }
}
            
            

