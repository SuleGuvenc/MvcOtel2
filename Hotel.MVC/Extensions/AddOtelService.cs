using Otel.BL.Abstract;
using Otel.BL.Concrete;
using Otel.DAL.Repository.Abstract;
using Otel.DAL.Repository.Concrete;

namespace Hotel.MVC.Extensions
{
    public  static class AddOtelService
    {

       
        public static IServiceCollection AddOtelServices(this IServiceCollection services)
        {

             services.AddScoped<IRoomManager, RoomManager>();

            services.AddScoped<IRoomRepository,RoomRepository>();

            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();
            services.AddScoped<IHotelManager, HotelManager>();
            services.AddScoped<IHotelRepository, HotelRepository>();
           services.AddScoped<IBookingManager, BookingManager>();   

            services.AddScoped<IBookingRepository, BookingRepository>();
           


            return services;
        }

    }
}
