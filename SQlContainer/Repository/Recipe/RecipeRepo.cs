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
        await _context.SaveChangesAsync();
        return recipeToRemove;
    }
    public async Task<Recipe> addIngrdientToRecipeAsync(Ingredient ingredient, string nameOfRecipe)
    {
        var trackedRecipe = await _context.Recipes.Include(r => r.IngredientList).FirstOrDefaultAsync(r => r.Name == nameOfRecipe);

        if (trackedRecipe == null)
        {
            throw new Exception("Not Found");
        }
        var trackedIngredient = await _context.Ingredients
        .FirstOrDefaultAsync(i => i.name == ingredient.name);

        if (trackedIngredient == null)
        {
            trackedIngredient = ingredient;
            _context.Ingredients.Add(trackedIngredient);
        }
        trackedRecipe.IngredientList.Add(trackedIngredient);
        await _context.SaveChangesAsync();
        return trackedRecipe;
    }
    public async Task<Recipe> removeIngrdientFromRecipeAsync(string RecipeName, string ingredientName)
    {
        var trackedRecipe = await _context.Recipes.Include(r => r.IngredientList).FirstOrDefaultAsync(r => r.Name == RecipeName);

        if (trackedRecipe == null)
        {
            throw new Exception("Not Found");
        }
        var trackedIngredient = await _context.Ingredients
        .FirstOrDefaultAsync(i => i.name == ingredientName);

        if (trackedIngredient != null)
        {
            // trackedIngredient = ingredient;
            _context.Ingredients.Remove(trackedIngredient);
            trackedRecipe.IngredientList.Remove(trackedIngredient);
            await _context.SaveChangesAsync();
        }
        return trackedRecipe;
    }
}