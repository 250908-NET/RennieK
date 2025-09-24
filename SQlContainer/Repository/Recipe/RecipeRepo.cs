public class RecipeRepo
{
    private readonly AppDbContext _context;

    public RecipeRepo(AppDbContext context)
    {
        _context = context;
    }
    public Task<List<Recipe>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Recipe> AddAsync(Recipe newRecipe)
    {
        throw new NotImplementedException();
    }
}