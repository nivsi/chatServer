namespace chatServer.UsersManager;
using System.ComponentModel.DataAnnotations;

public class User: IUser
{
    [Key]
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}