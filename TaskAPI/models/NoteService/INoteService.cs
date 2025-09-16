

using TaskAPI.models.NoteTask;

interface INoteService
{
    public List<NoteTask> getAllNoteTasks();
    public List<NoteTask> getAllNotesOnFilter(bool? isCompleted = false, string? priority = "");
    public NoteTask addTask(NoteTask newItem);
    public bool removeTaskById(int id);
    public NoteTask updatetask(NoteTask updatedItem);
    public List<NoteTask> getAllTask();
    public NoteTask getTaskByID(int id);

    public NoteTask editCategoryToTask(string name, NoteTask Task);
    public string RemoveCategory(string name);
    public string RemoveItemsByCategory(string name);


}