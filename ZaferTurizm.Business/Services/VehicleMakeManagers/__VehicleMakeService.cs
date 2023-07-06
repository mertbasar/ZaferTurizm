using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.VehicleMakeManagers;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs.VehicleMakeAllDtos;

namespace ZaferTurizm.Business.Services
{
    //Command :  Create, Update, Delete   
    //Query   :  Read
    public class __VehicleMakeService : __IVehicleMakeService
    {
        private readonly TourDbContext _tourDbContext;

        // Parametreye gönderilen -> Argüman 
        // parametre -> metotta tanımlanmış, dışarıdan gelen  değerleri karşılayacak olan değişken
        // argüman -> parametreye gönderilmiş değer
        public __VehicleMakeService(TourDbContext tourDbContext)
        {
            if (tourDbContext==null)
            {
                throw new ArgumentNullException("tourDbContext");
                //throw new ArgumentNullException(nameof(tourDbContext)
            }
            _tourDbContext = tourDbContext;
        }
        public CommandResult Create(VehicleMakeDto model) //Normal şartlarda geri dönüle gerek yok query olmadıkları için.
                                                         // hatanın sebebini detaylı geri yansıtabilmek için 
        {
            // Hata alma ihtimaline karşın try catch ile yapıyoruz.
            try
            {
                if(string.IsNullOrEmpty(model.Name))
                {
                    return CommandResult.Failure();
                }
                //Mapping -> Verileri Aktarma 
                var vehicleMakeEntity = new VehicleMake()

                {
                    Name = model.Name,
                };
                _tourDbContext.Add(vehicleMakeEntity);
                _tourDbContext.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex) //-> sistemdeki hataların atası exception
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
                
            }
            
        }
        public CommandResult Delete(VehicleMakeDto model)
        {
            if (model==null)
            {
                throw new ArgumentException(nameof(model), "Model null olamaz");
            }
            // Bu metot içerisinde tüm Delete akışını ayrıca implement etmeye gerek yok
            // Zaten bu işi Id üzerinden yapabilen aşağıdaki Delete(id) implemention'ı mevcut,
            // O yüzden bu metot çağrıldığından model.Id değerini aşağıdaki metoda göndererek 
            // pratik bir kodlama yapabiliriz.
            return Delete(model.Id);

        }



        public CommandResult Delete(int id)
        {
            var entity = new VehicleMake() { Id = id };// Daha performanslı Yöntem. bunu yaptığımda findlamaya gerek yok

            try
            {
                /*var vm = _tourDbContext.VehicleMakes.Find(id);*/// Klasik yöntem önce kaydı oku (entity izlenmeye başlıyor)
                /* _tourDbContext.Remove(vm); */
                _tourDbContext.VehicleMakes.Remove(entity);
                _tourDbContext.SaveChanges();                 // gerektiğini bildir (State'i Deleted olarak işaretlenecek)
                return CommandResult.Success();               // entity = _tourDbContext.VehicleMakes.Find(id);
                
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();


                //CommandResult Error yaz (ex alan ve mesaj için)..
            }
        }

        public IEnumerable<VehicleMakeDto> GetAll()
        {
            // Set methodu DbSet DÖNDÜRÜYOR.
            try
            {
                var vehicleMakeList = _tourDbContext.VehicleMakes.ToList();
                var vdtoList = new List<VehicleMakeDto>();
                foreach (var vehicleMake in vehicleMakeList)
                {
                    vdtoList.Add(new VehicleMakeDto()
                    {
                        Id = vehicleMake.Id,
                        Name = vehicleMake.Name,
                    });
                }
                return vdtoList;

                ///*****Alternetif ve Daha Pratik Bir Yol********////////

                // return _tourDbContext.VehicleMakes.Select(v => new VehicleMakeDto()
                //{
                //    Id = v.Id,
                //    Name = v.Name
                //}).ToList();
            }
            catch(Exception ex) 
            {
                Trace.TraceError(ex.ToString());
                //**Tekil bir kayit için kaydın olma durumuna instance
                //**olmama durumuna null gönder.

                //**Koleksiyon tipindeki bir veri için
                //**Verinin olma durumu Instance( veya birden fazla kayır içerir şekilde)
                //**Verinin olmama durumunda boş koleksiyon döndür.
                //**Koleksiyonlar için null değerinden mümkün olduğunca kaçınmak gerekir
                //**Bir koleksiyonun boş olduğu anlamını taşımamalı

                //return new List<VehicleMakeDto>();
                return Enumerable.Empty<VehicleMakeDto>();
            }  
        }



        public VehicleMakeDto GetById(int id)
        {
            var vehicleMake = _tourDbContext.VehicleMakes.FirstOrDefault(x => x.Id == id);

            try
            {
                if (vehicleMake ==null)
                {
                    return null;
                }
                var vehicleMakeDto = new VehicleMakeDto()
                {
                    Id = vehicleMake.Id,
                    Name = vehicleMake.Name
                };
                return vehicleMakeDto;

            }
            catch(Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;

            } 
        }
        public CommandResult Update(VehicleMakeDto model)
        {
            // Single -> yazdığımız kritere göre mutlaka 1 kayıt olmalı.tek bir kayıt varsa getirir yoksa hata verir.
            // SingleOrDefault -> yazdığınız kriterde 1 kayıt olmalı yada hiç olmamalı
            // First -> Kayıtların ilkini getirir. Kayıtlardan bir tane mutlaka olmalı ama ilkini döndürür
            // Find-> DbSet üzerinde PK değer ile bir kaydı bulmaya yarayan metod
            if (model == null)
            {
                //GENEL OLARAK BU TEKNİĞE Guard veya Defensive Coding denir.
                throw new ArgumentNullException(nameof(model),"VehicleMakeDto nesnesi null değer olamaz");
            }
            //Validation
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return CommandResult.Failure("Marka adı boş geçilemez");
            }
            var entity = new VehicleMake()
            {
                Id = model.Id,
                Name = model.Name,
            };
            try
            {                                                       
                _tourDbContext.Update(entity);
                _tourDbContext.SaveChanges();
                return CommandResult.Success();
            }
                    
            //Eğer .Net Core değil de .Net Framework ile EF kullanılıyor olsaydı.

            //1.En Klasik Yöntem

            //var vehicleMake1 = _tourDbContext.VehicleMakes.Find(model.Id);
            //vehicleMake1.Name = model.Name;
            //_tourDbContext.SaveChanges();

            //2.Attach Yöntemi(Dbden kaydı okumaya gerek yok)
            
            //var vehicleMake2 = new VehicleMake()
            //{
            //    Id = model.Id,
            //    Name = model.Name,
            //};
            //var entry = _tourDbContext.Attach(vehicleMake2);
            //entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //_tourDbContext.SaveChanges();

            catch (Exception ex) 
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("Bir hata meydana geldi. Sistem yöneticisine başvurun");
            }

            //özetle; Linq metotlarında Tekil kayıt döndürmeye yarayan Single, First Last metotlarının 
            //filtre kriterine yazdığınız ifadenin karşılığında kayıt dönmeme ihtimali varsa o durumda 
            // bu metotların OrDefault versiyonunu kullanın.
            //**await gördüğünde sonrasındaki methodları koparıyor gibi düşün onu çalıştırdıktan sonra diğer kodları çalıştırıyor
        }
    }
}
            
            
            
            


                













               
            
            
            


