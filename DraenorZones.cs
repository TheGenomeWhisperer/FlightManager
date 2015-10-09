
class DraenorZones
    {
        public List<object> AllFPs;

        public DraenorZones(int zoneID)
        {
            AllFPs = getDraenorInfo(zoneID);
        }

        // Filters out returns by zone on the continent
        private static List<object> getDraenorInfo(int zoneID)
        {
            List<object> result = new List<object>();

            // Frostfire Ridge (and caves and phases)
            if (zoneID == 6720 || zoneID == 6868 || zoneID == 6745 || zoneID == 6849 || zoneID == 6861 || zoneID == 6864 || zoneID == 6848 || zoneID == 6875 || zoneID == 6939 || zoneID == 7005 || zoneID == 7209)
            {
                return getFFR();
            }

            // Gorgrond (and caves and phases)
            if (zoneID == 6721 || zoneID == 6885 || zoneID == 7160 || zoneID == 7185)
            {
                return getGorgrond();
            }

            // Talador (and caves and phases)
            if (zoneID == 6662 || zoneID == 6980 || zoneID == 6979 || zoneID == 7089 || zoneID == 7622)
            {
                return getTalador();
            }

            // Spires of Arak
            if (zoneID == 6722)
            {
                return getSpires();
            }

            // Nagrand (and phased caves)
            if (zoneID == 6755 || zoneID == 7124 || zoneID == 7203 || zoneID == 7204 || zoneID == 7267)
            {
                return getNagrand();
            }

            // Shadowmoon Valley (and caves and phases)
            if (zoneID == 6719 || zoneID == 6976 || zoneID == 7460 || zoneID == 7083)
            {
                return getSMV();
            }

            // Tanaan Jungle
            if (zoneID == 6723)
            {
                return getTanaan();
            }

            // Ashran (and mine)
            if (zoneID == 6941 || zoneID == 7548)
            {
                return getAshran();
            }

            // Warspear
            if (zoneID == 7333)
            {
                return getWarspear();
            }

            // Stormshield
            if (zoneID == 7332)
            {
                return getStormshield();
            }

            // Frostwall Garrison (and 3 mine phases)
            if (zoneID == 7004 || zoneID == 7327 || zoneID == 7328 || zoneID == 7329)
            {
                return getHordeGarrison();
            }

            // Lunarfall Garrison (and 3 mine phases)
            if (zoneID == 7078 || zoneID == 7327 || zoneID == 7328 || zoneID == 7329)
            {
                return getHordeGarrison();
            }

            return result;
        }

        // Return for all of these will be in the following format (XYZ = V3 coordinates):  List<object> zoneFlightInfo = {FPName,X,Y,Z,FPName,X,Y,Z,...)
        private static List<object> getStormshield()
        {
            throw new NotImplementedException();
        }

        private static List<object> getWarspear()
        {
            throw new NotImplementedException();
        }

        private static List<object> getHordeGarrison()
        {
            List<object> test = new List<object>();
            test.Add("Frostwall Garrison");
            test.Add(5579.5f);
            test.Add(4565.3f);
            test.Add(136.2f);
            return test;
              
        }

        private static List<object> getAshran()
        {
            throw new NotImplementedException();
        }

        private static List<object> getTanaan()
        {
            throw new NotImplementedException();
        }

        private static List<object> getSMV()
        {
            throw new NotImplementedException();
        }

        private static List<object> getNagrand()
        {
            throw new NotImplementedException();
        }

        private static List<object> getSpires()
        {
            throw new NotImplementedException();
        }

        private static List<object> getTalador()
        {
            throw new NotImplementedException();
        }

        private static List<object> getGorgrond()
        {
            throw new NotImplementedException();
        }

        private static List<object> getFFR()
        {
            throw new NotImplementedException();
        }
    }