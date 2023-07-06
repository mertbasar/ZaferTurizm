using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs.VehicleDefinitionAllDtos
{
    public class VehicleDefinitionDto
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public bool HasToilet { get; set; }
        public int SeatCount { get; set; }
        public bool HasWifi { get; set; }
        public int VehicleModelId { get; set; }
        public int VehicleMakeId { get; set; }
    }
}
