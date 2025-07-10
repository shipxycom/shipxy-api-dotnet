using System.Net;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

/// White
/// 249898979@qq.com
namespace ShipxyApi
{
    /// <summary>
    /// 亿海蓝Elane船讯网shipxy
    /// </summary>
    public class Shipxy
    {
        public static string apiUrl = "https://api.shipxy.com/apicall/v3";
        public static HttpClient client = new HttpClient();

        /// <summary>
        /// 通用方法，获取API方法
        /// </summary>
        /// <param name="methodName">方法名</param>
        /// <param name="parameters">参数字典</param>
        /// <returns></returns>
        public static async Task<string> getMethod(string methodName, Dictionary<string, object> parameters)
        {
            string queryString = string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}"));
            UriBuilder uriBuilder = new UriBuilder(apiUrl + "/" + methodName);
            uriBuilder.Query = queryString; // 自动编码查询字符串部分
            Uri uri = uriBuilder.Uri; // 获取编码后的URI对象
            // Console.WriteLine(uri);
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 1船舶查询-1.1船舶模糊查询
        /// https://hiiau7lsqq.feishu.cn/wiki/VCSYw1FU3iP0zwk2IIFcf2oynPb
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="keywords">关键字：必填，船舶查询的输入关键字，可以是船名、呼号、MMSI、IMO 等；匹配原则：MMSI 为 9 位数, IMO 为 7 位数</param>
        /// <param name="max">最大返回数量：选填，最多返回的结果数量，该值最大 100</param>
        /// <returns></returns>
        public static async Task<string> SearchShip(string key, string keywords, int max = 100)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "keywords", keywords },
                { "max", max }
            };
            return await getMethod("SearchShip", parameters);
        }

        /// <summary>
        /// 1船舶查询-1.2船舶位置查询-单船位置查询
        /// https://hiiau7lsqq.feishu.cn/wiki/GxF2w6cZHisQiEkBRatcoIqlnfc
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="mmsi">船舶mmsi编号：必填，船舶mmsi编号，9 位数字</param>
        /// <returns></returns>
        public static async Task<string> GetSingleShip(string key, int mmsi)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "mmsi", mmsi }
            };
            return await getMethod("GetSingleShip", parameters);
        }

        /// <summary>
        /// 1船舶查询-1.2船舶位置查询-多船位置查询
        /// https://hiiau7lsqq.feishu.cn/wiki/GxF2w6cZHisQiEkBRatcoIqlnfc
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="mmsis">船舶mmsi编号：必填，船舶编号，船舶mmsi编号，多船查询以英文逗号隔开，单次查询船舶数量不超过100</param>
        /// <returns></returns>
        public static async Task<string> GetManyShip(string key, string mmsis)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "mmsis", mmsis }
            };
            return await getMethod("GetManyShip", parameters);
        }
    }
}