namespace LibraConsole.Models
{
    public class Tijdschrift : MediaItem
    {
        public Tijdschrift(string titel, DateOnly publicatieDatum, int editieNummer, Frequentie frequentie)
            : base(titel, publicatieDatum)
        {
            EditieNummer = editieNummer;
            Frequentie = frequentie;
        }
        public int EditieNummer { get; set; }
        public Frequentie Frequentie { get; set; }
        //override voorbeeld
        public override bool IsDigitaal => false;

        public override string GetInfo()
        {
            return $"{base.GetInfo()}\n" +
                $"Editienummer: {EditieNummer}\n" +
                $"Nieuwe aflevering: {Frequentie}";
        }
        public override string ToString()
        {
            return $"Tijdschrift \"{Titel}\"";
        }
    }
}
