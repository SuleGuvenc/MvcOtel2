using Otel.Entitiy.Abstarct;
using Otel.Entity.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Entitiy.Concrete
{
    public class Hotel:BaseEntity
    {
        
        public string ?Adres { get; set; }
        public string ?PostaCode { get; set; }

      

        public string HotelName { get; set; }
       
        public string HotelCity { get; set; }
        public string HotelCountry { get; set; }

        public string? Gsm { get; set; }

       

        //Hotel ve Rezervasyon arasındaki bire çok ilişki
        public ICollection<Booking>? Bookings { get; set; }

        //Hotel ve Employee arasındaki bire çok ilişki
        public ICollection<AppUser>? Users { get; set; }
        public ICollection<Room>? Rooms { get; set; }
     






       
       
      


    }
}
