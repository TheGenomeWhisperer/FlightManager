public class Localization
{
	// Default Constructor
	public Localization() {}
	
	
	public static string getAllDestinationNames()
	{
		
	}
	
	public static bool IsFlightMapOpen()
	{
		return Flight.API.ExecuteLua<bool>("if TaxiNodeName(1) ~= \"INVALID\" then return true else return false end");
	}

















}