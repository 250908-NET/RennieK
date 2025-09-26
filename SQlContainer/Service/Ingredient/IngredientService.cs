using System.Runtime.CompilerServices;
using Microsoft.Identity.Client;
using Microsoft.Net.Http.Headers;

class IngredientService : IIngredientService
{
    // public string name { get; set; }
    // public float quantity { get; set; }

    // public IngredientBase()
    // {
    //     this.name = "";
    //     this.quantity = 0;
    // }
    // public IngredientBase(string name, float quantity)
    // {
    //     this.name = name;
    //     this.quantity = quantity;
    // }
    private readonly IIngredientRepo _ingredientRepo;
    public IngredientService(IIngredientRepo repo)
    {
        _ingredientRepo = repo;
    }

    public Task<Ingredient> addIngredient(Ingredient item)
    {
        return _ingredientRepo.addIngredientAsync(item);
    }
    public Task<Ingredient> removeIngredient(string oldname)
    {
        return _ingredientRepo.removeIngredientAsync(oldname);
    }
    public async Task<List<Ingredient>> GetAllIngrdients()
    {
        return await _ingredientRepo.GetAllAsync();
    }
    public Task<List<Ingredient>> GetIngredientByName(string name)
    {
        return _ingredientRepo.GetAllAsync();
    }

}
