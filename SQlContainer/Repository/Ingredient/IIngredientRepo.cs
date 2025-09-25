interface IIngredientRepo
{
    public Task<List<Ingredient>> GetAllAsync();
    public Task<Ingredient> removeIngredientAsync(string oldname);

    public Task<Ingredient> addIngredientAsync(Ingredient item);
    public Task<List<Ingredient>> GetIngredientByNameAsync(string name);
}