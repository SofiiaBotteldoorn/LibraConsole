namespace LibraConsole.Models
{
    public class AudioBoek : Boek
    {
        public AudioBoek(int boekId, string titel, Auteur auteur, DateOnly publicatieDatum, string isbn, Genre genre, decimal prijs, int duurInMinuten, Lezer lezer)
            : base(boekId, titel, auteur, publicatieDatum, isbn, genre, prijs)
        {
            DuurInMinuten = duurInMinuten;
            Lezer = lezer;
        }
        public int DuurInMinuten { get; set; }
        //Aggregation voorbeeld
        public Lezer Lezer { get; set; }
        public override bool IsDigitaal => true;
        public override string GetInfo()
        {
            return $"{base.GetInfo()}\n" +
                $"Lezer: {Lezer.GetPersoonInfo()}\n" +
                $"Duurtijd: {DuurInMinuten} minuten";
        }
        public override string ToString()
        {
            return $"Audioboek \"{Titel}\"";
        }
    }
}
