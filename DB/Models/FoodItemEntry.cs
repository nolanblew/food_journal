using System.ComponentModel.DataAnnotations;

namespace Food_Journal.DB.Models
{
    public class FoodItemEntry : BaseModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public double Rating { get; set; }

        [Required]
        public Entry Entry { get; set; }

        public int EntryId { get; set; }
    }
}