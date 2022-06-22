using JsonExtention.Extentions;

namespace Example;

/// <summary>
/// サンプルクラス
/// </summary>
public class WeatherForecast
{
  public DateTimeOffset Date { get; set; }
  public int TemperatureCelsius { get; set; }
  public string Summary { get; set; } = string.Empty;
  public List<string> List { set; get; } = new List<string>();
}


/// <summary>
/// エントリクラス
/// </summary>
class Program
{
  static void Main(string[] args)
  {
    // サンプルクラスインスタンス作成
    var weatherForecast = new WeatherForecast
    {
      Date = DateTime.Parse("2019-08-01"),
      TemperatureCelsius = 25,
      Summary = "Hot"
    };
    weatherForecast.List.Add("A");
    weatherForecast.List.Add("B");

    // シリアライズ
    var json = weatherForecast.Serialize();
    Console.WriteLine($"Serialize[{json}]");

    // シリアライズしたJSON文字列をデシアライズ
    var classInstance = json.Deserialize<WeatherForecast>();

    // デシアライズ結果を表示
    Console.WriteLine($"Deserialize!");
    Console.WriteLine($"Date[{classInstance.Date}]");
    Console.WriteLine($"TemperatureCelsius[{classInstance.TemperatureCelsius}]");
    Console.WriteLine($"Summary[{classInstance.Summary}]");
    foreach (var item in classInstance.List)
    {
      Console.WriteLine($"List[{item}]");
    }
  }
}