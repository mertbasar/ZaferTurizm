using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs.TicketAllDtos
{
    public class TicketSummary
    {
        public int Id { get; set; }
        public string BusTripName { get { return    VehicleMakeName + " - " + VehicleModelName + " - " + PlateNumber; }  }
        public DateTime Date { get; set; }
        public decimal BusTripPrice { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public string PlateNumber { get; set; }
        public string PassengerFName { get; set; }
        public string PassengerLName { get; set; }
        public string PassengerIdentityNumber { get; set; }
        public string PassengerInfos { get { return PassengerIdentityNumber +" - "+ PassengerFName + " " + PassengerLName  ; } }
        public int SeatNumber { get; set; }
        public decimal PaidAmount { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Route { get; set; }
    }
}
