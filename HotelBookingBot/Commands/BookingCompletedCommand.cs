using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
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

		public override async Task Execute(Update update, BotClient botClient)
		{
			var chatId = update.CallbackQuery.From.Id;
			// await using (var context = new DataContext(botClient.Configuration.GetConnectionString("Db")))
			// {
			// 	await context.Bookings.AddAsync(botClient.Bookings[chatId]);
			// 	await context.SaveChangesAsync();
			// }

			await _telegramBotClient.SendTextMessageAsync(chatId, "Бронирование завершено!");
		}

		public override bool Contains(Update update, Command state)
		{
			return state.Name.Contains("Booking") && !string.IsNullOrWhiteSpace(update.CallbackQuery?.Data) && update.CallbackQuery.Data.Contains("yes");
		}
	}
}