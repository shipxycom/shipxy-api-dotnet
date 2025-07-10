using System;
using System.Net.Http;
using System.Threading.Tasks;
using ShipxyApi;

class Program
{   
    static string apiKey = "484db43a65ec4f87b5b4dcc69e586bf7";
    
    static async Task Main(string[] args)
    {   
        string responseBody = await Shipxy.SearchShip(apiKey, "coco", 2);
        // string responseBody = await Shipxy.GetSingleShip(apiKey, 413961925);
        // string responseBody = await Shipxy.GetManyShip(apiKey, "413961925,477232800,477172700");
        Console.WriteLine(responseBody);
    }
}