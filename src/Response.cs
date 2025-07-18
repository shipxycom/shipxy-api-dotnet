using System.Collections.Generic;
using System.Text.Json.Serialization;


/// <summary>
/// 基础响应类
/// </summary>
public class BaseResponse
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
}


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


/// <summary>
/// 靠泊港口船舶数据实体类
/// </summary>
public class PortOfCallByShipPortData
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
    /// 船舶类型（字符串）
    /// </summary>
    [JsonPropertyName("ship_type")]
    public string? ShipType { get; set; }

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
    /// 到达锚地（假设 JSON 字段名为 "arriveanchorage"）
    /// </summary>
    [JsonPropertyName("arriveanchorage")]
    public string? ArriveAnchorage { get; set; }

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
    /// 停留时间
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
public class GetPortOfCallByShipPortResponse
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 消息
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
    public List<PortOfCallByShipPortData>? Data { get; set; }
}


/// <summary>
/// 港口信息实体类
/// </summary>
public class PortInfo
{
    /// <summary>
    /// 港口代码
    /// </summary>
    [JsonPropertyName("port_code")]
    public string? PortCode { get; set; }

    /// <summary>
    /// 港口名称（英文）
    /// </summary>
    [JsonPropertyName("port_name")]
    public string? PortName { get; set; }

    /// <summary>
    /// 港口中文名
    /// </summary>
    [JsonPropertyName("port_cnname")]
    public string? PortCnName { get; set; }

    /// <summary>
    /// 港口时区
    /// </summary>
    [JsonPropertyName("port_time_zone")]
    public string? PortTimeZone { get; set; }

    /// <summary>
    /// 港口所属国家名称（英文）
    /// </summary>
    [JsonPropertyName("port_country_name")]
    public string? PortCountryName { get; set; }

    /// <summary>
    /// 港口所属国家名称（中文）
    /// </summary>
    [JsonPropertyName("port_country_cnname")]
    public string? PortCountryCnName { get; set; }

    /// <summary>
    /// 港口所属国家代码
    /// </summary>
    [JsonPropertyName("port_country_code")]
    public string? PortCountryCode { get; set; }

    /// <summary>
    /// 到达锚地（带下划线，注意区分）
    /// </summary>
    [JsonPropertyName("arrive_anchorage")]
    public string? ArriveAnchorage { get; set; }

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
    /// 当前港口所属国家英文名
    /// </summary>
    [JsonPropertyName("country_en")]
    public string? CountryEn { get; set; }

    /// <summary>
    /// 当前港口所属国家代码
    /// </summary>
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// 到达锚地（无下划线，注意与上面字段区分，语义可能略有差异）
    /// </summary>
    [JsonPropertyName("arriveanchorage")]
    public string? ArriveAnchorageAlt { get; set; }
}


/// <summary>
/// 船舶状态数据实体类
/// </summary>
public class ShipStatusData
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
    /// 船舶类型
    /// </summary>
    [JsonPropertyName("ship_type")]
    public string? ShipType { get; set; }

    /// <summary>
    /// 当前海区
    /// </summary>
    [JsonPropertyName("current_sea_area")]
    public string? CurrentSeaArea { get; set; }

    /// <summary>
    /// 海区代码
    /// </summary>
    [JsonPropertyName("sea_area_code")]
    public string? SeaAreaCode { get; set; }

    /// <summary>
    /// 当前城市
    /// </summary>
    [JsonPropertyName("current_city")]
    public string? CurrentCity { get; set; }

    /// <summary>
    /// 当前城市代码
    /// </summary>
    [JsonPropertyName("current_city_code")]
    public string? CurrentCityCode { get; set; }

    /// <summary>
    /// 经度
    /// </summary>
    [JsonPropertyName("lng")]
    public double? Lng { get; set; }

    /// <summary>
    /// 纬度
    /// </summary>
    [JsonPropertyName("lat")]
    public double? Lat { get; set; }

    /// <summary>
    /// 前一个港口信息
    /// </summary>
    [JsonPropertyName("previousport")]
    public PortInfo? PreviousPort { get; set; }

    /// <summary>
    /// 当前港口信息
    /// </summary>
    [JsonPropertyName("currentport")]
    public PortInfo? CurrentPort { get; set; }
}


/// <summary>
/// 获取船舶状态响应实体类
/// </summary>
public class GetShipStatusResponse
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 总数
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// 船舶状态数据列表
    /// </summary>
    [JsonPropertyName("data")]
    public List<ShipStatusData>? Data { get; set; }
}


/// <summary>
/// 港口停靠详细信息实体类
/// </summary>
public class PortCallPortInfo
{
    /// <summary>
    /// 港口代码
    /// </summary>
    [JsonPropertyName("port_code")]
    public string? PortCode { get; set; }

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
    /// 到达锚地
    /// </summary>
    [JsonPropertyName("arrival_anchorage")]
    public string? ArrivalAnchorage { get; set; }

    /// <summary>
    /// 实际到港时间 (ATA)
    /// </summary>
    [JsonPropertyName("ata")]
    public string? Ata { get; set; }

    /// <summary>
    /// 实际靠泊时间 (ATB)
    /// </summary>
    [JsonPropertyName("atb")]
    public string? Atb { get; set; }

    /// <summary>
    /// 实际离港时间 (ATD)
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
    /// 停留时间
    /// </summary>
    [JsonPropertyName("stay_time")]
    public double? StayTime { get; set; }

    /// <summary>
    /// 停靠码头时间
    /// </summary>
    [JsonPropertyName("stay_terminal_time")]
    public double? StayTerminalTime { get; set; }
}


/// <summary>
/// 港口停靠数据实体类
/// </summary>
public class PortOfCallByPortData
{
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
    /// 船舶类型
    /// </summary>
    [JsonPropertyName("ship_type")]
    public string? ShipType { get; set; }

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
    /// 当前港口信息
    /// </summary>
    [JsonPropertyName("currentport")]
    public PortCallPortInfo? CurrentPort { get; set; }

    /// <summary>
    /// 前一个港口信息
    /// </summary>
    [JsonPropertyName("previousport")]
    public PortCallPortInfo? PreviousPort { get; set; }

    /// <summary>
    /// 下一个港口信息
    /// </summary>
    [JsonPropertyName("nextport")]
    public PortCallPortInfo? NextPort { get; set; }
}


/// <summary>
/// 获取港口停靠数据响应实体类
/// </summary>
public class GetPortOfCallByPortResponse
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 总数
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// 港口停靠数据列表
    /// </summary>
    [JsonPropertyName("data")]
    public List<PortOfCallByPortData>? Data { get; set; }
}


/// <summary>
/// 路径点实体类，表示经纬度坐标
/// </summary>
public class RoutePoint
{
    /// <summary>
    /// 经度
    /// </summary>
    [JsonPropertyName("lng")]
    public double? Lng { get; set; }

    /// <summary>
    /// 纬度
    /// </summary>
    [JsonPropertyName("lat")]
    public double? Lat { get; set; }
}


/// <summary>
/// 基于点的航线规划数据实体类
/// </summary>
public class PlanRouteByPointData
{
    /// <summary>
    /// 距离
    /// </summary>
    [JsonPropertyName("distance")]
    public double? Distance { get; set; }

    /// <summary>
    /// 航线点列表
    /// </summary>
    [JsonPropertyName("route")]
    public List<RoutePoint>? Route { get; set; }
}


/// <summary>
/// 基于点的航线规划响应实体类
/// </summary>
public class PlanRouteByPointResponse
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    [JsonPropertyName("data")]
    public PlanRouteByPointData? Data { get; set; }
}


/// <summary>
/// 基于点的航线规划数据实体类
/// </summary>
public class PlanRouteByPortData
{
    /// <summary>
    /// 距离
    /// </summary>
    [JsonPropertyName("distance")]
    public double? Distance { get; set; }

    /// <summary>
    /// 航线点列表
    /// </summary>
    [JsonPropertyName("route")]
    public List<RoutePoint>? Route { get; set; }
}


/// <summary>
/// 基于点的航线规划响应实体类
/// </summary>
public class PlanRouteByPortResponse
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    [JsonPropertyName("data")]
    public PlanRouteByPortData? Data { get; set; }
}


/// <summary>
/// 单个 ETA 船舶信息实体类
/// </summary>
public class SingleETAShipInfo
{
    /// <summary>
    /// MMSI 号
    /// </summary>
    [JsonPropertyName("mmsi")]
    public int? Mmsi { get; set; }

    /// <summary>
    /// IMO 号
    /// </summary>
    [JsonPropertyName("imo")]
    public int? Imo { get; set; }

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
    /// 船舶类型
    /// </summary>
    [JsonPropertyName("ship_type")]
    public int? ShipType { get; set; }
}


/// <summary>
/// 单个 ETA 位置点信息实体类
/// </summary>
public class SingleETALocationInfo
{
    /// <summary>
    /// 经度
    /// </summary>
    [JsonPropertyName("lng")]
    public double? Lng { get; set; }

    /// <summary>
    /// 纬度
    /// </summary>
    [JsonPropertyName("lat")]
    public double? Lat { get; set; }

    /// <summary>
    /// 速度（单位可根据具体业务定义）
    /// </summary>
    [JsonPropertyName("speed")]
    public double? Speed { get; set; }

    /// <summary>
    /// 航速（SOG，Speed Over Ground，单位可根据具体业务定义）
    /// </summary>
    [JsonPropertyName("sog")]
    public double? Sog { get; set; }

    /// <summary>
    /// 海区名称
    /// </summary>
    [JsonPropertyName("sea_area")]
    public string? SeaArea { get; set; }

    /// <summary>
    /// 海区编码
    /// </summary>
    [JsonPropertyName("sea_area_code")]
    public int? SeaAreaCode { get; set; }
}


/// <summary>
/// 单个 ETA 港口信息实体类
/// </summary>
public class SingleETAPortInfo
{
    /// <summary>
    /// 港口代码
    /// </summary>
    [JsonPropertyName("port_code")]
    public string? PortCode { get; set; }

    /// <summary>
    /// 港口中文名
    /// </summary>
    [JsonPropertyName("port_cnname")]
    public string? PortCnname { get; set; }

    /// <summary>
    /// 港口英文名
    /// </summary>
    [JsonPropertyName("port_name")]
    public string? PortName { get; set; }

    /// <summary>
    /// 时区（整数，例如 +8 表示东八区）
    /// </summary>
    [JsonPropertyName("time_zone")]
    public int? TimeZone { get; set; }

    /// <summary>
    /// 港口所属国家代码
    /// </summary>
    [JsonPropertyName("port_country_code")]
    public string? PortCountryCode { get; set; }

    /// <summary>
    /// 港口所属国家英文名
    /// </summary>
    [JsonPropertyName("port_country_name")]
    public string? PortCountryName { get; set; }

    /// <summary>
    /// 港口所属国家中文名
    /// </summary>
    [JsonPropertyName("port_country_cnname")]
    public string? PortCountryCnname { get; set; }

    /// <summary>
    /// 预计到港时间（ATA，单位需根据具体业务定义，通常为时间戳或时间字符串）
    /// </summary>
    [JsonPropertyName("ata")]
    public double? Ata { get; set; }

    /// <summary>
    /// 预计靠泊时间（ATB）
    /// </summary>
    [JsonPropertyName("atb")]
    public double? Atb { get; set; }

    /// <summary>
    /// 预计离港时间（ATD）
    /// </summary>
    [JsonPropertyName("atd")]
    public double? Atd { get; set; }
}


/// <summary>
/// 单个 ETA 下一港口信息实体类
/// </summary>
public class SingleETANextPortInfo
{
    /// <summary>
    /// 港口代码
    /// </summary>
    [JsonPropertyName("port_code")]
    public string? PortCode { get; set; }

    /// <summary>
    /// 港口中文名
    /// </summary>
    [JsonPropertyName("port_cnname")]
    public string? PortCnname { get; set; }

    /// <summary>
    /// 港口名称（英文）
    /// </summary>
    [JsonPropertyName("port_name")]
    public string? PortName { get; set; }

    /// <summary>
    /// 时区（整数，例如 +8 表示东八区）
    /// </summary>
    [JsonPropertyName("time_zone")]
    public int? TimeZone { get; set; }

    /// <summary>
    /// 港口所属国家代码
    /// </summary>
    [JsonPropertyName("port_country_code")]
    public string? PortCountryCode { get; set; }

    /// <summary>
    /// 港口所属国家英文名
    /// </summary>
    [JsonPropertyName("port_country_name")]
    public string? PortCountryName { get; set; }

    /// <summary>
    /// 港口所属国家中文名
    /// </summary>
    [JsonPropertyName("port_country_cnname")]
    public string? PortCountryCnname { get; set; }

    /// <summary>
    /// 已航行距离（单位根据业务定义，通常为海里或公里）
    /// </summary>
    [JsonPropertyName("sailed_distance")]
    public double? SailedDistance { get; set; }

    /// <summary>
    /// 已航行时间（单位根据业务定义，可能为小时）
    /// </summary>
    [JsonPropertyName("sailed_time")]
    public double? SailedTime { get; set; }

    /// <summary>
    /// AIS 报告的速度
    /// </summary>
    [JsonPropertyName("ais_speed")]
    public double? AisSpeed { get; set; }

    /// <summary>
    /// 速度（单位与 ais_speed 一致）
    /// </summary>
    [JsonPropertyName("speed")]
    public double? Speed { get; set; }

    /// <summary>
    /// 预计到达时间（字符串格式，具体格式根据业务定义）
    /// </summary>
    [JsonPropertyName("eta")]
    public string? Eta { get; set; }

    /// <summary>
    /// 预计到达时间的 UTC 时间（整数，可能为时间戳）
    /// </summary>
    [JsonPropertyName("eta_utc")]
    public int? EtaUtc { get; set; }

    /// <summary>
    /// 剩余距离（单位根据业务定义）
    /// </summary>
    [JsonPropertyName("remaining_distance")]
    public double? RemainingDistance { get; set; }

    /// <summary>
    /// 距离（单位根据业务定义）
    /// </summary>
    [JsonPropertyName("distance")]
    public double? Distance { get; set; }
}


/// <summary>
/// 单个 ETA 精准数据汇总实体类
/// </summary>
public class GetSingleETAPreciseData
{
    /// <summary>
    /// 船舶信息
    /// </summary>
    [JsonPropertyName("ship")]
    public SingleETAShipInfo? Ship { get; set; }

    /// <summary>
    /// 位置信息
    /// </summary>
    [JsonPropertyName("location")]
    public SingleETALocationInfo? Location { get; set; }

    /// <summary>
    /// 上一个港口信息
    /// </summary>
    [JsonPropertyName("preport")]
    public SingleETAPortInfo? Preport { get; set; }

    /// <summary>
    /// 下一个港口信息
    /// </summary>
    [JsonPropertyName("nextport")]
    public SingleETANextPortInfo? Nextport { get; set; }
}




/// <summary>
/// 单个 ETA 精准响应实体类
/// </summary>
public class GetSingleETAPreciseResponse
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
    /// 响应数据
    /// </summary>
    [JsonPropertyName("data")]
    public GetSingleETAPreciseData? Data { get; set; }
}


/// <summary>
/// 天气点数据实体类，包含具体的气象参数。
/// </summary>
public class GetWeatherByPointData
{
    /// <summary>
    /// 气压（单位可能是 hPa 或其他，依据具体接口文档）。
    /// </summary>
    [JsonPropertyName("bm500")]
    public float? Bm500 { get; set; }

    /// <summary>
    /// 相对湿度，百分比。
    /// </summary>
    [JsonPropertyName("humidity")]
    public float? Humidity { get; set; }

    /// <summary>
    /// 海洋风向（单位：度）。
    /// </summary>
    [JsonPropertyName("oceandir")]
    public float? OceanDir { get; set; }

    /// <summary>
    /// 海洋风速（单位：米/秒 或其他）。
    /// </summary>
    [JsonPropertyName("oceanspeed")]
    public float? OceanSpeed { get; set; }

    /// <summary>
    /// 大气压强（单位：hPa）。
    /// </summary>
    [JsonPropertyName("pressure")]
    public float? Pressure { get; set; }

    /// <summary>
    /// 涨潮方向（单位：度）。
    /// </summary>
    [JsonPropertyName("swelldir")]
    public float? SwellDir { get; set; }

    /// <summary>
    /// 涨潮高度（单位：米）。
    /// </summary>
    [JsonPropertyName("swellheight")]
    public float? SwellHeight { get; set; }

    /// <summary>
    /// 涨潮周期（单位：秒）。
    /// </summary>
    [JsonPropertyName("swellperiod")]
    public float? SwellPeriod { get; set; }

    /// <summary>
    /// 温度（单位：摄氏度）。
    /// </summary>
    [JsonPropertyName("temperature")]
    public float? Temperature { get; set; }

    /// <summary>
    /// 能见度（单位：米或公里）。
    /// </summary>
    [JsonPropertyName("visibility")]
    public float? Visibility { get; set; }

    /// <summary>
    /// 波浪高度（单位：米）。
    /// </summary>
    [JsonPropertyName("waveheight")]
    public float? WaveHeight { get; set; }

    /// <summary>
    /// 风向（单位：度）。
    /// </summary>
    [JsonPropertyName("winddir")]
    public float? WindDir { get; set; }

    /// <summary>
    /// 风速（单位：米/秒）。
    /// </summary>
    [JsonPropertyName("windspeed")]
    public float? WindSpeed { get; set; }

    /// <summary>
    /// 发布时间，字符串格式，具体格式依据接口。
    /// </summary>
    [JsonPropertyName("publish_time")]
    public string? PublishTime { get; set; }

    /// <summary>
    /// 经度（单位：度）。
    /// </summary>
    [JsonPropertyName("lng")]
    public float? Lng { get; set; }

    /// <summary>
    /// 纬度（单位：度）。
    /// </summary>
    [JsonPropertyName("lat")]
    public float? Lat { get; set; }
}



/// <summary>
/// 天气点响应实体类，表示接口返回的整体结构。
/// </summary>
public class GetWeatherByPointResponse
{
    /// <summary>
    /// 状态码，通常用来表示请求是否成功（例如 1 表示成功，0 表示失败）。
    /// </summary>
    [JsonPropertyName("status")]
    public float? Status { get; set; }

    /// <summary>
    /// 返回信息，通常是对状态的描述或错误信息。
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 天气数据主体，具体包含温度、湿度等气象信息。
    /// </summary>
    [JsonPropertyName("data")]
    public GetWeatherByPointData? Data { get; set; }
}


/// <summary>
/// 海洋气象数据类
/// </summary>
public class WeatherData
{
    /// <summary>
    /// 区域类型
    /// 查询区域的类型：
    /// 0：全部；
    /// 1：沿岸；
    /// 2：近海；
    /// 3：远海
    /// </summary>
    [JsonPropertyName("weather_type")]
    public int? WeatherType { get; set; }

    /// <summary>
    /// 海区名称
    /// </summary>
    [JsonPropertyName("sea_area")]
    public string? SeaArea { get; set; }

    /// <summary>
    /// 预报时间
    /// </summary>
    [JsonPropertyName("publish_time")]
    public string? PublishTime { get; set; }

    /// <summary>
    /// 中心点纬度
    /// </summary>
    [JsonPropertyName("center_lat")]
    public double? CenterLat { get; set; }

    /// <summary>
    /// 中心点经度
    /// </summary>
    [JsonPropertyName("center_lng")]
    public double? CenterLng { get; set; }

    /// <summary>
    /// 预报时间段（建议非空）
    /// </summary>
    [JsonPropertyName("forecastaging")]
    public string? Forecastaging { get; set; }

    /// <summary>
    /// 气象信息：
    /// 阴、晴、多云、小雨、中雨、大雨、暴雨、阵雨、雷阵雨
    /// </summary>
    [JsonPropertyName("meteorological")]
    public string? Meteorological { get; set; }

    /// <summary>
    /// 风向：
    /// 东风；东南风；东南东；东北风；东北东；
    /// 南风；南南西；南南东；
    /// 西风；西南风；西南西；西北风；西北西；
    /// 北风；北北东；北北西
    /// </summary>
    [JsonPropertyName("winddirection")]
    public string? Winddirection { get; set; }

    /// <summary>
    /// 风级
    /// </summary>
    [JsonPropertyName("windpower")]
    public string? Windpower { get; set; }

    /// <summary>
    /// 浪高
    /// </summary>
    [JsonPropertyName("waveheight")]
    public string? Waveheight { get; set; }

    /// <summary>
    /// 能见度（km）
    /// </summary>
    [JsonPropertyName("visibility")]
    public double? Visibility { get; set; }
}


/// <summary>
/// 获取天气响应类
/// </summary>
public class GetWeatherResponse
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 信息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 总数
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// 天气数据列表
    /// </summary>
    [JsonPropertyName("data")]
    public List<WeatherData>? Data { get; set; }
}


/// <summary>
/// 台风列表项，表示单个台风的基本信息
/// 通常用于台风列表接口返回的台风数据封装
/// </summary>
public class TyphoonListItem
{
    /// <summary>
    /// 台风序号
    /// 无符号32位整数，唯一标识一个台风
    /// </summary>
    [JsonPropertyName("typhoon_id")]
    public uint? TyphoonId { get; set; }

    /// <summary>
    /// 台风国际编号
    /// 无符号32位整数，台风的国际编号
    /// </summary>
    [JsonPropertyName("typhoon_code")]
    public uint? TyphoonCode { get; set; }

    /// <summary>
    /// 台风国内编号
    /// 字符串类型，国内编号，前两位代表年份，后两位按时间先后排序
    /// </summary>
    [JsonPropertyName("typhoon_cncode")]
    public string? TyphoonCncode { get; set; }

    /// <summary>
    /// 台风名称（中文）
    /// 台风的中文名称
    /// </summary>
    [JsonPropertyName("typhoon_cnname")]
    public string? TyphoonCnname { get; set; }

    /// <summary>
    /// 台风名称（英文）
    /// 台风的英文名称
    /// </summary>
    [JsonPropertyName("typhoon_name")]
    public string? TyphoonName { get; set; }

    /// <summary>
    /// 发生年份
    /// 无符号32位整数，表示台风发生的年份
    /// </summary>
    [JsonPropertyName("current_year")]
    public uint? CurrentYear { get; set; }

    /// <summary>
    /// 是否正在发生
    /// 字符串类型，"ing" 表示台风正在进行中，否则为空字符串
    /// </summary>
    [JsonPropertyName("dataMark")]
    public string? DataMark { get; set; }
}


/// <summary>
/// 获取全部台风响应类
/// 用于封装台风列表接口的响应数据，包含状态码、提示信息、台风总数以及台风列表数据
/// </summary>
public class GetAllTyphoonResponse
{
    /// <summary>
    /// 状态码
    /// 一般用于标识接口调用成功与否，具体含义根据接口定义
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 返回信息
    /// 一般为接口调用结果的提示信息，如“成功”或错误原因
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 台风总数
    /// 表示此次查询返回的台风总条目数
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// 台风列表数据
    /// 具体的台风项集合，包含多个台风的详细信息
    /// </summary>
    [JsonPropertyName("data")]
    public List<TyphoonListItem>? Data { get; set; }
}

/// <summary>
/// 台风详细信息项
/// 表示某一时刻台风的具体观测或预报数据
/// </summary>
public class TyphoonDetailItem
{
    /// <summary>
    /// 台风序号
    /// 无符号32位整数，唯一标识一个台风
    /// </summary>
    [JsonPropertyName("typhoon_id")]
    public uint? TyphoonId { get; set; }

    /// <summary>
    /// 台风产生时间
    /// 字符串类型，表示台风产生的时间
    /// </summary>
    [JsonPropertyName("typhoon_time")]
    public string? TyphoonTime { get; set; }

    /// <summary>
    /// 预测信息
    /// 字符串类型，若为空表示实际观测点，非空表示预测点
    /// </summary>
    [JsonPropertyName("forecast")]
    public string? Forecast { get; set; }

    /// <summary>
    /// 预测时间范围
    /// 字符串类型，表示预测的时间范围
    /// </summary>
    [JsonPropertyName("fhour")]
    public string? Fhour { get; set; }

    /// <summary>
    /// 纬度
    /// 双精度浮点数，台风中心纬度，采用 WGS84 坐标系
    /// </summary>
    [JsonPropertyName("lat")]
    public double? Lat { get; set; }

    /// <summary>
    /// 经度
    /// 双精度浮点数，台风中心经度，采用 WGS84 坐标系
    /// </summary>
    [JsonPropertyName("lng")]
    public double? Lng { get; set; }

    /// <summary>
    /// 风级
    /// 字节类型，风级范围5-18
    /// </summary>
    [JsonPropertyName("grade")]
    public byte? Grade { get; set; }

    /// <summary>
    /// 风速
    /// 单精度浮点数，单位为米/秒
    /// </summary>
    [JsonPropertyName("mspeed")]
    public float? Mspeed { get; set; }

    /// <summary>
    /// 中心气压
    /// 单精度浮点数，单位为百帕
    /// </summary>
    [JsonPropertyName("pressure")]
    public float? Pressure { get; set; }

    /// <summary>
    /// 移动速度
    /// 单精度浮点数，单位为千米/小时
    /// </summary>
    [JsonPropertyName("kspeed")]
    public float? Kspeed { get; set; }

    /// <summary>
    /// 移向
    /// 字符串类型，台风移动方向，East（东）、West（西）、South（南）、North（北）
    /// </summary>
    [JsonPropertyName("direction")]
    public string? Direction { get; set; }

    /// <summary>
    /// 7级风圈半径
    /// 单精度浮点数，单位千米
    /// </summary>
    [JsonPropertyName("radius7")]
    public float? Radius7 { get; set; }

    /// <summary>
    /// 10级风圈半径
    /// 单精度浮点数，单位千米
    /// </summary>
    [JsonPropertyName("radius10")]
    public float? Radius10 { get; set; }

    /// <summary>
    /// 7级风圈半径标准差
    /// 单精度浮点数，单位千米
    /// </summary>
    [JsonPropertyName("radius7_s")]
    public float? Radius7S { get; set; }

    /// <summary>
    /// 10级风圈半径标准差
    /// 单精度浮点数，单位千米
    /// </summary>
    [JsonPropertyName("radius10_s")]
    public float? Radius10S { get; set; }

    /// <summary>
    /// 12级风圈半径标准差
    /// 单精度浮点数，单位千米
    /// </summary>
    [JsonPropertyName("radius12_s")]
    public float? Radius12S { get; set; }
}


/// <summary>
/// 单个台风详情响应类
/// 用于封装查询单个台风详细信息接口响应数据，包含状态码、提示信息、总条数及详细数据列表
/// </summary>
public class GetSingleTyphoonResponse
{
    /// <summary>
    /// 状态码
    /// 标识接口调用是否成功，具体含义由接口定义决定
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 返回信息
    /// 一般为接口调用结果说明，如“成功”或错误信息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 数据总数
    /// 返回的详细数据条目数
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// 台风详细信息列表
    /// 具体的台风详细数据集合
    /// </summary>
    [JsonPropertyName("data")]
    public List<TyphoonDetailItem>? Data { get; set; }
}


/// <summary>
/// 潮汐观测站信息
/// </summary>
public class TideStationInfo
{
    /// <summary>
    /// 港口潮汐观测站ID
    /// </summary>
    [JsonPropertyName("port_code")]
    public int? PortCode { get; set; }

    /// <summary>
    /// 港口名称（中文）
    /// </summary>
    [JsonPropertyName("port_cnname")]
    public string? PortCnname { get; set; }

    /// <summary>
    /// 港口名称（英文）
    /// </summary>
    [JsonPropertyName("port_name")]
    public string? PortName { get; set; }

    /// <summary>
    /// 港口国（中文）
    /// </summary>
    [JsonPropertyName("port_country_cnname")]
    public string? PortCountryCnname { get; set; }

    /// <summary>
    /// 港口国（英文）
    /// </summary>
    [JsonPropertyName("port_country_name")]
    public string? PortCountryName { get; set; }

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
    /// 港口时区
    /// </summary>
    [JsonPropertyName("port_time_zone")]
    public string? PortTimeZone { get; set; }

    /// <summary>
    /// 潮高基准面
    /// </summary>
    [JsonPropertyName("datumn")]
    public string? Datumn { get; set; }

    /// <summary>
    /// 潮汐性质
    /// </summary>
    [JsonPropertyName("tide_type")]
    public string? TideType { get; set; }
}



/// <summary>
/// 获取潮汐信息响应结果
/// </summary>
public class GetTidesResponse
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 信息提示
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 数据总数
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// 潮汐观测站信息列表
    /// </summary>
    [JsonPropertyName("data")]
    public List<TideStationInfo>? Data { get; set; }
}


/// <summary>
/// 潮汐总览数据项，包含当前日期4个潮汐时间点及对应的潮汐高度和潮汐标题名称。
/// </summary>
public class TideOverviewItem
{
    /// <summary>
    /// 日期
    /// </summary>
    [JsonPropertyName("tide_date")]
    public string? TideDate { get; set; }

    /// <summary>
    /// 当前日期第一个潮汐时间点
    /// </summary>
    [JsonPropertyName("tide_time1")]
    public string? TideTime1 { get; set; }

    /// <summary>
    /// 当前日期第二个潮汐时间点
    /// </summary>
    [JsonPropertyName("tide_time2")]
    public string? TideTime2 { get; set; }

    /// <summary>
    /// 当前日期第三个潮汐时间点
    /// </summary>
    [JsonPropertyName("tide_time3")]
    public string? TideTime3 { get; set; }

    /// <summary>
    /// 当前日期第四个潮汐时间点
    /// </summary>
    [JsonPropertyName("tide_time4")]
    public string? TideTime4 { get; set; }

    /// <summary>
    /// 当前日期第一个时间点的潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("tide_height1")]
    public float? TideHeight1 { get; set; }

    /// <summary>
    /// 当前日期第二个时间点的潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("tide_height2")]
    public float? TideHeight2 { get; set; }

    /// <summary>
    /// 当前日期第三个时间点的潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("tide_height3")]
    public float? TideHeight3 { get; set; }

    /// <summary>
    /// 当前日期第四个时间点的潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("tide_height4")]
    public float? TideHeight4 { get; set; }

    /// <summary>
    /// 当前日期第一个潮汐标题名称
    /// </summary>
    [JsonPropertyName("tide_lowhigh1")]
    public string? TideLowhigh1 { get; set; }

    /// <summary>
    /// 当前日期第二个潮汐标题名称
    /// </summary>
    [JsonPropertyName("tide_lowhigh2")]
    public string? TideLowhigh2 { get; set; }

    /// <summary>
    /// 当前日期第三个潮汐标题名称
    /// </summary>
    [JsonPropertyName("tide_lowhigh3")]
    public string? TideLowhigh3 { get; set; }

    /// <summary>
    /// 当前日期第四个潮汐标题名称
    /// </summary>
    [JsonPropertyName("tide_lowhigh4")]
    public string? TideLowhigh4 { get; set; }
}


/// <summary>
/// 潮汐详细项，包含一天24小时的潮高数据
/// </summary>
public class TideDetailItem
{
    /// <summary>
    /// 日期
    /// </summary>
    [JsonPropertyName("tide_date")]
    public string? TideDate { get; set; }

    /// <summary>
    /// 零点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h0")]
    public float? H0 { get; set; }

    /// <summary>
    /// 1点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h1")]
    public float? H1 { get; set; }

    /// <summary>
    /// 2点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h2")]
    public float? H2 { get; set; }

    /// <summary>
    /// 3点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h3")]
    public float? H3 { get; set; }

    /// <summary>
    /// 4点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h4")]
    public float? H4 { get; set; }

    /// <summary>
    /// 5点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h5")]
    public float? H5 { get; set; }

    /// <summary>
    /// 6点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h6")]
    public float? H6 { get; set; }

    /// <summary>
    /// 7点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h7")]
    public float? H7 { get; set; }

    /// <summary>
    /// 8点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h8")]
    public float? H8 { get; set; }

    /// <summary>
    /// 9点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h9")]
    public float? H9 { get; set; }

    /// <summary>
    /// 10点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h10")]
    public float? H10 { get; set; }

    /// <summary>
    /// 11点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h11")]
    public float? H11 { get; set; }

    /// <summary>
    /// 12点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h12")]
    public float? H12 { get; set; }

    /// <summary>
    /// 13点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h13")]
    public float? H13 { get; set; }

    /// <summary>
    /// 14点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h14")]
    public float? H14 { get; set; }

    /// <summary>
    /// 15点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h15")]
    public float? H15 { get; set; }

    /// <summary>
    /// 16点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h16")]
    public float? H16 { get; set; }

    /// <summary>
    /// 17点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h17")]
    public float? H17 { get; set; }

    /// <summary>
    /// 18点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h18")]
    public float? H18 { get; set; }

    /// <summary>
    /// 19点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h19")]
    public float? H19 { get; set; }

    /// <summary>
    /// 20点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h20")]
    public float? H20 { get; set; }

    /// <summary>
    /// 21点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h21")]
    public float? H21 { get; set; }

    /// <summary>
    /// 22点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h22")]
    public float? H22 { get; set; }

    /// <summary>
    /// 23点时潮汐高度，单位：米
    /// </summary>
    [JsonPropertyName("h23")]
    public float? H23 { get; set; }
}


/// <summary>
/// 获取潮汐数据的响应数据主体
/// </summary>
public class GetTideDataData
{
    /// <summary>
    /// 潮汐总览数据项列表
    /// </summary>
    [JsonPropertyName("overview")]
    public List<TideOverviewItem>? Overview { get; set; }

    /// <summary>
    /// 潮汐详细数据项列表
    /// </summary>
    [JsonPropertyName("detail")]
    public List<TideDetailItem>? Detail { get; set; }
}


/// <summary>
/// 获取潮汐数据的响应体
/// </summary>
public class GetTideDataResponse
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 返回消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 响应数据主体
    /// </summary>
    [JsonPropertyName("data")]
    public GetTideDataData? Data { get; set; }
}


/// <summary>
/// 航行警告数据
/// </summary>
public class GetNavWarningData
{
    /// <summary>
    /// 航行警告类型
    /// 1 军事任务，2 船舶演习，3 实弹射击，
    /// 4 船舶作业，5 航标动态，6 船舶搁浅，
    /// 7 船舶试航，8 沉没，9 人员伤亡，
    /// 10 施工作业，11 撤销航警，12 其他
    /// </summary>
    [JsonPropertyName("warning_type")]
    public int? WarningType { get; set; }

    /// <summary>
    /// 航行警告数据源，如：中国海事局
    /// </summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    /// <summary>
    /// 航行警告标题
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// 航行警告范围类型
    /// 1 单个坐标点；2 多边形区域；3 圆形区域；4 无坐标信息
    /// </summary>
    [JsonPropertyName("range_type")]
    public int? RangeType { get; set; }

    /// <summary>
    /// 范围坐标
    /// WGS84坐标系，经度和纬度以英文","隔开，
    /// 多个经纬度点位以英文";"隔开，
    /// 涉及多个区域的以and符号隔开。
    /// </summary>
    [JsonPropertyName("range_points")]
    public string? RangePoints { get; set; }

    /// <summary>
    /// 半径，单位：海里
    /// 当范围类型为圆形区域时，表示圆心半径
    /// </summary>
    [JsonPropertyName("radius")]
    public float? Radius { get; set; }

    /// <summary>
    /// 航行警告发布时间，北京时间，格式示例：2024-07-01 20:00
    /// </summary>
    [JsonPropertyName("pub_time")]
    public string? PubTime { get; set; }

    /// <summary>
    /// 过期时间，北京时间，格式示例：2024-07-21 20:00
    /// </summary>
    [JsonPropertyName("expire_time")]
    public string? ExpireTime { get; set; }

    /// <summary>
    /// 航行警告内容说明
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }
}


/// <summary>
/// 航行警告响应
/// </summary>
public class GetNavWarningResponse
{
    /// <summary>
    /// 状态码（浮点数）
    /// </summary>
    [JsonPropertyName("status")]
    public float? Status { get; set; }

    /// <summary>
    /// 返回消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 航行警告数据总数
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// 航行警告数据列表
    /// </summary>
    [JsonPropertyName("data")]
    public List<GetNavWarningData>? Data { get; set; }
}



/// <summary>
/// 船队数据
/// </summary>
public class FleetData
{
    /// <summary>
    /// 船队ID
    /// 船队的唯一标识，用于维护船队信息
    /// </summary>
    [JsonPropertyName("fleet_id")]
    public string? FleetId { get; set; }

    /// <summary>
    /// 船队名称
    /// 用于后续查询和区分不同船队
    /// </summary>
    [JsonPropertyName("fleet_name")]
    public string? FleetName { get; set; }

    /// <summary>
    /// 船舶清单
    /// 船队创建时所管理的所有船舶列表，包含多个MMSI编号
    /// </summary>
    [JsonPropertyName("mmsis")]
    public string? Mmsis { get; set; }

    /// <summary>
    /// 监控内容
    /// 船队所关联的监控内容，可通过更新船队信息API或控制台进行变更
    /// </summary>
    [JsonPropertyName("monitor")]
    public string? Monitor { get; set; }
}


/// <summary>
/// 船队响应数据
/// </summary>
public class FleetResponse
{
    /// <summary>
    /// 状态码
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// 返回消息
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// 船队数据
    /// </summary>
    [JsonPropertyName("data")]
    public FleetData? Data { get; set; }
}
