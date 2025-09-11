using System.Runtime.InteropServices;
using System.Text;
using Microsoft.AspNetCore.Http.Features;
using System.Linq;

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

List<string> Colors = ["Red", "Green", "Blue", "Yellow"];
app.MapGet("/colors", () =>
{
    return new { ThePrimeColors = Colors };
});
app.MapGet("/colors/random", () =>
{
    Random rando = new Random();
    return new { Random = Colors[rando.Next(Colors.Count)] };
});
app.MapGet("/colors/search/{letter}", (String letter) =>
{
    Random rando = new Random();
    return new { IsThisYourColor = Colors.Where(find => find.Contains(letter.ToUpper())).ToList() };
});

app.MapPost("/colors/add/{newColor}", (String newColor) =>
{
    var result = Colors.Where(find => find.Contains(newColor)).ToList();
    if (result.Count > 0)
    {
        return new { ThePrimeColors = Colors };
    }
    Colors.Add(newColor);
    return new { ThePrimeColors = Colors };
});

// *******************************************************************************************************
static float C2F(float temp)
{
    float tempretureF = temp * (9f / 5f) + 32;
    return tempretureF;
}

static float C2K(float temp)
{
    float tempretureK = temp + 273.15f;
    return tempretureK;
}
static float F2C(float temp)
{
    float tempretureC = (temp - 32f) * (5f / 9f);
    return tempretureC;
}
static float F2K(float temp)
{
    float tempretureC = temp + 273.15f;
    return tempretureC;
}
static float K2F(float temp)
{
    float tempretureF = (temp - 273.15f) * (9f / 5f) + 32;
    return tempretureF;
}
static float K2C(float temp)
{
    float tempretureC = temp - 273.15f;
    return tempretureC;
}

app.MapGet("/temp/celsius-to-fahrenheit/{temp}", (float temp) =>
{
    float tempretureF = temp * (9f / 5f) + 32;
    return new { Infahrenheit = tempretureF };
});

app.MapGet("/temp/fahrenheit-to-celsius/{temp}", (float temp) =>
{
    float tempretureC = (temp - 32f) * (5f / 9f);
    return new { InCelsius = tempretureC };
});

app.MapGet("/temp/kelvin-to-celsius/{temp}", (float temp) =>
{
    float tempretureC = temp - 273.15f;
    return new { InCelsius = tempretureC };
});

app.MapGet("/temp/celsius-to-kelvin/{temp}", (float temp) =>
{
    float tempretureC = temp + 273.15f;
    return new { Inkelvin = tempretureC };
});

app.MapGet("/temp/compare/{temp1}/{unit1}/{temp2}/{unit2}", (float temp1, string unit1, float temp2, string unit2) =>
{

    var converstionDictionary = new Dictionary<(string unit1, string unit2), Func<float, float>>()
    {
        {("C","K"), x => C2K(x)},
        {("C","F"), x => C2F(x)},
        {("C","C"), x => x},

        {("F","K"), x => F2K(x)},
        {("F","F"), x => x},
        {("F","C"), x => F2C(x)},

        {("K","K"), x => x },
        {("K","F"), x => K2F(x)},
        {("K","C"), x => K2C(x)},

    };
    var tempOne = converstionDictionary[(unit1, unit2)](temp1);
    return $"{temp1} degrees {unit1} is {tempOne} in {unit2} \n the difference between {unit2} in {unit2} is {tempOne - temp2} ";
});


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
