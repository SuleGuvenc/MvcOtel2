using Otel.Entitiy.Abstarct;
using Otel.Entity.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Entitiy.Concrete
{
   public class Booking:BaseEntity
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        //Rezervasyon ve Guest arasındaki bire çok ilişki
        public string? AppUserId { get; set; }
        public AppUser? User { get; set; }

        //Rezervasyon ve Room arasındaki bire bir ilişki
        public int? RoomId { get; set; }
        public Room? Room { get; set; }

        //Rezervasyon ve Hotel arasındaki bire çok ilişki
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        //Toplam fiyat 
        // public int ToplamFiyat {get;set;}
    }
}
