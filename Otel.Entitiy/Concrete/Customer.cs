using Otel.Entitiy.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Entitiy.Concrete
{
  public class Customer:BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string ?Email { get; set; }
        public string ?Tcno { get; set; }
        public string ? Gsm { get; set; }
        
        public int? GuestAmount { get; set; }
        
        public string? Password { get; set; }
      
        public string? Address { get; set; }
       
      
        //Guest ve Booking arasındaki bire çok ilişki
        public ICollection<Booking>? Bookings { get; set; }



    }
}
