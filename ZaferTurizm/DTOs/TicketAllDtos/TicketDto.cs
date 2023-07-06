using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs.TicketAllDtos
{
    public class TicketDto
    {
        public int BusTripId { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }

        public string PassengerFirstName { get; set; }
        public string PassengerLastName { get; set; }
        public string PassengerIdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }
}
