using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

        // SearchShipResponse responseBody = await Shipxy.SearchShip(apiKey, "413961925");
        // Console.WriteLine(responseBody?.Data?[0].ShipName);
        // SingleShipResponse responseBody = await Shipxy.GetSingleShip(apiKey, 413961925);
        // Console.WriteLine(responseBody?.Data?.ShipCnname);
        // ManyShipResponse responseBody = await Shipxy.GetManyShip(apiKey, "413961925,477232800,477172700");
        // Console.WriteLine(responseBody?.Data?[0].ShipName);
        // FleetShipResponse responseBody = await Shipxy.GetFleetShip(apiKey, "7c9f50b4-fdac-4935-97b4-bf301a24bd90");
        // Console.WriteLine(responseBody?.Data?[0].ShipName);
        // SurRoundingShipResponse responseBody = await Shipxy.GetSurRoundingShip(apiKey, 413961925);
        // Console.WriteLine(responseBody?.Data?[0].ShipName);
        // AreaShipResponse responseBody = await Shipxy.GetAreaShip(apiKey, "121.289063,35.424868-122.783203,35.281501-122.167969,33.979809");
        // Console.WriteLine(responseBody?.Data?.ShipList?[0].ShipName);
        // ShipRegistryResponse responseBody = await Shipxy.GetShipRegistry(apiKey, 413961925);
        // Console.WriteLine(responseBody?.Data?.Registry);
        // SearchShipParticularResponse responseBody = await Shipxy.SearchShipParticular(apiKey, parameters);
        // Console.WriteLine(responseBody?.Data?[0].ShipName);
        // Console.WriteLine(responseBody?.Data?[0]?.MainEngineList?[0].Designer);


        // SearchPortResponse responseBody = await Shipxy.SearchPort(apiKey, "qingdao", 2);
        // Console.WriteLine(responseBody?.Data?[0].PortCnName);
        // GetBerthShipsResponse responseBody = await Shipxy.GetBerthShips(apiKey, "CNSHG", 90);
        // Console.WriteLine(responseBody?.Data?[0].ShipName);
        // GetAnchorShipsResponse responseBody = await Shipxy.GetAnchorShips(apiKey, "CNSHG", 90);
        // Console.WriteLine(responseBody?.Data?[0].ShipName);
        // GetETAShipsResponse responseBody = await Shipxy.GetETAShips(apiKey, "CNSHG", 1746612218, 1747044218);
        // Console.WriteLine(responseBody?.Msg);

        // GetShipTrackResponse responseBody = await Shipxy.GetShipTrack(apiKey, 477172700, 1746612218, 1747044218);
        // Console.WriteLine(responseBody?.Data?[0].Utc);
        // SearchShipApproachResponse responseBody = await Shipxy.SearchshipApproach(apiKey, 477172700, 1746612218, 1747044218);
        // Console.WriteLine(responseBody?.Data?.ShipData?.ShipName);
        // Console.WriteLine(responseBody?.Data?.ApproachData?[0]?.ApproachShip?.ShipName);
        // Console.WriteLine(responseBody?.Data?.ApproachData?[0]?.ApproachEvent?.Position);

        // GetPortOfCallByShipResponse responseBody = await Shipxy.GetPortofCallByShip(apiKey, parameters, 1751007589, 1751440378);
        // Console.WriteLine(responseBody?.Data?[0].ShipName);
        // GetPortOfCallByShipPortResponse responseBody = await Shipxy.GetPortofCallByShipPort(apiKey, parameters, "CNSHG", 1751007589, 1751440378);
        // Console.WriteLine(responseBody?.Data?[0].ShipName);
        // GetShipStatusResponse responseBody = await Shipxy.GetShipStatus(apiKey, parameters);
        // Console.WriteLine(responseBody?.Data?[0].ShipName);
        // GetPortOfCallByPortResponse responseBody = await Shipxy.GetPortofCallByPort(apiKey, "CNSHG", 1751407589, 1751440378);
        // Console.WriteLine(responseBody?.Data?[0].ShipName);

        // PlanRouteByPointResponse responseBody = await Shipxy.PlanRouteByPoint(apiKey, "113.571144,22.844316", "121.58414,31.37979");
        // Console.WriteLine(responseBody?.Data?.Route?[0].Lng);
        // PlanRouteByPortResponse responseBody = await Shipxy.PlanRouteByPort(apiKey, "CNGZG", "CNSHG");
        // Console.WriteLine(responseBody?.Data?.Route?[0].Lng);
        // GetSingleETAPreciseResponse responseBody = await Shipxy.GetSingleETAPrecise(apiKey, 477172700, "CNSHG");
        // Console.WriteLine(responseBody?.Data?.Nextport?.PortCnname);
        // Console.WriteLine(responseBody?.Data?.Location?.SeaAreaCode);

        // GetWeatherByPointResponse responseBody = await Shipxy.GetWeatherByPoint(apiKey, 123.58414, 27.37979);
        // Console.WriteLine(responseBody?.Data?.PublishTime);
        // GetWeatherResponse responseBody = await Shipxy.GetWeather(apiKey, 1);
        // Console.WriteLine(responseBody?.Data?[0].SeaArea);
        // GetAllTyphoonResponse responseBody = await Shipxy.GetAllTyphoon(apiKey);
        // Console.WriteLine(responseBody?.Data?[0].TyphoonCnname);
        // GetSingleTyphoonResponse responseBody = await Shipxy.GetSingleTyphoon(apiKey, 2477927);
        // Console.WriteLine(responseBody?.Data?[0].TyphoonTime);
        // GetTidesResponse responseBody = await Shipxy.GetTides(apiKey);
        // Console.WriteLine(responseBody?.Data?[0].PortCnname);
        // GetTideDataResponse responseBody = await Shipxy.GetTideData(apiKey, 8000005, "2025-03-01", "2025-03-05");
        // Console.WriteLine(responseBody?.Data?.Overview?[0].TideDate);
        // Console.WriteLine(responseBody?.Data?.Detail?[0].H12);

        // GetNavWarningResponse responseBody = await Shipxy.GetNavWarning(apiKey, "2024-07-21 20:00", "2024-09-21 20:00", 1);
        // Console.WriteLine(responseBody?.Data?[0].Title);

        FleetRequest fleetRequest = new FleetRequest
        {
            FleetName = "测试船队3",
            Mmsis = "477985703,412751693",
        };

        // FleetResponse responseBody = await Shipxy.AddFleet(apiKey, fleetRequest);
        // Console.WriteLine(responseBody?.Data?.FleetId);
        // FleetResponse responseBody = await Shipxy.UpdateFleet(apiKey, "0372ec4c-eead-49ce-b005-6ffa731cc1df", fleetRequest);
        // Console.WriteLine(responseBody?.Data?.FleetId);
        // FleetResponse responseBody = await Shipxy.GetFleet(apiKey, "0372ec4c-eead-49ce-b005-6ffa731cc1df");
        // Console.WriteLine(responseBody?.Data?.FleetName);
        // BaseResponse responseBody = await Shipxy.DeleteFleet(apiKey, "756c3c46-8015-4b03-bebb-60edbf381653");
        // Console.WriteLine(responseBody?.Msg);
        // FleetResponse responseBody = await Shipxy.AddFleetShip(apiKey, "0372ec4c-eead-49ce-b005-6ffa731cc1df", "477985700,412751690");
        // Console.WriteLine(responseBody?.Data?.Mmsis);
        // FleetResponse responseBody = await Shipxy.UpdateFleetShip(apiKey, "0372ec4c-eead-49ce-b005-6ffa731cc1df", "477985700,412751690");
        // Console.WriteLine(responseBody?.Data?.Mmsis);
        // FleetResponse responseBody = await Shipxy.DeleteFleetShip(apiKey, "0372ec4c-eead-49ce-b005-6ffa731cc1df", "477985700");
        // Console.WriteLine(responseBody?.Data?.Mmsis);


        // AreaRequest areaRequest = new AreaRequest
        // {
        //     AreaBounds = "119.846180,32.345143-119.814280,32.311867-119.4661,32.291067-119.375887,32.213847",
        //     AreaName = "浙江沿海区域1",
        //     Url = "http://192.186.1.1:8000/Shipxy/testdemo",
        //     FilterType = 3,
        //     ShipType = "59",
        //     Length = "100",
        //     FleetId = "0372ec4c-eead-49ce-b005-6ffa731cc1df"
        // };
        // AreaResponse responseBody = await Shipxy.AddArea(apiKey, areaRequest);
        // Console.WriteLine(responseBody?.Data?.AreaId);

        // AreaRequest areaRequest1 = new AreaRequest
        // {
        //     AreaName = "浙江沿海区域2",
        // };;
        // AreaResponse responseBody = await Shipxy.UpdateArea(
        //     apiKey,
        //     "075451e6-0ffa-44d4-94d2-adbf17d862a5",
        //     areaRequest1
        // );
        // Console.WriteLine(responseBody?.Data?.AreaId);

        // AreaResponse responseBody = await Shipxy.GetArea(apiKey,
        //      "075451e6-0ffa-44d4-94d2-adbf17d862a5"
        // );
        // Console.WriteLine(responseBody?.Data?.AreaId);

        // BaseResponse responseBody = await Shipxy.DeleteArea(apiKey,
        //     "b7a40fa4-daae-4586-a56a-b09457331628"
        // );
        // Console.WriteLine(responseBody?.Status);

        // Console.WriteLine(JsonSerializer.Serialize(responseBody));
    }
}