using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.SignalR;

class UserService : IUserService
{
    User CurrentUser { get; set; }
    // UserService UserControl { get; set; }

    List<User> UserDatebase { get; set; }



    public User createUser(string username, string password, string email)
    {
        User newUser = new User(username, password, email);
        return newUser;
    }

    public User? findUserById(int id)
    {
        User? filter = UserDatebase.Find(user => user.id == id);
        if (filter == null) { return null; }
        return filter;

    }
    public void removeUser(int id)
    {
        User? filter = UserDatebase.Find(user => user.id == id);

        if (filter == null) { return; }
        UserDatebase.Remove(filter);
    }

    public User? editUser(UserBody changedUser, int id)
    {
        User? filter = UserDatebase.Find(user => user.id == id);
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
        User? filter = UserDatebase.Find(user => user.username == username);

        if (filter != null && filter.password == password)
        {

            return filter;
        }
        return null;
    }
}