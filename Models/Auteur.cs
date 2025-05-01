namespace LibraConsole.Models
{
    public class Auteur : Persoon
    {
        public Auteur(string voornaam, string familienaam, string pseudoniem, DateOnly geboortedatum, string land)
                : base(voornaam, familienaam, geboortedatum)
        {
            Pseudoniem = pseudoniem;
            Land = land;
        }
        private string pseudoniem;
        public string Pseudoniem
        {
            get => pseudoniem;
            set => pseudoniem = !string.IsNullOrWhiteSpace(value) ? value : "Dit auteur heeft geen pseudoniem";
        }
        public string Land { get; set; }
        public override string GetPersoonInfo()
        {
            return $"{base.GetPersoonInfo()}\n" +
                $"Pseudoniem: {Pseudoniem}\n" +
                $"Land: {Land}";
        }
        public override string ToString()
        {
            return $"Schrijver {Voornaam} {Familienaam}";
        }
    }
}
