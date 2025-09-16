

abstract class UserBase
{
    public int id { get; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }

    public NoteService Book { get; set; }

    public UserBase()
    {
        this.username = "";
        this.email = "";
        this.password = "";
    }
    public UserBase(string username, string email, string password)
    {
        this.username = username;
        this.email = email;
        this.password = password;
    }

}