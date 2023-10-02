using System.ComponentModel.DataAnnotations;

namespace Hotel.MVC.Areas.AdminArea.Models.DTOs
{
    public class HotelCreateDTO
    {


        public string? Adres { get; set; }
        public string? PostaCode { get; set; }


        [Required(AllowEmptyStrings =false,ErrorMessage ="Otel Adi Zorunludur")]
        public string HotelName { get; set; }

        public string HotelCity { get; set; }
        public string HotelCountry { get; set; }

        public string? Gsm { get; set; }
    }
}
