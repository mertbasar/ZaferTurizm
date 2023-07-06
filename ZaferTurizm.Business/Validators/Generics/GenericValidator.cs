using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Validators.Generics
{
    public class GenericValidator<TEntity> : IValidator<TEntity>
        where TEntity : class, IEntity, new()
    {
        public ValidationResult Validate(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
