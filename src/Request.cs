using System.Text.Json.Serialization;

/// <summary>
/// 请求数据模型，用于船舶历史挂靠记录
/// </summary>
public class GetPortofCallByShipRequest { 
    /// <summary>
    /// 船舶MMSI编号，9位数字
    /// 必填
    /// </summary>
    public uint Mmsi { get; set; }

    /// <summary>
    /// IMO编号，根据IMO查询
    /// 非必填
    /// </summary>
    public uint? Imo { get; set; }

    /// <summary>
    /// 船舶英文名称
    /// 提示：如果不同船舶的名称相同，则同名船舶的靠港记录都将返回
    /// </summary>
    public string? ShipName { get; set; }

    /// <summary>
    /// 船舶呼号
    /// 匹配原则：空格可有可无，字母大小写忽略，但字母数字顺序和个数必须一致
    /// 提示：如果不同船舶呼号相同，则相同呼号船舶的靠港记录都将返回
    /// </summary>
    public string? CallSign { get; set; }

    /// <summary>
    /// 历史靠港记录开始时间，Unix时间戳（秒）
    /// 必填。start_time与end_time必须同时填写，查询[start_time,end_time]之间的结果
    /// </summary>
    public int StartTime { get; set; }

    /// <summary>
    /// 历史靠港记录结束时间，Unix时间戳（秒）
    /// 必填。start_time与end_time必须同时填写
    /// </summary>
    public int EndTime { get; set; }

    /// <summary>
    /// 选填，时间类型
    /// 1 - 当地时区，如果不存在，则使用零时区
    /// 2 - 北京时区（默认）
    /// 3 - 零时区（格林尼治平均时）
    /// </summary>
    public int? TimeZone { get; set; } = 2;
}
/// <summary>
/// 请求数据模型，用于船舶挂靠指定港口记录
/// </summary>
public class GetPortofCallByShipPortRequest
{
    /// <summary>
    /// 船舶MMSI编号，9位数字
    /// 必填
    /// </summary>
    [JsonPropertyName("mmsi")]
    public uint Mmsi { get; set; }

    /// <summary>
    /// IMO编号，根据IMO查询
    /// 非必填
    /// </summary>
    [JsonPropertyName("imo")]
    public uint? Imo { get; set; }

    /// <summary>
    /// 船舶英文名称
    /// 非必填
    /// </summary>
    [JsonPropertyName("ship_name")]
    public string? ShipName { get; set; }

    /// <summary>
    /// 船舶呼号
    /// 非必填
    /// </summary>
    [JsonPropertyName("call_sign")]
    public string? CallSign { get; set; }

    /// <summary>
    /// 港口标准五位码
    /// 必填
    /// </summary>
    [JsonPropertyName("port_code")]
    public string PortCode { get; set; } = null!;

    /// <summary>
    /// 历史靠港记录开始时间，Unix时间戳，单位秒
    /// 必填。start_time与end_time必须同时填写，表示查询[start_time，end_time]之间的结果，
    /// 最多一次只能查询1年（366天）的靠港记录
    /// </summary>
    [JsonPropertyName("start_time")]
    public int StartTime { get; set; }

    /// <summary>
    /// 历史靠港记录结束时间，Unix时间戳，单位秒，UTC时间
    /// 必填。start_time与end_time必须同时填写
    /// </summary>
    [JsonPropertyName("end_time")]
    public int EndTime { get; set; }

    /// <summary>
    /// 时间类型（选填）
    /// 1 表示当地时区，如果不存在则使用零时区；
    /// 2 表示北京时区（默认）；
    /// 3 表示零时区（格林尼治平均时）
    /// </summary>
    [JsonPropertyName("time_zone")]
    public int? TimeZone { get; set; } = 2;
}

/// <summary>
/// 请求数据模型，用于搜索船舶详细信息
/// </summary>
public class SearchShipParticularRequest
{
    /// <summary>
    /// 船舶编号，MMSI，9位数字
    /// 非必填
    /// </summary>
    [JsonPropertyName("mmsi")]
    public uint? Mmsi { get; set; }

    /// <summary>
    /// IMO编号
    /// 非必填
    /// </summary>
    [JsonPropertyName("imo")]
    public uint? Imo { get; set; }

    /// <summary>
    /// 船舶呼号，如果不同船舶的呼号相同，则相同呼号档案都将返回
    /// 非必填
    /// </summary>
    [JsonPropertyName("call_sign")]
    public string? CallSign { get; set; }

    /// <summary>
    /// 船舶英文名称，如果不同船舶名称相同，则同名船舶档案都将返回
    /// 非必填
    /// </summary>
    [JsonPropertyName("ship_name")]
    public string? ShipName { get; set; }
}

/// <summary>
/// 请求数据模型，用于船舶当前挂靠信息
/// </summary>
public class GetShipStatusRequest
{
    /// <summary>
    /// 船舶编号，MMSI，9位数字
    /// 非必填
    /// </summary>
    [JsonPropertyName("mmsi")]
    public uint? Mmsi { get; set; }

    /// <summary>
    /// IMO编号
    /// 非必填
    /// </summary>
    [JsonPropertyName("imo")]
    public uint? Imo { get; set; }

    /// <summary>
    /// 船舶呼号，如果不同船舶的呼号相同，则相同呼号档案都将返回
    /// 非必填
    /// </summary>
    [JsonPropertyName("call_sign")]
    public string? CallSign { get; set; }

    /// <summary>
    /// 船舶英文名称，如果不同船舶名称相同，则同名船舶档案都将返回
    /// 非必填
    /// </summary>
    [JsonPropertyName("ship_name")]
    public string? ShipName { get; set; }

    /// <summary>
    /// 船舶英文名称，如果不同船舶名称相同，则同名船舶档案都将返回
    /// 非必填
    /// </summary>
    [JsonPropertyName("time_zone")]
    public int? timeZone { get; set; }
}


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


/// <summary>
/// 区域数据模型
/// </summary>
public class AreaRequest
{
    /// <summary>
    /// 区域范围，经纬度逗号分隔，多个点减号分隔，
    /// 如：（lng,lat - lng,lat - lng,lat）。
    /// 经纬度数，多个经纬度坐标点必须按照顺时针或逆时针依次输入。
    /// 必填
    /// </summary>
    [JsonPropertyName("area_bounds")]
    public string? AreaBounds { get; set; }

    /// <summary>
    /// 区域名称，为您创建的区域起名，用来后续查询和区分
    /// 必填
    /// </summary>
    [JsonPropertyName("area_name")]
    public string? AreaName { get; set; }

    /// <summary>
    /// 推送url地址，触发监控条件时候向此url推送数据
    /// 必填
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// 筛选类型，区域筛选监控的类型：
    /// 1代表全部船舶，
    /// 2代表根据船舶类型和长度筛选匹配，
    /// 3代表船队船舶。
    /// 选择1的时候，不需要输入船舶类型、长度和船队id，输入也不会保存；
    /// 选择2的时候，船舶类型和船舶长度为必填；
    /// 选择3的时候，船队id为必填。
    /// 必填
    /// </summary>
    [JsonPropertyName("filter_type")]
    public int? FilterType { get; set; }

    /// <summary>
    /// 船舶类型，根据船舶类型筛选监控并推送，
    /// 多个类型使用英文逗号隔开，不填则全选。
    /// 船舶类型列表请参考开发文档附录。
    /// 非必填
    /// </summary>
    [JsonPropertyName("ship_type")]
    public string? ShipType { get; set; }

    /// <summary>
    /// 船舶长度，根据船舶长度筛选并推送，
    /// 多个长度使用英文逗号隔开，不填则全选。
    /// 1，代表0-40米；
    /// 2，代表40-80米；
    /// 3，代表80-160米；
    /// 4，代表160-240米；
    /// 5，代表240-320米；
    /// 6，代表320米以上。
    /// 非必填
    /// </summary>
    [JsonPropertyName("length")]
    public string? Length { get; set; }

    /// <summary>
    /// 船队id，如果只想监控某一只或一批船舶在区域的进出情况，
    /// 可以创建船队，输入fleet_id则会监控船队下所有船舶。
    /// 填入此参数则不会再使用ship_type监控船只，只监控船队船舶。
    /// 非必填
    /// </summary>
    [JsonPropertyName("fleet_id")]
    public string? FleetId { get; set; }
}
