using AWolfBotLib.Colorize;

public abstract class Palitra
{
  public abstract RGB Primary { get; }
  public abstract RGB Process { get; }
  public abstract RGB Ok { get; }
  public abstract RGB Warn { get; }
  public abstract RGB Error { get; }
}
