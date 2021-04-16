using HotelBookingBot.Models;

namespace HotelBookingBot.Entities
{
	public class HotelRoom
	{
		public long Id { get; set; }
		public RoomType RoomType { get; set; }
		public Hotel Hotel { get; set; }
		public long HotelId { get; set; }
	}
}