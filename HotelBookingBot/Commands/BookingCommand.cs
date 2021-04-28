using System.Linq;
using System.Threading.Tasks;
using HotelBookingBot.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HotelBookingBot.Commands
{
	public class BookingCommand : Command
	{
		public override string Name { get; } = @"/Booking";
		private readonly ITelegramBotClient _telegramBotClient;

		public BookingCommand(ITelegramBotClient telegramBotClient)
		{
			_telegramBotClient = telegramBotClient;
		}

		public override async Task Execute(Update update, BotClient botClient)
		{
			var keyboardSuccess = new InlineKeyboardMarkup(new[]
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
			var keyboardFail = new InlineKeyboardMarkup(new[]
			{
				new[]
				{
					new InlineKeyboardButton
					{
						Text = "Да",
						CallbackData = "/start"
					},
					new InlineKeyboardButton
					{
						Text = "Отмена",
						CallbackData = "/back"
					}
				}
			});
			var booking = botClient.Bookings[update.CallbackQuery.From.Id];
			await using var context = new DataContext(botClient.Configuration.GetConnectionString("Db"));
			var hotelrooms = context.HotelRooms.ToList();
			var hotelRooms = context.HotelRooms
				.Where(hotelRoom =>
					hotelRoom.Price >= booking.PriceFilter.Item1 &&
					hotelRoom.Price <= booking.PriceFilter.Item2 && 
					hotelRoom.RoomType == booking.RoomType)
				.Select(x=>x.HotelId)
				.ToList();
			
			var hotels = context.Hotels.Include(i => i.City)
				.Where(x => x.City.Name == booking.CityName && x.Stars == booking.HotelStarsType).ToList();

			Hotel hotel = null;

			foreach (var item in hotels)
			{
				if (hotelRooms.Contains(item.Id))
				{
					hotel = item;
					break;
				}
			}
			
			if (hotel == null)
			{
				await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery.From.Id, "Отель по вашим параметрам не найден! Попробовать снова?", replyMarkup: keyboardFail);
			}
			else
			{
				var hotelString = $"Отель: {hotel.Name}\n" +
				                  $"Адрес: {hotel.City} ${hotel.Address}";
				await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery.From.Id, $"Подтверждаете бронирование отеля?\n {hotelString}", replyMarkup: keyboardSuccess);
			}
		}

		public override bool Contains(Update update, Command state)
		{
			return state.Name.Contains("TotalFinder") && !string.IsNullOrWhiteSpace(update.CallbackQuery?.Data) && update.CallbackQuery.Data.Contains("yes");
		}
	}
}