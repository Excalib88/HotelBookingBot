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

		public override async Task Execute(Update update, BotClient botClient)
		{
			var chatId = update.CallbackQuery.From.Id;
			var booking = botClient.Bookings[chatId];
			booking.HotelStarsType = update.CallbackQuery.Data.ToStars();
			var hotel = $"Город: {booking.CityName}\n" +
			            $"Количество дней: {booking.Days} д.\n" +
			            $"Тип номера: {booking.RoomType.ToEnumString()} \n" +
			            $"Ценовой диапозон: от {booking.PriceFilter.Item1} до {booking.PriceFilter.Item2}" +
			            $"Количество звезд: {booking.HotelStarsType.ToStarsString()}";
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
			await _telegramBotClient.SendTextMessageAsync(chatId, $"Подтверждаете правильность введённых данных? \n{hotel}", replyMarkup: keyboard);
		}

		public override bool Contains(Update update, Command state)
		{
			return state.Name.Contains("HotelStars") && !string.IsNullOrWhiteSpace(update.CallbackQuery?.Data) && update.CallbackQuery.Data.Contains("*");
		}
	}
}