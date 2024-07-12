using AWolfBotLib.Colorize;
using AWolfBotLib.FastSystem;

namespace AWolfBot;

internal class Program {
  private static async Task Main(string[] args) =>
    await new Program().Startup();

  private async Task Startup() {

    await Task.Delay(-1);
  }
}