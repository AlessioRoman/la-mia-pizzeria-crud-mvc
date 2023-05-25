namespace LaMiaPizzeriaRefactoring.Models
{
    public class PizzaFormModel
    {
        public PizzaModel Pizza { get; set; }
        public List<CategoryModel> Categories { get; set; }

        public PizzaFormModel() { }
    }
}
