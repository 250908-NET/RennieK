namespace TaskAPI.models.NoteTask;

class NoteTask : NoteTaskBase
{
    public NoteTask()
    {

    }
    public NoteTask(string title, string description, bool isCompleted, string priority, DateTime duedate) : base(title, description, isCompleted, priority, duedate)
    {


    }
}