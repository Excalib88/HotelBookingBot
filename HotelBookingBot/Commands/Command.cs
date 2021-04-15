using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace HotelBookingBot.Commands
{
	public abstract class Command
	{
		public abstract string Name { get; }

		public abstract Task Execute(Message message);

		public abstract bool Contains(Message message);
	}
}