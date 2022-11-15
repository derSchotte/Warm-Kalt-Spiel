internal class WarmKaltSpiel {
    static int alteEingabe = 0;
    static int gesucht;
    static bool Hardcore;
    static int counter = 1;
    static string[,] normalScore = new string[10,2];
    static string[,] hardcoreScore = new string[10,2];

    public static void Main( string[] args) {
        Gewonnen();

        // Optional: Zufallszahl (1-1000), Highscore
        // - zwei Highscore Arrays für 1-100 und 1-1000
        // - Namen eintragen in Highscore am ende des Games
        // - Speichern der Highscore in eine json oder txt


    }

    private static void GameMode() {
        // - Abfrage normal oder Hardcore
        string eingabe;

        Console.WriteLine( "Welchen Modus wollen sie Spielen?" );
        Console.WriteLine( "(Normal [1-100]) oder (Hardcore [1-1000])" );
        eingabe = Console.ReadLine();

        if( eingabe.ToLower() == "normal" ) {
            Hardcore = false;
        } else if( eingabe.ToLower() == "hardcore" ) {
            Hardcore = true;
        }
    }

    private static void Gewonnen() {
        bool gewonnen = false;
        GameMode();

        gesucht = GenerateRandom();

        do {
            if( Ueberpruefen( Eingaben() ) ) {
                gewonnen = true;
            }
        } while( !gewonnen );

        //EingabeHighscore();
    }

    private static void EingabeHighscore() {
        string name;
        string versuche;

        do {
            Console.WriteLine( "Geben sie 3 Zeichen als Namen ein!" );
            name = Console.ReadLine();
        } while( name.Length != 3 );

        versuche = counter.ToString();

        //if(Hardcore == true) {
        //    hardcoreScore = hardcoreScore.Concat(new string[,] { { name, versuche } } ).ToArray();
        //}
    }

    // Zufallszahl generieren zwischen min und max, wobei min und max aktuell feste werte sind.
    private static int GenerateRandom() {
        Random random = new Random();

        if( Hardcore == true ) {
            return random.Next( 1, 1001 );
        } else {
            return random.Next( 1, 101 );
        }
    }

    private static int Eingaben() {
        // User-Eingabe anlegen: DAU, Ersteingabe, Treffer?
        int eingabe = 0;
        bool check;
        Console.WriteLine( $"Versuche: {counter}" );

        do {
            if( Hardcore == true ) {
                Console.WriteLine( "Gib eine Zahl ein zwischen 1 und 1000" );
            } else {
                Console.WriteLine( "Gib eine Zahl ein zwischen 1 und 100" );
            }

            check = int.TryParse( Console.ReadLine(), out eingabe );

            if( !check ) {
                Console.WriteLine( "Gib eine Zahl ein... z.B. sowas wie 42!\n" );
            } else if( eingabe == 0 ) {
                Console.WriteLine( "Spassvogel, aber Ok es war ein Versuch" );
            }

        } while( !check );

        counter++;
        return eingabe;
    }

    private static bool Ueberpruefen( int eingabe ) {
        if( eingabe == gesucht ) {
            if( gesucht == 42 ) {
                Console.WriteLine( $"Die Antwort auf alle Fragen: {gesucht}" );
            } else {
                Console.WriteLine( $"Super, die eingabe {eingabe} ist gleich {gesucht}" );
            }
            return true;
        }

        int alt = Math.Abs(alteEingabe - gesucht);
        int neu = Math.Abs(eingabe - gesucht);

        if( alt > neu ) {
            Console.WriteLine( $"WÄRMER..." );
        } else if( alt < neu ) {
            Console.WriteLine( $"KÄLTER..." );
        }

        alteEingabe = eingabe;

        return false;
    }
}