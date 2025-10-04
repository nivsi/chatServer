namespace chatServer.UsersManager;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IUser?> GetUserByEmail(string email)
    {
       return await _userRepository.GetUserByEmailAsync(email);
    }
    
    public async Task<IUser?> CreateUser(IUser user)
    {
        return await _userRepository.CreateUserAsync(user) ? user : null;
    }
    
    public async Task<IUser?> UpdateUser(IUser user)
    {
        return await _userRepository.UpdateUserAsync(user) ? user : null;
    }
    
    public async Task<bool> RemoveUser(string email)
    {
        return await _userRepository.RemoveUserAsync(email);
    }
   


}