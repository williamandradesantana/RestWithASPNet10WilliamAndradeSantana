using System.Globalization;

namespace RestWithASPNet10WilliamAndradeSantana.Utils;

public class MathUtils
{
    public bool TryParseDecimal(string value, out decimal result) =>
      decimal.TryParse(
      value,
      NumberStyles.Any,
      NumberFormatInfo.InvariantInfo,
      out result);
}
