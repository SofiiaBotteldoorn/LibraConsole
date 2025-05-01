using LibraConsole.Interfaces;

namespace LibraConsole.Models
{
    public delegate void BibliotheekBericht(MediaItem item, Lid lid);
    public abstract class MediaItem : IMediaItem
    {
        private readonly DateOnly EerstePublicatieJaar = new DateOnly(1450, 1, 1);
        public MediaItem(string titel, DateOnly publicatieDatum)
        {
            Titel = titel;
            PublicatieDatum = publicatieDatum;
        }
        private string titel;
        public string Titel
        {
            get => titel;
            init => titel = !string.IsNullOrWhiteSpace(value) ? value : "titel onbekend";
        }
        private DateOnly publicatieDatum;
        public DateOnly PublicatieDatum
        {
            get => publicatieDatum;
            set
            {
                if (value < EerstePublicatieJaar)
                    throw new Exception($"De publicatiedatum mag niet voor {EerstePublicatieJaar.ToShortDateString()} zijn");
                publicatieDatum = value;
            }
        }
        //abstract propertyvoorbeeld
        public abstract bool IsDigitaal { get; }
        public bool IsUitgeleend { get; set; }
        public DateTime? UitleenDatum { get; set; }
        public DateTime? InleveringDatum { get; set; }
        public Lid Lener { get; set; }

        public virtual string GetInfo()
        {
            return $"Titel - {Titel} \n" +
                $"Publicatie jaar - {PublicatieDatum}";
        }

        //Events voor uitlenen en inleveren van item
        public event BibliotheekBericht? MediaUitgeleend;
        public event BibliotheekBericht? MediaIngeleverd;

        //Uitlenen en inleveren
        public void Uitlenen(MediaItem item, Lid lid)
        {
            if (!IsDigitaal && !IsUitgeleend)
            {
                IsUitgeleend = true;
                Lener = lid;
                if (MediaUitgeleend != null)
                {
                    UitleenDatum = DateTime.Now;
                    /*Test voor boete berekening: 
                     * Console.WriteLine("Uitleendatum? (bv. "2025/03/20"); 
                     * DateTime.Parse(Console.ReadLine());*/
                    MediaUitgeleend(this, lid);
                }

            }
            else if (IsDigitaal)
            {
                Console.WriteLine($"Onmogelijk.Item {item.ToString()} is digitaal");
            }
            else if (IsUitgeleend)
            {
                Console.WriteLine($"{item.Titel} is al uitgeleend");
            }
        }
        public void Inleveren(MediaItem item, Lid lid)
        {
            if (IsUitgeleend)
            {
                if (Lener == null || Lener != lid)
                {
                    Console.WriteLine($"Onmogelijk. Alleen {Lener?.ToString()} mag dit item inleveren");
                }
                else
                {
                    IsUitgeleend = false;
                    if (MediaIngeleverd != null)
                    {
                        InleveringDatum = DateTime.Now;
                        MediaIngeleverd(this, lid);

                    }
                    UitleenDatum = null;
                    Lener = null;
                }
            }
            else
            {
                Console.WriteLine($"Onmogelijk. {item.Titel} was niet uitgelend");
            }
        }
    }
}
