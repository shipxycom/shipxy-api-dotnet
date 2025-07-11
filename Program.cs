using System;
using System.Net.Http;
using System.Threading.Tasks;
using ShipxyApi;

class Program
{
    static string apiKey = "484db43a65ec4f87b5b4dcc69e586bf7";

    static async Task Main(string[] args)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "mmsi", 477172700 }
            };

        // string responseBody = await Shipxy.SearchShip(apiKey, "coco", 2);
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
        string responseBody = await Shipxy.UpdateFleet(apiKey, "c5832314-4aa4-4fd1-af30-8d32bf4829c0", parameters1);

        Console.WriteLine(responseBody);
    }
}