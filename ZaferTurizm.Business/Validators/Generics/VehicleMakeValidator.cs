using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Validators.Generics
{
    public class VehicleMakeValidator : IValidator<VehicleMake>
    {
        public ValidationResult Validate(VehicleMake entity)
        {
            var result = new ValidationResult();
            if (entity.Name==null) 
            {
                result.Messages.Add("Marka adı girmeniz gerekir");
            }
            return result;
        }
    }
}
