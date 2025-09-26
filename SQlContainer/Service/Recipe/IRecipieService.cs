interface IRecipeService
{
    // public Ingredient addIngredient(Ingredient newIngredient);
    // public int removeIngredient(string oldname);
    // public Task<Recipe> addRecipe(Recipe newRecipe);


    // public Task<Recipe> removeRecipe(Recipe newRecipe);
    // List<Ingredient> showAllIngredients();
    public Task<List<Recipe>> GetAllRecipes();
    public Task<List<Recipe>> GetRecipeByName();
    public Task<Recipe> removeIngredient(string oldname, string recipename);
    public Task<Recipe> addIngredient(Ingredient newIngredient, string nameOfRecipe);
    public Task<Recipe> addRecipe(Recipe newRecipe);
    public Task<Recipe> removeRecipe(string recipeName);
}