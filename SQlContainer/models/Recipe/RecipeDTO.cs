public class RecipeDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Ingredient> Ingredients { get; set; } = new();
    public string IngredientName { get; set; } = string.Empty;
}