using Microsoft.EntityFrameworkCore.Migrations.Operations;

interface IIngredientService
{
    // public string addName(string name, Ingredient item);
    // public float SetQuantity(float amount, Ingredient item);


    public Task<Ingredient> addIngredient(Ingredient item);
    public Task<Ingredient> removeIngredient(string oldname);
    public Task<List<Ingredient>> GetAllIngrdients();
    public Task<List<Ingredient>> GetIngredientByName(string name);


}