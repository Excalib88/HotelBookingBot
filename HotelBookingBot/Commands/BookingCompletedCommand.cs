using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HotelBookingBot.Commands
{
	public class BookingCompletedCommand : Command
	{
		public override string Name { get; } = @"/BookingCompleted";
		private readonly ITelegramBotClient _telegramBotClient;

		public BookingCompletedCommand(ITelegramBotClient telegramBotClient)
		{
			_telegramBotClient = telegramBotClient;
		}

		public override async Task Execute(Update update)
		{
			await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery.From.Id, "Бронирование завершено!");
		}

		public override bool Contains(Update update, Command state)
		{
			return state.Name.Contains("Booking") && !string.IsNullOrWhiteSpace(update.CallbackQuery?.Data) && update.CallbackQuery.Data.Contains("yes");
		}
	}
}