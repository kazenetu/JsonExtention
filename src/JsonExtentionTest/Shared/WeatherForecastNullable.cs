using System;
using System.Collections.Generic;

namespace JsonExtentionTest.Shared;

/// <summary>
/// テスト用サンプルクラス
/// </summary>
public class WeatherForecastNullable
{
  public DateTimeOffset? Date { get; set; }
  public int? TemperatureCelsius { get; set; }
  public string? Summary { get; set; }
  public List<string> List { set; get; } = new List<string>();
}
