public class Recipe
{
    public string Name { get; set; } = string.Empty;
    public int Id { get; set; }
    public List<Ingredient> IngredientList { get; set; } = new();



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