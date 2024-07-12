using AWolfBotLib.Colorize;

public class BasicPalitra : Palitra
{
  private RGB _primary = RGB.FromHEX("EFDECD");
  private RGB _process = RGB.FromHEX("0047AB");
  private RGB _ok = RGB.FromHEX("44944A");
  private RGB _warn = RGB.FromHEX("FF9900");
  private RGB _error = RGB.FromHEX("FF0033");

  public override RGB Primary { get => _primary; }
  public override RGB Process { get => _process; }
  public override RGB Ok { get => _ok; }
  public override RGB Warn { get => _warn; }
  public override RGB Error { get => _error; }
}