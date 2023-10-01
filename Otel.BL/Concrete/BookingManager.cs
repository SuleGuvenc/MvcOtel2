using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Otel.BL.Abstract;
using Otel.DAL.EntityConfig.Abstract;
using Otel.DAL.Repository.Abstract;
using Otel.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BL.Concrete
{
    public class BookingManager : ManagerBase<Booking>, IBookingManager
    {


        //Task<bool> CheckInVarMi(TimeSpan checkin);
        //Task<bool> CheckOutVarMi(TimeSpan checkout);
        public Task<Booking> GetBokings(string id)
        {
            var bookings = base.repository.dbContext.Booking.Include(x => x.AppUserId == id);

            return bookings;
        }
    }
}
    

