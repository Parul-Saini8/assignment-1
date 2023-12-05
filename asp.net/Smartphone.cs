// Models/Smartphone.cs

namespace SmartphoneManagement.Models
{
    public class Smartphone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }

        // New properties for Assignment 2
        public DateTime ReleaseDate { get; set; }
        public bool IsAvailable { get; set; }
    }
}
