using System.Collections.Generic;
using HotelBookingBot.Commands;
using Telegram.Bot;

namespace HotelBookingBot
{
	public class BotClient
	{
		public Dictionary<long, Command> CurrentStates { get; set; }
		public List<Command> Commands { get; }

		public BotClient(ITelegramBotClient telegramBotClient)
		{
			var startCommand = new StartCommand(telegramBotClient);
			CurrentStates = new Dictionary<long, Command>();

			Commands = new List<Command>
			{
				startCommand,
				new ChooseCityCommand(telegramBotClient),
				new DayQuantityCommand(telegramBotClient),
				new RoomTypeCommand(telegramBotClient),
				new PriceFilterCommand(telegramBotClient),
				new HotelStarsCommand(telegramBotClient),
				new TotalFinderCommand(telegramBotClient),
				new BookingCommand(telegramBotClient),
				new BookingCompletedCommand(telegramBotClient)
			};
		}
	}
}