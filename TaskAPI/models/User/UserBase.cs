

using System.Text.Json.Serialization;

abstract class UserBase
{
    public int id { get; set; }
    public string username { get; set; }
    public string email { get; set; }

    [JsonIgnore]
    public string password { get; set; }

    public NoteService Book { get; set; }

    public UserBase()
    {
        this.username = "";
        this.email = "";
        this.password = "";
        Book = new NoteService();
    }
    public UserBase(string username, string email, string password)
    {
        this.username = username;
        this.email = email;
        this.password = password;
        Book = new NoteService();
    }

}