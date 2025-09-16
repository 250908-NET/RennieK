using Microsoft.AspNetCore.Identity;

interface IUserService
{
    // User CurrentUser { get; set; }
    // UserService UserControl { get; set; }

    public User createUser(string username, string password, string email);

    public User? findUserById(int id);
    public void removeUser(int id);

    public User? editUser(UserBody changedUser, int id);

    // if we find a User, we run UserControl
    public User? login(string username, string password);




}