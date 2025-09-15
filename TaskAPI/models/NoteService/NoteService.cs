


using TaskAPI.models.NoteTask;

class NoteService : INoteService
{
    public List<NoteTask> noteBook = new List<NoteTask>();

    public NoteService()
    {
        noteBook = new List<NoteTask>();
    }

    public List<NoteTask> getAllNoteTasks()
    {
        return noteBook;
    }

    public List<NoteTask> getAllNotesOnFilter(bool isCompleted = false, string priority = "")
    {
        List<NoteTask> filter = noteBook.FindAll(Note =>
        {
            if (Note.isCompleted == isCompleted || Note.priority == priority)
            {
                return true;
            }
            return false;
        });
        return filter;
    }

    public NoteTask addTask(NoteTask newItem)
    {
        try
        {
            noteBook.Add(newItem);
            return newItem;
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public void removeTaskById(int id)
    {
        try
        {
            NoteTask objToRemove = noteBook.Find(objects => objects.id == id);
            if (objToRemove == null)
            {
                return;
            }
            noteBook.Remove(objToRemove);
        }
        catch (System.Exception)
        {

            throw;
        }
    }
    public NoteTask updatetask(NoteTask updatedTask)
    {
        int indexOfQuery = noteBook.FindIndex(objects => objects.id == updatedTask.id);


        noteBook[indexOfQuery] = updatedTask;

        return updatedTask;
    }
    public List<NoteTask> getAllTask()
    {
        return noteBook;
    }
    public NoteTask getTaskByID(int id)
    {
        try
        {
            NoteTask objbyId = noteBook.Find(objects => objects.id == id);
            return objbyId;
        }
        catch
        {
            throw;
        }
    }


    public NoteTask editCategoryToTask(string name, NoteTask Task)
    {
        Task.category = name;
        return Task;
    }
    public string RemoveCategory(string name)
    {
        foreach (NoteTask item in this.noteBook)
        {

            if (item.category == name)
            {
                item.category = "";
                // removeTaskById(item.id);
            }
        }
        return "";
    }

    public string RemoveItemsByCategory(string name)
    {
        foreach (NoteTask item in this.noteBook)
        {

            if (item.category == name)
            {
                // Add a log deleted Item later
                removeTaskById(item.id);
            }
        }
        return "";
    }
}