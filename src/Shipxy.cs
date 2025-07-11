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
            string queryString = string.Join("&", parameters.Where(p => p.Value != null).Select(p => $"{p.Key}={p.Value}"));
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

        /// <summary>
        /// 1船舶查询-1.2船舶位置查询-船队船位置查询
        /// https://hiiau7lsqq.feishu.cn/wiki/GxF2w6cZHisQiEkBRatcoIqlnfc
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="fleet_id">船队编号：必填，控制台中维护的船队id，查询船队下所有船舶数据。</param>
        /// <returns></returns>
        public static async Task<string> GetFleetShip(string key, string fleet_id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "fleet_id", fleet_id }
            };
            return await getMethod("GetFleetShip", parameters);
        }
        /// <summary>
        /// 1船舶查询-1.3周边船舶查询
        /// https://hiiau7lsqq.feishu.cn/wiki/XXTiwDpetivSFhkciWic6qarnOc
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="mmsi">船舶mmsi编号：必填，船舶mmsi编号，9 位数字</param>
        /// <returns></returns>
        public static async Task<string> GetSurRoundingShip(string key, int mmsi)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "mmsi", mmsi }
            };
            return await getMethod("GetSurRoundingShip", parameters);
        }

        /// <summary>
        /// 1船舶查询-1.4区域船舶查询
        /// https://hiiau7lsqq.feishu.cn/wiki/ZlcrwKpgqik1L3kvbIMcBJUCn1U
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="region">查询区域：必填，经纬度逗号分隔，多个点减号分隔，如： （lng,lat - lng,lat ）经纬度数，多个经纬度坐标点必须按照顺时针或逆时针依次输入。</param>
        /// <param name="output">输出格式：选填，输出数据格式类型选择：0为二进制 Base64 编码，1为json格式，默认为1</param>
        /// <param name="scode">会话令牌：选填，当区域范围船舶单次请求无法全部返回时，可以根据首次请求返回的scode再次请求剩余的数据，保证全部返回。</param>
        /// <returns></returns>
        public static async Task<string> GetAreaShip(string key, string region, int output = 1, int? scode = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "region", region },
                { "output", output },
            };
            if (scode != null) parameters.Add("scode", scode);
            return await getMethod("GetAreaShip", parameters);
        }

        /// <summary>
        /// 1船舶查询-1.5船舶船籍查询
        /// https://hiiau7lsqq.feishu.cn/wiki/Ko5gw1o0ZiMQankWEAscSMoin7g
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="mmsi">船舶mmsi编号：必填，船舶mmsi编号，9 位数字</param>
        /// <returns></returns>
        public static async Task<string> GetShipRegistry(string key, int mmsi)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "mmsi", mmsi }
            };
            return await getMethod("GetShipRegistry", parameters);
        }

        /// <summary>
        /// 1船舶查询-1.6船舶档案查询
        /// https://hiiau7lsqq.feishu.cn/wiki/Vvd2wHECliYz6okSoYucTRXvnsd
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="parameters">
        /// 键值对：
        /// mmsi: 船舶mmsi编号：非必填，船舶mmsi编号，9位数字。请求时船舶mmsi编号、imo、呼号、名称必填一项，全部不填则请求失败。
        /// imo: imo编号：非必填，船舶imo编号
        /// call_sign: 船舶呼号：非必填，船舶呼号，如果不同船舶的呼号相同，则相同呼号档案都将返回
        /// ship_name: 船舶名称：非必填，船舶英文名称，如果不同船舶的名称相同，则同名船舶的档案都将返回
        /// </param>
        /// <returns></returns>
        public static async Task<string> SearchShipParticular(string key, Dictionary<string, object> parameters)
        {
            if (parameters == null) return "Parameters cannot be null.";
            parameters.Add("key", key);
            return await getMethod("SearchShipParticular", parameters);
        }

        /// <summary>
        /// 2港口查询-2.1港口信息查询
        /// https://hiiau7lsqq.feishu.cn/wiki/DAlUwEn9Zi50gckSv0uc1qsIn6f
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="keywords">关键字：必填，港口查询的输入关键字，可以是港口中文/英文名称、港口标准五位码</param>
        /// <param name="max">最大返回数量：选填，最多返回的结果数量，该值最大 100</param>
        /// <returns></returns>
        public static async Task<string> SearchPort(string key, string keywords, int max = 100)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "keywords", keywords },
                { "max", max }
            };
            return await getMethod("SearchPort", parameters);
        }

        /// <summary>
        /// 2港口查询-2.2港口当前靠泊船查询
        /// https://hiiau7lsqq.feishu.cn/wiki/KdBNwIxOhijpALkCkNXc69MKn3g
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="port_code">港口标准code：必填，港口标准五位码</param>
        /// <param name="ship_type">船舶类型：选填，筛选船舶的类型，船舶类型清单请参考文档，不填写时返回全部船舶。</param>
        /// <returns></returns>
        public static async Task<string> GetBerthShips(string key, string port_code, int? ship_type = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "port_code", port_code },
            };
            if (ship_type != null) parameters.Add("ship_type", ship_type);
            return await getMethod("GetBerthShips", parameters);
        }

        /// <summary>
        /// 2港口查询-2.3港口当前到锚船舶查询
        /// https://hiiau7lsqq.feishu.cn/wiki/WTHnwa66niA4VhkmNVXchRRSnYe
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="port_code">港口标准code：必填，港口标准五位码</param>
        /// <param name="ship_type">船舶类型：选填，筛选船舶的类型，船舶类型清单请参考文档，不填写时返回全部船舶。</param>
        /// <returns></returns>
        public static async Task<string> GetAnchorShips(string key, string port_code, int? ship_type = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "port_code", port_code },
            };
            if (ship_type != null) parameters.Add("ship_type", ship_type);
            return await getMethod("GetAnchorShips", parameters);
        }

        /// <summary>
        /// 2港口查询-2.4港口预抵船舶查询
        /// https://hiiau7lsqq.feishu.cn/wiki/Poe3wdXkwiwzMUkATcJcigeBnJh
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="port_code">港口标准code：必填，港口标准五位码</param>
        /// <param name="start_time">开始时间：必填，开始时间，utc时间戳。开始时间必须大于当前时间</param>
        /// <param name="end_time">结束时间：必填，结束时间，utc时间戳。单次请求查询中，开始时间和结束时间的间隔不超过1周。</param>
        /// <param name="ship_type">船舶类型：选填，筛选船舶的类型，船舶类型清单请参考文档，不填写时返回全部船舶。</param>
        /// <returns></returns>
        public static async Task<string> GetETAShips(string key, string port_code, int start_time, int end_time, int? ship_type = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "port_code", port_code },
                { "start_time", start_time },
                { "end_time", end_time },
            };
            if (ship_type != null) parameters.Add("ship_type", ship_type);
            return await getMethod("GetETAShips", parameters);
        }

        /// <summary>
        /// 3历史行为-3.1船舶历史轨迹查询
        /// https://hiiau7lsqq.feishu.cn/wiki/RK2Uwh7tziQ7SnkzlDgcUk8Nnkc
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="mmsi">船舶编号：必填，船舶mmsi编号</param>
        /// <param name="start_time">开始时间：必填，查询的开始时间，unix时间戳</param>
        /// <param name="end_time">结束时间：必填，查询的截止时间，unix时间戳</param>
        /// <param name="output">输出格式：选填，输出数据格式类型选择：0为二进制 Base64 编码，1为json格式，默认为1。</param>
        /// <returns></returns>
        public static async Task<string> GetShipTrack(string key, int mmsi, int start_time, int end_time, int output = 1)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "mmsi", mmsi },
                { "start_time", start_time },
                { "end_time", end_time },
                { "output", output },
            };
            return await getMethod("GetShipTrack", parameters);
        }

        /// <summary>
        /// 3历史行为-3.2船舶搭靠记录查询
        /// https://hiiau7lsqq.feishu.cn/wiki/GYrTwxfzRiQdDxkJYOWcF3kKnnf
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="mmsi">船舶编号：必填，船舶mmsi编号，9 位数字</param>
        /// <param name="start_time">开始时间：必填，开始时间，utc时间戳。</param>
        /// <param name="end_time">结束时间：必填，结束时间，utc时间戳。单次请求查询中，开始时间和结束时间的间隔不超过1个月。</param>
        /// <param name="approach_zone">搭靠地区：选填，1代表港口地区搭靠；2代表锚地搭靠；3代表其他地点搭靠；不填写返回全部。</param>
        /// <returns></returns>
        public static async Task<string> SearchshipApproach(string key, int mmsi, int start_time, int end_time, int? approach_zone = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "mmsi", mmsi },
                { "start_time", start_time },
                { "end_time", end_time },
            };
            if (approach_zone != null) parameters.Add("approach_zone", approach_zone);
            return await getMethod("SearchshipApproach", parameters);
        }
    }
}