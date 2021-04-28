using System.Collections.Generic;

namespace HotelBookingBot.Models
{
	public class HotelModel
	{
		public string Name { get; set; }
		public List<RoomType> Rooms { get; set; }
		public HotelStarsType Stars { get; set; }
	}
}