using System;

namespace AWolfBotLib.Colorize;

public static class RGBStatic {
  public static string ToColor(this string content, RGB color) => $"{color.ToText()}{content}";
}
