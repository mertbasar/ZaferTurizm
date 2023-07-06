using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Validators.Generics
{
    public class RouteValidator : IValidator<Route>
    {
        public ValidationResult Validate(Route entity)
        {
            var result = new ValidationResult();
            if (entity.DepartureCityId<=0)
            
            result.Messages.Add("Kalkış Şehri Belirtilmelidir");
            
            if (entity.ArrivalCityId <= 0)
            {
                result.Messages.Add("Varış Şehri Belirtilmelidir.");
            }
            return result;  

                
        }
    }
}
