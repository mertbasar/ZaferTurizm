using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Validators.Generics
{
    public class VehicleModelValidator : IValidator<VehicleModel>
    {
        public ValidationResult Validate(VehicleModel entity)
        {
            var result = new ValidationResult();
            if(entity.Name == null)
            {
                result.Messages.Add("İsim Kısmı boş geçilemez.");
            }
            if (entity.VehicleMakeId<=0)
            {
                result.Messages.Add("Marka Adı boş geçilemez.");
            }
            return result;
        }
    }
}
