namespace ManageApp.model;

abstract class TaskBase
{
    public string title { get; set; }
    public string description { get; set; }
    public bool completionStatus { get; set; }
    public string priority { get; set; }//high, medium, low
    public DateTime dueDate { get; set; }
    public string category { get; set; }

    // public ToDoService[] listofTasks { get; set; }

    public TaskBase()
    {
        title = "";
        description = "";
        completionStatus = false;
        priority = "low";
        dueDate = DateTime.Today;
        category = "";
        // listofTasks = [];
    }

    public TaskBase(string newTitle, string newDescription, bool complete, string urgency, DateTime dateDue, string cat, ToDoService[] list)
    {
        title = newTitle;
        description = newDescription;
        completionStatus = complete;
        priority = urgency;
        dueDate = dateDue;
        category = cat;
        // listofTasks = list;
    }

    protected TaskBase(string title, string description, bool completionStatus, string priority, DateTime dueDate, string category)
    {
        this.title = title;
        this.description = description;
        this.completionStatus = completionStatus;
        this.priority = priority;
        this.dueDate = dueDate;
        this.category = category;
    }
}