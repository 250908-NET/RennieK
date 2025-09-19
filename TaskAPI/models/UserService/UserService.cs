using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.SignalR;

class UserService : IUserService
{
    User CurrentUser { get; set; }
    // UserService UserControl { get; set; }
    int numberOfUsers;
    public List<User> UserDatabase { get; set; }

    public UserService()
    {
        this.UserDatabase = new List<User>();
        numberOfUsers = 0;
    }

    public List<User> GetAllUsers()
    {
        return UserDatabase;
    }
    public User createUser(string username, string email, string password)
    {
        User newUser = new User(username, password, email);
        newUser.id = numberOfUsers;
        numberOfUsers++;
        UserDatabase.Add(newUser);
        return newUser;
    }

    public User? findUserById(int id)
    {
        User? filter = UserDatabase.Find(user => user.id == id);
        if (filter == null) { return null; }
        return filter;

    }
    public void removeUser(int id)
    {
        User? filter = UserDatabase.Find(user => user.id == id);

        if (filter == null) { return; }
        UserDatabase.Remove(filter);
    }

    public User? editUser(UserBody changedUser, int id)
    {
        User? filter = UserDatabase.Find(user => user.id == id);
        if (filter != null)
        {
            filter.email = changedUser.email != "" ? changedUser.email : filter.email;
            // filter.password= changedUser.password != "" ? changedUser.email : filter.email;
            filter.username = changedUser.username != "" ? changedUser.username : filter.username;
            return filter;
        }
        return null;


    }

    // if we find a User, we run UserControl
    public User? login(string username, string password)
    {
        User? filter = UserDatabase.Find(user => user.username == username);

        if (filter == null)
        {
            return null;
        }
        if (filter.password != password)
        {
            return null;
        }
        return filter;
    }
}