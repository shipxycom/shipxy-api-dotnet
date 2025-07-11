using System;
using System.Net.Http;
using System.Threading.Tasks;
using ShipxyApi;

class Program
{
    static string apiKey = "484db43a65ec4f87b5b4dcc69e586bf7";

    static async Task Main(string[] args)
    {
        // string responseBody = await Shipxy.SearchShip(apiKey, "coco", 2);
        // string responseBody = await Shipxy.GetSingleShip(apiKey, 413961925);
        // string responseBody = await Shipxy.GetManyShip(apiKey, "413961925,477232800,477172700");
        // string responseBody = await Shipxy.GetFleetShip(apiKey, "c02def78-a57d-4311-bee3-1c89a018cddf");
        // string responseBody = await Shipxy.GetSurRoundingShip(apiKey, 413961925);
        // string responseBody = await Shipxy.GetAreaShip(apiKey, "121.289063,35.424868-122.783203,35.281501-122.167969,33.979809");
        // string responseBody = await Shipxy.GetShipRegistry(apiKey, 413961925);
        // Dictionary<string, object> parameters = new Dictionary<string, object>
        //     {
        //         { "mmsi", 477172700 }
        //     };
        // string responseBody = await Shipxy.SearchShipParticular(apiKey, parameters);

        // string responseBody = await Shipxy.SearchPort(apiKey, "qingdao", 2);
        // string responseBody = await Shipxy.GetBerthShips(apiKey, "CNSHG", 90);
        // string responseBody = await Shipxy.GetAnchorShips(apiKey, "CNSHG", 90);
        string responseBody = await Shipxy.GetETAShips(apiKey, "CNSHG", 1746612218, 1747044218);
        Console.WriteLine(responseBody);
    }
}