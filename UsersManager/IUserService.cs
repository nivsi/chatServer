namespace chatServer.UsersManager;
public interface IUserService
{
    Task<IUser?> GetUserByEmail(string email);
    Task<IUser?> CreateUser(IUser user);
    Task<IUser?> UpdateUser(IUser user);
    Task<bool> RemoveUser(string email);
    
}