using AWolfBot.Middleware;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;

namespace AWolfBot.Commands;

[SlashCommandGroup("owner", "owner commands group")]
internal class OwnerSlashCommands : SlashCommands {
	[SlashRequireOwner]
	[SlashCommand("direct", "sending message to direct.📩")]
	public Task DirectCommand(
		InteractionContext ctx,
		[Option("user", selectTargetText)] DiscordUser target,
		[Option("message", "type message for target.")] string message) {
		Task.Run(async () => { await OwnerMiddleware.DirectLogic(ctx, target, message); });
		return Task.CompletedTask;
	}
	[SlashRequireOwner]
	[SlashCommand("embed", "sending embed to channel.📧")]
	public Task EmbedCommand(
		InteractionContext ctx,
		[Option("channel", "select channel.")] DiscordChannel channel,
		[Option("json", "embed json")] string json) {
		Task.Run(async () => { await OwnerMiddleware.EmbedLogic(ctx, channel, json); });
		return Task.CompletedTask;
	}
}