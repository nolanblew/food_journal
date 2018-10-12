using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_Journal.DB.Models
{
    public class Entry : BaseModel
    {
        [Required]
        public User User { get; set; }

        public int UserId { get; set; }

        [Required]
        public Location Location { get; set; }

        public int LocationId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        public string Title { get; set; }

        public List<FoodItemEntry> FoodEntries { get; set; }

        public string Notes { get; set; }

        public double Rating { get; set; }
    }
}