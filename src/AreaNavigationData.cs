using System.Text.Json.Serialization;

/// <summary>区域查询返回的航标信息。</summary>
public class AtonData
{
    /// <summary>mmsi.</summary>
    [JsonPropertyName("mmsi")] public uint? Mmsi { get; set; }
    /// <summary>aton_name.</summary>
    [JsonPropertyName("aton_name")] public string? AtonName { get; set; }
    /// <summary>aton_type.</summary>
    [JsonPropertyName("aton_type")] public int? AtonType { get; set; }
    /// <summary>length.</summary>
    [JsonPropertyName("length")] public double? Length { get; set; }
    /// <summary>width.</summary>
    [JsonPropertyName("width")] public double? Width { get; set; }
    /// <summary>left.</summary>
    [JsonPropertyName("left")] public double? Left { get; set; }
    /// <summary>trail.</summary>
    [JsonPropertyName("trail")] public double? Trail { get; set; }
    /// <summary>is_virtual.</summary>
    [JsonPropertyName("is_virtual")] public int? IsVirtual { get; set; }
    /// <summary>lat.</summary>
    [JsonPropertyName("lat")] public double? Lat { get; set; }
    /// <summary>lng.</summary>
    [JsonPropertyName("lng")] public double? Lng { get; set; }
    /// <summary>last_time.</summary>
    [JsonPropertyName("last_time")] public string? LastTime { get; set; }
    /// <summary>last_time_utc.</summary>
    [JsonPropertyName("last_time_utc")] public long? LastTimeUtc { get; set; }
}

/// <summary>区域查询返回的网位仪信息。</summary>
public class NetBuoyData
{
    /// <summary>mmsi.</summary>
    [JsonPropertyName("mmsi")] public uint? Mmsi { get; set; }
    /// <summary>length.</summary>
    [JsonPropertyName("length")] public double? Length { get; set; }
    /// <summary>width.</summary>
    [JsonPropertyName("width")] public double? Width { get; set; }
    /// <summary>lat.</summary>
    [JsonPropertyName("lat")] public double? Lat { get; set; }
    /// <summary>lng.</summary>
    [JsonPropertyName("lng")] public double? Lng { get; set; }
    /// <summary>last_time.</summary>
    [JsonPropertyName("last_time")] public string? LastTime { get; set; }
    /// <summary>last_time_utc.</summary>
    [JsonPropertyName("last_time_utc")] public long? LastTimeUtc { get; set; }
}

