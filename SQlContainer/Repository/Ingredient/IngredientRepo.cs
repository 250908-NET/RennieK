public class IngredientRepo : IIngredientRepo
{
    private readonly AppDbContext _context;
    public IngredientRepo(AppDbContext context)
    {
        _context = context;
    }
    public Task<List<Ingredient>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Ingredient> removeIngredientAsync(string oldname)
    {
        throw new NotImplementedException();
    }

    public Task<Ingredient> addIngredientAsync(Ingredient item)
    {
        throw new NotImplementedException();
    }
    public Task<List<Ingredient>> GetIngredientByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}