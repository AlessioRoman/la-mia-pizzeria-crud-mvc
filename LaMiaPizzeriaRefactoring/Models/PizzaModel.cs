using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMiaPizzeriaRefactoring.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [MaxLength(300)]
        public string ImageUrl { get; set; }
        public float Price { get; set; }

        public PizzaModel(string name, string description, string imageUrl, float price)
        {
            this.Name = name;
            this.Description = description;
            this.ImageUrl = imageUrl;
            this.Price = price;
        }
    }
}
