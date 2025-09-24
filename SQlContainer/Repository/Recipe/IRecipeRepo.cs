public interface IRecipeRepo
{
    // private readonly AppDbContext _context;


    public Task<List<Recipe>> GetAllAsync();
    public Task<Recipe> AddAsync(Recipe newRecipe);
}