using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HotelBookingBot.Commands
{
	public class RoomTypeCommand : Command
	{
		public override string Name { get; } = @"/RoomType";
		private readonly ITelegramBotClient _telegramBotClient;

		public RoomTypeCommand(ITelegramBotClient telegramBotClient)
		{
			_telegramBotClient = telegramBotClient;
		}

		public override async Task Execute(Update update, BotClient botClient)
		{
			var chatId = update.Message.Chat.Id;
			int.TryParse(update.Message?.Text, out int result);
			botClient.Bookings[chatId].Days = result;

			var keyboard = new InlineKeyboardMarkup(new[]
			{
				new[]
				{
					new InlineKeyboardButton
					{
						Text = "SNGL(single)",
						CallbackData = "sngl"
					},
					new InlineKeyboardButton
					{
						Text = "DBL(double)",
						CallbackData = "dbl"
					},
					new InlineKeyboardButton
					{
						Text = "TWIN",
						CallbackData = "twin"
					}
				},
				new[]
				{
					new InlineKeyboardButton
					{
						Text = "TRPL(Triple)",
						CallbackData = "trpl"
					},
					new InlineKeyboardButton
					{
						Text = "QDPL(Quadriple)",
						CallbackData = "qdpl"
					},
					new InlineKeyboardButton
					{
						Text = "ExB(Extra Bed)",
						CallbackData = "exb"
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

			await _telegramBotClient.SendTextMessageAsync(chatId, "Выберите тип номера", replyMarkup: keyboard);
		}

		public override bool Contains(Update update, Command state)
		{
			return int.TryParse(update.Message?.Text, out _) && state.Name.Contains("DayQuantity");
		}
	}
}