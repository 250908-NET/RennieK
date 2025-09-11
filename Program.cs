using System.Runtime.InteropServices;
using System.Text;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/add/{a}/{b}", (double a, double b) =>
{
    return new
    {
        operation = "add",

        sum = a + b
    };
});

app.MapGet("/sub/{a}/{b}", (double a, double b) =>
{
    return new
    {
        operation = "subtract",

        difference = a - b
    };
});

app.MapGet("/mul/{a}/{b}", (double a, double b) =>
{
    return new
    {
        operation = "multiply",

        difference = a * b
    };
});

app.MapGet("/div/{a}/{b}", (int a, int b) =>
{
    try
    {
        var structure = new
        {
            operation = "divide",

            difference = a / b
        };
        return Results.Ok(structure);

    }
    catch (DivideByZeroException)
    {
        var structure = new
        {
            operation = "divide",

            difference = "can't divide by zero"
        };
        return Results.Ok(structure);
    }
});


app.MapGet("/text/reverse/{text}", (string text) =>
{
    var reversedTextArr = text.Reverse();
    var reversedText = new StringBuilder();

    foreach (var item in reversedTextArr)
    {
        reversedText.Append(item);
    }
    return reversedText.ToString();
});
app.MapGet("/text/{command}/{text}", (string command, string text) =>
{
    if (command == "uppercase")
    {
        return text.ToUpper();
    }
    else if (command == "lowercase")
    {
        return text.ToLower();
    }
    else
    {
        return "";
    }
});
app.MapGet("/text/count/{text}", (string text) =>
{
    int letterCount = text.Count();
    int vowelcount = 0;
    foreach (char element in text)
    {
        char item = char.ToLower(element);
        if ("aeiou".Contains(item))
        {
            vowelcount++;
        }

    }
    return new
    {
        HowManyLetters = letterCount,
        HowManyVowels = vowelcount
    };
});

app.MapGet("/text/palindrome/{text}", (string text) =>
{
    var reversedTextArr = text.Reverse();
    var reversedText = new StringBuilder();

    foreach (var item in reversedTextArr)
    {
        reversedText.Append(item);
    }

    if (reversedText.ToString() == text)
    {
        return "palindrome";
    }
    return "not palindrome";
});

app.MapGet("/date/today", () =>
{
    DateTime date = DateTime.Today;
    return date;
});

app.MapGet("/date/age/{birthyear}", (int birthyear) =>
{
    DateTime date = DateTime.Today;
    var age = date.Year - birthyear;
    return new { AgeOfPerson = age };
});

app.MapGet("/date/daysbetween/{date1}/{date2}", (DateTime date1, DateTime date2) =>
{
    // DateTime dateone = new DateTime(2025, 9, 10, 8, 0, 0); // September 10, 2025, 8:00 AM
    // DateTime datetwo = new DateTime(2025, 9, 12, 10, 30, 0);
    var age = date2 - date1;
    // return dateone;
    return new { daysPassed = age.Days };
});

app.MapGet("/date/weekday/{date}", (DateTime date) =>
{
    // DateTime date = DateTime.Today;
    // var age = date.Year - birthyear;
    var days = new[] { "fri", "sat", "sun", "mon", "tue", "wed", "thurs" };
    return new { dayOftheWeek = days[(byte)date.DayOfWeek] };
});
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
