
namespace Food_Journal.DB.Models
{
    public class FoodItemEntry : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public double Rating { get; set; }

        public Entry Entry { get; set; }

        public int EntryId { get; set; }
    }
}