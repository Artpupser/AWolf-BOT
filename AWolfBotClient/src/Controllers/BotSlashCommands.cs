
using System.Reflection;
using AWolfBot.Commands;
using AWolfBot.Configs;
using AWolfBot.Core;
using AWolfBotLib.Services.LogService;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.EventArgs;

namespace AWolfBot.Controllers;

internal class BotSlashCommands : IBotController, IHaveHandlers {
	public static SlashCommandsExtension SlashCommands { get; private set; }
	public async Task Connect() {
		LogManager.Push("Slash commands connection...", LogType.Process);
		await ConnectSlash();
		await ConnectHandlers();
		await ConnectCommands();
		LogManager.Push("Slash commands success connected!", LogType.Ok);
	}
	private async Task ConnectSlash() {
		SlashCommands = Bot.Instance.Client.UseSlashCommands();
		await Task.CompletedTask;
	}

	private async Task ConnectCommands() {
		SlashCommands.RegisterCommands<EmptySlashCommands>(ApplicationConfig.Instance.GuildId);
		//SlashCommands.RegisterCommands<GamesSlashCommands>();
		SlashCommands.RegisterCommands<OwnerSlashCommands>();
		SlashCommands.RegisterCommands<AdminSlashCommands>();
		await SlashCommands.RefreshCommands();
		await Task.CompletedTask;
	}

	public async Task ConnectHandlers() {
		SlashCommands.SlashCommandErrored += SlashCommandErroredHandler;
		SlashCommands.SlashCommandInvoked += SlashCommandInvokedHandler;
		await Task.CompletedTask;
	}
	private async Task SlashCommandInvokedHandler(SlashCommandsExtension sender, SlashCommandInvokedEventArgs args) {
		LogManager.Push($"{args.Context.Channel.Name} -> {args.Context.User.Username} -> {args.Context.CommandName}", LogType.Primary);
		await Task.CompletedTask;
	}
	private async Task SlashCommandErroredHandler(SlashCommandsExtension sender, SlashCommandErrorEventArgs args) {
		LogManager.Push(args.Exception, LogType.Error);
		await Task.CompletedTask;
	}
}