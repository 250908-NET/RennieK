public interface IRecipeRepo
{
    // private readonly AppDbContext _context;


    public Task<List<Recipe>> GetAllRecipeAsync();
    public Task<Recipe> addRecipeAsync(Recipe newRecipe);
    public Task<Recipe> removeRecipeAsync(string recipeName);
    public Task<Recipe> addIngrdientToRecipeAsync(Ingredient ingredient, string nameOfRecipe);
    public Task<Recipe> removeIngrdientFromRecipeAsync(string RecipeName, string ingredientName);
}