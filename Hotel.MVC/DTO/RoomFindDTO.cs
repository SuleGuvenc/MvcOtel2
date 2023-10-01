namespace Hotel.MVC.DTO
{
	public class RoomFindDTO
	{
        public DateTime GirisTrh { get; set; }
        public DateTime? CikisTrh { get; set; }
        public byte?  YetiskinSayisi { get; set; }
        public byte? CocukSayisi { get; set; }

        public string?   AppUserId { get; set; }
    }
}
