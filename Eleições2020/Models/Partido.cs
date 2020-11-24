namespace Eleições2020.Models
{
    class Partido
    {
        public Partido(string p_partido)
        {
            partido = p_partido;
        }

        public override string ToString()
        {
            return partido;
        }

        public string partido { get; set; }
    }
}
