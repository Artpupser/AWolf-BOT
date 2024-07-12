namespace AWolfBotLib.FastSystem;
/// <summary>
/// Fast console -> fasting writing code!
/// </summary>
public class FastConsole
{
  /// <summary>
  /// GoL -> output content line -> Console.WriteLine();
  /// </summary>
  /// <param name="content">any content</param>
  public static void GoL(object content) => Console.Out.WriteLine(content);
  /// <summary>
  /// Go -> output content -> Console.Write();
  /// </summary>
  /// <param name="content">any content</param>
  public static void Go(object content) => Console.Out.Write(content);
  public static string Put(string description = "")
  {
    Go($"[{description}] > ");
  repeat:
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
      goto repeat;
    return input;
  }
}