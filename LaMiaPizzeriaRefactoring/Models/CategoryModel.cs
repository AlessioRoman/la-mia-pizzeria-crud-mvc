namespace LaMiaPizzeriaRefactoring.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PizzaModel> PizzaModels { get; set; }

        public CategoryModel() { }
    }
}
