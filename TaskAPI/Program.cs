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


app.MapGet("/api/tasks", () =>
{
    return service.getAllNoteTasks();
});
app.MapGet("/api/tasks/filter/{filter}", (string filter) =>
{
    switch (filter)
    {
        case "isCompleted":
            return service.getAllNotesOnFilter(true);
        case "low":
            return service.getAllNotesOnFilter(false, "low");
        case "high":
            return service.getAllNotesOnFilter(false, "high");
        case "isNotCompleted":
            return service.getAllNotesOnFilter(false);
    }
    return service.getAllNoteTasks();
});
app.MapGet("/api/tasks/{id}", (int id) =>
{
    // NoteService service = new NoteService();
    // NoteTask test = new NoteTask("hello", "testing123", true, "low", DateTime.Now);

    // service.addTask(test);
    // return "ok";

    return service.getTaskByID(id);

});

app.MapPost("/api/tasks", (TaskBody todo) =>
{
    // NoteService service = new NoteService();
    NoteTask newCreatedTask = new NoteTask(todo.title, todo.description, todo.isCompleted, todo.priority, todo.dueDate);

    service.addTask(newCreatedTask);

    return service.noteBook;
});

app.MapPut("/api/tasks/{id}", (int id, TaskBody todo) =>
{
    NoteTask noteEdit = service.getTaskByID(id);
    noteEdit.title = todo.title;
    noteEdit.description = todo.description;
    noteEdit.isCompleted = todo.isCompleted;
    noteEdit.dueDate = todo.dueDate;

    return service.updatetask(noteEdit);
});

app.MapDelete("/api/tasks/{id}", (int id) =>
{
    service.removeTaskById(id);
    return "removed";
});


app.Run();


