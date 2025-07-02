using System.ComponentModel.DataAnnotations;

namespace Mobile_Inventory_Web_API.Model
{
    public class Mobile
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Brand { get; set; }

        public decimal Price { get; set; }
    }
}
