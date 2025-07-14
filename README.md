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
引入方式一：

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
        string responseBody = await Shipxy.GetManyShip(apiKey, "413961925,477232800,477172700");
        Console.WriteLine(responseBody);
    }
}
```

## 开发者在使用过程中如有疑问，可以通过以下方式联系船讯网：

• 商务邮箱：support@shipxy.com

• 技术支持邮箱：service@shipxy.com

• 电话：400-010-8558 

![飞书](./images/飞书.jpg)
![微信](./images/微信.jpg)