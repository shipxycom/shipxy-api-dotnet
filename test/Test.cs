using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ShipxyApi;

class Program
{   
    static string apiKey = Key.apiKey;
    // static string apiKey = "请从 API控制台 申请";

    static async Task Main(string[] args)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "mmsi", 477172700 }
            };

        string responseBody = await Shipxy.SearchShip(apiKey, "coco", 2);
        // string responseBody = await Shipxy.GetSingleShip(apiKey, 413961925);
        // string responseBody = await Shipxy.GetManyShip(apiKey, "413961925,477232800,477172700");
        // string responseBody = await Shipxy.GetFleetShip(apiKey, "c02def78-a57d-4311-bee3-1c89a018cddf");
        // string responseBody = await Shipxy.GetSurRoundingShip(apiKey, 413961925);
        // string responseBody = await Shipxy.GetAreaShip(apiKey, "121.289063,35.424868-122.783203,35.281501-122.167969,33.979809");
        // string responseBody = await Shipxy.GetShipRegistry(apiKey, 413961925);

        // string responseBody = await Shipxy.SearchShipParticular(apiKey, parameters);

        // string responseBody = await Shipxy.SearchPort(apiKey, "qingdao", 2);
        // string responseBody = await Shipxy.GetBerthShips(apiKey, "CNSHG", 90);
        // string responseBody = await Shipxy.GetAnchorShips(apiKey, "CNSHG", 90);
        // string responseBody = await Shipxy.GetETAShips(apiKey, "CNSHG", 1746612218, 1747044218);

        // string responseBody = await Shipxy.GetShipTrack(apiKey, 477172700, 1746612218, 1747044218);
        // string responseBody = await Shipxy.SearchshipApproach(apiKey, 477172700, 1746612218, 1747044218);

        // string responseBody = await Shipxy.GetPortofCallByShip(apiKey, parameters, 1751007589, 1751440378);
        // string responseBody = await Shipxy.GetPortofCallByShipPort(apiKey, parameters, "CNSHG", 1751007589, 1751440378);
        // string responseBody = await Shipxy.GetShipStatus(apiKey, parameters);
        // string responseBody = await Shipxy.GetPortofCallByPort(apiKey, "CNSHG", 1751407589, 1751440378);

        // string responseBody = await Shipxy.PlanRouteByPoint(apiKey, "113.571144,22.844316", "121.58414,31.37979");
        // string responseBody = await Shipxy.PlanRouteByPort(apiKey, "CNGZG", "CNSHG");
        // string responseBody = await Shipxy.GetSingleETAPrecise(apiKey, 477172700, "CNSHG");

        // string responseBody = await Shipxy.GetWeatherByPoint(apiKey, 123.58414, 27.37979);
        // string responseBody = await Shipxy.GetWeather(apiKey, 1);
        // string responseBody = await Shipxy.GetAllTyphoon(apiKey);
        // string responseBody = await Shipxy.GetSingleTyphoon(apiKey, 2477927);
        // string responseBody = await Shipxy.GetTides(apiKey);
        // string responseBody = await Shipxy.GetTideData(apiKey, 8000005, "2025-03-01", "2025-03-05");

        // string responseBody = await Shipxy.GetNavWarning(apiKey, "2024-07-21 20:00", "2024-09-21 20:00", 1);

        // string responseBody = await Shipxy.AddFleet(apiKey, "测试船队1", "477985700,412751691", 1);
        Dictionary<string, object> parameters1 = new Dictionary<string, object>
            {
                { "fleet_name", "fleet_name" },
                { "mmsis", "412751690" },
                { "monitor", 1 },
            };
        // string responseBody = await Shipxy.UpdateFleet(apiKey, "3e661c75-9155-43bc-a93b-6624eb7c5dc2", parameters1);
        // string responseBody = await Shipxy.GetFleet(apiKey, "3e661c75-9155-43bc-a93b-6624eb7c5dc2");
        // string responseBody = await Shipxy.DeleteFleet(apiKey, "3e661c75-9155-43bc-a93b-6624eb7c5dc2");
        // string responseBody = await Shipxy.AddFleetShip(apiKey, "f777007b-fb88-4c4c-b4eb-db33e84e99ee", "477985700,412751690");
        // string responseBody = await Shipxy.UpdateFleetShip(apiKey, "f777007b-fb88-4c4c-b4eb-db33e84e99ee", "477985700,412751690");
        // string responseBody = await Shipxy.DeleteFleetShip(apiKey, "f777007b-fb88-4c4c-b4eb-db33e84e99ee", "477985700");

        Dictionary<string, object> parameters2 = new Dictionary<string, object>
            {
                { "ship_type", "59" },
                { "length", "100" },
                { "fleet_id", "f777007b-fb88-4c4c-b4eb-db33e84e99ee" },
            };

        // string responseBody = await Shipxy.AddArea(apiKey,
        //     "119.846180,32.345143-119.814280,32.311867-119.4661,32.291067-119.375887,32.213847",
        //     "浙江沿海区域1", "http://192.186.1.1:8000/Shipxy/testdemo", 3,  parameters2
        // );

        Dictionary<string, object> parameters3 = new Dictionary<string, object>
            {
                { "area_name", "area_name" },
            };
        // string responseBody = await Shipxy.UpdateArea(apiKey,
        //     "75021d99-f552-4d93-b2d7-2b67ca9f0840",
        //     parameters3
        // );

        // string responseBody = await Shipxy.GetArea(apiKey,
        //     "75021d99-f552-4d93-b2d7-2b67ca9f0840"
        // );

        // string responseBody = await Shipxy.DeleteArea(apiKey,
        //     "75021d99-f552-4d93-b2d7-2b67ca9f0840"
        // );

        Console.WriteLine(responseBody);
    }
}