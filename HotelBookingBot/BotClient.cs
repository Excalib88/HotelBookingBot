using System.Collections.Generic;
using HotelBookingBot.Commands;
using HotelBookingBot.Entities;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace HotelBookingBot
{
	public class BotClient
	{
		public List<Command> Commands { get; }
		public Dictionary<long, Command> CurrentStates { get; set; } = new Dictionary<long, Command>();
		public Dictionary<long, Booking> Bookings { get; set; } = new Dictionary<long, Booking>();
		public IConfiguration Configuration { get; set; }
		
		public BotClient(ITelegramBotClient telegramBotClient, IConfiguration configuration)
		{
			Commands = new List<Command>
			{
				new StartCommand(telegramBotClient),
				new ChooseCityCommand(telegramBotClient),
				new DayQuantityCommand(telegramBotClient),
				new RoomTypeCommand(telegramBotClient),
				new PriceFilterCommand(telegramBotClient),
				new HotelStarsCommand(telegramBotClient),
				new TotalFinderCommand(telegramBotClient),
				new BookingCommand(telegramBotClient),
				new BookingCompletedCommand(telegramBotClient)
			};

			Configuration = configuration;
		}
	}
}