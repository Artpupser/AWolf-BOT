using AWolfBotLib;
using AWolfBotLib.Services.ConfigService;

namespace AWolfBot.Configs;

internal class ApplicationConfig : IEnvConfig<ApplicationConfig>, ISingleConfig<ApplicationConfig> {
	public static ApplicationConfig Instance { get; set; }
	#region Bot
	[EnvKey("token")]
	public string Token { get; set; }
	[EnvKey("public_key")]
	public string PublicKey { get; set; }
	[EnvKey("app_id")]
	public ulong AppId { get; set; }
	[EnvKey("guild_id")]
	public ulong GuildId { get; set; }
	#endregion
	#region Logs
	[EnvKey("log_limit")]
	public byte LogsLimit { get; set; }
	[EnvKey("log_writeToFile")]
	public bool LogWriteToFile { get; set; }
	#endregion
	#region DB
	[EnvKey("db_path")]
	public string DbPath { get; set; }
	#endregion
}