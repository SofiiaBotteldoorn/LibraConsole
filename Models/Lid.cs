using LibraConsole.Interfaces;

namespace LibraConsole.Models
{
    public class Lid : Persoon, IIdentificeerbaar
    {
        public Lid(string voornaam, string familienaam, DateOnly geboortedatum, int lidId, DateOnly lidsinds)
                : base(voornaam, familienaam, geboortedatum)
        {
            LidId = lidId;
            LidSinds = lidsinds;
        }
        public int LidId { get; set; }
        //Exception handeling met ArgumentException
        private DateOnly lidSinds;
        public DateOnly LidSinds
        {
            get => lidSinds;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Today))
                    throw new ArgumentException("Lidmaatschap kan niet in toekomst zijn!", nameof(lidSinds));
                lidSinds = value;
            }
        }
        //property met alleen getter
        public bool LidmaatschapVerjaar
        {
            get
            {
                return LidSinds.Month == DateTime.Today.Month
                    && LidSinds.Day == DateTime.Today.Day;
            }
        }
        public override string GetPersoonInfo()
        {
            return $"{base.GetPersoonInfo()} \n" +
                $"Lid sinds: {LidSinds}";
        }

        public string IdInfo()
        {
            return $"Lid: {Voornaam} {Familienaam}, lid id: {LidId} ";
        }
        public override string ToString()
        {
            return $"Lid {Voornaam} {Familienaam}";
        }
    }
}
