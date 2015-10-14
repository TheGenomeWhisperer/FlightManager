public class Localization
{
	// Default Constructor
	public Localization() {}
	
	
	public static string getAllDestinationNames()
	{
		return "";
	}
	
	
	public static bool IsFlightMapOpen()
	{
		return Flight.API.ExecuteLua<bool>("if TaxiNodeName(1) ~= \"INVALID\" then return true else return false end");
	}


	// This is for building the variable names
	public static string NumberToWords(int number)
	{
		if (number == 0)
			return "zero";
	
		if (number < 0)
			return "minus " + NumberToWords(Math.Abs(number));
	
		string words = "";
	
		if ((number / 1000000) > 0)
		{
			words += NumberToWords(number / 1000000) + " million ";
			number %= 1000000;
		}
	
		if ((number / 1000) > 0)
		{
			words += NumberToWords(number / 1000) + " thousand ";
			number %= 1000;
		}
	
		if ((number / 100) > 0)
		{
			words += NumberToWords(number / 100) + " hundred ";
			number %= 100;
		}
	
		if (number > 0)
		{
			if (words != "")
				words += "and ";
	
			var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
			var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
	
			if (number < 20)
				words += unitsMap[number];
			else
			{
				words += tensMap[number / 10];
				if ((number % 10) > 0)
					words += unitsMap[number % 10];
			}
		}
		return words;
	}

    // INITIAL
	public static string BuildFirstString()
	{
		string result = "";
		if (IsFlightMapOpen())
		{
			int numNodes = Flight.API.ExecuteLua<int>("return NumTaxiNodes()");
			int count = 1;
			string number = "";
			for (int i = 1; i <= numNodes; i++) {
				number = Localization.NumberToWords(count);
				result += "string " + number + "  = \"" + Flight.API.ExecuteLua<string>("return TaxiNodeName(" + i + ")") + "_\";\n";
				count ++;
			}
			result = result.Substring(0,result.Length-1);
		}
		else
		{
			Flight.API.Print("FlightMap is Not Currently Open. Please Head to a FlightMaster, Open Window, and Try Again.");
		}
		return result;
	}
	
	// SUBSEQUENT
	public static string BuildFollowupString()
	{
		string result = "";
		if (IsFlightMapOpen())
		{
			int numNodes = Flight.API.ExecuteLua<int>("return NumTaxiNodes()");
			int count = 1;
			string number = "";
			for (int i = 1; i <= numNodes; i++) {
				number = Localization.NumberToWords(count);
				result += number + "  += \"" + Flight.API.ExecuteLua<string>("return TaxiNodeName(" + i + ")") + "_\";\n";
				count ++;
			}
			result = result.Substring(0,result.Length-1);
		}
		else
		{
			Flight.API.Print("FlightMap is Not Currently Open. Please Head to a FlightMaster, Open Window, and Try Again.");
		}
		return result;
	}
	
	
	
	
	
	
	
	
	
	public static string MergeAllClients(string names)
	{
		string result = names;
			
		
		return result;
	}
	
	
	public static string getDraenorFPNames()
	{
		string result = "";
		
		// Initial English
		string one  = "Exile's Rise, Shadowmoon Valley_";
		string two  = "Wor'gol, Frostfire Ridge_";
		string three  = "Bladespire Citadel, Frostfire Ridge_";
		string four  = "Throm'Var, Frostfire Ridge_";
		string five  = "Bloodmaul Slag Mines, Frostfire Ridge_";
		string six  = "Stonefang Outpost, Frostfire Ridge_";
		string seven  = "Thunder Pass, Frostfire Ridge_";
		string eight  = "Darkspear's Edge, Frostfire Ridge_";
		string nine  = "Warspear, Ashran_";
		string ten  = "Frostwall Garrison, Frostfire Ridge_";
		string eleven  = "Zangarra, Talador_";
		string twelve  = "Frostwolf Overlook, Talador_";
		string thirteen  = "Beastwatch, Gorgrond_";
		string fourteen  = "Vol'jin's Pride, Talador_";
		string fifteen  = "Durotan's Grasp, Talador_";
		string sixteen  = "Shattrath City, Talador_";
		string seventeen  = "Retribution Point, Talador_";
		string eighteen  = "Exarch's Refuge, Talador_";
		string nineteen  = "Terokkar Refuge, Talador_";
		string twenty  = "Socrethar's Rise, Shadowmoon Valley_";
		string twentyone  = "Axefall, Spires of Arak_";
		string twentytwo  = "The Ring of Trials, Nagrand_";
		string twentythree  = "Throne of the Elements, Nagrand_";
		string twentyfour  = "Wor'var, Nagrand_";
		string twentyfive  = "Riverside Post, Nagrand_";
		string twentysix  = "Veil Terokk, Spires of Arak_";
		string twentyseven  = "Talon Watch, Spires of Arak_";
		string twentyeight  = "Pinchwhistle Gearworks, Spires of Arak_";
		string twentynine  = "Bastion Rise, Gorgrond_";
		string thirty  = "Apexis Excavation, Spires of Arak_";
		string thirtyone  = "Evermorn Springs, Gorgrond_";
		string thirtytwo  = "Crow's Crook, Spires of Arak_";
		string thirtythree  = "Breaker's Crown, Gorgrond_";
		string thirtyfour  = "Iron Docks, Gorgrond_";
		string thirtyfive  = "Darktide Roost, Shadowmoon Valley_";
		string thirtysix  = "Skysea Ridge, Gorgrond_";
		string thirtyseven  = "Wolf's Stand, Frostfire Ridge_";
		string thirtyeight  = "Everbloom Wilds, Gorgrond_";
		string thirtynine  = "Akeeta's Hovel, Shadowmoon Valley_";
		string forty  = "Rilzit's Holdfast, Nagrand_";
		string fortyone  = "Nivek's Overlook, Nagrand_";
		string fortytwo  = "Joz's Rylaks, Nagrand_";
		string fortythree  = "Everbloom Overlook, Gorgrond_";
		string fortyfour  = "Vol'mar, Tanaan Jungle_";
		string fortyfive  = "Aktar's Post, Tanaan Jungle_";
		string fortysix  = "The Iron Front, Tanaan Jungle_";
		string fortyseven  = "Vault of the Earth, Tanaan Jungle_";
		string fortyeight  = "Malo's Lookout, Tanaan Jungle_";
		string fortynine  = "Sha'naari Refuge, Tanaan Jungle_";
		
		// Espanol(AL)
		one  += "Alto del Exilio, Valle Sombraluna_";
		two  += "Wor'gol, Cresta Pirofrío_";
		three  += "Ciudadela de Aguja del Filo, Cresta Pirofrío_";
		four  += "Throm'var, Cresta Pirofrío_";
		five  += "Minas de escoria Machacasangre, Cresta Pirofrío_";
		six  += "Avanzada de Colmillos Pétreos, Cresta Pirofrío_";
		seven  += "Paso del Trueno, Cresta Pirofrío_";
		eight  += "Acantilado de Lanza Negra, Cresta Pirofrío_";
		nine  += "Lanza de Guerra, Ashran_";
		ten  += "Fortaleza Muro de Escarcha, Cresta Pirofrío_";
		eleven  += "Zangarra, Talador_";
		twelve  += "Mirador Lobo Gélido, Talador_";
		thirteen  += "Observatorio de Bestias, Gorgrond_";
		fourteen  += "Orgullo de Vol'jin, Talador_";
		fifteen  += "Agarre de Durotan, Talador_";
		sixteen  += "Ciudad de Shattrath, Talador_";
		seventeen  += "Punta Retribución, Talador_";
		eighteen  += "Refugio del Exarca, Talador_";
		nineteen  += "Refugio Terokkar, Talador_";
		twenty  += "Alto de Socrethar, Valle Sombraluna_";
		twentyone  += "Caída del hacha, Pináculos de Arak_";
		twentytwo  += "El Círculo de los Retos, Nagrand_";
		twentythree  += "El Trono de los Elementos, Nagrand_";
		twentyfour  += "Wor'var, Nagrand_";
		twentyfive  += "Puesto de la Ribera, Nagrand_";
		twentysix  += "Velo Terokk, Pináculos de Arak_";
		twentyseven  += "Vigilancia de la Garra, Pináculos de Arak_";
		twentyeight  += "Engranajes Silbapellizco, Pináculos de Arak_";
		twentynine  += "Alto del Bastión, Gorgrond_";
		thirty  += "Excavación de ápices, Pináculos de Arak_";
		thirtyone  += "Manantiales Siempredía, Gorgrond_";
		thirtytwo  += "Recodo del Cuervo, Pináculos de Arak_";
		thirtythree  += "Corona del Rompedor, Gorgrond_";
		thirtyfour  += "Muelles de Hierro, Gorgrond_";
		thirtyfive  += "Nidal Marea Oscura, Valle Sombraluna_";
		thirtysix  += "Cresta Marempíreo, Gorgrond_";
		thirtyseven  += "Base del Lobo, Cresta Pirofrío_";
		thirtyeight  += "Espesura Sempibrote, Gorgrond_";
		thirtynine  += "Casucha de Akeeta, Valle Sombraluna_";
		forty  += "Sargazo de Rilzit, Nagrand_";
		fortyone  += "Mirador de Nivek, Nagrand_";
		fortytwo  += "Rylaks de Joz, Nagrand_";
		fortythree  += "Mirador Sempibrote, Gorgrond_";
		fortyfour  += "Vol'mar, Jungla Tanaan_";
		fortyfive  += "Base de Aktar, Jungla Tanaan_";
		fortysix  += "El Frente de Hierro, Jungla Tanaan_";
		fortyseven  += "Cámara de la Tierra, Jungla Tanaan_";
		fortyeight  += "Oteador de Malo, Jungla Tanaan_";
		fortynine  += "Refugio Sha'naari, Jungla Tanaan_";
		
		// Portuguese
		one  += "Aclive do Exilado, Vale da Lua Negra_";
		two  += "Wor'gol, Serra Fogofrio_";
		three  += "Cidadela Giralança, Serra Fogofrio_";
		four  += "Throm'var, Serra Fogofrio_";
		five  += "Minas de Escória do Malho Sangrento, Serra Fogofrio_";
		six  += "Posto Avançado da Presa Pétrea, Serra Fogofrio_";
		seven  += "Passo do Trovão, Serra Fogofrio_";
		eight  += "Fronteira Lançanegra, Serra Fogofrio_";
		nine  += "Lança de Guerra, Ashran_";
		ten  += "Guarnição da Muralha de Gelo, Serra Fogofrio_";
		eleven  += "Zangarra, Talador_";
		twelve  += "Alcândor do Lobo do Gelo, Talador_";
		thirteen  += "Guarda das Feras, Gorgrond_";
		fourteen  += "Orgulho de Vol'jin, Talador_";
		fifteen  += "Domínio de Durotan, Talador_";
		sixteen  += "Shattrath, Talador_";
		seventeen  += "Ponto da Desforra, Talador_";
		eighteen  += "Refúgio do Exarca, Talador_";
		nineteen  += "Refúgio Terokkar, Talador_";
		twenty  += "Elevado de Socrethar, Vale da Lua Negra_";
		twentyone  += "Ashakai, Agulhas de Arak_";
		twentytwo  += "Ringue da Provação, Nagrand_";
		twentythree  += "Trono dos Elementos, Nagrand_";
		twentyfour  += "Wor'var, Nagrand_";
		twentyfive  += "Posto da Ribeira, Nagrand_";
		twentysix  += "Véu Terokk, Agulhas de Arak_";
		twentyseven  += "Vigília da Garra, Agulhas de Arak_";
		twentyeight  += "Geringonças Beliscapito, Agulhas de Arak_";
		twentynine  += "Platô do Bastião, Gorgrond_";
		thirty  += "Escavação Apexis, Agulhas de Arak_";
		thirtyone  += "Fontes Perenalba, Gorgrond_";
		thirtytwo  += "Curva do Corvo, Agulhas de Arak_";
		thirtythree  += "Coroa do Rachador, Gorgrond_";
		thirtyfour  += "Docas de Ferro, Gorgrond_";
		thirtyfive  += "Mirante Ondanegra, Vale da Lua Negra_";
		thirtysix  += "Serra Celesmar, Gorgrond_";
		thirtyseven  += "Campina do Lobo, Serra Fogofrio_";
		thirtyeight  += "Selva Floretérnia, Gorgrond_";
		thirtynine  += "Casebre de Akeeta, Vale da Lua Negra_";
		forty  += "Raízes do Pino, Nagrand_";
		fortyone  += "Mirante do Naldo, Nagrand_";
		fortytwo  += "Rylaks do Joca, Nagrand_";
		fortythree  += "Mirante Floretérnia, Gorgrond_";
		fortyfour  += "Vol'mar, Selva de Tanaan_";
		fortyfive  += "Posto de Aktar, Selva de Tanaan_";
		fortysix  += "O Front de Ferro, Selva de Tanaan_";
		fortyseven  += "Cúpula da Terra, Selva de Tanaan_";
		fortyeight  += "Mirante de Malo, Selva de Tanaan_";
		fortynine  += "Refúgio Sha'naari, Selva de Tanaan_";
		
		// Deutsch
		one  += "Anhöhe der Exilanten, Schattenmondtal_";
		two  += "Wor'gol, Frostfeuergrat_";
		three  += "Speerspießerfestung, Frostfeuergrat_";
		four  += "Throm'var, Frostfeuergrat_";
		five  += "Blutschlägermine, Frostfeuergrat_";
		six  += "Steinzahnposten, Frostfeuergrat_";
		seven  += "Donnerpass, Frostfeuergrat_";
		eight  += "Dunkelspeerspalte, Frostfeuergrat_";
		nine  += "Kriegsspeer, Ashran_";
		ten  += "Frostwallgarnison, Frostfeuergrat_";
		eleven  += "Zangarra, Talador_";
		twelve  += "Frostwolfwarte, Talador_";
		thirteen  += "Wildwacht, Gorgrond_";
		fourteen  += "Vol'jins Stolz, Talador_";
		fifteen  += "Durotans Brückenkopf, Talador_";
		sixteen  += "Shattrath, Talador_";
		seventeen  += "Platz der Vergelter, Talador_";
		eighteen  += "Zuflucht des Exarchen, Talador_";
		nineteen  += "Terokkarzuflucht, Talador_";
		twenty  += "Socrethars Klippe, Schattenmondtal_";
		twentyone  += "Axtfall, Spitzen von Arak_";
		twentytwo  += "Ring der Prüfung, Nagrand_";
		twentythree  += "Thron der Elemente, Nagrand_";
		twentyfour  += "Wor'var, Nagrand_";
		twentyfive  += "Uferposten, Nagrand_";
		twentysix  += "Terokkversteck, Spitzen von Arak_";
		twentyseven  += "Klauenwacht, Spitzen von Arak_";
		twentyeight  += "Werkstatt Quetschpfeif, Spitzen von Arak_";
		twentynine  += "Bastionsklippe, Gorgrond_";
		thirty  += "Apexisausgrabung, Spitzen von Arak_";
		thirtyone  += "Immermornquellen, Gorgrond_";
		thirtytwo  += "Krähenwinkel, Spitzen von Arak_";
		thirtythree  += "Brecherkuppe, Gorgrond_";
		thirtyfour  += "Eisendocks, Gorgrond_";
		thirtyfive  += "Nachtflutnest, Schattenmondtal_";
		thirtysix  += "Horizontklippe, Gorgrond_";
		thirtyseven  += "Wolfswehr, Frostfeuergrat_";
		thirtyeight  += "Die Immergrüne Wildnis, Gorgrond_";
		thirtynine  += "Akeetas Hütte, Schattenmondtal_";
		forty  += "Rilzits Stützpunkt, Nagrand_";
		fortyone  += "Niveks Aussichtspunkt, Nagrand_";
		fortytwo  += "Joz' Rylaks, Nagrand_";
		fortythree  += "Die Immergrüne Aussicht, Gorgrond_";
		fortyfour  += "Vol'mar, Tanaandschungel_";
		fortyfive  += "Aktars Posten, Tanaandschungel_";
		fortysix  += "Die Eiserne Front, Tanaandschungel_";
		fortyseven  += "Das Erdgewölbe, Tanaandschungel_";
		fortyeight  += "Malos Ausblick, Tanaandschungel_";
		fortynine  += "Die Sha'naarizuflucht, Tanaandschungel_";
		
		// Espanol (EU)
		one  += "Alto del Exiliado, Valle Sombraluna_";
		two  += "Wor'gol, Cresta Fuego Glacial_";
		three  += "Ciudadela Aguja del Filo, Cresta Fuego Glacial_";
		four  += "Throm'var, Cresta Fuego Glacial_";
		five  += "Minas Machacasangre, Cresta Fuego Glacial_";
		six  += "Avanzada Colmillo Pétreo, Cresta Fuego Glacial_";
		seven  += "Paso del Trueno, Cresta Fuego Glacial_";
		eight  += "Talud Lanza Negra, Cresta Fuego Glacial_";
		nine  += "Lanza de Guerra, Ashran_";
		ten  += "Ciudadela Muro de Hielo, Cresta Fuego Glacial_";
		eleven  += "Zangarra, Talador_";
		twelve  += "Mirador Lobo Gélido, Talador_";
		thirteen  += "Avanzada de las Bestias, Gorgrond_";
		fourteen  += "Orgullo de Vol'jin, Talador_";
		fifteen  += "Asidero de Durotan, Talador_";
		sixteen  += "Ciudad de Shattrath, Talador_";
		seventeen  += "Punta Represalia, Talador_";
		eighteen  += "Refugio del Exarca, Talador_";
		nineteen  += "Refugio de Terokkar, Talador_";
		twenty  += "Alto de Socrethar, Valle Sombraluna_";
		twentyone  += "Hachazo, Cumbres de Arak_";
		twentytwo  += "El Círculo de los Retos, Nagrand_";
		twentythree  += "El Trono de los Elementos, Nagrand_";
		twentyfour  += "Wor'var, Nagrand_";
		twentyfive  += "Puesto Ribera, Nagrand_";
		twentysix  += "Velo Terokk, Cumbres de Arak_";
		twentyseven  += "Atalaya de la Garra, Cumbres de Arak_";
		twentyeight  += "Taller Silbapellizco, Cumbres de Arak_";
		twentynine  += "Alto del Bastión, Gorgrond_";
		thirty  += "Excavación Apexis, Cumbres de Arak_";
		thirtyone  += "Floración Sol Eterno, Gorgrond_";
		thirtytwo  += "Recodo del Cuervo, Cumbres de Arak_";
		thirtythree  += "Corona del Rompedor, Gorgrond_";
		thirtyfour  += "Puerto de Hierro, Gorgrond_";
		thirtyfive  += "Nidal Marea Oscura, Valle Sombraluna_";
		thirtysix  += "Cresta Cielomar, Gorgrond_";
		thirtyseven  += "Alto del Lobo, Cresta Fuego Glacial_";
		thirtyeight  += "Fronda del Vergel, Gorgrond_";
		thirtynine  += "Cuchitril de Akeeta, Valle Sombraluna_";
		forty  += "Sargazo de Rilzit, Nagrand_";
		fortyone  += "Mirador de Nivek, Nagrand_";
		fortytwo  += "Rylaks de Joz, Nagrand_";
		fortythree  += "Mirador del Vergel, Gorgrond_";
		fortyfour  += "Vol'mar, Selva de Tanaan_";
		fortyfive  += "Puesto de Aktar, Selva de Tanaan_";
		fortysix  += "Frente de Hierro, Selva de Tanaan_";
		fortyseven  += "Cámara de la Tierra, Selva de Tanaan_";
		fortyeight  += "Atalaya de Malo, Selva de Tanaan_";
		fortynine  += "Refugio Sha'naari, Selva de Tanaan_";
		
		// Francais
		one  += "Cime de l’Exilé, vallée d’Ombrelune_";
		two  += "Wor’gol, crête de Givrefeu_";
		three  += "Citadelle de Flèchelame, crête de Givrefeu_";
		four  += "Throm’Var, crête de Givrefeu_";
		five  += "Mine de la Masse-Sanglante, crête de Givrefeu_";
		six  += "Avant-poste de Croc-de-Pierre, crête de Givrefeu_";
		seven  += "Passage du Tonnerre, crête de Givrefeu_";
		eight  += "Lisière de Sombrelance, crête de Givrefeu_";
		nine  += "Fer-de-Lance, A’shran_";
		ten  += "Fief de Mur-de-Givre, crête de Givrefeu_";
		eleven  += "Zangarra, Talador_";
		twelve  += "Surplomb Loup-de-Givre, Talador_";
		thirteen  += "Guet des Bêtes, Gorgrond_";
		fourteen  += "Fierté de Vol’jin, Talador_";
		fifteen  += "Emprise de Durotan, Talador_";
		sixteen  += "Shattrath, Talador_";
		seventeen  += "Halte de la Vindicte, Talador_";
		eighteen  += "Refuge de l’Exarque, Talador_";
		nineteen  += "Refuge de Terokkar, Talador_";
		twenty  += "Cime de Socrethar, vallée d’Ombrelune_";
		twentyone  += "Tombe-Hache, flèches d’Arak_";
		twentytwo  += "Arène des Épreuves, Nagrand_";
		twentythree  += "Trône des éléments, Nagrand_";
		twentyfour  += "Wor’var, Nagrand_";
		twentyfive  += "Poste de la Rive, Nagrand_";
		twentysix  += "Voile Terokk, flèches d’Arak_";
		twentyseven  += "Guet de la Serre, flèches d’Arak_";
		twentyeight  += "Boulonnerie de Sifflepince, flèches d’Arak_";
		twentynine  += "Bastion insoumis, Gorgrond_";
		thirty  += "Excavation Apogide, flèches d’Arak_";
		thirtyone  += "Sources de l’Aube-Éternelle, Gorgrond_";
		thirtytwo  += "Courbe du Corbeau, flèches d’Arak_";
		thirtythree  += "Couronne du Briseur, Gorgrond_";
		thirtyfour  += "Quais de Fer, Gorgrond_";
		thirtyfive  += "Perchoir de Sombreflux, vallée d’Ombrelune_";
		thirtysix  += "Crête de Mer-Céleste, Gorgrond_";
		thirtyseven  += "Séjour du Loup, crête de Givrefeu_";
		thirtyeight  += "Séjour de la Flore éternelle, Gorgrond_";
		thirtynine  += "Taudis d’Akeeta, vallée d’Ombrelune_";
		forty  += "Redoute de Rilzit, Nagrand_";
		fortyone  += "Surplomb de Nivek, Nagrand_";
		fortytwo  += "Les rylaks de Joz, Nagrand_";
		fortythree  += "Surplomb de la Flore éternelle, Gorgrond_";
		fortyfour  += "Vol’mar, Jungle de Tanaan_";
		fortyfive  += "Poste d’Aktar, jungle de Tanaan_";
		fortysix  += "Front de Fer, jungle de Tanaan_";
		fortyseven  += "Caveau de la Terre, jungle de Tanaan_";
		fortyeight  += "Poste de guet de Malo, jungle de Tanaan_";
		fortynine  += "Refuge Sha’naari, jungle de Tanaan_";
		
		// Italiano
		one  += "Altura degli Esiliati, Valle di Torvaluna_";
		two  += "Wor'gol, Landa di Fuocogelo_";
		three  += "Fortezza dei Lamacurva, Landa di Fuocogelo_";
		four  += "Throm'var, Landa di Fuocogelo_";
		five  += "Miniere dei Magliorosso, Landa di Fuocogelo_";
		six  += "Avamposto dell'Artiglio di Pietra, Landa di Fuocogelo_";
		seven  += "Passo del Tuono, Landa di Fuocogelo_";
		eight  += "Riparo dei Lanciascura, Landa di Fuocogelo_";
		nine  += "Lancia da Guerra, Ashran_";
		ten  += "Guarnigione Rocciafredda, Landa di Fuocogelo_";
		eleven  += "Zangarra, Talador_";
		twelve  += "Promontorio dei Lupi Bianchi, Talador_";
		thirteen  += "Roccabestia, Gorgrond_";
		fourteen  += "Baluardo di Vol'jin, Talador_";
		fifteen  += "Breccia di Durotan, Talador_";
		sixteen  += "Shattrath, Talador_";
		seventeen  += "Presidio del Castigo, Talador_";
		eighteen  += "Rifugio dell'Esarca, Talador_";
		nineteen  += "Rifugio di Terokk, Talador_";
		twenty  += "Altura di Socrethar, Valle di Torvaluna_";
		twentyone  += "Calascure, Guglie di Arakk_";
		twentytwo  += "Circolo delle Sfide, Nagrand_";
		twentythree  += "Trono degli Elementi, Nagrand_";
		twentyfour  += "Wor'var, Nagrand_";
		twentyfive  += "Avamposto Rivalunga, Nagrand_";
		twentysix  += "Vol Terokk, Guglie di Arakk_";
		twentyseven  += "Presidio dell'Artiglio, Guglie di Arakk_";
		twentyeight  += "Stabilimenti Brillabotti, Guglie di Arakk_";
		twentynine  += "Altura del Bastione, Gorgrond_";
		thirty  += "Scavo Apexis, Guglie di Arakk_";
		thirtyone  += "Sorgenti di Vespreterno, Gorgrond_";
		thirtytwo  += "Artiglio del Corvo, Guglie di Arakk_";
		thirtythree  += "Corona dello Spezzatore, Gorgrond_";
		thirtyfour  += "Darsena di Ferro, Gorgrond_";
		thirtyfive  += "Covo dei Foscamarea, Valle di Torvaluna_";
		thirtysix  += "Dorsale di Vetta del Mare, Gorgrond_";
		thirtyseven  += "Difesa del Lupo, Landa di Fuocogelo_";
		thirtyeight  += "Giungla di Verdeterno, Gorgrond_";
		thirtynine  += "Tugurio di Akeeta, Valle di Torvaluna_";
		forty  += "Baluardo di Rilzit, Nagrand_";
		fortyone  += "Osservatorio di Nivek, Nagrand_";
		fortytwo  += "Rylak di Joz, Nagrand_";
		fortythree  += "Giungla di Verdeterno, Gorgrond_";
		fortyfour  += "Vol'mar, Giungla di Tanaan_";
		fortyfive  += "Avamposto di Aktar, Giungla di Tanaan_";
		fortysix  += "Fronte di Ferro, Giungla di Tanaan_";
		fortyseven  += "Cripta della Terra, Giungla di Tanaan_";
		fortyeight  += "Osservatorio di Malo, Giungla di Tanaan_";
		fortynine  += "Rifugio Sha'naari, Giungla di Tanaan_";
		
		// Russian
		one  += "Утес Изгнанников, Долина Призрачной Луны_";
		two  += "Вор'гол, Хребет Ледяного Огня_";
		three  += "Цитадель Камнерогов, Хребет Ледяного Огня_";
		four  += "Тром'вар, Хребет Ледяного Огня_";
		five  += "Шлаковые шахты Кровавого Молота, Хребет Ледяного Огня_";
		six  += "Аванпост Каменного Клыка, Хребет Ледяного Огня_";
		seven  += "Грозовой перевал, Хребет Ледяного Огня_";
		eight  += "Уступ Черного Копья, Хребет Ледяного Огня_";
		nine  += "Копье Войны, Ашран_";
		ten  += "Гарнизон Ледяных скал, Хребет Ледяного Огня_";
		eleven  += "Зангарра, Таладор_";
		twelve  += "Обзорная площадка Северного Волка, Таладор_";
		thirteen  += "Звериная застава, Горгронд_";
		fourteen  += "Гордость Вол'джина, Таладор_";
		fifteen  += "Опорный лагерь Дуротана, Таладор_";
		sixteen  += "Шаттрат, Таладор_";
		seventeen  += "Место Воздаяния, Таладор_";
		eighteen  += "Приют экзарха, Таладор_";
		nineteen  += "Тероккарский приют, Таладор_";
		twenty  += "Плато Сокретара, Долина Призрачной Луны_";
		twentyone  += "Павший Топор, Пики Арака_";
		twentytwo  += "Круг Испытаний, Награнд_";
		twentythree  += "Трон Стихий, Награнд_";
		twentyfour  += "Вор'вар, Награнд_";
		twentyfive  += "Речной лагерь, Награнд_";
		twentysix  += "Гнездовье Терокк, Пики Арака_";
		twentyseven  += "Дозор Когтя, Пики Арака_";
		twentyeight  += "Мастерская Паросвистов, Пики Арака_";
		twentynine  += "Утес Бастиона, Горгронд_";
		thirty  += "Раскопки города апекситов, Пики Арака_";
		thirtyone  += "Ключи Вечного Рассвета, Горгронд_";
		thirtytwo  += "Вороний Крюк, Пики Арака_";
		thirtythree  += "Венец Разрушителя, Горгронд_";
		thirtyfour  += "Железные Доки, Горгронд_";
		thirtyfive  += "Гнездовье Темного Прилива, Долина Призрачной Луны_";
		thirtysix  += "Гряда Небоводья, Горгронд_";
		thirtyseven  += "Волчья застава, Хребет Ледяного Огня_";
		thirtyeight  += "Заросли Вечного Цветения, Горгронд_";
		thirtynine  += "Укрытие Акиты, Долина Призрачной Луны_";
		forty  += "Укрепление Рилзита, Награнд_";
		fortyone  += "Дозор Нивека, Награнд_";
		fortytwo  += "Рилаки Джоза, Награнд_";
		fortythree  += "Дозор Вечного Цветения, Горгронд_";
		fortyfour  += "Вол'мар, Танаанские джунгли_";
		fortyfive  += "Лагерь Актара, Танаанские джунгли_";
		fortysix  += "Железный фронт, Танаанские джунгли_";
		fortyseven  += "Сокровищница Земли, Танаанские джунгли_";
		fortyeight  += "Дозорный пункт Мало, Танаанские джунгли_";
		fortynine  += "Убежище Ша'наари, Танаанские джунгли_";
		
		// Korean
		one  += "추방자의 언덕, 어둠달 골짜기_";
		two  += "워골, 서리불꽃 마루_";
		three  += "칼날첨탑 성채, 서리불꽃 마루_";
		four  += "트롬바르, 서리불꽃 마루_";
		five  += "피망치 잿가루 광산, 서리불꽃 마루_";
		six  += "돌송곳니 전초기지, 서리불꽃 마루_";
		seven  += "천둥 고개, 서리불꽃 마루_";
		eight  += "검은창 원정지, 서리불꽃 마루_";
		nine  += "전쟁의 창, 아쉬란_";
		ten  += "서리방벽 주둔지, 서리불꽃 마루_";
		eleven  += "장가라, 탈라도르_";
		twelve  += "서리늑대 전망대, 탈라도르_";
		thirteen  += "야수 감시터, 고르그론드_";
		fourteen  += "볼진의 긍지, 탈라도르_";
		fifteen  += "듀로탄의 손아귀, 탈라도르_";
		sixteen  += "샤트라스, 탈라도르_";
		seventeen  += "응징의 거점, 탈라도르_";
		eighteen  += "총독의 피난처, 탈라도르_";
		nineteen  += "테로카르 피난처, 탈라도르_";
		twenty  += "소크레타르의 마루, 어둠달 골짜기_";
		twentyone  += "도끼 야영지, 아라크 첨탑_";
		twentytwo  += "시험의 투기장, 나그란드_";
		twentythree  += "정령의 옥좌, 나그란드_";
		twentyfour  += "올바르, 나그란드_";
		twentyfive  += "강기슭 초소, 나그란드_";
		twentysix  += "장막의 테로크, 아라크 첨탑_";
		twentyseven  += "갈퀴의 감시탑, 아라크 첨탑_";
		twentyeight  += "핀치휘슬 기계작업장, 아라크 첨탑_";
		twentynine  += "성채 바깥마당, 고르그론드_";
		thirty  += "에펙시스 발굴현장, 아라크 첨탑_";
		thirtyone  += "영원아침 연못, 고르그론드_";
		thirtytwo  += "까마귀의 오솔길, 아라크 첨탑_";
		thirtythree  += "파괴자의 왕관, 고르그론드_";
		thirtyfour  += "강철 선착장, 고르그론드_";
		thirtyfive  += "어둠파도 보금자리, 어둠달 골짜기_";
		thirtysix  += "하늘바다 마루, 고르그론드_";
		thirtyseven  += "늑대의 보금자리, 서리불꽃 마루_";
		thirtyeight  += "상록숲 밀림, 고르그론드_";
		thirtynine  += "아키타의 오두막집, 어둠달 골짜기_";
		forty  += "릴지트의 보루, 나그란드_";
		fortyone  += "니베크의 전망대, 나그란드_";
		fortytwo  += "조즈의 라일라크, 나그란드_";
		fortythree  += "상록숲 전망대, 고르그론드_";
		fortyfour  += "볼마르, 타나안 밀림_";
		fortyfive  += "아크타르의 거점, 타나안 밀림_";
		fortysix  += "강철 전초지, 타나안 밀림_";
		fortyseven  += "흙의 보관소, 타나안 밀림_";
		fortyeight  += "말로의 망루, 타나안 밀림_";
		fortynine  += "샤나아리 은거처, 타나안 밀림_";
		
		// Taiwanese 
		one  += "流放者高地，影月谷_";
		two  += "沃格爾，霜火峰_";
		three  += "劍刃堡壘，霜火峰_";
		four  += "索姆瓦，霜火峰_";
		five  += "血槌熔渣礦場，霜火峰_";
		six  += "石牙哨站，霜火峰_";
		seven  += "雷霆隘口，霜火峰_";
		eight  += "暗矛之刃，霜火峰_";
		nine  += "戰爭之矛，艾斯蘭_";
		ten  += "霜牆要塞，霜火峰_";
		eleven  += "贊格拉，塔拉多爾_";
		twelve  += "霜狼瞰臺，塔拉多爾_";
		thirteen  += "獸望崗哨，格古隆德_";
		fourteen  += "沃金之傲，塔拉多爾_";
		fifteen  += "杜洛坦之握，塔拉多爾_";
		sixteen  += "撒塔斯城，塔拉多爾_";
		seventeen  += "懲戒崗哨，塔拉多爾_";
		eighteen  += "主教避難所，塔拉多爾_";
		nineteen  += "泰洛卡避難所，塔拉多爾_";
		twenty  += "索奎薩爾高地，影月谷_";
		twentyone  += "落斧堡，阿拉卡山_";
		twentytwo  += "試煉競技場，納葛蘭_";
		twentythree  += "元素王座，納葛蘭_";
		twentyfour  += "沃瓦爾，納葛蘭_";
		twentyfive  += "河畔哨站，納葛蘭_";
		twentysix  += "維爾泰洛克，阿拉卡山_";
		twentyseven  += "鴉爪崗哨，阿拉卡山_";
		twentyeight  += "急嘯零件廠，阿拉卡山_";
		twentynine  += "堡壘高地，格古隆德_";
		thirty  += "頂尖挖掘場，阿拉卡山_";
		thirtyone  += "永晨泉，格古隆德_";
		thirtytwo  += "烏鴉鉤，阿拉卡山_";
		thirtythree  += "破源者之冠，格古隆德_";
		thirtyfour  += "鋼鐵碼頭，格古隆德_";
		thirtyfive  += "暗潮棲息地，影月谷_";
		thirtysix  += "天海山脊，格古隆德_";
		thirtyseven  += "霜狼陣地，霜火峰_";
		thirtyeight  += "永茂林野地，格古隆德_";
		thirtynine  += "亞吉塔的小屋，影月谷_";
		forty  += "里茲特的營地，納葛蘭_";
		fortyone  += "尼維克的瞰臺，納葛蘭_";
		fortytwo  += "喬茲的萊拉克，納葛蘭_";
		fortythree  += "永茂林瞰臺，格古隆德_";
		fortyfour  += "沃爾瑪，塔南森林_";
		fortyfive  += "阿克塔崗哨，塔南森林_";
		fortysix  += "鋼鐵前線，塔南森林_";
		fortyseven  += "大地穹殿，塔南森林_";
		fortyeight  += "馬洛守望，塔南森林_";
		fortynine  += "夏納瑞營地，塔南森林_";
		
		// China
		one  += "流亡者高地，影月谷_";
		two  += "沃高尔，霜火岭_";
		three  += "刀塔堡垒，霜火岭_";
		four  += "索姆瓦尔，霜火岭_";
		five  += "血槌炉渣矿井，霜火岭_";
		six  += "岩牙岗哨，霜火岭_";
		seven  += "雷霆小径，霜火岭_";
		eight  += "暗矛之刃，霜火岭_";
		nine  += "战争之矛，阿什兰_";
		ten  += "霜壁要塞，霜火岭_";
		eleven  += "赞加拉，塔拉多_";
		twelve  += "霜狼岗哨，塔拉多_";
		thirteen  += "蛮兽岗哨，戈尔隆德_";
		fourteen  += "沃金之傲，塔拉多_";
		fifteen  += "杜隆坦之握，塔拉多_";
		sixteen  += "沙塔斯城，塔拉多_";
		seventeen  += "惩戒岗哨，塔拉多_";
		eighteen  += "大主教的避难所，塔拉多_";
		nineteen  += "泰罗卡避难所，塔拉多_";
		twenty  += "索克雷萨高地，影月谷_";
		twentyone  += "坠斧营地，阿兰卡峰林_";
		twentytwo  += "试炼竞技场，纳格兰_";
		twentythree  += "元素王座，纳格兰_";
		twentyfour  += "沃尔瓦，纳格兰_";
		twentyfive  += "河畔岗哨，纳格兰_";
		twentysix  += "泰罗克鸦巢，阿兰卡峰林_";
		twentyseven  += "鸦爪岗哨，阿兰卡峰林_";
		twentyeight  += "宾奇维斯零件工厂，阿兰卡峰林_";
		twentynine  += "棱堡高地，戈尔隆德_";
		thirty  += "埃匹希斯挖掘场，阿兰卡峰林_";
		thirtyone  += "永晨之泉，戈尔隆德_";
		thirtytwo  += "乌鸦小屋，阿兰卡峰林_";
		thirtythree  += "毁灭者之冠，戈尔隆德_";
		thirtyfour  += "钢铁码头，戈尔隆德_";
		thirtyfive  += "黑潮栖木，影月谷_";
		thirtysix  += "天海岭，戈尔隆德_";
		thirtyseven  += "霜狼阵地，霜火岭_";
		thirtyeight  += "永茂丛林，戈尔隆德_";
		thirtynine  += "阿基塔的小屋，影月谷_";
		forty  += "里尔兹特锚地，纳格兰_";
		fortyone  += "内维克的岗哨，纳格兰_";
		fortytwo  += "乔兹的双头飞龙，纳格兰_";
		fortythree  += "永茂岗哨，戈尔隆德_";
		fortyfour  += "沃玛尔，塔纳安丛林_";
		fortyfive  += "阿卡塔的岗哨，塔纳安丛林_";
		fortysix  += "钢铁前线，塔纳安丛林_";
		fortyseven  += "大地岩窟，塔纳安丛林_";
		fortyeight  += "玛洛岗哨，塔纳安丛林_";
		fortynine  += "沙纳尔避难所，塔纳安丛林_";
		
		return result;
	}
}

