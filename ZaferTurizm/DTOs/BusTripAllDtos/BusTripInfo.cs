using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs.BusTripAllDtos
{
    public class BusTripInfo
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public string RouteName
        {
            get
            {
                return DepartureName + "->" + ArrivalName;
            }
        }
        public string DepartureName { get; set; }
        public string ArrivalName { get; set; }

        public string VehicleName
        {
            get
            {
                return VehicleMakeName + " " + VehicleModelName + " " + PlateNumber;
            }
        }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public string PlateNumber { get; set; }
        public int SeatCount { get; set; }

        public IEnumerable<int> SoldSeatNumbers { get; set; }
    }
}
