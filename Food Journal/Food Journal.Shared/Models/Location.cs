namespace Food_Journal.Shared.Models
{
    public struct Location
    {
        public Location(double longitute, double latitude) : this()
        {
            Longitute = longitute;
            Latitude = latitude;
        }

        public double Longitute { get; set; }

        public double Latitude { get; set; }
    }
}
