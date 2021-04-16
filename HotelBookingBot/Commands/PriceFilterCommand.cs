using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HotelBookingBot.Commands
{
	public class PriceFilterCommand : Command
	{
		public override string Name { get; } = @"/PriceFilter";
		private readonly ITelegramBotClient _telegramBotClient;
		private readonly List<string> _roomTypes = new List<string>
		{
			"sngl", "dbl", "twin", "trpl", "qdpl", "exb"
		};

		public PriceFilterCommand(ITelegramBotClient telegramBotClient)
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
						Text = "0-5000",
						CallbackData = "0-5000"
					},
					new InlineKeyboardButton
					{
						Text = "5000-10000",
						CallbackData = "5000-10000"
					},
					new InlineKeyboardButton
					{
						Text = "10000-20000",
						CallbackData = "10000-20000"
					}
				},
				new[]
				{
					new InlineKeyboardButton
					{
						Text = "20000-30000",
						CallbackData = "20000-30000"
					},
					new InlineKeyboardButton
					{
						Text = "30000-40000",
						CallbackData = "30000-40000"
					},
					new InlineKeyboardButton
					{
						Text = "40000-50000",
						CallbackData = "40000-50000"
					}
				},
				new[]
				{
					new InlineKeyboardButton
					{
						Text = "0-25000",
						CallbackData = "0-25000"
					},
					new InlineKeyboardButton
					{
						Text = "25000-50000",
						CallbackData = "25000-50000"
					},
					new InlineKeyboardButton
					{
						Text = "Все",
						CallbackData = "Все-000"
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

			await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery.From.Id, "Выберите диапозон цен!", replyMarkup: keyboard);
		}

		public override bool Contains(Update update, Command state)
		{
			return state.Name.Contains("RoomType") && !string.IsNullOrWhiteSpace(update.CallbackQuery?.Data) && _roomTypes.Contains(update.CallbackQuery.Data);
		}
	}
}