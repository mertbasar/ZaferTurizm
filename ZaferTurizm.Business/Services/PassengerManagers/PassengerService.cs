using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.GenericCrudManagers;
using ZaferTurizm.Business.Validators.Generics;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;

using ZaferTurizm.DTOs.PassengerAllDtos;

namespace ZaferTurizm.Business.Services.PassengerManagers
{
    public class PassengerService : CrudService<PassengerDto, PassengerSummary, Passenger>, IPassengerService
    {
        public PassengerService(TourDbContext context,GenericValidator<Passenger> generic) : base(context, generic)
        { }

        protected override Expression<Func<Passenger, PassengerDto>> DtoMapper => 
            entity => new PassengerDto()
            {
               
                IdentityNumber = entity.IdentityNumber,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Gender = entity.Gender,
                PhoneNumber = entity.PhoneNumber,
                Age = entity.Age
            };

        protected override Expression<Func<Passenger, PassengerSummary>> SummaryMapper => 
            entity => new PassengerSummary()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Gender = entity.Gender,
                PhoneNumber = entity.PhoneNumber,
                Age = entity.Age
            };

        

        protected override Passenger MapToEntity(PassengerDto entity)
        {
            return new Passenger()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Gender = entity.Gender,
                PhoneNumber = entity.PhoneNumber,
            };
        }
    }
}
