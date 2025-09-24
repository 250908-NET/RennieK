interface IRecipieService
{
    public Ingredient addIngredient(Ingredient newIngredient);
    public int removeIngredient(string oldname);

    List<Ingredient> showAllIngredients();
}