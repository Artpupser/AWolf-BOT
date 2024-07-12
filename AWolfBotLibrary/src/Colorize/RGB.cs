namespace AWolfBotLib.Colorize;

public struct RGB {
  private static Palitra _palitra = new BasicPalitra();
  public static Palitra Palitra { get => _palitra; private set => _palitra = value; }
  private byte _r, _g, _b;
  public byte R { readonly get => _r; set => _r = value; }
  public byte G { readonly get => _g; set => _g = value; }
  public byte B { readonly get => _b; set => _b = value; }
  public static void LoadPalitra(Palitra palitra) => Palitra = palitra;
  public RGB(byte r, byte g, byte b) {
    R = r;
    G = g;
    B = b;
  }
  public static RGB FromHEX(string hex) {
    byte to = 16;
    return new RGB(
      Convert.ToByte(hex[0..2], to),
      Convert.ToByte(hex[2..4], to),
      Convert.ToByte(hex[4..6], to));
  }
  public readonly string ToText() => $"\x1b[38;2;{R};{G};{B}m";
  public readonly string ToText(string content = "") => $"\x1b[38;2;{R};{G};{B}m{content}";
}