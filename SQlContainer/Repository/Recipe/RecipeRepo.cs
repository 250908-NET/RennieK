public class RecipeRepo
{
    private readonly AppDbContext _context;

    public RecipeRepo(AppDbContext context)
    {
        _context = context;
    }
    public Task<List<Recipe>> GetAllRecipeAsync()
    {

        throw new NotImplementedException();
    }

    public Task<Recipe> addRecipeAsync(Recipe newRecipe)
    {
        throw new NotImplementedException();
    }

    public Task<Recipe> removeRecipeAsync(Recipe newRecipe)
    {
        throw new NotImplementedException();
    }
    public Task<Recipe> addIngrdientToRecipeAsync(Ingredient ingredient, Recipe recipe)
    {
        throw new NotImplementedException();
    }
    public Task<Recipe> removeIngrdientFromRecipeAsync(string name, Recipe recipe)
    {
        throw new NotImplementedException();
    }
}