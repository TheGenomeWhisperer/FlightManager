/*  FlightManager
|   Author: @Sklug  aka TheGenomeWhisperer
|
|   To Be Used with "Flight.cs" and "Localization.cs" class
|   For use in collaboration with the Rebot API 
|
|   Last Update: June 1st, 2016
*/


public class DraenorZones
{
    public static Fiber<int> Fib;
    public static bool IsSpecialPathingNeeded;
    
    // Default Constructor
    public DraenorZones() {}

    // Filters out returns by zone on the continent
    public static List<object> getDraenorInfo(int zoneID, bool factionIsHorde)
    {
        // Frostfire Ridge (and caves and phases and Garrison)
        if (zoneID == 6720 || zoneID == 6868 || zoneID == 6745 || zoneID == 6849 || zoneID == 6861 || zoneID == 6864 || zoneID == 6848 || zoneID == 6875 || zoneID == 6939 || zoneID == 7005 || zoneID == 7209 || zoneID == 7004 || zoneID == 7327 || zoneID == 7328 || zoneID == 7329)
        {
            IsSpecialPathingNeeded = true;
            return getFFR(factionIsHorde);
        }

        // Gorgrond (and caves and phases)
        if (zoneID == 6721 || zoneID == 6885 || zoneID == 7160 || zoneID == 7185)
        {
            IsSpecialPathingNeeded = true;
            return getGorgrond(factionIsHorde);
        }

        // Talador (and caves and phases)
        if (zoneID == 6662 || zoneID == 6980 || zoneID == 6979 || zoneID == 7089 || zoneID == 7622)
        {
            IsSpecialPathingNeeded = true;
            return getTalador(factionIsHorde);
        }

        // Spires of Arak
        if (zoneID == 6722)
        {
            return getSpires(factionIsHorde);
        }

        // Nagrand (and phased caves)
        if (zoneID == 6755 || zoneID == 7124 || zoneID == 7203 || zoneID == 7204 || zoneID == 7267)
        {
            IsSpecialPathingNeeded = true;
            return getNagrand(factionIsHorde);
        }

        // Shadowmoon Valley (and caves and phases)
        if (zoneID == 6719 || zoneID == 6976 || zoneID == 7460 || zoneID == 7083 || zoneID == 7078 || zoneID == 7327 || zoneID == 7328 || zoneID == 7329)
        {
            return getSMV(factionIsHorde);
        }

        // Tanaan Jungle
        if (zoneID == 6723)
        {
            return getTanaan(factionIsHorde);
        }

        // Ashran (and mine)
        if (zoneID == 6941 || zoneID == 7548)
        {
            IsSpecialPathingNeeded = true;
            return getAshran(factionIsHorde);
        }

        // Warspear
        if (zoneID == 7333)
        {
            return getWarspear(factionIsHorde);
        }
        
        // No matches
        List<object> result = new List<object>();
        return result;
    }

    // Return for all of these will be in the following format (XYZ = V3 coordinates):  List<object> zoneFlightInfo = {FPName,X,Y,Z,npcID, FPName,X,Y,Z,npcID, ...)
    private static List<object> getWarspear(bool factionIsHorde)
    {
        List<object> locations = new List<object>();
        if (factionIsHorde)
        {
            List<object> list0 = new List<object>(){"Warspear, Ashran",5312.5f,-3980.3f,18.2f,86049,IsSpecialPathingNeeded};
            locations.AddRange(list0);
        }
        else
        {
            // Insert Alliance locations here.
        }
        return locations;  
    }

    private static List<object> getAshran(bool factionIsHorde)
    {
        List<object> locations = new List<object>();
        if (factionIsHorde)
        {
            List<object> list0 = new List<object>(){"Warspear, Ashran",5312.5f,-3980.3f,18.2f,86049,IsSpecialPathingNeeded};
            locations.AddRange(list0);
        }
        else
        {
            // Insert Alliance locations here.
        }
        return locations;
    }

    private static List<object> getTanaan(bool factionIsHorde)
    {
        List<object> locations = new List<object>();
        if (factionIsHorde)
        {
            List<object> list0 = new List<object>(){"Vol'mar, Tanaan Jungle",4304.4f,-1475.0f,79.8f,90550,IsSpecialPathingNeeded};
            locations.AddRange(list0);
            List<object> list1 = new List<object>(){"The Iron Front, Tanaan Jungle",3972.1f,1204.6f,164.7f,90552,IsSpecialPathingNeeded};
            locations.AddRange(list1);
            List<object> list2 = new List<object>(){"Sha'naari Refuge, Tanaan Jungle",3727.7f,158.0f,56.1f,92809,IsSpecialPathingNeeded};
            locations.AddRange(list2);
            List<object> list3 = new List<object>(){"Aktar's Post, Tanaan Jungle",4562.1f,338.7f,220.8f,90560,IsSpecialPathingNeeded};
            locations.AddRange(list3);
            List<object> list4 = new List<object>(){"Vault of the Earth, Tanaan Jungle",3488.4f,-769.6f,39.7f,90562,IsSpecialPathingNeeded};
            locations.AddRange(list4);
            List<object> list5 = new List<object>(){"Malo's Lookout, Tanaan Jungle",4461.8f,-572.6f,49.4f,92808,IsSpecialPathingNeeded};
            locations.AddRange(list5);
        }
        else
        {
            // Insert Alliance locations here.
        }       
        return locations;
    }

    private static List<object> getSMV(bool factionIsHorde)
    {
        List<object> locations = new List<object>();
        if (factionIsHorde)
        {
            List<object> list0 = new List<object>(){"Akeeta's Hovel, Shadowmoon Valley",659.8f,718.0f,109.5f,88584,IsSpecialPathingNeeded};
            locations.AddRange(list0);
            List<object> list1 = new List<object>(){"Exile's Rise, Shadowmoon Valley",1515.5f,-797.9f,40.9f,76850,IsSpecialPathingNeeded};
            locations.AddRange(list1);
        
            if (Flight.API.Me.Level > 99)
            {
                List<object> list2 = new List<object>(){"Socrethar's Rise, Shadowmoon Valley",-792.1f,-679.7f,105.5f,81285,IsSpecialPathingNeeded};
                locations.AddRange(list2);  
            }
            
            Vector3 smv = new Vector3(-1383.1f, -1717.4f, 109.3f);
            if (Flight.API.Me.Position.Distance(smv) < 525)
            {
                List<object> list3 = new List<object>(){"Darktide Roost, Shadowmoon Valley",-973.2f,-1731f,2.9f,83427,IsSpecialPathingNeeded};
                locations.AddRange(list3);
            }
        }
        else
        {
            // Insert Alliance locations here.
        }       
        return locations;
    }

    private static List<object> getNagrand(bool factionIsHorde)
    {
        List<object> locations = new List<object>();
        if (factionIsHorde)
        {
            List<object> list0 = new List<object>(){"Nivek's Overlook, Nagrand",2054.2f,6506.9f,32.3f,88653,IsSpecialPathingNeeded};
            locations.AddRange(list0);
            List<object> list1 = new List<object>(){"The Ring of Trials, Nagrand",3037.7f,4787.5f,127.9f,83924,IsSpecialPathingNeeded};
            locations.AddRange(list1);
            List<object> list2 = new List<object>(){"Wor'var, Nagrand",3239.8f,4590.5f,144.7f,82346,IsSpecialPathingNeeded};
            locations.AddRange(list2);
            List<object> list3 = new List<object>(){"Throne of the Elements, Nagrand",3914.6f,5126.0f,62.4f,82844,IsSpecialPathingNeeded};
            locations.AddRange(list3);
            List<object> list4 = new List<object>(){"Joz's Rylaks, Nagrand",3653.4f,5774.5f,42.6f,88668,IsSpecialPathingNeeded};
            locations.AddRange(list4);
            List<object> list5 = new List<object>(){"Rilzit's Holdfast, Nagrand",3729.4f,6467.6f,6.9f,87395,IsSpecialPathingNeeded};
            locations.AddRange(list5);
            List<object> list6 = new List<object>(){"Riverside Post, Nagrand",3094.5f,6519.5f,12.7f,82340,IsSpecialPathingNeeded};
            locations.AddRange(list6);
        }
        else
        {
            // Insert Alliance locations here.
        }  
        return locations;
    }

    private static List<object> getSpires(bool factionIsHorde)
    {
        List<object> locations = new List<object>();
        if (factionIsHorde)
        {
            List<object> list0 = new List<object>(){"Apexis Excavation, Spires of Arak",384.3f,2444.4f,18.6f,84509,IsSpecialPathingNeeded};
            locations.AddRange(list0);
            List<object> list1 = new List<object>(){"Axefall, Spires of Arak",-353.3f,2280.9f,29.9f,82612,IsSpecialPathingNeeded};
            locations.AddRange(list1);
            List<object> list2 = new List<object>(){"Veil Terokk, Spires of Arak",-395.1f,1874.7f,51.5f,84498,IsSpecialPathingNeeded};
            locations.AddRange(list2);
            List<object> list3 = new List<object>(){"Crow's Crook, Spires of Arak",128.8f,1559.3f,-1.8f,84515,IsSpecialPathingNeeded};
            locations.AddRange(list3);
            List<object> list4 = new List<object>(){"Talon Watch, Spires of Arak",-338.4f,918.5f,75.0f,84504,IsSpecialPathingNeeded};
            locations.AddRange(list4);
            List<object> list5 = new List<object>(){"Pinchwhistle Gearworks, Spires of Arak",-1569.4f,994.7f,7.5f,82511,IsSpecialPathingNeeded};
            locations.AddRange(list5);
            
            Vector3 spires = new Vector3(413.8f, 842.6f, 86.7f);
            if (Flight.API.Me.Position.Distance(spires) < 500)
            {
                List<object> list6 = new List<object>(){"Akeeta's Hovel, Shadowmoon Valley",659.8f,718.0f,109.5f,88584,IsSpecialPathingNeeded};
                locations.AddRange(list6);  
            }
        }
        else
        {
            // Insert Alliance locations here.
        }  
        return locations;  
    }

    private static List<object> getTalador(bool factionIsHorde)
    {
        List<object> locations = new List<object>();
        if (factionIsHorde)
        {
            List<object> list0 = new List<object>(){"Frostwolf Overlook, Talador",4003.6f,2135.9f,116.8f,81053,IsSpecialPathingNeeded};
            locations.AddRange(list0);
            List<object> list1 = new List<object>(){"Vol'jin's Pride, Talador",3251.7f,1594.3f,162.2f,81057,IsSpecialPathingNeeded};
            locations.AddRange(list1);
            List<object> list2 = new List<object>(){"Zangarra, Talador",3410.1f,1038.6f,178.3f,80932,IsSpecialPathingNeeded};
            locations.AddRange(list2);
            List<object> list3 = new List<object>(){"Durotan's Grasp, Talador",2808.7f,2519.8f,120.7f,81058,IsSpecialPathingNeeded};
            locations.AddRange(list3);
            
            Vector3 here = new Vector3(2604.9f, 2797.0f, 242.1f);
            Vector3 here2 = new Vector3(2943.0f, 3351.9f, 53.0f);
            if ((Flight.API.Me.Position.Distance(here) < 251 && Flight.API.Me.Position.Z > 220) || (Flight.API.Me.Level > 99 && Flight.API.Me.Position.Distance(here2) < 430 && Flight.API.Me.Position.Z < 125))
            {
                List<object> list4 = new List<object>(){"Shattrath City, Talador",2727.0f,2775.8f,242.9f,81064,IsSpecialPathingNeeded};
                locations.AddRange(list4);
            }
            
            List<object> list5 = new List<object>(){"Terokkar Refuge, Talador",2164.9f,1627.7f,131.4f,81354,IsSpecialPathingNeeded};
            locations.AddRange(list5);
            List<object> list6 = new List<object>(){"Exarch's Refuge, Talador",1726.3f,2575.4f,133.7f,81078,IsSpecialPathingNeeded};
            locations.AddRange(list6);
            List<object> list7 = new List<object>(){"Retribution Point, Talador",1379.8f,3316.4f,137.8f,81068,IsSpecialPathingNeeded};
            locations.AddRange(list7);
        }
        else
        {
            // Insert Alliance locations here.
        }  
        return locations;
    }

    private static List<object> getGorgrond(bool factionIsHorde)
    {
        List<object> locations = new List<object>();
        if (factionIsHorde)
        {
            List<object> list0 = new List<object>(){"Iron Docks, Gorgrond",8486.2f,1544.2f,78.9f,84700,IsSpecialPathingNeeded};
            locations.AddRange(list0);
            List<object> list1 = new List<object>() {"Breaker's Crown, Gorgrond",6591.3f,1313.9f,64.6f,86492,IsSpecialPathingNeeded};
            locations.AddRange(list1);
            List<object> list2 = new List<object>(){"Evermorn Springs, Gorgrond",4822.8f,1670.8f,149.0f,84495,IsSpecialPathingNeeded};
            locations.AddRange(list2);
            List<object> list3 = new List<object>(){"Bastion Rise, Gorgrond",4649.9f,1187.5f,136.9f,84508,IsSpecialPathingNeeded};
            locations.AddRange(list3);
    
            if (Flight.API.Me.Level > 99)
            {
                List<object> list4 = new List<object>(){"Skysea Ridge, Gorgrond",7597.1f,1828.0f,79.1f,85829,IsSpecialPathingNeeded};
                locations.AddRange(list4);
                List<object> list5 = new List<object>(){"Everbloom Wilds, Gorgrond",7091.7f,406.8f,112.0f,84714,IsSpecialPathingNeeded};
                locations.AddRange(list5);
                List<object> list6 = new List<object>(){"Everbloom Overlook, Gorgrond",8019.4f,-554.9f,154.8f,88757,IsSpecialPathingNeeded};
                locations.AddRange(list6);
            }
            
            if (Flight.API.IsQuestCompleted(35151))
            {
                List<object> list7 = new List<object>(){"Beastwatch, Gorgrond",5782.3f,1292.7f,107.5f,81055,IsSpecialPathingNeeded};
                locations.AddRange(list7);
            }
        }
        else
        {
            // Insert Alliance locations here.
        }  
        return locations;
    }

    private static List<object> getFFR(bool factionIsHorde)
    {
        List<object> locations = new List<object>();
        if (factionIsHorde)
        {
            List<object> list0 = new List<object>(){"Frostwall Garrison, Frostfire Ridge",5579.5f,4565.3f,136.2f,79407,IsSpecialPathingNeeded};
            locations.AddRange(list0);
            List<object> list1 = new List<object>(){"Stonefang Outpost, Frostfire Ridge",6157.6f,5052.4f,134.3f,76879,IsSpecialPathingNeeded};
            locations.AddRange(list1);
            List<object> list2 = new List<object>(){"Wor'gol, Frostfire Ridge",5988.7f,6180.9f,70.1f,76782,IsSpecialPathingNeeded};
            locations.AddRange(list2);
            List<object> list3 = new List<object>(){"Throm'Var, Frostfire Ridge",7879.6f,5560.2f,111.1f,76783,IsSpecialPathingNeeded};
            locations.AddRange(list3);
            List<object> list4 = new List<object>(){"Bloodmaul Slag Mines, Frostfire Ridge",7403.6f,4356.3f,126.4f,76787,IsSpecialPathingNeeded};
            locations.AddRange(list4);
            List<object> list5 = new List<object>(){"Darkspear's Edge, Frostfire Ridge",6600.0f,4342.5f,91.1f,78699,IsSpecialPathingNeeded};
            locations.AddRange(list5);
            List<object> list6 = new List<object>(){"Wolf's Stand, Frostfire Ridge",5830.9f,3004.1f,183.2f,87707,IsSpecialPathingNeeded};
            locations.AddRange(list6);
            List<object> list7 = new List<object>(){"Thunder Pass, Frostfire Ridge",5788.9f,2397.1f,201.4f,76784,IsSpecialPathingNeeded};
            locations.AddRange(list7);
                
            if (Flight.API.IsQuestCompleted(33657))
            {
                List<object> list8 = new List<object>(){"Bladespire Citadel, Frostfire Ridge",6754.6f,6012.5f,250.0f,76781,IsSpecialPathingNeeded};
                locations.AddRange(list8);
            }
        }
        else
        {
            // Insert Alliance locations here.
        }     
        return locations;
    }
    
    public static IEnumerable<int> doSpecialPathing()
    {
        int zoneID = Flight.API.Me.ZoneId;

        // FROSTFIRE RIDGE ZONE SPECIAL PATHING!
        if (zoneID == 6720 || zoneID == 6868 || zoneID == 6745 || zoneID == 6849 || zoneID == 6861 || zoneID == 6864 || zoneID == 6848 || zoneID == 6875 || zoneID == 6939 || zoneID == 7005 || zoneID == 7209 || zoneID == 7004 || zoneID == 7327 || zoneID == 7328 || zoneID == 7329) {
            
            Vector3 location = new Vector3(5419.3f, 4900.0f, 55.3f);
            Vector3 location2 = new Vector3(5312.3f, 5009.5f, 5.0f);
            Vector3 location3 = new Vector3(5411.1f, 5012.9f, 3f);
            
            // At the docks
            if (Flight.API.Me.Position.Distance(location2) < 90 || Flight.API.Me.Position.Distance(location3) < 40 && !Flight.API.IsInGarrison) {
                var check = new Fiber<int>(HearthToGarrison());
                while (check.Run()) {
                    yield return 100;
                }
                yield return 1000;
                if (!Flight.API.IsInGarrison) {
                    Flight.API.Print("WARNING!!! Serious mesh issues at the docks. Please move up to the garrison manually and restart.");
                }
            }
            
            // Moving up from the docks - compensating for mesh issues.
            if (Flight.API.Me.Position.Distance(location) < 200 && !Flight.API.IsInGarrison) {
                Flight.API.Print("Heading from the Shipyard Back to Your Garrison!");
                
                while (!Flight.API.MoveTo(5475.7f, 4878.2f, 76.6f)) {
                    yield return 100;
                }
                
                while (!Flight.API.MoveTo(5473.5f, 4808.1f, 113.2f)) {
                    yield return 100;
                }
                
                while (!Flight.API.MoveTo(5464.6f, 4773.1f, 124.3f)) {
                    yield return 100;
                }
                
                while (!Flight.API.MoveTo(5545.9f, 4723.0f, 151.3f)) {
                    yield return 100;
                }
                // To Pause and let mesh load.
                yield return 2500;
                
                while (!Flight.API.CTM(5564.7f, 4653.8f, 148.7f)) {
                    yield return 100;
                }
            }
            
            // If already in Garrison
            if (Flight.API.IsInGarrison)
            {
                var check = new Fiber<int>(GTownHallExit());
                while (check.Run()){
                    yield return 100;
                }
            }
        }
        
        // GORGROND ZONE SPECIAL PATHING!!!!!
        //
        else if (zoneID == 6721 || zoneID == 6885 || zoneID == 7160 || zoneID == 7185)
        {
            List<object> result = Flight.getClosestFlight();
            Vector3 tangleheart1 = new Vector3(6061.0f, 96.4f, 48.1f);
            Vector3 tangleheart2 = new Vector3(6056.4f, 95.9f, 47.9f);
            Vector3 tangleheart3 = new Vector3(5954.9f, 132.4f, 55.2f);
            Vector3 tangleheart4 = new Vector3(5977.6f, 73.6f, 53.1f);
            Vector3 tangleheart5 = new Vector3(6038.7f, 93.1f, 48.0f);
            Vector3 tangleheart6 = new Vector3(6054.0f, 98.8f, 47.7f);
            Vector3 tangleheart7 = new Vector3(5788.9f, 1273.9f, 108.5f);
            Vector3 tangleheart8 = new Vector3(5195.9f, 1555.3f, 73.6f);
            
            // Pathing to use the MOLE machine if in vicinity of the area.
            if (Flight.API.Me.Position.Distance(tangleheart1) < 300)
            {
                if (Flight.API.Me.Position.Distance(tangleheart2) > 40)
                {
                    while(!Flight.API.MoveTo(tangleheart3))
                    {
                        yield return 100;
                    }
                    while(!Flight.API.MoveTo(tangleheart4))
                    {
                        yield return 100;
                    }
                    while(!Flight.API.MoveTo(tangleheart5))
                    {
                        yield return 100;
                    }
                }
                while(!Flight.API.MoveTo(tangleheart6))
                {
                    yield return 100;
                }
                foreach (var unit in Flight.API.GameObjects)
                {
                    if (unit.EntryID == 234425)
                    {
                        while (Flight.API.Me.Position.Distance(unit.Position) > 10)
                        {
                            Flight.API.MoveTo(unit.Position);
                            yield return 100;
                            if (Flight.API.Me.Position.Distance(unit.Position) <= 10)
                            {
                                Flight.API.MoveToStop();
                            }
                        }
                        yield return 1000;
                        while (Flight.API.Me.Position.Distance(tangleheart7) > 50)
                        {
                            unit.Interact();
                            yield return 2500;
                        }
                    }
                }
            }
            
            // Position Gorgron 2 (Evermorn Springs)
            if (Flight.API.Me.Position.Distance(tangleheart8) < 25)
            {
                while(!Flight.API.MoveTo(5218.4f, 1600.5f, 73.5f))
                {
                    yield return 100;
                }
            }
            
            // Beastwatch Navigation.
            if (result[0].Equals("Beastwatch, Gorgrond")) 
            {
                while(!Flight.API.MoveTo(5786.1f, 1255.8f, 107.4f))
                {
                    yield return 100;
                }
                while(!Flight.API.MoveTo(5779.9f, 1294.9f, 107.3f))
                {
                    yield return 100;
                }
            }
        }
        
        // TALADOR ZONE SPECIAL PATHING!!!!!
        //
        // Each Special condition is labeled.
        else if (zoneID == 6662 || zoneID == 6980 || zoneID == 6979 || zoneID == 7089 || zoneID == 7622)
        {
            // To Navigate out of Gordal Fortress and safely get around the energy Barrier.
            // Initial logic is a positional check to see if player is inside the Fortress.
            // LOCATION 1
            Vector3 gord1 = new Vector3(1410f, 1728.5f, 310.3f);
            if (Flight.API.Me.Position.Distance(gord1) < 390)
            {
                Vector3 gord2 = new Vector3(1666.5f, 1743.6f, 298.6f);
                if ((Flight.API.Me.Position.Z > 302.4) || ((Flight.API.Me.Position.Z > 296.0) && (Flight.API.Me.Position.Distance(gord2) > 47.05)))
                {
                    Flight.API.Print("It Appears that You are in Gordal Fortress! Navigating Out...");
                    // Guided pathing out of Gordal Fortress
                    Vector3 gord3 = new Vector3(1645.4f, 1767.4f, 312.5f);
                    Vector3 gord4 = new Vector3(1674.5f, 1729.1f, 291.4f);
                    while (!Flight.API.MoveTo(gord3))
                    {
                        yield return 100;
                    }
                    Flight.API.Print("Let's Avoid that Energy Barrier!");
                    while(!Flight.API.CTM(gord4))
                    {
                        yield return 100;
                    }
                    Flight.API.Print("Alright! Back on Track!!!");
                }
                yield break;
            }
            
            // Navigate out of Zangarra Properly.
            // LOCATION 2
            Vector3 zang1 = new Vector3(3187.2f, 788.7f, 77.7f);
            Vector3 zang2 = new Vector3(3035.2f,  954.0f,  105.5f);
            if (Flight.API.Me.Position.Distance(zang1) < 302 && Flight.API.Me.Position.Distance(zang2) > 75)
            {
                Flight.API.Print("Let's First Get Out of Zangarra!");
                // These quick 'Z' height checks are for some tight turns the mesh sometimes handles poorly.
                if (Flight.API.Me.Position.Z < 17)
                {
                    Vector3 zang3 = new Vector3(3316.2f, 950.4f, 17.4f);
                    while(!Flight.API.MoveTo(zang3))
                    {
                        yield return 100;
                    }
                }
                if (Flight.API.Me.Position.Z < 32)
                {
                    Vector3 zang4 = new Vector3(3286.9f, 1013.4f, 38.1f);
                    while(!Flight.API.MoveTo(zang4))
                    {
                        yield return 100;
                    }
                }
                if (Flight.API.Me.Position.Z < 44)
                {
                    Vector3 zang5 = new Vector3(3206.1f, 918.8f, 42.2f);
                    while(!Flight.API.MoveTo(zang5))
                    {
                        yield return 100;
                    }
                }
                Vector3 zang6 = new Vector3(3198.8f, 836.9f, 83.2f);
                while(!Flight.API.MoveTo(zang6))
                {
                    yield return 100;
                }
                // Brief pause for aggro
                yield return 2500;
                Vector3 zang7 = new Vector3(3199.5f, 843.6f, 84.3f);
                
                while (Flight.API.Me.Position.Distance(zang7) < 30)
                {
                    foreach (var unit in Flight.API.GameObjects)
                    {
                        if (unit.EntryID == 230874)
                        {
                            while(!Flight.API.MoveTo(unit.Position))
                            {
                                yield return 100;
                            }
                            unit.Interact();
                            yield return 10000;
                        }
                    }
                }
                Flight.API.Print("Alright, Let's Continue!");
                yield break;
            }
            
            // Navigate out of Voljin's Pride Arsenal
            // LOCATION 3
            Vector3 arsenal = new Vector3(3217.1f, 1606.4f, 166.1f);
            if (Flight.API.Me.Position.Distance(arsenal) < 15)
            {
                while(!Flight.API.CTM(3226.4f, 1600.0f, 166.0f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(3241.7f, 1589.6f, 163.2f))
                {
                    yield return 100;
                }
                yield break;
            }
            
            // Navigational pathing too Shattrath City Spire Flightpath.
            // LOCATION 4
            Vector3 shatt1 = new Vector3(2604.9f, 2797.0f, 242.1f);
            Vector3 shatt2 = new Vector3(2943.0f, 3351.9f, 53.0f);
            if (Flight.API.Me.Level > 99 && Flight.API.Me.Position.Distance(shatt2) < 430 && Flight.API.Me.Position.Z < 125)
            {
                Flight.API.Print("Let's Move out of Shattrath. The elevator in the Sha'tari Market District Looks Good...");
                var check = new Fiber<int>(TakeElevator(231934,7,2687.2f,3017.5f,69.5f,2682.8f,2995.0f,233.9f));
                while (check.Run())
                {
                    yield return 100;
                }
                Flight.API.Print("Let's Get to that Flightpath and Get Out of Here!");
                yield break;
            }
            
            // Navigational pathing if up on the ledge at Telmor
            // LOCATION 5
            Vector3 Telmor = new Vector3(759.8f, 2899.7f, 208.2f);
            if (Flight.API.Me.Position.Distance(Telmor) < 50)
            {
                Flight.API.Print("Let's Take this Elevator and Get Out of Telmor!");
                var check = new Fiber<int>(TakeElevator(232027, 3, 777.6f, 2893.5f, 207.8f, 794.6f, 2912.5f, 152.0f));
                while (check.Run()) {
                    yield return 100;
                }
            }
        }
        // End Talador
        
        // NAGRAND SPECIAL PATHING!
        //
        // BEGIN
        else if (zoneID == 6755 || zoneID == 7124 || zoneID == 7203 || zoneID == 7204 || zoneID == 7267)
        {
            // Location 1
            // Overwatch Summit - near Treasure
            Vector3 overwatch1 = new Vector3(1902.1f, 4714.6f, 364.3f);
            if (Flight.API.Me.Position.Distance(overwatch1) < 15)
            {
                while(!Flight.API.CTM(1899.0f, 4692.9f, 353.5f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(1920.5f, 4662.5f, 335.9f))
                {
                    yield return 100;
                }
            }
            
            // Location 2
            // Overwatch Summit - Taking portal to the bottom
            Vector3 overwatch2 = new Vector3(1975.5f, 4683.9f, 335.9f);
            if (Flight.API.Me.Position.Distance(overwatch2) < 100)
            {
                Flight.API.Print("Since You Are at the Overwatch Summit, Let's Take the Portal to the Bottom...");
                while(!Flight.API.MoveTo(1972.1f, 4702.8f, 335.9f))
                {
                    yield return 100;
                }
                
                // Brief Pause for Aggro
                yield return 2000;
                foreach (var unit in Flight.API.GameObjects)
                {
                    if (unit.EntryID == 232562)
                    {
                        while(!Flight.API.MoveTo(unit.Position))
                        {
                            yield return 100;
                        }
                        unit.Interact();
                        yield return 2500;
                        break;
                    }
                }
                yield break;
            }
            
            // Location 3
            // Near Rare Berserk T-300 Series Mark II
            Vector3 berserk = new Vector3(2486.7f, 4941.1f, 233.8f);
            if (Flight.API.Me.Position.Distance(berserk) < 20)
            {
                while(!Flight.API.CTM(2466.9f, 4889.6f, 206.3f))
                {
                    yield return 100;
                }
                yield break;
            }
            
            // Location 4
            // Out of Lower Sabermaw - avoid some wonky mesh issues.
            Vector3 saber1 = new Vector3(2610.7f, 5124.4f, 101.3f);
            Vector3 saber2 = new Vector3(2488.1f, 5051.6f, 216.1f);
            Vector3 saber3 = new Vector3(2579.7f, 5007.9f, 166.7f);
            Vector3 saber4 = new Vector3(2609.3f, 5177.9f, 194.6f);
            Vector3 saber5 = new Vector3(2588.2f, 4994.5f, 181.6f);
            Vector3 saber7 = new Vector3(2578.0f, 5160.2f, 203.9f);
            if (Flight.API.Me.Position.Distance(saber1) < 100 && !(Flight.API.Me.Position.Distance(saber2) < 50 || Flight.API.Me.Position.Distance(saber3) < 15 
            || Flight.API.Me.Position.Distance(saber4) < 30 || Flight.API.Me.Position.Distance(saber5) < 15 || (Flight.API.Me.Position.Distance(saber7) < 50 && (Flight.API.Me.Position.Z > 180))))
            {
                while(!Flight.API.MoveTo(2603.9f, 5281.5f, 135.3f))
                {
                    yield return 100;
                }
                yield break;
            }
            
            // Location 5
            // Out of Upper Sabermaw 1
            Vector3 saber6 = new Vector3(2579.7f, 5007.9f, 166.7f);
            if (Flight.API.Me.Position.Distance(saber6) < 10)
            {
                while(!Flight.API.MoveTo(2566.0f, 5015.8f, 177.6f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2588.2f, 4994.5f, 181.6f))
                {
                    yield return 100;
                }
            }
            
            // Location 6
            // Out of Upper Sabermaw 2
            if (Flight.API.Me.Position.Distance(saber2) < 50 || Flight.API.Me.Position.Distance(saber3) < 15 || Flight.API.Me.Position.Distance(saber4) < 30 
            || Flight.API.Me.Position.Distance(saber5) < 15 || (Flight.API.Me.Position.Distance(saber7) < 50 && (Flight.API.Me.Position.Z > 180)))
            {
                Flight.API.Print("The Upper Sabermaw Area Mesh is Troublesome... Navigating a better way out.");
                while(!Flight.API.MoveTo(2606.5f, 5174.1f, 195.8f))
                {
                    yield return 100;
                }
                yield return 1000;
                Flight.API.DisableCombat = true;
                Flight.API.MountUp();
                yield return 2000;
                while(!Flight.API.MoveTo(2577.5f, 5190.9f, 197.2f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2531.8f, 5192.2f, 184.4f))
                {
                    yield return 100;
                }
                yield return 1000;
                Flight.API.DisableCombat = false;
                yield break;
            }
            
            // Location 7
            // Move Away from Treasure "Abandoned Cargo"
            Vector3 cargo = new Vector3(2641.4f, 5469f, 81.7f);
            if (Flight.API.Me.Position.Distance(cargo) < 40)
            {
                while(!Flight.API.MoveTo(2680.5f, 5504.5f, 87.3f))
                {
                    yield return 100;
                }
                yield break;
            }
            
            // Location 8
            // Move off of the slope
            Vector3 ledge1 = new Vector3(2435.9f, 5637.3f, 168.4f);
            if (Flight.API.Me.Position.Distance(ledge1) < 6)
            {
                while(!Flight.API.CTM(2426.8f, 5614.8f, 153.0f))
                {
                    yield return 100;
                }
                yield break;
            }
            
            // Location 9
            // Move off of the ledge
            Vector3 ledge2 = new Vector3(2610.4f, 5571.5f, 90.4f);
            if (Flight.API.Me.Position.Distance(ledge2) < 15)
            {
                Flight.API.Print("Wow, What are You Doing Up On This Ledge? Jumping Off...");
                while(!Flight.API.CTM(2632.6f, 5560.8f, 74.9f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2642.8f, 5540.5f, 74.9f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2649.0f, 5533.3f, 80.1f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2642.9f, 5499.3f, 81.9f))
                {
                    yield return 100;
                }
                while(!Flight.API.MoveTo(2688.6f, 5493.2f, 88.0f))
                {
                    yield return 100;
                }
                yield break;
            }
            
            // Location 10
            // Spiteleaf Thicket
            Vector3 SpiteLeaf = new Vector3(4016.6f, 4556.8f, 46.3f);
            if (Flight.API.Me.Position.Distance(SpiteLeaf) < 75)
            {
                Flight.API.Print("Let's Get Out of this Cave...");
                while(!Flight.API.CTM(4019.9f, 4560.1f, 44.0f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(4005.4f, 4544.1f, 57.4f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(3997.4f, 4534.2f, 66.1f))
                {
                    yield return 100;
                }
                yield break;
            }
            
            // Location 11
            // Dirgemire
            Vector3 dirge1 = new Vector3(4271.1f, 4513.2f, -35.5f);
            Vector3 dirge2 = new Vector3(4280.5f, 4487.6f, 7.1f);
            if (Flight.API.Me.Position.Distance(dirge1) < 50 && !(Flight.API.Me.Position.Distance(dirge2) < 20))
            {
                while(!Flight.API.MoveTo(4281.9f, 4499.6f, -36.0f))
                {
                    yield return 100;
                }
                while(!Flight.API.MoveTo(4274.1f, 4490.7f, -37.1f))
                {
                    yield return 100;
                }
                while(!Flight.API.MoveTo(4311.4f, 4392.9f, -56.7f))
                {
                    yield return 100;
                }
                while(!Flight.API.MoveTo(4267.2f, 4425.4f, 1.0f))
                {
                    yield return 100;
                }
                yield break;
            }
            
            // Location 12
            // Ironbeard's ship
            Vector3 beard1 = new Vector3(2014.0f, 7361.9f, 18.4f);
            if (Flight.API.Me.Position.Distance(beard1) < 50)
            {
                while(!Flight.API.MoveTo(2008.7f, 7343.1f, 18.6f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2017.3f, 7315.6f, -1.5f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2106.0f, 7140.9f, 0.8f))
                {
                    yield return 100;
                }
                yield break;
            }
            
            // Location 13
            // Exit Tower
            Vector3 tower1 = new Vector3(2037.9f, 7012.4f, 51.1f);
            if (Flight.API.Me.Position.Distance(tower1) < 10)
            {
                Flight.API.DisableCombat = true;
                while(!Flight.API.CTM(2032.4f, 7004.9f, 51.2f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2025.8f, 7015.4f, 44.6f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2037.8f, 7021.4f, 33.4f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2044.4f, 7010.3f, 27.3f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2035.3f, 7002.9f, 27.5f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2027.6f, 7019.1f, 15.1f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2032.9f, 7022.0f, 15.2f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2032.0f, 7021.3f, 15.3f))
                {
                    yield return 100;
                }
                while(!Flight.API.CTM(2047.6f, 7003.3f, 15.2f))
                {
                    yield return 100;
                }
                Flight.API.DisableCombat = false;
                yield break;
            }
        }
        
        // ASHRAN SPECIAL PATHING!
        //
        // BEGIN
        else if (zoneID == 6941 || zoneID == 7548)
        {
            Flight.API.Print("Woah! Let's Get Out of Ashran Before Some Alliance Find You!");
            Vector3 ash = new Vector3(5090.1f, -3982.3f, 20.8f);
            while(!Flight.API.MoveTo(ash))
            {
                yield return 100;
            }
            Vector3 ash2 = new Vector3(5141.9f, -3964.1f, 2.2f);
            while(!Flight.API.MoveTo(ash2))
            {
                yield return 100;
            }
            yield break;
        }
        
        // Enter any additional pathing.
        yield break;
    }
    
    
    // Method:          TakeElevator(int,int,float,float,float,float,float,float)
    // What it Does:    Allows the navigation of any elevator!
    // Purpose:         At times in the script, transversing an elevator effectively can be a cumbersome to program
    //                  and as such I wrote a scalable method... the only key thing needed is for the developer to
    //                  time how long it takes the elevator to go from the bottom to the top, or the other way around.
    //                  Also, the position you would like the player to exit the elevator and travel to.  The travel time
    //                  was kind of a rough solution because it appears that while on the elevator, the API freezes all return values
    //                  thus I cannot seem to get an accurate positional check, so the timing allows me to enter, then determine exit time.
    public static IEnumerable<int> TakeElevator(int ElevatorID, int elevatorTravelTime, float startX, float startY, float startZ, float x, float y, float z) 
    {
        double position;
        double position2;
        bool elevatorFound = false;
        // Starting position to navigate to and wait for elevator (PLACE AT SAME LEVEL AS Elevator)
        Vector3 start = new Vector3(startX,startY,startZ);
        Vector3 destination = new Vector3(x,y,z);
        
        while (!Flight.API.MoveTo(start))
        {
            yield return 100;
        }
        foreach (var unit in Flight.API.GameObjects)
        {
            // This first determines if the elevator is properly identified.
        	if (unit.EntryID == ElevatorID)
        	{
                elevatorFound = true;
                Flight.API.SetFacing(unit);
                // The choice to disable combat is because once on the elevator, player should not attempt to leave it
                // or it could mess up the passing as the bot remembers its last spot before combat starts then returns to it
                Flight.API.DisableCombat = true;
                Flight.API.Print("Waiting For the Elevator...");
                position = Math.Sqrt(Flight.API.Me.DistanceSquaredTo(unit));
                yield return 100;
                position2 = Math.Sqrt(Flight.API.Me.DistanceSquaredTo(unit));
                yield return 100;
                
                // Some Added Redundancy to not attempt to take the elevator if it just arrived
                // Lest you try to hop on right before it moves away.
                while (Math.Sqrt(Flight.API.Me.DistanceSquaredTo(unit)) <= 20.0) {
                    yield return 100;
                }
                
                // The two positional checks right after each other are to determine movement of the elevator.
                // if they are equal, elevator is not moving, but if they are different, like the second location is further than the first,
                // then it can easily be determined it is moving away from you.
                // This first check holds position until the elevator moves.  This is actually really critical because what if
                // player arrives at the elevator and the elevator is at location already.  The method would recognize this then quickly try to jump on.
                // This could create a problem though because what if the elevator was only going to be there a split second more, then player tries to
                // traverse then ends up missing it.  This just helps avoid that... Long explanation I know.
                while (position == position2)
                {
                    position = Math.Sqrt(Flight.API.Me.DistanceSquaredTo(unit));
                    yield return 100;
                    position2 = Math.Sqrt(Flight.API.Me.DistanceSquaredTo(unit));
                    yield return 100;
                }
                // Meaning it is moving away from you or it is at least 10 yrds away.
                if (position != position2 || Math.Sqrt(Flight.API.Me.DistanceSquaredTo(unit)) > 10.0) 
                {
                    Flight.API.Print("Elevator is Moving...");
                    if (position > position2) 
                    {
                        Flight.API.Print("Elevator is Moving Towards Us... Almost Here!");
                    }
                    else 
                    {
                        Flight.API.Print("Elevator is Moving Away! Patience!");
                        while(position != position2) 
                        {
                            position = Math.Sqrt(Flight.API.Me.DistanceSquaredTo(unit));
                            yield return 100;
                            position2 = Math.Sqrt(Flight.API.Me.DistanceSquaredTo(unit));
                            yield return 100;
                        }
                        Flight.API.Print("Elevator Has Stopped at Other Side.  Let's Wait For It To Return!");
                        while(position == position2) 
                        {
                            position = Math.Sqrt(Flight.API.Me.DistanceSquaredTo(unit));
                            yield return 100;
                            position2 = Math.Sqrt(Flight.API.Me.DistanceSquaredTo(unit));
                            yield return 100;
                        }
                        Flight.API.Print("Alright, It Is Coming Back to us. Get Ready!");
                    }
                    // Checking position of elevator against your current position.
                    if (Flight.API.Me.Position.Z < unit.Position.Z)
                    {
                        while(unit.Position.Z > (startZ + 1.0)) 
                        {
                            yield return 100;
                        }
                    }
                    else if (Flight.API.Me.Position.Z > unit.Position.Z)
                    {
                        while(unit.Position.Z < (startZ - 1.0)) 
                        {
                            yield return 100;
                        }
                    }
                }
                Flight.API.Print("Ah, Excellent! Elevator is Here! Hop On Quick!");
                Flight.API.CTM(unit.Position);
                // The 4 seconds is added here to account for the stoppage of when you enter the elevator and it is stationary
                yield return ((elevatorTravelTime + 4) * 1000);
                while(!Flight.API.CTM(destination)) 
                {
                    yield return 200;
                }
                Flight.API.Print("You Have Successfully Beaten the Elevator Boss... Congratulations!!!");
        	}
        }
        if (!elevatorFound) 
        {
            Flight.API.Print("No Elevator Found. Please Be Sure elevator ID is Entered Properly and You are Next to It");
            yield break;
        }
        Flight.API.DisableCombat = false;
    }
    
    // Method:          "GTownHallExit()"
    // What it does:    Navigates out of a lvl 2 or 3 Garrison Town Hall (Horde)
    // Purpose:         Rebot has serious Mesh issues when starting a script within a Garrison
    //                  But, even worse, starting within a town hall.  This solves this issue
    //                  by using Click-To-Move actions to navigate out of the town hall successfully.
    //                  This is best used in the "initialization" stage of a script, or to be implemented
    //                  immediately after hearthing to the Garrison.
    public static IEnumerable<int> GTownHallExit()
    {
        int tier = Flight.API.ExecuteLua<int>("local level = C_Garrison.GetGarrisonInfo(); return level;");
        string zone = Flight.API.ExecuteLua<string>("local zone = GetMinimapZoneText(); return zone;");
        Vector3 location = new Vector3(5559.2f, 4604.8f, 141.7f);
        Vector3 location2 = new Vector3(5562.576f, 4601.484f, 141.7169f);
        Vector3 location3 = new Vector3(5576.729f, 4584.367f, 141.0846f);
        Vector3 location4 = new Vector3(5591.181f, 4569.721f, 136.2159f);
        
        if (Flight.API.Me.Position.Distance(location) < 25 && Flight.API.IsInGarrison && (tier == 2 || tier == 3))
        {
            // If I do not disable Flightmaster discovery, then it tries to run to flightmaster BEFORE executing CTM actions
            // which with the lack of a mesh, often results in the player just running helplessly into the wall with mesh errors spamming.
            Flight.API.GlobalBotSettings.FlightMasterDiscoverRange = 0.0f;
            while(Flight.API.Me.Position.Distance(location2) > 5)
            {
                Flight.API.CTM(location2);
                yield return 100;
            }
            while(Flight.API.Me.Position.Distance(location3) > 5)
            {
                Flight.API.CTM(location3);
                yield return 100;
            }
            while(Flight.API.Me.Position.Distance(location4) > 5)
            {
                Flight.API.CTM(location4);
                yield return 100;
            }
            Flight.API.GlobalBotSettings.FlightMasterDiscoverRange = 75.0f;
        }
        yield break;
    }
    
    // Method:          "HearthToGarrison()"
    // What it Does:    Exactly as described, uses the Garrison hearthstone.
    // Purpose:         Extraordinarily useful for speed.  If player needs to pickup a quest that starts in the garrison and they are not there
    //                  by adding this option it will hearth them back, likewise with turning in something.
    //                  This method is invaluable and used incredibly frequently to maximize the efficiency of player scripts and believable player
    //                  behavior.
    public static IEnumerable<int> HearthToGarrison()
    {
        // Error check to avoid use if flying
        if (Flight.API.Me.IsOnTaxi)
        {
            // Waits to use until OFF the IsOnTaxi.
            Flight.API.Print("Player is Currently on a Taxi, Please Be Patient And Enjoy the Scenery!");
            int count = 0;
            while (Flight.API.Me.IsOnTaxi)
            {
                yield return 1000;
                count++;
            }
            Flight.API.Print("Player Exited the Flightpath after " + count + " seconds!");
            yield return 1000;
        }
        
        if (!Flight.API.IsInGarrison) 
        {
            // Verifying Garrison hearthstone is not on Cooldown.
            if (Flight.API.ItemCooldown(110560) == 0) 
            {
                if (Flight.API.ExecuteLua<bool>("local name = GetFlight.temInfo(1); if name ~= nil then return true else return false end"))
                {
                    Flight.API.Print("Player is Interacting With a Vendor. Closing Window Before Attempting to Hearth, lest the Bot Will Attempt to Sell G-Hearthstone!");
                    Flight.API.ExecuteLua("CloseFlight.)");
                    yield return 1000;
                }
                
                // This is a check to verify player has moved, lest it will re-attempt to hearth.
                Vector3 startPos = Flight.API.Me.Position;
                while (Flight.API.Me.Position.Distance(startPos) < 50)
                {
                    Flight.API.Print("Hearthing to Garrison");
                    Flight.API.UseItem(110560);
                    yield return 1000;
                    // This keeps the player from attempting the next action until the Garrison hearthstone is successfully used
                    while(Flight.API.Me.IsCasting) 
                    {
                        yield return 100;
                    }
                    yield return 1000;
                    if (Flight.API.Me.Position.Distance(startPos) >= 50)
                    {
				        break;
                    }
                    else
                    {
                        Flight.API.Print("Player Failed to Hearth. Trying Again...");
                    }
                }
                // Waiting for loading screen!
                while (!Flight.API.IsInGarrison)
                {
                    yield return 1000;
                }
                // Sometimes mesh errors occur by trying to CTM because it tries as soon as loading screen goes away but maybe some assets
                // are not fully loaded in the world.  This gives a slight delay to ensure no error.  Really depends on player PC and connection.
                Flight.API.Print("One Moment, Giving Mesh a Chance to Catchup!");
                yield return 5000;
            }
            else 
            {
                // Assumedly, in instances like this, a 2ndary logic route is given as backup, either the mesh or by Flightpath.
                Flight.API.Print("Player Wanted to Hearth to Garrison, but it is on Cooldown...");
                // Apply Flight Logic soon...
                yield break;
            }
        }
        yield break;
    }
    
    // Method:          "GetEveryFlightMaster()"
    // What it Does:    Returns a massive list with every flightmaster of the entire continent and all accompanying details.
    // Purpose:         This is to parse through entire list in case the player needs to determine where to fly to.
    //                  An example of use would be:  
    //                  var check = new Fiber<int>(Flight.FlyTo(Flight.GetClosestFlightToDestination(Vector3 destination))); while (Flight.Fib.Rub() {yield return 100;})
    public static List<object> GetEveryFlightMaster()
    {
        bool isHorde = Flight.API.Me.IsHorde;
        // Adding all zones.
        List<object> result = new List<object>();
        result.AddRange(getWarspear(isHorde));
        result.AddRange(getAshran(isHorde));
        result.AddRange(getFFR(isHorde));
        result.AddRange(getGorgrond(isHorde));
        result.AddRange(getTalador(isHorde));
        result.AddRange(getSpires(isHorde));
        result.AddRange(getNagrand(isHorde));
        result.AddRange(getSMV(isHorde));
        result.AddRange(getTanaan(isHorde));
        
        return result;
    }
    
}