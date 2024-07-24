using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus;
using AWolfBot.Middleware;

namespace AWolfBot.Commands;

[SlashCommandGroup("admin", "admin commands group.")]
internal class AdminSlashCommands : SlashCommands {
	private const string reasonText = "why you want to kick this user.📝";
	private const int reasonLength = 512;
	[SlashCommand("kick", "kicked member from guild.🦿")]
	[SlashCommandPermissions(Permissions.KickMembers)]
	public Task KickCommand(InteractionContext ctx,
		[Option("target", selectTargetText)] DiscordUser user,
		[MaximumLength(reasonLength)]
		[Option("reason", reasonText)] string reason) {
		Task.Run(async () => { await AdminMiddleware.Kick(ctx, user, reason); });
		return Task.CompletedTask;
	}
	[SlashCommand("ban", "banned member from guild.⚖️")]
	[SlashCommandPermissions(Permissions.BanMembers)]
	public Task BanCommand(InteractionContext ctx,
		[Option("target", selectTargetText)] DiscordUser user,
		[Option("days", "select count days.📅")]
		[Maximum(30)]
		[Minimum(1)] long days,
		[MaximumLength(reasonLength)]
		[Option("reason", reasonText)] string reason) {
		Task.Run(async () => { await AdminMiddleware.Ban(ctx, user, days, reason); });
		return Task.CompletedTask;
	}
	[SlashCommand("timeout", "timeout member from guild.😴")]
	[SlashCommandPermissions(Permissions.ModerateMembers)]
	public Task TimeoutCommand(InteractionContext ctx,
		[Option("target", selectTargetText)] DiscordUser user,
		[Choice("minute", 60)]
		[Choice("hour", 3600)]
		[Choice("day", 86400)]
		[Choice("week", 604800)]
		[Choice("month", 18144000)]
		[Option("time", "select time.🕘")] long time,
		[MaximumLength(reasonLength)]
		[Option("reason", reasonText)] string reason) {
		Task.Run(async () => { await AdminMiddleware.Timeout(ctx, user, time, reason); });
		return Task.CompletedTask;
	}
}