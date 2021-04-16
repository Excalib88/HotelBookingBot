using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HotelBookingBot.Commands
{
	public class TotalFinderCommand : Command
	{
		public override string Name { get; } = @"/TotalFinder";
		private readonly ITelegramBotClient _telegramBotClient;

		public TotalFinderCommand(ITelegramBotClient telegramBotClient)
		{
			_telegramBotClient = telegramBotClient;
		}

		public override async Task Execute(Update update)
		{
			var keyboard = new InlineKeyboardMarkup(new[]
			{
				new[]
				{
					new InlineKeyboardButton
					{
						Text = "Да",
						CallbackData = "yes"
					},
					new InlineKeyboardButton
					{
						Text = "Отмена",
						CallbackData = "/back"
					}
				}
			});

			await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery.From.Id, "Подтверждаете правильность введённых данных?", replyMarkup: keyboard);
		}

		public override bool Contains(Update update, Command state)
		{
			return state.Name.Contains("HotelStars") && !string.IsNullOrWhiteSpace(update.CallbackQuery?.Data) && update.CallbackQuery.Data.Contains("*");
		}
	}
}