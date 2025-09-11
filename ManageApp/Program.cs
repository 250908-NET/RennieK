// See https://aka.ms/new-console-template for more information
using ManageApp.model;


class Program
{
    ToDoService notebook = new ToDoService();
    public static void showMainMenu(ToDoService notebook)
    {

        Console.WriteLine("1. Add New Item");
        Console.WriteLine("2. View all items");
        Console.WriteLine("3. Mark item complete");
        Console.WriteLine("4. Mark item incomplete");
        Console.WriteLine("5. Delete item");
        Console.WriteLine("6. Exit");
        string value = Console.ReadLine();
        newOptions(value, notebook);
    }
    public static void newOptions(string option, ToDoService notebook)
    {
        switch (option)
        {
            case "1":
                AddNewItemPrompt(notebook);
                break;
            case "2":
                notebook.showAllItems(false);
                break;
            case "3":
                notebook.showAllItems(true);
                Console.WriteLine("Write item number to Mark Complete: ");
                string index = Console.ReadLine();
                itemsToMarkComplete(notebook, int.Parse(index), true);
                break;
            case "4":
                AddNewItemPrompt(notebook);
                break;
            case "5":
                AddNewItemPrompt(notebook);
                break;
            case "6":
                AddNewItemPrompt(notebook);
                break;
        }

    }
    public static void itemsToMarkComplete(ToDoService notebook, int index, bool complete)
    {
        notebook.markComplete(index, complete);
    }
    public static void AddNewItemPrompt(ToDoService notebook)
    {
        ToDoService newItem = new ToDoService();
        Console.WriteLine("Write Title: ");
        string Title = Console.ReadLine();
        Console.WriteLine("Write Description: ");
        string description = Console.ReadLine();
        Console.WriteLine("Write Category: ");
        string category = Console.ReadLine();
        Console.WriteLine("Write Priority: ");
        string Priority = Console.ReadLine();
        newItem.title = Title;
        newItem.description = description;
        newItem.category = category;
        newItem.priority = Priority;

        notebook.addItem(newItem);
    }


    public static void Main()
    {
        ToDoService newItem = new ToDoService();
        showMainMenu(newItem);


    }
}



