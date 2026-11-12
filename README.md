# 亿海蓝-船讯网-sdk
[亿海蓝官网](https://www.shipxy.com/)&nbsp;&nbsp;
[API控制台](https://api.shipxy.com/v3/console/index)&nbsp;&nbsp;
[在线开发文档](https://hiiau7lsqq.feishu.cn/wiki/E0wAwrPpvieGhSk5wLCctNqonVb)&nbsp;&nbsp;
[github](https://github.com/shipxycom/shipxy-api-dotnet)&nbsp;&nbsp;
[gitee](https://gitee.com/shipxycom/shipxy-api-dotnet)&nbsp;&nbsp;
[nuget](https://www.nuget.org/packages/shipxy-api/)&nbsp;&nbsp;


引入方式一：
```
dotnet add package shipxy-api
```
引入方式二：

1、项目中添加动态库，例如路径为 lib\shipxy-api-dotnet.dll。   
2、.csproj文件中根节点Project引用该动态库。
```
  <ItemGroup>
      <Reference Include="ShipxyApi">
          <HintPath>lib\shipxy-api-dotnet.dll</HintPath>
      </Reference>
  </ItemGroup>
```
## 示例用法
```
using System;
using System.Threading.Tasks;
using ShipxyApi;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "请从 API控制台 申请";
        ManyShipResponse responseBody = await Shipxy.GetManyShip(apiKey, "413961925,477232800,477172700");
        Console.WriteLine(responseBody?.Data?[0].Mmsi);

        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // 禁用大部分转义
            WriteIndented = true
        };
        Console.WriteLine(JsonSerializer.Serialize(responseBody, options));
    }
}
```

## 开发者在使用过程中如有疑问，可以通过以下方式联系船讯网：

• 商务邮箱：support@shipxy.com

• 技术支持邮箱：service@shipxy.com

• 电话：400-010-8558 

![飞书](./images/飞书.jpg)
![微信](./images/微信.jpg)

## 全球潮汐与新气象接口

按官方文档 6.5、6.6、6.7 补充以下 GET 接口（均需对应高级服务权限）：

| 方法 | 必填参数 |
| --- | --- |
| GetGlobalTides | key |
| GetGlobalTideData | key、port_code、start_date、end_date |
| CurrentWeather | key、lng、lat |
| FutureWeather | key、lng、lat |
| HistoryWeather | key、lng、lat、start_time、end_time |

`port_code` 为整数潮汐观测站 ID，不是港口五位码。潮汐日期格式 `yyyy-MM-dd`，
历史数据从 2020 年起，单次不超过 90 天，未来预报不超过 30 天。
气象坐标为 WGS84；历史查询时间格式 `yyyy-MM-dd HH:mm:ss`，使用北京时间，
开始时间不早于三年前、结束时间须在当前时间 24 小时以前，单次不超过一个月。
响应 `observation_time` 为 UTC 时间。原有气象和国内潮汐接口继续保留。

## 船舶与港口查询参数更新

- `SearchShip` 按文档使用 GET。
- `GetAreaShip` 增加可选 `data_type`：0 船舶（默认）、1 航标、2 网位仪、3 船舶和航标、4 船舶和网位仪、5 全部。含航标或网位仪时 `output` 需为 1（JSON），响应增加 `aton_list`、`netbuoy_list`。
- `GetBerthShips`、`GetAnchorShips` 增加可选 `search_type`：1 屏蔽长期未上报 AIS 的船舶，0 返回全部。
- `GetPortofCallByPort` 单次历史查询不超过一周；船舶维度的历史挂靠查询仍按其各自的时间限制。

## 航线、航速提醒与海图接口

- `PlanRouteByPoint` 支持 `end_port_code`；与 `end_point` 至少填写一项，两项都填时终点港口优先。Python/.NET新增参数放在末尾，保留原有位置参数；Java请求DTO增加该字段。
- 新增 `SubShipAlertOfSpeed(key,mmsi,speed_limit,speed_duration)`、`UnsubShipAlertOfSpeed(key,mmsi)`、`SearchSubShipAlertOfSpeed(key)`。这是独立订阅列表，与船队monitor清单不同；`speed_limit`为最小-最大航速字符串（0～50节），可选`speed_duration`单位分钟，省略默认5。
- 新增 `GetShipRasterImage`、`GetPortTile` 返回原始图片字节，不做JSON反序列化。对应的 `GetShipRasterImageUrl`、`GetPortTileUrl` 仅构造URL，适用于地图图层。
- 光栅图服务需要与船讯网海图JS配套且开通权限，提供包装并不意味着可以独立绕过服务限制。瓦片x/y/z是网格坐标和缩放等级；港口投影类型为m、wm或wmgcj。
- `DeleteFleet` 按官方文档使用POST。Python更新船队/区域时可省略非必填参数；ETA目的港可省略。台风字符串ID保留数值调用兼容；强类型版本修正台风字符串字段和ETA出发港的时间字段，.NET相关响应字段现在为字符串并兼容读取旧数字JSON值。
