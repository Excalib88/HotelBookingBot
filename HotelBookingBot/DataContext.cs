using HotelBookingBot.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingBot
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Booking> Bookings { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<HotelRoom> HotelRooms { get; set; }
	}
}