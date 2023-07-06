﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Validators.Generics
{
    public interface IValidator<TEntity> 
        where TEntity : class,IEntity, new()
    {
        ValidationResult Validate(TEntity entity);
    }
}
