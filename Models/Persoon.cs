namespace LibraConsole.Models
{
    public abstract class Persoon
    {
        public Persoon(string voornaam, string familienaam, DateOnly geboortedatum)
        {
            Voornaam = voornaam;
            Familienaam = familienaam;
            Geboortedatum = geboortedatum;
        }
        private string voornaam;
        public string Voornaam
        {
            get => voornaam;
            init
            {
                if (string.IsNullOrWhiteSpace(value) || value.All(char.IsDigit))
                    throw new VoornaamException("Er werd verkeerd voornaam ingegeven!", value);
                voornaam = value;
            }
        }
        private string familienaam;
        public string Familienaam
        {
            get => familienaam;
            init
            {
                if (string.IsNullOrWhiteSpace(value) || value.All(char.IsDigit))
                    throw new FamilienaamException("Er werd verkeerd familienaam ingegeven!", value);
                familienaam = value;
            }
        }
        private DateOnly geboortedatum;
        public DateOnly Geboortedatum
        {
            get => geboortedatum;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Today))
                    throw new GeboortedatumException("Gebortedatum kan niet in toekomst zijn!", value);
                geboortedatum = value;
            }
        }
        public virtual string GetPersoonInfo()
        {
            return $"{Voornaam} {Familienaam}\n" +
                $"Geboortedatum {Geboortedatum}";
        }

        //Nested class met Eigen Exceptions om invoerfouten op te vangen
        public class VoornaamException : Exception
        {
            public string VerkeerdeVoornaam { get; set; }
            public VoornaamException(string message, string verkeerdeVoornaam)
                : base(message)
            {
                VerkeerdeVoornaam = verkeerdeVoornaam;
            }
        }
        public class FamilienaamException : Exception
        {
            public string VerkeerdeFamilienaam { get; set; }
            public FamilienaamException(string message, string verkeerdeFamilienaam)
                : base(message)
            {
                VerkeerdeFamilienaam = verkeerdeFamilienaam;
            }
        }

        public class GeboortedatumException : Exception
        {
            public DateOnly VerkeerdeGeboortedatum { get; set; }
            public GeboortedatumException(string message, DateOnly verkeerdeGeboortedatum)
                : base(message)
            {
                VerkeerdeGeboortedatum = verkeerdeGeboortedatum;
            }
        }
    }
}
