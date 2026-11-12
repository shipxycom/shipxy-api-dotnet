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
