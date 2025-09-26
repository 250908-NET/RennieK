using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=wizardly_noyce;User Id=sa;Password=babadoie2&*(97349846457;TrustServerCertificate=True;"));
builder.Services.AddScoped<IRecipeRepo, RecipeRepo>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

builder.Services.AddScoped<IIngredientRepo, IngredientRepo>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
// IngredientService ingredientService = new IngredientService();

app.MapGet("/cookbook/Ingredients", async (IIngredientService ingredientService) =>
{
    var Ingredients = await ingredientService.GetAllIngrdients();
    return Results.Ok(Ingredients);

});

app.MapGet("/cookbook/Ingredients/{name}", async (string name, IIngredientService ingredientService) =>
{
    var Ingredient = await ingredientService.GetIngredientByName(name);
    return Ingredient;
});

app.MapPost("/cookbook/Ingredient/add", async (Ingredient item, IIngredientService ingredientService) =>
{
    var Ingredient = await ingredientService.addIngredient(item);

});

app.MapDelete("/cookbook/Ingredient/remove/{name}", async (string name, IIngredientService ingredientService) =>
{
    var Ingredient = await ingredientService.removeIngredient(name);

});
// **************************************************************************************************************************************
app.MapGet("/cookbook/Recipe", async (IRecipeService recipeService) =>
{
    var Ingredients = await recipeService.GetAllRecipes();
    return Results.Ok(Ingredients);

});
app.MapGet("/cookbook/Recipe/{name}", async (string name, IRecipeService recipeService) =>
{
    var Ingredients = await recipeService.GetRecipeByName();
    return Results.Ok(Ingredients);

});

app.MapPost("/cookbook/Recipe/add", async (Recipe item, IRecipeService recipeService) =>
{
    var Ingredient = await recipeService.addRecipe(item);

});

app.MapDelete("/cookbook/Recipe/remove/{name}", async (string name, IRecipeService recipeService) =>
{
    var Ingredient = await recipeService.removeRecipe(name);

});

app.Run();

