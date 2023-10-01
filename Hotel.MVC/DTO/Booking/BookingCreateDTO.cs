namespace Hotel.MVC.DTO.Booking
{
    public class BookingCreateDTO
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public string UserId { get; set; }

        public  string AppUserId { get; set; }

        public string HotelId { get; set;}
        public string RoomId { get; set; }

    }
}
