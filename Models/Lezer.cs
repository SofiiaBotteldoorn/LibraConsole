namespace LibraConsole.Models
{
    //inheritance voorbeeld
    public class Lezer : Persoon
    {
        public Lezer(string voornaam, string familienaam, DateOnly geboortedatum, StemType stemType)
                    : base(voornaam, familienaam, geboortedatum)
        {
            StemType = stemType;
        }
        public StemType StemType { get; set; }
        public override string GetPersoonInfo()
        {
            return $"{base.GetPersoonInfo()} \n" +
                $"Stemtype: {StemType}";
        }
        public override string ToString()
        {
            return $"Lezer {Voornaam} {Familienaam}";
        }
    }
}
