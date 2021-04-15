using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace HotelBookingBot
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddBot(this IServiceCollection services, IConfiguration configuration)
		{
			var botClient = new TelegramBotClient(configuration["Key"]);
			botClient.SetWebhookAsync(configuration["Url"]).Wait();

			services.AddSingleton<ITelegramBotClient>(botClient);
			services.AddSingleton<BotClient>();

			return services;
		}
	}
}