using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace HotelBookingBot.Commands
{
	public abstract class Command
	{
		public abstract string Name { get; }

		public abstract Task Execute(Update update, BotClient botClient);

		public abstract bool Contains(Update update, Command state);
	}
}