// See https://aka.ms/new-console-template for more information
using ManageApp.model;


class Program
{
    ToDoService notebook = new ToDoService();
    bool trueExit = false;
    public static void showMainMenu(ToDoService notebook)
    {

        Console.WriteLine("1. Add New Item");
        Console.WriteLine("2. View all items");
        Console.WriteLine("3. Mark item complete");
        Console.WriteLine("4. Mark item incomplete");
        Console.WriteLine("5. Delete item");
        Console.WriteLine("6. Exit");
        string? value = Console.ReadLine();
        newOptions(value, notebook);
    }
    public static void newOptions(string option, ToDoService notebook)
    {
        bool exit = false;
        switch (option)
        {
            case "1":
                AddNewItemPrompt(notebook);

                break;
            case "2":
                notebook.showAllItems(false);

                break;
            case "3":
                notebook.showAllItems(false);
                Console.WriteLine("Write item number to Mark Complete: ");
                string? index = Console.ReadLine();
                itemsToMarkComplete(notebook, int.Parse(index), true);
                break;
            case "4":
                notebook.showAllItems(false);
                Console.WriteLine("Write item number to Mark Incomplete: ");
                string? newIndex = Console.ReadLine();
                itemsToMarkComplete(notebook, int.Parse(newIndex) - 1, false);
                // AddNewItemPrompt(notebook);
                break;
            case "5":
                // AddNewItemPrompt(notebook);
                notebook.showAllItems(true);
                Console.WriteLine("Remove item: ");
                string? index3 = Console.ReadLine();
                notebook.removeTask(int.Parse(index3));
                break;
            case "6":
                exit = true;
                break;
        }
        if (exit == false)
        {
            showMainMenu(notebook);
        }





    }
    public static void itemsToMarkComplete(ToDoService notebook, int index, bool complete)
    {
        notebook.markComplete(index, complete);
    }
    public static void AddNewItemPrompt(ToDoService notebook)
    {
        Task newItem = new Task();
        Console.WriteLine("Write Title: ");
        string? Title = Console.ReadLine();
        Console.WriteLine("Write Description: ");
        string? description = Console.ReadLine();
        Console.WriteLine("Write Category: ");
        string? category = Console.ReadLine();
        Console.WriteLine("Write Priority: ");
        string? Priority = Console.ReadLine();

        Console.WriteLine("Write duedate in format yyyy-mm-dd hh:mm:ss ");
        string timestring = Console.ReadLine();

        newItem.title = Title;
        newItem.description = description;
        newItem.category = category;
        newItem.priority = Priority;
        DateTime timeKeep = DateTime.Parse(timestring);
        newItem.dueDate = timeKeep;

        notebook.addItem(newItem);
    }


    public static void Main()
    {
        ToDoService notebook = new ToDoService();

        showMainMenu(notebook);


    }
}



