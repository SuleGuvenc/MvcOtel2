using AutoMapper;
using Hotel.MVC.DTO;
using Otel.Entity.Authentication;

namespace Hotel.MVC.AutoMapper
{
    public class MvcOtel:Profile
    {
        public MvcOtel()
        {
            CreateMap<LoginDTO, AppUser>();
            CreateMap<UserCreateDTO, AppUser>();

            CreateMap<RegisterDTO, AppUser>();
        }
    }
}
