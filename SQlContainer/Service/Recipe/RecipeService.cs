class RecipeService : IRecipieService
{
    List<Ingredient> recipe = new List<Ingredient>();


    // Recipie()
    // {
    //     recipe = new List<Ingredient>();
    // }

    private readonly IRecipeRepo _recipeRepo;

    public RecipeService(IRecipeRepo recipeRepo)
    {
        _recipeRepo = recipeRepo;
    }
    public int removeIngredient(string oldname)
    {
        int removeCount = recipe.RemoveAll(Ingredient => Ingredient.name == oldname);
        return removeCount;


    }
    public Ingredient addIngredient(Ingredient newIngredient)
    {
        recipe.Add(newIngredient);
        return newIngredient;
    }

    public Task<Recipe> addRecipe(Recipe newRecipe)
    {
        return _recipeRepo.AddAsync(newRecipe);
    }

    public List<Ingredient> showAllIngredients()
    {
        return recipe;
    }
}