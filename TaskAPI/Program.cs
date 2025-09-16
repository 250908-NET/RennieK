using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.models.NoteTask;

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

NoteService service = new NoteService();


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


app.Run();


