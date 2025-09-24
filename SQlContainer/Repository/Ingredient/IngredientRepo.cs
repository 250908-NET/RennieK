public class IngredientRepo
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
}