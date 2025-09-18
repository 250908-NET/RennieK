using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.models.NoteTask;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);
var key = Encoding.ASCII.GetBytes("123ABC!gybuctgfvhbjkldfgvhbjnkmhjkghjk");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("access_token"))
            {
                Console.WriteLine("Token from cookie: " + context.Request.Cookies["access_token"]);
                context.Token = context.Request.Cookies["access_token"];
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

NoteService service = new NoteService();
UserService Uservice = new UserService();

// app.MapGet("/api/tasks/", () =>
// {
//     return service.getAllNoteTasks();
// });
app.MapGet("/api/tasks", (bool? isCompleted, string? priority) =>
{
    // List<NoteTask> filter = service.getAllNotesOnFilter(isCompleted, priority);
    // if (filter.Count == 0)
    // {
    //     return Results.NoContent();
    // }
    return service.getAllNotesOnFilter(isCompleted, priority);

});

app.MapGet("/api/tasks/{id}", (int id) =>
{
    // NoteService service = new NoteService();
    // NoteTask test = new NoteTask("hello", "testing123", true, "low", DateTime.Now);

    // service.addTask(test);
    // return "ok";
    NoteTask retrivedNoteTask = service.getTaskByID(id);
    if (retrivedNoteTask == null)
    {
        return Results.NotFound(new
        {
            success = false,
            data = "empty",
            message = $"Item id:{id} Not found"
        });
    }

    return Results.Ok(new
    {
        success = true,
        data = retrivedNoteTask,
        message = $"Item id:{retrivedNoteTask.id} found"
    });

});

app.MapPost("/api/tasks", (TaskBody todo) =>
{
    // NoteService service = new NoteService();
    NoteTask newCreatedTask = new NoteTask(todo.title, todo.description, todo.isCompleted, todo.priority, todo.dueDate);

    if (todo.title == "")
    {
        return Results.BadRequest(new
        {
            success = false,
            data = "empty",
            message = $"invalid Title"
        });
    }
    service.addTask(newCreatedTask);

    return Results.Created("/api/tasks", new
    {
        success = true,
        data = service.noteBook,
        message = $"Item id:{newCreatedTask.id} created"
    });
});

app.MapPut("/api/tasks/{id}", (int id, TaskBody todo) =>
{

    NoteTask noteEdit = service.getTaskByID(id);
    if (noteEdit == null)
    {
        return Results.NotFound(new
        {
            success = true,
            data = "",
            message = $"Item id:{id} not found"
        });
    }
    noteEdit.title = todo.title;
    noteEdit.description = todo.description;
    noteEdit.isCompleted = todo.isCompleted;
    noteEdit.dueDate = todo.dueDate;

    return Results.Created("/api/tasks/{id}", new
    {
        success = true,
        data = service.updatetask(noteEdit),
        message = $"Item id:{id} updated"
    });
});

app.MapDelete("/api/tasks/{id}", (int id) =>
{

    if (service.removeTaskById(id) == false)
    {
        return Results.NotFound(new
        {
            success = false,
            data = "NotFound",
            message = "Can not find object withthat id"
        }
        );
    }
    return Results.Ok(new
    {
        success = true,
        data = "",
        message = $"Item id:{id} deleted"
    });
});

app.MapPost("/api/createNewAccount", (UserBody loginAttempt, HttpResponse response) =>
{

    User createdUser = Uservice.createUser(loginAttempt.username, loginAttempt.password, loginAttempt.email);

    // service.login(loginAttempt.username, loginAttempt.password);

    var token = new JwtSecurityTokenHandler().WriteToken(
        new JwtSecurityToken(
            expires: DateTime.UtcNow.AddMinutes(5),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256)));

    response.Cookies.Append("access_token", token, new CookieOptions
    {
        HttpOnly = true,
        Secure = false,
        SameSite = SameSiteMode.Strict,
        Expires = DateTime.UtcNow.AddMinutes(30)
    });

    return Results.Ok(new { success = true, data = new { access_token = token, UserEmail = loginAttempt.email, Username = loginAttempt.username }, message = $"Created UserID: {createdUser.id}" });
});

app.MapPost("/api/login", (UserBody loginAttempt, HttpResponse res) =>
{

    User? findUser = Uservice.login(loginAttempt.username, loginAttempt.password);


    if (findUser != null)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        JwtSecurityToken token = new JwtSecurityToken(expires: DateTime.UtcNow.AddMinutes(5),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256)
        );
        string tokenString = tokenHandler.WriteToken(token);

        res.Cookies.Append("access_token", tokenString, new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddMinutes(30)
        });
        return Results.Ok(new { success = true, data = new { access_token = tokenString, UserEmail = loginAttempt.email, Username = loginAttempt.username }, message = $"logged in: {loginAttempt.username}" });

        // return Results.Ok("fine");

    }
    // return Results.Ok("not fine");
    return Results.Ok(new { success = false, data = new { UserEmail = loginAttempt.email, Username = loginAttempt.username }, message = $" Wrong Username or Password: {loginAttempt.username}" });
});

app.MapGet("/secure", [Microsoft.AspNetCore.Authorization.Authorize] () =>
    $"You are authorized! {Uservice.UserDatabase}"
);

app.Run();


