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

    public string addName(string name, Ingredient item)
    {
        item.name = name;
        return name;
    }
    public float SetQuantity(float amount, Ingredient item)
    {
        item.quantity = amount;
        return amount;
    }
}
