using JsonExtention;
using JsonExtention.Extentions;
using System;
using System.Collections.Generic;

namespace JsonExtentionTest.Shared;

/// <summary>
/// テスト用サンプルクラス
/// </summary>
public class WeatherForecast : IJsonClass
{
  public DateTimeOffset Date { get; set; }
  public int TemperatureCelsius { get; set; }
  public string Summary { get; set; } = string.Empty;
  public List<string> List { set; get; } = new List<string>();
}
