using Microsoft.EntityFrameworkCore;

public class IngredientRepo : IIngredientRepo
{
    private readonly AppDbContext _context;
    public IngredientRepo(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Ingredient>> GetAllAsync()
    {
        return await _context.Ingredients.Include(i => i.AssociatedRecipes).ToListAsync();
    }

    public async Task<Ingredient> removeIngredientAsync(string oldname)
    {
        var removedIngredient = await _context.Ingredients.FirstAsync(Ingredient => Ingredient.name == oldname);
        _context.Ingredients.Remove(removedIngredient);
        await _context.SaveChangesAsync();
        return removedIngredient;

    }

    public async Task<Ingredient> addIngredientAsync(Ingredient item)
    {
        await _context.Ingredients.AddAsync(item);
        await _context.SaveChangesAsync();
        return item;
    }
    public async Task<List<Ingredient>> GetIngredientByNameAsync(string name)
    {
        return await _context.Ingredients.Include(i => i.AssociatedRecipes).Where(ingredient => ingredient.name == name).ToListAsync();
    }
}