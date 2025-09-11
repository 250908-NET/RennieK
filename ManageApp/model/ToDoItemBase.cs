namespace ManageApp.model;

abstract class ToDoItemBase
{
    public string title { get; set; }
    public string description { get; set; }
    public bool completionStatus { get; set; }
    public string priority { get; set; }//high, medium, low
    public DateTime dueDate { get; set; }
    public string category { get; set; }

    public ToDoService[] listofTasks { get; set; }

    public ToDoItemBase()
    {
        title = "";
        description = "";
        completionStatus = false;
        priority = "low";
        dueDate = DateTime.Today;
        category = "";
    }

    public ToDoItemBase(string newTitle, string newDescription, bool complete, string urgency, DateTime dateDue, string cat)
    {
        title = newTitle;
        description = newDescription;
        completionStatus = complete;
        priority = urgency;
        dueDate = dateDue;
        category = cat;
    }




}