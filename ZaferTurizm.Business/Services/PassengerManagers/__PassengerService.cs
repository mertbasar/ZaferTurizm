using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs.PassengerAllDtos;

namespace ZaferTurizm.Business.Services.PassengerManagers
{
    public class __PassengerService : __IPassengerService
    {
        private readonly TourDbContext _context;

        public __PassengerService(TourDbContext context)
        {
            _context = context;
        }

        public CommandResult Create(PassengerDto model)
        {
            if (model == null)
            { return CommandResult.Failure("Oluşturulmaya çalışan model bulunmuyor"); }

            try
            {
                var pas = new Passenger()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Gender = model.Gender,
                    PhoneNumber = model.PhoneNumber,
                    IdentityNumber = model.IdentityNumber,
                };
                _context.Passengers.Add(pas);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("BusTrip ekleme işlemi başarısız.");
            }

        }





        public CommandResult Delete(PassengerDto model)
        {
            if (model == null) return CommandResult.Failure("Silinecek veri gelmedi bana");
            return Delete(model.Id);
        }

        public CommandResult Delete(int id)
        {
            var pas = new Passenger()
            {
                Id = id,
            };
            try
            {
                _context.Passengers.Remove(pas);
                _context.SaveChanges();
                return CommandResult.Success("Passenger Silme işlemi başarılı..");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("İşlem Başarısız canım");

            }
        }

        public IEnumerable<PassengerDto> GetAll()
        {
            try
            {
                return _context.Passengers.Select(model => new PassengerDto()
                {
                    Id= model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Gender = model.Gender,
                    PhoneNumber = model.PhoneNumber,
                    IdentityNumber = model.IdentityNumber,

                }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<PassengerDto>();
            }
        }

        public PassengerDto? GetById(int id)
        {
            try
            {
                return _context.Passengers.Select(model => new PassengerDto()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Gender = model.Gender,
                    PhoneNumber = model.PhoneNumber,
                    IdentityNumber = model.IdentityNumber,

                }).SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public CommandResult Update(PassengerDto model)
        {
            try
            {
                _context.Update(new PassengerDto()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Gender = model.Gender,
                    PhoneNumber = model.PhoneNumber,
                    IdentityNumber = model.IdentityNumber,
                });
                _context.SaveChanges();
                return CommandResult.Success("Yolcu güncelleme işlemi başarılı");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("İşlem başarısız..");
            }
        }
    }
}
