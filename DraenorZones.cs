
public class DraenorZones
{
    public static Fiber<int> Fib;
    public static bool IsSpecialPathingNeeded;
    
    // Default Constructor
    public DraenorZones() {}

    // Filters out returns by zone on the continent
    public static List<object> getDraenorInfo(int zoneID, bool factionIsHorde)
    {
        if (factionIsHorde)
        {
            // Frostfire Ridge (and caves and phases and Garrison)
            if (zoneID == 6720 || zoneID == 6868 || zoneID == 6745 || zoneID == 6849 || zoneID == 6861 || zoneID == 6864 || zoneID == 6848 || zoneID == 6875 || zoneID == 6939 || zoneID == 7005 || zoneID == 7209 || zoneID == 7004 || zoneID == 7327 || zoneID == 7328 || zoneID == 7329)
            {
                IsSpecialPathingNeeded = true;
                return getHordeFFR();
            }

            // Gorgrond (and caves and phases)
            if (zoneID == 6721 || zoneID == 6885 || zoneID == 7160 || zoneID == 7185)
            {
                return getHordeGorgrond();
            }

            // Talador (and caves and phases)
            if (zoneID == 6662 || zoneID == 6980 || zoneID == 6979 || zoneID == 7089 || zoneID == 7622)
            {
                IsSpecialPathingNeeded = true;
                return getHordeTalador();
            }

            // Spires of Arak
            if (zoneID == 6722)
            {
                return getHordeSpires();
            }

            // Nagrand (and phased caves)
            if (zoneID == 6755 || zoneID == 7124 || zoneID == 7203 || zoneID == 7204 || zoneID == 7267)
            {
                return getHordeNagrand();
            }

            // Shadowmoon Valley (and caves and phases)
            if (zoneID == 6719 || zoneID == 6976 || zoneID == 7460 || zoneID == 7083 || zoneID == 7078 || zoneID == 7327 || zoneID == 7328 || zoneID == 7329)
            {
                return getHordeSMV();
            }

            // Tanaan Jungle
            if (zoneID == 6723)
            {
                return getHordeTanaan();
            }

            // Ashran (and mine)
            if (zoneID == 6941 || zoneID == 7548)
            {
                return getHordeAshran();
            }

            // Warspear
            if (zoneID == 7333)
            {
                return getHordeWarspear();
            }

            // Stormshield
            if (zoneID == 7332)
            {
                return getHordeStormshield();
            }
        }
        else
        {
            // to be filled with Alliance destinations
        }
        
        // No matches
        List<object> result = new List<object>();
        return result;
    }

    // Return for all of these will be in the following format (XYZ = V3 coordinates):  List<object> zoneFlightInfo = {FPName,X,Y,Z,npcID, FPName,X,Y,Z,npcID, ...)
    private static List<object> getHordeStormshield()
    {
        throw new NotImplementedException();
    }

    private static List<object> getHordeWarspear()
    {
        throw new NotImplementedException();
    }

    private static List<object> getHordeAshran()
    {
        throw new NotImplementedException();
    }

    private static List<object> getHordeTanaan()
    {
        throw new NotImplementedException();
    }

    private static List<object> getHordeSMV()
    {
        throw new NotImplementedException();
    }

    private static List<object> getHordeNagrand()
    {
        throw new NotImplementedException();
    }

    private static List<object> getHordeSpires()
    {
        List<object> locations = new List<object>(){"Apexis Excavation, Spires of Arak",384.3f,2444.4f,18.6f,84509,IsSpecialPathingNeeded};
        List<object> list = new List<object>(){"Axefall, Spires of Arak",-353.3f,2280.9f,29.9f,82612,IsSpecialPathingNeeded};
        locations.AddRange(list);
        
        return locations;
    }

    private static List<object> getHordeTalador()
    {
        List<object> locations = new List<object>(){"Frostwolf Overlook, Talador",4003.6f,2135.9f,116.8f,81053,IsSpecialPathingNeeded};
        List<object> list = new List<object>(){"Vol'jin's Pride, Talador",3251.7f,1594.3f,162.2f,81057,IsSpecialPathingNeeded};
        locations.AddRange(list);
        List<object> list2 = new List<object>(){"Zangarra, Talador",3410.1f,1038.6f,178.3f,80932,IsSpecialPathingNeeded};
        locations.AddRange(list2);
        List<object> list3 = new List<object>(){"Durotan's Grasp, Talador",2808.7f,2519.8f,120.7f,81058,IsSpecialPathingNeeded};
        locations.AddRange(list3);
        
        Vector3 here = new Vector3(2604.9f, 2797.0f, 242.1f);
        Vector3 here2 = new Vector3(2943.0f, 3351.9f, 53.0f);
        if ((Flight.API.Me.Distance2DTo(here) < 251 && Flight.API.Me.Position.Z > 220) || (Flight.API.Me.Level > 99 && Flight.API.Me.Distance2DTo(here2) < 430 && Flight.API.Me.Position.Z < 125))
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
                
        return locations;
    }

    private static List<object> getHordeGorgrond()
    {
        List<object> locations = new List<object>(){"Iron Docks, Gorgrond",8486.2f,1544.2f,78.9f,84700,IsSpecialPathingNeeded};
        List<object> list = new List<object>() {"Breaker's Crown, Gorgrond",6591.3f,1313.9f,64.6f,86492,IsSpecialPathingNeeded};
        locations.AddRange(list);
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
        
        return locations;
    }

    private static List<object> getHordeFFR()
    {
        List<object> locations = new List<object>(){"Frostwall Garrison, Frostfire Ridge",5579.5f,4565.3f,136.2f,79407,IsSpecialPathingNeeded};
        List<object> list = new List<object>(){"Stonefang Outpost, Frostfire Ridge",6157.6f,5052.4f,134.3f,76879,IsSpecialPathingNeeded};
        locations.AddRange(list);
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
        
        return locations;
    }
    
    public static IEnumerable<int> doSpecialPathing()
    {
        int zoneID = Flight.API.Me.ZoneId;
        
        // TALADOR ZONE SPECIAL PATHING!!!!!
        //
        //
        // Each Special condition is labeled.
        if (zoneID == 6662)
        {
            // To Navigate out of Gordal Fortress and safely get around the energy Barrier.
            // Initial logic is a positional check to see if player is inside the Fortress.
            // LOCATION 1
            Vector3 gord1 = new Vector3(1410f, 1728.5f, 310.3f);
            if (Flight.API.Me.Distance2DTo(gord1) < 390)
            {
                Vector3 gord2 = new Vector3(1666.5f, 1743.6f, 298.6f);
                if ((Flight.API.Me.Position.Z > 302.4) || ((Flight.API.Me.Position.Z > 296.0) && (Flight.API.Me.Distance2DTo(gord2) > 47.05)))
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
            if (Flight.API.Me.Distance2DTo(zang1) < 302 && Flight.API.Me.Distance2DTo(zang2) > 75)
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
                
                while (Flight.API.Me.Distance2DTo(zang7) < 30)
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
            if (Flight.API.Me.Distance2DTo(arsenal) < 15)
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
            if (Flight.API.Me.Level > 99 && Flight.API.Me.Distance2DTo(shatt2) < 430 && Flight.API.Me.Position.Z < 125)
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
            
            
            // Additional Talador pathing issues to be added here...
            
        }
        // End Talador
        
        yield return 100;
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
                    while(unit.Position.Z > (startZ + 1.0)) 
                    {
                        yield return 100;
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
    
    
    
    
    
    
    
    
    
}


