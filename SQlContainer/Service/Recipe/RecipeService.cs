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
    public Task<Recipe> removeIngredient(string oldname, Recipe recipe)
    {
        return _recipeRepo.removeIngrdientFromRecipeAsync(oldname, recipe);


    }
    public Task<Recipe> addIngredient(Ingredient newIngredient, Recipe recipe)
    {
        return _recipeRepo.addIngrdientToRecipeAsync(newIngredient, recipe);

    }

    public Task<Recipe> addRecipe(Recipe newRecipe)
    {
        return _recipeRepo.addRecipeAsync(newRecipe);
    }
    public Task<Recipe> removeRecipe(Recipe newRecipe)
    {
        return _recipeRepo.removeRecipeAsync(newRecipe);
    }
    // public List<Ingredient> showAllIngredients()
    // {
    //     return recipe;
    // }
}