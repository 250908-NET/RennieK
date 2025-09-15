public class TaskBody
{
    public string title { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public bool isCompleted { get; set; }
    public string priority { get; set; } = "low";
    public DateTime dueDate { get; set; } = DateTime.Now;

    public TaskBody()
    {

    }
}