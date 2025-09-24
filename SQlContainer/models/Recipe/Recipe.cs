public class Recipe
{
    List<Ingredient> IngredientList { get; set; } = new();
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Recipie()
    // {
    //     recipe = new List<Ingredient>();
    // }
    // public int removeIngredient(string oldname)
    // {
    //     int removeCount = recipe.RemoveAll(Ingredient => Ingredient.name == oldname);
    //     return removeCount;


    // }
    // public Ingredient addIngredient(Ingredient newIngredient)
    // {
    //     recipe.Add(newIngredient);
    //     return newIngredient;
    // }

    // public List<Ingredient> showAllIngredients()
    // {
    //     return recipe;
    // }
}