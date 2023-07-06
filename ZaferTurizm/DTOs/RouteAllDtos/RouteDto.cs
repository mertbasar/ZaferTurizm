using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs.RouteAllDtos
{
    public class RouteDto
    {
        public int Id { get; set; }
        public int DepartuteId { get; set; }
        public int ArrivalId { get; set; }
    }
}
