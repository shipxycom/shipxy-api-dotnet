using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// 返回搜索
/// </summary>
public class SearchShipResult
{
    /// <summary>
    /// 关键字匹配结果的类型，匹配类型:
    /// 1：船名；
    /// 2：呼号；
    /// 3：mmsi；
    /// 5：imo。
    /// </summary>
    [JsonPropertyName("match_type")]
    public byte? MatchType { get; set; }

    /// <summary>
    /// 船舶唯一标识，数值与mmsi一致。
    /// </summary>
    [JsonPropertyName("mmsi")]
    public uint? Mmsi { get; set; }

    /// <summary>
    /// 船舶imo编号。
    /// </summary>
    [JsonPropertyName("imo")]
    public uint? Imo { get; set; }

    /// <summary>
    /// 船舶呼号。
    /// </summary>
    [JsonPropertyName("call_sign")]
    public string? CallSign { get; set; }

    /// <summary>
    /// 船舶英文名称。
    /// </summary>
    [JsonPropertyName("ship_name")]
    public string? ShipName { get; set; }

    /// <summary>
    /// 数据源，0代表岸基或船基AIS基站，1代表卫星基站。
    /// </summary>
    [JsonPropertyName("data_source")]
    public byte? DataSource { get; set; }

    /// <summary>
    /// AIS最后更新上传的时间，字符串格式。
    /// </summary>
    [JsonPropertyName("last_time")]
    public string? LastTime { get; set; }

    /// <summary>
    /// AIS最后更新时间的UTC时间戳（秒）。
    /// </summary>
    [JsonPropertyName("last_time_utc")]
    public int? LastTimeUtc { get; set; }
}

/// <summary>
/// 返回结构体
/// </summary>
public class SearchShipResponse
{
    /// <summary>
    /// 状态码。
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 返回信息。
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 总记录数。
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// 船舶结果列表。
    /// </summary>
    [JsonPropertyName("data")]
    public List<SearchShipResult>? Data { get; set; }
}


/// <summary>
/// 船舶位置信息
/// </summary>
public class ShipPosition
{
    /// <summary>
    /// 船舶mmsi编号，9 位数字
    /// </summary>
    [JsonPropertyName("mmsi")]
    public int? Mmsi { get; set; }

    /// <summary>
    /// imo编号
    /// </summary>
    [JsonPropertyName("imo")]
    public int? Imo { get; set; }

    /// <summary>
    /// 船舶呼号
    /// </summary>
    [JsonPropertyName("call_sign")]
    public string? CallSign { get; set; }

    /// <summary>
    /// 船舶英文名称
    /// </summary>
    [JsonPropertyName("ship_name")]
    public string? ShipName { get; set; }

    /// <summary>
    /// 船舶中文名称
    /// </summary>
    [JsonPropertyName("ship_cnname")]
    public string? ShipCnname { get; set; }

    /// <summary>
    /// 数据源，0代表岸基或船基AIS基站，1代表卫星基站
    /// </summary>
    [JsonPropertyName("data_source")]
    public int? DataSource { get; set; }

    /// <summary>
    /// 船舶类型编号
    /// </summary>
    [JsonPropertyName("ship_type")]
    public int? ShipType { get; set; }

    /// <summary>
    /// 船舶长度，米，取值范围(0-1022)
    /// </summary>
    [JsonPropertyName("length")]
    public float? Length { get; set; }

    /// <summary>
    /// 船舶宽度，米
    /// </summary>
    [JsonPropertyName("width")]
    public float? Width { get; set; }

    /// <summary>
    /// 左舷距，米
    /// </summary>
    [JsonPropertyName("left")]
    public float? Left { get; set; }

    /// <summary>
    /// 尾距，米
    /// </summary>
    [JsonPropertyName("trail")]
    public float? Trail { get; set; }

    /// <summary>
    /// 吃水深度，米
    /// </summary>
    [JsonPropertyName("draught")]
    public float? Draught { get; set; }

    /// <summary>
    /// 目的地，标准化后的目的地港口名称
    /// </summary>
    [JsonPropertyName("dest")]
    public string? Dest { get; set; }

    /// <summary>
    /// 目的地代码
    /// </summary>
    [JsonPropertyName("destcode")]
    public string? Destcode { get; set; }

    /// <summary>
    /// 预计到达时间："2025-03-03 10:51:40"，北京时间
    /// </summary>
    [JsonPropertyName("eta")]
    public string? Eta { get; set; }

    /// <summary>
    /// 预计到达时间，Unix时间戳
    /// </summary>
    [JsonPropertyName("eta_utc")]
    public int? EtaUtc { get; set; }

    /// <summary>
    /// 航行状态，0为有效，当为-1时代表无效数据
    /// </summary>
    [JsonPropertyName("navistat")]
    public int? Navistat { get; set; }

    /// <summary>
    /// 坐标纬度，WGS84坐标系
    /// </summary>
    [JsonPropertyName("lat")]
    public double? Lat { get; set; }

    /// <summary>
    /// 坐标经度，WGS84坐标系
    /// </summary>
    [JsonPropertyName("lng")]
    public double? Lng { get; set; }

    /// <summary>
    /// 船舶实时速度，单位：节，当为-1时代表无效数据
    /// </summary>
    [JsonPropertyName("sog")]
    public float? Sog { get; set; }

    /// <summary>
    /// 航迹向，单位：度，当为-1时代表无效数据
    /// </summary>
    [JsonPropertyName("cog")]
    public float? Cog { get; set; }

    /// <summary>
    /// 航首向，单位：度，当为511时代表无效数据
    /// </summary>
    [JsonPropertyName("hdg")]
    public float? Hdg { get; set; }

    /// <summary>
    /// 转向率，单位度/分钟
    /// </summary>
    [JsonPropertyName("rot")]
    public float? Rot { get; set; }

    /// <summary>
    /// 最后更新时间，AIS最后更新上传的时间，“2025-03-26 14:00:00”，北京时间
    /// </summary>
    [JsonPropertyName("last_time")]
    public string? LastTime { get; set; }

    /// <summary>
    /// 最后更新时间，Unix时间戳
    /// </summary>
    [JsonPropertyName("last_time_utc")]
    public int? LastTimeUtc { get; set; }
}


/// <summary>
/// 单船响应结构
/// </summary>
public class SingleShipResponse
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 结果消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 船舶数据
    /// </summary>
    [JsonPropertyName("data")]
    public ShipPosition? Data { get; set; }
}


/// <summary>
/// 多船响应结构
/// </summary>
public class ManyShipResponse
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 结果消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 船舶数据列表
    /// </summary>
    [JsonPropertyName("data")]
    public List<ShipPosition>? Data { get; set; }
}


/// <summary>
/// 舰队船舶响应结构
/// </summary>
public class FleetShipResponse
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 结果消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 舰队船舶数据列表
    /// </summary>
    [JsonPropertyName("data")]
    public List<ShipPosition>? Data { get; set; }
}


/// <summary>
/// 周边船舶响应结构
/// </summary>
public class SurRoundingShipResponse
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 结果消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 船舶数据列表
    /// </summary>
    [JsonPropertyName("data")]
    public List<ShipPosition>? Data { get; set; }
}


/// <summary>
/// 区域船舶数据
/// </summary>
public class AreaShipData
{
    /// <summary>
    /// 总数
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("scode")]
    public int? Scode { get; set; }

    /// <summary>
    /// 继续标记，因 "continue" 是C#关键字，属性名采用 Continue_
    /// </summary>
    [JsonPropertyName("continue")]
    public int? Continue_ { get; set; }

    /// <summary>
    /// 船舶列表
    /// </summary>
    [JsonPropertyName("ship_list")]
    public List<ShipPosition>? ShipList { get; set; }
}


/// <summary>
/// 区域船舶响应结构
/// </summary>
public class AreaShipResponse
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 结果消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 区域船舶数据
    /// </summary>
    [JsonPropertyName("data")]
    public AreaShipData? Data { get; set; }
}



/// <summary>
/// 船舶注册数据
/// </summary>
public class ShipRegistryData
{
    /// <summary>
    /// 船舶MMSI编号，允许为空
    /// </summary>
    [JsonPropertyName("mmsi")]
    public int? Mmsi { get; set; }

    /// <summary>
    /// 船讯网授权码，验证服务权限
    /// </summary>
    [JsonPropertyName("registry")]
    public string? Registry { get; set; }
}


/// <summary>
/// 船舶注册响应结构
/// </summary>
public class ShipRegistryResponse
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 结果消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 船舶注册数据
    /// </summary>
    [JsonPropertyName("data")]
    public ShipRegistryData? Data { get; set; }
}


/// <summary>
/// 发动机信息
/// </summary>
public class EngineInfo
{
    /// <summary>
    /// 设计方
    /// </summary>
    [JsonPropertyName("designer")]
    public string? Designer { get; set; }

    /// <summary>
    /// 功率，单位千瓦
    /// </summary>
    [JsonPropertyName("powerKW")]
    public int? PowerKW { get; set; }
}


/// <summary>
/// 船舶详细信息数据模型
/// </summary>
public class ShipParticularData
{
    /// <summary>船舶mmsi编号，9 位数字</summary>
    [JsonPropertyName("mmsi")]
    public long? Mmsi { get; set; }

    /// <summary>imo编号</summary>
    [JsonPropertyName("imo")]
    public long? Imo { get; set; }

    /// <summary>船舶呼号</summary>
    [JsonPropertyName("call_sign")]
    public string? CallSign { get; set; }

    /// <summary>船舶英文名称</summary>
    [JsonPropertyName("ship_name")]
    public string? ShipName { get; set; }

    /// <summary>船舶长度，米，取值范围(0-1022)</summary>
    [JsonPropertyName("length")]
    public float? Length { get; set; }

    /// <summary>船舶型宽，米，取值范围（0-1022）</summary>
    [JsonPropertyName("mould_width")]
    public float? MouldWidth { get; set; }

    /// <summary>船旗国国家代码</summary>
    [JsonPropertyName("flag_country_code")]
    public string? FlagCountryCode { get; set; }

    /// <summary>船旗国英文名称</summary>
    [JsonPropertyName("flag_country")]
    public string? FlagCountry { get; set; }

    /// <summary>船舶建造国家英文名称</summary>
    [JsonPropertyName("build_country")]
    public string? BuildCountry { get; set; }

    /// <summary>船舶建造日期（格式：yyyyMM 或 yyyy，如 201601）</summary>
    [JsonPropertyName("build_date")]
    public string? BuildDate { get; set; }

    /// <summary>船级社名称</summary>
    [JsonPropertyName("class_name")]
    public string? ClassName { get; set; }

    /// <summary>船东互保协会名称</summary>
    [JsonPropertyName("pandi_club")]
    public string? PandiClub { get; set; }

    /// <summary>船舶类型</summary>
    [JsonPropertyName("ship_type")]
    public string? ShipType { get; set; }

    /// <summary>船舶类型子分类</summary>
    [JsonPropertyName("ship_type_level5_subgroup")]
    public string? ShipTypeLevel5Subgroup { get; set; }

    /// <summary>船舶类型分组</summary>
    [JsonPropertyName("ship_type_group")]
    public string? ShipTypeGroup { get; set; }

    /// <summary>船舶状态</summary>
    [JsonPropertyName("ship_status")]
    public string? ShipStatus { get; set; }

    /// <summary>船舶总吨数</summary>
    [JsonPropertyName("gross_tonnage")]
    public float? GrossTonnage { get; set; }

    /// <summary>净注册吨数</summary>
    [JsonPropertyName("net_tonnage")]
    public float? NetTonnage { get; set; }

    /// <summary>载重，吨</summary>
    [JsonPropertyName("deadweight")]
    public float? Deadweight { get; set; }

    /// <summary>船舶装载集装箱数量</summary>
    [JsonPropertyName("teu")]
    public int? Teu { get; set; }

    /// <summary>最大速度，单位：节</summary>
    [JsonPropertyName("speed_max")]
    public float? SpeedMax { get; set; }

    /// <summary>经济航速，单位：节</summary>
    [JsonPropertyName("speed_service")]
    public float? SpeedService { get; set; }

    /// <summary>船舶吃水，单位：米</summary>
    [JsonPropertyName("draught")]
    public float? Draught { get; set; }

    /// <summary>船籍港</summary>
    [JsonPropertyName("port_of_registry")]
    public string? PortOfRegistry { get; set; }

    /// <summary>集团所有方代码</summary>
    [JsonPropertyName("group_code")]
    public string? GroupCode { get; set; }

    /// <summary>集团所有方名称</summary>
    [JsonPropertyName("group_company")]
    public string? GroupCompany { get; set; }

    /// <summary>集团所有方所属国家代码</summary>
    [JsonPropertyName("group_country_code")]
    public string? GroupCountryCode { get; set; }

    /// <summary>集团所有方所属国家</summary>
    [JsonPropertyName("group_country")]
    public string? GroupCountry { get; set; }

    /// <summary>船舶管理者代码</summary>
    [JsonPropertyName("shipmanager_code")]
    public string? ShipmanagerCode { get; set; }

    /// <summary>船舶管理者名称</summary>
    [JsonPropertyName("shipmanager_company")]
    public string? ShipmanagerCompany { get; set; }

    /// <summary>船舶管理者所属国家代码</summary>
    [JsonPropertyName("shipmanager_country_code")]
    public string? ShipmanagerCountryCode { get; set; }

    /// <summary>船舶管理者所属国家</summary>
    [JsonPropertyName("shipmanager_country")]
    public string? ShipmanagerCountry { get; set; }

    /// <summary>船舶经营者代码</summary>
    [JsonPropertyName("operator_code")]
    public string? OperatorCode { get; set; }

    /// <summary>船舶经营者名称</summary>
    [JsonPropertyName("operator_company")]
    public string? OperatorCompany { get; set; }

    /// <summary>船舶经营者所属国家代码</summary>
    [JsonPropertyName("operator_country_code")]
    public string? OperatorCountryCode { get; set; }

    /// <summary>船舶经营者所属国家</summary>
    [JsonPropertyName("operator_country")]
    public string? OperatorCountry { get; set; }

    /// <summary>DOC 公司代码</summary>
    [JsonPropertyName("doc_code")]
    public string? DocCode { get; set; }

    /// <summary>DOC 公司名称</summary>
    [JsonPropertyName("doc_company")]
    public string? DocCompany { get; set; }

    /// <summary>DOC 公司所属国家代码</summary>
    [JsonPropertyName("doc_country_code")]
    public string? DocCountryCode { get; set; }

    /// <summary>DOC 公司所属国家</summary>
    [JsonPropertyName("doc_country")]
    public string? DocCountry { get; set; }

    /// <summary>注册所有方代码</summary>
    [JsonPropertyName("registered_code")]
    public string? RegisteredCode { get; set; }

    /// <summary>注册所有方名称</summary>
    [JsonPropertyName("registered_owner")]
    public string? RegisteredOwner { get; set; }

    /// <summary>注册所有方所属国家代码</summary>
    [JsonPropertyName("registered_country_code")]
    public string? RegisteredCountryCode { get; set; }

    /// <summary>注册所有方所属国家</summary>
    [JsonPropertyName("registered_country")]
    public string? RegisteredCountry { get; set; }

    /// <summary>技术管理者代码</summary>
    [JsonPropertyName("technical_code")]
    public string? TechnicalCode { get; set; }

    /// <summary>技术管理者名称</summary>
    [JsonPropertyName("technical_manager")]
    public string? TechnicalManager { get; set; }

    /// <summary>技术管理者所属国家代码</summary>
    [JsonPropertyName("technical_country_code")]
    public string? TechnicalCountryCode { get; set; }

    /// <summary>技术管理者所属国家</summary>
    [JsonPropertyName("technical_country")]
    public string? TechnicalCountry { get; set; }

    /// <summary>船舶建造者代码</summary>
    [JsonPropertyName("builder_code")]
    public string? BuilderCode { get; set; }

    /// <summary>船舶建造者名称</summary>
    [JsonPropertyName("builder_company")]
    public string? BuilderCompany { get; set; }

    /// <summary>船舶建造者所属国家代码</summary>
    [JsonPropertyName("builder_country_code")]
    public string? BuilderCountryCode { get; set; }

    /// <summary>船舶建造者所属国家</summary>
    [JsonPropertyName("builder_country")]
    public string? BuilderCountry { get; set; }

    /// <summary>主机信息列表</summary>
    [JsonPropertyName("main_engine_list")]
    public List<EngineInfo>? MainEngineList { get; set; }

    /// <summary>辅机信息列表</summary>
    [JsonPropertyName("aux_engine_list")]
    public List<EngineInfo>? AuxEngineList { get; set; }

    /// <summary>档案数据更新时间，格式：2016-01-01 12:12:30</summary>
    [JsonPropertyName("update_time")]
    public string? UpdateTime { get; set; }
}

/// <summary>
/// 船舶详细信息响应结构
/// </summary>
public class SearchShipParticularResponse
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 结果
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    [JsonPropertyName("data")]
    public List<ShipParticularData>? Data { get; set; }
}

/// <summary>
/// 港口数据模型
/// </summary>
public class PortData
{
    /// <summary>
    /// 港口标准五位码
    /// </summary>
    [JsonPropertyName("port_code")]
    public string? PortCode { get; set; }

    /// <summary>
    /// 港口英文名称
    /// </summary>
    [JsonPropertyName("port_name")]
    public string? PortName { get; set; }

    /// <summary>
    /// 港口中文名称
    /// </summary>
    [JsonPropertyName("port_cnname")]
    public string? PortCnName { get; set; }

    /// <summary>
    /// 港口所在时区
    /// </summary>
    [JsonPropertyName("port_time_zone")]
    public string? PortTimeZone { get; set; }

    /// <summary>
    /// 港口所属国家英文名
    /// </summary>
    [JsonPropertyName("port_country_name")]
    public string? PortCountryName { get; set; }

    /// <summary>
    /// 港口所属国家中文名
    /// </summary>
    [JsonPropertyName("port_country_cnname")]
    public string? PortCountryCnName { get; set; }
}


/// <summary>
/// 港口数据模型
/// </summary>
public class SearchPortResponse
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 结果
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 总数
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    [JsonPropertyName("data")]
    public List<PortData>? Data { get; set; }
}


/// <summary>
/// 船舶泊位数据实体类
/// </summary>
public class BerthShipData
{
    /// <summary>
    /// 船舶mmsi编号，9 位数字
    /// </summary>
    [JsonPropertyName("mmsi")]
    public long? Mmsi { get; set; }

    /// <summary>
    /// imo编号
    /// </summary>
    [JsonPropertyName("imo")]
    public long? Imo { get; set; }

    /// <summary>
    /// 船舶呼号
    /// </summary>
    [JsonPropertyName("call_sign")]
    public string? CallSign { get; set; }

    /// <summary>
    /// 船舶英文名称
    /// </summary>
    [JsonPropertyName("ship_name")]
    public string? ShipName { get; set; }

    /// <summary>
    /// 船舶类型
    /// </summary>
    [JsonPropertyName("ship_type")]
    public int? ShipType { get; set; }

    /// <summary>
    /// 船舶长度，米，取值范围(0-1022)
    /// </summary>
    [JsonPropertyName("length")]
    public float? Length { get; set; }

    /// <summary>
    /// 船舶宽度，米
    /// </summary>
    [JsonPropertyName("width")]
    public float? Width { get; set; }

    /// <summary>
    /// 左舷距，米
    /// </summary>
    [JsonPropertyName("left")]
    public float? Left { get; set; }

    /// <summary>
    /// 尾距，米
    /// </summary>
    [JsonPropertyName("trail")]
    public float? Trail { get; set; }

    /// <summary>
    /// 吃水深度，米
    /// </summary>
    [JsonPropertyName("draught")]
    public float? Draught { get; set; }

    /// <summary>
    /// 到达时间，北京时间，格式如：2025-03-03 10:51:40
    /// </summary>
    [JsonPropertyName("arrival_time")]
    public string? ArrivalTime { get; set; }

    /// <summary>
    /// 到达时间，Unix时间戳，UTC时间
    /// </summary>
    [JsonPropertyName("arrival_time_utc")]
    public string? ArrivalTimeUtc { get; set; }

    /// <summary>
    /// 船舶当前在港口持续停留的时间，单位分钟
    /// </summary>
    [JsonPropertyName("stay_time")]
    public float? StayTime { get; set; }

    /// <summary>
    /// 航行状态
    /// 0表示状态正常，-1代表无效数据
    /// </summary>
    [JsonPropertyName("navistat")]
    public int? Navistat { get; set; }
}

/// <summary>
/// 获取泊位船舶响应结果实体类
/// </summary>
public class GetBerthShipsResponse
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 结果信息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 总数
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// 数据列表
    /// </summary>
    [JsonPropertyName("data")]
    public List<BerthShipData>? Data { get; set; }
}


/// <summary>
/// 锚地船舶数据实体类
/// </summary>
public class AnchorShipData
{
    /// <summary>
    /// 船舶mmsi编号，9 位数字
    /// </summary>
    [JsonPropertyName("mmsi")]
    public long? Mmsi { get; set; }

    /// <summary>
    /// imo编号
    /// </summary>
    [JsonPropertyName("imo")]
    public long? Imo { get; set; }

    /// <summary>
    /// 船舶呼号
    /// </summary>
    [JsonPropertyName("call_sign")]
    public string? CallSign { get; set; }

    /// <summary>
    /// 船舶英文名称
    /// </summary>
    [JsonPropertyName("ship_name")]
    public string? ShipName { get; set; }

    /// <summary>
    /// 船舶类型
    /// </summary>
    [JsonPropertyName("ship_type")]
    public int? ShipType { get; set; }

    /// <summary>
    /// 船舶长度，米，取值范围(0-1022)
    /// </summary>
    [JsonPropertyName("length")]
    public float? Length { get; set; }

    /// <summary>
    /// 船舶宽度，米
    /// </summary>
    [JsonPropertyName("width")]
    public float? Width { get; set; }

    /// <summary>
    /// 左舷距，米
    /// </summary>
    [JsonPropertyName("left")]
    public float? Left { get; set; }

    /// <summary>
    /// 尾距，米
    /// </summary>
    [JsonPropertyName("trail")]
    public float? Trail { get; set; }

    /// <summary>
    /// 吃水深度，米
    /// </summary>
    [JsonPropertyName("draught")]
    public float? Draught { get; set; }

    /// <summary>
    /// 到达时间，北京时间，格式如：2025-03-03 10:51:40
    /// </summary>
    [JsonPropertyName("arrival_time")]
    public string? ArrivalTime { get; set; }

    /// <summary>
    /// 到达时间，Unix时间戳，UTC时间
    /// </summary>
    [JsonPropertyName("arrival_time_utc")]
    public string? ArrivalTimeUtc { get; set; }

    /// <summary>
    /// 船舶当前在港口持续停留的时间，单位分钟
    /// </summary>
    [JsonPropertyName("stay_time")]
    public float? StayTime { get; set; }

    /// <summary>
    /// 航行状态，0表示正常，-1代表无效数据
    /// </summary>
    [JsonPropertyName("navistat")]
    public int? Navistat { get; set; }
}


/// <summary>
/// 获取锚地船舶响应结果实体类
/// </summary>
public class GetAnchorShipsResponse
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 结果信息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 总数
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// 数据列表
    /// </summary>
    [JsonPropertyName("data")]
    public List<AnchorShipData>? Data { get; set; }
}


/// <summary>
/// ETA（预计到达时间）船舶数据实体类
/// </summary>
public class ETAShipData
{
    /// <summary>
    /// MMSI 编号
    /// </summary>
    [JsonPropertyName("mmsi")]
    public int? Mmsi { get; set; }

    /// <summary>
    /// 船舶名称
    /// </summary>
    [JsonPropertyName("ship_name")]
    public string? ShipName { get; set; }

    /// <summary>
    /// IMO 编号
    /// </summary>
    [JsonPropertyName("imo")]
    public int? Imo { get; set; }

    /// <summary>
    /// 载重吨，DWT
    /// </summary>
    [JsonPropertyName("dwt")]
    public float? Dwt { get; set; }

    /// <summary>
    /// 船舶类型
    /// </summary>
    [JsonPropertyName("ship_type")]
    public string? ShipType { get; set; }

    /// <summary>
    /// 船舶长度，米
    /// </summary>
    [JsonPropertyName("length")]
    public float? Length { get; set; }

    /// <summary>
    /// 船舶宽度，米
    /// </summary>
    [JsonPropertyName("width")]
    public float? Width { get; set; }

    /// <summary>
    /// 吃水深度，米
    /// </summary>
    [JsonPropertyName("draught")]
    public float? Draught { get; set; }

    /// <summary>
    /// 报告港中文名
    /// </summary>
    [JsonPropertyName("preport_cnname")]
    public string? PReportCnName { get; set; }

    /// <summary>
    /// 上次时间，格式字符串
    /// </summary>
    [JsonPropertyName("last_time")]
    public string? LastTime { get; set; }

    /// <summary>
    /// 上次时间，Unix 时间戳（UTC）
    /// </summary>
    [JsonPropertyName("last_time_utc")]
    public int? LastTimeUtc { get; set; }

    /// <summary>
    /// 预计到达时间，格式字符串
    /// </summary>
    [JsonPropertyName("eta")]
    public string? Eta { get; set; }

    /// <summary>
    /// 预计到达时间，Unix 时间戳（UTC）
    /// </summary>
    [JsonPropertyName("eta_utc")]
    public int? EtaUtc { get; set; }

    /// <summary>
    /// 目的地
    /// </summary>
    [JsonPropertyName("dest")]
    public string? Dest { get; set; }

    /// <summary>
    /// 船旗国
    /// </summary>
    [JsonPropertyName("ship_flag")]
    public string? ShipFlag { get; set; }

    /// <summary>
    /// 船籍港
    /// </summary>
    [JsonPropertyName("registry")]
    public string? Registry { get; set; }
}


/// <summary>
/// 获取 ETA 船舶响应结果实体类
/// </summary>
public class GetETAShipsResponse
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 响应消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 总数量
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// 船舶数据列表
    /// </summary>
    [JsonPropertyName("data")]
    public List<ETAShipData>? Data { get; set; }
}


/// <summary>
/// 船舶轨迹点实体类
/// </summary>
public class ShipTrackPoint
{
    /// <summary>
    /// 数据来源
    /// 0代表岸基或船基AIS基站，1代表卫星基站
    /// </summary>
    [JsonPropertyName("data_source")]
    public byte? DataSource { get; set; }

    /// <summary>
    /// 点位更新时间，Unix时间戳
    /// </summary>
    [JsonPropertyName("utc")]
    public long? Utc { get; set; }

    /// <summary>
    /// 纬度，WGS84坐标系
    /// </summary>
    [JsonPropertyName("lat")]
    public double? Lat { get; set; }

    /// <summary>
    /// 经度，WGS84坐标系
    /// </summary>
    [JsonPropertyName("lng")]
    public double? Lng { get; set; }

    /// <summary>
    /// 船速，单位节
    /// 当返回值为-1时，代表无效数据
    /// </summary>
    [JsonPropertyName("sog")]
    public float? Sog { get; set; }

    /// <summary>
    /// 航迹向，单位度
    /// 当返回值为-1时，代表无效数据
    /// </summary>
    [JsonPropertyName("cog")]
    public float? Cog { get; set; }
}


/// <summary>
/// 获取船舶轨迹响应结果实体类
/// </summary>
public class GetShipTrackResponse
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 响应消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 船舶轨迹点数据列表
    /// </summary>
    [JsonPropertyName("data")]
    public List<ShipTrackPoint>? Data { get; set; }
}


/// <summary>
/// 靠泊船舶信息实体类
/// </summary>
public class ApproachShipInfo
{
    /// <summary>
    /// 船舶 MMSI 编号
    /// </summary>
    [JsonPropertyName("mmsi")]
    public int? Mmsi { get; set; }

    /// <summary>
    /// IMO 编号
    /// </summary>
    [JsonPropertyName("imo")]
    public int? Imo { get; set; }

    /// <summary>
    /// 船舶呼号
    /// </summary>
    [JsonPropertyName("call_sign")]
    public string? CallSign { get; set; }

    /// <summary>
    /// 船舶名称
    /// </summary>
    [JsonPropertyName("ship_name")]
    public string? ShipName { get; set; }

    /// <summary>
    /// 船舶类型
    /// </summary>
    [JsonPropertyName("ship_type")]
    public int? ShipType { get; set; }
}

/// <summary>
/// 靠泊事件信息实体类
/// </summary>
public class ApproachEventInfo
{
    /// <summary>
    /// 靠泊区编号
    /// </summary>
    [JsonPropertyName("approach_zone")]
    public int? ApproachZone { get; set; }

    /// <summary>
    /// 纬度
    /// </summary>
    [JsonPropertyName("lat")]
    public float? Lat { get; set; }

    /// <summary>
    /// 经度
    /// </summary>
    [JsonPropertyName("lng")]
    public float? Lng { get; set; }

    /// <summary>
    /// 港口代码
    /// </summary>
    [JsonPropertyName("port_code")]
    public string? PortCode { get; set; }

    /// <summary>
    /// 位置描述
    /// </summary>
    [JsonPropertyName("position")]
    public string? Position { get; set; }

    /// <summary>
    /// 靠泊时间（字符串格式）
    /// </summary>
    [JsonPropertyName("approach_time")]
    public string? ApproachTime { get; set; }

    /// <summary>
    /// 靠泊时间，Unix时间戳
    /// </summary>
    [JsonPropertyName("approach_time_utc")]
    public int? ApproachTimeUtc { get; set; }

    /// <summary>
    /// 离泊时间（字符串格式）
    /// </summary>
    [JsonPropertyName("separation_time")]
    public string? SeparationTime { get; set; }

    /// <summary>
    /// 离泊时间，Unix时间戳
    /// </summary>
    [JsonPropertyName("separation_time_utc")]
    public int? SeparationTimeUtc { get; set; }

    /// <summary>
    /// 靠泊时长，单位小时（或根据实际调整）
    /// </summary>
    [JsonPropertyName("duration")]
    public float? Duration { get; set; }

    /// <summary>
    /// 船速，单位节
    /// </summary>
    [JsonPropertyName("sog")]
    public float? Sog { get; set; }
}


/// <summary>
/// 靠泊数据项实体类
/// </summary>
public class ApproachDataItem
{
    /// <summary>
    /// 靠泊船舶信息
    /// </summary>
    [JsonPropertyName("approach_ship")]
    public ApproachShipInfo? ApproachShip { get; set; }

    /// <summary>
    /// 靠泊事件信息
    /// </summary>
    [JsonPropertyName("approach_event")]
    public ApproachEventInfo? ApproachEvent { get; set; }
}


/// <summary>
/// 船舶靠泊数据实体类
/// </summary>
public class ShipApproachData
{
    /// <summary>
    /// 船舶数据
    /// </summary>
    [JsonPropertyName("ship_data")]
    public ApproachShipInfo? ShipData { get; set; }

    /// <summary>
    /// 靠泊数据列表
    /// </summary>
    [JsonPropertyName("approach_data")]
    public List<ApproachDataItem>? ApproachData { get; set; }
}

/// <summary>
/// 查询船舶靠泊响应实体类
/// </summary>
public class SearchShipApproachResponse
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 结果消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    [JsonPropertyName("data")]
    public ShipApproachData? Data { get; set; }
}

/// <summary>
/// 靠泊港口数据实体类
/// </summary>
public class PortOfCallData
{
    /// <summary>
    /// 船名
    /// </summary>
    [JsonPropertyName("ship_name")]
    public string? ShipName { get; set; }

    /// <summary>
    /// 呼号
    /// </summary>
    [JsonPropertyName("call_sign")]
    public string? CallSign { get; set; }

    /// <summary>
    /// IMO号
    /// </summary>
    [JsonPropertyName("imo")]
    public int? Imo { get; set; }

    /// <summary>
    /// MMSI号
    /// </summary>
    [JsonPropertyName("mmsi")]
    public int? Mmsi { get; set; }

    /// <summary>
    /// 船舶类型，保持整数类型（如有字符串请调整为 string）
    /// </summary>
    [JsonPropertyName("ship_type")]
    public int? ShipType { get; set; }

    /// <summary>
    /// 港口中文名
    /// </summary>
    [JsonPropertyName("port_cnname")]
    public string? PortCnName { get; set; }

    /// <summary>
    /// 港口名
    /// </summary>
    [JsonPropertyName("port_name")]
    public string? PortName { get; set; }

    /// <summary>
    /// 港口时区
    /// </summary>
    [JsonPropertyName("port_time_zone")]
    public string? PortTimeZone { get; set; }

    /// <summary>
    /// 港口代码
    /// </summary>
    [JsonPropertyName("port_code")]
    public string? PortCode { get; set; }

    /// <summary>
    /// 码头名称
    /// </summary>
    [JsonPropertyName("terminal_name")]
    public string? TerminalName { get; set; }

    /// <summary>
    /// 泊位名称
    /// </summary>
    [JsonPropertyName("berth_name")]
    public string? BerthName { get; set; }

    /// <summary>
    /// 港口所在国家中文名
    /// </summary>
    [JsonPropertyName("port_country_cnname")]
    public string? PortCountryCnName { get; set; }

    /// <summary>
    /// 港口所在国家名
    /// </summary>
    [JsonPropertyName("port_country_name")]
    public string? PortCountryName { get; set; }

    /// <summary>
    /// 港口所在国家代码
    /// </summary>
    [JsonPropertyName("port_country_code")]
    public string? PortCountryCode { get; set; }

    /// <summary>
    /// 到达锚地
    /// </summary>
    [JsonPropertyName("arrival_anchorage")]
    public string? ArrivalAnchorage { get; set; }

    /// <summary>
    /// 实际到达时间（ATA）
    /// </summary>
    [JsonPropertyName("ata")]
    public string? Ata { get; set; }

    /// <summary>
    /// 靠泊时间（ATB）
    /// </summary>
    [JsonPropertyName("atb")]
    public string? Atb { get; set; }

    /// <summary>
    /// 实际离港时间（ATD）
    /// </summary>
    [JsonPropertyName("atd")]
    public string? Atd { get; set; }

    /// <summary>
    /// 到港吃水
    /// </summary>
    [JsonPropertyName("arrival_draught")]
    public double? ArrivalDraught { get; set; }

    /// <summary>
    /// 离港吃水
    /// </summary>
    [JsonPropertyName("departure_draught")]
    public double? DepartureDraught { get; set; }

    /// <summary>
    /// 停留时间（单位可根据实际调整）
    /// </summary>
    [JsonPropertyName("stay_time")]
    public double? StayTime { get; set; }

    /// <summary>
    /// 码头停留时间
    /// </summary>
    [JsonPropertyName("stay_terminal_time")]
    public double? StayTerminalTime { get; set; }
}


/// <summary>
/// 根据船舶获取靠泊港口响应实体类
/// </summary>
public class GetPortOfCallByShipResponse
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 消息提示
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 数据列表
    /// </summary>
    [JsonPropertyName("data")]
    public List<PortOfCallData>? Data { get; set; }
}
