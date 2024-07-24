using AWolfBot.Core;
using AWolfBotLib.Discord;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Newtonsoft.Json;

namespace AWolfBot.Middleware;

internal class OwnerMiddleware : MiddlewareAbstract {
	public static async Task DirectLogic(InteractionContext ctx, DiscordUser user, string message) {
		var member = await Bot.GetMember(user);
		var embed = user.GetEmbed();
		var dmChannel = await member.CreateDmChannelAsync();
		embed.WithText($"{message}");
		await ctx.CreateResponseAsync($"message success sended to {user.Username}", true);
		await dmChannel.SendMessageAsync(embed);
	}
	public static async Task EmbedLogic(InteractionContext ctx, DiscordChannel channel, string json) {
		try {
			var embed = JsonConvert.DeserializeObject<DiscordEmbedBuilder>(json);
			await channel.SendMessageAsync(embed);
		} catch(Exception) {
			await ctx.CreateResponseAsync("""
			Example: {"Title":null,"Description":null,"Url":null,"Color":{"Value":0,"R":0,"G":0,"B":0},"Timestamp":null,"ImageUrl":null,"Author":null,"Footer":null,"Thumbnail":null,"Fields":[]}
			""", true);
		}
	}
}