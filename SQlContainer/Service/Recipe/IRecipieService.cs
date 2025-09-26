interface IRecipieService
{
    // public Ingredient addIngredient(Ingredient newIngredient);
    // public int removeIngredient(string oldname);
    // public Task<Recipe> addRecipe(Recipe newRecipe);


    // public Task<Recipe> removeRecipe(Recipe newRecipe);
    // List<Ingredient> showAllIngredients();

    public Task<Recipe> removeIngredient(string oldname, Recipe recipe);
    public Task<Recipe> addIngredient(Ingredient newIngredient, Recipe recipe);
    public Task<Recipe> addRecipe(Recipe newRecipe);
    public Task<Recipe> removeRecipe(Recipe newRecipe);
}