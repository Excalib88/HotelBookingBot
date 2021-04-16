using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HotelBookingBot.Commands
{
	public class HotelStarsCommand : Command
	{
		public override string Name { get; } = @"/HotelStars";
		private readonly ITelegramBotClient _telegramBotClient;

		public HotelStarsCommand(ITelegramBotClient telegramBotClient)
		{
			_telegramBotClient = telegramBotClient;
		}

		public override async Task Execute(Update update, BotClient botClient)
		{
			var keyboard = new InlineKeyboardMarkup(new[]
			{
				new[]
				{
					new InlineKeyboardButton
					{
						Text = "*",
						CallbackData = "*"
					},
					new InlineKeyboardButton
					{
						Text = "**",
						CallbackData = "**"
					},
					new InlineKeyboardButton
					{
						Text = "***",
						CallbackData = "***"
					},
					new InlineKeyboardButton
					{
						Text = "****",
						CallbackData = "****"
					},
					new InlineKeyboardButton
					{
						Text = "*****",
						CallbackData = "*****"
					}
				},
				new[]
				{
					new InlineKeyboardButton
					{
						Text = "Назад",
						CallbackData = "/back"
					}
				}
			});

			await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery.From.Id, "Сколько звезд должно быть у отеля?", replyMarkup:keyboard);
		}

		public override bool Contains(Update update, Command state)
		{
			return state.Name.Contains("PriceFilter") && !string.IsNullOrWhiteSpace(update.CallbackQuery?.Data) && update.CallbackQuery.Data.Contains("000");
		}
	}
}