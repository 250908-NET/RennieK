using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
string connection = File.ReadAllText("connection.txt");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connection));
builder.Services.AddScoped<IRecipeRepo, RecipeRepo>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

builder.Services.AddScoped<IIngredientRepo, IngredientRepo>();
builder.Services.AddScoped<IIngredientService, IngredientService>();

// builder.Services.AddControllers()
//     .AddJsonOptions(options =>
//     {
//         options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//     });

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();
// app.MapControllers();
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
    return Results.Ok(Ingredient);

});

app.MapPut("/cookbook/Recipe/update/{nameOfRecipe}", async (string nameOfRecipe, Ingredient ingredient, IRecipeService recipeService) =>
{
    var recipe = await recipeService.addIngredient(ingredient, nameOfRecipe);
    return Results.Ok(recipe);

});
app.MapDelete("/cookbook/Recipe/remove/{RecipeName}", async (string RecipeName, IRecipeService recipeService) =>
{
    var Ingredient = await recipeService.removeRecipe(RecipeName);
    return Results.Ok(Ingredient);

});
app.MapPatch("/cookbook/Recipe/remove", async (RecipeDTO DTO, IRecipeService recipeService) =>
{
    var Ingredient = await recipeService.removeIngredient(DTO.Name, DTO.IngredientName);
    return Results.Ok(Ingredient);

});

app.Run();

