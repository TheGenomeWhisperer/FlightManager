// This will be the Flight Manager


public class Flight
{
    public static ReBotAPI API;
    public static Fiber<int> Fib;
    public string destinationName;
    
    // With a destination
    public Flight(string destination)
    {
        destinationName = destination;
    }
    
    // Empty Constructor sets destination to null
    public Flight() 
    {
        destinationName = "";
    }


    public static IEnumerable<int> FlyTo(String destinationName)
    {
        var check = new Fiber<int>(ToFlightMaster());
        while (check.Run())
        {
            yield return 100;
        }
        
        // Now, determine if destinationName is Known.
        if (IsKnown(destinationName))
        {
            destinationName = destinationName.Substring(0, destinationName.IndexOf(','));
            API.Print("Flying to " + destinationName + "! Yay!");
            
            // Flightpath waiting
            yield return 5000;
            int count = 5;
            while (API.Me.IsOnTaxi)
            {
                yield return 1000;
                count++;
            }
            int min = count / 60;
            int seconds = count % 60;
            if (min == 1 || seconds == 1)
            {
                if (min == 1 && seconds != 1)
                {
                    API.Print("Player Arrived at their Destination After " + min + " minute and " + seconds + " seconds!");
                }
                else if (seconds == 1 && min != 1)
                {
                    API.Print("Player Arrived at their Destination After " + min + " minutes and " + seconds + " second!");
                }
                else
                {
                    API.Print("Player Arrived at their Destination After " + min + " minute and " + seconds + " second!");                 
                }
                
            }
            else
            {
                API.Print("Player Arrived at their Destination After " + min + " minutes and " + seconds + " seconds!");              
            }

        }
        else
        {
            API.Print("Unable to Find Desired Flight destination...");
            // Create script that finds the furthest known FP and takes that...
        }
    }

    // Method:      "GetClosestFlight(string)"
    // Purpose:     Take an Object with all FPs of a given zone, then determine
    //               which one is the closest to the player to take.
    public static List<object> getClosestFlight()
    {
        List<object> result = new List<object>();
        List<object> FPs = new List<object>();

        int continentID = API.Me.ContinentID;
        int zoneID = API.Me.ZoneId;
        float closestDistance;
        float tempDistance;
        int npcID;
        string closestZone;
        Vector3 closestVector3;
        Vector3 position;

        // Obtaining List
        FPs = getFlightMasterInfo(continentID, zoneID);

        // Setting the initial FP to the closest distance
        closestZone = (string)FPs[0];
        closestVector3 = new Vector3((float)FPs[1], (float)FPs[2], (float)FPs[3]);
        closestDistance = API.Me.Distance2DTo(closestVector3);
        npcID = (int)FPs[4];
        

        // Filtering for Closest flight now.
        for (int i = 0; i < FPs.Count - 4; i = i + 5)
        {
            position = new Vector3((float)FPs[i + 1], (float)FPs[i + 2], (float)FPs[i + 3]);
            tempDistance = API.Me.Distance2DTo(position);
            if (tempDistance < closestDistance)
            {
                closestDistance = tempDistance;
                closestVector3 = position;
                closestZone = (string)FPs[i];
                npcID = (int)FPs[i+4];
            }
        }
        // Creating list with the name of the closest flightpath with accompanying Vector3 position of Flightmaster
        result.Add(closestZone);
        result.Add(closestVector3);
        result.Add(closestDistance);
        result.Add(npcID);
        return result;
    }
    
    
    // Method:      "ToFlightMaster(String)"
    public static IEnumerable<int> ToFlightMaster()
    {
        List<object> result = getClosestFlight();
        float distance = (float) result[2];
        distance = (int)Math.Ceiling(distance);
        int npcID = (int) result[3];
        string location = (string) result[0];
        location = location.Substring(0, location.IndexOf(','));
        API.Print("The Flightpath Located at \"" + location + "\" is the Closest Known FP!");
        // String from plural to non. QoL thing only...
        if (distance == 1)
        {
            API.Print("Traveling Roughly " + distance + " Yard to Get There...");
        }
        else
        {
            API.Print("Traveling Roughly " + distance + " Yards to Get There...");
        }
        
        // Ok, time to move!
        Vector3 destination = (Vector3) result[1];
        while (!API.MoveTo(destination))
        {
            yield return 100;
        }
        
        // Targeting the FlightMaster!
        foreach (var unit in API.Units)
        {
            if (unit.EntryID == npcID)
            {
                API.Me.SetFocus(unit);
                API.Me.SetTarget(unit);
                break;
            }
        }
        
        // Edging closer to FlightMaster
        while(!API.MoveTo(API.Me.Focus.Position))
        {
            yield return 100;
        }
        // Interacting with the FlightMaster
        API.Me.Focus.Interact();
        yield return 1500;
        API.ExecuteLua("GossipTitleButton1:Click()");
        yield return 1000;
    }

    // Method:      "IsKnown(String)"
    public static bool IsKnown(String destinationName)
    {
        return API.ExecuteLua<bool>("local known = false; for i=1,NumTaxiNodes() do if TaxiNodeName(i) == \"" + destinationName + "\" then known = true; TakeTaxiNode(i); break; end end return known;");
    }

    // Filters out returns by continent
    public static List<object> getFlightMasterInfo(int continentID, int zoneID)
    {
        List<object> result = new List<object>();
        bool factionIsHorde = API.Me.IsHorde;
        
        // Draenor Continent
        if (continentID == 1116)
        {
            DraenorZones continent = new DraenorZones(zoneID, factionIsHorde);
            return continent.AllFPs;
        }
        return result;

        // All Continents Eventually to be Added
    }
}