using System.Collections.Generic;
using System.Threading.Tasks;

namespace chatServer.UsersManager;
public interface IUserRepository
{
    public Task<IUser?> GetUserByEmailAsync(string email);
    public Task<bool> CreateUserAsync(IUser user);
    public Task<bool> UpdateUserAsync(IUser user);
    public Task<bool> RemoveUserAsync(string email);
    Task<IEnumerable<IUser>> GetAllUsersAsync();

}