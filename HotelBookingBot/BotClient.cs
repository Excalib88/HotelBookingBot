using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingBot.Commands;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace HotelBookingBot
{
	public class BotClient
	{
		public Command CurrentState { get; set; }
		public List<Command> Commands { get; }

		public BotClient(ITelegramBotClient telegramBotClient)
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
		}
	}
}