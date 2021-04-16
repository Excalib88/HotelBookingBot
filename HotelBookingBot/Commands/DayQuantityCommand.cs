using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HotelBookingBot.Commands
{
	public class DayQuantityCommand : Command
	{
		public override string Name { get; } = "/DayQuantity";
		private readonly ITelegramBotClient _telegramBotClient;
		private readonly List<string> _cities = new List<string>
		{
			"Алма-Ата", "Нур-Султан", "Шымкент", "Актобе", "Караганда", "Тараз", "Павлодар", "Атырау", "Костанай"
		};

		public DayQuantityCommand(ITelegramBotClient telegramBotClient)
		{
			_telegramBotClient = telegramBotClient;
		}

		public override async Task Execute(Update update, BotClient botClient)
		{
			await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery.From.Id, "Введите количество дней!");
		}

		public override bool Contains(Update update, Command state)
		{
			return state.Name.Contains("ChooseCity") && !string.IsNullOrWhiteSpace(update.CallbackQuery?.Data) &&
				_cities.Contains(update.CallbackQuery?.Data);
		}
	}
}