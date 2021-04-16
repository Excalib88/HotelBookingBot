﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace HotelBookingBot.Controllers
{
	[Route("api/message")]
	public class MessageController : Controller
	{
		private readonly BotClient _botClient;

		public MessageController(BotClient botClient)
		{
			_botClient = botClient;
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

			foreach (var command in commands.Where(command => command.Contains(update, _botClient.CurrentState)))
			{
				await command.Execute(update);
				_botClient.CurrentState = command;

				break;
			}

			return Ok();
		}
	}
}