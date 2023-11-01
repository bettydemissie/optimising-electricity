// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

    public class RouteData
    {
        public List<Route> routes { get; set; }
    }

    public class VehicleData
    {
        public List<Vehicle> vehicles { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string jsonFilePath = "routes.json";
            string jsonText = File.ReadAllText(jsonFilePath);

            RouteData data = JsonConvert.DeserializeObject<RouteData>(jsonText);

            string jsonFilePathVehicles = "vehicles.json";
            string jsonTextVehicles = File.ReadAllText(jsonFilePathVehicles);

            VehicleData vehicleData = JsonConvert.DeserializeObject<VehicleData>(jsonTextVehicles);

            var routeOptimizer = new RouteOptimizer(data.routes, vehicleData.vehicles);
            var assignedPairs = routeOptimizer.OptimizeRoutes();

            Console.WriteLine("Optimal vehicle-route pairs:");
            
            foreach (var pair in assignedPairs)
            {
                Console.WriteLine($"Route {pair.RouteId} assigned to Vehicle {pair.VehicleId}");
            }

            double totalParallelKWh = routeOptimizer.CalculateParallelConsumption(assignedPairs);
            double totalSequentialKWh = routeOptimizer.CalculateSequentialConsumptionUsingLeastEfficientVehicle();

            Console.WriteLine("Total kWh for sequential use using the least efficient vehicle: " + totalSequentialKWh);
            Console.WriteLine("Total kWh for parallel use: " + totalParallelKWh);
        }
    }
