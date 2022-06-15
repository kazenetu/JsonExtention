using System.Text.Json;

namespace JsonExtention.Extentions;

/// <summary>
/// JSON変換拡張関数
/// </summary>
public static class JsonExtention
{
  /// <summary>
  /// JSONシリアライズ
  /// </summary>
  /// <param name="src">JSON継承用インターフェイスのサブクラスインスタンス</param>
  /// <returns>JSON文字列</returns>
  static public string Serialize(this IJsonClass src)
  {
    var t = src.GetType();
    return JsonSerializer.Serialize(Convert.ChangeType(src, t));
  }

  /// <summary>
  /// JSONデシアライズ
  /// </summary>
  /// <param name="src">JSON文字列</param>
  /// <typeparam name="T">JSON継承用インターフェイスのサブクラス</typeparam>
  /// <returns>JSON継承用インターフェイスのサブクラスインスタンス</returns>
  static public T Deserialize<T>(this string src) where T : IJsonClass, new()
  {
    return JsonSerializer.Deserialize<T>(src) ?? new T();
  }
}
