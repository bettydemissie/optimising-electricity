using System.Collections.Generic;

public class Route
{
    public string route_id { get; set; }
    public List<Stop> stops { get; set; }

    public double GetTotalDistance()
    {
        return stops.Sum(stop => stop.distance_km);
    }
}