using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>航速订阅条目。</summary>
public class SpeedSubscriptionData
{
    /// <summary>船舶MMSI。</summary>
    [JsonPropertyName("mmsi"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)] public uint? Mmsi { get; set; }
    /// <summary>最小-最大航速，单位节。</summary>
    [JsonPropertyName("speed_limit")] public string? SpeedLimit { get; set; }
    /// <summary>持续时间，单位分钟。</summary>
    [JsonPropertyName("speed_duration")] public double? SpeedDuration { get; set; }
}

/// <summary>独立航速订阅列表。</summary>
public class SearchSubShipAlertOfSpeedResponse : BaseResponse
{
    /// <summary>条目总数。</summary>
    [JsonPropertyName("total")] public int? Total { get; set; }
    /// <summary>订阅条目。</summary>
    [JsonPropertyName("data")] public List<SpeedSubscriptionData>? Data { get; set; }
}

/// <summary>兼容官方字符串字段及旧版数字JSON值。</summary>
public sealed class FlexibleApiStringConverter : JsonConverter<string>
{
    /// <summary>读取字符串或数字。</summary>
    public override string? Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null) return null;
        if (reader.TokenType == JsonTokenType.String) return reader.GetString();
        using var value = JsonDocument.ParseValue(ref reader);
        if (value.RootElement.ValueKind == JsonValueKind.Number) return value.RootElement.GetRawText();
        throw new JsonException("Expected string or number.");
    }
    /// <summary>按官方字符串字段格式输出。</summary>
    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) => writer.WriteStringValue(value);
}
