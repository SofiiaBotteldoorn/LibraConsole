using LibraConsole.Interfaces;

namespace LibraConsole.Models
{
    public class Bibliotheek : IIdentificeerbaar
    {
        public required int BibliotheekId { get; init; }
        public required string Naam { get; init; }
        public required string Stad { get; init; }
        //static property met dfault waarde + property met mixed access level
        public static decimal BoetePerDag { get; private set; } = 0.25m;

        //verandert de boete per dag voor private set. Alleen positieve waarden zijn toegestaan
        public static void WijzigBoete(decimal nieuweBoete)
        {
            if (nieuweBoete <= 0m)
                throw new ArgumentException("Nieuwe boete moet positief zijn!");
            BoetePerDag = nieuweBoete;
            Console.WriteLine($"Nieuwe boete per dag is ingesteld op: {nieuweBoete} euro.");
        }

        public void BevestigUitlening(MediaItem item, Lid lid)
        {
            Console.WriteLine($"Uw uitlening: {item.Titel} uitgelend door {lid.Voornaam} {lid.Familienaam} op {item.UitleenDatum}");
        }

        public void BevestigInlevering(MediaItem item, Lid lid)
        {
            Console.WriteLine($"Uw uitlening: {item.Titel}  teruggebracht door {lid.Voornaam} {lid.Familienaam} op {item.InleveringDatum}");
            ToonBoete(item);
        }
        public static decimal BerekenBoete(MediaItem item)
        {
            if (item.UitleenDatum == null || item.InleveringDatum == null)
                throw new InvalidOperationException("Uitleen- of inleverdatum is niet ingevuld!");

            TimeSpan aantalDagen = (TimeSpan)(item.InleveringDatum - item.UitleenDatum);
            int dagenTeLaat = Math.Max(0, aantalDagen.Days - 20);
            return dagenTeLaat * BoetePerDag;

        }
        public static void ToonBoete(MediaItem item)
        {

            decimal teBetalen = BerekenBoete(item);
            TimeSpan aantalDagen = (TimeSpan)(item.InleveringDatum - item.UitleenDatum);
            if (teBetalen > 0m)
            {
                Console.WriteLine($"Dagen overtijd: {aantalDagen.Days - 20}. Boete:{teBetalen} euro.");
            }
            else
            {
                Console.WriteLine("Dank u voor het tijdig terugbrengen!");
            }
            Console.WriteLine($"Aantal dagen uitgeleend: {aantalDagen.Days}");
        }
        public string IdInfo()
        {
            return $"Bibliotheek: {Naam} bibliotheek id: {BibliotheekId}\n" +
                $"Stad: {Stad}\n" +
                $"Boete per dag bij deze bibliotheek: {BoetePerDag} euro";
        }
        public override string ToString()
        {
            return $"Bibliotheek {Naam}";
        }
    }
}
