using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs.PassengerAllDtos
{
    public class PassengerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public Gender Gender { get; set; } // Proje referansına ZaferTurizmi ekledik DTO katmanını.
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }
}
