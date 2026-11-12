using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>Global tide station list; station IDs are not port codes.</summary>
public class GetGlobalTidesResponse
{
    /// <summary>Status.</summary>
    [JsonPropertyName("status")] public int? Status { get; set; }
    /// <summary>Msg.</summary>
    [JsonPropertyName("msg")] public string? Msg { get; set; }
    /// <summary>Total.</summary>
    [JsonPropertyName("total")] public int? Total { get; set; }
    /// <summary>Data.</summary>
    [JsonPropertyName("data")] public List<GlobalTideStationInfo>? Data { get; set; }
}

/// <summary>GlobalTideStationInfo.</summary>
public class GlobalTideStationInfo
{
    /// <summary>PortCode.</summary>
    [JsonPropertyName("port_code")] public int? PortCode { get; set; }
    /// <summary>PortCnname.</summary>
    [JsonPropertyName("port_cnname")] public string? PortCnname { get; set; }
    /// <summary>PortName.</summary>
    [JsonPropertyName("port_name")] public string? PortName { get; set; }
    /// <summary>PortCountryCnname.</summary>
    [JsonPropertyName("port_country_cnname")] public string? PortCountryCnname { get; set; }
    /// <summary>PortCountryName.</summary>
    [JsonPropertyName("port_country_name")] public string? PortCountryName { get; set; }
    /// <summary>Lat.</summary>
    [JsonPropertyName("lat")] public double? Lat { get; set; }
    /// <summary>Lng.</summary>
    [JsonPropertyName("lng")] public double? Lng { get; set; }
    /// <summary>PortTimeZone.</summary>
    [JsonPropertyName("port_time_zone")] public string? PortTimeZone { get; set; }
    // The PDF declares float and demonstrates a numeric string; accept both.
    /// <summary>Datumn.</summary>
    [JsonPropertyName("datumn")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public double? Datumn { get; set; }
}

/// <summary>GetGlobalTideDataResponse.</summary>
public class GetGlobalTideDataResponse : GetTideDataResponse { }

/// <summary>
/// Current, future and historical weather. Data retains the original object or
/// array, including observation_time (UTC), atmospheric_data and ocean_data.
/// </summary>
public class GlobalWeatherResponse
{
    /// <summary>Status.</summary>
    [JsonPropertyName("status")] public int? Status { get; set; }
    /// <summary>Msg.</summary>
    [JsonPropertyName("msg")] public string? Msg { get; set; }
    /// <summary>Data.</summary>
    [JsonPropertyName("data")] public JsonElement Data { get; set; }
}
