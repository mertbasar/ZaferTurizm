using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Business.Services.VehicleDefinitionManagers;
using ZaferTurizm.Business.Services.VehicleMakeManagers;
using ZaferTurizm.Business.Services.VehicleModelManagers;
using ZaferTurizm.DTOs.VehicleDefinitionAllDtos;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleDefinitionController : Controller
    {
        private readonly IVehicleDefinitionService _vehicleDefinitonService;
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleMakeService _vehicleMakeService;
        public VehicleDefinitionController(
            IVehicleDefinitionService vehicleDefinitonService, 
            IVehicleModelService vehicleModelService, 
            IVehicleMakeService vehicleMakeService) 
        {
            _vehicleDefinitonService = vehicleDefinitonService;
            _vehicleModelService = vehicleModelService;
            _vehicleMakeService = vehicleMakeService;
            
        }

        


        public IActionResult Index()
        {
            return View(_vehicleDefinitonService.GetSummaries());
        }
        public IActionResult Create() 
        {
            var makeList = _vehicleMakeService.GetAll();
            ViewBag.MakeList = new SelectList(makeList,"Id","Name");
            var modelList = _vehicleModelService.GetAll();
            ViewBag.ModelList = new SelectList(modelList, "Id", "Name");
            
            return View();
        }
        //[HttpPost]
        //public IActionResult Create() 
        //{

        //}
        [HttpPost]
        public IActionResult Create(VehicleDefinitionDto vdo)
        {
            if (vdo == null)
            {
                return Json("Ekleme işlemi başarısız,model boş");
            }
            var result = _vehicleDefinitonService.Create(vdo);

            return Json(result);
            
            

            
        }
        public IActionResult Edit(int id)
        {
            var vd = _vehicleDefinitonService.GetById(id);
            if (vd==null)
            {
                return NotFound();
            }

            var makeList = _vehicleMakeService.GetAll();
            ViewBag.MakeList = new SelectList(
                makeList, 
                "Id", 
                "Name",
                vd.VehicleMakeId);
            var modelList = _vehicleModelService.GetByMakeId(vd.VehicleMakeId);
            ViewBag.ModelList = new SelectList(
                modelList,
                "Id",
                "Name");
                
                
           

            return View(vd);
        }
        [HttpPost]
        public IActionResult Edit(VehicleDefinitionDto vdo)
        {
            if (vdo == null) return Ok();
            var result = _vehicleDefinitonService.Update(vdo);
            if(result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var makeList = _vehicleMakeService.GetAll();
                ViewBag.MakeList = new SelectList(
                    makeList,
                    "Id",
                    "Name",
                    vdo.VehicleMakeId);


                return View(vdo);
            }
        }
        public IActionResult Delete(int id)
        {
            if(id == 0)  return Json("Bu boş la"); 
            var result = _vehicleDefinitonService.Delete(id);
            return Json(result.Message);
        }
    }
}




