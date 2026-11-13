using System.Text.Json;
using System.Text.Json.Serialization;

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
