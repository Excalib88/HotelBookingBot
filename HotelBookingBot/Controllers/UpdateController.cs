using System.Linq;
using System.Threading.Tasks;
using HotelBookingBot.Commands;
using HotelBookingBot.Entities;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HotelBookingBot.Controllers
{
	[Route("api/message")]
	public class MessageController : Controller
	{
		private readonly BotClient _botClient;
		private readonly ITelegramBotClient _telegramBotClient;

		public MessageController(BotClient botClient, ITelegramBotClient telegramBotClient)
		{
			_botClient = botClient;
			_telegramBotClient = telegramBotClient;
		}

		[HttpGet("health")]
		public IActionResult Get()
		{
			return Ok("Health");
		}
		//todo: доделать обновление Booking в командах и готово
		[HttpPost("update")]
		public async Task<IActionResult> Post([FromBody]Update update)
		{
			if (update == null) return Ok();

			var commands = _botClient.Commands;
			var chatId = update.Message?.Chat?.Id ?? update.CallbackQuery.From.Id;

			if (!_botClient.CurrentStates.TryGetValue(chatId, out _))
			{
				_botClient.CurrentStates.TryAdd(chatId, new StartCommand(_telegramBotClient));
			}

			if (!_botClient.Bookings.TryGetValue(chatId, out _))
			{
				_botClient.Bookings.TryAdd(chatId, new Booking());
			}

			foreach (var command in commands.Where(command => command.Contains(update, _botClient.CurrentStates[chatId])))
			{
				await command.Execute(update, _botClient);
				_botClient.CurrentStates[chatId] = command;
				break;
			}

			return Ok();
		}
	}
}