
public class DraenorZones
{
    public List<object> AllFPs;

    public DraenorZones(int zoneID, bool factionIsHorde)
    {
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
        throw new NotImplementedException();
    }

    private static List<object> getHordeTalador()
    {
        throw new NotImplementedException();
    }

    private static List<object> getHordeGorgrond()
    {
        List<object> locations = new List<object>(){"Iron Docks, Gorgrond",8486.2f,1544.2f,78.9f,84700};
                        
        locations.Add("Breaker's Crown, Gorgrond");
        locations.Add(6591.3f);  
        locations.Add(1313.9f);  
        locations.Add(64.6f);
        locations.Add(86492);
        
        locations.Add("Evermorn Springs, Gorgrond");
        locations.Add(4822.8f);  
        locations.Add(1670.8f);  
        locations.Add(149.0f);    
        locations.Add(84495);
        
        locations.Add("Bastion Rise, Gorgrond");
        locations.Add(4649.9f);  
        locations.Add(1187.5f);    
        locations.Add(136.9f);
        locations.Add(84508);
        
        if (Flight.API.Me.Level > 99)
        {
            locations.Add("Skysea Ridge, Gorgrond");
            locations.Add(7597.1f);
            locations.Add(1828.0f);
            locations.Add(79.1f);
            locations.Add(85829);
            
            locations.Add("Everbloom Wilds, Gorgrond");
            locations.Add(7091.7f);
            locations.Add(406.8f);
            locations.Add(112.0f);
            locations.Add(84714);
            
            locations.Add("Everbloom Overlook, Gorgrond");
            locations.Add(8019.4f);
            locations.Add(-554.9f);
            locations.Add(154.8f);  
            locations.Add(88757);
        }
        
        if (Flight.API.IsQuestCompleted(35151))
        {
            locations.Add("Beastwatch, Gorgrond");
            locations.Add(5782.3f);
            locations.Add(1292.7f);      
            locations.Add(107.5f);
            locations.Add(81055);
        }
        
        return locations;
    }

    private static List<object> getHordeFFR()
    {
        List<object> locations = new List<object>(){"Frostwall Garrison, Frostfire Ridge",5579.5f,4565.3f,136.2f,79407};
        
        locations.Add("Stonefang Outpost, Frostfire Ridge");
        locations.Add(6157.6f);
        locations.Add(5052.4f);
        locations.Add(134.3f);
        locations.Add(76879);
        
        locations.Add("Wor'gol, Frostfire Ridge");
        locations.Add(5988.7f);
        locations.Add(6180.9f);
        locations.Add(70.1f);
        locations.Add(76782);
        
        locations.Add("Throm'Var, Frostfire Ridge");
        locations.Add(7879.6f);
        locations.Add(5560.2f);
        locations.Add(111.1f);
        locations.Add(76783);
        
        locations.Add("Bloodmaul Slag Mines, Frostfire Ridge");
        locations.Add(7403.6f);
        locations.Add(4356.3f);
        locations.Add(126.4f);
        locations.Add(76787);
        
        locations.Add("Darkspear's Edge, Frostfire Ridge");
        locations.Add(6600.0f);
        locations.Add(4342.5f);
        locations.Add(91.1f);
        locations.Add(78699);
        
        locations.Add("Wolf's Stand, Frostfire Ridge");
        locations.Add(5830.9f);
        locations.Add(3004.1f);
        locations.Add(183.2f);
        locations.Add(87707);
        
        locations.Add("Thunder Pass, Frostfire Ridge");
        locations.Add(5788.9f);
        locations.Add(2397.1f);
        locations.Add(201.4f);
        locations.Add(76784);
        
        if (Flight.API.IsQuestCompleted(33657))
        {
            locations.Add("Bladespire Citadel, Frostfire Ridge");
            locations.Add(6754.6f);
            locations.Add(6012.5f);
            locations.Add(250.0f);
            locations.Add(76781);
        }
        
        return locations;
    }
}


