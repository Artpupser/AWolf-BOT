
using AWolfBot.Configs;
using AWolfBot.Core;
using DSharpPlus.Entities;

namespace AWolfBot.Controllers;

internal class BotStatus : IBotController {
	private static Bot Bot => Bot.Instance;
	public async Task Connect() {
		var guild = await Bot.GetGuild(ApplicationConfig.Instance.GuildId);
		var activity = new DiscordActivity() {
			Name = $"{guild.Name}",
			ActivityType = ActivityType.Streaming,
			StreamUrl = "https://www.youtube.com/watch?v=VVmKYdzHlYw",
		};
		await Bot.Client.UpdateStatusAsync(activity, UserStatus.Online, DateTimeOffset.Now);
	}
}