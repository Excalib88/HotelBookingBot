using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HotelBookingBot.Commands
{
	public class ChooseCityCommand : Command
    {
        public override string Name { get; } = @"/ChooseCity";
		private readonly ITelegramBotClient _telegramBotClient;

		public ChooseCityCommand(ITelegramBotClient telegramBotClient)
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
                        Text = "Алма-Ата",
                        CallbackData = "Алма-Ата"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "Нур-Султан",
                        CallbackData = "Нур-Султан"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "Шымкент",
                        CallbackData = "Шымкент"
                    }
                },
                new[] 
                {
                    new InlineKeyboardButton
                    {
                        Text = "Актобе",
                        CallbackData = "Актобе"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "Караганда",
                        CallbackData = "Караганда"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "Тараз",
                        CallbackData = "Тараз"
                    }
                }, 
                new[] 
                {
                    new InlineKeyboardButton
                    {
                        Text = "Павлодар",
                        CallbackData = "Павлодар"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "Атырау",
                        CallbackData = "Атырау"
                    },
                    new InlineKeyboardButton
                    {
                        Text = "Костанай",
                        CallbackData = "Костанай"
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

			await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery.From.Id, "Выберите город", replyMarkup: keyboard);
		}

		public override bool Contains(Update update, Command state) 
        {
            return state.Name.Contains("start") && !string.IsNullOrWhiteSpace(update.CallbackQuery?.Data) && update.CallbackQuery?.Data == "/choose";
		}
	}
}