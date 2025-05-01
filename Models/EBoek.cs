namespace LibraConsole.Models
{
    public class EBoek : Boek
    {
        public EBoek(int boekId, string titel, Auteur auteur, DateOnly publicatieDatum, string isbn, Genre genre, decimal prijs, Formaat eboekFormaat)
            : base(boekId, titel, auteur, publicatieDatum, isbn, genre, prijs)
        {
            EBookFormaat = eboekFormaat;
        }
        //Mogelijkheid enum binnen class hebben
        public enum Formaat
        {
            PDF,
            EPUB,
            MOBI,
            TXT
        }
        public Formaat EBookFormaat { get; set; }
        public override bool IsDigitaal => true;
        public override string GetInfo()
        {
            return $"{base.GetInfo()}\n" +
                $"Formaat: {EBookFormaat}";
        }
        public override string ToString()
        {
            return $"EBoek \n{Titel}\n";
        }
    }
}
