using System.Linq;
using System.Threading.Tasks;
using HotelBookingBot.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

		[HttpPost("update")]
		public async Task<IActionResult> Post([FromBody]Update update)
		{
			if (update == null) return Ok();

			var commands = _botClient.Commands;
			long chatId = update.Message?.Chat?.Id ?? update.CallbackQuery.From.Id;

			if (!_botClient.CurrentStates.TryGetValue(chatId, out Command result))
			{
				_botClient.CurrentStates.TryAdd(chatId, new StartCommand(_telegramBotClient));
			}

			foreach (var command in commands.Where(command => command.Contains(update, _botClient.CurrentStates[chatId])))
			{
				await command.Execute(update);

				break;
			}

			return Ok();
		}
	}
}