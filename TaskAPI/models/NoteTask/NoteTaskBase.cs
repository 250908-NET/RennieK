using Microsoft.Net.Http.Headers;
using Microsoft.VisualBasic;

namespace TaskAPI.models.NoteTask;

abstract class NoteTaskBase
{
    private string _title;
    private string _description;
    private bool _isCompleted;
    private string _priority;
    private DateTime _dueDate;
    private string _category;

    public int id { get; set; }
    public string title
    {
        get => _title; set { _title = value; updateAt = DateTime.Now; }
    }
    public string description
    {
        get => _description; set { _description = value; updateAt = DateTime.Now; }
    }
    public bool isCompleted
    {
        get => _isCompleted; set { _isCompleted = value; updateAt = DateTime.Now; }
    }
    public string priority
    {
        get => _priority; set { _priority = value; updateAt = DateTime.Now; }
    }

    public DateTime dueDate
    {
        get => _dueDate; set { _dueDate = value; updateAt = DateTime.Now; }
    }
    public string category
    {
        get => _category; set { _category = value; updateAt = DateTime.Now; }
    }
    public DateTime createdAt { get; set; }
    public DateTime updateAt { get; set; }

    public NoteTaskBase()
    {
        Random randomNumber = new Random();
        this.createdAt = DateTime.Now;
        this.id = randomNumber.Next() + this.createdAt.Microsecond;
        this.title = "UnNamed";
        this.description = "N/A";
        this.isCompleted = false;
        this.priority = "low";
        this.category = "";
        // this.updateAt = DateTime.Now;
    }
    public NoteTaskBase(string title, string description, bool isCompleted, string priority, DateTime duedate)
    {
        Random randomNumber = new Random();
        this.createdAt = DateTime.Now;
        this.id = randomNumber.Next() + this.createdAt.Microsecond;

        this.title = title;
        this.description = description;
        this.isCompleted = isCompleted;
        this.priority = priority;
        this.dueDate = duedate;
        this.createdAt = DateTime.Now;
    }
}