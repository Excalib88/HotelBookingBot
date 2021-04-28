namespace HotelBookingBot.Models
{
	public class HotelBooking
	{
		public (int, int) PriceFilter { get; set; }
		public string CityName { get; set; }
		public int Days { get; set; }
		public RoomType RoomType { get; set; }
		public HotelStarsType HotelStarsType { get; set; }
		
	}
}