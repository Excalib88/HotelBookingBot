using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HotelBookingBot.Commands
{
	public class StartCommand : Command
	{
		public override string Name => @"/start";

		private readonly ITelegramBotClient _telegramBotClient;

		public StartCommand(ITelegramBotClient telegramBotClient)
		{
			_telegramBotClient = telegramBotClient;
		}
		
		public override bool Contains(Update update, Command state)
		{
			return !string.IsNullOrWhiteSpace(update.Message?.Text) && update.Message.Text.Contains(Name) || 
				update.CallbackQuery?.Data == "/back" || 
				update.Message?.Text == "/back";
		}

		public override async Task Execute(Update update)
		{
			var chatId = update.Message?.Chat?.Id;
			if (chatId == null)
			{
				chatId = update.CallbackQuery.From.Id;
			}

			var keyboard = new InlineKeyboardMarkup(new [] 
			{
				new [] 
				{
					new InlineKeyboardButton
					{
						Text = "Подобрать отель",
						CallbackData = "/choose"
					}
				}
			});

			await _telegramBotClient.SendTextMessageAsync(chatId, "Добро пожаловать в сервис бронирование отелей!", 
				replyMarkup: keyboard);
		}
	}
}