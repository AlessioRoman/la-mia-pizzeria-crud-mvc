using LaMiaPizzeriaRefactoring.Models.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMiaPizzeriaRefactoring.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }

        [MaxLength(40)]
        [StringLength(100, ErrorMessage = "Il campo titolo può essere lungo al massimo 100 caratteri")]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Il campo descrizione è obbligatorio!")]
        [MoreThanFiveWords(ErrorMessage = "Il campo descrizione deve contenere almeno 5 parole!")]
        public string Description { get; set; }

        [MaxLength(300)]
        [Required(ErrorMessage = "Il campo URL dell'immagine è obbligatorio")]
        [Url(ErrorMessage = "L'URL inserito non è un url valido!")]
        [StringLength(300, ErrorMessage = "Il campo URL immagine può contenere al massimo 300 caratteri")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Il prezzo è obbligatorio!")]
        [Range(0, 150, ErrorMessage = "Il prezzo non è valido!")]
        public float Price { get; set; }

        public int? CategoryId { get; set; }
        public CategoryModel? Category { get; set; }

        public PizzaModel()
        {

        }
        public PizzaModel(string name, string description, string imageUrl, float price)
        {
            this.Name = name;
            this.Description = description;
            this.ImageUrl = imageUrl;
            this.Price = price;
        }
    }
}
