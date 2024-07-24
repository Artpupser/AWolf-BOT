using AWolfBotLib.Services.LogService;
using DSharpPlus;
using DSharpPlus.EventArgs;
using AWolfBot.Configs;
using Microsoft.Extensions.Logging;
using DSharpPlus.Entities;
using AWolfBot.Controllers;

namespace AWolfBot.Core;
internal class Bot : IBot {
	public static Bot Instance { get; private set; }
	public static DiscordConfiguration Config => new() {
		Token = ApplicationConfig.Instance.Token,
		TokenType = TokenType.Bot,
		MinimumLogLevel = LogLevel.Information,
		ShardCount = 1,
		Intents = DiscordIntents.AllUnprivileged,
		AlwaysCacheMembers = true,
		GatewayCompressionLevel = GatewayCompressionLevel.Stream,
		ShardId = 0
	};
	public DiscordClient Client { get; private set; }
	public BotStatus Status { get; private set; }
	public BotSlashCommands SlashCommands { get; private set; }
	public DiscordGuild Guild { get; private set; }
	public DiscordMember BotMemberInGuild { get; private set; }
	public Bot() {
		if(Instance is not null)
			throw new Exception("Singleton");
		Instance = this;
		Client = new(Config);
		Status = new();
		SlashCommands = new();
	}
	public async Task Start() {
		LogManager.Push("Bot starting...", LogType.Process);
		await ConnectHandlers();
		await Client.ConnectAsync();
		await ConnectControllers();
		LogManager.Push("Bot success started!", LogType.Ok);
	}
	public async Task<DiscordGuild> GetGuild(ulong id) => await Client.GetGuildAsync(id);
	public async Task<DiscordMember> GetMember(DiscordUser user) => await Guild.GetMemberAsync(user.Id);
	#region IBot
	public Task ConnectHandlers() {
		Client.Ready += ReadyHandler;
		Client.ClientErrored += ClientErroredHandler;
		return Task.CompletedTask;
	}
	public async Task ConnectControllers() {
		await Status.Connect();
		await SlashCommands.Connect();
	}
	#endregion
	private async Task ClientErroredHandler(DiscordClient sender, ClientErrorEventArgs args) {
		LogManager.Push($"{args.Exception}", LogType.Error);
		await Task.CompletedTask;
	}
	private async Task ReadyHandler(DiscordClient sender, ReadyEventArgs args) {
		LogManager.Push("Bot is ready!", LogType.Ok);
		Guild = await GetGuild(ApplicationConfig.Instance.GuildId);
		BotMemberInGuild = await Guild.GetMemberAsync(Client.CurrentUser.Id);
		await Task.CompletedTask;
	}

}