/*  FlightManager
|   Author: @Sklug  aka TheGenomeWhisperer
|
|   To Be Used with "Flight.cs" and "InsertContinentName.cs" class
|   For use in collaboration with the Rebot API 
|
|   Last Update 14th Oct, 2015 */


public class Localization
{
	// Default Constructor
	public Localization() {}
	
	// Method:		"IsFlightMapOpen()"
	public static bool IsFlightMapOpen()
	{
		return Flight.API.ExecuteLua<bool>("if TaxiNodeName(1) ~= \"INVALID\" then return true else return false end");
	}
	
	// Method:		"Localize(string)"
	// Purpose:		To take the given string, and return the translated string.
	public static string Localize(string destinationName)
	{
		List<List<string>> list = getDraenorFPNames();
		string locale = Flight.API.ExecuteLua<string>("return GetLocale()");
		int index = 0;
		string result = "";
		
		// Determine Player Client
		switch (locale)
		{
			case "enGB":
				index = 0;
				break;
			case "enUS":
				index = 0;
				break;
			case "esMX":
				index = 1;
				break;
			case "ptBR":
				index = 2;
				break;
			case "deDE":
				index = 3;
				break;
			case "esES":
				index = 4;
				break;
			case "frFR":
				index = 5;
				break;
			case "itIT":
				index = 6;
				break;
			case "ruRU":
				index = 7;
				break;
			case "koKR":
				index = 8;
				break;
			case "zhTW":
				index = 9;
				break;
			case "zhCN":
				index = 10;
				break;
			default:
				Flight.API.Print("Country Not Identified. Please Report Back Which Client You Are Using. TY!");
				break;
		}
		
		for (int i = 0; i < list.Count; i++)
		{
			if (list.ElementAt(i).ElementAt(0).Equals(destinationName))
			{
				result = list.ElementAt(i).ElementAt(index);
				break;
			}
		}
		return result;
	}
	
	// INITIAL
	public static string BuildFirstString()
	{
		string result = "";
		if (IsFlightMapOpen())
		{
			int numNodes = Flight.API.ExecuteLua<int>("return NumTaxiNodes()");
			for (int i = 1; i <= numNodes; i++) 
			{
				result += "list.Add(temp = new List<string>() {{\"" + Flight.API.ExecuteLua<string>("return TaxiNodeName(" + i + ")") + "\"}});\n";
			}
		}
		else
		{
			Flight.API.Print("FlightMap is Not Currently Open. Please Head to a FlightMaster, Open Window, and Try Again.");
		}
		result = "List<List<string>> list = new List<List<string>>();\nList<string> = temp;\n\n" + result;
		return result;
	}
	
	// Secondary List Building
	public static string BuildNextString()
	{
		string result = "";
		if (IsFlightMapOpen())
		{
			int numNodes = Flight.API.ExecuteLua<int>("return NumTaxiNodes()");
			int index;
			for (int i = 1; i <= numNodes; i++) 
			{
				index = i-1;
				result += "list.ElementAt(" + index + ").Add(\"" + Flight.API.ExecuteLua<string>("return TaxiNodeName(" + i + ")") + "\");\n";
			}
		}
		else
		{
			Flight.API.Print("FlightMap is Not Currently Open. Please Head to a FlightMaster, Open Window, and Try Again.");
		}
		return result;
	}
	
	
	public static List<List<string>> getDraenorFPNames()
	{
		List<List<string>> list = new List<List<string>>();
		List<string> temp;
		
		// English
		list.Add(temp = new List<string>() {"Exile's Rise, Shadowmoon Valley"});
		list.Add(temp = new List<string>() {"Wor'gol, Frostfire Ridge"});
		list.Add(temp = new List<string>() {"Bladespire Citadel, Frostfire Ridge"});
		list.Add(temp = new List<string>() {"Throm'Var, Frostfire Ridge"});
		list.Add(temp = new List<string>() {"Bloodmaul Slag Mines, Frostfire Ridge"});
		list.Add(temp = new List<string>() {"Stonefang Outpost, Frostfire Ridge"});
		list.Add(temp = new List<string>() {"Thunder Pass, Frostfire Ridge"});
		list.Add(temp = new List<string>() {"Darkspear's Edge, Frostfire Ridge"});
		list.Add(temp = new List<string>() {"Warspear, Ashran"});
		list.Add(temp = new List<string>() {"Frostwall Garrison, Frostfire Ridge"});
		list.Add(temp = new List<string>() {"Zangarra, Talador"});
		list.Add(temp = new List<string>() {"Frostwolf Overlook, Talador"});
		list.Add(temp = new List<string>() {"Beastwatch, Gorgrond"});
		list.Add(temp = new List<string>() {"Vol'jin's Pride, Talador"});
		list.Add(temp = new List<string>() {"Durotan's Grasp, Talador"});
		list.Add(temp = new List<string>() {"Shattrath City, Talador"});
		list.Add(temp = new List<string>() {"Retribution Point, Talador"});
		list.Add(temp = new List<string>() {"Exarch's Refuge, Talador"});
		list.Add(temp = new List<string>() {"Terokkar Refuge, Talador"});
		list.Add(temp = new List<string>() {"Socrethar's Rise, Shadowmoon Valley"});
		list.Add(temp = new List<string>() {"Axefall, Spires of Arak"});
		list.Add(temp = new List<string>() {"The Ring of Trials, Nagrand"});
		list.Add(temp = new List<string>() {"Throne of the Elements, Nagrand"});
		list.Add(temp = new List<string>() {"Wor'var, Nagrand"});
		list.Add(temp = new List<string>() {"Riverside Post, Nagrand"});
		list.Add(temp = new List<string>() {"Veil Terokk, Spires of Arak"});
		list.Add(temp = new List<string>() {"Talon Watch, Spires of Arak"});
		list.Add(temp = new List<string>() {"Pinchwhistle Gearworks, Spires of Arak"});
		list.Add(temp = new List<string>() {"Bastion Rise, Gorgrond"});
		list.Add(temp = new List<string>() {"Apexis Excavation, Spires of Arak"});
		list.Add(temp = new List<string>() {"Evermorn Springs, Gorgrond"});
		list.Add(temp = new List<string>() {"Crow's Crook, Spires of Arak"});
		list.Add(temp = new List<string>() {"Breaker's Crown, Gorgrond"});
		list.Add(temp = new List<string>() {"Iron Docks, Gorgrond"});
		list.Add(temp = new List<string>() {"Darktide Roost, Shadowmoon Valley"});
		list.Add(temp = new List<string>() {"Skysea Ridge, Gorgrond"});
		list.Add(temp = new List<string>() {"Wolf's Stand, Frostfire Ridge"});
		list.Add(temp = new List<string>() {"Everbloom Wilds, Gorgrond"});
		list.Add(temp = new List<string>() {"Akeeta's Hovel, Shadowmoon Valley"});
		list.Add(temp = new List<string>() {"Rilzit's Holdfast, Nagrand"});
		list.Add(temp = new List<string>() {"Nivek's Overlook, Nagrand"});
		list.Add(temp = new List<string>() {"Joz's Rylaks, Nagrand"});
		list.Add(temp = new List<string>() {"Everbloom Overlook, Gorgrond"});
		list.Add(temp = new List<string>() {"Vol'mar, Tanaan Jungle"});
		list.Add(temp = new List<string>() {"Aktar's Post, Tanaan Jungle"});
		list.Add(temp = new List<string>() {"The Iron Front, Tanaan Jungle"});
		list.Add(temp = new List<string>() {"Vault of the Earth, Tanaan Jungle"});
		list.Add(temp = new List<string>() {"Malo's Lookout, Tanaan Jungle"});
		list.Add(temp = new List<string>() {"Sha'naari Refuge, Tanaan Jungle"});
		
		// Espanol(AL)
		list.ElementAt(0).Add("Alto del Exilio, Valle Sombraluna");
		list.ElementAt(1).Add("Wor'gol, Cresta Pirofrío");
		list.ElementAt(2).Add("Ciudadela de Aguja del Filo, Cresta Pirofrío");
		list.ElementAt(3).Add("Throm'var, Cresta Pirofrío");
		list.ElementAt(4).Add("Minas de escoria Machacasangre, Cresta Pirofrío");
		list.ElementAt(5).Add("Avanzada de Colmillos Pétreos, Cresta Pirofrío");
		list.ElementAt(6).Add("Paso del Trueno, Cresta Pirofrío");
		list.ElementAt(7).Add("Acantilado de Lanza Negra, Cresta Pirofrío");
		list.ElementAt(8).Add("Lanza de Guerra, Ashran");
		list.ElementAt(9).Add("Fortaleza Muro de Escarcha, Cresta Pirofrío");
		list.ElementAt(10).Add("Zangarra, Talador");
		list.ElementAt(11).Add("Mirador Lobo Gélido, Talador");
		list.ElementAt(12).Add("Observatorio de Bestias, Gorgrond");
		list.ElementAt(13).Add("Orgullo de Vol'jin, Talador");
		list.ElementAt(14).Add("Agarre de Durotan, Talador");
		list.ElementAt(15).Add("Ciudad de Shattrath, Talador");
		list.ElementAt(16).Add("Punta Retribución, Talador");
		list.ElementAt(17).Add("Refugio del Exarca, Talador");
		list.ElementAt(18).Add("Refugio Terokkar, Talador");
		list.ElementAt(19).Add("Alto de Socrethar, Valle Sombraluna");
		list.ElementAt(20).Add("Caída del hacha, Pináculos de Arak");
		list.ElementAt(21).Add("El Círculo de los Retos, Nagrand");
		list.ElementAt(22).Add("El Trono de los Elementos, Nagrand");
		list.ElementAt(23).Add("Wor'var, Nagrand");
		list.ElementAt(24).Add("Puesto de la Ribera, Nagrand");
		list.ElementAt(25).Add("Velo Terokk, Pináculos de Arak");
		list.ElementAt(26).Add("Vigilancia de la Garra, Pináculos de Arak");
		list.ElementAt(27).Add("Engranajes Silbapellizco, Pináculos de Arak");
		list.ElementAt(28).Add("Alto del Bastión, Gorgrond");
		list.ElementAt(29).Add("Excavación de ápices, Pináculos de Arak");
		list.ElementAt(30).Add("Manantiales Siempredía, Gorgrond");
		list.ElementAt(31).Add("Recodo del Cuervo, Pináculos de Arak");
		list.ElementAt(32).Add("Corona del Rompedor, Gorgrond");
		list.ElementAt(33).Add("Muelles de Hierro, Gorgrond");
		list.ElementAt(34).Add("Nidal Marea Oscura, Valle Sombraluna");
		list.ElementAt(35).Add("Cresta Marempíreo, Gorgrond");
		list.ElementAt(36).Add("Base del Lobo, Cresta Pirofrío");
		list.ElementAt(37).Add("Espesura Sempibrote, Gorgrond");
		list.ElementAt(38).Add("Casucha de Akeeta, Valle Sombraluna");
		list.ElementAt(39).Add("Sargazo de Rilzit, Nagrand");
		list.ElementAt(40).Add("Mirador de Nivek, Nagrand");
		list.ElementAt(41).Add("Rylaks de Joz, Nagrand");
		list.ElementAt(42).Add("Mirador Sempibrote, Gorgrond");
		list.ElementAt(43).Add("Vol'mar, Jungla Tanaan");
		list.ElementAt(44).Add("Base de Aktar, Jungla Tanaan");
		list.ElementAt(45).Add("El Frente de Hierro, Jungla Tanaan");
		list.ElementAt(46).Add("Cámara de la Tierra, Jungla Tanaan");
		list.ElementAt(47).Add("Oteador de Malo, Jungla Tanaan");
		list.ElementAt(48).Add("Refugio Sha'naari, Jungla Tanaan");

		// Portuguese
		list.ElementAt(0).Add("Aclive do Exilado, Vale da Lua Negra");
		list.ElementAt(1).Add("Wor'gol, Serra Fogofrio");
		list.ElementAt(2).Add("Cidadela Giralança, Serra Fogofrio");
		list.ElementAt(3).Add("Throm'var, Serra Fogofrio");
		list.ElementAt(4).Add("Minas de Escória do Malho Sangrento, Serra Fogofrio");
		list.ElementAt(5).Add("Posto Avançado da Presa Pétrea, Serra Fogofrio");
		list.ElementAt(6).Add("Passo do Trovão, Serra Fogofrio");
		list.ElementAt(7).Add("Fronteira Lançanegra, Serra Fogofrio");
		list.ElementAt(8).Add("Lança de Guerra, Ashran");
		list.ElementAt(9).Add("Guarnição da Muralha de Gelo, Serra Fogofrio");
		list.ElementAt(10).Add("Zangarra, Talador");
		list.ElementAt(11).Add("Alcândor do Lobo do Gelo, Talador");
		list.ElementAt(12).Add("Guarda das Feras, Gorgrond");
		list.ElementAt(13).Add("Orgulho de Vol'jin, Talador");
		list.ElementAt(14).Add("Domínio de Durotan, Talador");
		list.ElementAt(15).Add("Shattrath, Talador");
		list.ElementAt(16).Add("Ponto da Desforra, Talador");
		list.ElementAt(17).Add("Refúgio do Exarca, Talador");
		list.ElementAt(18).Add("Refúgio Terokkar, Talador");
		list.ElementAt(19).Add("Elevado de Socrethar, Vale da Lua Negra");
		list.ElementAt(20).Add("Ashakai, Agulhas de Arak");
		list.ElementAt(21).Add("Ringue da Provação, Nagrand");
		list.ElementAt(22).Add("Trono dos Elementos, Nagrand");
		list.ElementAt(23).Add("Wor'var, Nagrand");
		list.ElementAt(24).Add("Posto da Ribeira, Nagrand");
		list.ElementAt(25).Add("Véu Terokk, Agulhas de Arak");
		list.ElementAt(26).Add("Vigília da Garra, Agulhas de Arak");
		list.ElementAt(27).Add("Geringonças Beliscapito, Agulhas de Arak");
		list.ElementAt(28).Add("Platô do Bastião, Gorgrond");
		list.ElementAt(29).Add("Escavação Apexis, Agulhas de Arak");
		list.ElementAt(30).Add("Fontes Perenalba, Gorgrond");
		list.ElementAt(31).Add("Curva do Corvo, Agulhas de Arak");
		list.ElementAt(32).Add("Coroa do Rachador, Gorgrond");
		list.ElementAt(33).Add("Docas de Ferro, Gorgrond");
		list.ElementAt(34).Add("Mirante Ondanegra, Vale da Lua Negra");
		list.ElementAt(35).Add("Serra Celesmar, Gorgrond");
		list.ElementAt(36).Add("Campina do Lobo, Serra Fogofrio");
		list.ElementAt(37).Add("Selva Floretérnia, Gorgrond");
		list.ElementAt(38).Add("Casebre de Akeeta, Vale da Lua Negra");
		list.ElementAt(39).Add("Raízes do Pino, Nagrand");
		list.ElementAt(40).Add("Mirante do Naldo, Nagrand");
		list.ElementAt(41).Add("Rylaks do Joca, Nagrand");
		list.ElementAt(42).Add("Mirante Floretérnia, Gorgrond");
		list.ElementAt(43).Add("Vol'mar, Selva de Tanaan");
		list.ElementAt(44).Add("Posto de Aktar, Selva de Tanaan");
		list.ElementAt(45).Add("O Front de Ferro, Selva de Tanaan");
		list.ElementAt(46).Add("Cúpula da Terra, Selva de Tanaan");
		list.ElementAt(47).Add("Mirante de Malo, Selva de Tanaan");
		list.ElementAt(48).Add("Refúgio Sha'naari, Selva de Tanaan");
		
		// Deutsch
		list.ElementAt(0).Add("Anhöhe der Exilanten, Schattenmondtal");
		list.ElementAt(1).Add("Wor'gol, Frostfeuergrat");
		list.ElementAt(2).Add("Speerspießerfestung, Frostfeuergrat");
		list.ElementAt(3).Add("Throm'var, Frostfeuergrat");
		list.ElementAt(4).Add("Blutschlägermine, Frostfeuergrat");
		list.ElementAt(5).Add("Steinzahnposten, Frostfeuergrat");
		list.ElementAt(6).Add("Donnerpass, Frostfeuergrat");
		list.ElementAt(7).Add("Dunkelspeerspalte, Frostfeuergrat");
		list.ElementAt(8).Add("Kriegsspeer, Ashran");
		list.ElementAt(9).Add("Frostwallgarnison, Frostfeuergrat");
		list.ElementAt(10).Add("Zangarra, Talador");
		list.ElementAt(11).Add("Frostwolfwarte, Talador");
		list.ElementAt(12).Add("Wildwacht, Gorgrond");
		list.ElementAt(13).Add("Vol'jins Stolz, Talador");
		list.ElementAt(14).Add("Durotans Brückenkopf, Talador");
		list.ElementAt(15).Add("Shattrath, Talador");
		list.ElementAt(16).Add("Platz der Vergelter, Talador");
		list.ElementAt(17).Add("Zuflucht des Exarchen, Talador");
		list.ElementAt(18).Add("Terokkarzuflucht, Talador");
		list.ElementAt(19).Add("Socrethars Klippe, Schattenmondtal");
		list.ElementAt(20).Add("Axtfall, Spitzen von Arak");
		list.ElementAt(21).Add("Ring der Prüfung, Nagrand");
		list.ElementAt(22).Add("Thron der Elemente, Nagrand");
		list.ElementAt(23).Add("Wor'var, Nagrand");
		list.ElementAt(24).Add("Uferposten, Nagrand");
		list.ElementAt(25).Add("Terokkversteck, Spitzen von Arak");
		list.ElementAt(26).Add("Klauenwacht, Spitzen von Arak");
		list.ElementAt(27).Add("Werkstatt Quetschpfeif, Spitzen von Arak");
		list.ElementAt(28).Add("Bastionsklippe, Gorgrond");
		list.ElementAt(29).Add("Apexisausgrabung, Spitzen von Arak");
		list.ElementAt(30).Add("Immermornquellen, Gorgrond");
		list.ElementAt(31).Add("Krähenwinkel, Spitzen von Arak");
		list.ElementAt(32).Add("Brecherkuppe, Gorgrond");
		list.ElementAt(33).Add("Eisendocks, Gorgrond");
		list.ElementAt(34).Add("Nachtflutnest, Schattenmondtal");
		list.ElementAt(35).Add("Horizontklippe, Gorgrond");
		list.ElementAt(36).Add("Wolfswehr, Frostfeuergrat");
		list.ElementAt(37).Add("Die Immergrüne Wildnis, Gorgrond");
		list.ElementAt(38).Add("Akeetas Hütte, Schattenmondtal");
		list.ElementAt(39).Add("Rilzits Stützpunkt, Nagrand");
		list.ElementAt(40).Add("Niveks Aussichtspunkt, Nagrand");
		list.ElementAt(41).Add("Joz' Rylaks, Nagrand");
		list.ElementAt(42).Add("Die Immergrüne Aussicht, Gorgrond");
		list.ElementAt(43).Add("Vol'mar, Tanaandschungel");
		list.ElementAt(44).Add("Aktars Posten, Tanaandschungel");
		list.ElementAt(45).Add("Die Eiserne Front, Tanaandschungel");
		list.ElementAt(46).Add("Das Erdgewölbe, Tanaandschungel");
		list.ElementAt(47).Add("Malos Ausblick, Tanaandschungel");
		list.ElementAt(48).Add("Die Sha'naarizuflucht, Tanaandschungel");		
		
		// Espanol(EU)
		list.ElementAt(0).Add("Alto del Exiliado, Valle Sombraluna");
		list.ElementAt(1).Add("Wor'gol, Cresta Fuego Glacial");
		list.ElementAt(2).Add("Ciudadela Aguja del Filo, Cresta Fuego Glacial");
		list.ElementAt(3).Add("Throm'var, Cresta Fuego Glacial");
		list.ElementAt(4).Add("Minas Machacasangre, Cresta Fuego Glacial");
		list.ElementAt(5).Add("Avanzada Colmillo Pétreo, Cresta Fuego Glacial");
		list.ElementAt(6).Add("Paso del Trueno, Cresta Fuego Glacial");
		list.ElementAt(7).Add("Talud Lanza Negra, Cresta Fuego Glacial");
		list.ElementAt(8).Add("Lanza de Guerra, Ashran");
		list.ElementAt(9).Add("Ciudadela Muro de Hielo, Cresta Fuego Glacial");
		list.ElementAt(10).Add("Zangarra, Talador");
		list.ElementAt(11).Add("Mirador Lobo Gélido, Talador");
		list.ElementAt(12).Add("Avanzada de las Bestias, Gorgrond");
		list.ElementAt(13).Add("Orgullo de Vol'jin, Talador");
		list.ElementAt(14).Add("Asidero de Durotan, Talador");
		list.ElementAt(15).Add("Ciudad de Shattrath, Talador");
		list.ElementAt(16).Add("Punta Represalia, Talador");
		list.ElementAt(17).Add("Refugio del Exarca, Talador");
		list.ElementAt(18).Add("Refugio de Terokkar, Talador");
		list.ElementAt(19).Add("Alto de Socrethar, Valle Sombraluna");
		list.ElementAt(20).Add("Hachazo, Cumbres de Arak");
		list.ElementAt(21).Add("El Círculo de los Retos, Nagrand");
		list.ElementAt(22).Add("El Trono de los Elementos, Nagrand");
		list.ElementAt(23).Add("Wor'var, Nagrand");
		list.ElementAt(24).Add("Puesto Ribera, Nagrand");
		list.ElementAt(25).Add("Velo Terokk, Cumbres de Arak");
		list.ElementAt(26).Add("Atalaya de la Garra, Cumbres de Arak");
		list.ElementAt(27).Add("Taller Silbapellizco, Cumbres de Arak");
		list.ElementAt(28).Add("Alto del Bastión, Gorgrond");
		list.ElementAt(29).Add("Excavación Apexis, Cumbres de Arak");
		list.ElementAt(30).Add("Floración Sol Eterno, Gorgrond");
		list.ElementAt(31).Add("Recodo del Cuervo, Cumbres de Arak");
		list.ElementAt(32).Add("Corona del Rompedor, Gorgrond");
		list.ElementAt(33).Add("Puerto de Hierro, Gorgrond");
		list.ElementAt(34).Add("Nidal Marea Oscura, Valle Sombraluna");
		list.ElementAt(35).Add("Cresta Cielomar, Gorgrond");
		list.ElementAt(36).Add("Alto del Lobo, Cresta Fuego Glacial");
		list.ElementAt(37).Add("Fronda del Vergel, Gorgrond");
		list.ElementAt(38).Add("Cuchitril de Akeeta, Valle Sombraluna");
		list.ElementAt(39).Add("Sargazo de Rilzit, Nagrand");
		list.ElementAt(40).Add("Mirador de Nivek, Nagrand");
		list.ElementAt(41).Add("Rylaks de Joz, Nagrand");
		list.ElementAt(42).Add("Mirador del Vergel, Gorgrond");
		list.ElementAt(43).Add("Vol'mar, Selva de Tanaan");
		list.ElementAt(44).Add("Puesto de Aktar, Selva de Tanaan");
		list.ElementAt(45).Add("Frente de Hierro, Selva de Tanaan");
		list.ElementAt(46).Add("Cámara de la Tierra, Selva de Tanaan");
		list.ElementAt(47).Add("Atalaya de Malo, Selva de Tanaan");
		list.ElementAt(48).Add("Refugio Sha'naari, Selva de Tanaan");
		
		// Francais
		list.ElementAt(0).Add("Cime de l’Exilé, vallée d’Ombrelune");
		list.ElementAt(1).Add("Wor’gol, crête de Givrefeu");
		list.ElementAt(2).Add("Citadelle de Flèchelame, crête de Givrefeu");
		list.ElementAt(3).Add("Throm’Var, crête de Givrefeu");
		list.ElementAt(4).Add("Mine de la Masse-Sanglante, crête de Givrefeu");
		list.ElementAt(5).Add("Avant-poste de Croc-de-Pierre, crête de Givrefeu");
		list.ElementAt(6).Add("Passage du Tonnerre, crête de Givrefeu");
		list.ElementAt(7).Add("Lisière de Sombrelance, crête de Givrefeu");
		list.ElementAt(8).Add("Fer-de-Lance, A’shran");
		list.ElementAt(9).Add("Fief de Mur-de-Givre, crête de Givrefeu");
		list.ElementAt(10).Add("Zangarra, Talador");
		list.ElementAt(11).Add("Surplomb Loup-de-Givre, Talador");
		list.ElementAt(12).Add("Guet des Bêtes, Gorgrond");
		list.ElementAt(13).Add("Fierté de Vol’jin, Talador");
		list.ElementAt(14).Add("Emprise de Durotan, Talador");
		list.ElementAt(15).Add("Shattrath, Talador");
		list.ElementAt(16).Add("Halte de la Vindicte, Talador");
		list.ElementAt(17).Add("Refuge de l’Exarque, Talador");
		list.ElementAt(18).Add("Refuge de Terokkar, Talador");
		list.ElementAt(19).Add("Cime de Socrethar, vallée d’Ombrelune");
		list.ElementAt(20).Add("Tombe-Hache, flèches d’Arak");
		list.ElementAt(21).Add("Arène des Épreuves, Nagrand");
		list.ElementAt(22).Add("Trône des éléments, Nagrand");
		list.ElementAt(23).Add("Wor’var, Nagrand");
		list.ElementAt(24).Add("Poste de la Rive, Nagrand");
		list.ElementAt(25).Add("Voile Terokk, flèches d’Arak");
		list.ElementAt(26).Add("Guet de la Serre, flèches d’Arak");
		list.ElementAt(27).Add("Boulonnerie de Sifflepince, flèches d’Arak");
		list.ElementAt(28).Add("Bastion insoumis, Gorgrond");
		list.ElementAt(29).Add("Excavation Apogide, flèches d’Arak");
		list.ElementAt(30).Add("Sources de l’Aube-Éternelle, Gorgrond");
		list.ElementAt(31).Add("Courbe du Corbeau, flèches d’Arak");
		list.ElementAt(32).Add("Couronne du Briseur, Gorgrond");
		list.ElementAt(33).Add("Quais de Fer, Gorgrond");
		list.ElementAt(34).Add("Perchoir de Sombreflux, vallée d’Ombrelune");
		list.ElementAt(35).Add("Crête de Mer-Céleste, Gorgrond");
		list.ElementAt(36).Add("Séjour du Loup, crête de Givrefeu");
		list.ElementAt(37).Add("Séjour de la Flore éternelle, Gorgrond");
		list.ElementAt(38).Add("Taudis d’Akeeta, vallée d’Ombrelune");
		list.ElementAt(39).Add("Redoute de Rilzit, Nagrand");
		list.ElementAt(40).Add("Surplomb de Nivek, Nagrand");
		list.ElementAt(41).Add("Les rylaks de Joz, Nagrand");
		list.ElementAt(42).Add("Surplomb de la Flore éternelle, Gorgrond");
		list.ElementAt(43).Add("Vol’mar, Jungle de Tanaan");
		list.ElementAt(44).Add("Poste d’Aktar, jungle de Tanaan");
		list.ElementAt(45).Add("Front de Fer, jungle de Tanaan");
		list.ElementAt(46).Add("Caveau de la Terre, jungle de Tanaan");
		list.ElementAt(47).Add("Poste de guet de Malo, jungle de Tanaan");
		list.ElementAt(48).Add("Refuge Sha’naari, jungle de Tanaan");
		
		// Italiano
		list.ElementAt(0).Add("Altura degli Esiliati, Valle di Torvaluna");
		list.ElementAt(1).Add("Wor'gol, Landa di Fuocogelo");
		list.ElementAt(2).Add("Fortezza dei Lamacurva, Landa di Fuocogelo");
		list.ElementAt(3).Add("Throm'var, Landa di Fuocogelo");
		list.ElementAt(4).Add("Miniere dei Magliorosso, Landa di Fuocogelo");
		list.ElementAt(5).Add("Avamposto dell'Artiglio di Pietra, Landa di Fuocogelo");
		list.ElementAt(6).Add("Passo del Tuono, Landa di Fuocogelo");
		list.ElementAt(7).Add("Riparo dei Lanciascura, Landa di Fuocogelo");
		list.ElementAt(8).Add("Lancia da Guerra, Ashran");
		list.ElementAt(9).Add("Guarnigione Rocciafredda, Landa di Fuocogelo");
		list.ElementAt(10).Add("Zangarra, Talador");
		list.ElementAt(11).Add("Promontorio dei Lupi Bianchi, Talador");
		list.ElementAt(12).Add("Roccabestia, Gorgrond");
		list.ElementAt(13).Add("Baluardo di Vol'jin, Talador");
		list.ElementAt(14).Add("Breccia di Durotan, Talador");
		list.ElementAt(15).Add("Shattrath, Talador");
		list.ElementAt(16).Add("Presidio del Castigo, Talador");
		list.ElementAt(17).Add("Rifugio dell'Esarca, Talador");
		list.ElementAt(18).Add("Rifugio di Terokk, Talador");
		list.ElementAt(19).Add("Altura di Socrethar, Valle di Torvaluna");
		list.ElementAt(20).Add("Calascure, Guglie di Arakk");
		list.ElementAt(21).Add("Circolo delle Sfide, Nagrand");
		list.ElementAt(22).Add("Trono degli Elementi, Nagrand");
		list.ElementAt(23).Add("Wor'var, Nagrand");
		list.ElementAt(24).Add("Avamposto Rivalunga, Nagrand");
		list.ElementAt(25).Add("Vol Terokk, Guglie di Arakk");
		list.ElementAt(26).Add("Presidio dell'Artiglio, Guglie di Arakk");
		list.ElementAt(27).Add("Stabilimenti Brillabotti, Guglie di Arakk");
		list.ElementAt(28).Add("Altura del Bastione, Gorgrond");
		list.ElementAt(29).Add("Scavo Apexis, Guglie di Arakk");
		list.ElementAt(30).Add("Sorgenti di Vespreterno, Gorgrond");
		list.ElementAt(31).Add("Artiglio del Corvo, Guglie di Arakk");
		list.ElementAt(32).Add("Corona dello Spezzatore, Gorgrond");
		list.ElementAt(33).Add("Darsena di Ferro, Gorgrond");
		list.ElementAt(34).Add("Covo dei Foscamarea, Valle di Torvaluna");
		list.ElementAt(35).Add("Dorsale di Vetta del Mare, Gorgrond");
		list.ElementAt(36).Add("Difesa del Lupo, Landa di Fuocogelo");
		list.ElementAt(37).Add("Giungla di Verdeterno, Gorgrond");
		list.ElementAt(38).Add("Tugurio di Akeeta, Valle di Torvaluna");
		list.ElementAt(39).Add("Baluardo di Rilzit, Nagrand");
		list.ElementAt(40).Add("Osservatorio di Nivek, Nagrand");
		list.ElementAt(41).Add("Rylak di Joz, Nagrand");
		list.ElementAt(42).Add("Giungla di Verdeterno, Gorgrond");
		list.ElementAt(43).Add("Vol'mar, Giungla di Tanaan");
		list.ElementAt(44).Add("Avamposto di Aktar, Giungla di Tanaan");
		list.ElementAt(45).Add("Fronte di Ferro, Giungla di Tanaan");
		list.ElementAt(46).Add("Cripta della Terra, Giungla di Tanaan");
		list.ElementAt(47).Add("Osservatorio di Malo, Giungla di Tanaan");
		list.ElementAt(48).Add("Rifugio Sha'naari, Giungla di Tanaan");
		
		// Russian
		list.ElementAt(0).Add("Утес Изгнанников, Долина Призрачной Луны");
		list.ElementAt(1).Add("Вор'гол, Хребет Ледяного Огня");
		list.ElementAt(2).Add("Цитадель Камнерогов, Хребет Ледяного Огня");
		list.ElementAt(3).Add("Тром'вар, Хребет Ледяного Огня");
		list.ElementAt(4).Add("Шлаковые шахты Кровавого Молота, Хребет Ледяного Огня");
		list.ElementAt(5).Add("Аванпост Каменного Клыка, Хребет Ледяного Огня");
		list.ElementAt(6).Add("Грозовой перевал, Хребет Ледяного Огня");
		list.ElementAt(7).Add("Уступ Черного Копья, Хребет Ледяного Огня");
		list.ElementAt(8).Add("Копье Войны, Ашран");
		list.ElementAt(9).Add("Гарнизон Ледяных скал, Хребет Ледяного Огня");
		list.ElementAt(10).Add("Зангарра, Таладор");
		list.ElementAt(11).Add("Обзорная площадка Северного Волка, Таладор");
		list.ElementAt(12).Add("Звериная застава, Горгронд");
		list.ElementAt(13).Add("Гордость Вол'джина, Таладор");
		list.ElementAt(14).Add("Опорный лагерь Дуротана, Таладор");
		list.ElementAt(15).Add("Шаттрат, Таладор");
		list.ElementAt(16).Add("Место Воздаяния, Таладор");
		list.ElementAt(17).Add("Приют экзарха, Таладор");
		list.ElementAt(18).Add("Тероккарский приют, Таладор");
		list.ElementAt(19).Add("Плато Сокретара, Долина Призрачной Луны");
		list.ElementAt(20).Add("Павший Топор, Пики Арака");
		list.ElementAt(21).Add("Круг Испытаний, Награнд");
		list.ElementAt(22).Add("Трон Стихий, Награнд");
		list.ElementAt(23).Add("Вор'вар, Награнд");
		list.ElementAt(24).Add("Речной лагерь, Награнд");
		list.ElementAt(25).Add("Гнездовье Терокк, Пики Арака");
		list.ElementAt(26).Add("Дозор Когтя, Пики Арака");
		list.ElementAt(27).Add("Мастерская Паросвистов, Пики Арака");
		list.ElementAt(28).Add("Утес Бастиона, Горгронд");
		list.ElementAt(29).Add("Раскопки города апекситов, Пики Арака");
		list.ElementAt(30).Add("Ключи Вечного Рассвета, Горгронд");
		list.ElementAt(31).Add("Вороний Крюк, Пики Арака");
		list.ElementAt(32).Add("Венец Разрушителя, Горгронд");
		list.ElementAt(33).Add("Железные Доки, Горгронд");
		list.ElementAt(34).Add("Гнездовье Темного Прилива, Долина Призрачной Луны");
		list.ElementAt(35).Add("Гряда Небоводья, Горгронд");
		list.ElementAt(36).Add("Волчья застава, Хребет Ледяного Огня");
		list.ElementAt(37).Add("Заросли Вечного Цветения, Горгронд");
		list.ElementAt(38).Add("Укрытие Акиты, Долина Призрачной Луны");
		list.ElementAt(39).Add("Укрепление Рилзита, Награнд");
		list.ElementAt(40).Add("Дозор Нивека, Награнд");
		list.ElementAt(41).Add("Рилаки Джоза, Награнд");
		list.ElementAt(42).Add("Дозор Вечного Цветения, Горгронд");
		list.ElementAt(43).Add("Вол'мар, Танаанские джунгли");
		list.ElementAt(44).Add("Лагерь Актара, Танаанские джунгли");
		list.ElementAt(45).Add("Железный фронт, Танаанские джунгли");
		list.ElementAt(46).Add("Сокровищница Земли, Танаанские джунгли");
		list.ElementAt(47).Add("Дозорный пункт Мало, Танаанские джунгли");
		list.ElementAt(48).Add("Убежище Ша'наари, Танаанские джунгли");

		// Korean
		list.ElementAt(0).Add("추방자의 언덕, 어둠달 골짜기");
		list.ElementAt(1).Add("워골, 서리불꽃 마루");
		list.ElementAt(2).Add("칼날첨탑 성채, 서리불꽃 마루");
		list.ElementAt(3).Add("트롬바르, 서리불꽃 마루");
		list.ElementAt(4).Add("피망치 잿가루 광산, 서리불꽃 마루");
		list.ElementAt(5).Add("돌송곳니 전초기지, 서리불꽃 마루");
		list.ElementAt(6).Add("천둥 고개, 서리불꽃 마루");
		list.ElementAt(7).Add("검은창 원정지, 서리불꽃 마루");
		list.ElementAt(8).Add("전쟁의 창, 아쉬란");
		list.ElementAt(9).Add("서리방벽 주둔지, 서리불꽃 마루");
		list.ElementAt(10).Add("장가라, 탈라도르");
		list.ElementAt(11).Add("서리늑대 전망대, 탈라도르");
		list.ElementAt(12).Add("야수 감시터, 고르그론드");
		list.ElementAt(13).Add("볼진의 긍지, 탈라도르");
		list.ElementAt(14).Add("듀로탄의 손아귀, 탈라도르");
		list.ElementAt(15).Add("샤트라스, 탈라도르");
		list.ElementAt(16).Add("응징의 거점, 탈라도르");
		list.ElementAt(17).Add("총독의 피난처, 탈라도르");
		list.ElementAt(18).Add("테로카르 피난처, 탈라도르");
		list.ElementAt(19).Add("소크레타르의 마루, 어둠달 골짜기");
		list.ElementAt(20).Add("도끼 야영지, 아라크 첨탑");
		list.ElementAt(21).Add("시험의 투기장, 나그란드");
		list.ElementAt(22).Add("정령의 옥좌, 나그란드");
		list.ElementAt(23).Add("올바르, 나그란드");
		list.ElementAt(24).Add("강기슭 초소, 나그란드");
		list.ElementAt(25).Add("장막의 테로크, 아라크 첨탑");
		list.ElementAt(26).Add("갈퀴의 감시탑, 아라크 첨탑");
		list.ElementAt(27).Add("핀치휘슬 기계작업장, 아라크 첨탑");
		list.ElementAt(28).Add("성채 바깥마당, 고르그론드");
		list.ElementAt(29).Add("에펙시스 발굴현장, 아라크 첨탑");
		list.ElementAt(30).Add("영원아침 연못, 고르그론드");
		list.ElementAt(31).Add("까마귀의 오솔길, 아라크 첨탑");
		list.ElementAt(32).Add("파괴자의 왕관, 고르그론드");
		list.ElementAt(33).Add("강철 선착장, 고르그론드");
		list.ElementAt(34).Add("어둠파도 보금자리, 어둠달 골짜기");
		list.ElementAt(35).Add("하늘바다 마루, 고르그론드");
		list.ElementAt(36).Add("늑대의 보금자리, 서리불꽃 마루");
		list.ElementAt(37).Add("상록숲 밀림, 고르그론드");
		list.ElementAt(38).Add("아키타의 오두막집, 어둠달 골짜기");
		list.ElementAt(39).Add("릴지트의 보루, 나그란드");
		list.ElementAt(40).Add("니베크의 전망대, 나그란드");
		list.ElementAt(41).Add("조즈의 라일라크, 나그란드");
		list.ElementAt(42).Add("상록숲 전망대, 고르그론드");
		list.ElementAt(43).Add("볼마르, 타나안 밀림");
		list.ElementAt(44).Add("아크타르의 거점, 타나안 밀림");
		list.ElementAt(45).Add("강철 전초지, 타나안 밀림");
		list.ElementAt(46).Add("흙의 보관소, 타나안 밀림");
		list.ElementAt(47).Add("말로의 망루, 타나안 밀림");
		list.ElementAt(48).Add("샤나아리 은거처, 타나안 밀림");
		
		// Taiwan
		list.ElementAt(0).Add("流放者高地，影月谷");
		list.ElementAt(1).Add("沃格爾，霜火峰");
		list.ElementAt(2).Add("劍刃堡壘，霜火峰");
		list.ElementAt(3).Add("索姆瓦，霜火峰");
		list.ElementAt(4).Add("血槌熔渣礦場，霜火峰");
		list.ElementAt(5).Add("石牙哨站，霜火峰");
		list.ElementAt(6).Add("雷霆隘口，霜火峰");
		list.ElementAt(7).Add("暗矛之刃，霜火峰");
		list.ElementAt(8).Add("戰爭之矛，艾斯蘭");
		list.ElementAt(9).Add("霜牆要塞，霜火峰");
		list.ElementAt(10).Add("贊格拉，塔拉多爾");
		list.ElementAt(11).Add("霜狼瞰臺，塔拉多爾");
		list.ElementAt(12).Add("獸望崗哨，格古隆德");
		list.ElementAt(13).Add("沃金之傲，塔拉多爾");
		list.ElementAt(14).Add("杜洛坦之握，塔拉多爾");
		list.ElementAt(15).Add("撒塔斯城，塔拉多爾");
		list.ElementAt(16).Add("懲戒崗哨，塔拉多爾");
		list.ElementAt(17).Add("主教避難所，塔拉多爾");
		list.ElementAt(18).Add("泰洛卡避難所，塔拉多爾");
		list.ElementAt(19).Add("索奎薩爾高地，影月谷");
		list.ElementAt(20).Add("落斧堡，阿拉卡山");
		list.ElementAt(21).Add("試煉競技場，納葛蘭");
		list.ElementAt(22).Add("元素王座，納葛蘭");
		list.ElementAt(23).Add("沃瓦爾，納葛蘭");
		list.ElementAt(24).Add("河畔哨站，納葛蘭");
		list.ElementAt(25).Add("維爾泰洛克，阿拉卡山");
		list.ElementAt(26).Add("鴉爪崗哨，阿拉卡山");
		list.ElementAt(27).Add("急嘯零件廠，阿拉卡山");
		list.ElementAt(28).Add("堡壘高地，格古隆德");
		list.ElementAt(29).Add("頂尖挖掘場，阿拉卡山");
		list.ElementAt(30).Add("永晨泉，格古隆德");
		list.ElementAt(31).Add("烏鴉鉤，阿拉卡山");
		list.ElementAt(32).Add("破源者之冠，格古隆德");
		list.ElementAt(33).Add("鋼鐵碼頭，格古隆德");
		list.ElementAt(34).Add("暗潮棲息地，影月谷");
		list.ElementAt(35).Add("天海山脊，格古隆德");
		list.ElementAt(36).Add("霜狼陣地，霜火峰");
		list.ElementAt(37).Add("永茂林野地，格古隆德");
		list.ElementAt(38).Add("亞吉塔的小屋，影月谷");
		list.ElementAt(39).Add("里茲特的營地，納葛蘭");
		list.ElementAt(40).Add("尼維克的瞰臺，納葛蘭");
		list.ElementAt(41).Add("喬茲的萊拉克，納葛蘭");
		list.ElementAt(42).Add("永茂林瞰臺，格古隆德");
		list.ElementAt(43).Add("沃爾瑪，塔南森林");
		list.ElementAt(44).Add("阿克塔崗哨，塔南森林");
		list.ElementAt(45).Add("鋼鐵前線，塔南森林");
		list.ElementAt(46).Add("大地穹殿，塔南森林");
		list.ElementAt(47).Add("馬洛守望，塔南森林");
		list.ElementAt(48).Add("夏納瑞營地，塔南森林");
		
		// China
		list.ElementAt(0).Add("流亡者高地，影月谷");
		list.ElementAt(1).Add("沃高尔，霜火岭");
		list.ElementAt(2).Add("刀塔堡垒，霜火岭");
		list.ElementAt(3).Add("索姆瓦尔，霜火岭");
		list.ElementAt(4).Add("血槌炉渣矿井，霜火岭");
		list.ElementAt(5).Add("岩牙岗哨，霜火岭");
		list.ElementAt(6).Add("雷霆小径，霜火岭");
		list.ElementAt(7).Add("暗矛之刃，霜火岭");
		list.ElementAt(8).Add("战争之矛，阿什兰");
		list.ElementAt(9).Add("霜壁要塞，霜火岭");
		list.ElementAt(10).Add("赞加拉，塔拉多");
		list.ElementAt(11).Add("霜狼岗哨，塔拉多");
		list.ElementAt(12).Add("蛮兽岗哨，戈尔隆德");
		list.ElementAt(13).Add("沃金之傲，塔拉多");
		list.ElementAt(14).Add("杜隆坦之握，塔拉多");
		list.ElementAt(15).Add("沙塔斯城，塔拉多");
		list.ElementAt(16).Add("惩戒岗哨，塔拉多");
		list.ElementAt(17).Add("大主教的避难所，塔拉多");
		list.ElementAt(18).Add("泰罗卡避难所，塔拉多");
		list.ElementAt(19).Add("索克雷萨高地，影月谷");
		list.ElementAt(20).Add("坠斧营地，阿兰卡峰林");
		list.ElementAt(21).Add("试炼竞技场，纳格兰");
		list.ElementAt(22).Add("元素王座，纳格兰");
		list.ElementAt(23).Add("沃尔瓦，纳格兰");
		list.ElementAt(24).Add("河畔岗哨，纳格兰");
		list.ElementAt(25).Add("泰罗克鸦巢，阿兰卡峰林");
		list.ElementAt(26).Add("鸦爪岗哨，阿兰卡峰林");
		list.ElementAt(27).Add("宾奇维斯零件工厂，阿兰卡峰林");
		list.ElementAt(28).Add("棱堡高地，戈尔隆德");
		list.ElementAt(29).Add("埃匹希斯挖掘场，阿兰卡峰林");
		list.ElementAt(30).Add("永晨之泉，戈尔隆德");
		list.ElementAt(31).Add("乌鸦小屋，阿兰卡峰林");
		list.ElementAt(32).Add("毁灭者之冠，戈尔隆德");
		list.ElementAt(33).Add("钢铁码头，戈尔隆德");
		list.ElementAt(34).Add("黑潮栖木，影月谷");
		list.ElementAt(35).Add("天海岭，戈尔隆德");
		list.ElementAt(36).Add("霜狼阵地，霜火岭");
		list.ElementAt(37).Add("永茂丛林，戈尔隆德");
		list.ElementAt(38).Add("阿基塔的小屋，影月谷");
		list.ElementAt(39).Add("里尔兹特锚地，纳格兰");
		list.ElementAt(40).Add("内维克的岗哨，纳格兰");
		list.ElementAt(41).Add("乔兹的双头飞龙，纳格兰");
		list.ElementAt(42).Add("永茂岗哨，戈尔隆德");
		list.ElementAt(43).Add("沃玛尔，塔纳安丛林");
		list.ElementAt(44).Add("阿卡塔的岗哨，塔纳安丛林");
		list.ElementAt(45).Add("钢铁前线，塔纳安丛林");
		list.ElementAt(46).Add("大地岩窟，塔纳安丛林");
		list.ElementAt(47).Add("玛洛岗哨，塔纳安丛林");
		list.ElementAt(48).Add("沙纳尔避难所，塔纳安丛林");
		
		return list;
	}
}

// '，' = 65292   ASC value.