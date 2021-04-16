using System.Collections.Generic;
using HotelBookingBot.Models;

namespace HotelBookingBot.Entities
{
	public class Hotel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public City City { get; set;}
		public long CityId { get; set; }
		public string Address { get; set; }
		public HotelStarsType Stars { get; set; }
		public List<HotelRoom> HotelRooms { get; set; }
	}
}