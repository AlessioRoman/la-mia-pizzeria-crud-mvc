using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeriaRefactoring.Models
{
    public class PrenotazioneModel
    {
        public int Id { get; set; }

        [MaxLength(40)]
        [StringLength(100, ErrorMessage = "Il campo titolo può essere lungo al massimo 100 caratteri")]
        public string Name { get; set; }

        public int NumberOfPeople { get; set; }

        public DateTime Date { get; set; }

        public PrenotazioneModel()
        {

        }
    }
}
