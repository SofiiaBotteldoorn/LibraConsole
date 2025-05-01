
#region Data
using LibraConsole.Interfaces;
using LibraConsole.Models;
using static LibraConsole.Models.Persoon;

List<Auteur> auteurs = new List<Auteur>()
{
    new Auteur("Leo", "Tolstoy", "", new DateOnly(1828, 9, 9), "Rusland"),
    new Auteur("John", "Tolkien", null, new DateOnly(1892, 1, 3), "Verenigd Koninkrijk"),
    new Auteur("Mikhail", "Bulgakov", "", new DateOnly(1891, 5, 15), "Rusland"),
    new Auteur("Theodore", "Dreiser", "", new DateOnly(1871, 8, 27), "Verenigde Staten"),
    new Auteur("Eric", "Blair", "George Orwell", new DateOnly(1903, 6, 25), "Verenigd Koninkrijk"),
    new Auteur("Fyodor", "Dostoevsky", "", new DateOnly(1821, 11, 11), "Rusland")
};

List<Lid> leden = new List<Lid>
{
    new Lid("Saya", "Endo", new DateOnly(1992, 4, 3), 1001, new DateOnly(2020, 4, 29)),
    new Lid("Bram", "Vermeulen", new DateOnly(1988, 11, 17), 1002, new DateOnly(2018, 9, 15)),
    new Lid("Hans", "De Smet", new DateOnly(1965, 8, 1), 1003, new DateOnly(1999, 3, 10)),
    new Lid("Johan", "Van Dijk", new DateOnly(1963, 5, 5), 1004, new DateOnly(2010, 6, 1)),
    new Lid("Sofie", "Maes", new DateOnly(1990, 12, 12), 1005, new DateOnly(2017, 11, 20)),
    new Lid("Kaat", "Declercq", new DateOnly(1997, 8, 30), 1006, new DateOnly(2023, 1, 5)),
    new Lid("Thomas", "Janssens", new DateOnly(1985, 3, 25), 1007, new DateOnly(2015, 7, 18)),
    new Lid("Elke", "De Vos", new DateOnly(1993, 2, 14), 1008, new DateOnly(2019, 4, 21)),
    new Lid("Wouter", "Van Damme", new DateOnly(1991, 6, 8), 1009, new DateOnly(2022, 2, 11))
};

//Object maken met object initializer
Bibliotheek deKrook = new Bibliotheek
{
    BibliotheekId = 10,
    Naam = "De Krook",
    Stad = "Gent"
};
Bibliotheek bibliobus = new Bibliotheek
{
    BibliotheekId = 12,
    Naam = "Bibliobus",
    Stad = " Leuven"
};

Lezer narrator = new Lezer("Stephen", "Fry", new DateOnly(1957, 8, 24), StemType.Man);

//Inheritance polymorfisme met items array
MediaItem[] items = new MediaItem[4];
items[0] = new Boek(1, "War and Peace", auteurs[0], new DateOnly(1890, 5, 5), "9791234567891", Genre.Roman, 24.50m);
items[1] = new Tijdschrift("DeMorgen", new DateOnly(1970, 1, 1), 15, Frequentie.Wekelijks);
items[2] = new EBoek(3, "Silmarillion", auteurs[1], new DateOnly(1977, 9, 15), "9780618391110", Genre.Fantasie, 22.00m, EBoek.Formaat.PDF);
items[3] = new AudioBoek(7, "An American Tragedy", auteurs[3], new DateOnly(1925, 12, 17), "9780451527707", Genre.Roman, 16.50m, 1200, narrator);

//Inheritance polymorfisme met personenlijst
List<Persoon> personenLijst = new List<Persoon>() {
    new Auteur("Stephen", "King", "", new DateOnly(1947, 9, 21), "Verenigde Staten"),
    new Lezer("Emma", "Thompson", new DateOnly(1959, 4, 15), StemType.Vrouw),
    new Lid("Wesley", "Oostvogels", new DateOnly(1985, 9, 1), 1010, new DateOnly(2016, 8, 9))
};

//Interface polymorfisme
List<IIdentificeerbaar> objectenMetId = new List<IIdentificeerbaar>()
{
    new Bibliotheek { BibliotheekId = 11, Naam = "Hoboken Bibliotheek", Stad = "Antwerpen - Hoboken"},
    new Boek(2, "Crime and Punishment", auteurs[5], new DateOnly(1866, 1, 1), "9780140449136", Genre.Detective, 18.50m),
    new Lid("Michael", "Thys", new DateOnly(1979, 5, 30), 1011, new DateOnly(2000, 5, 5))
};

//Controleren of een object implementeerd interface
List<Object> gemengdeItems = new List<Object>()
{
    new Lezer("Ben", "Scott", new DateOnly(1987,2,2), StemType.Man),
    new Tijdschrift("National Geographic", new DateOnly(1888, 10, 1), 135, Frequentie.Maandelijks),
    new Boek(2, "1984", auteurs[4], new DateOnly(1949, 6, 8), "9780451524935", Genre.Distopie, 15.99m),
    new Lid("Shauna", "Shipman", new DateOnly(1990, 6, 13), 1013, new DateOnly(2020, 11, 5)),
    new EBoek(1, "Heart of a Dog", auteurs[2], new DateOnly(1925, 1, 1), "9781612191911", Genre.Roman, 11.75m, EBoek.Formaat.PDF)
};

//Nieuwe objecten toevoegen in lijst voor 7. pattern matching optie
gemengdeItems.Add(new AudioBoek(6, "The Shining", (Auteur)personenLijst[0], new DateOnly(1977, 1, 28), "9780307743657", Genre.Horror, 14.99m, 780, narrator));
gemengdeItems.Add(null);
gemengdeItems.Add("Welkom!");

//Boeken voor Uitlening en Inlevering scenarios
List<Boek> boeken = new List<Boek>()
{
    new Boek(3, "The Master and Margarita", auteurs[2], new DateOnly(1967, 1, 1), "9780141180144", Genre.Roman, 19.00m),
    new EBoek(1, "Heart of a Dog", auteurs[2], new DateOnly(1925, 1, 1), "9781612191911", Genre.Roman, 11.75m, EBoek.Formaat.PDF),
    new AudioBoek(2, "Anna Karenina", auteurs[0], new DateOnly(1878, 1, 1), "9780143035008", Genre.Roman, 22.99m, 1450, narrator),
    new Boek(4, "The Hobbit", auteurs[1], new DateOnly(1937, 9, 21), "9780261102217", Genre.Roman, 16.95m)
};

#endregion
while (true)
{

    Console.WriteLine("\nWelkom bij de bibliotheek!");
    Console.WriteLine("Kies een actie:");
    Console.WriteLine("1. Toon auteurs");
    Console.WriteLine("2. Toon leden");
    Console.WriteLine("3. Toon inheritance polymofism voorbeeld(met items[])");
    Console.WriteLine("4. Toon inheritance polymofism voorbeeld(met personenlijst)");
    Console.WriteLine("5. Toon Interface polymofism(objecten met ID)");
    Console.WriteLine("6. Controleer implementaties (Is IIdentificeerbaar)");
    Console.WriteLine("7. Toon pattern matching");
    Console.WriteLine("8. Test exceptions");
    Console.WriteLine("9. Voorkomen boete zonder uitleen datum");
    Console.WriteLine("10. Verander boete per dag");
    Console.WriteLine("11. Uitlening beheer");
    Console.WriteLine("12. Toon of dit lid heeft lidmaatschap verjaar vandaag");

    Console.WriteLine("0. Afsluiten");


    string keuze = Console.ReadLine();
    Console.Clear();

    switch (keuze)
    {
        case "1":
            Console.WriteLine("Auteurs:\n");
            ToonAuteurs();
            break;
        case "2":
            Console.WriteLine("Leden gesorteerd op registratie datum:\n");
            ToonLeden();
            break;
        case "3":
            Console.WriteLine("Inheritance polymofisme voorbeeld met items[]:\n");
            ToonInheritancePolymorfismMetItemsArray();
            break;
        case "4":
            Console.WriteLine("Inheritance polymofisme voorbeeld met personen:\n");
            ToonInheritancePolymorfismMetPersonen();
            break;
        case "5":
            Console.WriteLine("Interface polymorfisme: \n");
            InterfacePolymorfism();
            break;
        case "6":
            Console.WriteLine("Implementaties controle (Is IIdentificeerbaar):");
            ControleerIsIdentificeerbaar();
            break;
        case "7":
            Console.WriteLine("Pattern matching:\n");
            ToonPatternMatching();
            break;
        case "8":
            Console.WriteLine("Exceptions\n");
            TestExceptions();
            break;
        case "9":
            Console.WriteLine("Poging om boete zonder uiteling te rekenen\n");
            SimuleerVerkeerdeBoete();
            break;
        case "10":
            Console.WriteLine("Verander boete");
            VeranderBoete();
            break;
        case "11":
            Console.WriteLine("Uitlening simulatie");
            BeheerUitlening();
            break;
        case "12":
            Console.WriteLine("Lidmaatschap verjaar?");
            LidmaatschapVerjaar();
            break;
        case "0":
            Console.WriteLine("Tot ziens!");
            return;
        default:
            Console.WriteLine("Ongeldige invoer");
            break;
    }

    void ToonAuteurs()
    {
        var auteurLijst = from auteur in auteurs
                          orderby auteur.Familienaam
                          select auteur;
        foreach (var auteur in auteurLijst)
        {
            Console.WriteLine(auteur.GetPersoonInfo());
            Console.WriteLine();
        }
    }
    void ToonLeden()
    {
        var ledenLijst = leden.OrderBy(l => l.LidSinds);
        foreach (var lid in ledenLijst)
        {
            Console.WriteLine(lid.GetPersoonInfo());
            Console.WriteLine();
        }
    }
    void ToonInheritancePolymorfismMetItemsArray()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item.GetInfo());
            Console.WriteLine();
        }
    }
    void ToonInheritancePolymorfismMetPersonen()
    {
        foreach (var persoon in personenLijst)
        {
            Console.WriteLine(persoon.GetPersoonInfo());
            Console.WriteLine();
        }
    }
    void InterfacePolymorfism()
    {
        foreach (IIdentificeerbaar ding in objectenMetId)
        {
            Console.WriteLine(ding.IdInfo());
            Console.WriteLine();
        }

    }
    void ControleerIsIdentificeerbaar()
    {
        foreach (var ding in gemengdeItems)
            Console.WriteLine(ding is IIdentificeerbaar);
    }
    void ToonPatternMatching()
    {
        //Pattern matching voorbeeld voor verschillende soorten boeken
        foreach (var item in gemengdeItems)
        {
            switch (item)
            {
                case AudioBoek a when a?.Genre == Genre.Horror:
                    Console.WriteLine($"{a.Titel} is een {a.Genre}-audioboek geschreven door {a.Auteur.Voornaam} {a.Auteur.Familienaam}. Duurtijd is {a.DuurInMinuten} minuten, verteller: {a.Lezer.Voornaam} {a.Lezer.Familienaam}");
                    break;
                case EBoek e when e?.EBookFormaat == EBoek.Formaat.PDF:
                    Console.WriteLine($"{e.Titel} is een boek geschreven door {e.Auteur.Voornaam} {e.Auteur.Familienaam}. Beschikbaar in {e.EBookFormaat}");
                    break;
                case Boek b when b?.Genre == Genre.Distopie:
                    Console.WriteLine($"{b.Titel} is een {b.Genre} geschreven door {b.Auteur.Voornaam} {b.Auteur.Familienaam}");
                    break;
                case null:
                    Console.WriteLine($"null");
                    break;
                default:
                    Console.WriteLine($"{item.ToString()} is geen boek");
                    break;
            }
        }
    }

    void TestExceptions()
    {
        try
        {
            var foutiefLid = new Lid("453", "Lid", new DateOnly(1988, 1, 1), 1, new DateOnly(2015, 1, 1));
            Console.WriteLine($"Alles was juist ingevuld: {foutiefLid.GetPersoonInfo()}\n");
        }
        catch(VoornaamException ex) 
        {
            Console.WriteLine($"Fout:{ex.Message}: \"{ex.VerkeerdeVoornaam}\"");
        }
        catch (FamilienaamException ex)
        {
            Console.WriteLine($"Fout:{ex.Message}: \"{ex.VerkeerdeFamilienaam}\"");
        }
        catch (GeboortedatumException ex)
        {
            Console.WriteLine($"Fout:{ex.Message}: \"{ex.VerkeerdeGeboortedatum}\"");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fout:{ex.Message}");
        }
    }

    void SimuleerVerkeerdeBoete()
    {
        //Proberen per ongeluk ToonBoete aanropen zonder Uitleen en Inleverings datums
        try
        {
            Bibliotheek.ToonBoete(boeken[0]);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    void VeranderBoete()
    {
        //Nieuwe boete instellen
        Console.WriteLine("Tik nieuwe boete. Bv. 0,15");
        try
        {
            if (decimal.TryParse(Console.ReadLine(), out decimal nieuweBoete))
            {
                Bibliotheek.WijzigBoete(nieuweBoete);
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Boete niet aangepast");
            }
            Console.WriteLine($"Huidige boete per dag: {Bibliotheek.BoetePerDag} euro");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fout: {ex.Message}");
        }
    }

    //Uitlening en Inlevering simulatie
    Boek? BoekKiezen()
    {
        Console.WriteLine("\nBeschikbare boeken:");
        for (int i = 0; i < boeken.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {boeken[i].Titel}");
        }

        Console.Write("Kies een boek (nummer): ");
        if (!int.TryParse(Console.ReadLine(), out int boekIndex) || boekIndex < 1 || boekIndex >= boeken.Count + 1)
        {
            Console.WriteLine("Ongeldige keuze voor boek");
            return null;
        }
        else
        {
            return boeken[boekIndex - 1];
        }
    }
    Lid? LidKiezen()
    {
        Console.WriteLine("\nBeschikbare leden:");
        for (int i = 0; i < leden.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {leden[i].Voornaam} {leden[i].Familienaam}");
        }

        Console.Write("Kies een lid (nummer): ");
        if (!int.TryParse(Console.ReadLine(), out int lidIndex) || lidIndex < 1 || lidIndex >= leden.Count + 1)
        {
            Console.WriteLine("Ongeldige keuze voor lid");
            return null;
        }
        else
        {
            return leden[lidIndex - 1];
        }
    }
    void VoerUitleningUit(Boek boek, Lid lid)
    {
        //Event koppelen
        boek.MediaUitgeleend += deKrook.BevestigUitlening;
        boek.Uitlenen(boek, lid);
        boek.MediaUitgeleend -= deKrook.BevestigUitlening;
    }
    void VoerInleveringUit(Boek boek, Lid lid)
    {
        boek.MediaIngeleverd += deKrook.BevestigInlevering;
        boek.Inleveren(boek, lid);
        boek.MediaIngeleverd -= deKrook.BevestigInlevering;
    }
    void BeheerUitlening()
    {
        Boek? gekozenBoek = BoekKiezen();
        if (gekozenBoek == null)
        {
            return;
        }

        Lid? gekozenLid = LidKiezen();
        if (gekozenLid == null)
        {
            return;
        }
        Console.WriteLine("\nActies:");
        Console.WriteLine("1. Uitlenen");
        Console.WriteLine("2. Inleveren");
        Console.Write("Uw keuze: ");
        string actie = Console.ReadLine();

        if (actie == "1")
        {
            VoerUitleningUit(gekozenBoek, gekozenLid);
        }
        else if (actie == "2")
        {
            VoerInleveringUit(gekozenBoek, gekozenLid);
        }
        else
        {
            Console.WriteLine("Ongeldige actie");
        }
    }
    void LidmaatschapVerjaar()
    {
        Console.WriteLine("\nBeschikbare leden:");
        for (int i = 0; i < leden.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {leden[i].Voornaam} {leden[i].Familienaam}");
        }
        Console.WriteLine("\nKies een lid om te zien of vandaag is zijn lidmaatschap verjaar is");
        if (int.TryParse(Console.ReadLine(), out int lidIndex))
        {
            if (leden[lidIndex - 1].LidmaatschapVerjaar)
            {
                Console.WriteLine($"\n\"Vandaag verjaart het lidmaatschap van {leden[lidIndex - 1]}!");
            }
            else
            {
                Console.WriteLine($"\nVandaag is geen lidmaatschap verjaar van {leden[lidIndex - 1]}");
            }
        }
        else
        {
            Console.WriteLine("Ongeldige invoer");
        }
    }
}