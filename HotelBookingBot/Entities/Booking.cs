namespace HotelBookingBot.Entities
{
	public class Booking
	{
		public long Id { get; set; }
		public Hotel Hotel { get; set; }
		public Client Client { get; set; }
	}
}