using System.Runtime.CompilerServices;
using Microsoft.Identity.Client;
using Microsoft.Net.Http.Headers;

public class Ingredient
{
    public int Id { get; set; } // Primary Key
    public string name { get; set; }
    public float quantity { get; set; }

    public List<Recipe> AssociatedRecipes { get; set; } = new();

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

    // public string addName(string name)
    // {
    //     this.name = name;
    //     return name;
    // }
    // public float SetQuantity(float amount)
    // {
    //     this.quantity = amount;
    //     return amount;
    // }
}
