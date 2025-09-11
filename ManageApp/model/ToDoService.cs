using System.Reflection;
using ManageApp.model;

class ToDoService : ToDoItemBase
{

    // ToDoService[] listofTasks;
    public ToDoService() : base()
    {
        // this.title = "";
        // this.description = "";
        // // this.completionStatus = false;

    }
    public ToDoService(string title, string description, bool completionStatus, string priority, DateTime dueDate, string category, ToDoService listofTasks) : base(title, description, completionStatus, priority, dueDate, category)
    {
        this.title = title;
        this.description = description;
        this.completionStatus = completionStatus;
        this.priority = priority;
        this.dueDate = dueDate;
        this.category = category;
        this.listofTasks = [];
    }

    public void addItem(ToDoService item)
    {
        this.listofTasks.Append(item);
    }
    public void showAllItems(bool onlyTitle)
    {

        foreach (var item in listofTasks)
        {
            Console.WriteLine(item.title);
            if (onlyTitle == false)
            {
                Console.WriteLine(item.description);
                Console.WriteLine(item.completionStatus);
                Console.WriteLine(item.priority);
                Console.WriteLine(item.dueDate);
                Console.WriteLine(item.category);
            }
        }
    }
    public void markComplete(int index, bool complete)
    {
        this.listofTasks[index].completionStatus = complete;
    }
    public string showToDo()
    {
        return $@"
        Title: {this.title}
        description: {this.description}
        completed: {(this.completionStatus ? "Finished" : "Unfinished")}

        ";
    }


}