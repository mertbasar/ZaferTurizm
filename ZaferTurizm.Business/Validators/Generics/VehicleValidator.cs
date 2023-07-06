using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Validators.Generics
{
    public class VehicleValidator : IValidator<Vehicle>
    {
        public ValidationResult Validate(Vehicle entity)
        {
            var result = new ValidationResult();
            if (entity.PlateNumber == null)
            {
                result.Messages.Add("Plaka boş olamaz");
            }
            if (entity.ImagesUrl==null)
            {
                result.Messages.Add("Resim eklenmemiş.");
            }
            if (entity.VehicleDefinitionId<=0)
            {
                result.Messages.Add("Araç model seçişmemiş");
            }
            return result;
        }
    }
}
