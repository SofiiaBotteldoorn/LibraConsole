using LibraConsole.Interfaces;

namespace LibraConsole.Models
{
    public class Boek : MediaItem, IIdentificeerbaar
    {
        public Boek(int boekId, string titel, Auteur auteur, DateOnly publicatieDatum, string isbn, Genre genre, decimal prijs)
            : base(titel, publicatieDatum)
        {
            BoekId = boekId;
            Auteur = auteur;
            ISBN = isbn;
            Genre = genre;
            Prijs = prijs;
        }
        public int BoekId { get; init; }
        public Auteur Auteur { get; set; }


        private string isbn;
        public string ISBN
        {
            get => isbn;
            init
            {
                if (!IsGeldigeISBN(value))
                {
                    throw new ArgumentException("Ongeldige ISBN nummer", nameof(value));
                }
                isbn = value;
            }
        }
        public Genre Genre { get; set; }
        private decimal prijs;
        public decimal Prijs
        {
            get => prijs;
            set
            {
                if (value < 0m)
                    throw new ArgumentException("Prijs kan niet negatief zijn!", nameof(value));
                prijs = value;
            }
        }
        public override bool IsDigitaal => false;

        //Controleert of het ISBN correct is: lengte, cijfers, begint met: 978/979.
        private bool IsGeldigeISBN(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return false;
            if (isbn.Length != 13)
                return false;
            if (!isbn.All(char.IsDigit))
                return false;
            if (isbn.Substring(0, 3) != "978" && isbn.Substring(0, 3) != "979")
                return false;
            return true;
        }
        public override string GetInfo()
        {
            return $"BoekId: {BoekId}\n" +
                $"ISBN: {ISBN}\n" +
                $"{base.GetInfo()}\n" +
                $"Auteur {Auteur.GetPersoonInfo()}\n" +
                $"Genre {Genre}\n" +
                $"Prijs: {Prijs}";
        }

        public string IdInfo()
        {
            return $"Boek: {Titel}, boek id: {BoekId}";
        }
        public override string ToString()
        {
            return $"Boek \"{Titel}\n";
        }
    }
}
