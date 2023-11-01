using System;
using System.Collections.Generic;
using System.Linq;

public class RouteOptimizer
{
    private List<Route> routes;
    private List<Vehicle> vehicles;

    public RouteOptimizer(List<Route> routes, List<Vehicle> vehicles)
    {
        this.routes = routes;
        this.vehicles = vehicles;
    }

    public List<Assignment> OptimizeRoutes()
    {
        // Sort routes by distance in ascending order
        routes.Sort((a, b) => a.GetTotalDistance().CompareTo(b.GetTotalDistance()));

        // Sort vehicles by consumption in descending order
        vehicles.Sort((a, b) => b.kwh_per_100_km.CompareTo(a.kwh_per_100_km));

        var assignedPairs = new List<Assignment>();
        var remainingRoutes = new List<Route>(routes);
        var remainingVehicles = new List<Vehicle>(vehicles);
        
        foreach (var route in remainingRoutes)
        {
                if(remainingVehicles.Count > 0)
                {
                    assignedPairs.Add(new Assignment { RouteId = route.route_id, VehicleId = remainingVehicles.FirstOrDefault().id });
                    remainingVehicles.RemoveAt(0);
                }
                else
                {
                    Console.WriteLine("All routes could not be paired with any vehicle, NOT ENOUGH VEHICLES AVAILABLE");
                    break;
                }
        }

        return assignedPairs;
    }

    public double CalculateSequentialConsumptionUsingLeastEfficientVehicle()
    {
        var leastEfficientVehicle = vehicles.OrderByDescending(v => v.kwh_per_100_km).First();
        
        return routes.Sum(route => route.GetTotalDistance() * leastEfficientVehicle.kwh_per_100_km / 100);
    }

    public double CalculateParallelConsumption(List<Assignment> assignedPairs)
    {
        double totalConsumption = assignedPairs.Sum(pair =>
        {
            var route = routes.FirstOrDefault(r => r.route_id == pair.RouteId);
            var vehicle = vehicles.FirstOrDefault(v => v.id == pair.VehicleId);
            return route.GetTotalDistance() * vehicle.kwh_per_100_km / 100;
        });

        return Math.Round(totalConsumption, 2); // Round to 2 decimal places
    }

}

