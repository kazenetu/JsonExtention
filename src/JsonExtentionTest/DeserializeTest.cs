using JsonExtention;
using JsonExtention.Extentions;
using JsonExtentionTest.Shared;
using System;
using Xunit;

namespace JsonExtentionTest;

public class DeserializeTest : IDisposable
{
  /// <summary>
  /// Setup
  /// </summary>
  public DeserializeTest()
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
    // JSON文字列
    var json = @"{""Date"":""2019-08-01T00:00:00+09:00"",""TemperatureCelsius"":25,""Summary"":""Hot"",""List"":[""A"",""B""]}";

    // デシアライズ
    var classInstance = json.Deserialize<WeatherForecast>();

    // 各プロパティの確認
    Assert.Equal(DateTime.Parse("2019-08-01T00:00:00+09:00"), classInstance.Date);
    Assert.Equal(25, classInstance.TemperatureCelsius);
    Assert.Equal("Hot", classInstance.Summary);
    Assert.NotEmpty(classInstance.List);
    Assert.Equal(2, classInstance.List.Count);
    Assert.Equal("A", classInstance.List[0]);
    Assert.Equal("B", classInstance.List[1]);
  }

  [Fact]
  public void NormalDefault()
  {
    // JSON文字列
    var json = @"{""Date"":""0001-01-01T00:00:00+00:00"",""TemperatureCelsius"":0,""Summary"":"""",""List"":[]}";

    // デシアライズ
    var classInstance = json.Deserialize<WeatherForecast>();

    // 各プロパティの確認
    Assert.Equal(DateTime.Parse("0001-01-01T00:00:00+00:00"), classInstance.Date);
    Assert.Equal(0, classInstance.TemperatureCelsius);
    Assert.Equal(string.Empty, classInstance.Summary);
    Assert.Empty(classInstance.List);
  }

  [Fact]
  public void NormalNull()
  {
    // JSON文字列
    var json = @"{""Date"":null,""TemperatureCelsius"":null,""Summary"":null,""List"":[]}";

    // デシアライズ
    var classInstance = json.Deserialize<WeatherForecastNullable>();

    // 各プロパティの確認
    Assert.Null(classInstance.Date);
    Assert.Null(classInstance.TemperatureCelsius);
    Assert.Null(classInstance.Summary);
    Assert.Empty(classInstance.List);
  }

  [Fact]
  public void NormalNullSetValue()
  {
    // JSON文字列
    var json = @"{""Date"":""2019-08-01T00:00:00+09:00"",""TemperatureCelsius"":25,""Summary"":""Hot"",""List"":[""A"",""B""]}";

    // デシアライズ
    var classInstance = json.Deserialize<WeatherForecastNullable>();

    // 各プロパティの確認
    Assert.NotNull(classInstance.Date);
    Assert.Equal(DateTime.Parse("2019-08-01T00:00:00+09:00"), classInstance.Date);

    Assert.NotNull(classInstance.TemperatureCelsius);
    Assert.Equal(25, classInstance.TemperatureCelsius);

    Assert.NotNull(classInstance.Summary);
    Assert.Equal("Hot", classInstance.Summary);

    Assert.NotEmpty(classInstance.List);
    Assert.Equal(2, classInstance.List.Count);
    Assert.Equal("A", classInstance.List[0]);
    Assert.Equal("B", classInstance.List[1]);
  }

  [Fact]
  public void NormalNotExistsProperty_WeatherForecastNullable()
  {
    // JSON文字列
    var json = @"{""Property"":""ABC""}";

    // デシアライズ
    var classInstance = json.Deserialize<WeatherForecastNullable>();

    // 各プロパティの確認
    Assert.Null(classInstance.Date);
    Assert.Null(classInstance.TemperatureCelsius);
    Assert.Null(classInstance.Summary);
    Assert.Empty(classInstance.List);
  }

  [Fact]
  public void NotmalNotExistsProperty_WeatherForecast()
  {
    // JSON文字列
    var json = @"{""Property"":""ABC""}";

    // デシアライズ
    var classInstance = json.Deserialize<WeatherForecast>();

    // 各プロパティの確認
    Assert.Equal(DateTime.Parse("0001-01-01T00:00:00+00:00"), classInstance.Date);
    Assert.Equal(0, classInstance.TemperatureCelsius);
    Assert.Equal(string.Empty, classInstance.Summary);
    Assert.Empty(classInstance.List);
  }

  [Fact]
  public void ErrorJsonPropertyDateNG()
  {
    // JSON文字列
    var json = @"{""Date"":""ABC""";

    // デシアライズで例外発生確認
    var ex = Assert.ThrowsAny<Exception>(() => json.Deserialize<WeatherForecast>());
    Assert.IsType<System.Text.Json.JsonException>(ex);
  }

}