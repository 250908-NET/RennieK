using Microsoft.EntityFrameworkCore.Migrations.Operations;

interface IIngredientService
{
    public string addName(string name, Ingredient item);
    public float SetQuantity(float amount, Ingredient item);
}