using System.Text.Json.Serialization;

/// <summary>
/// 船队请求数据，用于创建或更新船队
/// </summary>
public class FleetRequest
{
    /// <summary>
    /// 船队名称
    /// 为您创建的船队起名，用于后续查询和区分。
    /// </summary>
    [JsonPropertyName("fleet_name")]
    public string? FleetName { get; set; }
    /// <summary>
    /// 船舶清单
    /// 添加船队下管理的船舶信息，输入多个MMSI编号，用英文逗号隔开。
    /// </summary>
    [JsonPropertyName("mmsis")]
    public string? Mmsis { get; set; }

    /// <summary>
    /// 监控内容
    /// 选择船队进行监控的内容，取值：
    /// 1 - 船队船舶查询
    /// 2 - 船位实时推送
    /// 3 - 船舶到离事件推送
    /// 4 - 动态ETA推送
    /// 5 - AIS异常事件推送
    /// 6 - 区域监控推送
    /// 7 - 船舶搭靠事件推送
    /// 多选时用英文逗号隔开。
    /// </summary>
    [JsonPropertyName("monitor")]
    public string? Monitor { get; set; }
}
