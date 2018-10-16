using System.Collections.Generic;

namespace Food_Journal.DB.Models
{
    public class Location : BaseModel
    {
        public string GoogleMapsId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public List<Entry> Entries { get; set; }
    }
}