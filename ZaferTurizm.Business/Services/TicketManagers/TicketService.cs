using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.GenericCrudManagers;
using ZaferTurizm.Business.Validators.Generics;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;
using ZaferTurizm.DTOs.TicketAllDtos;

namespace ZaferTurizm.Business.Services.TicketManagers
{
    public class TicketService : CrudService<TicketDto, TicketSummary, Ticket>, ITicketService
    {
        public TicketService(TourDbContext context,GenericValidator<Ticket> generic) : base(context, generic)
        {
        }

        protected override Expression<Func<Ticket, TicketDto>> DtoMapper => 
            entity => new TicketDto()
            {
                BusTripId = entity.BusTripId,
                Price = entity.PaidAmount
                
            };

        protected override Expression<Func<Ticket, TicketSummary>> SummaryMapper => 
            entity => new TicketSummary()
            {
                Id=entity.Id,
                Date = entity.BusTrip.Date,
                BusTripPrice = entity.BusTrip.Price,
                VehicleMakeName = entity.BusTrip.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name,
                VehicleModelName= entity.BusTrip.Vehicle.VehicleDefinition.VehicleModel.Name,
                PlateNumber= entity.BusTrip.Vehicle.PlateNumber,
                PassengerFName = entity.Passenger.FirstName,
                PassengerLName = entity.Passenger.LastName,
                PassengerIdentityNumber = entity.Passenger.IdentityNumber,
                SeatNumber= entity.SeatNumber,
                PaidAmount= entity.PaidAmount,
                Age = entity.Passenger.Age,
                PhoneNumber = entity.Passenger.PhoneNumber,
                Route = entity.BusTrip.Route.DepartureCity.Name + " -> " + entity.BusTrip.Route.ArrivalCity.Name

            };

        

        protected override Ticket MapToEntity(TicketDto entity)
        {
            return new Ticket()
            {
                
                BusTripId=entity.BusTripId,
                SeatNumber = entity.SeatNumber,
                PaidAmount= entity.Price,
                

            };
        }
        public override CommandResult Create(TicketDto dto)
        {
            try
            {
                var passenger = _context.Passengers
                    .FirstOrDefault(passenger => passenger.IdentityNumber == dto.PassengerIdentityNumber);
                if (passenger == null)
                {
                    passenger = new Passenger()
                    {
                        FirstName = dto.PassengerFirstName,
                        LastName = dto.PassengerLastName,
                        IdentityNumber = dto.PassengerIdentityNumber,
                        Gender = Gender.None,
                        PhoneNumber= dto.PhoneNumber,
                        Age = dto.Age
                    };
                    _context.Passengers.Add(passenger);
                    _context.SaveChanges();
                }
                var ticket = new Ticket()
                {
                    BusTripId = dto.BusTripId,
                    SeatNumber = dto.SeatNumber,
                    PaidAmount = dto.Price,
                    PassengerId = passenger.Id
                };
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
                return CommandResult.Success("Bilet Başarıyla Kaydedildi");

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("Ticket Kaydedilemedi");
            } 
        }

    }
}
