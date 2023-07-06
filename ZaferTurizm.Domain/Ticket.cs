using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public int BusTripId { get; set; }
        public int PassengerId { get; set; }
        public int SeatNumber { get; set; }
        public decimal PaidAmount { get; set; }
        public BusTrip BusTrip { get; set; }
        public Passenger Passenger { get; set; }
    }
}
