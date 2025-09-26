using Microsoft.EntityFrameworkCore;

public class RecipeRepo : IRecipeRepo
{
    private readonly AppDbContext _context;

    public RecipeRepo(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Recipe>> GetAllRecipeAsync()
    {

        return await _context.Recipes.Include(r => r.IngredientList).ToListAsync();
    }

    public async Task<Recipe> addRecipeAsync(Recipe newRecipe)
    {
        await _context.Recipes.AddAsync(newRecipe);
        await _context.SaveChangesAsync();
        return newRecipe;
    }

    public async Task<Recipe> removeRecipeAsync(string name)
    {
        var recipeToRemove = await _context.Recipes.FirstAsync(r => r.Name == name);
        _context.Remove(recipeToRemove);
        return recipeToRemove;
    }
    public async Task<Recipe> addIngrdientToRecipeAsync(Ingredient ingredient, Recipe recipe)
    {
        var trackedRecipe = await _context.Recipes.Include(r => r.IngredientList).FirstOrDefaultAsync(r => r.Id == recipe.Id);

        if (trackedRecipe == null)
        {
            throw new Exception("Not Found");
        }
        var trackedIngredient = await _context.Ingredients
        .FirstOrDefaultAsync(i => i.Id == ingredient.Id);

        if (trackedIngredient == null)
        {
            trackedIngredient = ingredient;
            _context.Ingredients.Add(trackedIngredient);
        }
        trackedRecipe.IngredientList.Add(trackedIngredient);
        await _context.SaveChangesAsync();
        return trackedRecipe;
    }
    public Task<Recipe> removeIngrdientFromRecipeAsync(string name, Recipe recipe)
    {
        throw new NotImplementedException();
    }
}