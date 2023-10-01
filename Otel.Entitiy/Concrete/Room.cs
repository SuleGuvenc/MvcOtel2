using Otel.Entitiy.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Entitiy.Concrete
{
   public class Room:BaseEntity
    {
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
     
        public string? Price { get; set; }
        public string? Description { get; set; }
        //Hotel ve Room arasındaki bire çok ilişki
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public bool? IsEmpty { get; set; } = true;
        //Room ve Booking arasındaki bire bir ilişki
        public ICollection<Booking>? Bookings { get; set; }
    }
}
