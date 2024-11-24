using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

public class WaypointManager
{
    private Dictionary<string, Vec3d> waypoints = new Dictionary<string, Vec3d>();

    public void AddWaypoint(string name, Vec3d position)
    {
        waypoints[name] = position;
    }

    public Vec3d GetWaypoint(string name)
    {
        return waypoints.ContainsKey(name) ? waypoints[name] : null;
    }

    public void RemoveWaypoint(string name)
    {
        if (waypoints.ContainsKey(name))
        {
            waypoints.Remove(name);
        }
    }

    public List<string> GetAllWaypointNames()
    {
        return waypoints.Keys.ToList();
    }
}