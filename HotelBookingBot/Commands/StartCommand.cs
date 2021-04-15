using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HotelBookingBot.Commands
{
	public class StartCommand : Command
	{
		public override string Name => @"/start";
		private readonly ITelegramBotClient _telegramBotClient;

		public StartCommand(ITelegramBotClient telegramBotClient)
		{
			_telegramBotClient = telegramBotClient;
		}
		
		public override bool Contains(Message message)
		{
			if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
				return false;

			return message.Text.Contains(this.Name);
		}

		public override async Task Execute(Message message)
		{
			var chatId = message.Chat.Id;
			await _telegramBotClient.SendTextMessageAsync(chatId, "Hello I'm ASP.NET Core Bot", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
		}
	}
}