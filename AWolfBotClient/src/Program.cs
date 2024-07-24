using AWolfBot.Configs;
using AWolfBotLib.Services.LogService;
using AWolfBotLib.Services.ConfigService;
using AWolfBotLib.Services.IOService;
using AWolfBotLib.Options;
using AWolfBot.Core;
using System.Reflection;
using AWolfBotLib.Services.DatabaseService;

namespace AWolfBot;

internal class Program {
	public Program() {
		_ = FileManager.Load(new FileManagerOptions(new() {
			["logs"] = $"{FileManager.ExecutePath}Logs/",
		}));
		ConfigManager.LoadEnvConfig(new ApplicationConfig());
		_ = LogManager.Load(new(
			ApplicationConfig.Instance.LogsLimit,
			true,
			ApplicationConfig.Instance.LogWriteToFile,
			FileManager.GetFolderPath("logs")));
		_ = Database.Load(new DatabaseOptions($"Data Source={ApplicationConfig.Instance.DbPath}"));
	}

	private static async Task Main() =>
		await new Program().Startup();
	public static Assembly GetAssembly() => Assembly.GetAssembly(typeof(Program));
	private async Task Startup() {
		LogManager.Push("Application success starting...", LogType.Process);
		var bot = new Bot();
		await bot.Start();
		await Task.Delay(-1);
	}
}