using HotelBookingBot.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingBot
{
	public class DataContext : DbContext
	{
		private readonly string _connectionString;

		// public DataContext(DbContextOptions options) : base(options)
		// {
		// }

		public DataContext(string connectionString = @"Data Source=D:/Projects/HotelBookingBot/booking.db")
		{
			_connectionString = connectionString;
		}
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(_connectionString);
		}

		public DbSet<Booking> Bookings { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<HotelRoom> HotelRooms { get; set; }
	}
}