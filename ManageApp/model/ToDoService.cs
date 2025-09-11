using System.Collections.Generic;
using System.Reflection;
using ManageApp.model;
using Microsoft.VisualBasic;

class ToDoService
{

    List<Task> listofTasks = new List<Task>();

    public ToDoService() : base()
    {
        this.listofTasks = new List<Task>();
    }


    public void addItem(Task item)
    {
        this.listofTasks.Add(item);
    }
    public void showAllItems(bool onlyTitle)
    {
        int i = 1;
        foreach (var item in this.listofTasks)
        {
            Console.WriteLine(i + ". " + item.title);
            if (onlyTitle == false)
            {
                Console.WriteLine(item.description);
                Console.WriteLine(item.completionStatus);
                Console.WriteLine(item.priority);
                Console.WriteLine(item.dueDate);
                Console.WriteLine(item.category);
            }
            i++;
        }
    }
    public void markComplete(int index, bool complete)
    {
        this.listofTasks[index].completionStatus = complete;
    }

    public void removeTask(int index)
    {
        this.listofTasks.RemoveAt(index - 1);
        // this.listofTasks[index].completionStatus = complete;
    }
    // public string showToDo()
    // {
    //     return $@"
    //     Title: {this.title}
    //     description: {this.description}
    //     completed: {(this.completionStatus ? "Finished" : "Unfinished")}

    //     ";
    // }


}