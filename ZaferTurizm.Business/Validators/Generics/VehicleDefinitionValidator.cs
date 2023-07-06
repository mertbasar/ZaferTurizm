using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Validators.Generics
{
    public class VehicleDefinitionValidator : IValidator<VehicleDefinition>
    {
        public ValidationResult Validate(VehicleDefinition entity)
        {
            var result = new ValidationResult();
            if (entity.VehicleModelId<=0) 
            {
                result.Messages.Add("Model belirtmelisiniz");
            }
            if (entity.SeatCount<=0)
            {
                result.Messages.Add("Koltuk sayısı geçersiz");
            }
            return result;
        }
    }
}
            





