using Microsoft.AspNetCore.Mvc;
using ZaferTurizm.Business.Services.VehicleMakeManagers;
using ZaferTurizm.DTOs.VehicleMakeAllDtos;
using ZaferTurizm.WebApp.Models;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly IVehicleMakeService _vehicleMakeService;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }

        public IActionResult Index()
        {
            var vehicleMakes = _vehicleMakeService.GetAll();
            return View(vehicleMakes);
        }
        public IActionResult Create() 
        {
            return View();
        }
        //inputlar için name attribute u çok önemli.. sadece bununla httpye veriyi atabiliyoruz.
        //sadece name ile bile kayıt yapabiliyoruz
        //formun action olması önemli
        //buttonun submit olması
        [HttpPost]
        public IActionResult CreateVehicleMake(MarkaViewModel markaViewModel) 
        // IFormCollection ile de verileri tutabilirdik, name yardımıyla
        // çekebilirdik.
        // input name i ile yazılan parametre aynıysa eşleme yapabiliyor
        // marka_adi string..
        // Http get tipindeki requestlerde veriler URLin devamında Query String
        // olarak sunucuya iletilir
        // Örn : VehicleMake/Create?marka_adi=Isuzu
        // Http Post (put ve delete dahil) tipindeki requestlerde veriler Requestin BODY bölümünde (
        // (yani gömülü şekilde) sunucya iletilir
        // get isteği Veri cevabı almak için kullanılmalı(get yöntemi ile ekleme yapmak sakıncalı)
        {
            string vm = markaViewModel.Marka_Adi;
            var vehicleMakeDto = new VehicleMakeDto()
            {
                Name = vm
            };
            var result = _vehicleMakeService.Create(vehicleMakeDto);
            //if (result.IsSuccess)
            //{
            //    return Json(result.Message);
            //}
            //else
            //{
            //    retu
            //}
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Ok();
            }
        }
        //Attributeler eksta meta bilgi sağlamamızı sağlar.

        //Bir action üstüne [HttpPost] gibi Attribiteların eklenmesi , o acition metodun YALNIZCA O HTTP
        //METODU İLE ÇALIŞACAĞONI bildirmek olur. Yani diğer Http metotları ile aynı adrese açılmış Requestlere 
        //CEVAP VERME anlamına gelir.
        //KIsacası, Create action'ını YALNIZCA POST REQUESTLERE CEVAP VER şeklinde kısıtlamış olduk.
        
        //Sadece Post tipindeki requestlere cevap veririm. Düzensiz veri eklemenin (bad request) 
        // önüne geçmek için.
        
        
        //http ile ilgili bilgileri httpcontext içine gider --> ilk bilgilerden
        
            //Http status..
            //200 -> ok.. başarılı
            //3.. -> redirection hataları
            //404 -> not found kullanıcı hatası içerenler // Unauthorized
            //500 -> developer hataları // internal server error
        public IActionResult Update(int id)
        {
            var findedMarka =_vehicleMakeService.GetById(id);
            if (findedMarka != null) 
            { 
                return View(findedMarka); 
            }
            else 
            {
                return NotFound(); 
            }
            
        }
        [HttpPost]
        public IActionResult Update(VehicleMakeDto vehicleMakeDto)
        {
            var result = _vehicleMakeService.Update(vehicleMakeDto);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Ok();        
            }
            
        }
        //public IActionResult Delete(int id)
        //{
            
        //    if (id == 0)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    var result = _vehicleMakeService.Delete(id); 
        //    if (result.IsSuccess)
        //    {
        //        return RedirectToAction("Index");
        //    } 
        //    else
        //    {
        //        return NotFound();
        //    }

            
        //}
        [HttpPost]
        public IActionResult Delete(int id)
        {

            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var result = _vehicleMakeService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }


        }
    }
}




        








