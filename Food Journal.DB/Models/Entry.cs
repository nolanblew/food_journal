using System;
using System.Collections.Generic;

namespace Food_Journal.DB.Models
{
    public class Entry : BaseModel
    {
        public User User { get; set; }

        public int UserId { get; set; }

        public Location Location { get; set; }

        public int LocationId { get; set; }

        public DateTime DateTime { get; set; }

        public string Title { get; set; }

        public List<FoodItemEntry> FoodEntries { get; set; }

        public string Notes { get; set; }

        public double Rating { get; set; }
    }
}