using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace chatServer.UsersManager;

public class UserRepository : IUserRepository
{
    private AppDbContext _dbContext;
    
    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IUser?> GetUserByEmailAsync(string email)
    { 
        return await CheckIfUserExists(email);
    }

    public async Task<bool> CreateUserAsync(IUser user)
    {
        var existingUser = await _dbContext.Users.FindAsync(user.Email);
        if (existingUser != null)
            return false;
        var newUser = CreateNewUser(user);
        _dbContext.Users.Add(newUser);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateUserAsync(IUser user)
    {
        var oldUser = await CheckIfUserExists(user.Email);
        if (oldUser == null)
            return false;
        oldUser.FirstName = user.FirstName;
        oldUser.LastName = user.LastName;
        oldUser.Password = user.Password;
        await _dbContext.SaveChangesAsync();
        //TODO UPDATE MASSAGE TABLE FOR NAMES
        return true;
    }

    public async Task<bool> RemoveUserAsync(string email)
    {
        var user = await _dbContext.Users.FindAsync(email);
        if (user == null)
            return false;
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        //todo remove user from all chats
        return true;
    }

    public async Task<IEnumerable<IUser>> GetAllUsersAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }
    
    private async Task <User?> CheckIfUserExists(string email)
    {
        var user = await _dbContext.Users.FindAsync(email);
        return user;
    }

    private static User CreateNewUser(IUser user)
    {
        return new User
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Password = user.Password
        };
    }
}