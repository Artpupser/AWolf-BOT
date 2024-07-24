using AWolfBot.Core;
using AWolfBotLib.Discord;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace AWolfBot.Middleware;

internal class AdminMiddleware : MiddlewareAbstract {
	public static async Task Kick(InteractionContext ctx, DiscordUser user, string reason) => await GetEmbedAndMember(ctx, user, async (embed, member) => {
		await embed.WithText($"{user.Username} process kicking.").Send(ctx);
		await member.RemoveAsync(reason);
	});
	public static async Task Ban(InteractionContext ctx, DiscordUser user, long days, string reason) => await GetEmbedAndMember(ctx, user, async (embed, member) => {
		await embed.WithText($"{user.Username} process banning.").Send(ctx);
		await member.BanAsync((int)days, reason);
	});

	public static async Task Timeout(InteractionContext ctx, DiscordUser user, long time, string reason) => await GetEmbedAndMember(ctx, user, async (embed, member) => {
		await embed.WithText($"{user.Username} process timeout.").Send(ctx);
		await member.TimeoutAsync(DateTimeOffset.Now.AddSeconds(time), reason);
	});
	private static async Task GetEmbedAndMember(InteractionContext ctx, DiscordUser user, Action<DiscordEmbedBuilder, DiscordMember> action) {
		var embed = ctx.User.GetEmbed();
		var member = await Bot.GetMember(user);
		if(CheckHierarchy(member, embed))
			action(embed, member);
	}
}