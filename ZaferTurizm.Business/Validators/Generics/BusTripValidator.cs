using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Validators.Generics
{
    public class BusTripValidator : IValidator<BusTrip>
    {
        public ValidationResult Validate(BusTrip entity)
        {
            var result = new ValidationResult();
            if (entity.RouteId <=0)
            {
                result.Messages.Add("Rota değer boş geçilemez");
            }
            if(entity.VehicleId <=0) 
            {
                result.Messages.Add("Araç bilgisi boş geçilemez.");
            }
            if (entity.Date < DateTime.Now) 
            {
                result.Messages.Add("Geçmiş bir tarih değer olamaz");
            }
            if(entity.Price <= 0) { result.Messages.Add("Hatalı Fiyat Bilgisi"); }

            return result;
        }
        
    }
}
