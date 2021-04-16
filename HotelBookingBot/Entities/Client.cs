using System;

namespace HotelBookingBot.Entities
{
	public class Client
	{
		public long Id { get; set; }
		public string Fio { get; set; }
		public DateTime BirthDate { get; set; }
		public string PassportSeries { get; set; }
		public string PassportNumber { get; set; }
	}
}