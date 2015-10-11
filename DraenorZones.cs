
public class DraenorZones
{
    public static Fiber<int> Fib;
    public static bool IsSpecialPathingNeeded;
    public List<object> AllFPs;

    public DraenorZones(int zoneID, bool factionIsHorde)
    {
        IsSpecialPathingNeeded = false;
        AllFPs = getDraenorInfo(zoneID, factionIsHorde);      
    }

    // Filters out returns by zone on the continent
    private static List<object> getDraenorInfo(int zoneID, bool factionIsHorde)
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
        List<object> locations = new List<object>(){"Apexis Excavation, Spires of Arak",384.3f,2444.4f,18.6f,84509};
        List<object> list = new List<object>(){"Axefall, Spires of Arak",-353.3f,2280.9f,29.9f,82612};
        locations.AddRange(list);
        
        return locations;
    }

    private static List<object> getHordeTalador()
    {
        List<object> locations = new List<object>(){"Frostwolf Overlook, Talador",4003.6f,2135.9f,116.8f,81053};
        List<object> list = new List<object>(){"Vol'jin's Pride, Talador",3251.7f,1594.3f,162.2f,81057};
        locations.AddRange(list);
        List<object> list2 = new List<object>(){"Zangarra, Talador",3410.1f,1038.6f,178.3f,80932};
        locations.AddRange(list2);
        List<object> list3 = new List<object>(){"Durotan's Grasp, Talador",2808.7f,2519.8f,120.7f,81058};
        locations.AddRange(list3);
        List<object> list4 = new List<object>(){"Shattrath City, Talador",2727.0f,2775.8f,242.9f,81064};
        locations.AddRange(list4);
        List<object> list5 = new List<object>(){"Terokkar Refuge, Talador",2164.9f,1627.7f,131.4f,81354};
        locations.AddRange(list5);
        List<object> list6 = new List<object>(){"Exarch's Refuge, Talador",1726.3f,2575.4f,133.7,81078};
        locations.AddRange(list6);
                
        return locations;
    }

    private static List<object> getHordeGorgrond()
    {
        List<object> locations = new List<object>(){"Iron Docks, Gorgrond",8486.2f,1544.2f,78.9f,84700};
        List<object> list = new List<object>() {"Breaker's Crown, Gorgrond",6591.3f,1313.9f,64.6f,86492};
        locations.AddRange(list);
        List<object> list2 = new List<object>(){"Evermorn Springs, Gorgrond",4822.8f,1670.8f,149.0f,84495};
        locations.AddRange(list2);
        List<object> list3 = new List<object>(){"Bastion Rise, Gorgrond",4649.9f,1187.5f,136.9f,84508};
        locations.AddRange(list3);

        
        if (Flight.API.Me.Level > 99)
        {
            List<object> list4 = new List<object>(){"Skysea Ridge, Gorgrond",7597.1f,1828.0f,79.1f,85829};
            locations.AddRange(list4);
            List<object> list5 = new List<object>(){"Everbloom Wilds, Gorgrond",7091.7f,406.8f,112.0f,84714};
            locations.AddRange(list5);
            List<object> list6 = new List<object>(){"Everbloom Overlook, Gorgrond",8019.4f,-554.9f,154.8f,88757};
            locations.AddRange(list6);
        }
        
        if (Flight.API.IsQuestCompleted(35151))
        {
            List<object> list7 = new List<object>(){"Beastwatch, Gorgrond",5782.3f,1292.7f,107.5f,81055};
            locations.AddRange(list7);
        }
        
        return locations;
    }

    private static List<object> getHordeFFR()
    {
        List<object> locations = new List<object>(){"Frostwall Garrison, Frostfire Ridge",5579.5f,4565.3f,136.2f,79407};
        List<object> list = new List<object>(){"Stonefang Outpost, Frostfire Ridge",6157.6f,5052.4f,134.3f,76879};
        locations.AddRange(list);
        List<object> list2 = new List<object>(){"Wor'gol, Frostfire Ridge",5988.7f,6180.9f,70.1f,76782};
        locations.AddRange(list2);
        List<object> list3 = new List<object>(){"Throm'Var, Frostfire Ridge",7879.6f,5560.2f,111.1f,76783};
        locations.AddRange(list3);
        List<object> list4 = new List<object>(){"Bloodmaul Slag Mines, Frostfire Ridge",7403.6f,4356.3f,126.4f,76787};
        locations.AddRange(list4);
        List<object> list5 = new List<object>(){"Darkspear's Edge, Frostfire Ridge",6600.0f,4342.5f,91.1f,78699};
        locations.AddRange(list5);
        List<object> list6 = new List<object>(){"Wolf's Stand, Frostfire Ridge",5830.9f,3004.1f,183.2f,87707};
        locations.AddRange(list6);
        List<object> list7 = new List<object>(){"Thunder Pass, Frostfire Ridge",5788.9f,2397.1f,201.4f,76784};
        locations.AddRange(list7);
               
        if (Flight.API.IsQuestCompleted(33657))
        {
            List<object> list8 = new List<object>(){"Bladespire Citadel, Frostfire Ridge",6754.6f,6012.5f,250.0f,76781};
            locations.AddRange(list8);
        }
        
        return locations;
    }
}


