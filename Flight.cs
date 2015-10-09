// This will be the Flight Manager


public class Flight
{
    public static ReBotAPI API;
    public static Fiber<int> Fib;

    // Empty Constructor
    public Flight() { }


    public static void FlyTo(String destinationName)
    {
        getClosestFlight(destinationName);
    }

    // Method:      "GetClosestFlight(string)"
    // Purpose:     Take an Object with all FPs of a given zone, then determine
    //               which one is the closest to the player to take.
    public static List<Object> getClosestFlight(String destinationName)
    {
        List<Object> result = new List<Object>();
        List<Object> FPs = new List<Object>();

        int continentID = API.Me.ContinentID;
        int zoneID = API.Me.ZoneId;
        float closestDistance;
        float tempDistance;
        string closestZone;
        Vector3 closestVector3;
        Vector3 position;

        // Obtaining List
        FPs = getFlightMasterInfo(continentID, zoneID);

        // Setting the initial FP to the closest distance
        closestZone = (string)FPs[0];
        closestVector3 = new Vector3((float)FPs[1], (float)FPs[2], (float)FPs[3]);
        closestDistance = API.Me.DistanceTo(closestVector3);

        // Filtering for Closest flight now.
        for (int i = 0; i < FPs.Count - 4; i = i + 4)
        {
            position = new Vector3((float)FPs[i + 1], (float)FPs[i + 2], (float)FPs[i + 3]);
            tempDistance = API.Me.DistanceTo(position);
            if (tempDistance < closestDistance)
            {
                closestDistance = tempDistance;
                closestVector3 = position;
                closestZone = (string)FPs[i];
            }
        }
        result.Add(closestZone);
        result.Add(closestVector3);
        return result;
    }
    // Method:      "ToFlightMaster(String)"
    public static IEnumerable<int> ToFlightMaster(String destinationName)
    {
        yield return 100;
    }

    // Method:      "IsKnown(String)"
    public static bool IsKnown(String destinationName)
    {
        bool result = false;
        String playerName = API.Me.Name;
        String serverName = API.ExecuteLua<string>("return GetRealmName");
        String fileName = ("Settings\\" + serverName + "\\" + playerName + "\\Taxibook.json");

        // Add Code

        return result;
    }

    // Method:      "ClosestFM()"
    public static string ClosestFM()
    {
        string result = "";
        return result;
    }

    // Filters out returns by continent
    private static List<Object> getFlightMasterInfo(int continentID, int zoneID)
    {
        List<Object> result = new List<Object>();

        // Draenor Continent
        if (continentID == 1116)
        {
            DraenorZones continent = new DraenorZones(zoneID);
            return continent.AllFPs;
        }
        return result;

        // All Continents Eventually to be Added
    }
}