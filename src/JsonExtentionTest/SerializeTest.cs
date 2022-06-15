using System.Globalization;
using JsonExtention;
using JsonExtention.Extentions;
using JsonExtentionTest.Shared;
using System;
using Xunit;

namespace JsonExtentionTest;

public class SerializeTest : IDisposable
{
  /// <summary>
  /// Setup
  /// </summary>
  public SerializeTest()
  {
  }

  /// <summary>
  /// Teardown
  /// </summary>
  public void Dispose()
  {
  }

  [Fact]
  public void Normal()
  {
    // サンプルクラスインスタンス作成
    var weatherForecast = new WeatherForecast
    {
      Date = DateTimeOffset.Parse("2019-08-01 +9:00"),
      TemperatureCelsius = 25,
      Summary = "Hot"
    };
    weatherForecast.List.Add("A");
    weatherForecast.List.Add("B");

    // シリアライズ
    var json = weatherForecast.Serialize();

    Assert.Equal(@"{""Date"":""2019-08-01T00:00:00+09:00"",""TemperatureCelsius"":25,""Summary"":""Hot"",""List"":[""A"",""B""]}", json);
  }

  [Fact]
  public void NormalDefault()
  {
    // サンプルクラスインスタンス作成
    var weatherForecast = new WeatherForecast();

    // シリアライズ
    var json = weatherForecast.Serialize();

    Assert.Equal(@"{""Date"":""0001-01-01T00:00:00+00:00"",""TemperatureCelsius"":0,""Summary"":"""",""List"":[]}", json);
  }

  [Fact]
  public void NormalNull()
  {
    // サンプルクラスインスタンス作成
    var weatherForecast = new WeatherForecastNullable
    {
      Date = null,
      TemperatureCelsius = null,
      Summary = null
    };

    // シリアライズ
    var json = weatherForecast.Serialize();

    Assert.Equal(@"{""Date"":null,""TemperatureCelsius"":null,""Summary"":null,""List"":[]}", json);
  }

  [Fact]
  public void NormalNullSetValue()
  {
    // サンプルクラスインスタンス作成
    var weatherForecast = new WeatherForecastNullable
    {
      Date = DateTimeOffset.Parse("2019-08-01 +9:00"),
      TemperatureCelsius = 25,
      Summary = "Hot"
    };
    weatherForecast.List.Add("A");
    weatherForecast.List.Add("B");

    // シリアライズ
    var json = weatherForecast.Serialize();

    Assert.Equal(@"{""Date"":""2019-08-01T00:00:00+09:00"",""TemperatureCelsius"":25,""Summary"":""Hot"",""List"":[""A"",""B""]}", json);
  }
}