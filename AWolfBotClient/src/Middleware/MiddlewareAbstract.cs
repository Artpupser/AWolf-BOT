using AWolfBot.Core;
using AWolfBotLib.Discord;
using DSharpPlus.Entities;

namespace AWolfBot.Middleware;

internal abstract class MiddlewareAbstract {
	protected static Bot Bot => Bot.Instance;
	protected static bool CheckHierarchy(DiscordMember member, DiscordEmbedBuilder builder) {
		if(member.Hierarchy >= Bot.BotMemberInGuild.Hierarchy) {
			builder.WithText("The bot cannot manipulate participants higher in the role or their own kind.");
			return false;
		}
		return true;
	}
}