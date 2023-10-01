using Otel.Entitiy.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Entitiy.Concrete
{
    public class Employee:BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public  string ?Gsm { get; set; }
        public string ? Mail { get; set; }

       
     
        
  
        //Hotel ve Employee arasındaki bire çok ilişki
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }


    }
}
