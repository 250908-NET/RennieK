using ManageApp.model;

class Task : TaskBase
{
    public Task() : base()
    {

    }

    public Task(string title, string description, bool completionStatus, string priority, DateTime dueDate, string category) : base(title, description, completionStatus, priority, dueDate, category)
    {
        this.title = title;
        this.description = description;
        this.completionStatus = completionStatus;
        this.priority = priority;
        this.dueDate = dueDate;
        this.category = category;
    }
}