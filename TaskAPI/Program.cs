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
Dictionary<string, int> userDictionary = new Dictionary<string, int>();
// app.MapGet("/api/tasks/", () =>
// {
//     return service.getAllNoteTasks();
// });
app.MapGet("/api/tasks", [Microsoft.AspNetCore.Authorization.Authorize] (bool? isCompleted, string? priority, HttpRequest req) =>
{
    if (req.Cookies.TryGetValue("access_token", out var tokenString))
    {
        if (userDictionary.TryGetValue(tokenString, out int userID))
        {
            // NoteTask newCreatedTask = new NoteTask(todo.title, todo.description, todo.isCompleted, todo.priority, todo.dueDate);
            User? userObj = Uservice.findUserById(userID);
            if (userObj != null)
            {
                List<NoteTask> filteredNoteTask = userObj.Book.noteBook;
                if (filteredNoteTask.Count == 0)
                {
                    return Results.NotFound(new { success = false, data = "empty", message = $"No COntent found by." });
                }
                return Results.Created("/api/tasks", new
                {
                    success = true,
                    data = filteredNoteTask,
                    message = $"Items found."
                });

            }
        }
    }
    return Results.NotFound(new { success = false, data = "empty", message = $"No COntent found" });

});

app.MapGet("/api/tasks/{id}", [Microsoft.AspNetCore.Authorization.Authorize] (int id, HttpRequest req) =>
{
    // NoteService service = new NoteService();
    // NoteTask test = new NoteTask("hello", "testing123", true, "low", DateTime.Now);

    // service.addTask(test);
    // return "ok";
    if (req.Cookies.TryGetValue("access_token", out var tokenString))
    {
        if (userDictionary.TryGetValue(tokenString, out int userID))
        {
            // NoteTask newCreatedTask = new NoteTask(todo.title, todo.description, todo.isCompleted, todo.priority, todo.dueDate);
            User? userObj = Uservice.findUserById(userID);
            if (userObj != null)
            {
                NoteTask? filteredNoteTask = userObj.Book.getTaskByID(id);
                if (filteredNoteTask == null)
                {
                    return Results.NotFound(new { success = false, data = "empty", message = $"No COntent found by id:{id}" });
                }
                return Results.Created("/api/tasks", new
                {
                    success = true,
                    data = filteredNoteTask,
                    message = $"Item found."
                });

            }
        }
    }
    // NoteTask retrivedNoteTask = service.getTaskByID(id);
    // if (retrivedNoteTask == null)
    // {
    //     return Results.NotFound(new
    //     {
    //         success = false,
    //         data = "empty",
    //         message = $"Item id:{id} Not found"
    //     });
    // }

    // return Results.Ok(new
    return Results.NotFound(new { success = false, data = "empty", message = $"No COntent found by id:{id}" });

});

app.MapPost("/api/tasks", [Microsoft.AspNetCore.Authorization.Authorize] (TaskBody todo, HttpRequest req) =>
{

    // NoteService service = new NoteService();
    if (todo.title == "")
    {
        return Results.BadRequest(new
        {
            success = false,
            data = "empty",
            message = $"invalid Title"
        });
    }
    if (req.Cookies.TryGetValue("access_token", out var tokenString))
    {

        if (userDictionary.TryGetValue(tokenString, out int userID))
        {
            NoteTask newCreatedTask = new NoteTask(todo.title, todo.description, todo.isCompleted, todo.priority, todo.dueDate);
            User? userObj = Uservice.findUserById(userID);
            if (userObj != null)
            {
                userObj.Book.addTask(newCreatedTask);
                return Results.Created("/api/tasks", new
                {
                    success = true,
                    data = userObj.Book.noteBook,
                    message = $"Item id:{newCreatedTask.id} created"
                });

            }
        }
    }

    return Results.BadRequest();
    // service.addTask(newCreatedTask);


});

app.MapPut("/api/tasks/{id}", [Microsoft.AspNetCore.Authorization.Authorize] (int id, TaskBody todo, HttpRequest req) =>
{

    if (req.Cookies.TryGetValue("access_token", out var tokenString))
    {

        if (userDictionary.TryGetValue(tokenString, out int userID))
        {
            // NoteTask newCreatedTask = new NoteTask(todo.title, todo.description, todo.isCompleted, todo.priority, todo.dueDate);
            User? userObj = Uservice.findUserById(userID);
            NoteTask? noteEdit = userObj.Book.getTaskByID(id);
            if (userObj == null)
            {
                return Results.NotFound(new
                {
                    success = false,
                    data = "empty",
                    message = $"Item id:{id} created"
                });
            }

            if (noteEdit == null)
            {
                return Results.NotFound(new
                {
                    success = false,
                    data = "empty",
                    message = $"Item id:{id} created"
                });
            }
            noteEdit.title = todo.title;
            noteEdit.description = todo.description;
            noteEdit.isCompleted = todo.isCompleted;
            noteEdit.dueDate = todo.dueDate;
            userObj.Book.updatetask(noteEdit);
            return Results.Created("/api/tasks", new
            {
                success = true,
                data = userObj.Book.noteBook,
                message = $"Item id:{id} created"
            });
        }
    }

    // NoteTask noteEdit = service.getTaskByID(id);
    // if (noteEdit == null)
    // {
    //     return Results.NotFound(new
    //     {
    //         success = true,
    //         data = "",
    //         message = $"Item id:{id} not found"
    //     });
    // }
    // noteEdit.title = todo.title;
    // noteEdit.description = todo.description;
    // noteEdit.isCompleted = todo.isCompleted;
    // noteEdit.dueDate = todo.dueDate;

    return Results.NotFound(new
    {
        success = false,
        data = "empty",
        message = $"Item id:{id} updated"
    });
});

app.MapDelete("/api/tasks/{id}", [Microsoft.AspNetCore.Authorization.Authorize] (int id, HttpRequest req) =>
{

    if (req.Cookies.TryGetValue("access_token", out var tokenString))
    {
        if (userDictionary.TryGetValue(tokenString, out int userID))
        {
            // NoteTask newCreatedTask = new NoteTask(todo.title, todo.description, todo.isCompleted, todo.priority, todo.dueDate);
            User? userObj = Uservice.findUserById(userID);
            if (userObj == null)
            {
                // userObj.Book.addTask(newCreatedTask);
                return Results.NotFound(new
                {
                    success = false,
                    data = "",
                    message = $" id:{id} not found"
                });
            }
            if (userObj.Book.removeTaskById(id))
            {
                return Results.Accepted($"/api/tasks/{id}", new
                {
                    success = true,
                    data = "",
                    message = $" id:{id} removed"
                });
            }


        }
    }

    return Results.BadRequest(new
    {
        success = true,
        data = "",
        message = $"Bad Request"
    });
});

app.MapPost("/api/createNewAccount", (UserBody loginAttempt, HttpResponse response) =>
{

    User createdUser = Uservice.createUser(loginAttempt.username, loginAttempt.password, loginAttempt.email);

    // service.login(loginAttempt.username, loginAttempt.password);

    var token = new JwtSecurityTokenHandler().WriteToken(
        new JwtSecurityToken(
            expires: DateTime.UtcNow.AddMinutes(30),
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
        userDictionary.Add(tokenString, findUser.id);
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


