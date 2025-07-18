using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json;

namespace ShipxyApi
{
    /// <summary>
    /// 亿海蓝Elane船讯网shipxy
    /// 作者：White
    /// </summary>
    public class Shipxy
    {
        private static string apiUrl = "https://api.shipxy.com/apicall/v3";
        private static HttpClient client = new HttpClient();

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
            Console.WriteLine(uri);
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 通用方法，发送POST请求
        /// </summary>
        /// <param name="methodName">方法名</param>
        /// <param name="parameters">参数字典</param>
        /// <returns></returns>
        public static async Task<string> postMethod(string methodName, Dictionary<string, object> parameters)
        {
            string url = apiUrl + "/" + methodName;
            // 过滤掉值为 null 的参数
            Dictionary<string, object> filteredParams = parameters.Where(p => p.Value != null)
                                           .ToDictionary(p => p.Key, p => p.Value);
            // 序列化参数为 JSON 字符串
            string jsonString = System.Text.Json.JsonSerializer.Serialize(filteredParams);
            // 创建请求内容，指定编码和媒体类型
            HttpContent content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            Console.WriteLine($"POST {url}");
            Console.WriteLine("Request body:");
            Console.WriteLine(jsonString);
            // 发送POST请求
            HttpResponseMessage response = await client.PostAsync(url, content);
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
        public static async Task<SearchShipResponse> SearchShip(string key, string keywords, int max = 100)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "keywords", keywords },
                { "max", max }
            };
            // 调用POST方法，获取JSON字符串
            string json = await postMethod("SearchShip", parameters);

            SearchShipResponse response = JsonSerializer.Deserialize<SearchShipResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
        }

        /// <summary>
        /// 1船舶查询-1.2船舶位置查询-单船位置查询
        /// https://hiiau7lsqq.feishu.cn/wiki/GxF2w6cZHisQiEkBRatcoIqlnfc
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="mmsi">船舶mmsi编号：必填，船舶mmsi编号，9 位数字</param>
        /// <returns></returns>
        public static async Task<SingleShipResponse> GetSingleShip(string key, int mmsi)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "mmsi", mmsi }
            };
            string json = await getMethod("GetSingleShip", parameters);

            SingleShipResponse response = JsonSerializer.Deserialize<SingleShipResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
        }

        /// <summary>
        /// 1船舶查询-1.2船舶位置查询-多船位置查询
        /// https://hiiau7lsqq.feishu.cn/wiki/GxF2w6cZHisQiEkBRatcoIqlnfc
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="mmsis">船舶mmsi编号：必填，船舶编号，船舶mmsi编号，多船查询以英文逗号隔开，单次查询船舶数量不超过100</param>
        /// <returns></returns>
        public static async Task<ManyShipResponse> GetManyShip(string key, string mmsis)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "mmsis", mmsis }
            };
            string json = await getMethod("GetManyShip", parameters);

            ManyShipResponse response = JsonSerializer.Deserialize<ManyShipResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
        }

        /// <summary>
        /// 1船舶查询-1.2船舶位置查询-船队船位置查询
        /// https://hiiau7lsqq.feishu.cn/wiki/GxF2w6cZHisQiEkBRatcoIqlnfc
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="fleet_id">船队编号：必填，控制台中维护的船队id，查询船队下所有船舶数据。</param>
        /// <returns></returns>
        public static async Task<FleetShipResponse> GetFleetShip(string key, string fleet_id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "fleet_id", fleet_id }
            };
            string json = await getMethod("GetFleetShip", parameters);

            FleetShipResponse response = JsonSerializer.Deserialize<FleetShipResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
        }
        /// <summary>
        /// 1船舶查询-1.3周边船舶查询
        /// https://hiiau7lsqq.feishu.cn/wiki/XXTiwDpetivSFhkciWic6qarnOc
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="mmsi">船舶mmsi编号：必填，船舶mmsi编号，9 位数字</param>
        /// <returns></returns>
        public static async Task<SurRoundingShipResponse> GetSurRoundingShip(string key, int mmsi)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "mmsi", mmsi }
            };
            string json = await getMethod("GetSurRoundingShip", parameters);

            SurRoundingShipResponse response = JsonSerializer.Deserialize<SurRoundingShipResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
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
        public static async Task<AreaShipResponse> GetAreaShip(string key, string region, int output = 1, int? scode = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "region", region },
                { "output", output },
            };
            if (scode != null) parameters.Add("scode", scode);
            string json = await getMethod("GetAreaShip", parameters);

            AreaShipResponse response = JsonSerializer.Deserialize<AreaShipResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
        }

        /// <summary>
        /// 1船舶查询-1.5船舶船籍查询
        /// https://hiiau7lsqq.feishu.cn/wiki/Ko5gw1o0ZiMQankWEAscSMoin7g
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="mmsi">船舶mmsi编号：必填，船舶mmsi编号，9 位数字</param>
        /// <returns></returns>
        public static async Task<ShipRegistryResponse> GetShipRegistry(string key, int mmsi)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "mmsi", mmsi }
            };
            string json = await getMethod("GetShipRegistry", parameters);

            ShipRegistryResponse response = JsonSerializer.Deserialize<ShipRegistryResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
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
        public static async Task<SearchShipParticularResponse> SearchShipParticular(string key, Dictionary<string, object> parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters), "Parameters cannot be null.");
            parameters.Add("key", key);
            string json = await getMethod("SearchShipParticular", parameters);

            SearchShipParticularResponse response = JsonSerializer.Deserialize<SearchShipParticularResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
        }

        /// <summary>
        /// 2港口查询-2.1港口信息查询
        /// https://hiiau7lsqq.feishu.cn/wiki/DAlUwEn9Zi50gckSv0uc1qsIn6f
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="keywords">关键字：必填，港口查询的输入关键字，可以是港口中文/英文名称、港口标准五位码</param>
        /// <param name="max">最大返回数量：选填，最多返回的结果数量，该值最大 100</param>
        /// <returns></returns>
        public static async Task<SearchPortResponse> SearchPort(string key, string keywords, int max = 100)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "keywords", keywords },
                { "max", max }
            };
            string json = await getMethod("SearchPort", parameters);
            SearchPortResponse response = JsonSerializer.Deserialize<SearchPortResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
        }

        /// <summary>
        /// 2港口查询-2.2港口当前靠泊船查询
        /// https://hiiau7lsqq.feishu.cn/wiki/KdBNwIxOhijpALkCkNXc69MKn3g
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="port_code">港口标准code：必填，港口标准五位码</param>
        /// <param name="ship_type">船舶类型：选填，筛选船舶的类型，船舶类型清单请参考文档，不填写时返回全部船舶。</param>
        /// <returns></returns>
        public static async Task<GetBerthShipsResponse> GetBerthShips(string key, string port_code, int? ship_type = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "port_code", port_code },
            };
            if (ship_type != null) parameters.Add("ship_type", ship_type);
            string json = await getMethod("GetBerthShips", parameters);
            GetBerthShipsResponse response = JsonSerializer.Deserialize<GetBerthShipsResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
        }

        /// <summary>
        /// 2港口查询-2.3港口当前到锚船舶查询
        /// https://hiiau7lsqq.feishu.cn/wiki/WTHnwa66niA4VhkmNVXchRRSnYe
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="port_code">港口标准code：必填，港口标准五位码</param>
        /// <param name="ship_type">船舶类型：选填，筛选船舶的类型，船舶类型清单请参考文档，不填写时返回全部船舶。</param>
        /// <returns></returns>
        public static async Task<GetAnchorShipsResponse> GetAnchorShips(string key, string port_code, int? ship_type = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "port_code", port_code },
            };
            if (ship_type != null) parameters.Add("ship_type", ship_type);
            string json = await getMethod("GetAnchorShips", parameters);

            GetAnchorShipsResponse response = JsonSerializer.Deserialize<GetAnchorShipsResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
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
        public static async Task<GetETAShipsResponse> GetETAShips(string key, string port_code, int start_time, int end_time, int? ship_type = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "port_code", port_code },
                { "start_time", start_time },
                { "end_time", end_time },
            };
            if (ship_type != null) parameters.Add("ship_type", ship_type);
            string json = await getMethod("GetETAShips", parameters);

            GetETAShipsResponse response = JsonSerializer.Deserialize<GetETAShipsResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
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
        public static async Task<GetShipTrackResponse> GetShipTrack(string key, int mmsi, int start_time, int end_time, int output = 1)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "mmsi", mmsi },
                { "start_time", start_time },
                { "end_time", end_time },
                { "output", output },
            };
            string json = await getMethod("GetShipTrack", parameters);

            GetShipTrackResponse response = JsonSerializer.Deserialize<GetShipTrackResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
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
        public static async Task<SearchShipApproachResponse> SearchshipApproach(string key, int mmsi, int start_time, int end_time, int? approach_zone = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "mmsi", mmsi },
                { "start_time", start_time },
                { "end_time", end_time },
            };
            if (approach_zone != null) parameters.Add("approach_zone", approach_zone);

            string json = await getMethod("SearchshipApproach", parameters);

            SearchShipApproachResponse response = JsonSerializer.Deserialize<SearchShipApproachResponse>(json)
                ?? throw new InvalidOperationException("Deserialization returned null.");
            return response;
        }
        /// <summary>
        /// 4挂靠记录-4.1船舶历史挂靠记录
        /// https://hiiau7lsqq.feishu.cn/wiki/Sv5rw61KVioV0ekq4ytcBpGgnGd
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="parameters">
        /// 键值对：
        /// mmsi: 船舶mmsi编号：非必填，船舶mmsi编号，9位数字。请求时船舶mmsi编号、imo、呼号、名称必填一项，全部不填则请求失败。
        /// imo: imo编号：非必填，船舶imo编号
        /// call_sign: 船舶呼号：非必填，船舶呼号，如果不同船舶的呼号相同，则相同呼号档案都将返回
        /// ship_name: 船舶名称：非必填，船舶英文名称，如果不同船舶的名称相同，则同名船舶的档案都将返回
        /// </param>
        /// <param name="start_time">开始时间：必填，历史靠港记录开始时间，Unix 时间戳start_time与end_time为必填项，表示查询[start_time，end_time]之间的结果，最多1次只能查询1年（366天）的靠港记录.</param>
        /// <param name="end_time">结束时间：必填，历史靠港记录结束时间，unix 时间戳。</param>
        /// <param name="time_zone">时区：选填，时间类型(选填)。 1当地时区，如果不存在，使用零时区；2北京时区；3零时区，即格林尼治平均时。默认值：2。</param>
        /// <returns></returns>
        public static async Task<string> GetPortofCallByShip(string key, Dictionary<string, object> parameters, int start_time, int end_time, int time_zone = 2)
        {
            if (parameters == null) return "Parameters cannot be null.";
            parameters.Add("key", key);
            parameters.Add("start_time", start_time);
            parameters.Add("end_time", end_time);
            parameters.Add("time_zone", time_zone);
            return await getMethod("GetPortofCallByShip", parameters);
        }

        /// <summary>
        /// 4挂靠记录-4.2船舶挂靠指定港口记录
        /// https://hiiau7lsqq.feishu.cn/wiki/R01xw8GxYiPd08kGhDeckVojnSC
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="parameters">
        /// 键值对：
        /// mmsi: 船舶mmsi编号：非必填，船舶mmsi编号，9位数字。请求时船舶mmsi编号、imo、呼号、名称必填一项，全部不填则请求失败。
        /// imo: imo编号：非必填，船舶imo编号
        /// call_sign: 船舶呼号：非必填，船舶呼号，如果不同船舶的呼号相同，则相同呼号档案都将返回
        /// ship_name: 船舶名称：非必填，船舶英文名称，如果不同船舶的名称相同，则同名船舶的档案都将返回
        /// </param>
        /// <param name="port_code">港口标准code：必填，港口标准五位码</param>
        /// <param name="start_time">开始时间：必填，历史靠港记录开始时间，Unix 时间戳start_time与end_time为必填项，表示查询[start_time，end_time]之间的结果，最多1次只能查询1年（366天）的靠港记录.</param>
        /// <param name="end_time">结束时间：必填，历史靠港记录结束时间，unix 时间戳。</param>
        /// <param name="time_zone">时区：选填，时间类型(选填)。 1当地时区，如果不存在，使用零时区；2北京时区；3零时区，即格林尼治平均时。默认值：2。</param>
        /// <returns></returns>
        public static async Task<string> GetPortofCallByShipPort(string key, Dictionary<string, object> parameters, string port_code, int start_time, int end_time, int time_zone = 2)
        {
            if (parameters == null) return "Parameters cannot be null.";
            parameters.Add("key", key);
            parameters.Add("port_code", port_code);
            parameters.Add("start_time", start_time);
            parameters.Add("end_time", end_time);
            parameters.Add("time_zone", time_zone);
            return await getMethod("GetPortofCallByShipPort", parameters);
        }

        /// <summary>
        /// 4挂靠记录-4.3船舶当前挂靠信息
        /// https://hiiau7lsqq.feishu.cn/wiki/O3PRwZoAjiX3DdknudicZnVpnxH
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="parameters">
        /// 键值对：
        /// mmsi: 船舶mmsi编号：非必填，船舶mmsi编号，9位数字。请求时船舶mmsi编号、imo、呼号、名称必填一项，全部不填则请求失败。
        /// imo: imo编号：非必填，船舶imo编号
        /// call_sign: 船舶呼号：非必填，船舶呼号，如果不同船舶的呼号相同，则相同呼号档案都将返回
        /// ship_name: 船舶名称：非必填，船舶英文名称，如果不同船舶的名称相同，则同名船舶的档案都将返回
        /// </param>
        /// <param name="time_zone">时区：选填，时间类型(选填)。 1当地时区，如果不存在，使用零时区；2北京时区；3零时区，即格林尼治平均时。默认值：2。</param>
        /// <returns></returns>
        public static async Task<string> GetShipStatus(string key, Dictionary<string, object> parameters, int time_zone = 2)
        {
            if (parameters == null) return "Parameters cannot be null.";
            parameters.Add("key", key);
            parameters.Add("time_zone", time_zone);
            return await getMethod("GetShipStatus", parameters);
        }

        /// <summary>
        /// 4挂靠记录-4.4港口挂靠历史船舶
        /// https://hiiau7lsqq.feishu.cn/wiki/G9BDwzNPqiXdyckzFrBctxYUnHd
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="port_code">港口标准code：必填，港口标准五位码</param>
        /// <param name="start_time">开始时间：必填，历史靠港记录开始时间，Unix 时间戳start_time与end_time为必填项，表示查询[start_time，end_time]之间的结果，最多1次只能查询1年（366天）的靠港记录.</param>
        /// <param name="end_time">结束时间：必填，历史靠港记录结束时间，unix 时间戳。</param>
        /// <param name="type">查询类型：选填，查询类型（选填）。1，按照ATA（到港时间）查询；2，按照ATD（离港时间）查询。默认值：1</param>
        /// <param name="time_zone">时区：选填，时间类型(选填)。 1当地时区，如果不存在，使用零时区；2北京时区；3零时区，即格林尼治平均时。默认值：2。</param>
        /// <returns></returns>
        public static async Task<string> GetPortofCallByPort(string key, string port_code, int start_time, int end_time, int type = 1, int time_zone = 2)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "port_code", port_code },
                { "start_time", start_time },
                { "end_time", end_time },
                { "type", type },
                { "time_zone", time_zone },
            };
            return await getMethod("GetPortofCallByPort", parameters);
        }

        /// <summary>
        /// 5航线规划-5.1点到点航线规划
        /// https://hiiau7lsqq.feishu.cn/wiki/A3UBwJ7pViozTskSFwPcJ4Ldnze
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="start_point">起始点：必填，出发的位置点，lng,lat</param>
        /// <param name="end_point">结束点：必填，到达的位置点，lng,lat</param>
        /// <param name="avoid">绕航节点：非必填，需要避让的节点，id详见附录7 。绕航多节点时，不同id之间使用逗号分隔；不填则不绕航；一次请求绕航的节点控制在10个以内。</param>
        /// <param name="through">查询类型：非必填，必经的点，lng,lat - lng,lat；多点之间用“-”连接；不填则不必经；一次请求途经的节点控制在30个以内。</param>
        /// <returns></returns>
        public static async Task<string> PlanRouteByPoint(string key, string start_point, string end_point, string? avoid = null, string? through = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "start_point", start_point },
                { "end_point", end_point },
            };
            if (avoid != null) parameters.Add("avoid", avoid);
            if (through != null) parameters.Add("through", through);
            return await getMethod("PlanRouteByPoint", parameters);
        }

        /// <summary>
        /// 5航线规划-5.2港到港航线规划
        /// https://hiiau7lsqq.feishu.cn/wiki/NpsbwNzWWiJRy2k79bscVljTntd
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="start_port_code">起始港：必填，出发港PortCode港口标准五位码</param>
        /// <param name="end_port_code">结束港：必填，到达港PortCode港口标准五位码</param>
        /// <param name="avoid">绕航节点：非必填，需要避让的节点，id详见附录7 。绕航多节点时，不同id之间使用逗号分隔；不填则不绕航；一次请求绕航的节点控制在10个以内。</param>
        /// <param name="through">查询类型：非必填，必经的点，lng,lat - lng,lat；多点之间用“-”连接；不填则不必经；一次请求途经的节点控制在30个以内。</param>
        /// <returns></returns>
        public static async Task<string> PlanRouteByPort(string key, string start_port_code, string end_port_code, string? avoid = null, string? through = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "start_port_code", start_port_code },
                { "end_port_code", end_port_code },
            };
            if (avoid != null) parameters.Add("avoid", avoid);
            if (through != null) parameters.Add("through", through);
            return await getMethod("PlanRouteByPort", parameters);
        }

        /// <summary>
        /// 5航线规划-5.3预计到达时间(ETA)查询
        /// https://hiiau7lsqq.feishu.cn/wiki/NMxnw8fEHiRhrPkIpwTcovdfnOg
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="mmsi">船舶mmsi编号：必填，船舶mmsi编号，9 位数字</param>
        /// <param name="port_code">港口标准code：非必填，港口标准CODE值，可以使用港口查询API获取。如果此处不填写港口，则默认查询船舶在AIS中填写的下一目的港口。</param>
        /// <param name="speed">设定船速：非必填，船舶在接下来的航行中维持的速度，单位：节。如果此处不填写，则默认按照船舶近一个月的平均航速来计算预计到达，平均航速是去掉在港口地区锚泊的船速信息后计算的平均值。</param>
        /// <returns></returns>
        public static async Task<string> GetSingleETAPrecise(string key, int mmsi, string? port_code = null, double? speed = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "mmsi", mmsi },
            };
            if (port_code != null) parameters.Add("port_code", port_code);
            if (speed != null) parameters.Add("speed", speed);
            return await getMethod("GetSingleETAPrecise", parameters);
        }

        /// <summary>
        /// 6气象天气-6.1单点海洋气象
        /// https://hiiau7lsqq.feishu.cn/wiki/AFfAwtwc1ifij6k5JQ9c2u3hnbh
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="lng">经度：必填，WGS84坐标系，格式为lng=155.2134。</param>
        /// <param name="lat">纬度：必填，WGS84坐标系，格式为lat=20.2134。</param>
        /// <param name="weather_time">时间：非必填，utc时间，Unix时间戳。不填写则查询最近时间的气象数据。</param>
        /// <returns></returns>
        public static async Task<string> GetWeatherByPoint(string key, double lng, double lat, int? weather_time = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "lng", lng },
                { "lat", lat },
            };
            if (weather_time != null) parameters.Add("weather_time", weather_time);
            return await getMethod("GetWeatherByPoint", parameters);
        }

        /// <summary>
        /// 6气象天气-6.2海区气象
        /// https://hiiau7lsqq.feishu.cn/wiki/EEdPwP4kqi10qjkehH5cmK2Onwc
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="weather_type">区域类型：必填，查询区域的类型：0：全部；1：沿岸；2：近海；3：远海。</param>
        /// <returns></returns>
        public static async Task<string> GetWeather(string key, int weather_type)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "weather_type", weather_type },
            };
            return await getMethod("GetWeather", parameters);
        }

        /// <summary>
        /// 6气象天气-6.3全球台风-获取全球台风列表
        /// https://hiiau7lsqq.feishu.cn/wiki/PuWSw4Nteir49WkMccMcryjNnbp
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <returns></returns>
        public static async Task<string> GetAllTyphoon(string key)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
            };
            return await getMethod("GetAllTyphoon", parameters);
        }

        /// <summary>
        /// 6气象天气-6.3全球台风-获取单个台风信息
        /// https://hiiau7lsqq.feishu.cn/wiki/PuWSw4Nteir49WkMccMcryjNnbp
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="typhoon_id">台风序号：必填，通过查询台风列表获得</param>
        /// <returns></returns>
        public static async Task<string> GetSingleTyphoon(string key, int typhoon_id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "typhoon_id", typhoon_id }
            };
            return await getMethod("GetSingleTyphoon", parameters);
        }

        /// <summary>
        /// 6气象天气-6.4国内港口潮汐-查询国内潮汐观测站列表
        /// https://hiiau7lsqq.feishu.cn/wiki/Ayoiw98eSi0PrpkZnLnclCy8nzd
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <returns></returns>
        public static async Task<string> GetTides(string key)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
            };
            return await getMethod("GetTides", parameters);
        }

        /// <summary>
        /// 6气象天气-6.4国内港口潮汐-查询单个观测站潮汐详情
        /// https://hiiau7lsqq.feishu.cn/wiki/Ayoiw98eSi0PrpkZnLnclCy8nzd
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="port_code">潮汐观测站id：必填，港口潮汐观测站id</param>
        /// <param name="start_date">起始日期：必填，查询潮汐起始日期（2022-09-26），支持从2020年开始往后的历史数据查询。</param>
        /// <param name="end_date">结束日期：必填，查询潮汐结束日期（2022-10-03）</param>
        /// <returns></returns>
        public static async Task<string> GetTideData(string key, int port_code, string start_date, string end_date)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "port_code", port_code },
                { "start_date", start_date },
                { "end_date", end_date }
            };
            return await getMethod("GetTideData", parameters);
        }

        /// <summary>
        /// 8海事数据-8.1航行警告查询
        /// https://hiiau7lsqq.feishu.cn/wiki/DCgdwVip5ifCpAkQ3lfcq8OEnOc
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="start_time">开始时间：必填，筛选航行警告发布时间。</param>
        /// <param name="end_time">结束时间：必填，筛选航行警告发布时间</param>
        /// <param name="warning_type">警告类型：非必填，警告类型筛选，默认是0，返回全部类型。1军事任务，2船舶演习，3实弹射击，4船舶作业，5航标动态，6船舶搁浅，7船舶试航，8沉没，9人员伤亡，10施工作业，11撤销航警，12其他</param>
        /// <returns></returns>
        public static async Task<string> GetNavWarning(string key, string start_time, string end_time, int warning_type = 0)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "start_time", start_time },
                { "end_time", end_time },
                { "warning_type", warning_type }
            };
            return await getMethod("GetNavWarning", parameters);
        }

        /// <summary>
        /// 9监控推送-9.1监控船队管理-设置监控船舶列表-创建船队
        /// https://hiiau7lsqq.feishu.cn/wiki/A3UBwJ7pViozTskSFwPcJ4Ldnze
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="fleet_name">船队名称：必填，为您创建的船队起名，用来后续查询和区分</param>
        /// <param name="mmsis">船舶清单：必填，添加船队下管理的船舶信息，输入多个mmsi编号，用英文逗号隔开</param>
        /// <param name="monitor">监控内容：必填，选择船队进行监控的内容，1代表船队船舶查询；2代表船位实时推送；3代表船舶到离事件推送；4代表动态ETA推送；5代表AIS异常事件推送；6代表区域监控推送；7代表船舶搭靠事件推送。多选以英文逗号隔开。</param>
        /// <returns></returns>
        public static async Task<string> AddFleet(string key, string fleet_name, string mmsis, int monitor = 0)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "fleet_name", fleet_name },
                { "mmsis", mmsis },
                { "monitor", monitor }
            };
            return await getMethod("AddFleet", parameters);
        }

        /// <summary>
        /// 9监控推送-9.1监控船队管理-设置监控船舶列表-创建船队
        /// https://hiiau7lsqq.feishu.cn/wiki/A3UBwJ7pViozTskSFwPcJ4Ldnze
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="fleet_id">船队id：必填，船队的ID，用来对船队信息进行维护的唯一标识。</param>
        /// <param name="parameters">
        /// fleet_name 船队名称：非必填，输入名称则更新船队名称
        /// mmsis 船舶清单：非必填，批量更新船队船舶信息，输入船舶mmsi编号，以英文逗号隔开。覆盖式全量更新，不做单独的增加和减少。
        /// monitor 监控内容：非必填，变更船队进行监控的内容，1代表船队船舶查询；2代表船位实时推送；3代表船舶到离事件推送；4代表动态ETA推送；5代表AIS异常事件推送；6代表区域监控推送；7代表船舶搭靠事件推送。多选以英文逗号隔开。覆盖式全量更新，不做单独的增加和减少。
        /// </param>
        /// <returns></returns>
        public static async Task<string> UpdateFleet(string key, string fleet_id, Dictionary<string, object> parameters)
        {
            if (parameters == null) return "Parameters cannot be null.";
            parameters.Add("key", key);
            parameters.Add("fleet_id", fleet_id);

            return await getMethod("UpdateFleet", parameters);
        }

        /// <summary>
        /// 9监控推送-9.1监控船队管理-设置监控船舶列表-查询船队
        /// https://hiiau7lsqq.feishu.cn/wiki/A3UBwJ7pViozTskSFwPcJ4Ldnze
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="fleet_id">船队id：必填，船队的ID，用来对船队信息进行维护的唯一标识。</param>
        /// <returns></returns>
        public static async Task<string> GetFleet(string key, string fleet_id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "fleet_id", fleet_id },
            };
            return await getMethod("GetFleet", parameters);
        }

        /// <summary>
        /// 9监控推送-9.1监控船队管理-设置监控船舶列表-删除船队
        /// https://hiiau7lsqq.feishu.cn/wiki/A3UBwJ7pViozTskSFwPcJ4Ldnze
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="fleet_id">船队id：必填，船队的ID，用来对船队信息进行维护的唯一标识。</param>
        /// <returns></returns>
        public static async Task<string> DeleteFleet(string key, string fleet_id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "fleet_id", fleet_id },
            };
            return await getMethod("DeleteFleet", parameters);
        }

        /// <summary>
        /// 9监控推送-9.1监控船队管理-设置监控船舶列表-船队船舶增加
        /// https://hiiau7lsqq.feishu.cn/wiki/A3UBwJ7pViozTskSFwPcJ4Ldnze
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="fleet_id">船队id：必填，船队的ID，用来对船队信息进行维护的唯一标识。</param>
        /// <param name="mmsis">船舶清单：必填，添加船队管理的船舶，mmsi编号，以英文逗号隔开。增量更新，不变动原有船队船舶，输入的mmsi编号与原有重复时，新填入的不会增加到船队中。</param>
        /// <returns></returns>
        public static async Task<string> AddFleetShip(string key, string fleet_id, string mmsis)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "fleet_id", fleet_id },
                { "mmsis", mmsis }
            };
            return await getMethod("AddFleetShip", parameters);
        }

        /// <summary>
        /// 9监控推送-9.1监控船队管理-设置监控船舶列表-船队船舶批量更新
        /// https://hiiau7lsqq.feishu.cn/wiki/A3UBwJ7pViozTskSFwPcJ4Ldnze
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="fleet_id">船队id：必填，船队的ID，用来对船队信息进行维护的唯一标识。</param>
        /// <param name="mmsis">船舶清单：必填，添加船队管理的船舶，mmsi编号，以英文逗号隔开。增量更新，不变动原有船队船舶，输入的mmsi编号与原有重复时，新填入的不会增加到船队中。</param>
        /// <returns></returns>
        public static async Task<string> UpdateFleetShip(string key, string fleet_id, string mmsis)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "fleet_id", fleet_id },
                { "mmsis", mmsis }
            };
            return await getMethod("UpdateFleetShip", parameters);
        }

        /// <summary>
        /// 9监控推送-9.1监控船队管理-设置监控船舶列表-船队船舶删除
        /// https://hiiau7lsqq.feishu.cn/wiki/A3UBwJ7pViozTskSFwPcJ4Ldnze
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="fleet_id">船队id：必填，船队的ID，用来对船队信息进行维护的唯一标识。</param>
        /// <param name="mmsis">船舶清单：必填，添加船队管理的船舶，mmsi编号，以英文逗号隔开。增量更新，不变动原有船队船舶，输入的mmsi编号与原有重复时，新填入的不会增加到船队中。</param>
        /// <returns></returns>
        public static async Task<string> DeleteFleetShip(string key, string fleet_id, string mmsis)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "fleet_id", fleet_id },
                { "mmsis", mmsis }
            };
            return await getMethod("DeleteFleetShip", parameters);
        }

        /// <summary>
        /// 9监控推送-9.4区域监控推送-区域创建
        /// https://hiiau7lsqq.feishu.cn/wiki/A3UBwJ7pViozTskSFwPcJ4Ldnze
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="area_bounds">区域范围：必填，经纬度逗号分隔，多个点减号分隔，如： （lng,lat - lng,lat - lng,lat ）经纬度数，多个经纬度坐标点必须按照顺时针或逆时针依次输入。</param>
        /// <param name="area_name">区域名称：必填，为您创建的区域起名，用来后续查询和区分</param>
        /// <param name="url">推送url：必填，推送的url地址，触发监控条件时候向这个url地址推送数据。</param>
        /// <param name="filter_type">筛选类型：必填，区域筛选监控的类型，1代表全部船舶，2代表根据船舶类型和长度筛选匹配，3代表船队船舶。选择1的时候，不需要输入船舶类型、长度和船队id，输入也不会保存；选择2的时候，船舶类型和船舶长度为必填；选择3的时候，船队id为必填。</param>
        /// <param name="parameters1">
        /// ship_type 船舶类型：非必填，区域监控船舶的类型，根据船舶类型筛选监控并推送，多个类型使用英文逗号隔开，不填则全选。船舶类型列表请参考开发文档附录。
        /// length 船舶长度：非必填，区域监控船舶长度，根据船舶的长度筛选并推送，多个长度使用英文逗号隔开，不填则全选。1，代表0-40米；2，代表40-80米；3，代表80-160米；4，代表160-240米；5，代表240-320米；6，代表320米以上。
        /// fleet_id 船队id：非必填，区域监控船队，如果只想监控某一只或一批船舶在区域的进出情况。可以创建船队，输入fleet_id则会监控船队下所有船舶。填入此参数则不会再使用ship_type监控船只，只监控船队船舶。
        /// </param>
        /// <returns></returns>
        public static async Task<string> AddArea(string key, string area_bounds, string area_name, string url, int filter_type, Dictionary<string, object> parameters1)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "area_bounds", area_bounds },
                { "area_name", area_name },
                { "url", url },
                { "filter_type", filter_type },
            };

            foreach (var kvp in parameters1)
            {
                parameters[kvp.Key] = kvp.Value; // 存在则覆盖，不存在则添加
            }

            return await getMethod("AddArea", parameters);
        }

        /// <summary>
        /// 9监控推送-9.4区域监控推送-区域更新
        /// https://hiiau7lsqq.feishu.cn/wiki/A3UBwJ7pViozTskSFwPcJ4Ldnze
        /// </summary>
        /// <param name="key">授权码：必填，船讯网授权码，验证服务权限</param>
        /// <param name="area_id">区域的ID：必填，区域的id，唯一标识，用来后续对区域的删改查</param>
        /// <param name="parameters1">
        /// area_bounds 区域范围：必填，经纬度逗号分隔，多个点减号分隔，如： （lng,lat - lng,lat - lng,lat ）经纬度数，多个经纬度坐标点必须按照顺时针或逆时针依次输入。
        /// area_name 区域名称：必填，为您创建的区域起名，用来后续查询和区分。
        /// url 推送url：必填，推送的url地址，触发监控条件时候向这个url地址推送数据。
        /// filter_type 筛选类型：必填，区域筛选监控的类型，1代表全部船舶，2代表根据船舶类型和长度筛选匹配，3代表船队船舶。选择1的时候，不需要输入船舶类型、长度和船队id，输入也不会保存；选择2的时候，船舶类型和船舶长度为必填；选择3的时候，船队id为必填。
        /// ship_type 船舶类型：非必填，区域监控船舶的类型，根据船舶类型筛选监控并推送，多个类型使用英文逗号隔开，不填则全选。船舶类型列表请参考开发文档附录。
        /// length 船舶长度：非必填，区域监控船舶长度，根据船舶的长度筛选并推送，多个长度使用英文逗号隔开，不填则全选。1，代表0-40米；2，代表40-80米；3，代表80-160米；4，代表160-240米；5，代表240-320米；6，代表320米以上。
        /// fleet_id 船队id：非必填，区域监控船队，如果只想监控某一只或一批船舶在区域的进出情况。可以创建船队，输入fleet_id则会监控船队下所有船舶。填入此参数则不会再使用ship_type监控船只，只监控船队船舶。
        /// </param>
        /// <returns></returns>
        public static async Task<string> UpdateArea(string key, string area_id, Dictionary<string, object> parameters1)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "area_id", area_id },
            };

            foreach (var kvp in parameters1)
            {
                parameters[kvp.Key] = kvp.Value; // 存在则覆盖，不存在则添加
            }

            return await getMethod("UpdateArea", parameters);
        }

        /// <summary>
        /// 9监控推送-9.4区域监控推送-区域查询
        /// https://hiiau7lsqq.feishu.cn/wiki/A3UBwJ7pViozTskSFwPcJ4Ldnze
        /// </summary>
        /// <param name="key"></param>
        /// <param name="area_id"></param>
        /// <returns></returns>
        public static async Task<string> GetArea(string key, string area_id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "area_id", area_id },
            };

            return await getMethod("GetArea", parameters);
        }

        /// <summary>
        /// 9监控推送-9.4区域监控推送-区域删除
        /// https://hiiau7lsqq.feishu.cn/wiki/A3UBwJ7pViozTskSFwPcJ4Ldnze
        /// </summary>
        /// <param name="key"></param>
        /// <param name="area_id"></param>
        /// <returns></returns>
        public static async Task<string> DeleteArea(string key, string area_id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "key", key },
                { "area_id", area_id },
            };

            return await getMethod("DeleteArea", parameters);
        }
    }
}