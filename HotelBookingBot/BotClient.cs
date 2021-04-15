using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingBot.Commands;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace HotelBookingBot
{
	public class BotClient
	{
		public List<Command> Commands { get; }
		
		public BotClient(ITelegramBotClient telegramBotClient)
		{
			Commands = new List<Command>
			{
				new StartCommand(telegramBotClient)
			};
		}
	}
}