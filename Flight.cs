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
    
    // Empty Constructor sets destination to empty
    public Flight() 
    {
        destinationName = "";
    }
    
    
    // Method:      "FlyTo(string)"
    // Sets up the initial command to send out the instructions to travel to a destination.
    public static IEnumerable<int> FlyTo(String destinationName)
    {
        var check = new Fiber<int>(ToFlightMaster());
        while (check.Run())
        {
            yield return 100;
        }
        
        // Interacting with the FlightMaster
        if (API.Me.Focus != null)
        {
            while (!IsFlightMapOpen())
            {
                API.Me.Focus.Interact();
                yield return 1500;
                if (!IsFlightMapOpen())
                {
                    FlightMasterGossip();
                    yield return 1000;
                }
            }
        }
        
        // Now, determine if destinationName is Known.
        if (IsFlightMapOpen())
        {
            if (IsFPKnown(destinationName))
            {
                destinationName = destinationName.Substring(0, destinationName.IndexOf(','));
                API.Print("Flying to " + destinationName + "! Yay!");
                
                yield return 5000;
                int count = 6;
                while (API.Me.IsOnTaxi)
                {
                    yield return 1000;
                    count++;
                }
                int min = count / 60;
                int seconds = count % 60;
                string minute = "minutes";
                string second = "seconds";
                if (min == 1)
                {
                    minute = "minute";
                }
                if (seconds == 1)
                {
                    second = "second";
                }
                API.Print("Player Arrived at their Destination After " + min + " " + minute + " and " + seconds + " " + second + "!");
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
        List<object> FPs = new List<object>();
        List<object> result = new List<object>();

        // Obtaining List
        FPs = getFlightMasterInfo();
        
        if (FPs.Count != 0)
        {
            float closestDistance;
            float tempDistance;
            int npcID;
            string closestZone;
            bool IsSpecialPathingNeeded;
            Vector3 closestVector3;
            Vector3 position;
        
            // Setting the initial FP to the closest distance
            closestZone = (string)FPs[0];
            closestVector3 = new Vector3((float)FPs[1], (float)FPs[2], (float)FPs[3]);
            closestDistance = API.Me.Distance2DTo(closestVector3);
            npcID = (int)FPs[4];
            IsSpecialPathingNeeded = (bool)FPs[5];
            
    
            // Filtering for Closest flight now.
            for (int i = 0; i < FPs.Count - 5; i = i + 6)
            {
                position = new Vector3((float)FPs[i + 1], (float)FPs[i + 2], (float)FPs[i + 3]);
                tempDistance = API.Me.Distance2DTo(position);
                if (tempDistance < closestDistance)
                {
                    closestDistance = tempDistance;
                    closestVector3 = position;
                    closestZone = (string)FPs[i];
                    npcID = (int)FPs[i+4];
                    IsSpecialPathingNeeded = (bool)FPs[i+5];
                }
            }
            // Creating list with the name of the closest flightpath with accompanying Vector3 position of Flightmaster
            List<object> final = new List<object>(){closestZone,closestVector3,closestDistance,npcID,IsSpecialPathingNeeded};
            result.AddRange(final);
        }
        return result;
    }
    
    
    // Filters out returns by continent
    public static List<object> getFlightMasterInfo()
    {
        List<object> result = new List<object>();
        int continentID = API.Me.ContinentID;
        int zoneID = API.Me.ZoneId;
        bool factionIsHorde = API.Me.IsHorde;
        
        // Draenor Continent
        if (continentID == 1116)
        {
            result = DraenorZones.getDraenorInfo(zoneID, factionIsHorde);
        }
        
        // All Continents Eventually to be Added
        return result;

        
    }
    
    
    // Method:      "IsFlightMapOpen()"
    public static bool IsFlightMapOpen()
	{
		return Flight.API.ExecuteLua<bool>("if TaxiNodeName(1) ~= \"INVALID\" then return true else return false end");
	}
    
    
    // Method:      "IsFPKnown(String)"
    public static bool IsFPKnown(String destinationName)
    {
        // destinationName = destinationName.Localize();
        return API.ExecuteLua<bool>("local known = false; for i=1,NumTaxiNodes() do if TaxiNodeName(i) == \"" + destinationName + "\" then known = true; TakeTaxiNode(i); break; end end return known;");
    }
    
    
    // Method:      "FlightMasterGossip()"
    // Purpose:     Often Flightmasters have a lot of different Gossip options, like say, unfinished quests,
    //              which will replace the normal gossip position on the flightmaster.  This finds the gossip option and 
    //              selects the correct one.  This also brings in compatibility for ALL clients.
    public static void FlightMasterGossip()
    {
        // Initializing Function
        string title = "title0";
        string luaCall = ("local title0,_ = GetGossipOptions(); if title0 ~= nil then return title0 else return \"nil\" end");
        string result = API.ExecuteLua<string>(luaCall);
        // Now Ready to Iterate through All Gossip Options!
        // The reason "1" is used instead of the conventional "0" is because Gossip options start at 1.
        int i = 1;
        string num = "";
        while (result != null)
        {
            if (result.Equals("Show me where I can fly.") || result.Equals("Muéstrame adónde puedo ir volando.") || result.Equals("Mostre-me para onde posso voar.") || result.Equals("Wohin kann ich fliegen?") || result.Equals("Muéstrame adónde puedo ir volando.") || result.Equals("Montrez-moi où je peux voler.") || result.Equals("Mostrami dove posso volare.") || result.Equals("Покажи, куда я могу отправиться.") || result.Equals("제가 날아갈 수 있는 곳을 알려 주십시오.") || result.Equals("告訴我可以飛往那些地方。") || result.Equals("告诉我可以飞到哪里去。"))
            {
                API.Print("Selection Found at Gossip Option " + i + ".");
                API.ExecuteLua("SelectGossipOption(" + i + ");");
                break;
            }
            else
            {
                // This builds the new string to be added into an Lua API call.
                num = i.ToString();
                title = (title.Substring(0,title.Length-1) + num);
                luaCall = ("local " + title + ",_," + luaCall.Substring(6,luaCall.Length-6));
                result = API.ExecuteLua<string>(luaCall);
                i++;
            }
        }
    }
   
    
    // Method:      "ToFlightMaster(String)"
    public static IEnumerable<int> ToFlightMaster()
    {
        List<object> result = getClosestFlight();
        
        // If Empty Result, Zone not known.
        if (result.Count == 0)
        {
            API.Print("Unfortunately the Zone Your Are in Does Not Have the Flightpaths Mapped yet!");
            API.Print("It Would Be Amazing if You Could Report Back on the Forums Your Location. Thank you!");
            yield break;
        }
        
        // Casting all the Object to Types
        string location = (string) result[0];
        Vector3 destination = (Vector3) result[1];
        float distance = (float) result[2];
        distance = (int)Math.Ceiling(distance);
        int npcID = (int) result[3];
        bool IsSpecialPathingNeeded = (bool) result[4];
        location = location.Substring(0, location.IndexOf(','));
        
        API.Print("The Closest Known Flightpath is Located at \"" + location + "\"");
        string yards = "Yards";
        // String from plural to non. QoL thing only...
        if (distance == 1)
        {
            yards = "Yard";
        }
        API.Print("Traveling Roughly " + distance + " " + yards + " to Get There...");
    
        // This is where to add special pathing considerations.
        if (IsSpecialPathingNeeded)
        {
            if (API.Me.ContinentID == 1116)
            {
                var check = new Fiber<int>(DraenorZones.doSpecialPathing());
                while (check.Run())
                {
                    yield return 100;
                }
            }
            
            // Add connections to other Classes There...
            //  else if (API.Me.ContinentID == 1)
            //  {
                
            //  }
        }

        // Ok, time to move!
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
        while(API.Me.Focus != null && !API.MoveTo(API.Me.Focus.Position))
        {
            yield return 100;
        }
    }
}